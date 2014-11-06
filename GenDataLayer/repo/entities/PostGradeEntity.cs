using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class PostGradeEntity : TeacherEntity
    {
        public int PostGradeId { get; set; }
        public string PostGradeNo { get; set; }
        public DateTime? PostGradeDate { get; set; }
        public string PostModeName { get; set; }
        public string PostGradeNote { get; set; }
        public string EditedBy { get; set; }
        public bool? PostGradeAccepted { get; set; }
        public string PostGradeAcceptedBy { get; set; }

    }
}
