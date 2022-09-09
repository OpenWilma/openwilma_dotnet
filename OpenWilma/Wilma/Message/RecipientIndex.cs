namespace OpenWilma.Wilma;

public record RecipientIndex
{
    public int Id { get; set; }
    public string Caption { get; set; }
    public string ShowTeachers { get; set; }
    public string ShowWorkplaceInstructors { get; set; }

    public IEnumerable<Recipient> TeacherRecords { get; set; }
    public IEnumerable<Recipient> PersonnelRecords { get; set; }
}
