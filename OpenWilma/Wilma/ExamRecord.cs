namespace OpenWilma.Wilma;

#nullable enable
public record ExamRecord
{
    public DateTime Date { get; set; }

    public string? Name { get; set; }
    public string? Caption { get; set; }
    public string? Topic { get; set; }

    public string? Info { get; set; }
    public string? Grade { get; set; }
    public string? VerbalGrade { get; set; }
}
