namespace OpenWilma.Wilma;

public record Role
{
    public string Name { get; set; }
    public RoleType Type { get; set; }

    /// <summary>
    /// The card number in Primus
    /// </summary>
    public int PrimusId { get; set; }

    /// <summary>
    /// User role specific key
    /// </summary>
    public string FormKey { get; set; }

    /// <summary>
    /// Base64 encoded profile picture data
    /// </summary>
    public string Photo { get; set; }

    public bool EarlyEduUser { get; set; }

    /// <summary>
    /// The unique role identifier
    /// </summary>
    public string Slug { get; set; }

    public string School { get; set; }
}
