using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class StudentEntity : Student
    {
        public string Names { get; set; }
        public string ScholarshipName { get; set; }
        public int? ScholarshipId { get; set; }
        public string Course { get; set; }
        public string Section { get; set; }
        public string YearLevel { get; set; }
        public int? ScholarshipId1 { get; set; }
        public string ScholarshipName1 { get; set; }
        public int? ScholarshidId2 { get; set; }
        public string ScholarshipName2 { get; set; }
        //public int? CourseId { get; set; }
        //public int? YearLevelId { get; set; }
        //public int? SectionId { get; set; }
        //public int? TypeId { get; set; }
        //public int? StatusId { get; set; }
        //public int? ProspectusId { get; set; }
        //public int? SemSyId { get; set; }
        //public int? BranchId { get; set; }
        //public bool? Cancelled { get; set; }
        //public bool? Paid { get; set; }
        //public bool? Enrolled { get; set; }
        //public string CourseName { get; set; }
        //public string CurriculumName { get; set; }
        //public string StatusName { get; set; }
        //public string TypeName { get; set; }

        public string YearCourseSection
        {
            get
            {
                if (Course == string.Empty)
                    Course = @"_";

                if (YearLevel == string.Empty)
                    YearLevel = @"_";

                if (Section == string.Empty)
                    Section = @"_";
                
                return String.Format(@"{0}/{1}/{2}", YearLevel, Course, Section);
            }
        }

        public string FullName {
            get { 
                var tempName = string.Empty;
                tempName += LastName != null ? LastName.ToUpper() : @" - ";
                tempName += FirstName != null ? String.Format(@", {0}", FirstName) : @" - ";
                tempName += MiddleName != null ? string.Format(@" {0}", MiddleName) : @" - ";
                return tempName;
            }
        }
    }
}
