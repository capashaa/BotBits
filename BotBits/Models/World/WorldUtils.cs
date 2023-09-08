﻿using System;
using System.Collections.Generic;
using System.Linq;
using BotBits.Events;
using BotBits.SendMessages;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public static class WorldUtils
    {
        public static WorldType GetLegacyWorldType(int width, int height)
        {
            if (width == 25 && height == 25) return WorldType.Small;
            if (width == 40 && height == 30) return WorldType.HomeWorld;
            if (width == 50 && height == 50) return WorldType.Medium;
            if (width == 100 && height == 100) return WorldType.Large;
            if (width == 200 && height == 200) return WorldType.Massive;
            if (width == 400 && height == 50) return WorldType.Wide;
            if (width == 400 && height == 200) return WorldType.Great;
            if (width == 100 && height == 400) return WorldType.Tall;
            if (width == 636 && height == 50) return WorldType.UltraWide;
            if (width == 150 && height == 25) return WorldType.Tutorial;
            if (width == 110 && height == 110) return WorldType.MoonLarge;
            if (width == 300 && height == 300) return WorldType.Huge;
            if (width == 200 && height == 400) return WorldType.VerticalGreat;
            if (width == 150 && height == 150) return WorldType.Big;
            return WorldType.Unknown;
        }

        public static Size GetWorldSize(WorldType type)
        {
            switch (type)
            {
                case WorldType.Small:
                    return new Size(25, 25);

                case WorldType.HomeWorld:
                    return new Size(40, 30);

                case WorldType.Medium:
                    return new Size(50, 50);

                case WorldType.Large:
                    return new Size(100, 100);

                case WorldType.Massive:
                    return new Size(200, 200);

                case WorldType.Wide:
                    return new Size(400, 50);

                case WorldType.Great:
                    return new Size(400, 200);

                case WorldType.Tall:
                    return new Size(100, 400);

                case WorldType.UltraWide:
                    return new Size(636, 50);

                case WorldType.MoonLarge:
                    return new Size(110, 110);

                case WorldType.Tutorial:
                    return new Size(150, 25);

                case WorldType.Huge:
                    return new Size(300, 300);

                case WorldType.VerticalGreat:
                    return new Size(200, 400);
                    
                case WorldType.Big:
                    return new Size(150, 150);

                default:
                    throw new NotSupportedException("Unknown world type!");
            }
        }

        public static ForegroundBlock GetForegroundFromDatabase(DatabaseObject obj, Foreground.Id foreground)
        {
            var foregroundType = GetForegroundType(foreground);

            switch (foregroundType)
            {
                case ForegroundType.Normal:
                    return new ForegroundBlock(foreground);

                case ForegroundType.Note:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("id", 0));

                case ForegroundType.Goal:
                case ForegroundType.Toggle:
                case ForegroundType.ToggleGoal:
                case ForegroundType.Team:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("goal", 0));

                case ForegroundType.Morphable:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("rotation", 0));

                case ForegroundType.Portal:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("id", 0),
                        obj.GetUInt("target", 0),
                        (Morph.Id)obj.GetUInt("rotation", 0));

                case ForegroundType.WorldPortal:
                    return new ForegroundBlock(foreground,
                        obj.GetString("target"));

                case ForegroundType.Label:
                    return new ForegroundBlock(foreground,
                        obj.GetString("text", "no text found"),
                        obj.GetString("text_color", "#FFFFFF"),
                        obj.GetUInt("wrapWidth", 200));

                case ForegroundType.Sign:
                    return new ForegroundBlock(foreground,
                        obj.GetString("text", "No text found."),
                        (Morph.Id)obj.GetUInt("signtype", 0));

                default:
                    throw new NotSupportedException("Encountered an unsupported block!");
            }
        }

        public static BlockArgsType GetBlockArgsType(ForegroundType type)
        {
            switch (type)
            {
                case ForegroundType.Normal:
                    return BlockArgsType.None;

                case ForegroundType.Goal:
                case ForegroundType.Toggle:
                case ForegroundType.ToggleGoal:
                case ForegroundType.Morphable:
                case ForegroundType.Team:
                case ForegroundType.Note:
                    return BlockArgsType.Number;

                case ForegroundType.WorldPortal:
                    return BlockArgsType.String;

                case ForegroundType.Portal:
                    return BlockArgsType.Portal;

                case ForegroundType.Label:
                    return BlockArgsType.Label;

                case ForegroundType.Sign:
                    return BlockArgsType.Sign;
                case ForegroundType.NPC:
                    return BlockArgsType.NPC;
                default:
                    throw new ArgumentException("Invalid BlockType.", nameof(type));
            }
        }

        public static ForegroundBlock GetForegroundFromArgs(Foreground.Id block, object[] args)
        {
            var foregroundType = GetBlockArgsType(GetForegroundType(block));

            switch (foregroundType)
            {
                case BlockArgsType.None:
                {
                    return new ForegroundBlock(block);
                }

                case BlockArgsType.Number:
                {
                    switch (args[0])
                    {
                        case int si:
                            return new ForegroundBlock(block, si);
                        case uint i:
                            return new ForegroundBlock(block, i);

                        default:
                            throw new ArgumentException("Unsupported numeral type.", nameof(args));
                    }
                }

                case BlockArgsType.String:
                {
                    var str = Convert.ToString(args[0]);
                    return new ForegroundBlock(block, str);
                }

                case BlockArgsType.Portal:
                {
                    var portalRotation = (Morph.Id)Convert.ToUInt32(args[0]);
                    var portalId = Convert.ToUInt32(args[1]);
                    var portalTarget = Convert.ToUInt32(args[2]);
                    return new ForegroundBlock(block, portalId, portalTarget, portalRotation);
                }

                case BlockArgsType.Label:
                {
                    var text = Convert.ToString(args[0]);
                    var textcolor = Convert.ToString(args[1]);
                    var wrapWidth = Convert.ToUInt32(args[2]);
                    return new ForegroundBlock(block, text, textcolor, wrapWidth);
                }

                case BlockArgsType.Sign:
                {
                    var text = Convert.ToString(args[0]);
                    var color = (Morph.Id)Convert.ToUInt32(args[1]);
                    return new ForegroundBlock(block, text, color);
                }
                case BlockArgsType.NPC:
                    {
                        var name = Convert.ToString(args[0]);
                        var message1 = Convert.ToString(args[1]);
                        var message2 = Convert.ToString(args[2]);
                        var message3 = Convert.ToString(args[3]);
                        return new ForegroundBlock(block, name, message1, message2, message3);
                    }
                default:
                    throw new ArgumentException("Invalid block.", nameof(block));
            }
        }

        internal static ArgumentException GetMissingArgsErrorMessage(BlockArgsType type, [InvokerParameterName] string paramName)
        {
            switch (type)
            {
                case BlockArgsType.None:
                    return new ArgumentException("That block doesn't accept any extra parameters!", paramName);
                case BlockArgsType.Number:
                    return new ArgumentException("That block needs a number as its parameter.", paramName);
                case BlockArgsType.String:
                    return new ArgumentException("That block needs a string as its parameter.", paramName);
                case BlockArgsType.Sign:
                    return new ArgumentException("Sign blocks need a string followed by a sign morph (Morph.Sign).", paramName);
                case BlockArgsType.Portal:
                    return new ArgumentException("Portal blocks require three parameters in the following order: id (int) target (int) rotation (Morph.Portal).", paramName);
                case BlockArgsType.Label:
                    return new ArgumentException("Label blocks require two parameters in the following order: text (string) hex color (string).", paramName);
                default:
                    return new ArgumentException("Invalid arguments for the given block!", paramName);
            }
        }

        public static ForegroundType GetForegroundType(Foreground.Id id)
        {
            var package = ItemServices.GetPackageInternal((int)id);
            return package?.ForegroundType ?? ForegroundType.Normal;
        }

        public static void DrawBorder<TForeground, TBackground>
            (World<TForeground, TBackground> world, TForeground borderBlock)
            where TForeground : struct
            where TBackground : struct
        {
            var maxX = world.Width - 1;
            var maxY = world.Height - 1;
            for (var y = 0; y <= maxY; y++)
            {
                world.Foreground[0, y] = borderBlock;
                world.Foreground[maxX, y] = borderBlock;
            }
            for (var x = 0; x <= maxX; x++)
            {
                world.Foreground[x, 0] = borderBlock;
                world.Foreground[x, maxY] = borderBlock;
            }
        }

        public static int PosToBlock(double pos)
        {
            return (int)pos + 8 >> 4;
        }

        public static bool IsAlreadyPlaced(PlaceSendMessage sent, Blocks world)
        {
            switch (sent.Layer)
            {
                case Layer.Foreground:
                    var fg = world.Foreground[sent.X, sent.Y];
                    return sent.Id == (int)fg.Block.Id &&
                           sent.Args.SequenceEqual(fg.Block.GetArgs());
                case Layer.Background:
                    var bg = world.Background[sent.X, sent.Y];
                    return sent.Id == (int)bg.Block.Id;
                default:
                    throw new NotSupportedException("Unknown layer.");
            }
        }

        internal static bool AreSame<T, TBlock>(PlaceSendMessage sent, T received)
            where T : PlaceEvent<T, TBlock>
            where TBlock : struct
        {
            var bg = received as BackgroundPlaceEvent;
            if (bg != null) return AreSame(sent, bg);
            var fg = received as ForegroundPlaceEvent;
            if (fg != null) return AreSame(sent, fg);

            throw new NotSupportedException("Unknown PlaceEvent.");
        }


        internal static bool AreSame(PlaceSendMessage sent, ForegroundPlaceEvent received)
        {
            return sent.Id == (int)received.New.Block.Id &&
                   sent.Args.SequenceEqual(received.New.Block.GetArgs());
        }

        internal static bool AreSame(PlaceSendMessage sent, BackgroundPlaceEvent received)
        {
            return sent.Id == (int)received.New.Block.Id;
        }

        internal static bool AreSame(PlaceSendMessage b1, PlaceSendMessage b2)
        {
            return b1.Id == b2.Id && b1.Args.SequenceEqual(b2.Args);
        }

        public static bool IsPlaceable<TForeground, TBackground>
            (PlaceSendMessage p, IReadOnlyWorld<TForeground, TBackground> world)
            where TForeground : struct
            where TBackground : struct
        {
            return p.X >= 0 && p.Y >= 0 && p.X < world.Width && p.Y < world.Height;
        }

        internal static IEnumerable<Point> GetPos(byte[] byteArrayX, byte[] byteArrayY)
        {
            for (var i = 0; i <= byteArrayX.Length - 1; i += 2)
            {
                var x = byteArrayX[i] * 256 + byteArrayX[i + 1];
                var y = byteArrayY[i] * 256 + byteArrayY[i + 1];

                yield return new Point(x, y);
            }
        }

        internal static IEnumerable<Point> GetShortPos(byte[] byteArrayX, byte[] byteArrayY)
        {
            for (var i = 0; i <= byteArrayX.Length - 1; i++)
            {
                int x = byteArrayX[i];
                int y = byteArrayY[i];

                yield return new Point(x, y);
            }
        }
    }
}