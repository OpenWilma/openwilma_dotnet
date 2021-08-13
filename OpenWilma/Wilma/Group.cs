using System;
using System.Collections.Generic;

namespace OpenWilma.Wilma
{
    public class Group
    {
        public int Id { get; set; }
        
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        
        public string Name { get; set; }
        public string Caption { get; set; }
        
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Committed { get; set; }

        public IEnumerable<TeacherRecord> Teachers { get; set; }
        public IEnumerable<HomeworkRecord> Homework { get; set; }
        public IEnumerable<DiaryRecord> Diary { get; set; }
        public IEnumerable<ExamRecord> Exams { get; set; }
    }
}
