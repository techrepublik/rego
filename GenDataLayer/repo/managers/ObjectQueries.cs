using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;

namespace GenDataLayer.repo.managers
{
    public class ObjectQueries
    {
        //edited by josh 4.9.13
        #region College
        public static College GetCollegeSingle(int iCollegeId)
        {
            using (var dCollege = new DataRepository<College>())
            {
                return dCollege.Single(c => c.CollegeId == iCollegeId);
            }
        }

        public static List<College> GetAllColleges(int iBranchId)
        {
            using (var dCollege = new DataRepository<College>())
            {
                return dCollege.Find(f => f.BranchId == iBranchId).ToList();
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region Department
        public static Department GetDepartmentSingle(int iDepartmentId)
        {
            using (var _d = new DataRepository<Department>())
            {
                return _d.Single(d => d.DepartmentId == iDepartmentId);
            }
        }

        public static IList<Department> GetDepartmentsCollege(int iCollegeId)
        {
            using (var _d = new DataRepository<Department>())
            {
                return _d.GetAll().Where(s => s.CollegeId == iCollegeId).OrderBy(r => r.DepartmentName).ToList();
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region Course
        public static Cours GetCourseSingle(int iCourseId)
        {
            using (var _d = new DataRepository<Cours>())
            {
                return _d.Single(c => c.CourseId == iCourseId);
            }
        }

        public static IList<Cours> GetCourseDepartment(int iDepartmentId)
        {
            using (var _d = new DataRepository<Cours>())
            {
                return _d.GetAll().Where(s => s.DepartmentId == iDepartmentId).OrderBy(r => r.CourseName).ToList();
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region FeeTitle
        public static FeeTitle GetFeeTitleSingle(int iFeeTitleId)
        {
            using (var _d = new DataRepository<FeeTitle>())
            {
                return _d.Single(f => f.FeeTitleId == iFeeTitleId);
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region FeeSubTitle
        public static FeeSubTitle GetFeeSubTitleSingle(int iFeeSubTitleId)
        {
            using (var _d = new DataRepository<FeeSubTitle>())
            {
                return _d.Single(f => f.FeeSubTitleId == iFeeSubTitleId);
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region FeeParticular
        public static FeeParticular GetFeeParticularSingle(int iFeeParticulatId)
        {
            using (var _d = new DataRepository<FeeParticular>())
            {
                return _d.Single(f => f.FeeParticularId == iFeeParticulatId);
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region Subject
        public static List<Subject> GetSubjectList()
        {
            using (var _d = new DataRepository<Subject>())
            {
                return _d.GetAll().OrderBy(s => s.SubjectNo).ToList();
            }
        }

        public static IEnumerable<Subject> FindSubjectList(string sValue)
        {
            using (var _d = new DataRepository<Subject>())
            {
                return sValue.Length > 0
                           ? _d.Find(
                           s => (s.SubjectNo.StartsWith(sValue))) : null; // || s.SubjectDescriptiveTitle.StartsWith(sValue)))
            }
        }
        #endregion

        //edited by josh 4.10.13
        #region Rooms
        public static List<Room> GetRoomList()
        {
            using (var _d = new DataRepository<Room>())
            {
                return _d.GetAll().OrderBy(r => r.RoomNo).ToList();
            }
        }

        public static List<Room> GetRoomListByCollege(int iCollegeId)
        {
            using (var _d = new DataRepository<Room>())
            {
                return _d.Find(r => r.CollegeId == iCollegeId).ToList();
            }
        }
        #endregion

        //edited by josh 4.9.13
        #region Prospectus
        public static Prospectus GetProspectusSingle(int iProspectusId)
        {
            using (var _d = new DataRepository<Prospectus>())
            {
                return _d.Single(p => p.ProspectusId == iProspectusId);
            }
        }

        public static IList<Prospectus> GetProspectusCourse(int iCouseId)
        {
            using (var _d = new DataRepository<Prospectus>())
            {
                return _d.GetAll().Where(s => s.CourseId == iCouseId).OrderBy(r => r.ProspectusName).ToList();
            }
        }
        #endregion

        //edited by josh 4.10.13
        #region DepartmentSubject
        public static IEnumerable<DepartmentSubject> GetDepartmentSubjects()
        {
            using (var _d = new DataRepository<DepartmentSubject>())
            {
                return _d.GetAll();
            }
        }

        public static List<DepartmentSubjectEntity> GetDepartmentSubjectEntities(int iDepartmentId)
        {
            using (var _e = new ESEntities())
            {
                var q = from d in _e.DepartmentSubjects
                        where d.DepartmentId == iDepartmentId
                        select new DepartmentSubjectEntity
                                   {
                                       DepartmentId = (int)d.DepartmentId,
                                       DepartSubjectId = d.DepartmentSubjectId,
                                       SubjectId = (int)d.SubjectId,
                                       SubjectNo = d.Subject.SubjectNo,
                                       SubjectDescriptiveTitle = d.Subject.SubjectDescriptiveTitle,
                                       SubjectLecUnit = d.Subject.SubjectLecUnit,
                                       SubjectLabUnit = d.Subject.SubjectLabUnit,
                                       SubjectCreUnit = d.Subject.SubjectCreUnit,
                                       IsCreditable = d.Subject.IsCreditable,
                                       IsActive = d.Subject.IsActive,
                                       DateAdded = (DateTime) d.DateAdded
                                   };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 4.14.13
        #region ProspectusSubject
        public static IList<ProspectusSubjectEntity> GetProspectusSubjectEntities(int iProspectusSemYrId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ProspectusSubjects
                        where (p.ProspectusSemYrId == iProspectusSemYrId)
                        orderby p.Subject.SubjectNo
                        select new ProspectusSubjectEntity
                                   {
                                       ProspectusSemYrId = (int)p.ProspectusSemYrId,
                                       ProspectusSubjectId = p.ProspectusSubjectId,
                                       SubjectId = (int)p.SubjectId,
                                       SubjectNo = p.Subject.SubjectNo,
                                       DescriptiveTitle = p.Subject.SubjectDescriptiveTitle,
                                       Lecture = p.Subject.SubjectLecUnit,
                                       Laboratory = p.Subject.SubjectLabUnit,
                                       Credit = p.Subject.SubjectCreUnit,
                                       IsCounted = (bool)p.IsCounted
                                   };
                return q.ToList();
            }
        }

        public static IList<ProspectusSubjectEntity> GetProspectusSubjectEntitiesAll(int iSem)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ProspectusSubjects
                        where (p.ProspectusSemYr.Semester == iSem)
                        orderby p.Subject.SubjectNo
                        select new ProspectusSubjectEntity
                        {
                            ProspectusSemYrId = (int)p.ProspectusSemYrId,
                            ProspectusSubjectId = p.ProspectusSubjectId,
                            SubjectId = (int)p.SubjectId,
                            SubjectNo = p.Subject.SubjectNo,
                            DescriptiveTitle = p.Subject.SubjectDescriptiveTitle,
                            Lecture = p.Subject.SubjectLecUnit,
                            Laboratory = p.Subject.SubjectLabUnit,
                            Credit = p.Subject.SubjectCreUnit,
                            IsCounted = (bool)p.IsCounted
                        };
                return q.ToList();
            }
        }

        public static IList<ProspectusSubjectEntity> GetProspectusSubjectEntitiesProspectus(int iProspectusId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ProspectusSubjects
                        where (p.ProspectusSemYr.ProspectusId == iProspectusId)
                        orderby p.Subject.SubjectNo
                        select new ProspectusSubjectEntity
                        {
                            ProspectusSemYrId = (int)p.ProspectusSemYrId,
                            ProspectusSubjectId = p.ProspectusSubjectId,
                            SubjectId = (int)p.SubjectId,
                            SubjectNo = p.Subject.SubjectNo,
                            DescriptiveTitle = p.Subject.SubjectDescriptiveTitle,
                            Lecture = p.Subject.SubjectLecUnit,
                            Laboratory = p.Subject.SubjectLabUnit,
                            Credit = p.Subject.SubjectCreUnit,
                            IsCounted = (bool)p.IsCounted
                        };
                return q.ToList();
            }
        }

        public static IList<ProspectusSubjectEntity> GetProspectusSubjectEntitiesProspectusCourse(int iCourseId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ProspectusSubjects
                        where (p.ProspectusSemYr.Prospectus.CourseId == iCourseId)
                        orderby p.Subject.SubjectNo
                        select new ProspectusSubjectEntity
                        {
                            ProspectusSemYrId = (int)p.ProspectusSemYrId,
                            ProspectusSubjectId = p.ProspectusSubjectId,
                            SubjectId = (int)p.SubjectId,
                            SubjectNo = p.Subject.SubjectNo,
                            DescriptiveTitle = p.Subject.SubjectDescriptiveTitle,
                            Lecture = p.Subject.SubjectLecUnit,
                            Laboratory = p.Subject.SubjectLabUnit,
                            Credit = p.Subject.SubjectCreUnit,
                            IsCounted = (bool)p.IsCounted
                        };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 4.13.13
        #region SemSy
        public static List<SemSyEntity> GetSemSyEntities()
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.SemSys
                        orderby s.SemSyId ascending
                        select new SemSyEntity
                                   {
                                       SemSyId = s.SemSyId,
                                       Semester = s.Semester,
                                       Sy = s.Sy,
                                       SemesterName = s.SemesterName,
                                       Active = s.Active
                                   };
                return q.ToList();
            }
        }

        public static SemSyEntity GetSemSyEntity(int iId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.SemSys
                        where (s.SemSyId == iId)
                        orderby s.SemSyId ascending
                        select new SemSyEntity
                        {
                            SemSyId = s.SemSyId,
                            Semester = s.Semester,
                            Sy = s.Sy,
                            SemesterName = s.SemesterName,
                            Active = s.Active
                        };
                return q.SingleOrDefault();
            }
        }
        #endregion

        //edited by josh 4.13.13
        #region CourseSecScheduleEntity
        public static List<CourseSecScheduleEntity> GetCourseSecScheduleEntities()
        {
            using (var _e = new ESEntities())
            {
                var q = from c in _e.CourseSecSchedules
                        select new CourseSecScheduleEntity
                                   {
                                       CourseSecScheduleEntityId = c.CourseSecScheduleId,
                                       SemSyId = c.SemSyId,
                                       CourseId = c.CourseId,
                                       YearLevelId = c.YearLevelId,
                                       SectionId = c.SectionId,
                                       Note = c.Note,
                                       IsActive = c.IsActive,
                                       SemSyName = c.SemSy.Semester + ", " + c.SemSy.Sy,
                                       CourseName = c.Cours.Abbreviation,
                                       YearLevelName = c.YearLevel.YearLevelName,
                                       SectionName = c.Section.SectionName
                                   };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 4.25.13
        #region ProspectusSubjectPreReqEntity
        public static List<ProspectusSubjectPreReqEntity> GetProspectusSubjectPreReqEntities(int iProSubjectId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.PreRequisites
                        where (p.ProspectusSubjectId == iProSubjectId)
                        select new ProspectusSubjectPreReqEntity
                        {
                            ProspectusSubjectPreReqId = p.PreRequisiteId,
                            ProspectusSubjectId = p.ProspectusSubjectId,
                            SubjectId = p.SubjectId,
                            SubjectNo = p.Subject.SubjectNo,
                            DescriptiveTitle = p.Subject.SubjectDescriptiveTitle,
                            Lecture = p.Subject.SubjectLecUnit,
                            Laboratory = p.Subject.SubjectLabUnit,
                            Credit = p.Subject.SubjectCreUnit,
                            Note = p.Note,
                            IsAndOr = p.IsAndOr
                        };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.13.13
        #region Scheduling
        public static List<SchedulingEntity> GetScheduleAll(int iSemSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Schedules
                        where (s.CourseSecSchedule.SemSyId == iSemSyId)
                        orderby s.ScheduleId ascending
                        select new SchedulingEntity
                        {
                           ScheduleId = (int)s.ScheduleId,
                           ProspectusSubjectId = (int)s.ProspectusSubjectId,
                           CourseSecScheduleId = s.CourseSecScheduleId,
                           ScheduleCode = s.ScheduleCode,
                           SubjectNo = s.ProspectusSubject.Subject.SubjectNo,
                           SubjectDescriptiveTitle = s.ProspectusSubject.Subject.SubjectDescriptiveTitle,
                           SubjectLecUnit = s.ProspectusSubject.Subject.SubjectLecUnit,
                           SubjectLabUnit = s.ProspectusSubject.Subject.SubjectLabUnit,
                           SubjectCreUnit = s.ProspectusSubject.Subject.SubjectCreUnit,
                           Deleted = s.IsDeleted,
                           Requested = s.IsRequested,
                           Active = s.IsActive,
                           Limit = s.StudentLimit,
                           Added = s.StudentAdded
                        };
                return q.ToList();
            }
        }

        public static IList<SchedulingEntity> GetScheduleSet(int iCourSecSetId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Schedules
                        where (s.CourseSecSchedule.CourseSecScheduleId == iCourSecSetId)
                        orderby s.ScheduleId ascending
                        select new SchedulingEntity
                        {
                            ScheduleId = (int)s.ScheduleId,
                            ProspectusSubjectId = (int)s.ProspectusSubjectId,
                            CourseSecScheduleId = s.CourseSecScheduleId,
                            ScheduleCode = s.ScheduleCode,
                            SubjectNo = s.ProspectusSubject.Subject.SubjectNo,
                            SubjectDescriptiveTitle = s.ProspectusSubject.Subject.SubjectDescriptiveTitle,
                            SubjectLecUnit = s.ProspectusSubject.Subject.SubjectLecUnit,
                            SubjectLabUnit = s.ProspectusSubject.Subject.SubjectLabUnit,
                            SubjectCreUnit = s.ProspectusSubject.Subject.SubjectCreUnit,
                            Deleted = s.IsDeleted,
                            Requested = s.IsRequested,
                            Active = s.IsActive,
                            Limit = s.StudentLimit,
                            Added = s.StudentAdded
                        };
                return q.ToList();
            }
        }

        public static IList<SchedulingEntity> GetScheduleCourseYrSec(int iCourseId, string sYr, string sSec)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Schedules
                        join q1 in _e.ScheduleDetails on s.ScheduleId equals q1.ScheduleId into q01 from q01a in q01.DefaultIfEmpty()
                        join q2 in _e.ProspectusSubjects on s.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in _e.Subjects on q2.SubjectId equals q3.SubjectId
                        where ((s.CourseSecSchedule.CourseId == iCourseId) && (s.CourseSecSchedule.YearLevel.YearLevelName == sYr) && (s.CourseSecSchedule.Section.SectionName == sSec))
                        orderby s.ScheduleId ascending
                        select new SchedulingEntity
                        {
                            ScheduleId = (int)s.ScheduleId,
                            ProspectusSubjectId = (int)s.ProspectusSubjectId,
                            CourseSecScheduleId = s.CourseSecScheduleId,
                            ScheduleCode = s.ScheduleCode,
                            SubjectNo = q3.SubjectNo,
                            SubjectDescriptiveTitle = q3.SubjectDescriptiveTitle,
                            SubjectLecUnit = q3.SubjectLecUnit,
                            SubjectLabUnit = q3.SubjectLabUnit,
                            SubjectCreUnit = q3.SubjectCreUnit,
                            CourseName = s.CourseSecSchedule.Cours.Abbreviation,
                            YearLevel = s.CourseSecSchedule.YearLevel.YearLevelName,
                            Section = s.CourseSecSchedule.Section.SectionName,
                            TimeIn = q01a.TimeIn,
                            TimeOut = q01a.TimeOut,
                            Days = q01a.Days,
                            Room = q01a.Room.RoomNo,
                            LecLab = q01a.LecLab,
                            Deleted = s.IsDeleted,
                            Requested = s.IsRequested,
                            Active = s.IsActive,
                            Limit = s.StudentLimit,
                            Added = s.StudentAdded
                        };

                var list = new List<SchedulingEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    if (item == null)
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        scheduleEntity.ScheduleDetail = schedule;
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        }

        public static List<SchedulingEntity> GetScheduleSemSyDepartmentId(int iSemSyId, int iDepartmentId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Schedules
                        join q1 in _e.ScheduleDetails on s.ScheduleId equals q1.ScheduleId into q01
                        from q01a in q01.DefaultIfEmpty()
                        join q2 in _e.ProspectusSubjects on s.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in _e.Subjects on q2.SubjectId equals q3.SubjectId
                        where ((s.CourseSecSchedule.SemSyId == iSemSyId) && (s.CourseSecSchedule.Cours.DepartmentId == iDepartmentId))
                        orderby s.ScheduleId ascending
                        select new SchedulingEntity
                        {
                            ScheduleId = (int)s.ScheduleId,
                            ProspectusSubjectId = (int)s.ProspectusSubjectId,
                            CourseSecScheduleId = s.CourseSecScheduleId,
                            ScheduleCode = s.ScheduleCode,
                            SubjectNo = q3.SubjectNo,
                            SubjectDescriptiveTitle = q3.SubjectDescriptiveTitle,
                            SubjectLecUnit = q3.SubjectLecUnit,
                            SubjectLabUnit = q3.SubjectLabUnit,
                            SubjectCreUnit = q3.SubjectCreUnit,
                            CourseName = s.CourseSecSchedule.Cours.Abbreviation,
                            YearLevel = s.CourseSecSchedule.YearLevel.YearLevelName,
                            Section = s.CourseSecSchedule.Section.SectionName,
                            TimeIn = q01a.TimeIn,
                            TimeOut = q01a.TimeOut,
                            Days = q01a.Days,
                            Room = q01a.Room.RoomNo,
                            LecLab = q01a.LecLab,
                            //FacultyIdNo = q5.TeacherNo,
                            //FacultyFirstName = q5.FirstName,
                            //FacultyLastName = q5.LastName,
                            //FacultyMiddleName = q5.MiddleName,
                            Deleted = s.IsDeleted,
                            Requested = s.IsRequested,
                            Active = s.IsActive,
                            Limit = s.StudentLimit,
                            Added = s.StudentAdded
                        };

                var list = new List<SchedulingEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    if (item == null)
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        scheduleEntity.ScheduleDetail = schedule;
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        }

        public static List<SchedulingEntity> GetScheduleSemSyTeacher(int iSemSyId, int iTeacherId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Schedules
                        join q1 in _e.ScheduleDetails on s.ScheduleId equals q1.ScheduleId into q01
                        from q01a in q01.DefaultIfEmpty()
                        join q2 in _e.ProspectusSubjects on s.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in _e.Subjects on q2.SubjectId equals q3.SubjectId
                        join q4 in _e.TeacherSubjects on s.ScheduleId equals q4.ScheduleId into q04
                        from q04a in q04.DefaultIfEmpty()
                        join q5 in _e.Teachers on q04a.TeacherId equals q5.TeacherId
                        where ((s.CourseSecSchedule.SemSyId == iSemSyId) && (q5.TeacherId == iTeacherId))
                        orderby s.ScheduleId ascending
                        select new SchedulingEntity
                        {
                            ScheduleId = (int)s.ScheduleId,
                            ProspectusSubjectId = (int)s.ProspectusSubjectId,
                            CourseSecScheduleId = s.CourseSecScheduleId,
                            ScheduleCode = s.ScheduleCode,
                            SubjectNo = q3.SubjectNo,
                            SubjectDescriptiveTitle = q3.SubjectDescriptiveTitle,
                            SubjectLecUnit = q3.SubjectLecUnit,
                            SubjectLabUnit = q3.SubjectLabUnit,
                            SubjectCreUnit = q3.SubjectCreUnit,
                            CourseName = s.CourseSecSchedule.Cours.Abbreviation,
                            YearLevel = s.CourseSecSchedule.YearLevel.YearLevelName,
                            Section = s.CourseSecSchedule.Section.SectionName,
                            TimeIn = q01a.TimeIn,
                            TimeOut = q01a.TimeOut,
                            Days = q01a.Days,
                            Room = q01a.Room.RoomNo,
                            LecLab = q01a.LecLab,
                            FacultyIdNo = q5.TeacherNo,
                            FacultyFirstName = q5.FirstName,
                            FacultyLastName = q5.LastName,
                            FacultyMiddleName = q5.MiddleName,
                            Deleted = s.IsDeleted,
                            Requested = s.IsRequested,
                            Active = s.IsActive,
                            Limit = s.StudentLimit,
                            Added = s.StudentAdded
                        };

                var list = new List<SchedulingEntity>();
                foreach (var scheduleEntity in q)
                {
                    var item = list.Find(f => f.ScheduleId == scheduleEntity.ScheduleId);
                    if (item == null)
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        scheduleEntity.ScheduleDetail = schedule;
                        list.Add(scheduleEntity);
                    }
                    else
                    {
                        var schedule = String.Format(@"{0}, {1} - {2}, {3}, {4} ", scheduleEntity.Days,
                                                     scheduleEntity.TimeIn,
                                                     scheduleEntity.TimeOut, scheduleEntity.LecLab,
                                                     scheduleEntity.Room);
                        item.ScheduleDetail += schedule + " : ";
                    }
                }
                return list;
            }
        } 

        public static IList<ScheduleDetail> GetSchecduleDetails(int iScheduleId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.ScheduleDetails
                        where (s.ScheduleId == iScheduleId)
                        orderby s.ScheduleDetailId ascending
                        select s;
                return q.ToList();
            }
        }
        #endregion  

        //edited by josh 5.14.13
        #region Room
        public static IList<Room> GetRooms()
        {
            using (var _d = new DataRepository<Room>())
            {
                return _d.GetAll().OrderBy(r => r.RoomNo).ToList();
            }
        }
        #endregion

        //edited by josh 5.14.13
        #region ScheduleFeeName
        public static IList<ScheduleFeeName> GetScheduleFeeNames()
        {
            using (var _d = new DataRepository<ScheduleFeeName>())
            {
                return _d.GetAll().OrderBy(r => r.ScheduleName).ToList();
            }
        }
        #endregion

        //edited by josh 5.14.13
        #region ScheduleFees
        public static IList<ScheduleFee> GetScheduleFees(int iScheduleFeeNameId)
        {
            using (var _d = new DataRepository<ScheduleFee>())
            {
                return _d.GetAll().Where(r => r.ScheduleFeeNameId == iScheduleFeeNameId).ToList();
            }
        }

        public static List<PrintScheduleFeeClass> GetPrintScheduleFees(int iFeeNameId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ScheduleFees
                        where (p.ScheduleFeeNameId == iFeeNameId)
                        select new PrintScheduleFeeClass
                                   {
                                       ScheduleFeeNameId = p.ScheduleFeeNameId,
                                       ScheduleFeeNames = p.ScheduleFeeName.ScheduleName,
                                       Description = p.ScheduleFeeName.Description,
                                       ScheduleFeeId = p.ScheduleFeeId,
                                       Particular = p.FeeParticular.Particulars,
                                       Amount = p.Amount,
                                       IsActive = p.IsActive
                                   };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.14.13
        #region Scholarships
        public static IList<Scholarship> GetScholarships()
        {
            using (var _d = new DataRepository<Scholarship>())
            {
                return _d.GetAll().OrderBy(s => s.ScholarshipName).ToList();
            }
        }
        #endregion

        //edited by josh 5.14.13
        #region ScholarshipFees
        public static IList<ScholarshipFee> GetScholarshipFees()
        {
            using (var _d = new DataRepository<ScholarshipFee>())
            {
                return _d.GetAll().ToList();
            }
        }

        public static IList<ScholarshipFeeEntity> GetScholarshipFeeEntityScheduleFee(int iScheduleFee)
        {
            using (var _e = new ESEntities())
            {
                var q = (from s in _e.ScheduleFees
                        join s1 in _e.ScholarshipFees on s.ScheduleFeeId equals s1.ScheduleFeeId
                        into s3 from s1 in s3.DefaultIfEmpty()
                        where (s.ScheduleFeeNameId == iScheduleFee)
                        select new ScholarshipFeeEntity
                                   {
                                       ScholarshipFeeId = 0,
                                       ScheduleFeeId = s.ScheduleFeeId,
                                       Percentage = s1.Percentage,
                                       Particulars = s.FeeParticular.Particulars
                                   }).Distinct();
                return q.ToList();
            }
        }

        public static IList<ScholarshipFeeEntity> GetScholarshipFeeEntityScholarship(int iScholarshipId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.ScholarshipFees
                        where (s.ScholarshipId == iScholarshipId)
                        select new ScholarshipFeeEntity
                        {
                            ScholarshipFeeId = s.ScholarshipFeeId,
                            ScholarshipId = s.ScholarshipId,
                            ScheduleFeeId = s.ScheduleFeeId,
                            Percentage = s.Percentage,
                            Particulars = s.ScheduleFee.FeeParticular.Particulars
                        };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.14.13
        #region SetPresetFees
        public static IList<SetPresetFeeEntity> GetSetPresetFees()
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.SetPresetFees
                        select new SetPresetFeeEntity
                                   {
                                       SemYrId = s.SemSyId,
                                       SemYrName = s.SemSy.Semester + ", " + s.SemSy.Sy,
                                       CourseId = s.CourseId,
                                       CourseName = s.Cours.Abbreviation,
                                       YearLevelId = s.YearLevelId,
                                       YearLevelName = s.YearLevel.YearLevelName,
                                       SetPresetFeeId = s.SetPresetFeeId,
                                       Note = s.Note
                                   };
                return q.ToList();
            }
        }

        public static SetPresetFee GetSetPresetFee(int iSetPresetId)
        {
            using (var _d = new DataRepository<SetPresetFee>())
            {
                return _d.Single(s => s.SetPresetFeeId == iSetPresetId);
            }
        }
        #endregion

        //edited by josh 5.17.13
        #region PresetFees
        public static IList<PresetFeeEntity> GetPresetFees(int iSetPresetFeeId)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.PresetFees
                        where (s.SetPresetFeeId == iSetPresetFeeId)
                        select new PresetFeeEntity
                                   {
                                       PresetFeeId = s.PresetFeeId,
                                       ScheduleFeeId = s.ScheduleFeeId,
                                       SetPresetId = s.SetPresetFeeId,
                                       DateAdded = s.DateAdded,
                                       Amount = s.ScheduleFee.Amount,
                                       Particular = s.ScheduleFee.FeeParticular.Particulars,
                                       Active = s.ScheduleFee.IsActive
                                   };
                return q.ToList();
            }
        }

        #endregion

        //edited by josh 5.17.13
        #region LaboratoryFees
        public static IList<LaboratoryFeesEntity> GetLaboratoryFeesEntity(int iSemSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = from l in _e.LaboratoryFees
                        where (l.SemSyId == iSemSyId)
                        select new LaboratoryFeesEntity
                        {
                            LaboratoryFeeId = l.LaboratoryFeeId,
                            SemYrId = l.SemSyId,
                            FeeParticularId = l.FeeParticularId,
                            Amount = l.Amount,
                            Particular = l.FeeParticular.Particulars
                        };
                return q.ToList();
            }
        }

        public static IList<LaboratoryFeesEntity> GetLaboratoryFeesEntity()
        {
            using (var _e = new ESEntities())
            {
                var q = from l in _e.LaboratoryFees
                        orderby l.FeeParticular.Particulars ascending 
                        select new LaboratoryFeesEntity
                        {
                            LaboratoryFeeId = l.LaboratoryFeeId,
                            SemYrId = l.SemSyId,
                            FeeParticularId = l.FeeParticularId,
                            Amount = l.Amount,
                            Particular = l.FeeParticular.Particulars
                        };
                return q.ToList();
            }
        }

        public static IList<LaboratoryFee> GetLaboratoryFees(int iSemSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = from l in _e.LaboratoryFees
                        where (l.SemSyId == iSemSyId)
                        select l;
                return q.ToList();
            }
        }

        public static IList<LaboratoryFee> GetLaboratoryFees()
        {
            using (var _e = new ESEntities())
            {
                var q = from l in _e.LaboratoryFees
                        orderby l.FeeParticular.Particulars ascending
                        select l;
                return q.ToList();
            }
        }

        #endregion

        //edited by josh 5.17.13
        #region LaboratorySubjects
        public static IList<LaboratorySubjectEntity> GetLaboratorySubjects(int iLabFeeId)
        {
            using (var _e = new ESEntities())
            {
                var q = from l in _e.LabSubjects
                        where (l.LaboratoryFeeId == iLabFeeId)
                        select new LaboratorySubjectEntity
                        {
                            LabSubjectId = l.LabSubjectId,
                            LaboratoryFeeId = l.LaboratoryFeeId,
                            Active = l.IsActive,
                            SubjectId = l.Subject.SubjectId,
                            SubjectNo = l.Subject.SubjectNo,
                            SubjectDescriptiveTitle = l.Subject.SubjectDescriptiveTitle,
                            SubjectLecUnit = l.Subject.SubjectLecUnit,
                            SubjectLabUnit = l.Subject.SubjectLabUnit,
                            SubjectCreUnit = l.Subject.SubjectCreUnit
                        };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.17.13
        #region ViewProspectus
        private static String GetPrerequisite(int? iProspectusSubjectId)
        {
            var s = new StringBuilder();
            using (var _e = new ESEntities())
            {
                var q = from p in _e.PreRequisites
                        where (p.ProspectusSubjectId == iProspectusSubjectId)
                        select new
                                   {
                                       p.Subject.SubjectNo,
                                       PreId = p.PreRequisiteId,
                                       p.IsAndOr
                                   };

                var i = 0;
                foreach (var item in q)
                {
                    if (i == 0)
                        s.Append(item.SubjectNo);
                    else
                    {
                        s.Append(item.IsAndOr == false ? " / " : " & ");
                        s.Append(item.SubjectNo);
                    }
                    i++;
                }
                return s.ToString();
            }
        }

        public static IList<PrintProspectusClass> GetPrintProspectus(int iProspectusId)
        {
            var lItems = new List<PrintProspectusClass>();
            using (var _e = new ESEntities())
            {
                var q = from v in _e.ViewProspectus
                        where (v.ProspectusId == iProspectusId)
                        orderby v.Semester ascending orderby v.Sy ascending 
                        select new PrintProspectusClass
                                   {
                                       CourseId = v.CourseId,
                                       CourseName = v.CourseName,
                                       CourseAbbreviation = v.Abbreviation,
                                       Duration = v.Duration,
                                       ProspectusId = v.ProspectusId,
                                       ProspectusName = v.ProspectusName,
                                       Curriculum = v.Curriculum,
                                       Description = v.ProspectusDescription,
                                       ProspectusNote = v.Note,
                                       SemYrId = v.ProspectusSemYrId,
                                       Semester = v.Semester,
                                       SemesterName = v.SemesterName,
                                       YearLevel = v.Sy,
                                       SemYrNote = v.Expr1,
                                       IsCounted = v.IsCounted,
                                       SubjectId = v.SubjectId,
                                       SubjectNo = v.SubjectNo,
                                       DescriptiveTitle = v.SubjectDescriptiveTitle,
                                       Lecture = v.SubjectLecUnit,
                                       Laboratory = v.SubjectLabUnit,
                                       Credit = v.SubjectCreUnit,
                                       IsCreditable = v.IsCreditable,
                                       IsActive = v.IsActive,
                                       ProspectusSubjectId = v.ProspectusSubjectId
                                   };
                foreach (var item in q.ToList())
                {
                    var p = item;
                    p.PreRequsites = GetPrerequisite(p.ProspectusSubjectId);
                    lItems.Add(p);
                }
                return lItems;
            }
        }
        #endregion

        //edited by josh 5.19.13
        #region ViewSchedules
        private static String GetScheduleDetail(int? iScheduleId)
        {
            var s = new StringBuilder();
            using (var _e = new ESEntities())
            {
                var q = from p in _e.ScheduleDetails
                        where (p.ScheduleId == iScheduleId)
                        select new
                        {
                            p.TimeIn,
                            p.TimeOut,
                            p.Days,
                            p.LecLab,
                            p.Room.RoomNo
                        };

                var i = 0;
                foreach (var item in q.ToList())
                {
                    if (i == 0)
                        s.Append(item.TimeIn + " - " + item.TimeOut + "  [" + item.Days + ", " + item.LecLab + ", " + item.RoomNo + "]");
                    else
                    {
                        s.AppendLine();
                        s.Append(item.TimeIn + " - " + item.TimeOut + "  [" + item.Days + ", " + item.LecLab + ", " + item.RoomNo + "]");
                    }
                    i++;
                }

                return s.ToString();
            }
        }

        public static List<PrintScheduleClass> GetPrintSchedulesAll(int iSemYr)
        {
            var lItems = new List<PrintScheduleClass>();
            using (var _e = new ESEntities())
            {
                var q = from s in _e.ViewSchedules
                        where (s.SemSyId == iSemYr)
                        select new PrintScheduleClass
                                   {
                                       SemSyId = s.SemSyId,
                                       Semester = s.Semester,
                                       Sy = s.Sy,
                                       CourseId = s.CourseId,
                                       Course = s.Abbreviation,
                                       YearLevel = s.YearLevelName,
                                       SectionName = s.SectionName,
                                       ScheduleId = s.ScheduleId,
                                       StudentLimit = s.StudentLimit,
                                       Added = s.StudentAdded,
                                       Active = s.Active,
                                       Requested = s.IsRequested,
                                       Deleted = s.IsDeleted,
                                       SubjectNo = s.SubjectNo,
                                       DescriptiveTitle = s.SubjectDescriptiveTitle,
                                       Lecture = s.SubjectLecUnit,
                                       Laboratory = s.SubjectLabUnit,
                                       Credit = s.SubjectCreUnit
                                   };
                foreach (var item in q.ToList())
                {
                    var p = item;
                    p.TimeSchedule = GetScheduleDetail(item.ScheduleId);
                    lItems.Add(p);
                }
                return lItems;
            }
        }
        #endregion

        //edited by josh 5.21.13
        #region ViewCollegeEnrolleeSummary
        public static List<PrintEnrolleeDepartmentClass> GetPrintEnrolleeDepartments(int iCollegeId, int iSemYrId)
        {
            using (var _e = new ESEntities())
            {
                var q = from e in _e.ViewCollegeEnrolleeSummaries
                        where ((e.CollegeId == iCollegeId) && (e.SemSyId == iSemYrId))
                        group e by new
                        {
                            Dept = e.DepartmentName,
                            Coll = e.CollegeName
                        }
                            into ep
                            select new PrintEnrolleeDepartmentClass
                                {
                                    DepartmentName = ep.Key.Dept,
                                    CollegeName = ep.Key.Coll,
                                    Assessed = ep.Count(),
                                    Paid = ep.Count(p => p.IsPaid == true),
                                    Cancelled = ep.Count(c => c.IsCancelled == true)
                                };
                return q.ToList();
            }
        }

        public static List<PrintEnrolleeDepartmentClass> GetPrintEnrolleeCourses(int iDepartmentId,  int iSemYrId)
        {
            using (var _e = new ESEntities())
            {
                var q = from e in _e.ViewCollegeEnrolleeSummaries
                        where ((e.DepartmentId == iDepartmentId) && (e.SemSyId == iSemYrId))
                        group e by new
                            {
                                Abbreviation = e.Abbreviation + " - " + e.CourseName,
                                Dept = e.DepartmentName,
                                Coll = e.CollegeName
                            }
                            into ep
                            select new PrintEnrolleeDepartmentClass
                            {
                                CourseName = ep.Key.Abbreviation,
                                DepartmentName = ep.Key.Dept,
                                CollegeName = ep.Key.Coll,
                                Assessed = ep.Count(),
                                Paid = ep.Count(p => p.IsPaid == true),
                                Cancelled = ep.Count(c => c.IsCancelled == true)
                            };
                return q.ToList();
            }
        }

        public static List<PrintEnrolleeDepartmentClass> GetPrintEnrolleeCoursesYrSec(int iCourseId, int iSemYrId)
        {
            using (var _e = new ESEntities())
            {
                var q = from e in _e.ViewCollegeEnrolleeSummaries
                        where ((e.CourseId == iCourseId) && (e.SemSyId == iSemYrId))
                        group e by new
                            {
                                Abbr = e.Abbreviation + "/" + e.YearLevelName + "/" + e.SectionName,
                                Dept = e.DepartmentName,
                                Coll = e.CollegeName
                            }
                            into ep
                            select new PrintEnrolleeDepartmentClass
                            {
                                CourseName = ep.Key.Abbr,
                                CollegeName = ep.Key.Coll,
                                DepartmentName = ep.Key.Dept,
                                Assessed = ep.Count(),
                                Paid = ep.Count(p => p.IsPaid == true),
                                Cancelled = ep.Count(c => c.IsCancelled == true)
                            };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.27.13
        #region ViewStudentCrsYrSec
        public static List<PrintStudentClass> GetPrintStudentClass(int iSemSyId, int? iYearLevelId, int? iSectionId, int? iCrs)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.Registrations
                        where ((s.SemSyId == iSemSyId) && (s.YearLevelId == iYearLevelId) && (s.SectionId == iSectionId) && (s.CourseId == iCrs))
                        orderby s.Student.LastName, s.Student.FirstName ascending
                        select new PrintStudentClass
                            {
                                StudentId = s.Student.StudentId,
                                StudentNo = s.Student.IdNo,
                                LastName = s.Student.LastName,
                                FirstName = s.Student.FirstName,
                                CourseId = s.Cours.CourseId,
                                CourseName = s.Cours.Abbreviation,
                                YearLevelId = s.YearLevelId,
                                YearLevelName = s.YearLevel.YearLevelName,
                                SectionId = s.SectionId,
                                SectionName = s.Section.SectionName,
                                ScholarshipId = s.ScholarshipId,
                                ScholarshipName = s.Scholarship.ScholarshipName
                            };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.27.13
        #region others
        public static List<CourseYearSectionEntity> GetCourseYearSection(int iSemSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = (from y in _e.Registrations
                        where (y.SemSyId == iSemSyId)
                        orderby y.Cours.Abbreviation, y.Section.SectionName ascending 
                        select new CourseYearSectionEntity
                            {
                                CourseId = y.CourseId,
                                CourseName = y.Cours.Abbreviation,
                                YearLevelId = y.YearLevelId,
                                YearLevelName = y.YearLevel.YearLevelName,
                                SectionId = y.SectionId,
                                SectionName = y.Section.SectionName
                            }).Distinct();
                return q.ToList() ;
            }
        }
        #endregion

        //edited by josh 5.28.13
        #region FeeSummary
        public static List<PrintFeeClass> GetPrintFeeClassAll(int iSemSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.FeeTitles
                        join p1 in _e.FeeSubTitles on p.FeeTitleId equals p1.FeeTitleId
                        join p2 in _e.FeeParticulars on p1.FeeSubTitleId equals p2.FeeSubTitleId
                        join p3 in _e.Assessments on p2.FeeParticularId equals p3.FeeParticularId
                        join p4 in _e.Registrations on p3.RegistrationId equals p4.RegistrationId
                        join p5 in _e.ReceiptDetails on p3.AssessmentId equals p5.AssessmentId
                        join p6 in _e.Receipts on p5.ReceiptId equals p6.ReceiptId into p56
                        from p56A in p56.DefaultIfEmpty()
                        where (p4.SemSyId == iSemSyId)
                        select new PrintFeeClass
                            {
                                FeeTitleId = p.FeeTitleId,
                                FeeTitleName = p.FeeTitleName,
                                FeeSubTitleId = p1.FeeSubTitleId,
                                FeeSubTitleName = p1.FeeSubTitleName,
                                FeeParticularId = p2.FeeParticularId,
                                FeeParticularName = p2.Particulars,
                                Amount = p3.Amount,
                                AddAmount = p3.AddAmount,
                                Less = p3.Less,
                                AddLess = p3.AddLess,
                                NetAmount = p3.NetAmount,
                                IsOriginal = p3.IsOriginal
                                //PaidAmount = p3.Sum(a => a.ReceiptDetails.Sum(b => b.Amount))
                                //PaidAmount = p5.Amount
                            };
                return q.ToList();
            }
        }

        public static List<PrintFeeClass> GetPrintFeeClassFeeTitle(int iSemSyId, int iFeeTitleId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.FeeTitles
                        join p1 in _e.FeeSubTitles on p.FeeTitleId equals p1.FeeTitleId
                        join p2 in _e.FeeParticulars on p1.FeeSubTitleId equals p2.FeeSubTitleId
                        join p3 in _e.Assessments on p2.FeeParticularId equals p3.FeeParticularId
                        join p4 in _e.Registrations on p3.RegistrationId equals p4.RegistrationId
                        //join p5 in _e.ReceiptDetails on p3.AssessmentId equals p5.AssessmentId into p35
                        //from selection in p35.DefaultIfEmpty()
                        where ((p4.SemSyId == iSemSyId) && (p.FeeTitleId == iFeeTitleId))
                        group p3 by new
                        {
                            p.FeeTitleName,
                            p1.FeeSubTitleName,
                        }
                            into fees
                            select new PrintFeeClass
                            {
                                FeeTitleName = fees.Key.FeeTitleName,
                                FeeSubTitleName = fees.Key.FeeSubTitleName,
                                Amount = fees.Sum(a => a.GrossAmount),
                                AddAmount = fees.Sum(a => a.AddAmount),
                                Less = fees.Sum(a => a.Less),
                                AddLess = fees.Sum(a => a.AddLess),
                                NetAmount = fees.Sum(a => a.NetAmount),
                                PaidAmount = fees.Sum(a => a.ReceiptDetails.Sum(b => b.Receipt.IsValid == true ? b.Amount : 0)) 
                            };
                return q.ToList();
            }
        }

        public static List<PrintFeeClass> GetPrintFeeClassFeeSubTitle(int iSemSyId, int iFeeSubTitleId)
        {
            using (var _e = new ESEntities())
            {
                var q = from p in _e.FeeTitles
                        join p1 in _e.FeeSubTitles on p.FeeTitleId equals p1.FeeTitleId
                        join p2 in _e.FeeParticulars on p1.FeeSubTitleId equals p2.FeeSubTitleId
                        join p3 in _e.Assessments on p2.FeeParticularId equals p3.FeeParticularId
                        join p4 in _e.Registrations on p3.RegistrationId equals p4.RegistrationId
                        //join p5 in _e.ReceiptDetails on p3.AssessmentId equals p5.AssessmentId into p35
                        //from selection in p35.DefaultIfEmpty()
                        //join p6 in _e.Receipts on selection.ReceiptId equals p6.ReceiptId into selp6
                        //from selp6a in selp6.DefaultIfEmpty()
                        where ((p4.SemSyId == iSemSyId) && (p1.FeeSubTitleId == iFeeSubTitleId))
                        group p3 by new
                            {
                                p.FeeTitleName,
                                p1.FeeSubTitleName,
                                p2.Particulars,
                            }
                        into fees
                        select new PrintFeeClass
                            {
                                FeeTitleName = fees.Key.FeeTitleName,
                                FeeSubTitleName = fees.Key.FeeSubTitleName,
                                FeeParticularName = fees.Key.Particulars,
                                Amount = fees.Sum(a => a.GrossAmount),
                                AddAmount = fees.Sum(a => a.AddAmount),
                                Less = fees.Sum(a => a.Less),
                                AddLess = fees.Sum(a => a.AddLess),
                                NetAmount = fees.Sum(a => a.NetAmount),
                                PaidAmount = fees.Sum(a => a.ReceiptDetails.Sum(b => b.Receipt.IsValid == true ? b.Amount : 0)) 
                            };

                return q.ToList();
            }
        }
        #endregion

        //edited by josh 5.31.13
        #region ClassList
        public static List<PrintClassList> GetClassListSchedule(int iScheduleId)
        {
            var lClassList = new List<PrintClassList>();
            var strSched = new StringBuilder();
            using (var _e = new ESEntities())
            {
                var q = from p in _e.RegisteredSchedules
                        join p1 in _e.Registrations on p.RegistrationId equals p1.RegistrationId
                        join p2 in _e.Students on p1.StudentId equals p2.StudentId
                        join p3 in _e.Schedules on p.ScheduleId equals p3.ScheduleId
                        join p4 in _e.ScheduleDetails on p3.ScheduleId equals p4.ScheduleId
                        join p5 in _e.ProspectusSubjects on p3.ProspectusSubjectId equals p5.ProspectusSubjectId
                        join p6 in _e.Subjects on p5.SubjectId equals p6.SubjectId
                        join p7 in _e.YearLevels on p1.YearLevelId equals p7.YearLevelId
                        join p8 in _e.Sections on p1.SectionId equals p8.SectionId
                        join p9 in _e.Scholarships on p1.ScholarshipId equals p9.ScholarshipId
                        join p10 in _e.Courses on p1.CourseId equals p10.CourseId
                        join p11 in _e.Rooms on p4.RoomId equals p11.RoomId
                        where (p3.ScheduleId == iScheduleId)
                        select new PrintClassList
                            {
                                StudentId = p2.StudentId,
                                StudentNo = p2.IdNo,
                                LastName = p2.LastName,
                                FirstName = p2.FirstName,
                                MiddleName = p2.MiddleName,
                                CourseName = p10.CourseName,
                                YearLevelName = p7.YearLevelName,
                                SectionName = p8.SectionName,
                                IsRequest = p3.IsRequested,
                                SubjectNo = p6.SubjectNo,
                                DescriptiveTitle = p6.SubjectDescriptiveTitle,
                                Lecture = p6.SubjectLecUnit,
                                Laboratory = p6.SubjectLabUnit,
                                Credit = p6.SubjectCreUnit,
                                SchedIn = p4.TimeIn,
                                SchedOut = p4.TimeOut,
                                Days = p4.Days,
                                LecLab = p4.LecLab,
                                RoomNo = p11.RoomNo
                            };

                var i = 0;
                foreach (var item in q.ToList())
                {
                    var p = new PrintClassList();
                    p = item;
                    if (i == 0)
                    {
                        strSched.Append(String.Format(@"{0} - {1}, {2}, {3}, {4}, {5}", item.SchedIn, item.SchedOut,
                                                      item.Days, item.LecLab, item.RoomNo));
                    }
                    else
                    {
                        strSched.AppendLine();
                        strSched.Append(String.Format(@"{0} - {1}, {2}, {3}, {4}, {5}", item.SchedIn, item.SchedOut,
                                                      item.Days, item.LecLab, item.RoomNo));
                    }
                    p.ScheduleDetail = strSched.ToString();
                    lClassList.Add(p);
                }
                return lClassList;
            }
        }
        #endregion

        //edited by josh 7.21.13
        #region Branches
        public static List<Branch> GetBranches()
        {
            using (var _dBranch = new DataRepository<Branch>())
            {
                return _dBranch.GetAll().ToList();
            }
        }
        #endregion

        //edited by josh 8.8.2013
        #region AccountQuery
        public static List<YearLevelCourseSectionSemSyEntity> GetStudentBySemSy(string searchValue)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Students
                        join q1 in _e.Registrations on q0.StudentId equals q1.StudentId
                            into q01
                        from q1A in q01.DefaultIfEmpty()
                        where ((q0.IdNo == searchValue) || (q0.LastName.StartsWith(searchValue)))
                        select new YearLevelCourseSectionSemSyEntity
                            {
                                StudentId = q0.StudentId,
                                IdNo = q0.IdNo,
                                LastName = q0.LastName,
                                FirstName = q0.FirstName,
                                MiddleName = q0.MiddleName,
                                SemSyId = q1A.SemSyId,
                                SemSyName = q1A.SemSy.Semester + @", " + q1A.SemSy.Sy,
                                CourseId = q1A.CourseId,
                                CourseName = q1A.Cours.Abbreviation,
                                YearLevelId = q1A.YearLevelId,
                                YearLevelName = q1A.YearLevel.YearLevelName,
                                SectionId = q1A.SectionId,
                                SectionName = q1A.Section.SectionName,
                                ScholarshipName = q1A.Scholarship.ScholarshipName,
                                RegistrationId = q1A.RegistrationId,
                                RegistrationDate = q1A.RegistrationDate
                            };

                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static YearLevelCourseSectionSemSyEntity GetStudentBySemSy(int iRegistrationId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Students
                        join q1 in _e.Registrations on q0.StudentId equals q1.StudentId
                            into q01
                        from q1A in q01.DefaultIfEmpty()
                        where (q1A.RegistrationId == iRegistrationId)
                        select new YearLevelCourseSectionSemSyEntity
                        {
                            StudentId = q0.StudentId,
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            SemSyId = q1A.SemSyId,
                            SemSyName = q1A.SemSy.Semester + @", " + q1A.SemSy.Sy,
                            CourseId = q1A.CourseId,
                            CourseName = q1A.Cours.Abbreviation,
                            YearLevelId = q1A.YearLevelId,
                            YearLevelName = q1A.YearLevel.YearLevelName,
                            SectionId = q1A.SectionId,
                            SectionName = q1A.Section.SectionName,
                            ScholarshipName = q1A.Scholarship.ScholarshipName
                        };

                return q.SingleOrDefault();
            }
        }
        #endregion

        //edited by josh 8.16.2013
        #region Users
        public static UserEntity GetUserByUserNamePassword(string sUserName, string sPassword)
        {
            using (var _e = new ESEntities())
            {
                var u = new UserEntity();
                try
                {
                    var q = from q0 in _e.Users
                            where ((q0.UserName.Equals(sUserName)) && (q0.Password.Equals(sPassword)) && (q0.IsActive == true))
                            select new UserEntity
                            {
                                UserId = q0.UserId,
                                UserName = q0.UserName,
                                Password = q0.Password,
                                UserLevel = q0.UserLevel.UserLevelName,
                                IsActive = q0.IsActive,
                                UserFullName = q0.UserFullName
                            };
                    u = q.SingleOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                return u;
            }
        }
        #endregion

        //edited by josh 8.25.2013 
        #region MunCityEntity
        public static List<MunCityEntity> GetMunCityProvince(Province province)
        {
            using (var _e = new ESEntities())
            {
                var q = from m in _e.MunCities
                        where (m.ProvinceId == province.ProvinceId)
                        select new MunCityEntity
                            {
                                ProvinceName = m.Province.ProvinceName,
                                MunCityName = m.MunCityName
                            };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 8.25.2013 
        #region Barangay
        public static List<BarangayEntity> GetBarangayMunCity(MunCity munCity)
        {
            using (var _e = new ESEntities())
            {
                var q = from b in _e.Barangays
                        where (b.MunCityId == munCity.MunCityId)
                        select new BarangayEntity
                            {
                                BarangayName = b.BarangayName,
                                MunCityName = b.MunCity.MunCityName,
                                ProvinceName = b.MunCity.Province.ProvinceName
                            };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 8.25.2013 
        #region Street
        public static List<StreetEntity> GetStreetBarangay(Barangay barangay)
        {
            using (var _e = new ESEntities())
            {
                var q = from s in _e.StreetHouses
                        where (s.BarangayId == barangay.BarangayId)
                        select new StreetEntity
                        {
                            BarangayName = s.Barangay.BarangayName,
                            MunCityName = s.Barangay.MunCity.MunCityName,
                            ProvinceName = s.Barangay.MunCity.Province.ProvinceName,
                            StreetName = s.StreetName
                        };
                return q.ToList();
            }
        }
        #endregion

        //edited by josh 8.30.2013
        #region GradingPeriod
        public static GradingPeriod GetGradingPeriod(int iGradingPeriodId   )
        {
            using (var _d = new DataRepository<GradingPeriod>())
            {
                return _d.First(g => g.GradingLabelId == iGradingPeriodId);
            }
        }

        public static GradingPeriod GetGradingPeriod()
        {
            using (var _d = new DataRepository<GradingPeriod>())
            {
                return _d.FirstOrDefault(g => g.GradingLabelId == 1);
            }
        }
        #endregion

        //edited by josh 9.18.2013
        #region Teachers & TeacherEntity
        public static List<TeacherEntity> GetAllTeachers()
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Teachers
                        select new TeacherEntity
                            {
                                TeacherId = q0.TeacherId,
                                TeacherNo = q0.TeacherNo,
                                LastName = q0.LastName,
                                FirstName = q0.FirstName,
                                MiddleName = q0.MiddleName,
                                BirthDate = q0.BirthDate,
                                CivilStatus = q0.CivilStatus,
                                EmpStatus = q0.EmpStatus.EmpStatusName,
                                Position = q0.Position.PostitionName,
                                IsActive = q0.IsActive,
                                PositionId = q0.PositionId,
                                EmpStatusId = q0.EmpStatusId,
                                Picture = q0.Picture,
                                Sex = q0.Sex
                            };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<TeacherEntity> GetAllTeachers(string criteria)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Teachers
                        where ((q0.TeacherNo.StartsWith(criteria)) || q0.LastName.StartsWith(criteria))
                        select new TeacherEntity
                        {
                            TeacherId = q0.TeacherId,
                            TeacherNo = q0.TeacherNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            BirthDate = q0.BirthDate,
                            CivilStatus = q0.CivilStatus,
                            EmpStatus = q0.EmpStatus.EmpStatusName,
                            Position = q0.Position.PostitionName,
                            IsActive = q0.IsActive,
                            PositionId = q0.PositionId,
                            EmpStatusId = q0.EmpStatusId,
                            Picture = q0.Picture,
                            Sex = q0.Sex
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<TeacherEntity> GetAllTeachersWithDepartment()
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Teachers
                        join q1 in e.DepartmentTeachers on q0.TeacherId equals q1.TeacherId
                        select new TeacherEntity
                        {
                            TeacherId = q0.TeacherId,
                            TeacherNo = q0.TeacherNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            BirthDate = q0.BirthDate,
                            CivilStatus = q0.CivilStatus,
                            EmpStatus = q0.EmpStatus.EmpStatusName,
                            Position = q0.Position.PostitionName,
                            IsActive = q0.IsActive,
                            PositionId = q0.PositionId,
                            EmpStatusId = q0.EmpStatusId,
                            Picture = q0.Picture,
                            Sex = q0.Sex,
                            DepartmentId = q1.DepartmentId,
                            DepartmentName = q1.Department.DepartmentName
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }
        #endregion

        //edited by josh 10.3.2013
        #region DepartmentTeachers
        public static List<DepartmentTeacherEntity> GetAllDepartmentTeachers()
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Teachers
                        join q1 in e.DepartmentTeachers on q0.TeacherId equals q1.TeacherId
                        into q01
                        from q01a in q01.DefaultIfEmpty()
                        select new DepartmentTeacherEntity
                        {
                            DepartmentTeacherId = q01a.DepartmentTeacherId,
                            DepartmentId = q01a.DepartmentId,
                            Note = q01a.DepartmentTeacherNote,
                            Active = q01a.DepartmentTeacherIsActive,
                            PositionName = q0.Position.PostitionName,
                            EmpStatusName = q0.EmpStatus.EmpStatusName,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            TeacherNo = q0.TeacherNo,
                            TeacherId = q0.TeacherId
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<DepartmentTeacherEntity> GetAllDepartmentTeacherByDepartmentId(int iId, int iChoice)
        {
            using (var e = new ESEntities())
            {
                var list = new List<DepartmentTeacherEntity>();
                switch (iChoice)
                {
                    case 0:
                        var q = from q0 in e.DepartmentTeachers
                                join q1 in e.Teachers on q0.TeacherId equals q1.TeacherId
                                join q2 in e.Departments on q0.DepartmentId equals q2.DepartmentId
                                into q02
                                from q02a in q02.DefaultIfEmpty()
                                where (q02a.DepartmentId == iId)
                                select new DepartmentTeacherEntity
                                {
                                    DepartmentTeacherId = q0.DepartmentTeacherId,
                                    DepartmentId = q0.DepartmentId,
                                    Note = q0.DepartmentTeacherNote,
                                    Active = q0.DepartmentTeacherIsActive,
                                    PositionName = q1.Position.PostitionName,
                                    EmpStatusName = q1.EmpStatus.EmpStatusName,
                                    DepartmentName = q02a.DepartmentName,
                                    LastName = q1.LastName,
                                    FirstName = q1.FirstName,
                                    MiddleName = q1.MiddleName, 
                                    TeacherNo = q1.TeacherNo
                                };
                        list = q.OrderBy(o => o.LastName).ToList();
                        break;
                    case 1:
                        var qA = from q0 in e.DepartmentTeachers
                                join q1 in e.Teachers on q0.TeacherId equals q1.TeacherId
                                join q2 in e.Departments on q0.DepartmentId equals q2.DepartmentId
                                into q02
                                from q02a in q02.DefaultIfEmpty()
                                where (q02a.CollegeId == iId)
                                select new DepartmentTeacherEntity
                                {
                                    DepartmentTeacherId = q0.DepartmentTeacherId,
                                    DepartmentId = q0.DepartmentId,
                                    Note = q0.DepartmentTeacherNote,
                                    Active = q0.DepartmentTeacherIsActive,
                                    PositionName = q1.Position.PostitionName,
                                    EmpStatusName = q1.EmpStatus.EmpStatusName,
                                    DepartmentName = q02a.DepartmentName,
                                    LastName = q1.LastName,
                                    FirstName = q1.FirstName,
                                    MiddleName = q1.MiddleName,
                                    TeacherNo = q1.TeacherNo
                                };
                        list = qA.OrderBy(o => o.LastName).ToList();
                        break;
                    case 2: break;
                    default: break;
                }
                return list;
            }
        }
        #endregion

        //edited by josh 11.8.13
        #region Registration
        public static List<RegistrationEntity> GetStudentEntity(string criteria)
        {
            using (var e = new ESEntities())
            {
                var q = (from q0 in e.Students
                        join q1 in e.Registrations on q0.StudentId equals q1.StudentId
                            into q01
                        from q01a in q01.DefaultIfEmpty()
                         join q2 in e.Scholarships on q01a.ScholarshipId equals q2.ScholarshipId
                         join q3 in e.Scholarships on q01a.ScholarshipId1 equals q3.ScholarshipId
                         join q4 in e.Scholarships on q01a.ScholarshipId2 equals q4.ScholarshipId
                        where ((q0.IdNo == criteria) || (q0.LastName.StartsWith(criteria)))
                        select new RegistrationEntity
                            {
                                StudentId = q0.StudentId,
                                IdNo = q0.IdNo,
                                LastName = q0.LastName,
                                FirstName = q0.FirstName,
                                MiddleName = q0.MiddleName,
                                Course = q01a.Cours.Abbreviation,
                                YearLevel = q01a.YearLevel.YearLevelName,
                                Section = q01a.Section.SectionName,
                                CourseId = q01a.CourseId,
                                ProspectusId = q01a.ProspectusId,
                                YearLevelId = q01a.YearLevelId,
                                SectionId = q01a.SectionId,
                                StatusId = q01a.StudentStatusId,
                                TypeId = q01a.StudentTypeId,
                                ScholarshipId = q01a.ScholarshipId,
                                ScholarshipId1 = q01a.ScholarshipId1,
                                ScholarshipId2 = q01a.ScholarshipId2,
                                Cancelled = q01a.IsCancelled,
                                Paid = q01a.IsPaid,
                                Enrolled = q01a.IsEnrolled,
                                CourseName = q01a.Cours.CourseName,
                                CurriculumName = q01a.Prospectus.ProspectusName,
                                StatusName = q01a.StudentStatus.StatusName,
                                TypeName = q01a.StudentType.StudentTypeName,
                                ScholarshipName = q2.ScholarshipName,
                                ScholarshipName1 = q3.ScholarshipName,
                                ScholarshipName2 = q4.ScholarshipName,
                                RegistrationDate = q01a.RegistrationDate,
                                RegistrationId = q01a.RegistrationId
                            }).Distinct();
                return q.OrderBy(o => o.LastName).Distinct().ToList();
            }            
        }

        public static List<RegistrationEntity> GetStudentRegistrationCeritficate(string criteria, int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Students
                        join q1 in e.Registrations on q0.StudentId equals q1.StudentId
                        join q2 in e.Scholarships on q1.ScholarshipId equals q2.ScholarshipId
                        join q3 in e.Scholarships on q1.ScholarshipId1 equals q3.ScholarshipId into q13
                        from q13a in q13.DefaultIfEmpty()
                        join q4 in e.Scholarships on q1.ScholarshipId2 equals q4.ScholarshipId into q14
                        from q14a in q14.DefaultIfEmpty()
                        where (((q0.IdNo == criteria) || (q0.LastName.StartsWith(criteria))) && (q1.SemSyId == iSemSyId))
                        select new RegistrationEntity
                        {
                            StudentId = q0.StudentId,
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            Course = q1.Cours.Abbreviation,
                            YearLevel = q1.YearLevel.YearLevelName,
                            Section = q1.Section.SectionName,
                            CourseId = q1.CourseId,
                            ProspectusId = q1.ProspectusId,
                            YearLevelId = q1.YearLevelId,
                            SectionId = q1.SectionId,
                            StatusId = q1.StudentStatusId,
                            TypeId = q1.StudentTypeId,
                            ScholarshipId = q1.ScholarshipId,
                            ScholarshipId1 = q1.ScholarshipId1,
                            ScholarshipId2 = q1.ScholarshipId2,
                            Cancelled = q1.IsCancelled,
                            Paid = q1.IsPaid,
                            Enrolled = q1.IsEnrolled,
                            CourseName = q1.Cours.CourseName,
                            CurriculumName = q1.Prospectus.ProspectusName,
                            StatusName = q1.StudentStatus.StatusName,
                            TypeName = q1.StudentType.StudentTypeName,
                            ScholarshipName = q2.ScholarshipName,
                            ScholarshipName1 = q13a.ScholarshipName,
                            ScholarshipName2 = q14a.ScholarshipName,
                            RegistrationDate = q1.RegistrationDate,
                            RegistrationId = q1.RegistrationId
                        };
                return q.OrderBy(o => o.LastName).Distinct().ToList();
            }
        }

        public static List<RegistrationEntity> GetStudentEntity01(string criteria)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Students
                        where ((q0.IdNo == criteria) || (q0.LastName.StartsWith(criteria)))
                        select new RegistrationEntity
                        {
                            StudentId = q0.StudentId,
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<StudentEntity> GetStudentEntity02(string criteria)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Students
                        where ((q0.IdNo == criteria) || (q0.LastName.StartsWith(criteria)))
                        select new StudentEntity
                        {
                            StudentId = q0.StudentId,
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            Gender = q0.Gender
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static RegistrationEntity GetStudentRegistration(int iSemSyId, int iStudentId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Students
                        join q1 in e.Registrations on q0.StudentId equals q1.StudentId
                        join q2 in e.Scholarships on q1.ScholarshipId equals q2.ScholarshipId
                        join q3 in e.Scholarships on q1.ScholarshipId1 equals q3.ScholarshipId into q13
                        from q13a in q13.DefaultIfEmpty() 
                        join q4 in e.Scholarships on q1.ScholarshipId2 equals q4.ScholarshipId into q14 from q14a in q14.DefaultIfEmpty()
                        where ((q0.StudentId == iStudentId) && (q1.SemSyId == iSemSyId))
                        select new RegistrationEntity
                        {
                            StudentId = q0.StudentId,
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            Course = q1.Cours.Abbreviation,
                            YearLevel = q1.YearLevel.YearLevelName,
                            Section = q1.Section.SectionName,
                            CourseId = q1.CourseId,
                            ProspectusId = q1.ProspectusId,
                            YearLevelId = q1.YearLevelId,
                            SectionId = q1.SectionId,
                            StatusId = q1.StudentStatusId,
                            TypeId = q1.StudentTypeId,
                            ScholarshipId = q1.ScholarshipId,
                            ScholarshipId1 = q1.ScholarshipId1,
                            ScholarshipId2 = q1.ScholarshipId2,
                            Cancelled = q1.IsCancelled,
                            Paid = q1.IsPaid,
                            Enrolled = q1.IsEnrolled,
                            CourseName = q1.Cours.CourseName,
                            CurriculumName = q1.Prospectus.ProspectusName,
                            StatusName = q1.StudentStatus.StatusName,
                            TypeName = q1.StudentType.StudentTypeName,
                            ScholarshipName = q2.ScholarshipName,
                            ScholarshipName1 = q13a.ScholarshipName,
                            ScholarshipName2 = q14a.ScholarshipName,
                            RegistrationDate = q1.RegistrationDate,
                            RegistrationId = q1.RegistrationId,
                            SemSyId = q1.SemSyId,
                            BranchId = q1.BranchId
                        };
                return q.SingleOrDefault();
            }
        }

        public static RegistrationEntity GetStudentRegistrationById(int iStudentId)
        {
            using (var e = new ESEntities())
            {
                var q = (from q0 in e.Students
                         join q1 in e.Registrations on q0.StudentId equals q1.StudentId
                         join q2 in e.Scholarships on q1.ScholarshipId equals q2.ScholarshipId
                         join q3 in e.Scholarships on q1.ScholarshipId1 equals q3.ScholarshipId into q13
                         from q13a in q13.DefaultIfEmpty()
                         join q4 in e.Scholarships on q1.ScholarshipId2 equals q4.ScholarshipId into q14
                         from q14a in q14.DefaultIfEmpty()
                         where (q1.StudentId == iStudentId) 
                         orderby q1.RegistrationId descending 
                         select new RegistrationEntity
                             {
                                 StudentId = q0.StudentId,
                                 IdNo = q0.IdNo,
                                 LastName = q0.LastName,
                                 FirstName = q0.FirstName,
                                 MiddleName = q0.MiddleName,
                                 Course = q1.Cours.Abbreviation,
                                 YearLevel = q1.YearLevel.YearLevelName,
                                 Section = q1.Section.SectionName,
                                 CourseId = q1.CourseId,
                                 ProspectusId = q1.ProspectusId,
                                 YearLevelId = q1.YearLevelId,
                                 SectionId = q1.SectionId,
                                 StatusId = q1.StudentStatusId,
                                 TypeId = q1.StudentTypeId,
                                 ScholarshipId = q1.ScholarshipId,
                                 ScholarshipId1 = q1.ScholarshipId1,
                                 ScholarshipId2 = q1.ScholarshipId2,
                                 Cancelled = q1.IsCancelled,
                                 Paid = q1.IsPaid,
                                 Enrolled = q1.IsEnrolled,
                                 CourseName = q1.Cours.CourseName,
                                 CurriculumName = q1.Prospectus.ProspectusName,
                                 StatusName = q1.StudentStatus.StatusName,
                                 TypeName = q1.StudentType.StudentTypeName,
                                 ScholarshipName = q2.ScholarshipName,
                                 ScholarshipName1 = q13a.ScholarshipName,
                                 ScholarshipName2 = q14a.ScholarshipName,
                                 RegistrationDate = q1.RegistrationDate,
                                 RegistrationId = q1.RegistrationId
                             }).Take(1);
                return q.SingleOrDefault();
            }
        }

        public static RegistrationEntity GetStudentRegistrationById(int iStudentId, int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = (from q0 in e.Students
                         join q1 in e.Registrations on q0.StudentId equals q1.StudentId
                         join q2 in e.Scholarships on q1.ScholarshipId equals q2.ScholarshipId
                         join q3 in e.Scholarships on q1.ScholarshipId1 equals q3.ScholarshipId into q13
                         from q13a in q13.DefaultIfEmpty() 
                         join q4 in e.Scholarships on q1.ScholarshipId2 equals q4.ScholarshipId into q14 from q14a in q14.DefaultIfEmpty()
                         where ((q1.StudentId == iStudentId) && (q1.SemSyId == iSemSyId))
                         orderby q1.RegistrationId descending
                         select new RegistrationEntity
                         {
                             StudentId = q0.StudentId,
                             IdNo = q0.IdNo,
                             LastName = q0.LastName,
                             FirstName = q0.FirstName,
                             MiddleName = q0.MiddleName,
                             Course = q1.Cours.Abbreviation,
                             YearLevel = q1.YearLevel.YearLevelName,
                             Section = q1.Section.SectionName,
                             CourseId = q1.CourseId,
                             ProspectusId = q1.ProspectusId,
                             YearLevelId = q1.YearLevelId,
                             SectionId = q1.SectionId,
                             StatusId = q1.StudentStatusId,
                             TypeId = q1.StudentTypeId,
                             SemSyId = q1.SemSyId,
                             ScholarshipId = q1.ScholarshipId,
                             ScholarshipId1 = q1.ScholarshipId1,
                             ScholarshipId2 = q1.ScholarshipId2,
                             Cancelled = q1.IsCancelled,
                             Paid = q1.IsPaid,
                             Enrolled = q1.IsEnrolled,
                             CourseName = q1.Cours.CourseName,
                             CurriculumName = q1.Prospectus.ProspectusName,
                             StatusName = q1.StudentStatus.StatusName,
                             TypeName = q1.StudentType.StudentTypeName,
                             ScholarshipName = q2.ScholarshipName,
                             ScholarshipName1 = q13a.ScholarshipName,
                             ScholarshipName2 = q14a.ScholarshipName,
                             RegistrationDate = q1.RegistrationDate,
                             RegistrationId = q1.RegistrationId
                         }).Take(1);
                return q.SingleOrDefault();
            }
        }

        public static Registration CheckIfEnrolledSemSyStudent(int iSemSyId, int iStudentId)
        {
            using (var e = new ESEntities())
            {
                var q = e.Registrations.SingleOrDefault(r => (r.StudentId == iStudentId) && (r.SemSyId == iSemSyId));
                return q;
            }
        }

        public static Registration GetRegistration(int iRegistrationId)
        {
            using (var e = new ESEntities())
            {
                var q = e.Registrations.SingleOrDefault(r => r.RegistrationId == iRegistrationId);
                return q;
            }
        }

        public static StudentPicture GetStudentPicture(int iStudentId)
        {
            using (var e = new ESEntities())
            {
                var q = e.StudentPictures.SingleOrDefault(s => s.StudentId == iStudentId);

                return q;
            }
        }
        #endregion
    }
}
