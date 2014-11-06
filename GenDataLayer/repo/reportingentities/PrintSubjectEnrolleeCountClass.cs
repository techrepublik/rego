using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintSubjectEnrolleeCountClass : PrintStudentClass
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double Lecture { get; set; }
        public double Laboratory { get; set; }
        public double Credit { get; set; }
        public int NoEnrolled { get; set; }
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        
        public string Units 
        {
            get { return String.Format(@"{0}, {1}, {2}", Lecture, Laboratory, Credit); }
        }
    }
}