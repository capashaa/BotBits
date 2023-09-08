using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a world portal is placed in the world.
    /// </summary>
    [ReceiveEvent("wp")]
    internal sealed class WorldPortalPlaceEvent : PlayerEvent<WorldPortalPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WorldPortalPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal WorldPortalPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 5)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.WorldPortalTarget = message.GetString(3);
            this.WorldPortalId = message.GetInteger(4);
        }

        /// <summary>
        ///     Gets or sets the world portal target.
        /// </summary>
        /// <value>The world portal target.</value>
        public string WorldPortalTarget { get; set; }

        /// <summary>
        ///     Gets or sets the world portal id.
        /// </summary>
        /// <value>The world portal id.</value>
        public int WorldPortalId{ get; set; }

        /// <summary>
        ///     Gets or sets the block id.
        /// </summary>
        /// <value>
        ///     The block id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the position x.
        /// </summary>
        /// <value>The position x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the position y.
        /// </summary>
        /// <value>The position y.</value>
        public int Y { get; set; }
    }
}