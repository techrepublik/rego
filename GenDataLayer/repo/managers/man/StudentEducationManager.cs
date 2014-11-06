using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class StudentEducationManager
    {
        private static DataRepository<SchoolEducation> _d;

        public static int Save(SchoolEducation schoolEducation)
        {
            using (_d = new DataRepository<SchoolEducation>())
            {
                var s = new SchoolEducation
                    {
                        SchoolEducationId = schoolEducation.SchoolEducationId,
                        SchoolEducationAddress = schoolEducation.SchoolEducationAddress,
                        SchoolEducationYearLast = schoolEducation.SchoolEducationYearLast,
                        AlliedSchoolId = schoolEducation.AlliedSchoolId,
                        EduactionLevelId = schoolEducation.EduactionLevelId,
                        StudentId = schoolEducation.StudentId
                    };
                if (schoolEducation.SchoolEducationId > 0)
                    _d.Update(s);
                else
                    _d.Add(s);
                _d.SaveChanges();

                return s.SchoolEducationId;
            }
        }

        public static bool Delete(SchoolEducation schoolEducation)
        {
            using (_d = new DataRepository<SchoolEducation>())
            {
                _d.Delete(d => d.SchoolEducationId == schoolEducation.SchoolEducationId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<SchoolEducation>())
            {
                _d.Delete(d => d.SchoolEducationId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<SchoolEducation> GetAllSchoolEducationByStudent(int iStudentId)
        {
            using (_d = new DataRepository<SchoolEducation>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.Find(f => f.StudentId == iStudentId).OrderBy(o => o.SchoolEducationId).ToList();
            }
        }
    }
}
