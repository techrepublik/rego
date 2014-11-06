
namespace GenDataLayer.repo.entities
{
    public class CourseSecScheduleEntity : SemSyEntity
    {
        public int CourseSecScheduleEntityId { get; set; }
        public new int? SemSyId { get; set; }
        public int? CourseId { get; set; }
        public int? YearLevelId { get; set; }
        public int? SectionId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }

        public new string SemSyName { get; set; }
        public string CourseName { get; set; }
        public string YearLevelName { get; set; }
        public string SectionName { get; set; }

        public string DisplayCaption
        {
            get { return string.Format(@"{0}/{1}/{2}", CourseName, YearLevelName, SectionName); }
        }
    }
}
