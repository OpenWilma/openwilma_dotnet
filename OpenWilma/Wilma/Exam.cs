using System;
using System.Collections.Generic;

#nullable enable
namespace OpenWilma.Wilma
{
    public class Exam
    {
        public int Id { get; set; }
        public int ExamId { get; set; }

        public string Course { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CourseTitle { get; set; } = default!;

        public string? Grade { get; set; }
        public string? VerbalGrade { get; set; }

        public bool? Unseen { get; set; }

        public DateTime? ExamSeen { get; set; }

        /// <summary>
        /// Localized string representation of the <see cref="ExamSeen"/> date.
        /// </summary>
        public string? ExamSeenDate { get; set; }

        public IEnumerable<TeacherRecord> Teachers { get; set; } = default!;
        
        public DateTime Date { get; set; }
        public string? Info { get; set; }

        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
    }
}
