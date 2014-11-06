using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers.man
{
    public class TeacherSubjectManager
    {
        private static DataRepository<TeacherSubject> _d;

        public static int Save(TeacherSubject teacherSubject)
        {
            var t = new TeacherSubject
                {
                    TeacherSubjectId = teacherSubject.TeacherSubjectId,
                    TeacherId = teacherSubject.TeacherId,
                    ScheduleId = teacherSubject.ScheduleId,
                    TeacherSubjectNote = teacherSubject.TeacherSubjectNote,
                    TeacherSubjectIsActive = teacherSubject.TeacherSubjectIsActive,
                    TeacherSubjectOnUs = teacherSubject.TeacherSubjectOnUs,
                    TeacherSubjectPosted = teacherSubject.TeacherSubjectPosted,
                    TeacherSubjectPostEdited = teacherSubject.TeacherSubjectPostEdited,
                    TeacherSubjectPostedDate = teacherSubject.TeacherSubjectPostedDate,
                    TeacherSubjectPostMode = teacherSubject.TeacherSubjectPostMode,
                    TeacherSubjectPostedBy = teacherSubject.TeacherSubjectPostedBy
                };

            using (_d = new DataRepository<TeacherSubject>())
            {
                if (teacherSubject.TeacherSubjectId > 0)
                    _d.Update(t);
                else
                    _d.Add(t);

                _d.SaveChanges();

                return t.TeacherSubjectId;
            }
        }

        public static bool Delete(TeacherSubject teacherSubject)
        {
            using (_d = new DataRepository<TeacherSubject>())
            {
                _d.Delete(d => d.TeacherSubjectId == teacherSubject.TeacherSubjectId);
                _d.SaveChanges();

                return true;
            }
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<TeacherSubject>())
            {
                _d.Delete(d => d.TeacherSubjectId == iId);
                _d.SaveChanges();

                return true;
            }
        }

        public static List<TeacherSubject> GetAllTeacherSubjectByTeacherId(int iId)
        {
            using (_d = new DataRepository<TeacherSubject>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.Find(f => f.TeacherId == iId).ToList();
            }
        }
    }
}
