using System;

namespace GenDataLayer.repo.entities
{
    public class TeacherEntity : Teacher
    {
        public new string Position { get; set; }
        public new string EmpStatus { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string FullName
        {
            get { return String.Format(@"{0}, {1} {2}", LastName, FirstName, MiddleName); }
        }
    }
}
