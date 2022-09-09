using System.Collections.Generic;

namespace OpenWilma.Wilma;

public record Student
{
    public string Phone { get; set; }
    public string Address { get; set; }
    public string PostAddress { get; set; }
    public string Email { get; set; }

    public IEnumerable<Guardian> Guardians { get; set; }
}
