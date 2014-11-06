using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenDataLayer.repo.entities;

namespace GenDataLayer.repo.managers.man
{
    public class ScheduleManager
    {
        public static List<ScheduleEntity> GetScheduleDetail(int iCrsYrSecId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Schedules
                        join q1 in e.CourseSecSchedules on q0.CourseSecScheduleId equals q1.CourseSecScheduleId
                        join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in e.Subjects on q2.SubjectId equals q3.SubjectId
                        join q4 in e.ScheduleDetails on q0.ScheduleId equals q4.ScheduleId into q04
                        from q04a in q04.DefaultIfEmpty()
                        where (q0.CourseSecScheduleId == iCrsYrSecId)
                        select new ScheduleEntity
                        {
                            ScheduleId = q0.ScheduleId,
                            ScheduleCode = q0.ScheduleCode,
                            StudentLimit = q0.StudentLimit,
                            StudentAdded = q0.StudentAdded,
                            IsDeleted = q0.IsDeleted,
                            IsRequested = q0.IsRequested,
                            IsActive = q0.IsActive,
                            SubjectCode = q3.SubjectNo,
                            SubjectName = q3.SubjectDescriptiveTitle,
                            Lecture = q3.SubjectLecUnit,
                            Laboratory = q3.SubjectLabUnit,
                            Credit = q3.SubjectCreUnit,
                            TimeIn = q04a.TimeIn,
                            TimeOut = q04a.TimeOut,
                            Days = q04a.Days,
                            LecLab = q04a.LecLab,
                            RoomNo = q04a.Room.RoomNo
                        };

                var list = new List<ScheduleEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    if (item == null)
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        scheduleEntity.ScheduleDetail = schedule;
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        }

        public static List<ScheduleEntity> GetScheduleDetail(int iSemSyId, int iCourse, int iYearLevel, int iSection)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Schedules
                        join q1 in e.CourseSecSchedules on q0.CourseSecScheduleId equals q1.CourseSecScheduleId
                        join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in e.Subjects on q2.SubjectId equals q3.SubjectId
                        join q4 in e.ScheduleDetails on q0.ScheduleId equals q4.ScheduleId into q04
                        from q04a in q04.DefaultIfEmpty()
                        where
                            ((iSemSyId == q1.SemSyId) && (iCourse == q1.CourseId) && (iYearLevel == q1.YearLevelId) &&
                             (iSection == q1.SectionId))
                        select new ScheduleEntity
                            {
                                ScheduleId = q0.ScheduleId,
                                ScheduleCode = q0.ScheduleCode,
                                StudentLimit = q0.StudentLimit,
                                StudentAdded = q0.StudentAdded,
                                IsDeleted = q0.IsDeleted,
                                IsRequested = q0.IsRequested,
                                IsActive = q0.IsActive,
                                SubjectCode = q3.SubjectNo,
                                SubjectName = q3.SubjectDescriptiveTitle,
                                Lecture = q3.SubjectLecUnit,
                                Laboratory = q3.SubjectLabUnit,
                                Credit = q3.SubjectCreUnit,
                                TimeIn = q04a.TimeIn,
                                TimeOut = q04a.TimeOut,
                                Days = q04a.Days,
                                LecLab = q04a.LecLab,
                                RoomNo = q04a.Room.RoomNo
                            };

                var list = new List<ScheduleEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    if (item == null)
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        scheduleEntity.ScheduleDetail = schedule;
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        }

        public static ScheduleEntity GetScheduleDetailByCode(string code)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Schedules
                        join q1 in e.CourseSecSchedules on q0.CourseSecScheduleId equals q1.CourseSecScheduleId
                        join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in e.Subjects on q2.SubjectId equals q3.SubjectId
                        join q4 in e.ScheduleDetails on q0.ScheduleId equals q4.ScheduleId into q04
                        from q04a in q04.DefaultIfEmpty()
                        where (q0.ScheduleCode == code)
                        select new ScheduleEntity
                        {
                            ScheduleId = q0.ScheduleId,
                            ScheduleCode = q0.ScheduleCode,
                            StudentLimit = q0.StudentLimit,
                            StudentAdded = q0.StudentAdded,
                            IsDeleted = q0.IsDeleted,
                            IsRequested = q0.IsRequested,
                            IsActive = q0.IsActive,
                            SubjectCode = q3.SubjectNo,
                            SubjectName = q3.SubjectDescriptiveTitle,
                            Lecture = q3.SubjectLecUnit,
                            Laboratory = q3.SubjectLabUnit,
                            Credit = q3.SubjectCreUnit,
                            TimeIn = q04a.TimeIn,
                            TimeOut = q04a.TimeOut,
                            Days = q04a.Days,
                            LecLab = q04a.LecLab,
                            RoomNo = q04a.Room.RoomNo
                        };

                var subjectSchedule = new ScheduleEntity();
                var iCounter = 0;
                foreach (var scheduleEntity in q)
                {
                    iCounter += 1;
                    if (iCounter == 1)
                    {
                        subjectSchedule = scheduleEntity;
                    }
                    var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                    scheduleEntity.TimeIn,
                                                    scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                    scheduleEntity.RoomNo);
                    //scheduleEntity.ScheduleDetail = schedule;
                    subjectSchedule.ScheduleDetail += schedule + " : "; 
                }
                
                return subjectSchedule;
            }
        }

        //edited by josh 11.11.13
        #region RegisteredSubjects
        public static List<RegisteredSubjectEntity> GetAllRegisteredSubjectEntity(int iRegistrationId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.RegisteredSchedules
                        join q1 in e.Schedules on q0.ScheduleId equals q1.ScheduleId into q01
                        from q01a in q01.DefaultIfEmpty()
                        join q1a in e.ScheduleDetails on q01a.ScheduleId equals q1a.ScheduleId into q1q0a from q1q0a1 in q1q0a.DefaultIfEmpty()
                        join q2 in e.ProspectusSubjects on q01a.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in e.Subjects on q2.SubjectId equals q3.SubjectId
                        where (q0.RegistrationId == iRegistrationId)
                        select new RegisteredSubjectEntity
                        {
                            RegisteredId = q0.RegisteredScheduleId,
                            Regular = q0.IsRegular,
                            Added = q0.IsAdded,
                            Dropped = q0.IsDropped,
                            ScheduleCode = q0.ScheduleCode,
                            ScheduleId = q01a.ScheduleId,
                            SubjectId = q3.SubjectId,
                            Remark = q0.Remark,
                            First = q0.FirstGrading,
                            Second = q0.SecondGrading,
                            Third = q0.ThirdGrading,
                            Fourth = q0.FourthGrading,
                            Fifth = q0.FifthGrading,
                            Sixth = q0.SixthGrading,
                            Posted = q0.IsPosted,
                            PostEdited = q0.IsPostEdited,
                            PostedDate = q0.PostedDate,
                            PostEditedDate = q0.PostEditedDate,
                            EditedBy = q0.EditedBy,
                            StudentLimit = q01a.StudentLimit,
                            StudentAdded = q01a.StudentAdded,
                            IsDeleted = q01a.IsDeleted,
                            IsRequested = q01a.IsRequested,
                            IsActive = q01a.IsActive,
                            SubjectCode = q3.SubjectNo,
                            SubjectName = q3.SubjectDescriptiveTitle,
                            Lecture = q3.SubjectLecUnit,
                            Laboratory = q3.SubjectLabUnit,
                            Credit = q3.SubjectCreUnit,
                            TimeIn = q1q0a1.TimeIn,
                            TimeOut = q1q0a1.TimeOut,
                            Days = q1q0a1.Days,
                            LecLab = q1q0a1.LecLab,
                            RoomNo = q1q0a1.Room.RoomNo
                        };
                var list = new List<RegisteredSubjectEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    var schedule = @"";
                    if (item == null)
                    {
                        schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        scheduleEntity.ScheduleDetail = schedule + " : ";
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.RoomNo);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        }
        #endregion

        //edited by josh 11/13.13
        public static List<CourseSecScheduleEntity> GetAllCourseSecScheduleEntity(int iCollegeId, int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.CourseSecSchedules
                        join q1 in e.Courses on q0.CourseId equals q1.CourseId
                        join q2 in e.Departments on q1.DepartmentId equals q2.DepartmentId
                        join q3 in e.YearLevels on q0.YearLevelId equals q3.YearLevelId
                        join q4 in e.Sections on q0.SectionId equals q4.SectionId
                        join q5 in e.SemSys on q0.SemSyId equals q5.SemSyId
                        where ((q2.CollegeId == iCollegeId) && (q0.SemSyId == iSemSyId))
                        select new CourseSecScheduleEntity
                            {
                                CourseSecScheduleEntityId = q0.CourseSecScheduleId,
                                IsActive = q0.IsActive,
                                CourseName = q1.Abbreviation,
                                YearLevelName = q3.YearLevelName,
                                SectionName = q4.SectionName,
                                Semester = q5.Semester,
                                Sy = q5.Sy
                            };
                return q.OrderBy(o => o.CourseName).ToList();
            }
        }

        public static College GetStudentCollege(int iCourseId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Colleges
                        join q1 in e.Departments on q0.CollegeId equals q1.CollegeId
                        join q2 in e.Courses on q1.DepartmentId equals q2.DepartmentId
                        where (q2.CourseId == iCourseId)
                        select q0;
                return q.SingleOrDefault();
            }
        }

        public static int GetRegisteredStudentsBySchedule(int iScheduleId)
        {
            using (var e = new ESEntities())
            {
                var q = (from q0 in e.RegisteredSchedules
                        where (q0.ScheduleId == iScheduleId)
                        select q0).Distinct();
                return q.Count();

            }
        }

        //public static List<StudentLedgerEntity> ListStudentLedgerByRegistration(int iRegistrationId)
        //{
        //    using (var _e = new ESEntities())
        //    {
        //        var q = from q0 in _e.Assessments
        //                join q1a in _e.FeeParticulars on q0.FeeParticularId equals q1a.FeeParticularId
        //                join q1 in _e.ReceiptDetails on q0.AssessmentId equals q1.AssessmentId into q01
        //                from q01a in q01.DefaultIfEmpty()
        //                where (q0.RegistrationId == iRegistrationId)
        //                group q0 by new
        //                {
        //                    RegistrationId = q0.RegistrationId,
        //                    ParticularId = q1a.FeeParticularId,
        //                    ParticularName = q1a.Particulars
        //                }
        //                    into qSum
        //                    select new StudentLedgerEntity
        //                    {
        //                        RegistrationId = qSum.Key.RegistrationId,
        //                        ParticularId = qSum.Key.ParticularId,
        //                        ParticularName = qSum.Key.ParticularName,
        //                        AssessedAmount = qSum.Sum(a => a.GrossAmount),
        //                        AssessedAdd = qSum.Sum(a => a.AddAmount),
        //                        AssessedDeduction = qSum.Sum(a => a.Less),
        //                        AssessedDeducAdd = qSum.Sum(a => a.AddLess),
        //                        PaidAmount = qSum.Sum(a => a.ReceiptDetails.Sum(b => b.Amount))
        //                    };
        //        return q.ToList();
        //    }
        //}

    }
}
