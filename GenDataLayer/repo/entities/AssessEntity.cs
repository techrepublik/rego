using System;

namespace GenDataLayer.repo.entities
{
    public class AssessEntity : FeeParticular
    {
        public int AssessmentId { get; set; }
        public double? Amount { get; set; }
        public double? AddAmount { get; set; }
        public double? Less { get; set; }
        public double? AddLess { get; set; }
        public double? PercentLess { get; set; }
        public double? NetAmount { get; set; }
        public double? GrossAmount { get; set; }
        public bool? Original { get; set; }
        public int? RegistrationId { get; set; }
        public int? SubjectId { get; set; }
        public string LabParticulars { get; set; }

        public decimal? GrossAmt
        {
            get { return Convert.ToDecimal(Convert.ToDecimal(GrossAmount) + Convert.ToDecimal(AddAmount)); }
        }

        public decimal? Deduction
        {
            get { return Convert.ToDecimal(Less) + Convert.ToDecimal(AddLess); }
        }

        public decimal? NetAmt
        {
            get { return Convert.ToDecimal(GrossAmt) - Convert.ToDecimal(Deduction); }
        }
    }
}
