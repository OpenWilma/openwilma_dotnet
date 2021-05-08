using System.Collections.Generic;

namespace Wilma.Api.Wilma
{
    public class RecipientIndex
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string ShowTeachers { get; set; }

        public IEnumerable<Recipient> TeacherRecords { get; set; }
        public IEnumerable<Recipient> PersonnelRecords { get; set; }
    }
}
