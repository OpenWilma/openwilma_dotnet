using System;

namespace Wilma.Api.Wilma
{
    public class WilmaMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Folder { get; set; }
        public int SenderId { get; set; }
        public int SenderType { get; set; }
        public string Sender { get; set; }
        public int Replies { get; set; }
        public bool? IsEvent { get; set; }
    }
}
