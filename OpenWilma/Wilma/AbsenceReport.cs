namespace OpenWilma.Wilma;

public record AbsenceReport
{
    public int ReportDate { get; set; }
    public string CurrentReportText { get; set; }
    public string DateMessage { get; set; }
    public string ReportHeading { get; set; }
    public IEnumerable<Excuse> Excuses { get; set; }
}
