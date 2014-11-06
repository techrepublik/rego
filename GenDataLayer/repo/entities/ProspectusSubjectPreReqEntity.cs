using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class ProspectusSubjectPreReqEntity : ProspectusSubjectEntity
    {
        public int ProspectusSubjectPreReqId { get; set; }
        public string Note { get; set; }
        public bool? IsAndOr { get; set; }
    }
}
