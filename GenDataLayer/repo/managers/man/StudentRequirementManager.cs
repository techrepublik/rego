using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class StudentRequirementManager
    {
        private static DataRepository<StudentRequirement> _d;

        public static int Save(StudentRequirement studentRequirement)
        {
            using (_d = new DataRepository<StudentRequirement>())
            {
                var s = new StudentRequirement
                    {
                        StudentRequirementId = studentRequirement.StudentRequirementId,
                        RequirementId = studentRequirement.RequirementId,
                        StudentRequirementIsOk = studentRequirement.StudentRequirementIsOk,
                        StudentRequirementDate = studentRequirement.StudentRequirementDate,
                        StudentRequirementNote = studentRequirement.StudentRequirementNote,
                        StudentId = studentRequirement.StudentId
                    };
                if (studentRequirement.StudentRequirementId > 0)
                    _d.Update(s);
                else
                    _d.Add(s);
                _d.SaveChanges();

                return s.StudentRequirementId;
            }
        }

        public static bool Delete(StudentRequirement studentRequirement)
        {
            using (_d = new DataRepository<StudentRequirement>())
            {
                _d.Delete(d => d.StudentRequirementId == studentRequirement.StudentRequirementId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<StudentRequirement>())
            {
                _d.Delete(d => d.StudentRequirementId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<StudentRequirement> GetAllStudentRequirementsByStudent(int iId)
        {
            using (_d = new DataRepository<StudentRequirement>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.Find(f => f.StudentId == iId).OrderByDescending(o => o.StudentRequirementDate).ToList();
            }
        }
    }
}
