using System.Threading.Tasks;
using System.Collections.Generic;

using OpenWilma.Wilma;

namespace OpenWilma
{
    public class ExamApi
    {
        private readonly Role _role;
        private readonly WilmaSession _session;

        public ExamApi(WilmaSession session, Role role)
        {
            _role = role;
            _session = session;
        }

        public Task<IEnumerable<Exam>> GetExamsAsync()
            => WAPI.GetAsync<IEnumerable<Exam>>(_session, _role.Slug + "/exams/index_json");

        public Task MarkAsSeenAsync()
            => WAPI.PostAsync(_session, _role.Slug + "/exams/seen");
    }
}
