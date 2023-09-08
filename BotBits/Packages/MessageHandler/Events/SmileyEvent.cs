using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone changes their smiley.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("face")]
    public sealed class SmileyEvent : PlayerEvent<SmileyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmileyEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal SmileyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.SmileyShape = (SmileyShape)message.GetInteger(0);
            this.SmileyColour = (SmileyColour)message.GetInt(1);
            this.SmileyBorder = message.GetInt(2);
            this.SmileyEyes = (SmileyEyes)message.GetInt(3);
            this.SmileyMouth = (SmileyMouth)message.GetInt(4);
            this.SmileyAddon = (SmileyAddon)message.GetInt(5);
            this.SmileyAbove = (SmileyAbove)message.GetInt(6);
            this.SmileyBelow = (SmileyBelow)message.GetInt(7);
            this.SmileyWings = (SmileyWings)message.GetInt(8);
        }

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
    }
}