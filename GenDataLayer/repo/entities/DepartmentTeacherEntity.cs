using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class DepartmentTeacherEntity : Teacher
    {
        public int? DepartmentTeacherId { get; set; }
        public string Note { get; set; }
        public bool? Active { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string EmpStatusName { get; set; }

        public string FullName
        {
            get { return String.Format(@"{0}, {1} {2}", LastName, FirstName, MiddleName); }
        }
    }
}
