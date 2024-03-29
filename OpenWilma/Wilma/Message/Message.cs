﻿using System.Text.Json.Serialization;

namespace OpenWilma.Wilma;

#nullable enable
public record Message
{
    public int Id { get; set; }
    public string Subject { get; set; } = default!;
    public DateTime TimeStamp { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MessageFolder Folder { get; set; }

    public int RecipientCount { get; set; }
    public IEnumerable<string>? Recipients { get; set; }

    public int SenderId { get; set; }
    public RoleType SenderType { get; set; }
    public string Sender { get; set; } = default!;

    public int? Replies { get; set; }
    public bool AllowCollatedReply { get; set; }
    public bool IsEvent { get; set; }

    public string ContentHTML { get; set; } = default!;

    public EventData? EventData { get; set; }
    public IEnumerable<MessageReply>? ReplyList { get; set; }

    public bool AllowForward { get; set; }
    public bool AllowReply { get; set; }
}
