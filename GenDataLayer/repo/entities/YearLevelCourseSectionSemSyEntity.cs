using System;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class YearLevelCourseSectionSemSyEntity : StudentEntity
    {
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public int? SemSyId { get; set; }
        public string SemSyName { get; set; }
        public new int StudentId { get; set; }
        public string ConcatenatedNames { get; set; }
        public int? RegistrationId { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public string CrsYearSection
        {
            get
            {
                var crsYeSec = new StringBuilder();
                if (YearLevelName != null)
                    crsYeSec.Append(YearLevelName + "/");
                if (CourseName != null)
                    crsYeSec.Append(CourseName + "/");
                if (SectionName != null)
                    crsYeSec.Append(SectionName);

                return crsYeSec.ToString();
            }
        }
    }
}
