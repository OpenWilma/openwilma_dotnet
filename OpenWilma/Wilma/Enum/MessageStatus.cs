namespace OpenWilma.Wilma;

/// <summary>
/// Represents the current status of a message.
/// </summary>
public enum MessageStatus
{
    Default = 0,
    /// <summary>
    /// Message has not been opened by recipient.
    /// </summary>
    Unread = 1
}
