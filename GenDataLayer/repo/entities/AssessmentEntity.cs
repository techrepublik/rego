using System;
namespace GenDataLayer.repo.entities
{
    public class AssessmentEntity : Assessment
    {
        public string Description { get; set; }
        public bool? IsTuition { get; set; }

        public int? PresetFeeId { get; set; }
        public string Particulars { get; set; }

        public decimal? TotalAmount { get; set; }
        public new decimal? NetAmount { get; set; }

        public int? LabId { get; set; }
        public bool HasLaboratory { get; set; }

        public int? SemSyId { get; set; }

        public decimal? GrossAmt
        {
            get { return Convert.ToDecimal(Convert.ToDecimal(Amount) + Convert.ToDecimal(AddAmount)); }
        }

        public decimal? Deduction
        {
            get { return Convert.ToDecimal(Less) + Convert.ToDecimal(AddLess); }
        }

        public decimal? NetAmt
        {
            get { return Convert.ToDecimal(GrossAmount) - Convert.ToDecimal(Deduction); }
        }

    }
}
