using OpenWilma.Wilma;

namespace OpenWilma.Model;

public record RecipientResponse
{
    public string ShowMyGuardian { get; set; }
    public int MyGuardianID { get; set; }
    public int MyGuardianClassID { get; set; }
    public string MyGuardianTitle { get; set; }
    public IList<Guardian> GuardianRecords { get; set; }

    public string ShowMyStudent { get; set; }
    public int MyStudentID { get; set; }
    public int MyStudentClassID { get; set; }
    public string MyStudentTitle { get; set; }

    public int MyTeacherID { get; set; }
    public string MyTeacherTitle { get; set; }
    public string MyTeacherCaption { get; set; }

    public IList<RecipientIndex> IndexRecords { get; set; }
}
