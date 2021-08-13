using System.Drawing;

namespace OpenWilma.Wilma
{
    /// <summary>
    /// Represents a single reservation in the <see cref="BasicSchedule"/>. Simple example of reservation could be a lesson.
    /// </summary>
    public class Reservation
    {
        public int ReservationID { get; set; }

        /// <summary>
        /// The unique identifier of the parent schedule in which the reservation belongs.
        /// </summary>
        public int ScheduleID { get; set; }

        public int Day { get; set; }

        //TODO: Think of way to represent this time span nicely, probably new type to ease interaction with other system date & time types. A custom System.TimeSpan converter might be enough though
        public string Start { get; set; }
        public string End { get; set; }

        public Color Color { get; set; }

        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public string Class { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowAddMoveRemove { get; set; }
    }
}
