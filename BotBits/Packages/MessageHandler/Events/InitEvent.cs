using PlayerIOClient;
using System;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when the player initially joins the room. Contains world information such as title and world content.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("init")]
    public sealed class InitEvent : PlayerEvent<InitEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InitEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal InitEvent(BotBitsClient client, Message message)
            : base(client, message, 5, true)
        {
            this.Owner = message.GetString(0);
            this.WorldName = message.GetString(1);
            this.Plays = message.GetInt(2);
            this.Favorites = message.GetInt(3);
            this.Likes = message.GetInt(4);
            // 5: UserId
            this.SmileyShape = (SmileyShape)message.GetInt(6);
            this.SmileyColour = (SmileyColour)message.GetInt(7);
            this.SmileyBorder = message.GetInt(8);
            this.SmileyEyes = (SmileyEyes)message.GetInt(9);
            this.SmileyMouth = (SmileyMouth)message.GetInt(10);
            this.SmileyAddon = (SmileyAddon)message.GetInt(11);
            this.SmileyAbove = (SmileyAbove)message.GetInt(12);
            this.SmileyBelow = (SmileyBelow)message.GetInt(13);
            this.SmileyWings = (SmileyWings)message.GetInt(14);
            this.AuraShape = (AuraShape)message.GetInt(15);
            this.AuraColor = (AuraColor)message.GetInt(16);
            //this.GoldBorder = message.GetBoolean(17);
            this.SpawnX = message.GetDouble(17);
            this.SpawnY = message.GetDouble(18);
            this.ChatColor = message.GetUInt(19);
            this.Username = message.GetString(20);
            this.CanEdit = message.GetBoolean(21);
            this.IsOwner = message.GetBoolean(22);
            this.Favorited = message.GetBoolean(23);
            this.Liked = message.GetBoolean(24);
            this.WorldWidth = message.GetInt(25);
            this.WorldHeight = message.GetInt(26);
            this.GravityMultiplier = message.GetDouble(27);
            this.BackgroundColor = message.GetUInt(28);
            this.Visible = message.GetBoolean(29);
            this.HideLobby = message.GetBoolean(30);
            this.AllowSpectating = message.GetBoolean(31);
            this.RoomDescription = message.GetString(32);
            this.CurseLimit = message.GetInt(33);
            this.ZombieLimit = message.GetInt(34);
            this.Campaign = message.GetBoolean(35);
            this.CrewId = message.GetString(36);
            this.CrewName = message.GetString(37);
            this.CanChangeWorldOptions = message.GetBoolean(38);
            this.WorldStatus = (WorldStatus)message.GetInt(39);
            this.Badge = message.GetBadge(40);
            this.CrewMember = message.GetBoolean(41);
            this.MinimapEnabled = message.GetBoolean(42);
            this.LobbyPreviewEnabled = message.GetBoolean(43);
            this.OrangeSwitches = VarintHelper.ToInt32Array(message.GetByteArray(44));
            this.FriendsOnly = message.GetBoolean(45);
            this.OwnerConnectUserId = message.GetString(46);
            this.CanToggleGodMode = message.GetBoolean(47);
        }

        public bool FriendsOnly { get; set; }
        public string OwnerConnectUserId { get; set; }
        public bool CanToggleGodMode { get; }
        public bool GoldBorder { get; set; }

        public int[] OrangeSwitches { get; set; }

        public AuraColor AuraColor { get; set; }

        public bool LobbyPreviewEnabled { get; set; }

        public bool MinimapEnabled { get; set; }

        public bool CrewMember { get; set; }

        public WorldStatus WorldStatus { get; set; }

        public Badge Badge { get; set; }

        public bool CanChangeWorldOptions { get; set; }

        public string CrewName { get; set; }

        public string CrewId { get; set; }

        public bool Campaign { get; set; }

        public bool Liked { get; set; }

        public bool Favorited { get; set; }

        public int ZombieLimit { get; set; }

        public int CurseLimit { get; set; }

        public string RoomDescription { get; set; }

        public bool AllowSpectating { get; set; }

        public uint ChatColor { get; set; }

        public bool HideLobby { get; set; }

        public AuraShape AuraShape { get; set; }

        /// <summary>
        ///     Gets or sets the smiley shape
        /// </summary>
        /// <value>The Smiley Shape</value>
        public SmileyShape SmileyShape { get; set; }

        /// <summary>
        ///     Gets or sets the smiley colour
        /// </summary>
        /// <value>The Smiley Colour</value>
        public SmileyColour SmileyColour { get; set; }

        /// <summary>
        ///     Gets or sets the smiley border
        /// </summary>
        /// <value>The Smiley Border</value>
        public int SmileyBorder { get; set; }

        /// <summary>
        ///     Gets or sets the smiley eyes
        /// </summary>
        /// <value>The Smiley Eyes</value>
        public SmileyEyes SmileyEyes { get; set; }

        /// <summary>
        ///     Gets or sets the smiley mouth
        /// </summary>
        /// <value>The Smiley Mouth</value>
        public SmileyMouth SmileyMouth { get; set; }

        /// <summary>
        ///     Gets or sets the smiley addon
        /// </summary>
        /// <value>The Smiley Addon</value>
        public SmileyAddon SmileyAddon { get; set; }
        /// <summary>
        ///     Gets or sets the smiley above
        /// </summary>
        /// <value>The Smiley Above look</value>
        public SmileyAbove SmileyAbove { get; set; }

        /// <summary>
        ///     Gets or sets the smiley below
        /// </summary>
        /// <value>The Smiley Below look</value>
        public SmileyBelow SmileyBelow { get; set; }

        /// <summary>
        ///     Gets or sets the smiley wings
        /// </summary>
        /// <value>The Smiley Wings</value>
        public SmileyWings SmileyWings { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InitEvent" /> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        /// <summary>
        ///     Gets or sets the color of the background.
        /// </summary>
        /// <value>
        ///     The color of the background.
        /// </value>
        public uint BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is allowed to edit.
        /// </summary>
        /// <value><c>true</c> if this instance can edit; otherwise, <c>false</c>.</value>
        public bool CanEdit { get; set; }

        /// <summary>
        ///     Gets or sets the gravity of the world.
        /// </summary>
        /// <value>The gravity.</value>
        public double GravityMultiplier { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this player owns the world.
        /// </summary>
        /// <value><c>true</c> if this player is the owner; otherwise, <c>false</c>.</value>
        public bool IsOwner { get; set; }

        /// <summary>
        ///     Gets or sets the width of the world.
        /// </summary>
        /// <value>The width of the room.</value>
        public int WorldWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of the world.
        /// </summary>
        /// <value>The height of the room.</value>
        public int WorldHeight { get; set; }

        /// <summary>
        ///     Gets or sets the spawn x coordinate.
        /// </summary>
        /// <value>The spawn x.</value>
        public double SpawnX { get; set; }

        /// <summary>
        ///     Gets or sets the spawn y coordinate.
        /// </summary>
        /// <value>The spawn y.</value>
        public double SpawnY { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the current woots of the world.
        /// </summary>
        /// <value>The current woots.</value>
        public int Favorites { get; set; }

        /// <summary>
        ///     Gets or sets the owner username of the world.
        /// </summary>
        /// <value>The owner username.</value>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the plays of the world.
        /// </summary>
        /// <value>The plays.</value>
        public int Plays { get; set; }

        /// <summary>
        ///     Gets or sets the total woots of the world.
        /// </summary>
        /// <value>The total woots.</value>
        public int Likes { get; set; }

        /// <summary>
        ///     Gets or sets the name of the world.
        /// </summary>
        /// <value>The name of the world.</value>
        public string WorldName { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int SpawnBlockX => WorldUtils.PosToBlock(this.SpawnX);

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int SpawnBlockY => WorldUtils.PosToBlock(this.SpawnY);

        public AccessGroup AccessGroup
        {
            get => this.Visible ? this.FriendsOnly ? AccessGroup.Friends : AccessGroup.Anyone : AccessGroup.Noone;
            set
            {
                this.Visible = value != AccessGroup.Noone;
                this.FriendsOnly = value == AccessGroup.Friends;
            }
        }
    }
}