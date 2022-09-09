using OpenWilma.Wilma;

namespace OpenWilma;

public class WilmaContext : IWilmaContext
{
    public string Url { get; }
    public string Key { get; }
    public Language Language { get; set; }

    public WilmaContext(WilmaServer server, string key, Language language = Language.English)
        : this(server.Url, key, language)
    { }
    public WilmaContext(string url, string key, Language language = Language.English)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(key);

        Url = url;
        Key = key;
        Language = language;
    }
}
