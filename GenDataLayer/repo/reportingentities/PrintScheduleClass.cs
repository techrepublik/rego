
namespace GenDataLayer.repo.reportingentities
{
    public class PrintScheduleClass
    {
        //Main
        public int SemSyId { get; set; }
        public string Semester { get; set; }
        public string Sy { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
        public int YearLevelId { get; set; }
        public string YearLevel { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int ScheduleId { get; set; }
        public int? StudentLimit { get; set; }
        public int? Added { get; set; }
        public bool? Active { get; set; }
        public bool? Requested { get; set; }
        public bool? Deleted { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double? Lecture { get; set; }
        public double? Laboratory { get; set; }
        public double? Credit { get; set; }

        //Details
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string TimeSchedule { get; set; }
        public string Days { get; set; }
        public string LecLab { get; set; }
        public string RoomNo { get; set; }

        public string Units
        {
            get { return string.Format(@"{0}, {1}, {2}", Lecture, Laboratory, Credit); }
        }

        public string TimePeriod
        {
            get { return TimeIn + " - " + TimeOut; }
        }

        public string CrsYrSec
        {
            get { return Course + "/" + YearLevel + "/" + SectionName; }
        }

        public string Limits
        {
            get { return string.Format(@"{0} - {1}", StudentLimit, Added); }
        }
    }
}
