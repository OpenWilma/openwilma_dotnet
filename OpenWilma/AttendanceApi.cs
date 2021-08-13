using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using OpenWilma.Wilma;

namespace OpenWilma
{
    public class AttendanceApi
    {
        private readonly Role _role;
        private readonly WilmaSession _session;

        public AttendanceApi(WilmaSession session, Role role)
        {
            _session = session;
            _role = role;
        }

        public Task<IEnumerable<Observation>> GetLessonNotesAsync(DateTime? date = default)
        {
            string path = "/attendance/index_json";
            
            if (date is not null)
                path += "?date={date:d.M.yyyy}";

            return WAPI.GetAsync<IEnumerable<Observation>>(_session, _role.Slug + path);
        }
    }
}
