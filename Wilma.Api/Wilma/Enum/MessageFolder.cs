namespace Wilma.Api.Wilma.Enum
{
    /// <summary>
    /// Represents the folder kinds in which messages can be placed.
    /// </summary>
    public enum MessageFolder
    {
        /// <summary>
        /// Represents a message that we have received.
        /// </summary>
        Inbox,
        /// <summary>
        /// Represents a messages sent by us.
        /// </summary>
        Outbox,
        /// <summary>
        /// Represents an archived message.
        /// </summary>
        Archive,
        /// <summary>
        /// Represents an drafted message.
        /// </summary>
        Drafts,
        /// <summary>
        /// Contains all of the message folders.
        /// </summary>
        All
    }
}
