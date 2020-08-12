using System.Collections.Generic;

using Wilma.Api.Model;
using Wilma.Api.Wilma;

namespace Wilma.Api
{
    public class WilmaSession
    {
        public WilmaContext Context { get; }
        
        public string FormKey { get; set; }
        public IEnumerable<Role> Roles { get; }

        public WilmaSession(WilmaContext context, IndexResponse data)
        {
            Context = context;

            Roles = data.Roles;
            FormKey = data.FormKey;
        }
    }
}
