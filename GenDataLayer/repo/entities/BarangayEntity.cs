using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class BarangayEntity : Barangay
    {
        public string ProvinceName { get; set; }
        public string MunCityName { get; set; }
        public new string BarangayName { get; set; }
    }
}
