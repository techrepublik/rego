using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class StudentSubjectEntity : SubjectStudentEntity
    {
        public int SubjectScheduleId { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double? LaboratoryUnit { get; set; }
        public double? LectureUnit { get; set; }
        public double? CreditUnit { get; set; }
        public string Midterm { get; set; }
        public string FinalTerm { get; set; }
        public string ReGrade { get; set; }
        public string Remark { get; set; }
    }
}
