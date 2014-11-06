using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintStudentListClass : PrintStudentClass
    {
        public string Scholarship { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double Lecture { get; set; }
        public double Laboratory { get; set; }
        public double Credit { get; set; }
        public string Schedule { get; set; }
        public string Instructor { get; set; }
    }
}
