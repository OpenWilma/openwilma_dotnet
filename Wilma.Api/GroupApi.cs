using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Wilma;

namespace Wilma.Api
{
    public class GroupApi
    {
        private readonly Role _role;
        private readonly WilmaSession _session;

        public GroupApi(WilmaSession session, Role role)
        {
            _role = role;
            _session = session;
        }

        public Task<IEnumerable<Group>> GetGroupsAsync()
            => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json");
        
        public Task<IEnumerable<Group>> GetPastGroupsAsync()
            => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json/past");
        
        public Task<IEnumerable<Group>> GetFutureGroupsAsync()
            => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json/future");
    }
}
