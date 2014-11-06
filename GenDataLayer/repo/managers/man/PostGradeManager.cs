using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class PostGradeManager
    {
        private static DataRepository<PostGrade> _d;

        public static int Save(PostGrade postGrade)
        {
            var p = new PostGrade
                {
                    PostGradeId = postGrade.PostGradeId,
                    PostModeId = postGrade.PostModeId,
                    PostGradeNo = postGrade.PostGradeNo,
                    PostGradeDate = postGrade.PostGradeDate,
                    PostGradeNote = postGrade.PostGradeNote,
                    TeacherSubjectId = postGrade.TeacherSubjectId,
                    EditedBy = postGrade.EditedBy,
                    PostGradeAccepted = postGrade.PostGradeAccepted,
                    PostGradeAcceptedBy = postGrade.PostGradeAcceptedBy
                };
            using (_d = new DataRepository<PostGrade>())
            {
                if (postGrade.PostGradeId > 0)
                    _d.Update(p);
                else
                    _d.Add(p);

                _d.SaveChanges();

                return p.PostGradeId;
            }
        }

        public static bool Delete(PostGrade postGrade)
        {
            using (_d = new DataRepository<PostGrade>())
            {
                _d.Delete(d => d.PostGradeId == postGrade.PostGradeId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<PostGrade> GetAll(int teacherSubjectId)
        {
            using (_d = new DataRepository<PostGrade>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.Find(f => f.TeacherSubjectId == teacherSubjectId).ToList();
            }
        }

        public static int GetLastNo()
        {
            using (_d = new DataRepository<PostGrade>())
            {
                var singleOrDefault = _d.GetAll().OrderByDescending(o => o.PostGradeId).Take(1).SingleOrDefault();
                var iResult = 0;
                if (singleOrDefault != null)
                    iResult = singleOrDefault.PostGradeId;

                return iResult + 1;
            }
        }
    }
}
