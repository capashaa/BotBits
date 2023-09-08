using System;
using System.ComponentModel;
using System.Threading.Tasks;
using PlayerIOClient;
namespace BotBits
{
    public class PlayerData
    {
        public PlayerObject PlayerObject { get; }

        public DatabaseObject DatabaseObject { get; }

        public PlayerData(PlayerObject playerObject, ShopData shopData)
        {
            this.PlayerObject = playerObject;
            this.ShopData = shopData;
        }
        public ShopData ShopData { get; }

        //public bool BetaMember => this.ShopData.GetCount("pro") > 0 || this.PlayerObject.OldBetaMember;

        public bool HasSmileyShape(SmileyShape smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyColour(SmileyColour smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyBorder(SmileyBorder smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyEyes(SmileyEyes smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }
        public bool HasSmileyMouth(SmileyMouth smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyAddon(SmileyAddon smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyAbove(SmileyAbove smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }
        public bool HasSmileyBelow(SmileyBelow smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasSmileyWings(SmileyWings smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }
        public bool HasAuraColor(AuraColor auraColor)
        {
            return this.HasPack(ItemServices.GetPackage(auraColor));
        }

        public bool HasAuraShape(AuraShape auraShape)
        {
            return this.HasPack(ItemServices.GetPackage(auraShape));
        }

        internal bool HasBlockInternal(Foreground.Id id)
        {
            return this.HasPack(ItemServices.GetPackage(id));
        }

        internal bool HasBlockInternal(Background.Id id)
        {
            return this.HasPack(ItemServices.GetPackage(id));
        }

        internal bool HasBlockInternal(int id)
        {
            return this.HasPack(ItemServices.GetPackageInternal(id));
        }

        private bool HasPack(PackAttribute pack)
        {
            if (pack?.Package == null) return true;
            if (pack.AdminOnly) return true; // return this.PlayerObject.Administrator;
            if (pack.GoldMembershipItem) return true; // return this.PlayerObject.GoldMember;
            return this.ShopData.GetCount(pack.Package) > 0;

        }
    }
}