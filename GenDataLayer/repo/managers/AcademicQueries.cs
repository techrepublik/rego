using GenDataLayer.repo.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenDataLayer.repo.reportingentities;

namespace GenDataLayer.repo.managers
{
    public class AcademicQueries
    {
        public static List<YearLevelCourseSectionSemSyEntity> LoadYearLevelSemSyByRegistration(int iStudentId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Registrations
                        join q1 in _e.SemSys on q0.SemSyId equals q1.SemSyId
                        join q2 in _e.Courses on q0.CourseId equals q2.CourseId
                        join q3 in _e.Sections on q0.SectionId equals q3.SectionId
                        join q4 in _e.Scholarships on q0.ScholarshipId equals q4.ScholarshipId
                        into q04 from q04a in q04.DefaultIfEmpty()
                        where (q0.StudentId == iStudentId)
                        select new YearLevelCourseSectionSemSyEntity
                            {
                                RegistrationId = q0.RegistrationId,
                                SemSyId = q0.SemSyId,
                                YearLevelName = q0.YearLevel.YearLevelName,
                                SemSyName = q1.Semester + ", " + q1.Sy,
                                CourseName = q2.Abbreviation,
                                SectionName = q3.SectionName,
                                ScholarshipName = q04a.ScholarshipName
                            };
                return q.OrderByDescending(o => o.RegistrationId).ToList();
            }
        }

        public static List<StudentSubjectEntity> LoadStudentSubjectEntityByRegistration(int iRegistration)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.RegisteredSchedules
                        join q1 in _e.Schedules on q0.ScheduleId equals q1.ScheduleId
                        join q2 in _e.ProspectusSubjects on q1.ProspectusSubjectId equals q2.ProspectusSubjectId
                        join q3 in _e.Subjects on q2.SubjectId equals q3.SubjectId
                        where (q0.RegistrationId == iRegistration)
                        select new StudentSubjectEntity
                            {
                                SubjectScheduleId = q1.ScheduleId,
                                ScheduleCode = q1.ScheduleCode,
                                SubjectNo = q3.SubjectNo,
                                DescriptiveTitle = q3.SubjectDescriptiveTitle,
                                CreditUnit = q3.SubjectCreUnit,
                                LaboratoryUnit = q3.SubjectLabUnit,
                                LectureUnit = q3.SubjectLecUnit,
                                FirstGrade = q0.FirstGrading,
                                SecondGrade = q0.SecondGrading,
                                ThirdGrade = q0.ThirdGrading,
                                FourthGrade = q0.FourthGrading,
                                FifthGrade = q0.FifthGrading,
                                SixthGrade = q0.SixthGrading,
                                Remark = q0.Remark,
                                Added = q0.IsAdded,
                                Regular = q0.IsRegular,
                                Dropped = q0.IsDropped,
                                Posted = q0.IsPosted,
                                PostEdited = q0.IsPostEdited,
                                PostedDate = q0.PostedDate,
                                PostEditedDate = q0.PostEditedDate,
                                RegistrationId = q0.RegistrationId,
                                EditedBy = q0.EditedBy
                            };
                return q.ToList();
            }
        }

        public static List<RegistrationEntity> GetRegistrationEntity(int iSemSyId, int iBranchId, int iId, int iChoiceId)
        {
            using (var e = new ESEntities())
            {
                var listRegistration = new List<RegistrationEntity>();
                switch (iChoiceId)
                {
                    case 1:
                        var qA = from q1 in e.Registrations
                                 join q2 in e.Students on q1.StudentId equals q2.StudentId
                                 join q3 in e.Courses on q1.CourseId equals q3.CourseId
                                 join q4 in e.Departments on q3.DepartmentId equals q4.DepartmentId
                                 where ((q4.CollegeId == iId) && (q4.College.BranchId == iBranchId) &&
                                      (q1.SemSyId == iSemSyId))
                                 select new RegistrationEntity
                                     {
                                         RegistrationId = q1.RegistrationId,
                                         RegistrationDate = q1.RegistrationDate,
                                         Paid = q1.IsPaid,
                                         Cancelled = q1.IsCancelled,
                                         Enrolled = q1.IsEnrolled,
                                         StatusName = q1.StudentStatus.StatusName,
                                         TypeName = q1.StudentType.StudentTypeName,
                                         IdNo = q2.IdNo,
                                         LastName = q2.LastName,
                                         FirstName = q2.FirstName,
                                         MiddleName = q2.MiddleName,
                                         Gender = q2.Gender,
                                         YearLevel = q1.YearLevel.YearLevelName,
                                         Course = q1.Cours.Abbreviation,
                                         Section = q1.Section.SectionName
                                     };
                        listRegistration = qA.OrderByDescending(o => o.RegistrationDate).ToList();
                        break;
                    case 2:
                        var qB = from q1 in e.Registrations
                                 join q2 in e.Students on q1.StudentId equals q2.StudentId
                                 join q3 in e.Courses on q1.CourseId equals q3.CourseId
                                 join q4 in e.Departments on q3.DepartmentId equals q4.DepartmentId
                                 where ((q4.DepartmentId == iId) && (q4.College.BranchId == iBranchId) &&
                                      (q1.SemSyId == iSemSyId))
                                 select new RegistrationEntity
                                     {
                                         RegistrationId = q1.RegistrationId,
                                         RegistrationDate = q1.RegistrationDate,
                                         Paid = q1.IsPaid,
                                         Cancelled = q1.IsCancelled,
                                         Enrolled = q1.IsEnrolled,
                                         StatusName = q1.StudentStatus.StatusName,
                                         TypeName = q1.StudentType.StudentTypeName,
                                         IdNo = q2.IdNo,
                                         LastName = q2.LastName,
                                         FirstName = q2.FirstName,
                                         MiddleName = q2.MiddleName,
                                         Gender = q2.Gender,
                                         YearLevel = q1.YearLevel.YearLevelName,
                                         Course = q1.Cours.Abbreviation,
                                         Section = q1.Section.SectionName
                                     };
                        listRegistration = qB.OrderByDescending(o => o.RegistrationDate).ToList();
                        break;
                    case 3:
                        var qC = from q1 in e.Registrations
                                 join q2 in e.Students on q1.StudentId equals q2.StudentId
                                 join q3 in e.Courses on q1.CourseId equals q3.CourseId
                                 join q4 in e.Departments on q3.DepartmentId equals q4.DepartmentId
                                 where ((q1.CourseId == iId) && (q4.College.BranchId == iBranchId) &&
                                      (q1.SemSyId == iSemSyId))
                                 select new RegistrationEntity
                                     {
                                         RegistrationId = q1.RegistrationId,
                                         RegistrationDate = q1.RegistrationDate,
                                         Paid = q1.IsPaid,
                                         Cancelled = q1.IsCancelled,
                                         Enrolled = q1.IsEnrolled,
                                         StatusName = q1.StudentStatus.StatusName,
                                         TypeName = q1.StudentType.StudentTypeName,
                                         IdNo = q2.IdNo,
                                         LastName = q2.LastName,
                                         FirstName = q2.FirstName,
                                         MiddleName = q2.MiddleName,
                                         Gender = q2.Gender,
                                         YearLevel = q1.YearLevel.YearLevelName,
                                         Course = q1.Cours.Abbreviation,
                                         Section = q1.Section.SectionName
                                     };
                        listRegistration = qC.OrderByDescending(o => o.RegistrationDate).ToList();
                        break;
                    default:
                        break;
                }
                return listRegistration;
            }
        }

        public static List<RegistrationEntity> GetRegistrationEntity(int iSemSyId, int iBranchId, int iYearId, int iSectionId, int iCourseId)
        {
            using (var e = new ESEntities())
            {
                var qC = from q1 in e.Registrations
                         join q2 in e.Students on q1.StudentId equals q2.StudentId
                        join q3 in e.Courses on q1.CourseId equals q3.CourseId
                        join q4 in e.Departments on q3.DepartmentId equals q4.DepartmentId
                        where ((q1.CourseId == iCourseId) && (q1.YearLevelId == iYearId) && (q1.CourseId == iCourseId) && (q4.College.BranchId == iBranchId) &&
                            (q1.SemSyId == iSemSyId))
                        select new RegistrationEntity
                        {
                            RegistrationId = q1.RegistrationId,
                            RegistrationDate = q1.RegistrationDate,
                            Paid = q1.IsPaid,
                            Cancelled = q1.IsCancelled,
                            Enrolled = q1.IsEnrolled,
                            StatusName = q1.StudentStatus.StatusName,
                            TypeName = q1.StudentType.StudentTypeName,
                            IdNo = q2.IdNo,
                            LastName = q2.LastName,
                            FirstName = q2.FirstName,
                            MiddleName = q2.MiddleName,
                            Gender = q2.Gender,
                            YearLevel = q1.YearLevel.YearLevelName,
                            Course = q1.Cours.Abbreviation,
                            Section = q1.Section.SectionName
                        };
                return qC.OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public static List<RegistrationEntity> GetRegistrationEntity(int iSemSyId, int iBranchId)
        {
            using (var e = new ESEntities())
            {
                var qC = from q1 in e.Registrations
                         join q2 in e.Students on q1.StudentId equals q2.StudentId
                         join q3 in e.Courses on q1.CourseId equals q3.CourseId
                         join q4 in e.Departments on q3.DepartmentId equals q4.DepartmentId
                         where ((q4.College.BranchId == iBranchId) && (q1.SemSyId == iSemSyId))
                         select new RegistrationEntity
                         {
                             RegistrationId = q1.RegistrationId,
                             RegistrationDate = q1.RegistrationDate,
                             Paid = q1.IsPaid,
                             Cancelled = q1.IsCancelled,
                             Enrolled = q1.IsEnrolled,
                             StatusName = q1.StudentStatus.StatusName,
                             TypeName = q1.StudentType.StudentTypeName,
                             IdNo = q2.IdNo,
                             LastName = q2.LastName,
                             FirstName = q2.FirstName,
                             MiddleName = q2.MiddleName,
                             Gender = q2.Gender,
                             YearLevel = q1.YearLevel.YearLevelName,
                             Course = q1.Cours.Abbreviation,
                             Section = q1.Section.SectionName
                         };
                return qC.OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        //edited by josh 10.4.2014
        #region TeacherSubjects
        public static List<TeacherSubjectEntity> GetAllTeacherSubjects(int iId, int iChoice, int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var list = new List<TeacherSubjectEntity>();
                switch (iChoice)
                {
                    case 0:
                        var qa = from q0 in e.Schedules
                                 join q1 in e.TeacherSubjects on q0.ScheduleId equals q1.ScheduleId into q01 from q01a in q01.DefaultIfEmpty()
                                 join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                                 join q3 in e.ProspectusSemYrs on q2.ProspectusSemYrId equals q3.ProspectusSemYrId
                                 join q4 in e.Prospectuses on q3.ProspectusId equals q4.ProspectusId
                                 join q5 in e.Courses on q4.CourseId equals q5.CourseId
                                 join q6 in e.Subjects on q2.SubjectId equals q6.SubjectId
                                 where ((q5.DepartmentId == iId) && (q0.CourseSecSchedule.SemSyId == iSemSyId))
                                 select new TeacherSubjectEntity
                                     {
                                         TeacherSubjectId = q01a.TeacherSubjectId,
                                         TeacherSubjectNote = q01a.TeacherSubjectNote,
                                         TeacherId = q01a.TeacherId,
                                         ScheduleId = q0.ScheduleId,
                                         Active = q01a.TeacherSubjectIsActive,
                                         OnUs = q01a.TeacherSubjectOnUs,
                                         ScheduleCode = q0.ScheduleCode,
                                         SubjectNo = q6.SubjectNo,
                                         SubjectDescriptiveTitle = q6.SubjectDescriptiveTitle,
                                         SubjectLecUnit = q6.SubjectLecUnit,
                                         SubjectLabUnit = q6.SubjectLabUnit,
                                         SubjectCreUnit = q6.SubjectCreUnit,
                                         IsActive = q6.IsActive,
                                         Posted = q01a.TeacherSubjectPosted,
                                         PostEdited = q01a.TeacherSubjectPostEdited,
                                         PostedDate = q01a.TeacherSubjectPostedDate,
                                         Mode = q01a.TeacherSubjectPostMode,
                                         PostedBy = q01a.TeacherSubjectPostedBy
                                     };
                        list = qa.ToList();
                        break;
                    case 1:
                        var qb = from q0 in e.Schedules
                                 join q1 in e.TeacherSubjects on q0.ScheduleId equals q1.ScheduleId into q01 from q01a in q01.DefaultIfEmpty()
                                 join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                                 join q3 in e.ProspectusSemYrs on q2.ProspectusSemYrId equals q3.ProspectusSemYrId
                                 join q4 in e.Prospectuses on q3.ProspectusId equals q4.ProspectusId
                                 join q5 in e.Courses on q4.CourseId equals q5.CourseId
                                 join q5a in e.Departments on q5.DepartmentId equals q5a.DepartmentId
                                 join q6 in e.Subjects on q2.SubjectId equals q6.SubjectId
                                 where ((q5a.CollegeId == iId) && (q0.CourseSecSchedule.SemSyId == iSemSyId))
                                 select new TeacherSubjectEntity
                                     {
                                         TeacherSubjectId = q01a.TeacherSubjectId,
                                         TeacherSubjectNote = q01a.TeacherSubjectNote,
                                         TeacherId = q01a.TeacherId,
                                         ScheduleId = q0.ScheduleId,
                                         Active = q01a.TeacherSubjectIsActive,
                                         OnUs = q01a.TeacherSubjectOnUs,
                                         ScheduleCode = q0.ScheduleCode,
                                         SubjectNo = q6.SubjectNo,
                                         SubjectDescriptiveTitle = q6.SubjectDescriptiveTitle,
                                         SubjectLecUnit = q6.SubjectLecUnit,
                                         SubjectLabUnit = q6.SubjectLabUnit,
                                         SubjectCreUnit = q6.SubjectCreUnit,
                                         IsActive = q6.IsActive,
                                         Posted = q01a.TeacherSubjectPosted,
                                         PostEdited = q01a.TeacherSubjectPostEdited,
                                         PostedDate = q01a.TeacherSubjectPostedDate,
                                         Mode = q01a.TeacherSubjectPostMode,
                                         PostedBy = q01a.TeacherSubjectPostedBy
                                     };
                        list = qb.ToList();
                        break;
                    case 2:
                        var qc = from q0 in e.Schedules
                                 join q1 in e.TeacherSubjects on q0.ScheduleId equals q1.ScheduleId into q01 from q01a in q01.DefaultIfEmpty()
                                 join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                                 join q3 in e.ProspectusSemYrs on q2.ProspectusSemYrId equals q3.ProspectusSemYrId
                                 join q4 in e.Prospectuses on q3.ProspectusId equals q4.ProspectusId
                                 join q5 in e.Courses on q4.CourseId equals q5.CourseId
                                 join q5a in e.Departments on q5.DepartmentId equals q5a.DepartmentId
                                 join q6 in e.Subjects on q2.SubjectId equals q6.SubjectId
                                 where ((q01a.TeacherId == iId) && (q0.CourseSecSchedule.SemSyId == iSemSyId))
                                 select new TeacherSubjectEntity
                                     {
                                         TeacherSubjectId = q01a.TeacherSubjectId,
                                         TeacherSubjectNote = q01a.TeacherSubjectNote,
                                         TeacherId = q01a.TeacherId,
                                         ScheduleId = q0.ScheduleId,
                                         Active = q01a.TeacherSubjectIsActive,
                                         OnUs = q01a.TeacherSubjectOnUs,
                                         ScheduleCode = q0.ScheduleCode,
                                         SubjectNo = q6.SubjectNo,
                                         SubjectDescriptiveTitle = q6.SubjectDescriptiveTitle,
                                         SubjectLecUnit = q6.SubjectLecUnit,
                                         SubjectLabUnit = q6.SubjectLabUnit,
                                         SubjectCreUnit = q6.SubjectCreUnit,
                                         IsActive = q6.IsActive,
                                         Posted = q01a.TeacherSubjectPosted,
                                         PostEdited = q01a.TeacherSubjectPostEdited,
                                         PostedDate = q01a.TeacherSubjectPostedDate,
                                         Mode = q01a.TeacherSubjectPostMode,
                                         PostedBy = q01a.TeacherSubjectPostedBy
                                     };
                        list = qc.ToList();
                        break;
                    default:
                        break;
                }
                return list;
            }
        }
        #endregion

        //edited by josh 10.4.2014
        #region StudentGrades
        public static List<SubjectStudentEntity> GetAllStudentBySubject(int iId1, int iId2)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Students
                        join q1 in _e.Registrations on q0.StudentId equals q1.StudentId
                        join q2 in _e.RegisteredSchedules on q1.RegistrationId equals q2.RegistrationId
                        where ((q1.SemSyId == iId1) && (q2.ScheduleId == iId2))
                        select new SubjectStudentEntity
                        {
                            IdNo = q0.IdNo,
                            LastName = q0.LastName,
                            FirstName = q0.FirstName,
                            MiddleName = q0.MiddleName,
                            Course = q1.Cours.Abbreviation,
                            Section = q1.Section.SectionName,
                            YearLevel = q1.YearLevel.YearLevelName,
                            Regular = q2.IsRegular,
                            Added = q2.IsAdded,
                            Dropped = q2.IsDropped,
                            FirstGrade = q2.FirstGrading,
                            SecondGrade = q2.SecondGrading,
                            ThirdGrade = q2.ThirdGrading,
                            FourthGrade = q2.FourthGrading,
                            FifthGrade = q2.FirstGrading,
                            SixthGrade = q2.SixthGrading,
                            Remarks = q2.Remark,
                            RegisterdSubjectId = q2.RegisteredScheduleId,
                            ScheduleId = q2.ScheduleId,
                            ScheduleCode = q2.ScheduleCode,
                            RegistrationId = q2.RegistrationId,
                            Posted = q2.IsPosted,
                            PostEdited = q2.IsPostEdited,
                            PostedDate = q2.PostedDate,
                            PostEditedDate = q2.PostEditedDate,
                            EditedBy = q2.EditedBy
                        };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<SubjectEntity> GetAllSubjectByCriteria(string criteria, int semSyId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Schedules
                        join q1 in _e.ProspectusSubjects on q0.ProspectusSubjectId equals q1.ProspectusSubjectId
                        join q2 in _e.Subjects on q1.SubjectId equals q2.SubjectId
                        join q3 in _e.CourseSecSchedules on q0.CourseSecScheduleId equals q3.CourseSecScheduleId
                        where ((q3.SemSyId == semSyId) &&
                             ((q0.ScheduleCode == criteria) || (q2.SubjectNo.StartsWith(criteria)) ||
                              (q2.SubjectDescriptiveTitle.StartsWith(criteria))))
                        select new SubjectEntity
                            {
                                ScheduleId = q0.ScheduleId,
                                ScheduleCode = q0.ScheduleCode,
                                SubjectNo = q2.SubjectNo,
                                SubjectDescriptiveTitle = q2.SubjectDescriptiveTitle,
                                SubjectLecUnit = q2.SubjectLecUnit,
                                SubjectLabUnit = q2.SubjectLabUnit,
                                SubjectCreUnit = q2.SubjectCreUnit
                            };
                return q.OrderBy(o => o.SubjectNo).ToList();
            }
        }
        #endregion

        //edited by josh 10.4.2013
        #region GradeBase
        public static List<GradeBaseValue> GetGradeBaseDefault()
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.GradeBaseValues
                        where (q0.GradeBas.GradeBaseDefault == true)
                        select q0;
                return q.OrderBy(o => o.GradeBaseValueArrange).ToList();
            }
        }
        #endregion

        //edited by josh 10.16.2013
        public static List<PostGradeEntity> GetAllPostGrades(int iP1, int iChoice, DateTime? date01 = null, DateTime? date02 = null)
        {
            using (var e = new ESEntities())
            {
                List<PostGradeEntity> list = null;
                switch (iChoice)
                {
                    case 1:
                        var qa = from q0 in e.PostGrades
                        join q1 in e.TeacherSubjects on q0.TeacherSubjectId equals q1.TeacherSubjectId
                        join q2 in e.PostModes on q0.PostModeId equals q2.PostModeId
                        join q3 in e.Teachers on q1.TeacherId equals q3.TeacherId
                        join q4 in e.Schedules on q1.ScheduleId equals q4.ScheduleId
                        join q4a in e.CourseSecSchedules on q4.CourseSecScheduleId equals q4a.CourseSecScheduleId
                        join q5 in e.ProspectusSubjects on q4.ProspectusSubjectId equals q5.ProspectusSubjectId
                        join q6 in e.Subjects on q5.SubjectId equals q6.SubjectId
                        where (q4a.SemSyId == iP1)
                        select new PostGradeEntity
                            {
                                PostGradeId = q0.PostGradeId,
                                PostGradeNo = q0.PostGradeNo,
                                PostGradeDate = q0.PostGradeDate,
                                PostGradeNote = q0.PostGradeNote,
                                EditedBy = q0.EditedBy,
                                PostGradeAccepted = q0.PostGradeAccepted,
                                PostGradeAcceptedBy = q0.PostGradeAcceptedBy,
                                PostModeName = q2.PostModeName,
                                TeacherNo = q3.TeacherNo,
                                TeacherId = q3.TeacherId,
                                LastName = q3.LastName,
                                FirstName = q3.FirstName,
                                MiddleName = q3.MiddleName
                            };
                        list = qa.OrderByDescending(o => o.PostGradeDate).ToList();
                        break;
                    case 2:
                        var qb = from q0 in e.PostGrades
                        join q1 in e.TeacherSubjects on q0.TeacherSubjectId equals q1.TeacherSubjectId
                        join q2 in e.PostModes on q0.PostModeId equals q2.PostModeId
                        join q3 in e.Teachers on q1.TeacherId equals q3.TeacherId
                        join q4 in e.Schedules on q1.ScheduleId equals q4.ScheduleId
                        join q4a in e.CourseSecSchedules on q4.CourseSecScheduleId equals q4a.CourseSecScheduleId
                        join q5 in e.ProspectusSubjects on q4.ProspectusSubjectId equals q5.ProspectusSubjectId
                        join q6 in e.Subjects on q5.SubjectId equals q6.SubjectId
                        where ((q4a.SemSyId == iP1) && (q0.PostGradeDate == date01))
                        select new PostGradeEntity
                            {
                                PostGradeId = q0.PostGradeId,
                                PostGradeNo = q0.PostGradeNo,
                                PostGradeDate = q0.PostGradeDate,
                                PostGradeNote = q0.PostGradeNote,
                                EditedBy = q0.EditedBy,
                                PostGradeAccepted = q0.PostGradeAccepted,
                                PostGradeAcceptedBy = q0.PostGradeAcceptedBy,
                                PostModeName = q2.PostModeName,
                                TeacherNo = q3.TeacherNo,
                                TeacherId = q3.TeacherId,
                                LastName = q3.LastName,
                                FirstName = q3.FirstName,
                                MiddleName = q3.MiddleName
                            };
                        list = qb.OrderByDescending(o => o.PostGradeDate).ToList();
                        break;
                    case 3:
                        var qc = from q0 in e.PostGrades
                        join q1 in e.TeacherSubjects on q0.TeacherSubjectId equals q1.TeacherSubjectId
                        join q2 in e.PostModes on q0.PostModeId equals q2.PostModeId
                        join q3 in e.Teachers on q1.TeacherId equals q3.TeacherId
                        join q4 in e.Schedules on q1.ScheduleId equals q4.ScheduleId
                        join q4a in e.CourseSecSchedules on q4.CourseSecScheduleId equals q4a.CourseSecScheduleId
                        join q5 in e.ProspectusSubjects on q4.ProspectusSubjectId equals q5.ProspectusSubjectId
                        join q6 in e.Subjects on q5.SubjectId equals q6.SubjectId
                        where ((q4a.SemSyId == iP1) && ((q0.PostGradeDate >= date01) && (q0.PostGradeDate <= date02)))
                        select new PostGradeEntity
                            {
                                PostGradeId = q0.PostGradeId,
                                PostGradeNo = q0.PostGradeNo,
                                PostGradeDate = q0.PostGradeDate,
                                PostGradeNote = q0.PostGradeNote,
                                EditedBy = q0.EditedBy,
                                PostGradeAccepted = q0.PostGradeAccepted,
                                PostGradeAcceptedBy = q0.PostGradeAcceptedBy,
                                PostModeName = q2.PostModeName,
                                TeacherNo = q3.TeacherNo,
                                TeacherId = q3.TeacherId,
                                LastName = q3.LastName,
                                FirstName = q3.FirstName,
                                MiddleName = q3.MiddleName
                            };
                        list = qc.OrderByDescending(o => o.PostGradeDate).ToList();
                        break;
                    default: break;
                }
                return list;
            }
        }

        //edite by josh 10.12.2013
        #region Objects
        public static TeacherSubjectEntity GetSubjectScheduleTeacher(int scheduleId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Schedules
                         join q1 in e.TeacherSubjects on q0.ScheduleId equals q1.ScheduleId into q01
                         from q01a in q01.DefaultIfEmpty()
                         join q2 in e.ProspectusSubjects on q0.ProspectusSubjectId equals q2.ProspectusSubjectId
                         join q6 in e.Subjects on q2.SubjectId equals q6.SubjectId
                         join q7 in e.Teachers on q01a.TeacherId equals q7.TeacherId into q17 from q17a in q17.DefaultIfEmpty()
                         where (q0.ScheduleId == scheduleId)
                         select new TeacherSubjectEntity
                         {
                             TeacherSubjectId = q01a.TeacherSubjectId,
                             TeacherSubjectNote = q01a.TeacherSubjectNote,
                             TeacherId = q01a.TeacherId,
                             ScheduleId = q0.ScheduleId,
                             Active = q01a.TeacherSubjectIsActive,
                             OnUs = q01a.TeacherSubjectOnUs,
                             ScheduleCode = q0.ScheduleCode,
                             SubjectNo = q6.SubjectNo,
                             SubjectDescriptiveTitle = q6.SubjectDescriptiveTitle,
                             SubjectLecUnit = q6.SubjectLecUnit,
                             SubjectLabUnit = q6.SubjectLabUnit,
                             SubjectCreUnit = q6.SubjectCreUnit,
                             IsActive = q6.IsActive,
                             Posted = q01a.TeacherSubjectPosted,
                             PostEdited = q01a.TeacherSubjectPostEdited,
                             PostedDate = q01a.TeacherSubjectPostedDate,
                             Mode = q01a.TeacherSubjectPostMode,
                             PostedBy = q01a.TeacherSubjectPostedBy,
                             TeacherIdNo = q17a.TeacherNo,
                             TeacherLastName = q17a.LastName,
                             TeacherFirstName = q17a.FirstName,
                             TeacherMiddleName = q17a.MiddleName
                         };
                return q.SingleOrDefault();
            }
        }
        #endregion

        //edied by josh 10.16.2013
        #region PrintStundent
        public static List<PrintStudentClass> GetPrintStudentClass(int iScheduleid)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Registrations
                        join q1 in e.RegisteredSchedules on q0.RegistrationId equals q1.RegistrationId
                        join q2 in e.Students on q0.StudentId equals q2.StudentId
                        join q3 in e.Courses on q0.CourseId equals q3.CourseId
                        join q4 in e.YearLevels on q0.YearLevelId equals q4.YearLevelId
                        join q5 in e.Sections on q0.SectionId equals q5.SectionId
                        join q6 in e.Scholarships on q0.ScholarshipId equals q6.ScholarshipId
                        into q06 from q06a in q06.DefaultIfEmpty()
                        where (q1.ScheduleId == iScheduleid)
                        orderby q2.LastName, q2.FirstName ascending
                        select new PrintStudentClass
                        {
                            StudentId = q2.StudentId,
                            StudentNo = q2.IdNo,
                            LastName = q2.LastName,
                            FirstName = q2.FirstName,
                            CourseId = q3.CourseId,
                            CourseName = q3.Abbreviation,
                            YearLevelId = q4.YearLevelId,
                            YearLevelName = q4.YearLevelName,
                            SectionId = q5.SectionId,
                            SectionName = q5.SectionName,
                            ScholarshipId = q06a.ScholarshipId,
                            ScholarshipName = q06a.ScholarshipName,
                            RegistrationDate = q0.RegistrationDate
                        };
                return q.ToList();
            }
        }
        #endregion

    }
}
