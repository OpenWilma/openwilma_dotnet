namespace OpenWilma.Wilma;

public record DiaryRecord
{
    public DateTime Date { get; set; }
    public string Lesson { get; set; }
    public string Note { get; set; }

    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherCode { get; set; }
}
