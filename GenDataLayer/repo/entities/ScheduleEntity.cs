using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ScheduleEntity : Schedule
    {
        public int? SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public double? Lecture { get; set; }
        public double? Laboratory { get; set; }
        public double? Credit { get; set; }
        public string UnitX { get; set; }

        public string ScheduleDetail { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Days { get; set; }
        public string LecLab { get; set; }
        public string RoomNo { get; set; }

        public string Units
        {
            get { return String.Format(@"{0}, {1}, {2}", Lecture, Laboratory, Credit); }
        }

        public int NoOfRegisted { get; set; }
    }
}
