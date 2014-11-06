using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class SubjectStudentEntity : StudentEntity
    {
        public int? RegisterdSubjectId { get; set; }
        public bool? Regular { get; set; }
        public bool? Added { get; set; }
        public bool? Dropped { get; set; }
        public int? ScheduleId { get; set; }
        public int? RegistrationId { get; set; }
        public string Remarks { get; set; }
        public string FirstGrade { get; set; }
        public string SecondGrade { get; set; }
        public string ThirdGrade { get; set; }
        public string FourthGrade { get; set; }
        public string FifthGrade { get; set; }
        public string SixthGrade { get; set; }
        public bool? Posted { get; set; }
        public bool? PostEdited { get; set; }
        public DateTime? PostEditedDate { get; set; }
        public DateTime? PostedDate { get; set; }
        public string EditedBy { get; set; }
        public string ScheduleCode { get; set; }
    }
}
