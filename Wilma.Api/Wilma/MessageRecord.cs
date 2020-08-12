using System;
using System.Text.Json.Serialization;

using Wilma.Api.Wilma.Enum;

namespace Wilma.Api.Wilma
{
    public class MessageRecord
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime TimeStamp { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageFolder Folder { get; set; }

        public int SenderId { get; set; }
        public RoleType SenderType { get; set; }
        public string Sender { get; set; }
        public int Replies { get; set; }
        public bool? IsEvent { get; set; }
    }
}
