using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            _role = role;
            _session = session;
        }

        public async Task<IEnumerable<MessageRecord>> GetMessagesAsync(MessageFolder folder = MessageFolder.Inbox)
        {
            string folderPath = "/messages/index_json";

            if (folder != MessageFolder.Inbox)
                folderPath += $"/{folder}";

            return await WAPI.GetAsync<IEnumerable<MessageRecord>>(_session,
                _role.Slug + folderPath).ConfigureAwait(false);
        }

        public async Task<Message> GetMessageContentAsync(int messageId)
        {
            var messages = await WAPI.GetAsync<IEnumerable<Message>>(_session, 
                _role.Slug + "/messages/" + messageId).ConfigureAwait(false);

            return messages.First();
        }
    }
}
