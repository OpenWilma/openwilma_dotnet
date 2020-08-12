using System.Collections.Generic;
using System.Text.Json.Serialization;

using Wilma.Api.Wilma;
using Wilma.Api.Wilma.Enum;

namespace Wilma.Api.Model
{
    public class IndexResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LoginResult LoginResult { get; set; }

        public string SessionID { get; set; }
        public int ApiVersion { get; set; }
        public string FormKey { get; set; }

        //TODO: What are these two
        public IEnumerable<object> ConnectIds { get; set; }
        public IEnumerable<object> Workers { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
