using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintPresetFeeClass
    {
        public int PresetFeeNameId { get; set; }
        public string PresetFeeName { get; set; }
        public string CourseName { get; set; }
        public string YearLevelName { get; set; }
        public string SectionName { get; set; }
        public int FeeParticularId { get; set; }
        public string FeeParticularName { get; set; }
        public decimal Amount { get; set; }

        public string CrsYrSec 
        {
            get { return String.Format(@"{0}/{1}/{2}", CourseName, YearLevelName, SectionName); } 
        }
    }
}
