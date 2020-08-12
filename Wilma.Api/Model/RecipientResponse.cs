using System.Collections.Generic;

using Wilma.Api.Wilma;

namespace Wilma.Api.Model
{
    public class IndexRecord
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public string ShowTeachers { get; set; }

        public IList<Recipient> TeacherRecords { get; set; }
        public IList<Recipient> PersonnelRecords { get; set; }
    }

    public class RecipientResponse
    {
        public string ShowMyGuardian { get; set; }
        public string MyGuardianID { get; set; }
        public string MyGuardianClassID { get; set; }
        public string MyGuardianTitle { get; set; }
        public IList<Guardian> GuardianRecords { get; set; }

        public string MyTeacherID { get; set; }
        public string MyTeacherTitle { get; set; }
        public string MyTeacherCaption { get; set; }

        public IList<IndexRecord> IndexRecords { get; set; }
    }
}
