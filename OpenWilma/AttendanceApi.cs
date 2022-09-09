using OpenWilma.Wilma;

namespace OpenWilma;

public class AttendanceApi : IAttendanceApi
{
    private readonly Role _role;
    private readonly IWilmaSession _session;

    public AttendanceApi(IWilmaSession session, Role role)
        => (_session, _role) = (session, role);

    public Task<IEnumerable<Observation>> GetLessonNotesAsync(DateTime? date = default)
    {
        string path = "/attendance/index_json";

        if (date is not null)
            path += $"?date={date:d.M.yyyy}";

        return WAPI.GetAsync<IEnumerable<Observation>>(_session, _role.Slug + path);
    }

    public Task<IEnumerable<Observation>> GetStudentLessonNotesAsync(int studentId)
    {
        return WAPI.GetAsync<IEnumerable<Observation>>(_session, _role.Slug + "/attendance/index_json/student/" + studentId);
    }

    public Task<string> SaveNoteExcuseAsync(int lessoneNoteId, int excuseId, string excuseText = default)
    {
        var parameters = new Dictionary<string, string>
        {
            { "item" + lessoneNoteId, "true" },
            { "text", excuseText },
            { "type", excuseId.ToString() }
        };

        return WAPI.PostAsync<string>(_session, _role.Slug + "/attendance/saveexcuse", parameters);
    }
    public Task<string> GetReportInfoAsync()
    {
        return WAPI.GetAsync<string>(_session, _role.Slug + "/attendance");
    }
}
