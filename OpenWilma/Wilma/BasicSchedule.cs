using System.Collections.Generic;

namespace OpenWilma.Wilma
{
    public class BasicSchedule
    {
        public IEnumerable<Reservation> Schedule { get; set; }
        public IEnumerable<Term> Terms { get; set; }
    }
}
