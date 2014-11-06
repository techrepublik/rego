using System;
using System.Linq;
using System.Data.Objects;
using GenDataLayer.repo.entities;

namespace GenDataLayer.repo.managers
{
    public static class CompiledQueries
    {
        #region
        public static readonly Func<ESEntities, IQueryable<Student>> GetStudents =
          CompiledQuery.Compile<ESEntities, IQueryable<Student>>(q => q.Students);
        #endregion
        #region College
        public static readonly Func<ESEntities, IQueryable<College>> GetColleges =
           CompiledQuery.Compile<ESEntities, IQueryable<College>>(q => q.Colleges);
        #endregion

        #region YearLevel
        public static readonly Func<ESEntities, IQueryable<YearLevel>> GetYearLevels =
            CompiledQuery.Compile<ESEntities, IQueryable<YearLevel>>(q => q.YearLevels.OrderBy(c => c.YearLevelName));
        #endregion

        #region Cours
        public static readonly Func<ESEntities, IQueryable<Cours>> GetCourses =
            CompiledQuery.Compile<ESEntities, IQueryable<Cours>>(q => q.Courses.OrderBy(c => c.CourseName));

        public static readonly Func<ESEntities, IQueryable<CourseEntity>> GetCoursesEntity =
            CompiledQuery.Compile<ESEntities, IQueryable<CourseEntity>>(q => q.Courses.GroupJoin(q.Departments, t => t.DepartmentId, t2 => (Int32?) (t2.DepartmentId), (t, t2Join) => new {t, t2Join})
                                                                              .SelectMany(temp0 => temp0.t2Join.DefaultIfEmpty(), (temp0, t2) => new {temp0, t2})
                                                                              .OrderBy(temp1 => temp1.temp0.t.CourseName)
                                                                              .Select(temp1 =>
                                                                                      new CourseEntity
                                                                                          {
                                                                                              CourseId = temp1.temp0.t.CourseId,
                                                                                              CourseName = temp1.temp0.t.CourseName,
                                                                                              Abbreviation = temp1.temp0.t.Abbreviation,
                                                                                              DepartmentId = temp1.t2.DepartmentId,
                                                                                              DepartmentName = temp1.t2.DepartmentName
                                                                                          }));
        #endregion

        #region Scholarship
        public static readonly Func<ESEntities, IQueryable<Scholarship>> GetScholarships =
            CompiledQuery.Compile<ESEntities, IQueryable<Scholarship>>(q => q.Scholarships.OrderBy(c => c.ScholarshipName));
        #endregion

        #region StudentType
        public static readonly Func<ESEntities, IQueryable<StudentType>> GetStudentTypes =
            CompiledQuery.Compile<ESEntities, IQueryable<StudentType>>(q => q.StudentTypes.OrderBy(c => c.StudentTypeName));
        #endregion

        #region StudentStatus
        public static readonly Func<ESEntities, IQueryable<StudentStatus>> GetStudentStatuses =
            CompiledQuery.Compile<ESEntities, IQueryable<StudentStatus>>(q => q.StudentStatuses.OrderBy(c => c.StatusName));
        #endregion

        #region Section
        public static readonly Func<ESEntities, IQueryable<Section>> GetSections =
            CompiledQuery.Compile<ESEntities, IQueryable<Section>>(q => q.Sections.OrderBy(c => c.SectionName));
        #endregion

        #region Major
        public static readonly Func<ESEntities, IQueryable<Major>> GetMajors =
            CompiledQuery.Compile<ESEntities, IQueryable<Major>>(q => q.Majors.OrderBy(c => c.MajorName));
        #endregion

        #region Minor
        public static readonly Func<ESEntities, IQueryable<Minor>> GetMinors =
            CompiledQuery.Compile<ESEntities, IQueryable<Minor>>(q => q.Minors.OrderBy(c => c.MinorName));
        #endregion

        #region Get Subjects by YearLevel, Course and Section
        /// <summary>
        /// Get Subjects by YearLevel, Course and Section
        /// </summary>
        public static readonly Func<ESEntities, int, int, int, IQueryable<SubjectEntity>> GetSubjectsByYearLevelCourseSection =
            CompiledQuery.Compile<ESEntities, int, int, int, IQueryable<SubjectEntity>>((q, yearLeveId, courseId, sectionId) => (from t in q.SemSys
                                                                                                                                 join t0 in q.CourseSecSchedules on t.SemSyId equals t0.SemSyId
                                                                                                                                 join t1 in q.Schedules on t0.CourseSecScheduleId equals t1.CourseSecScheduleId
                                                                                                                                 join t2 in q.ProspectusSubjects on t1.ProspectusSubjectId equals t2.ProspectusSubjectId
                                                                                                                                 join t3 in q.Subjects on t2.SubjectId equals t3.SubjectId
                                                                                                                                 where
                                                                                                                                   (t3.IsActive == true &&
                                                                                                                                  t3.IsDeleted == false) &&
                                                                                                                                   t.Active == true &&
                                                                                                                                   (t0.YearLevelId == yearLeveId &&
                                                                                                                                  t0.CourseId == courseId &&
                                                                                                                                  t0.SectionId == sectionId)
                                                                                                                                 select new SubjectEntity
                                                                                                                                 {
                                                                                                                                     ScheduleId = t1.ScheduleId,
                                                                                                                                     ScheduleCode = t1.ScheduleCode,
                                                                                                                                     TotalToBeRegisteredStudent = t1.StudentLimit.Value + t1.StudentAdded.Value,
                                                                                                                                     SubjectId = t3.SubjectId,
                                                                                                                                     SubjectNo = t3.SubjectNo,
                                                                                                                                     SubjectDescriptiveTitle = t3.SubjectDescriptiveTitle,
                                                                                                                                     SubjectLecUnit = t3.SubjectLecUnit ?? 0,
                                                                                                                                     SubjectLabUnit = t3.SubjectLabUnit ?? 0,
                                                                                                                                     SubjectCreUnit = t3.SubjectCreUnit ?? 0
                                                                                                                                 }));


        public static readonly Func<ESEntities, string, IQueryable<SubjectEntity>> GetSubjectsByScheduleCode =
    CompiledQuery.Compile<ESEntities, string, IQueryable<SubjectEntity>>((q, scheduleCode) => (from t in q.SemSys
                                                                                               join t0 in q.CourseSecSchedules on t.SemSyId equals t0.SemSyId
                                                                                               join t1 in q.Schedules on t0.CourseSecScheduleId equals t1.CourseSecScheduleId
                                                                                               join t2 in q.ProspectusSubjects on t1.ProspectusSubjectId equals t2.ProspectusSubjectId
                                                                                               join t3 in q.Subjects on t2.SubjectId equals t3.SubjectId
                                                                                               where
                                                                                                 (t3.IsActive == true &&
                                                                                                t3.IsDeleted == false) &&
                                                                                                (t.Active == true &&
                                                                                                 t1.ScheduleCode == scheduleCode)
                                                                                               select new SubjectEntity
                                                                                               {
                                                                                                   ScheduleId = t1.ScheduleId,
                                                                                                   ScheduleCode = t1.ScheduleCode,
                                                                                                   TotalToBeRegisteredStudent = t1.StudentLimit.Value + t1.StudentAdded.Value,
                                                                                                   SubjectId = t3.SubjectId,
                                                                                                   SubjectNo = t3.SubjectNo,
                                                                                                   SubjectDescriptiveTitle = t3.SubjectDescriptiveTitle,
                                                                                                   SubjectLecUnit = t3.SubjectLecUnit ?? 0,
                                                                                                   SubjectLabUnit = t3.SubjectLabUnit ?? 0,
                                                                                                   SubjectCreUnit = t3.SubjectCreUnit ?? 0
                                                                                               }));
        #endregion

        #region Schedule
        public static readonly Func<ESEntities, int?, int?> GetTotalStudentRegisteredByScheduleId =
          CompiledQuery.Compile<ESEntities, int?, int?>((q, scheduleId) => (from t in
                                                                              (from t in q.Schedules
                                                                               join t0 in q.RegisteredSchedules on t.ScheduleId equals t0.ScheduleId
                                                                               where
                                                                                 (t.ScheduleId == scheduleId) &&
                                                                                 (t0.IsAdded == true &&
                                                                                 t0.IsDropped == false)
                                                                               select new
                                                                               {
                                                                                   t0.RegisteredScheduleId,
                                                                                   Dummy = "x"
                                                                               })
                                                                          group t by new { t.Dummy } into g
                                                                          select new
                                                                          {
                                                                              TotalStudentRegistered = g.Count()
                                                                          }).FirstOrDefault().TotalStudentRegistered);


        #endregion

        #region Schedule Details
        public static readonly Func<ESEntities, int?, IQueryable<ScheduleDetailEntity>> GetScheduleDetailsByScheduleId =
          CompiledQuery.Compile<ESEntities, int?, IQueryable<ScheduleDetailEntity>>((q, scheduleId) => (from t in q.ScheduleDetails
                                                                                                        join t2 in q.Rooms on t.RoomId equals t2.RoomId into t2Join
                                                                                                        from t2 in t2Join.DefaultIfEmpty()
                                                                                                        where t.ScheduleId == scheduleId
                                                                                                        select new ScheduleDetailEntity
                                                                                                        {
                                                                                                            ScheduleDetailId = t.ScheduleDetailId,
                                                                                                            TimeIn = t.TimeIn,
                                                                                                            TimeOut = t.TimeOut,
                                                                                                            Days = t.Days,
                                                                                                            LecLab = t.LecLab,
                                                                                                            RoomId = t2.RoomId,
                                                                                                            RomeNo = t2.RoomNo
                                                                                                        }));


        #endregion

        #region Course Majors
        public static readonly Func<ESEntities, int, IQueryable<CourseMajorEntity>> GetCourseMajorEntityByCourseId =
         CompiledQuery.Compile<ESEntities, int, IQueryable<CourseMajorEntity>>((q, courseId) => (from t in q.Courses
                                                                                                  join t2 in q.CourseMajors on t.CourseId equals t2.CourseId
                                                                                                  join t3 in q.Majors on t2.MajorId equals t3.MajorId
                                                                                                  where t.CourseId == courseId
                                                                                                  select new CourseMajorEntity
                                                                                                     {
                                                                                                         CourseMajorId = t2.CourseMajorId,
                                                                                                         MajorName = t3.MajorName,
                                                                                                         Note = t2.Note,
                                                                                                         CourseId = t.CourseId,
                                                                                                         CourseName = t.CourseName
                                                                                                     }));
        #endregion

        #region Course Minor
        public static readonly Func<ESEntities, int, IQueryable<CourseMinorEntity>> GetCourseMinorEntityByCourseMajorId =
         CompiledQuery.Compile<ESEntities, int, IQueryable<CourseMinorEntity>>((q, courseMajorId) => (from t in q.CourseMajors
                                                                                                      join t2 in q.CourseMinors on t.CourseMajorId equals t2.CourseMajorId
                                                                                                      join t3 in q.Courses on t.CourseId equals t3.CourseId
                                                                                                      join t4 in q.Majors on t.MajorId equals t4.MajorId
                                                                                                      join t5 in q.Minors on t2.MinorId equals t5.MinorId
                                                                                                      where t2.CourseMinorId == courseMajorId
                                                                                                      select new CourseMinorEntity
                                                                                                      {
                                                                                                          CourseMinorId = t2.CourseMinorId,
                                                                                                          CourseMajorId = t.CourseMajorId,
                                                                                                          CourseMajorName = t4.MajorName + " - " + t3.CourseName,
                                                                                                          Note = t2.Note,
                                                                                                          MinorId = t5.MinorId,
                                                                                                          MinorName = t5.MinorName
                                                                                                      }));
        #endregion

        #region Prospectus 
        public static readonly Func<ESEntities, int, IQueryable<Prospectus>> GetProspectusByCourseId =
                CompiledQuery.Compile<ESEntities, int, IQueryable<Prospectus>>((q, courseId) => q.Prospectuses.Where(c => c.CourseId == courseId));
        #endregion

        #region Registration
        public static readonly Func<ESEntities, int?> GetRegistrationMaxNo =
            CompiledQuery.Compile<ESEntities, int?>(q => q.Registrations.OrderByDescending(c => c.RegistrationId).Select(c => (int?)c.RegistrationId).Take(1).FirstOrDefault());

        #endregion

        //#region Fees
        //public static readonly Func<ESEntities, int, int, IQueryable<AssessmentEntity>> GetAssessmentEntityByYearLevelIdCourseId =
        //        CompiledQuery.Compile<ESEntities, int, int, IQueryable<AssessmentEntity>>((q, yearLevelId, courseId) =>
        //                                                                                                    (from t in q.SetPresetFees
        //                                                                                                     join t0 in q.SemSys on t.SemSyId equals t0.SemSyId
        //                                                                                                     join t1 in q.PresetFees on t.PresetFeeId equals t1.PresetFeeId
        //                                                                                                     join t2 in q.FeeParticulars on t1.FeeParitularId equals t2.FeeParticularId
        //                                                                                                     let lab = q.LaboratoryFees.FirstOrDefault(c => c.FeeParticularId == t2.FeeParticularId)
        //                                                                                                     where
        //                                                                                                       (t0.Active == true) &&
        //                                                                                                      t1.YearLevelId == yearLevelId &&
        //                                                                                                       t.CourseId == courseId
        //                                                                                                     select new AssessmentEntity
        //                                                                                                     {
        //                                                                                                         FeeParticularId = t2.FeeParticularId,
        //                                                                                                         Particulars = t2.Particulars,
        //                                                                                                         Amount = t1.Amount,
        //                                                                                                         TotalAmount = 0,
        //                                                                                                         PercentLess = 0,
        //                                                                                                         NetAmount = 0,
        //                                                                                                         IsTuition = t2.IsTuition,
        //                                                                                                         HasLaboratory = lab != null,
        //                                                                                                         LabId = lab.FeeParticularId
        //                                                                                                     }));

        //#endregion

        #region Laboratories
        public static readonly Func<ESEntities, int?, IQueryable<LaboratoryFeeEntity>> GetLaboratoryFeeEntityByFeeParticularId =
               CompiledQuery.Compile<ESEntities, int?, IQueryable<LaboratoryFeeEntity>>((q, feeParticularId) => (from t in q.Subjects
                                                                                                          join t0 in q.LabSubjects on t.SubjectId equals t0.SubjectId
                                                                                                          join t1 in q.LaboratoryFees on t0.LaboratoryFeeId equals t1.LaboratoryFeeId
                                                                                                          join t2 in q.FeeParticulars on t1.FeeParticularId equals t2.FeeParticularId
                                                                                                          where t2.FeeParticularId == feeParticularId && (t0.IsActive.HasValue && t0.IsActive.Value)
                                                                                                          select new LaboratoryFeeEntity
                                                                                                          {
                                                                                                              FeeParticularId = t2.FeeParticularId,
                                                                                                              Particulars = t2.Particulars + "( " + t.SubjectNo + " )",
                                                                                                              Amount = t1.Amount,
                                                                                                              SubjectLabUnit = t.SubjectLabUnit
                                                                                                          }));
        #endregion

    }
}
