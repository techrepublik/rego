using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class ReceiptDetailManager
    {
        private static DataRepository<ReceiptDetail> _d;

        public static int Save(ReceiptDetail receiptDetail)
        {
            var r = new ReceiptDetail
                {
                    ReceiptDetailId = receiptDetail.ReceiptDetailId,
                    ReceiptId = receiptDetail.ReceiptId,
                    AssessmentId = receiptDetail.AssessmentId,
                    FeeParticularId = receiptDetail.FeeParticularId,
                    Amount = receiptDetail.Amount,
                    IsValid = receiptDetail.IsValid,
                    CollectionName = receiptDetail.CollectionName
                };
            using (_d = new DataRepository<ReceiptDetail>())
            {
                if (receiptDetail.ReceiptDetailId > 0)
                    _d.Update(r);
                else
                    _d.Add(r);

                _d.SaveChanges();
            }
            return r.ReceiptDetailId;
        }

        public static List<ReceiptDetail> GetAllReceiptDetail(int iReceiptId)
        {
            using (_d = new DataRepository<ReceiptDetail>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.Find(r => r.ReceiptId == iReceiptId).ToList();
            }
        }
    }
}
