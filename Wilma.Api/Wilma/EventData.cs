using System.Collections.Generic;

namespace Wilma.Api.Wilma
{
    public class EventData
    {
        public bool MustApply { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
