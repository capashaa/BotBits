using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change smiley.
    /// </summary>
    public sealed class SmileySendMessage : SendMessage<SmileySendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmileySendMessage" /> class.
        /// </summary>
        /// <param name="smiley">The face.</param>
        /// 
        
        public SmileySendMessage(SmileyShape shape,SmileyColour colour,SmileyBorder border,SmileyEyes eyes, SmileyMouth mouth, SmileyAddon addon, SmileyAbove above, SmileyBelow below, SmileyWings wings)
        {
            this.SmileyShape = shape;
            this.SmileyColour = colour;
            this.SmileyBorder = border;
            this.SmileyEyes = eyes;
            this.SmileyMouth = mouth;
            this.SmileyAddon = addon;
            this.SmileyAbove = above;
            this.SmileyBelow = below;
            this.SmileyWings = wings;
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
        public SmileyBorder SmileyBorder { get; set; }

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
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("smiley", (int)this.SmileyShape, (int)this.SmileyColour, (int)this.SmileyBorder, (int)this.SmileyEyes,(int)this.SmileyMouth,(int)this.SmileyAddon, (int)this.SmileyAbove,(int)this.SmileyBelow,(int)this.SmileyWings);
        }
    }
}