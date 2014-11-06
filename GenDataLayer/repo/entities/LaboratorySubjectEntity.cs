using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class LaboratorySubjectEntity : Subject
    {
        public int LabSubjectId { get; set; }
        public int? LaboratoryFeeId  { get; set; }
        public bool? Active { get; set; }
    }
}
