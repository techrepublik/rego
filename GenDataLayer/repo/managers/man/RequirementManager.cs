using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class RequirementManager
    {
        private static DataRepository<Requirement> _d;

        public static int Save(Requirement requirement)
        {
            using (_d = new DataRepository<Requirement>())
            {
                var r = new Requirement
                    {
                        RequirementId = requirement.RequirementId,
                        RequirementName = requirement.RequirementName
                    };
                if (requirement.RequirementId > 0)
                    _d.Update(r);
                else
                    _d.Add(r);
                _d.SaveChanges();

                return r.RequirementId;
            }
        }

        public static bool Delete(Requirement requirement)
        {
            using (_d = new DataRepository<Requirement>())
            {
                _d.Delete(d => d.RequirementId == requirement.RequirementId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Requirement>())
            {
                _d.Delete(d => d.RequirementId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<Requirement> GetAllRequirements()
        {
            using (_d = new DataRepository<Requirement>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.GetAll().OrderBy(o => o.RequirementName).ToList();
            }
        }
    }
}
