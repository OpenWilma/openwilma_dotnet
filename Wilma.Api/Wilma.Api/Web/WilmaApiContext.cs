using System;

using Wilma.Api.Wilma;

namespace Wilma.Api.Web
{
    public class WilmaApiContext
    {
        private const string MISSING_API_KEY = "You have to specify the API key";

        public Uri BaseUri { get; }
        public string Key { get; }

        public WilmaApiContext(WilmaServer server, string key)
            : this(server.Url, key)
        { }
        public WilmaApiContext(string url, string key)
        {
            BaseUri = new Uri(url);
            Key = key ?? throw new ArgumentNullException(MISSING_API_KEY);
        }
    }
}
