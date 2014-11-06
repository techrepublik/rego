using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class StreetEntity : StreetHous
    {
        public string ProvinceName { get; set; }
        public string MunCityName { get; set; }
        public string BarangayName { get; set; }
    }
}
