using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers
{
    public class Validation
    {
        public static Student CheckStudentDuplicateIdNo(string idno)
        {
            using (var _d = new DataRepository<Student>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.FirstOrDefault(s => s.IdNo == idno);
            }
        }

        public static bool CheckSubjectStudentLimit()
        {
            return true;
        }
    }
}
