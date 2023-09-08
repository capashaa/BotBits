using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a npc block is placed in the world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("bn")]
    internal sealed class NPCPlaceEvent : PlayerEvent<NPCPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NPCPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal NPCPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 7)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.Name = message.GetString(3);
            this.Message1 = message.GetString(4);
            this.Message2 = message.GetString(5);
            this.Message3 = message.GetString(6);
        }

        /// <summary>
        ///     Gets or sets the name of the NPC.
        /// </summary>
        /// <value>The name of the NPC.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the NPC message 1.
        /// </summary>
        /// <value>The first message from NPC.</value>
        public string Message1 { get; set; }

        /// <summary>
        ///     Gets or sets the NPC message 2.
        /// </summary>
        /// <value>The second message from NPC.</value>
        public string Message2 { get; set; }

        /// <summary>
        ///     Gets or sets the NPC message 3.
        /// </summary>
        /// <value>The third message from NPC.</value>
        public string Message3 { get; set; }

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