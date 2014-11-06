using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ProspectusSubjectEntity
    {
        public int? ProspectusSubjectId { get; set; }
        public int ProspectusSemYrId { get; set; }
        public bool IsCounted { get; set; }
        public int? SubjectId { get; set; }
        public string SubjectNo { get; set; }
        public string DescriptiveTitle { get; set; }
        public double? Lecture { get; set; }
        public double? Laboratory { get; set; }
        public double? Credit { get; set; }
    }
}
