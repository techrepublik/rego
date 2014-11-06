using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class CourseYearSectionEntity
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int?  YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public string CrsYearSec
        {
            get {return  String.Format(@"{0}/{1}/{2}", CourseName, YearLevelName, SectionName); }
        }
    }
}
