﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BotBits.Shop;

namespace BotBits
{
    public static class BlockServices
    {
        private static readonly Dictionary<int, PackAttribute> _blockPacks = new Dictionary<int, PackAttribute>();
        private static readonly Dictionary<int, Type> _blockGroups = new Dictionary<int, Type>();
        private static readonly Dictionary<Smiley, PackAttribute> _smileyPacks = new Dictionary<Smiley, PackAttribute>();

        static BlockServices()
        {
            LoadPacks(typeof(Background));
            LoadPacks(typeof(Foreground));
            LoadSmileys(typeof(Smiley));
        }

        public static Type GetGroup(int id)
        {
            Type type;
            _blockGroups.TryGetValue(id, out type);
            return type;
        }

        internal static PackAttribute GetPackageInternal(int id)
        {
            PackAttribute pack;
            _blockPacks.TryGetValue(id, out pack);
            return pack;
        }

        public static string GetPackage(int id)
        {
            PackAttribute pack;
            _blockPacks.TryGetValue(id, out pack);
            return pack != null 
                ? pack.Package 
                : null;
        }

        public static int GetBlocksPerPackage(int id)
        {
            PackAttribute pack;
            _blockPacks.TryGetValue(id, out pack);
            return pack != null
                ? pack.BlocksPerPack
                : 0;
        }

        public static string GetPackage(Smiley id)
        {
            PackAttribute pack;
            _smileyPacks.TryGetValue(id, out pack);
            return pack != null
                ? pack.Package
                : null;
        }

        static void LoadPacks(Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var value = (ushort)field.GetValue(null);
                _blockGroups[value] = type;

                var pack = GetPack(field);
                if (pack != null)
                    _blockPacks.Add(value, pack);
            }

            foreach (var i in type.GetNestedTypes())
            {
                LoadPacks(i);
            }
        }
        

        static void LoadSmileys(Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var pack = GetPack(field);
                if (pack != null)
                {
                    _smileyPacks.Add((Smiley)field.GetValue(null), pack);
                }
            }

            foreach (var i in type.GetNestedTypes())
            {
                LoadPacks(i);
            }
        }

        static PackAttribute GetPack(ICustomAttributeProvider provider)
        {
            return (PackAttribute)provider
                .GetCustomAttributes(typeof(PackAttribute), false)
                .FirstOrDefault();
        }
    }
}
