using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Model;
using Wilma.Api.Wilma;
using Wilma.Api.Wilma.Enum;

namespace Wilma.Api
{
    public class MessageApi
    {
        private readonly Role _role;
        private readonly WilmaSession _session;

        public MessageApi(WilmaSession session, Role role)
        {
            _session = session;
            _role = role;
        }

        /// <summary>
        /// Retrieves all the messages from the specified folder.
        /// </summary>
        /// <param name="folder">The folder to retrieve messages from, by default <see cref="MessageFolder.Inbox"/>.</param>
        /// <returns>The message records.</returns>
        public Task<IEnumerable<MessageRecord>> GetMessagesAsync(MessageFolder folder = MessageFolder.Inbox)
        {
            string path = "/messages/index_json";

            if (folder != MessageFolder.Inbox)
                path += $"/{folder}";

            return WAPI.GetAsync<IEnumerable<MessageRecord>>(_session, _role.Slug + path);
        }

        /// <summary>
        /// Retrieves the message contents by the unique message identifier.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>The message contents.</returns>
        public async Task<Message> GetMessageContentAsync(int messageId)
        {
            var messages = await WAPI.GetAsync<IEnumerable<Message>>(_session,
                _role.Slug + "/messages/" + messageId).ConfigureAwait(false);
            return messages.First();
        }

        public Task<RecipientResponse> GetAllRecipientsAsync()
        {
            return WAPI.GetAsync<RecipientResponse>(_session, _role.Slug + "/messages/recipients");
        }

        /// <summary>
        /// Reply to a message which has the collated replies allowed.
        /// </summary>
        /// <param name="messageId">The identifier of the message which the reply is meant for.</param>
        /// <param name="bodyText">The reply message body.</param>
        public Task<HttpResponseMessage> ReplyAsync(int messageId, string bodyText)
        {
            return WAPI.PostAsync(_session, _role.Slug + "/messages/collatedreply/" + messageId, 
                parameters: new Dictionary<string, string> {{ "BodyText", bodyText }});
        }

        /// <summary>
        /// Send a new message to recipient(s).
        /// </summary>
        /// <param name="subject">The message subject.</param>
        /// <param name="bodyText">The message body.</param>
        /// <param name="showRecipients">Whether recipients are able to see the other recipients.</param>
        /// <param name="collatedReplies">Whether recipients are able to see each other's replies.</param>
        /// <param name="recipients">The message recipients.</param>
        public async Task<bool> ComposeMessageAsync(string subject, string bodyText,
            bool showRecipients = false, bool collatedReplies = false,
            params (RecipientType type, string id)[] recipients)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Subject", subject),
                new KeyValuePair<string, string>("BodyText", bodyText),
                new KeyValuePair<string, string>("ShowRecipients", showRecipients.ToString()),
                new KeyValuePair<string, string>("CollatedReplies", collatedReplies.ToString())
            };

            foreach (var (recipientType, recipientId) in recipients)
            {
                if (recipientType == RecipientType.Guardian)
                    throw new NotImplementedException($"//TODO: {nameof(RecipientType.Guardian)}");

                parameters.Add(new KeyValuePair<string, string>(
                    "r_" + recipientType.ToString(), recipientId.ToString()));
            }

            using var response = await WAPI.PostAsync(_session,
                _role.Slug + "/messages/compose", parameters).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Mark messages unread.
        /// </summary>
        /// <param name="messageIds">The message(s) to delete.</param>
        public async Task<bool> MarkUnreadAsync(params int[] messageIds)
        {
            var parameters = new List<KeyValuePair<string, object>>(messageIds.Length);
            foreach (int mid in messageIds)
            {
                parameters.Add(new KeyValuePair<string, object>("mid", mid));
            }

            using var response = await WAPI.GetAsync(_session,
                _role.Slug + "/message/markunread", parameters);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Archives the messages. These message will now reside in the <see cref="MessageFolder.Archive"/>.
        /// </summary>
        /// <param name="messageIds">The message(s) to archive.</param>
        public async Task<bool> ArchiveAsync(params int[] messageIds)
        {
            var parameters = new List<KeyValuePair<string, string>>(messageIds.Length);
            foreach (int mid in messageIds)
            {
                parameters.Add(new KeyValuePair<string, string>("mid", mid.ToString()));
            }

            using var response = await WAPI.PostAsync(_session,
                _role.Slug + "/messages/archivetool", parameters).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Deletes the messages from the account folder(s).
        /// </summary>
        /// <param name="messageIds">The message(s) to delete.</param>
        public async Task<bool> DeleteAsync(params int[] messageIds)
        {
            var parameters = new List<KeyValuePair<string, string>>(messageIds.Length);
            foreach (int mid in messageIds)
            {
                parameters.Add(new KeyValuePair<string, string>("mid", mid.ToString()));
            }

            using var response = await WAPI.PostAsync(_session,
                _role.Slug + "/messages/delete", parameters);
            return response.IsSuccessStatusCode;
        }
    }
}
