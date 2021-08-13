using System;

namespace OpenWilma.Wilma
{
    public class Event
    {
        public int MsgId { get; set; }
        public int EventId { get; set; }
        public string Subject { get; set; }

        public DateTime Start { get; set; }
        public string StartDayName { get; set; }
        
        public DateTime End { get; set; }
        public string EndDayName { get; set; }

        public DateTime EnrollStart { get; set; }
        public DateTime EnrollEnd { get; set; }
        public DateTime CancelDate { get; set; }

        public string Info { get; set; }
        public bool SameDay { get; set; }
        public int MaxPeople { get; set; }

        public string Sender { get; set; }
        public bool? IsDismissed { get; set; }
        public string State { get; set; } //TODO: Expired
        public int PeopleCount { get; set; }
    }
}
