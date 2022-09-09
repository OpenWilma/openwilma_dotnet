using OpenWilma.Wilma;

namespace OpenWilma;

public interface IAttendanceApi
{
    Task<IEnumerable<Observation>> GetLessonNotesAsync(DateTime? date);
    Task<IEnumerable<Observation>> GetStudentLessonNotesAsync(int studentId);
    Task<string> SaveNoteExcuseAsync(int lessoneNoteId, int excuseId, string excuseText = default);
    Task<string> GetReportInfoAsync();
}
