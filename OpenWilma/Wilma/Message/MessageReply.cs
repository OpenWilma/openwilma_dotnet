﻿namespace OpenWilma.Wilma;

public record MessageReply
{
    public string Id { get; set; }
    public string ContentHtml { get; set; }
    public DateTime TimeStamp { get; set; }
    public int SenderId { get; set; }
    public RoleType SenderType { get; set; }
    public string Sender { get; set; }
}
