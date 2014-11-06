using System;

namespace GenDataLayer.repo.entities
{
    public class RegistrationEntity : StudentEntity
    {
        public int? CourseId { get; set; }
        public int? YearLevelId { get; set; }
        public int? SectionId { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public int? ProspectusId { get; set; }
        public int? SemSyId { get; set; }
        public int? BranchId { get; set; }
        public bool? Cancelled { get; set; }
        public bool? Paid { get; set; }
        public bool? Enrolled { get; set; }
        public string CourseName { get; set; }
        public string CurriculumName { get; set; }
        public string StatusName { get; set; }
        public string TypeName { get; set; }
        public int? RegistrationId { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? UserId { get; set; }
        public int? ModifiedById { get; set; }
        public int? ScholarshipId1 { get; set; }
        public int? ScholarshipId2 { get; set; }
        public int? FinalScreenedBy { get; set; }
    }
}
