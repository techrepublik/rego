using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class StudentBalanceEntity : YearLevelCourseSectionSemSyEntity
    {
        public decimal? AssessedAmount { get; set; }
        public decimal? AssessedAdd { get; set; }
        public decimal? AssessedDeduction { get; set; }
        public decimal? AssessedDeducAdd { get; set; }
        public decimal? PaidAmount { get; set; }

        public decimal? Balance
        {
            get
            {
                var tempBalance = Convert.ToDecimal(AssessedAmount) + Convert.ToDecimal(AssessedAdd);
                var tempDeduct = Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd) + Convert.ToDecimal(PaidAmount);
                return tempBalance - tempDeduct;
            }
        }

        public decimal? Debit
        {
            get { return Convert.ToDecimal(AssessedAmount) + Convert.ToDecimal(AssessedDeducAdd); }
        }

        public decimal? Credit
        {
            get { return Convert.ToDecimal(AssessedDeduction) + Convert.ToDecimal(AssessedDeducAdd) + Convert.ToDecimal(PaidAmount); }
        }

        public float? Percent { get; set; }
    }
}
