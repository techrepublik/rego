using System;

namespace GenDataLayer.repo.entities
{
    public class ReceiptDetailEntity : ReceiptDetail
    {
        public new int ReceiptId { get; set; }
        public string Particulars { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? Valid { get; set; }

        public string ReceiptNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
    }
}
