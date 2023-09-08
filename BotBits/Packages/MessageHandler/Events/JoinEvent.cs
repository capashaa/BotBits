using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone joins world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("add")]
    public sealed class JoinEvent : PlayerEvent<JoinEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JoinEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal JoinEvent(BotBitsClient client, Message message)
            : base(client, message, create: true)
        {
            this.Username = message.GetString(1);
            this.ConnectUserId = message.GetString(2);
            this.SmileyShape = (SmileyShape)message.GetInt(3);
            this.SmileyColour = (SmileyColour)message.GetInt(4);
            this.SmileyBorder = message.GetInt(5);
            this.SmileyEyes = (SmileyEyes)message.GetInt(6);
            this.SmileyMouth = (SmileyMouth)message.GetInt(7);
            this.SmileyAddon = (SmileyAddon)message.GetInt(8);
            this.SmileyAbove = (SmileyAbove)message.GetInt(9);
            this.SmileyBelow = (SmileyBelow)message.GetInt(10);
            this.SmileyWings = (SmileyWings)message.GetInt(11);
            this.X = message.GetDouble(12);
            this.Y = message.GetDouble(13);
            this.GodMode = message.GetBoolean(14);
            this.StaffMode = message.GetBoolean(15);
            this.HasChat = message.GetBoolean(16);
            this.Coins = message.GetInteger(17);
            this.BlueCoins = message.GetInteger(18);
            this.Deaths = message.GetInteger(19);
            this.Friend = message.GetBoolean(20);
            this.GoldMember = message.GetBoolean(21);
           // this.GoldBorder = message.GetBoolean(22);
            this.Team = (Team)message.GetInt(22);
            this.AuraShape = (AuraShape)message.GetInt(23);
            this.AuraColor = (AuraColor)message.GetInt(24);
            this.ChatColor = message.GetUInt(25);
            this.Badge = message.GetBadge(26);
            this.CrewMember = message.GetBoolean(27);
            this.PurpleSwitches = VarintHelper.ToInt32Array(message.GetByteArray(28));
            this.HasEditRights = message.GetBoolean(29);
            this.HasGodRights = message.GetBoolean(30);
        }
        
        public bool GoldBorder { get; set; }

        public bool HasEditRights { get; set; }

        public bool HasGodRights { get; set; }

        public AuraColor AuraColor { get; set; }

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
        ///     Gets or sets the amount of deaths.
        /// </summary>
        /// <value>The deaths.</value>
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether player is crew member.
        /// </summary>
        /// <value><c>true</c> if player is crew member; otherwise, <c>false</c>.</value>
        public bool CrewMember { get; set; }

        /// <summary>
        ///     Gets or sets the badge.
        /// </summary>
        /// <value>The badge.</value>
        public Badge Badge { get; set; }

        /// <summary>
        ///     Gets or sets the connect user identifier.
        /// </summary>
        /// <value>The connect user identifier.</value>
        public string ConnectUserId { get; set; }

        /// <summary>
        ///     Gets or sets the aura.
        /// </summary>
        /// <value>
        ///     The aura.
        /// </value>
        public AuraShape AuraShape { get; set; }

        /// <summary>
        ///     Gets or sets the team.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public Team Team { get; set; }

        /// <summary>
        ///     Gets or sets the color of the chat.
        /// </summary>
        /// <value>
        ///     The color of the chat.
        /// </value>
        public uint ChatColor { get; set; }

        /// <summary>
        ///     Gets or sets whether the user is in staff mode or not.
        /// </summary>
        /// <value><c>true</c> if the player has activated staff mode; otherwise, <c>false</c>.</value>
        public bool StaffMode { get; set; }

        /// <summary>
        ///     Gets or sets the amount of yellow coins the player has.
        /// </summary>
        /// <value>The yellow coins.</value>
        public int Coins { get; set; }

        /// <summary>
        ///     Gets or sets the amount of blue coins the player has.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; set; }


        /// <summary>
        ///     Gets or sets whether this player may chat using the free-form chat box.
        /// </summary>
        /// <value><c>true</c> if this player has chat; otherwise, <c>false</c>.</value>
        public bool HasChat { get; set; }

        /// <summary>
        ///     Gets or sets whether this player is a club member.
        /// </summary>
        /// <value><c>true</c> if this player is a club member; otherwise, <c>false</c>.</value>
        public bool GoldMember { get; set; }

        /// <summary>
        ///     Gets or sets whether this player has activated god mode.
        /// </summary>
        /// <value><c>true</c> if this player is in god mode; otherwise, <c>false</c>.</value>
        public bool GodMode { get; set; }
        
        /// <summary>
        ///     Gets or sets whether this player is my friend or not.
        /// </summary>
        /// <value><c>true</c> if this player is my friend; otherwise, <c>false</c>.</value>
        public bool Friend { get; set; }

        /// <summary>
        ///     Gets or sets whether the player has toggled a purple switch.
        /// </summary>
        /// <value><c>true</c> if the player has toggled a purple switch; otherwise, <c>false</c>.</value>
        public int[] PurpleSwitches { get; set; }

        /// <summary>
        ///     Gets or sets the username of the player.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate of the player.
        /// </summary>
        /// <value>The user position x.</value>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the y coordinate of the player.
        /// </summary>
        /// <value>The user position y.</value>
        public double Y { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX => WorldUtils.PosToBlock(this.X);

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY => WorldUtils.PosToBlock(this.Y);
    }
}