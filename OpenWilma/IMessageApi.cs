using OpenWilma.Model;
using OpenWilma.Wilma;

namespace OpenWilma;

public interface IMessageApi
{
    Task<IEnumerable<MessageRecord>> GetMessagesAsync(MessageFolder folder);
    Task<Message> GetMessageContentAsync(int messageId);
    Task<RecipientResponse> GetAllRecipientsAsync();
    Task<HttpResponseMessage> ReplyAsync(int messageId, string bodyText);

    Task<bool> ComposeMessageAsync(string subject, string bodyText,
        bool showRecipients, bool collatedReplies,
        params (RecipientType type, string id)[] recipients);

    Task<bool> MarkUnreadAsync(params int[] messageIds);
    Task<bool> ArchiveAsync(params int[] messageIds);
    Task<bool> DeleteAsync(params int[] messageIds);
}