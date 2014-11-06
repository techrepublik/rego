using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class PostModeManager
    {
        private static DataRepository<PostMode> _d;

        public static int Save(PostMode postMode)
        {
            var p = new PostMode
                {
                    PostModeId = postMode.PostModeId,
                    PostModeName = postMode.PostModeName,
                    PostModeDescription = postMode.PostModeDescription,
                    PostModeStaff = postMode.PostModeStaff,
                    PostModeTeacher = postMode.PostModeTeacher
                };
            using (_d = new DataRepository<PostMode>())
            {
                if (postMode.PostModeId > 0)
                    _d.Update(p);
                else
                    _d.Add(p);

                _d.SaveChanges();

                return p.PostModeId;
            }

        }

        public static bool Delete(PostMode postMode)
        {
            using (_d = new DataRepository<PostMode>())
            {
                _d.Delete(d => d.PostModeId == postMode.PostModeId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<PostMode> GetAll()
        {
            using (_d = new DataRepository<PostMode>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.GetAll().OrderBy(o => o.PostModeName).ToList();
            }
        }
    }
}
