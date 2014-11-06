using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class YearLevelCourseSectionEntity
    {
        public int YearLevelId { get; set; }
        public int CouseLevelId { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
    }

}
