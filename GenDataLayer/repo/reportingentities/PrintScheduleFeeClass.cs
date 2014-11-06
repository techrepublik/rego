using System;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintScheduleFeeClass
    {
        public int? ScheduleFeeNameId { get; set; }
        public string ScheduleFeeNames { get; set; }
        public string Description { get; set; }
        public int? ScheduleFeeId { get; set; }
        public string Particular { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsActive { get; set; }
    }
}
