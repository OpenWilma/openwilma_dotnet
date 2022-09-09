namespace OpenWilma.Wilma;

public record EventData
{
    public bool MustApply { get; set; }
    public IEnumerable<Event> Events { get; set; }
}
