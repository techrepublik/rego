using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintEnrolleeDepartmentClass
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseFullName { get; set; }
        public int Assessed { get; set; }
        public int Paid { get; set; }
        public int Cancelled { get; set; }
        public bool? Enrolled { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }
    }
}
