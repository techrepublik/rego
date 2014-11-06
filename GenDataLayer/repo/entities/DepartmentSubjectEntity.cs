using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class DepartmentSubjectEntity : Subject
    {
        public int DepartSubjectId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
