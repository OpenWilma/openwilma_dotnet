using System;
using System.Text.Json.Serialization;

using OpenWilma.Wilma.Enum;

#nullable enable
namespace OpenWilma.Wilma
{
    public class MessageRecord
    {
        public int Id { get; set; }
        public string Subject { get; set; } = default!;
        public DateTime TimeStamp { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageFolder Folder { get; set; }

        public int SenderId { get; set; }
        public RoleType SenderType { get; set; }
        public string Sender { get; set; } = default!;
        public string? SenderStudentName { get; set; }
        public int? SenderPasswdID { get; set; }
        public string? SenderGuardianName { get; set; }
        public int? Replies { get; set; }
        public bool? IsEvent { get; set; }
        public MessageStatus Status { get; set; }
    }
}
