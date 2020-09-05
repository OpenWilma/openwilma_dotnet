using System;

namespace Wilma.Api.Wilma
{
    public class DiaryRecord
    {
        public DateTime Date { get; set; }
        public string Lesson { get; set; }
        public string Note { get; set; }

        //Following properties are practically the existing TeacherRecord model. 
        //TODO: Research if there's a way to use existing type here in System.Text.Json
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherCode { get; set; }
    }
}
