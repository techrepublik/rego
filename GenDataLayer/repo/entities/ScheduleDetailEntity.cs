using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ScheduleDetailEntity : ScheduleDetail
    {
        public string ConcatSchedules { get; set; }
        public string RomeNo { get; set; }
    }
}
