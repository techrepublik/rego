using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintClassList : PrintStudentClass
    {
        public int ScheduleId { get; set; }
        public bool? IsRequest { get; set; }
        public String SubjectNo { get; set; }
        public String DescriptiveTitle { get; set; }
        public double? Lecture { get; set; }
        public double? Laboratory { get; set; }
        public double? Credit { get; set; }
        public string SchedIn { get; set; }
        public string SchedOut { get; set; }
        public string Days { get; set; }
        public string LecLab { get; set; }
        public string RoomNo { get; set; }
        public string ScheduleDetail { get; set; }
        public string Instructor { get; set; }
    }
}
