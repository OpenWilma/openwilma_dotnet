using System;

using OpenWilma.Wilma;
using OpenWilma.Wilma.Enum;

namespace OpenWilma
{
    public class WilmaContext
    {
        private const string MISSING_API_KEY = "You have to specify the API key in order to use Wilma's API";

        public string Url { get; }
        public string Key { get; }
        public Language Language { get; set; }

        public WilmaContext(WilmaServer server, string key, Language language = Language.English)
            : this(server.Url, key, language)
        { }
        public WilmaContext(string url, string key, Language language = Language.English)
        {
            Url = url;
            Key = key ?? throw new ArgumentNullException(nameof(key), MISSING_API_KEY);
            Language = language;
        }
    }
}
