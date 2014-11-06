using System;

namespace GenDataLayer.repo.entities
{
    public class StudentLedgerEntity
    {
        public int? ParticularId { get; set; }
        public int? RegistrationId { get; set; }
        public string ParticularName { get; set; }
        public string ParticularName1 { get; set; }
        public decimal? AssessedAmount { get; set; }
        public decimal? AssessedAdd { get; set; }
        public decimal? AssessedDeduction { get; set; }
        public decimal? AssessedDeducAdd { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? Valid { get; set; }
        public int? AssessmentId { get; set; }

        public Decimal? Balance
        {
            get
            {
                var tempBalance = 0.0m;
                var tempDeduct = 0.00m;
                if (Valid == true)
                {
                    tempBalance = Convert.ToDecimal(AssessedAmount) + Convert.ToDecimal(AssessedAdd);
                    tempDeduct = Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd) +
                                     Convert.ToDecimal(PaidAmount);
                }
                else
                {
                    tempBalance = Convert.ToDecimal(AssessedAmount) + Convert.ToDecimal(AssessedAdd);
                    tempDeduct = Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd);
                }
                return tempBalance - tempDeduct;
            } 
        }

        public decimal? Debit
        {
            get
            {
                return Convert.ToDecimal(AssessedAmount) + Convert.ToDecimal(AssessedAdd);
            }
        }

        public decimal? Credit
        {
            get
            {
                var credit = 0.00m;
                if (Valid == true)
                    credit = Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd) + Convert.ToDecimal(PaidAmount);
                else
                    credit = Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd);

                return credit;
            }
        }

        public float? Percent { get; set; }
    }
}
