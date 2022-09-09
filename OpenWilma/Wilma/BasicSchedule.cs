namespace OpenWilma.Wilma;

public record BasicSchedule
{
    public IEnumerable<Reservation> Schedule { get; set; }
    public IEnumerable<Term> Terms { get; set; }
}
