namespace OpenWilma.Wilma;

public record News
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string Topic { get; set; }
    public string Description { get; set; }
    public string ContentHtml { get; set; }
    public string Creator { get; set; }

    public DateTime Created { get; set; }
}
