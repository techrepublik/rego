using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class AlliedSchoolsManager
    {
        private static DataRepository<AlliedSchool> _d;

        public static int Save(AlliedSchool alliedSchool)
        {
            var a = new AlliedSchool
                {
                    AlliedSchoolId = alliedSchool.AlliedSchoolId,
                    AlliedSchoolName = alliedSchool.AlliedSchoolName,
                    AlliedSchoolShortName = alliedSchool.AlliedSchoolShortName
                };
            using (_d = new DataRepository<AlliedSchool>())
            {
                if (alliedSchool.AlliedSchoolId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);

                _d.SaveChanges();    
            }

            return a.AlliedSchoolId;
        }

        public static bool Delete(AlliedSchool alliedSchool)
        {
            using (_d = new DataRepository<AlliedSchool>())
            {
                _d.Delete(d => d.AlliedSchoolId == alliedSchool.AlliedSchoolId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<AlliedSchool>())
            {
                _d.Delete(d => d.AlliedSchoolId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<AlliedSchool> GetAllAlliedShools()
        {
            using (_d = new DataRepository<AlliedSchool>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.GetAll().OrderBy(o => o.AlliedSchoolName).ToList();
            }
        }
    }
}
