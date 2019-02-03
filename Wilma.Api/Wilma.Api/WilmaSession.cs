using System.Collections.Generic;

using Wilma.Api.Web;
using Wilma.Api.Wilma;
using Wilma.Api.Web.Model;

namespace Wilma.Api
{
    public class WilmaSession
    {
        public IList<WilmaRole> Roles { get; }
        public WilmaApiContext Context { get; }
        
        public string Name { get; private set; }
        public string FormKey { get; set; }

        public bool IsAuthenticated { get; private set; } = true;

        public WilmaSession(string url, string apiKey, IndexResponse data)
            : this(new WilmaApiContext(url, apiKey), data)
        { }
        public WilmaSession(WilmaApiContext apiContext, IndexResponse data)
        {
            Context = apiContext;

            Roles = data.Roles;
            FormKey = data.FormKey;
        }
    }
}
