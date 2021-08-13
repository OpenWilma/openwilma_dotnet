using System.Collections.Generic;
using System.Text.Json.Serialization;

using OpenWilma.Wilma;
using OpenWilma.Wilma.Enum;

namespace OpenWilma.Model
{
    public class IndexResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LoginResult LoginResult { get; set; }

        public string SessionID { get; set; }
        public int ApiVersion { get; set; }
        public string FormKey { get; set; }

        public IEnumerable<object> ConnectIds { get; set; }
        public IEnumerable<Worker> Workers { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
