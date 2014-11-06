using System;

namespace GenDataLayer.repo.reportingentities
{
    public class PrintFeeClass
    {
        public int FeeTitleId { get; set; }
        public string FeeTitleName { get; set; }
        public int FeeSubTitleId { get; set; }
        public string FeeSubTitleName { get; set; }
        public int FeeParticularId { get; set; }
        public string FeeParticularName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AddAmount { get; set; }
        public decimal? Less { get; set; }
        public decimal? AddLess { get; set; }
        public decimal? NetAmount { get; set; }
        public bool? IsOriginal { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsValid { get; set; }

        public decimal GrossAmount 
        {
            get
            {
                //if (Amount != null)
                //{
                //    if (AddAmount != null)
                //    {
                //        total =+ (Amount + AddAmount);
                //    }
                //    else
                //    {
                //        total =+ (Amount + 0);
                //    }
                //}
                //else
                //{
                //    total =+ 0;
                //}
                var total = Convert.ToDecimal(Amount); // +Convert.ToDecimal(AddAmount);
                return total;
            }
        }
        public decimal LessAmount
        {
            get
            {
                //decimal? total;
                //if (Less != null)
                //{
                //    if (AddLess != null)
                //    {
                //        total =+ (Less + AddLess);
                //    }
                //    else
                //    {
                //        total =+ (Less + 0);
                //    }
                //}
                //else
                //{
                //    total =+ 0;
                //}
                return Convert.ToDecimal(Less);
            }
        }

        public decimal NetAmt
        {
            get { return GrossAmount - LessAmount; }
        }

        public decimal Balance
        {
            get { return NetAmt - Convert.ToDecimal(PaidAmount); }
        }
    }
}
