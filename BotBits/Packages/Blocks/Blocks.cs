﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;
using Yonom.EE;

namespace BotBits
{
    public sealed class Blocks : EventListenerPackage<Blocks>, IBlockAreaEnumerable,
        IReadOnlyWorld<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>
    {
        private BlockDataWorld _blockDataWorld;
        private ReadOnlyBlocksWorld _readOnlyBlocksWorld;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Blocks()
        {
            this.World = new BlockDataWorld(0, 0);
        }

        private BlockDataWorld World
        {
            get => this._blockDataWorld;
            set
            {
                this._blockDataWorld = value;
                this._readOnlyBlocksWorld = new ReadOnlyBlocksWorld(this._blockDataWorld);
            }
        }
        public IEnumerator<BlocksItem> GetEnumerator()
        {
            DiagnosticServices.GetEnumerator<Blocks>(this.BotBits);

            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        Blocks IBlockAreaEnumerable.Blocks => this;

        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);

        public int Height => this._blockDataWorld.Height;

        public int Width => this._blockDataWorld.Width;

        public IReadOnlyBlockLayer<BlockData<ForegroundBlock>> Foreground => this._readOnlyBlocksWorld.Foreground;

        public IReadOnlyBlockLayer<BlockData<BackgroundBlock>> Background => this._readOnlyBlocksWorld.Background;

        public void Place(int x, int y, BackgroundBlock block)
        {
            new PlaceSendMessage(Layer.Background, x, y, (int)block.Id)
                .SendIn(this.BotBits);
        }

        public void Place(int x, int y, ForegroundBlock block)
        {
            new PlaceSendMessage(Layer.Foreground, x, y, (int)block.Id, block.GetArgs())
                .SendIn(this.BotBits);
        }
        
        public Task FinishSendAsync()
        {
            return PlaceSendMessage.Of(this.BotBits).FinishQueueAsync()
                .Then(tsk => BlockChecker.Of(this.BotBits).FinishChecksAsync())
                .ToSafeTask();
        }

        [EventListener]
        private void On(InitEvent e)
        {
            this.World = GetWorld(e.PlayerIOMessage, e.WorldWidth, e.WorldHeight);
        }

        [EventListener(EventPriority.Low)]
        private void OnLow(InitEvent e)
        {
            new WorldResizeEvent(e.WorldWidth, e.WorldHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void On(LoadLevelEvent e)
        {
            this.World = GetWorld(e.PlayerIOMessage, this.Width, this.Height);
        }

        [EventListener]
        private void On(ClearEvent e)
        {
            this.World = GetClearedWorld(e.RoomWidth, e.RoomHeight, e.BorderBlock);
            new WorldResizeEvent(e.RoomWidth, e.RoomHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void On(BlockPlaceEvent e)
        {
            if (this.Height <= e.Y || this.Width <= e.X)
                return;

            switch (e.Layer)
            {
                case Layer.Foreground:
                    this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id);
                    break;

                case Layer.Background:
                    this.RaiseBackground(e.Player, e.X, e.Y, new BackgroundBlock((Background.Id)e.Id));
                    break;
            }
        }

        [EventListener]
        private void On(PortalPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.PortalRotation, e.PortalId, e.PortalTarget);
        }

        [EventListener]
        private void On(CoinDoorPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.CoinsToOpen);
        }

        [EventListener]
        private void On(MorphablePlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.Rotation);
        }

        [EventListener]
        private void On(SoundPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.SoundId);
        }

        [EventListener]
        private void On(NPCPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.Name,e.Message1,e.Message2,e.Message3);
        }

        [EventListener]
        private void On(WorldPortalPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.WorldPortalTarget,e.Id);
        }

        [EventListener]
        private void On(LabelPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.Text, e.TextColor, e.WrapWidth);
        }

        [EventListener]
        private void On(SignPlaceEvent e)
        {
            this.RaiseForegroundData(e.Player, e.X, e.Y, (Foreground.Id)e.Id, e.Text, e.SignColor);
        }

        private void RaiseForegroundData(Player player, int x, int y, Foreground.Id block, params object[] args)
        {
            var fgWorldBlock = WorldUtils.GetForegroundFromArgs(block, args);
            this.RaiseForeground(player, x, y, fgWorldBlock);
        }
        
        private void RaiseForeground(Player player, int x, int y, ForegroundBlock newBlock)
        {
            var newData = new BlockData<ForegroundBlock>(player, newBlock);
            BlockData<ForegroundBlock> oldData;
            lock (this.World.Foreground)
            {
                oldData = this.World.Foreground[x, y];
                this.World.Foreground[x, y] = newData;
            }

            new ForegroundPlaceEvent(x, y, oldData, newData)
                .RaiseIn(this.BotBits);
        }

        private void RaiseBackground(Player player, int x, int y, BackgroundBlock newBlock)
        {
            var newData = new BlockData<BackgroundBlock>(player, newBlock);
            BlockData<BackgroundBlock> oldData;
            lock (this.World.Foreground)
            {
                oldData = this.World.Background[x, y];
                this.World.Background[x, y] = newData;
            }

            new BackgroundPlaceEvent(x, y, oldData, newData)
                .RaiseIn(this.BotBits);
        }

        private static BlockDataWorld GetWorld(Message m, int width, int height)
        {
            var world = new BlockDataWorld(width, height);
            var datas = m.Type == "init" ? InitParse.Parse(m.GetByteArray(49)) : InitParse.Parse(m.GetByteArray(1));
            foreach (var data in datas)
            {
                var block = data.Type;
                var l = (Layer)data.Layer;

                switch (l)
                {
                    case Layer.Background:
                        var bgWorldBlock = new BackgroundBlock((Background.Id)block);
                        var bg = new BlockData<BackgroundBlock>(bgWorldBlock);
                        foreach (var pos in data.Locations)
                            world.Background[pos.X, pos.Y] = bg;
                        break;

                    case Layer.Foreground:
                        var fgWorldBlock = WorldUtils.GetForegroundFromArgs((Foreground.Id)block, data.Args);
                        var fg = new BlockData<ForegroundBlock>(fgWorldBlock);
                        foreach (var pos in data.Locations)
                            world.Foreground[pos.X, pos.Y] = fg;
                        break;
                }
            }

            return world;
        }

        private static BlockDataWorld GetClearedWorld(int width, int height, Foreground.Id borderBlock)
        {
            var world = new BlockDataWorld(width, height);
            WorldUtils.DrawBorder(world, new BlockData<ForegroundBlock>(new ForegroundBlock(borderBlock)));
            return world;
        }

        public ProxyWorld GetProxyWorld()
        {
            return new ProxyWorld(this);
        }

        public ExpectedData<ForegroundBlock> GetExpectedForeground(Point p)
        {
            var expected = BlockChecker.Of(this.BotBits).GetExpectedForeground(p);
            return expected.HasValue 
                ? new ExpectedData<ForegroundBlock>(Player.Nobody, expected.Value, true)
                : new ExpectedData<ForegroundBlock>(this.Foreground[p].Placer, this.Foreground[p].Block, false);
        }

        public ExpectedData<BackgroundBlock> GetExpectedBackground(Point p)
        {
            var expected = BlockChecker.Of(this.BotBits).GetExpectedBackground(p);
            return expected.HasValue
                ? new ExpectedData<BackgroundBlock>(Player.Nobody, expected.Value, true)
                : new ExpectedData<BackgroundBlock>(this.Foreground[p].Placer, this.Background[p].Block, false);
        }
    }
    public class DataChunk
    {
        public int Layer { get; set; }
        public uint Type { get; set; }
        public Point[] Locations { get; set; }
        public object[] Args { get; set; }

        public DataChunk(int layer, uint type, byte[] xs, byte[] ys, object[] args)
        {
            Layer = layer;
            Type = type;
            Args = args;
            Locations = GetLocations(xs, ys);
        }

        private static Point[] GetLocations(byte[] xs, byte[] ys)
        {
            var points = new List<Point>();
            for (var i = 0; i < xs.Length; i += 2) points.Add(new Point((xs[i] << 8) | xs[i + 1], (ys[i] << 8) | ys[i + 1]));
            return points.ToArray();

        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    public class Block
    {
        public int id { get; set; }

        public int x, y, layer;
        public object[] args { get; set; }
        public Block(int blockID, params object[] args)
        {
            this.id = blockID;
            this.args = args;
        }
    }

}