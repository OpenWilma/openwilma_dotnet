using OpenWilma.Model;
using OpenWilma.Wilma;

namespace OpenWilma;

public class WilmaSession : IWilmaSession
{
    public IWilmaContext Context { get; }

    public int ApiVersion { get; set; }
    public string FormKey { get; set; }
    public IEnumerable<Role> Roles { get; }

    public WilmaSession(IWilmaContext context, IndexResponse data)
    {
        Context = context;

        Roles = data.Roles;
        FormKey = data.FormKey;
        ApiVersion = data.ApiVersion;
    }
}
