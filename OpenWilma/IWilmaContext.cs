using OpenWilma.Wilma;

namespace OpenWilma;

public interface IWilmaContext
{
    string Url { get; }
    string Key { get; }
    Language Language { get; set; }
}
