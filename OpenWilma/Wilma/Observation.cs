using System;
using System.Drawing;

#nullable enable
namespace OpenWilma.Wilma
{
    public class Observation
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Duration { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = default!;
        public string TeacherCode { get; set; } = default!;

        public int CourseId { get; set; }
        public string Course { get; set; } = default!;

        public int TypeId { get; set; }
        public string TypeCode { get; set; } = default!;
        public string TypeShort { get; set; } = default!;
        public string TypeName { get; set; } = default!;

        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        public bool RequiresClearance { get; set; }
        public int? ClearanceType { get; set; }
        public string? ClearanceInfo { get; set; } = default!;
        public DateTime? ClearanceDate { get; set; }
        public DateTime? ClearanceHandledDate { get; set; }

        public int? DiscId { get; set; }
        public string? DiscName { get; set; }

        public string? ObservationInfo { get; set; }
        public bool? ObservationInfoVisible { get; set; }

        public int? PersonnelId { get; set; }
        public string? PersonnelName { get; set; } = default!;
        public string? PersonnelCode { get; set; } = default!;
    }
}
