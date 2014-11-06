using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ScheduleFeesEntity : FeeParticular
    {
        public int ScheduleFeeId { get; set; }
        public decimal? Amount { get; set; }
        public bool? Active { get; set; }
        public int? SemSyId { get; set; }
    }
}
