using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.managers
{
    public static class Remove
    {
        #region Student

        public static readonly Func<int, bool> Student = id =>
            {
                using (IDataRepository<Student> i = new DataRepository<Student>())
                {
                    i.Delete(new Student {StudentId = id});
                    i.SaveChanges();
                    return true;
                }
            };

        #endregion
        //edited by Josh 4.9.13

        #region Assessment

        public static readonly Func<int, bool> Assessment = id =>
        {
            using (IDataRepository<Assessment> i = new DataRepository<Assessment>())
            {
                i.Delete(new Assessment { AssessmentId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Barangays

        public static readonly Func<int, bool> Barangays = id =>
        {
            using (IDataRepository<Barangay> i = new DataRepository<Barangay>())
            {
                i.Delete(new Barangay { BarangayId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Colleges

        public static readonly Func<int, bool> Colleges = id =>
        {
            using (IDataRepository<College> i = new DataRepository<College>())
            {
                i.Delete(new College { CollegeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region CourseMajors

        public static readonly Func<int, bool> CourseMajors = id =>
        {
            using (IDataRepository<CourseMajor> i = new DataRepository<CourseMajor>())
            {
                i.Delete(new CourseMajor { CourseMajorId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13
        #region CourseMinors

        public static readonly Func<int, bool> CourseMinors = id =>
        {
            using (IDataRepository<CourseMinor> i = new DataRepository<CourseMinor>())
            {
                i.Delete(new CourseMinor { CourseMinorId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Course

        public static readonly Func<int, bool> Course = id =>
        {
            using (IDataRepository<Cours> i = new DataRepository<Cours>())
            {
                i.Delete(new Cours { CourseId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13


        #region CourseSecSchedules

        public static readonly Func<int, bool> CourseSecSchedules = id =>
        {
            using (IDataRepository<CourseSecSchedule> i = new DataRepository<CourseSecSchedule>())
            {
                i.Delete(new CourseSecSchedule { CourseSecScheduleId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13


        #region Departments

        public static readonly Func<int, bool> Departments = id =>
        {
            using (IDataRepository<Department> i = new DataRepository<Department>())
            {
                i.Delete(new Department { DepartmentId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region DepartmentSubjects

        public static readonly Func<int, bool> DepartmentSubjects = id =>
        {
            using (IDataRepository<DepartmentSubject> i = new DataRepository<DepartmentSubject>())
            {
                i.Delete(new DepartmentSubject { DepartmentSubjectId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region FeeParticulars

        public static readonly Func<int, bool> FeeParticulars = id =>
        {
            using (IDataRepository<FeeParticular> i = new DataRepository<FeeParticular>())
            {
                i.Delete(new FeeParticular { FeeParticularId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region FeeSubTitles

        public static readonly Func<int, bool> FeeSubTitles = id =>
        {
            using (IDataRepository<FeeSubTitle> i = new DataRepository<FeeSubTitle>())
            {
                i.Delete(new FeeSubTitle { FeeSubTitleId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region FeeTitle

        public static readonly Func<int, bool> FeeTitle = id =>
        {
            using (IDataRepository<FeeTitle> i = new DataRepository<FeeTitle>())
            {
                i.Delete(new FeeTitle { FeeTitleId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region LaboratoryFees

        public static readonly Func<int, bool> LaboratoryFees = id =>
        {
            using (IDataRepository<LaboratoryFee> i = new DataRepository<LaboratoryFee>())
            {
                i.Delete(new LaboratoryFee { LaboratoryFeeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region LabSubjects

        public static readonly Func<int, bool> LabSubjects = id =>
        {
            using (IDataRepository<LabSubject> i = new DataRepository<LabSubject>())
            {
                i.Delete(new LabSubject { LabSubjectId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Majors

        public static readonly Func<int, bool> CoMajorsurse = id =>
        {
            using (IDataRepository<Major> i = new DataRepository<Major>())
            {
                i.Delete(new Major { MajorId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Minors

        public static readonly Func<int, bool> Minors = id =>
        {
            using (IDataRepository<Minor> i = new DataRepository<Minor>())
            {
                i.Delete(new Minor { MinorId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region MunCitys

        public static readonly Func<int, bool> MunCitys = id =>
        {
            using (IDataRepository<MunCity> i = new DataRepository<MunCity>())
            {
                i.Delete(new MunCity { MunCityId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region PaidParticulars

        public static readonly Func<int, bool> PaidParticulars = id =>
        {
            using (IDataRepository<PaidParticular> i = new DataRepository<PaidParticular>())
            {
                i.Delete(new PaidParticular { PaidParicularId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region PreRequisites

        public static readonly Func<int, bool> PreRequisites = id =>
        {
            using (IDataRepository<PreRequisite> i = new DataRepository<PreRequisite>())
            {
                i.Delete(new PreRequisite { PreRequisiteId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region PresetFees

        public static readonly Func<int, bool> PresetFees = id =>
        {
            using (IDataRepository<PresetFee> i = new DataRepository<PresetFee>())
            {
                i.Delete(new PresetFee { PresetFeeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Prospectuss

        public static readonly Func<int, bool> Prospectusss = id =>
        {
            using (IDataRepository<Prospectus> i = new DataRepository<Prospectus>())
            {
                i.Delete(new Prospectus { ProspectusId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region ProspectusSemYrs

        public static readonly Func<int, bool> ProspectusSemYrs = id =>
        {
            using (IDataRepository<ProspectusSemYr> i = new DataRepository<ProspectusSemYr>())
            {
                i.Delete(new ProspectusSemYr { ProspectusSemYrId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        
        //edited by Faith 4.9.13
        #region ProspectusSubjects

        public static readonly Func<int, bool> ProspectusSubjects = id =>
        {
            using (IDataRepository<ProspectusSubject> i = new DataRepository<ProspectusSubject>())
            {
                i.Delete(new ProspectusSubject { ProspectusSubjectId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        
        //edited by Faith 4.9.13
        #region Provinces

        public static readonly Func<int, bool> Provinces = id =>
        {
            using (IDataRepository<Province> i = new DataRepository<Province>())
            {
                i.Delete(new Province { ProvinceId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13

        #region Receipts

        public static readonly Func<int, bool> Receipts = id =>
        {
            using (IDataRepository<Receipt> i = new DataRepository<Receipt>())
            {
                i.Delete(new Receipt { ReceiptId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13


        #region RegisteredSchedules

        public static readonly Func<int, bool> RegisteredSchedules = id =>
        {
            using (IDataRepository<RegisteredSchedule> i = new DataRepository<RegisteredSchedule>())
            {
                i.Delete(new RegisteredSchedule { RegisteredScheduleId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Registrations

        public static readonly Func<int, bool> Registrations = id =>
        {
            using (IDataRepository<Registration> i = new DataRepository<Registration>())
            {
                i.Delete(new Registration { RegistrationId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Rooms

        public static readonly Func<int, bool> Rooms = id =>
        {
            using (IDataRepository<Room> i = new DataRepository<Room>())
            {
                i.Delete(new Room { RoomId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region ScheduleDetails

        public static readonly Func<int, bool> ScheduleDetails = id =>
        {
            using (IDataRepository<ScheduleDetail> i = new DataRepository<ScheduleDetail>())
            {
                i.Delete(new ScheduleDetail { ScheduleDetailId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        
        
        //edited by Faith 4.9.13 - Josh
        #region ScheduleFees

        public static readonly Func<int, bool> ScheduleFees = id =>
        {
            using (IDataRepository<ScheduleFee> i = new DataRepository<ScheduleFee>())
            {
                i.Delete(new ScheduleFee { ScheduleFeeId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Faith 4.9.13 - Josh
        #region ScheduleFeeName

        public static readonly Func<int, bool> ScheduleFeeNames = id =>
        {
            using (IDataRepository<ScheduleFeeName> i = new DataRepository<ScheduleFeeName>())
            {
                i.Delete(new ScheduleFeeName { ScheduleFeeNameId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Faith 4.9.13
        #region Schedules

        public static readonly Func<int, bool> Schedules = id =>
        {
            using (IDataRepository<Schedule> i = new DataRepository<Schedule>())
            {
                i.Delete(new Schedule { ScheduleId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13
        #region ScholarshipFee

        public static readonly Func<int, bool> ScholarshipFee = id =>
        {
            using (IDataRepository<ScholarshipFee> i = new DataRepository<ScholarshipFee>())
            {
                i.Delete(new ScholarshipFee { ScholarshipFeeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13
        #region Scholarships

        public static readonly Func<int, bool> Scholarshp = id =>
        {
            using (IDataRepository<Scholarship> i = new DataRepository<Scholarship>())
            {
                i.Delete(new Scholarship { ScholarshipId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13
        #region Sections

        public static readonly Func<int, bool> Sections = id =>
        {
            using (IDataRepository<Section> i = new DataRepository<Section>())
            {
                i.Delete(new Section { SectionId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13
         #region SemSys

        public static readonly Func<int, bool> SemSys = id =>
        {
            using (IDataRepository<SemSy> i = new DataRepository<SemSy>())
            {
                i.Delete(new SemSy { SemSyId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion

        //edited by Faith 4.9.13
        #region SetPresetFees

        public static readonly Func<int, bool> SetPresetFees = id =>
        {
            using (IDataRepository<SetPresetFee> i = new DataRepository<SetPresetFee>())
            {
                i.Delete(new SetPresetFee { SetPresetFeeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region SetScheduleFees

        public static readonly Func<int, bool> SetScheduleFee = id =>
        {
            using (IDataRepository<SetScheduleFee> i = new DataRepository<SetScheduleFee>())
            {
                i.Delete(new SetScheduleFee { SetScheduleFeeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13
        #region StreetHouss

        public static readonly Func<int, bool> StreetHouss = id =>
        {
            using (IDataRepository<StreetHous> i = new DataRepository<StreetHous>())
            {
                i.Delete(new StreetHous { StreetHouseId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region StudentPictures

        public static readonly Func<int, bool> StudentPictures = id =>
        {
            using (IDataRepository<StudentPicture> i = new DataRepository<StudentPicture>())
            {
                i.Delete(new StudentPicture { StudentPictureId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13


        #region StudentStatuss

        public static readonly Func<int, bool> StudentStatuss = id =>
        {
            using (IDataRepository<StudentStatus> i = new DataRepository<StudentStatus>())
            {
                i.Delete(new StudentStatus { StudentStatusId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        //edited by japz 4.9.13
        #region StudentType

        public static readonly Func<int, bool> StudentType = id =>
        {
            using (IDataRepository<StudentType> i = new DataRepository<StudentType>())
            {
                i.Delete(new StudentType { StudenTypeId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region Subjects

        public static readonly Func<int, bool> Subjects = id =>
        {
            using (IDataRepository<Subject> i = new DataRepository<Subject>())
            {
                i.Delete(new Subject { SubjectId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region UserAcces

        public static readonly Func<int, bool> UserAcces = id =>
        {
            using (IDataRepository<UserAccess> i = new DataRepository<UserAccess>())
            {
                i.Delete(new UserAccess { UserAccessId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region UserLevels

        public static readonly Func<int, bool> UserLevels = id =>
        {
            using (IDataRepository<UserLevel> i = new DataRepository<UserLevel>())
            {
                i.Delete(new UserLevel { UserLevelId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region UserRestrictions

        public static readonly Func<int, bool> UserRestrictions = id =>
        {
            using (IDataRepository<UserRestriction> i = new DataRepository<UserRestriction>())
            {
                i.Delete(new UserRestriction { UserRestrictionId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13


        #region Users

        public static readonly Func<int, bool> Users = id =>
        {
            using (IDataRepository<User> i = new DataRepository<User>())
            {
                i.Delete(new User { UserId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        //edited by Faith 4.9.13

        #region YearLevels

        public static readonly Func<int, bool> YearLevels = id =>
        {
            using (IDataRepository<YearLevel> i = new DataRepository<YearLevel>())
            {
                i.Delete(new YearLevel { YearLevelId = id });
                i.SaveChanges();
                return true;
            }
        };

        #endregion
        
        //edited by Josh 9.3.13
        #region Branches
        public static readonly Func<int, bool> Branches = id =>
        {
            using (IDataRepository<Branch> i = new DataRepository<Branch>())
            {
                i.Delete(new Branch { BranchId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Josh 9.3.13
        #region GradBases
        public static readonly Func<int, bool> GradeBases = id =>
        {
            using (var i = new DataRepository<GradeBas>())
            {
                i.Delete(new GradeBas { GradeBaseId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Josh 9.3.13
        #region GradBaseValues
        public static readonly Func<int, bool> GradeBaseValues = id =>
        {
            using (var i = new DataRepository<GradeBaseValue>())
            {
                i.Delete(new GradeBaseValue { GradeBaseValueId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Josh 10.2.13
        #region Positions
        public static readonly Func<int, bool> Positions = id =>
        {
            using (var i = new DataRepository<Position>())
            {
                i.Delete(new Position { PositionId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Josh 10.2.13
        #region EmpStatuses
        public static readonly Func<int, bool> EmpStatuses = id =>
        {
            using (var i = new DataRepository<EmpStatus>())
            {
                i.Delete(new EmpStatus { EmpStatusId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion

        //edited by Josh 10.2.13
        #region Teachers
        public static readonly Func<int, bool> Teachers = id =>
        {
            using (var i = new DataRepository<Teacher>())
            {
                i.Delete(new Teacher { TeacherId = id });
                i.SaveChanges();
                return true;
            }
        };
        #endregion
    }
}
