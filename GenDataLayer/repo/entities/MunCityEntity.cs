using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class MunCityEntity : Province
    {
        public new string ProvinceName { get; set; }
        public string MunCityName { get; set; }
    }
}
