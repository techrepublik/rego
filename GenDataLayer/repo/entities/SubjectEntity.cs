using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class SubjectEntity : Subject
    {
        public int? ScheduleId { get; set; }
        public string ScheduleCode { get; set; }
        public int? TotalToBeRegisteredStudent { get; set; }
        public string Units { get; set; }
        public string ConcanatedSchedule { get; set; }
        public bool? IsValid { get; set; }

        public string FullUnits
        {
            get { return String.Format(@"{0}, {1}, {2}", SubjectLecUnit, SubjectLabUnit, SubjectCreUnit); }
        }
    }
}
