using OpenWilma.Wilma;

namespace OpenWilma;

public interface IGroupApi
{
    Task<IEnumerable<Group>> GetGroupsAsync();
    Task<IEnumerable<Group>> GetPastGroupsAsync();
    Task<IEnumerable<Group>> GetFutureGroupsAsync();
}