using System;

namespace GenDataLayer.repo.entities
{
    public class ReceiptEntity
    {
        public int ReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string StudentIdNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool? Valid { get; set; }
        public decimal? Amount { get; set; }
        public string Collector { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserMiddleName { get; set; }

        public string FullName
        {
            get { return String.Format(@"{0}, {1} {2}", LastName, FirstName, MiddleName); }
        }

        public string UserFullName
        {
            get { return String.Format(@"{0}, {1} {2}", UserLastName, UserFirstName, UserMiddleName); }
        }
    }
}
