using OpenWilma.Wilma;

namespace OpenWilma;

public class ExamApi : IExamApi
{
    private readonly Role _role;
    private readonly IWilmaSession _session;

    public ExamApi(IWilmaSession session, Role role)
        => (_session, _role) = (session, role);

    public Task<IEnumerable<Exam>> GetExamsAsync()
        => WAPI.GetAsync<IEnumerable<Exam>>(_session, _role.Slug + "/exams/index_json");

    public Task MarkExamAsSeenAsync()
        => WAPI.PostAsync(_session, _role.Slug + "/exams/seen");
}
