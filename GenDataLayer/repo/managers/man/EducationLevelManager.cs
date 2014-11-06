using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class EducationLevelManager
    {
        private static DataRepository<EducationLevel> _d;

        public static int Save(EducationLevel educationLevel)
        {
            using (_d = new DataRepository<EducationLevel>())
            {
                var e = new EducationLevel
                    {
                        EducationLevelId = educationLevel.EducationLevelId,
                        EducationLevelName = educationLevel.EducationLevelName,
                        EducationLevelDisplay = educationLevel.EducationLevelDisplay
                    };
                if (educationLevel.EducationLevelId > 0)
                    _d.Update(e);
                else
                    _d.Add(e);
                _d.SaveChanges();

                return e.EducationLevelId;
            }
        }

        public static bool Delete(EducationLevel educationLevel)
        {
            using (_d = new DataRepository<EducationLevel>())
            {
                _d.Delete(d => d.EducationLevelId == educationLevel.EducationLevelId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<EducationLevel>())
            {
                _d.Delete(d => d.EducationLevelId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<EducationLevel> GetAllEducationLevels()
        {
            using (_d = new DataRepository<EducationLevel>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.GetAll().OrderBy(o => o.EducationLevelDisplay).ToList();
            }
        }
    }
}
