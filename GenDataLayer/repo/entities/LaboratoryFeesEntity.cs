using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class LaboratoryFeesEntity
    {
        public int LaboratoryFeeId { get; set; }
        public int? SemYrId { get; set; }
        public int? FeeParticularId { get; set; }
        public decimal? Amount { get; set; }
        public string Particular { get; set; }
        public int? SubjectId { get; set; }
        public string SubectNo { get; set; }

        public string ParticularLabel {
            get { return String.Format(@"{0},  {1}", Particular, SubectNo); }
        }

        public string DisplayLabel
        {
            get {return String.Format("{0}, {1:000.00}",Particular, Amount); }
        }
    }
}
