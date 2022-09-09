using OpenWilma.Wilma;

namespace OpenWilma;

public interface IWilmaSession
{
    IWilmaContext Context { get; }

    int ApiVersion { get; set; }
    string FormKey { get; set; }
    IEnumerable<Role> Roles { get; }
}
