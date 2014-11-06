using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintStudentClass
    {
        public int StudentId { get; set; }
        public string StudentNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? ScholarshipId { get; set; }
        public string ScholarshipName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ParentGuardian { get; set; }
        public string Beneficiaries { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public string FullName 
        {
            get { return String.Format(@"{0}, {1}, {2}", LastName.ToUpper(), FirstName, MiddleName); }
        }

        public string CrsYrSec
        {
            get { return String.Format(@"{0}/{1}/{2}", CourseName, YearLevelName, SectionName); } 
        }
    }
}
