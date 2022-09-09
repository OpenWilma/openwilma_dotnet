using OpenWilma.Wilma;

namespace OpenWilma;

public interface IExamApi
{
    Task<IEnumerable<Exam>> GetExamsAsync();
    Task MarkExamAsSeenAsync();
}
