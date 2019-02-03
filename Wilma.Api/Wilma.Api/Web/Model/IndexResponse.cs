using System.Collections.Generic;
using System.Runtime.Serialization;

using Wilma.Api.Wilma;

namespace Wilma.Api.Web.Model
{
    public sealed class IndexResponse
    {
        public string LoginResult { get; set; }

        [DataMember(Name = "SessionID")]
        public string SessionId { get; set; }

        public int ApiVersion { get; set; }
        public string FormKey { get; set; }
        public IList<object> ConnectIds { get; set; }
        public IList<object> Workers { get; set; }

        public IList<WilmaRole> Roles { get; set; }
    }
}
