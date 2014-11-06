using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ScholarshipFeeEntity 
    {
        public int ScholarshipFeeId { get; set; }
        public int? ScheduleFeeId { get; set; }
        public int? ScholarshipId { get; set; }
        public double? Percentage { get; set; }
        public string Particulars { get; set; }
        public int? FeeParticularId { get; set; }
    }
}
