using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BotBits
{
    public static class ItemServices
    {
        private static readonly ConcurrentDictionary<SmileyShape, PackAttribute> _smileyShapePacks = new ConcurrentDictionary<SmileyShape, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyColour, PackAttribute> _smileyColourPacks = new ConcurrentDictionary<SmileyColour, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyBorder, PackAttribute> _smileyBorderPacks = new ConcurrentDictionary<SmileyBorder, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyEyes, PackAttribute> _smileyEyesPacks = new ConcurrentDictionary<SmileyEyes, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyMouth, PackAttribute> _smileyMouthPacks = new ConcurrentDictionary<SmileyMouth, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyAddon, PackAttribute> _smileyAddonPacks = new ConcurrentDictionary<SmileyAddon, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyAbove, PackAttribute> _smileyAbovePacks = new ConcurrentDictionary<SmileyAbove, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyBelow, PackAttribute> _smileyBelowPacks = new ConcurrentDictionary<SmileyBelow, PackAttribute>();
        private static readonly ConcurrentDictionary<SmileyWings, PackAttribute> _smileyWingsPacks = new ConcurrentDictionary<SmileyWings, PackAttribute>();
        private static readonly ConcurrentDictionary<AuraColor, PackAttribute> _auraColorPacks = new ConcurrentDictionary<AuraColor, PackAttribute>();
        private static readonly ConcurrentDictionary<AuraShape, PackAttribute> _auraShapePacks = new ConcurrentDictionary<AuraShape, PackAttribute>();
        private static readonly ConcurrentDictionary<int, PackAttribute> _blockPacks = new ConcurrentDictionary<int, PackAttribute>();
        private static readonly Dictionary<int, Type> _blockGroups = new Dictionary<int, Type>();

        static ItemServices()
        {
            LoadPacks(typeof(Background));
            LoadPacks(typeof(Foreground));
            LoadEnum(_smileyShapePacks);
            LoadEnum(_smileyColourPacks);
            LoadEnum(_smileyBorderPacks);
            LoadEnum(_smileyEyesPacks);
            LoadEnum(_smileyMouthPacks);
            LoadEnum(_smileyAddonPacks);
            LoadEnum(_smileyAbovePacks);
            LoadEnum(_smileyBelowPacks);
            LoadEnum(_smileyWingsPacks);
            LoadEnum(_auraColorPacks);
            LoadEnum(_auraShapePacks);
        }

        public static Type GetGroup(Foreground.Id id)
        {
            if (id == 0) return typeof(Foreground);
            return GetGroup((int)id);
        }

        public static Type GetGroup(Background.Id id)
        {
            if (id == 0) return typeof(Background);
            return GetGroup((int)id);
        }

        public static KeyValuePair<int, Type>[] GetGroups()
        {
            return _blockGroups.ToArray();
        }

        public static PackAttribute GetPackage(AuraShape id)
        {
            PackAttribute pack;
            _auraShapePacks.TryGetValue(id, out pack);
            return pack;
        }

        public static PackAttribute GetPackage(AuraColor id)
        {
            PackAttribute pack;
            _auraColorPacks.TryGetValue(id, out pack);
            return pack;
        }

        public static PackAttribute GetPackage(SmileyShape id)
        {
            PackAttribute pack;
            _smileyShapePacks.TryGetValue(id, out pack);
            return pack;
        }

        public static PackAttribute GetPackage(SmileyColour id)
        {
            PackAttribute pack;
            _smileyColourPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyBorder id)
        {
            PackAttribute pack;
            _smileyBorderPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyEyes id)
        {
            PackAttribute pack;
            _smileyEyesPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyMouth id)
        {
            PackAttribute pack;
            _smileyMouthPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyAbove id)
        {
            PackAttribute pack;
            _smileyAbovePacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyBelow id)
        {
            PackAttribute pack;
            _smileyBelowPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyAddon id)
        {
            PackAttribute pack;
            _smileyAddonPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(SmileyWings id)
        {
            PackAttribute pack;
            _smileyWingsPacks.TryGetValue(id, out pack);
            return pack;
        }
        public static PackAttribute GetPackage(Foreground.Id id)
        {
            return GetPackageInternal((int)id);
        }

        public static PackAttribute GetPackage(Background.Id id)
        {
            return GetPackageInternal((int)id);
        }

        public static void SetPackage(AuraShape id, PackAttribute package)
        {
            _auraShapePacks[id] = package;
        }

        public static void SetPackage(AuraColor id, PackAttribute package)
        {
            _auraColorPacks[id] = package;
        }

        public static void SetPackage(SmileyShape id, PackAttribute package)
        {
            _smileyShapePacks[id] = package;
        }

        public static void SetPackage(SmileyColour id, PackAttribute package)
        {
            _smileyColourPacks[id] = package;
        }

        public static void SetPackage(SmileyBorder id, PackAttribute package)
        {
            _smileyBorderPacks[id] = package;
        }
        public static void SetPackage(SmileyEyes id, PackAttribute package)
        {
            _smileyEyesPacks[id] = package;
        }

        public static void SetPackage(SmileyMouth id, PackAttribute package)
        {
            _smileyMouthPacks[id] = package;
        }

        public static void SetPackage(SmileyAddon id, PackAttribute package)
        {
            _smileyAddonPacks[id] = package;
        }
        public static void SetPackage(SmileyAbove id, PackAttribute package)
        {
            _smileyAbovePacks[id] = package;
        }

        public static void SetPackage(SmileyBelow id, PackAttribute package)
        {
            _smileyBelowPacks[id] = package;
        }

        public static void SetPackage(SmileyWings id, PackAttribute package)
        {
            _smileyWingsPacks[id] = package;
        }
        public static void SetPackage(Foreground.Id id, PackAttribute package)
        {
            SetPackageInternal((int)id, package);
        }

        public static void  SetPackage(Background.Id id, PackAttribute package)
        {
            SetPackageInternal((int)id, package);
        }

        internal static void SetPackageInternal(int id, PackAttribute package)
        {
            _blockPacks[id] = package;
        }

        internal static PackAttribute GetPackageInternal(int id)
        {
            PackAttribute pack;
            _blockPacks.TryGetValue(id, out pack);
            return pack;
        }

        private static void LoadPacks(Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var value = (ushort)field.GetValue(null);
                try
                {
                    if (value != 0)
                        _blockGroups.Add(value, type);

                    var pack = GetPack(field);
                    if (pack != null)
                    {
                        var result = _blockPacks.TryAdd(value, pack);
                        Debug.Assert(result); // _blockGroups.Add must fail if the value is duplicate
                    }
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidOperationException("Duplicate block: " + value, ex);
                }
            }

            foreach (var i in type.GetNestedTypes())
            {
                LoadPacks(i);
            }
        }


        private static void LoadEnum<T>(ConcurrentDictionary<T, PackAttribute> collection)
        {
            foreach (var field in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var pack = GetPack(field);
                if (pack != null)
                {
                    var result = collection.TryAdd((T)field.GetValue(null), pack); 
                    Debug.Assert(result); // Enums employ a compile time uniqueness check
                }
            }
        }

        private static PackAttribute GetPack(ICustomAttributeProvider provider)
        {
            return (PackAttribute)provider
                .GetCustomAttributes(typeof(PackAttribute), false)
                .FirstOrDefault();
        }

        private static Type GetGroup(int id)
        {
            Type type;
            _blockGroups.TryGetValue(id, out type);
            return type;
        }
    }
}