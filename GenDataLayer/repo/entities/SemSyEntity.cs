using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class SemSyEntity
    {
        public int SemSyId { get; set; }
        public string Semester { get; set; }
        public string Sy { get; set; }
        public bool? Active { get; set; }
        public string SemesterName { get; set; }
        public string SemSyName
        {
            get { return string.Format(@"{0}, {1}", Semester, Sy); }
        }

        public string SemSyNameLabel
        {
            get { return string.Format(@"{0}, {1}", Semester, Sy); }
        }
    }
}
