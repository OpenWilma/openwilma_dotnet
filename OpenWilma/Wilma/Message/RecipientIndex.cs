using System.Collections.Generic;

namespace OpenWilma.Wilma
{
    public class RecipientIndex
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string ShowTeachers { get; set; }
        public string ShowWorkplaceInstructors { get; set; }

        public IEnumerable<Recipient> TeacherRecords { get; set; }
        public IEnumerable<Recipient> PersonnelRecords { get; set; }
    }
}
