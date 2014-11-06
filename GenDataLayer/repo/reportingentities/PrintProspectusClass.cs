using System;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintProspectusClass
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseAbbreviation { get; set; }
        public string Duration { get; set; }
        public int ProspectusId { get; set; }
        public string ProspectusName { get; set; }
        public string Curriculum { get; set; }
        public string Description { get; set; }
        public string ProspectusNote { get; set; }
        public int SemYrId { get; set; }
        public int? Semester { get; set; }
        public string SemesterName { get; set; }
        public int? YearLevel { get; set; }
        public string SemYrNote { get; set; }
        public bool? IsCounted { get; set; }
        public int? SubjectId { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double? Lecture { get; set; }
        public double? Laboratory { get; set; }
        public double? Credit { get; set; }
        public bool? IsCreditable { get; set; }
        public bool? IsActive { get; set; }
        public int? ProspectusSubjectId { get; set; }
        public string PreRequsites { get; set; }

        public string Units
        {
            get
            {
                return String.Format(@"{0}, {1}, {2}",Lecture, Laboratory, Credit);
            }
        }
    }
}
