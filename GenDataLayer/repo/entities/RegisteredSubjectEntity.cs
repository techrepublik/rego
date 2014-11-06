using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class RegisteredSubjectEntity : ScheduleEntity
    {
        public int RegisteredId { get; set; }
        public bool? Regular { get; set; }
        public bool? Added { get; set; }
        public bool? Dropped { get; set; }
        public string Remark { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Fourth { get; set; }
        public string Fifth { get; set; }
        public string Sixth { get; set; }
        public bool? Posted { get; set; }
        public bool? PostEdited { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime? PostEditedDate { get; set; }
        public string EditedBy { get; set; }
    }
}
