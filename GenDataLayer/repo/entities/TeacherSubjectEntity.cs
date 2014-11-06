using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class TeacherSubjectEntity : SubjectEntity
    {
        public int? TeacherSubjectId { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherSubjectNote { get; set; }
        public bool? Active { get; set; }
        public bool? OnUs { get; set; }
        public bool? Posted { get; set; }
        public bool? PostEdited { get; set; }
        public int? PostPodeId { get; set; }
        public bool? Mode { get; set; }
        public string PostedBy { get; set; }
        public DateTime? PostedDate { get; set; }
        public string TeacherIdNo { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherMiddleName { get; set; }

        public string TeacherName
        {
            get
            {
                return String.Format(@"{0}, {1} {2}", TeacherLastName, TeacherFirstName,
                                     TeacherMiddleName);
            }
        }
    }
}
