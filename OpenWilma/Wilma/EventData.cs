using System.Collections.Generic;

namespace OpenWilma.Wilma
{
    public class EventData
    {
        public bool MustApply { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
