using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class DepartmentTeacherManager
    {
        private static DataRepository<DepartmentTeacher> _d;

        public static int Save(DepartmentTeacher departmentTeacher)
        {
            //var d = departmentTeacher;
            var d = new DepartmentTeacher
                {
                    DepartmentTeacherId = departmentTeacher.DepartmentTeacherId,
                    TeacherId = departmentTeacher.TeacherId,
                    DepartmentTeacherNote = departmentTeacher.DepartmentTeacherNote,
                    DepartmentId = departmentTeacher.DepartmentId,
                    DepartmentTeacherIsActive = departmentTeacher.DepartmentTeacherIsActive
                };
            using (_d = new DataRepository<DepartmentTeacher>())
            {
                if (departmentTeacher.DepartmentTeacherId > 0)
                    _d.Update(d);
                else
                    _d.Add(d);

                _d.SaveChanges();

                return d.DepartmentTeacherId;
            }
        }

        public static bool Delete(DepartmentTeacher departmentTeacher)
        {
            using (_d = new DataRepository<DepartmentTeacher>())
            {
                _d.Delete(d => d.DepartmentTeacherId == departmentTeacher.DepartmentTeacherId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<DepartmentTeacher>())
            {
                _d.Delete(d => d.DepartmentTeacherId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<DepartmentTeacher> GetAllDepartmentTeacherByDepartment(int iId)
        {
            using (_d = new DataRepository<DepartmentTeacher>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.Find(f => f.DepartmentId == iId).ToList();
            }
        }
    }
}
