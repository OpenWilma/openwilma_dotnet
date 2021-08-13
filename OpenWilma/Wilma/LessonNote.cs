using System;
using System.Drawing;

namespace OpenWilma.Wilma
{
    public class LessonNote
    {
		public DateTime TimeStamp { get; set; }

		public int Lesson { get; set; }
		public int Duration { get; set; }

		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
		public string TeacherCode { get; set; }

		public int CourseId { get; set; }
		public string Course { get; set; }

		public int TypeId { get; set; }
		public string TypeCode { get; set; }
		public string TypeShort { get; set; }
		public string TypeName { get; set; }

		public Color ForegroundColor { get; set; }
		public Color BackgroundColor { get; set; }

		public bool RequiresClearance { get; set; }

		public string DiscName { get; set; }
		public int DiscId { get; set; }

		public string ObservationInfo { get; set; }
		public bool ObservationInfoVisible { get; set; }

		public int PersonnelId { get; set; }
		public string PersonnelCode { get; set; }
		public string PersonnelName { get; set; }

		public int ClearanceType { get; set; }
		public string ClearanceInfo { get; set; }
		public DateTime ClearanceDate { get; set; }
		public DateTime ClearanceHandledDate { get; set; }
	}
}
