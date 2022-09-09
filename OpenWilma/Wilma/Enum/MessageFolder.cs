namespace OpenWilma.Wilma;

/// <summary>
/// Represents the folder kinds in which messages can be placed.
/// </summary>
public enum MessageFolder
{
    /// <summary>
    /// Represents the received messages.
    /// </summary>
    Inbox,
    /// <summary>
    /// Represents messages sent by us.
    /// </summary>
    Outbox,
    /// <summary>
    /// Represents the archived messages.
    /// </summary>
    Archive,
    /// <summary>
    /// Represents the drafted messages.
    /// </summary>
    Drafts,
    /// <summary>
    /// Represents the messages in the <see cref="Inbox"/> folder that have <see cref="Message.IsEvent"/> set to true.
    /// </summary>
    Appointments,
    /// <summary>
    /// Contains all of the message folders.
    /// </summary>
    All
}
