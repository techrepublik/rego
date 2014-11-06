using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class ReceiptManager
    {
        private static DataRepository<Receipt> _d;

        public static Receipt GetReceipt(int iReceiptId)
        {
            using (_d = new DataRepository<Receipt>())
            {
                return _d.FirstOrDefault(r => r.ReceiptId == iReceiptId);
            }
        }
    }
}
