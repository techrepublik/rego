
namespace GenDataLayer.repo.entities
{
    public class SchedulingEntity : Subject
    {
        public int ScheduleId { get; set; }
        public string ScheduleCode { get; set; }
        public int? Limit { get; set; }
        public int? Added { get; set; }
        public bool? Deleted { get; set; }
        public bool? Requested { get; set; }
        public bool? Active { get; set; }
        public int? ProspectusSubjectId { get; set; }
        public int? CourseSecScheduleId { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }
        public string CourseName { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Days { get; set; }
        public string Room { get; set; }
        public string LecLab { get; set; }
        public string FacultyIdNo { get; set; }
        public string FacultyLastName { get; set; }
        public string FacultyFirstName { get; set; }
        public string FacultyMiddleName { get; set; }
        public string ScheduleDetail { get; set; }

        public string YrCrsSec
        {
            get { return string.Format(@"{0}/{1}/{2}", YearLevel, CourseName, Section); }
        }

        public string SubjectProfile
        {
            get
            {
                return string.Format(@"{0} - {1} {2}:{3}:{4}", SubjectNo, SubjectDescriptiveTitle, SubjectLecUnit,
                                     SubjectLabUnit, SubjectCreUnit);
            }
        }

        public string FacultyDetail
        {
            get
            {
                return string.Format(@"{0} - {1}, {2} {3}", FacultyIdNo, FacultyLastName, FacultyFirstName,
                                     FacultyMiddleName);
            }
        }
    }
}
