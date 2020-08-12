using System;

using Wilma.Api.Wilma;

namespace Wilma.Api
{
    public class WilmaContext
    {
        private const string MISSING_API_KEY = "You have to specify the API key";

        public string Url { get; }
        public string Key { get; }

        public WilmaContext(WilmaServer server, string key)
            : this(server.Url, key)
        { }
        public WilmaContext(string url, string key)
        {
            Url = url;
            Key = key ?? throw new ArgumentNullException(MISSING_API_KEY);
        }
    }
}
