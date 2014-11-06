using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class LaboratoryFeeEntity : LaboratoryFee
    {
        public string Particulars { get; set; }
        public double? SubjectLabUnit { get; set; }
        public double? PercentLess { get; set; }
    }
}
