using System.Collections.Generic;

namespace OpenWilma.Wilma
{
    public class ScheduleGroup
    {
        public int Id { get; set; }
        public int CourseId { get; set; } //TODO: ?

        public string ShortCaption { get; set; }
        public string Caption { get; set; }
        public string FullCaption { get; set; }

        public string Class { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
