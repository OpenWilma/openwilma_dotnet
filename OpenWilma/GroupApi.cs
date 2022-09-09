using OpenWilma.Wilma;

namespace OpenWilma;

public class GroupApi : IGroupApi
{
    private readonly Role _role;
    private readonly IWilmaSession _session;

    public GroupApi(IWilmaSession session, Role role)
        => (_session, _role) = (session, role);

    public Task<IEnumerable<Group>> GetGroupsAsync()
        => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json");

    public Task<IEnumerable<Group>> GetPastGroupsAsync()
        => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json/past");

    public Task<IEnumerable<Group>> GetFutureGroupsAsync()
        => WAPI.GetAsync<IEnumerable<Group>>(_session, _role.Slug + "/groups/index_json/future");
}
