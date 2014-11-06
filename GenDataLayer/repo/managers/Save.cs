using System;
using System.Data;

namespace GenDataLayer.repo.managers
{
    public static class Save
    {
        #region Student
        public static readonly Func<Student, int> Student = o =>
            {
                var s = new Student
                    {
                        StudentId = o.StudentId,
                        IdNo = o.IdNo,
                        LastName = o.LastName,
                        FirstName = o.FirstName,
                        MiddleName = o.MiddleName,
                        Extension = o.Extension,
                        Gender = o.Gender,
                        BirthDate = o.BirthDate,
                        CivilStatus = o.CivilStatus,
                        Citizenship = o.Citizenship,
                        ProvinceId = o.ProvinceId,
                        MunCityId = o.MunCityId,
                        BarangayId = o.BarangayId,
                        StreetHouseId = o.StreetHouseId,
                        PlaceOfBirth = o.PlaceOfBirth,
                        ParentsGuardian = o.ParentsGuardian,
                        Religion = o.Religion,
                        Tribe = o.Tribe,
                        ProvinceId1 = o.ProvinceId1,
                        MunCityId1 = o.MunCityId1,
                        BarangayId1 = o.BarangayId1,
                        StreetHouseId1 = o.StreetHouseId1,
                        MothersName = o.MothersName,
                        FathersName = o.FathersName,
                        MothersAddress = o.MothersAddress,
                        FathersAddress = o.FathersAddress,
                        MothersOccupation = o.MothersOccupation,
                        FathersOccuapation = o.FathersOccuapation,
                        CampusResidence = o.CampusResidence,
                        GuardianAddress = o.GuardianAddress,
                        GuardianOccupation = o.GuardianOccupation,
                        ContactNo1 = o.ContactNo1,
                        ContactNo2 = o.ContactNo2,
                        ContactNo3 = o.ContactNo3
                    };

                using (IDataRepository<Student> i = new DataRepository<Student>())
                {
                    if (s.StudentId > 0)
                        i.Update(s);
                    else
                        i.Add(s);
                    i.SaveChanges();
                }
                return s.StudentId;

            };
        #endregion

        public static readonly Func<College, int> CollegeTest = delegate(College o)
        {
            int i;
            using (var con = new ESEntities())
            {
                if (o.CollegeId > 0)
                {
                    con.Colleges.Attach(o);
                    con.ObjectStateManager.ChangeObjectState(o, EntityState.Modified);
                }
                else
                    con.Colleges.AddObject(o);
                con.SaveChanges();
                i = o.CollegeId;
            }
            return i;
        };

        //edited by Josh 4.9.13
        #region College
        public static readonly Func<College, int> College = o =>
            {
                var o1 = new College()
                {
                    CollegeId = o.CollegeId,
                    CollegeName = o.CollegeName,
                    CollegeDescription = o.CollegeDescription,
                    BranchId = o.BranchId
                };
                using (IDataRepository<College> i = new DataRepository<College>())
                {
                    if (o1.CollegeId > 0)
                        i.Update(o1);
                    else
                        i.Add(o1);
                    i.SaveChanges();
                }
                return o1.CollegeId;
            };
        #endregion

        //edited by Josh 4.9.13
        #region Department
        public static readonly Func<Department, int> Department = o =>
        {
            var d = new Department()
            {
                DepartmentId = o.DepartmentId,
                DepartmentName = o.DepartmentName,
                DepartmentDescription = o.DepartmentDescription,
                CollegeId = o.CollegeId
            };
            using (IDataRepository<Department> i = new DataRepository<Department>())
            {
                if (d.DepartmentId > 0)
                    i.Update(d);
                else
                    i.Add(d);
                i.SaveChanges();
            }
            return d.DepartmentId;
        };
        #endregion

        //edited by Josh 4.9.13 - Josh
        #region Course
        public static readonly Func<Cours, int> Cours = o =>
        {
            var c = new Cours
                        {
                            CourseId = o.CourseId,
                            CourseName = o.CourseName,
                            Abbreviation = o.Abbreviation,
                            Duration = o.Duration,
                            DepartmentId = o.DepartmentId
                        };
            using (IDataRepository<Cours> i = new DataRepository<Cours>())
            {
                if (o.CourseId > 0)
                    i.Update(c);
                else
                    i.Add(c);
                i.SaveChanges();
            }
            return c.CourseId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region FeeTitle
        public static readonly Func<FeeTitle, int> FeeTitle = o =>
        {
            var f = new FeeTitle()
                        {
                            FeeTitleId = o.FeeTitleId,
                            FeeTitleName = o.FeeTitleName,
                            FeeTitleDescription = o.FeeTitleDescription
                        };
            
            using (IDataRepository<FeeTitle> i = new DataRepository<FeeTitle>())
            {
                if (o.FeeTitleId > 0)
                    i.Update(f);
                else
                    i.Add(f);
                i.SaveChanges();
            }
            return f.FeeTitleId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region FeeSubTitle
        public static readonly Func<FeeSubTitle, int> FeeSubTitle = o =>
        {
            var f = new FeeSubTitle()
            {
                FeeTitleId = o.FeeTitleId,
                FeeSubTitleId = o.FeeSubTitleId,
                FeeSubTitleName = o.FeeSubTitleName,
                FeeSubTitleDescription = o.FeeSubTitleDescription
            };

            using (IDataRepository<FeeSubTitle> i = new DataRepository<FeeSubTitle>())
            {
                if (o.FeeSubTitleId > 0)
                    i.Update(f);
                else
                    i.Add(f);
                i.SaveChanges();
            }
            return f.FeeSubTitleId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region FeeParticular
        public static readonly Func<FeeParticular, int> FeeParticular = o =>
        {
            var f = new FeeParticular
                        {
                            FeeSubTitleId = o.FeeSubTitleId,
                            FeeParticularId = o.FeeParticularId,
                            Particulars = o.Particulars,
                            Descriptions = o.Descriptions,
                            IsTuition = o.IsTuition,
                            FundId = o.FundId
                        };
            using (IDataRepository<FeeParticular> i = new DataRepository<FeeParticular>())
            {
                if (o.FeeParticularId > 0)
                    i.Update(f);
                else
                    i.Add(f);
                i.SaveChanges();
            }
            return f.FeeParticularId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region SemSy
        public static readonly Func<SemSy, int> SemSy = o =>
        {
            var s = new SemSy
                        {
                            SemSyId = o.SemSyId,
                            Semester = o.Semester,
                            SemesterName = o.SemesterName,
                            Sy = o.Sy,
                            Active = o.Active
                        };
            using (IDataRepository<SemSy> i = new DataRepository<SemSy>())
            {
                if (o.SemSyId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
            }
            return s.SemSyId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region YearLevel
        public static readonly Func<YearLevel, int> YearLevels = o =>
        {
            var y = new YearLevel
                        {
                            YearLevelId = o.YearLevelId,
                            YearLevelName = o.YearLevelName
                        };
            using (IDataRepository<YearLevel> i = new DataRepository<YearLevel>())
            {
                if (o.YearLevelId > 0)
                    i.Update(y);
                else
                    i.Add(y);
                i.SaveChanges();
            }
            return y.YearLevelId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region Section
        public static readonly Func<Section, int> Sections = o =>
        {
            var s = new Section
                        {
                            SectionId = o.SectionId,
                            SectionName = o.SectionName
                        };
            using (IDataRepository<Section> i = new DataRepository<Section>())
            {
                if (o.SectionId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
            }
            return s.SectionId;
        };
        #endregion

        //edited by Josh 4.9.13
        #region Assessment
        public static readonly Func<Assessment, int> Assessment = o =>
        {
            using (var i = new DataRepository<Assessment>())
            {
                var o1 = new Assessment
                    {
                        AssessmentId = o.AssessmentId,
                        Amount = o.Amount,
                        AddAmount = o.AddAmount,
                        Less = o.Less,
                        AddLess = o.AddLess,
                        PercentLess = o.PercentLess,
                        NetAmount = o.NetAmount,
                        GrossAmount = o.GrossAmount,
                        IsOriginal = o.IsOriginal,
                        FeeParticularId = o.FeeParticularId,
                        RegistrationId = o.RegistrationId
                    };

                if (o.AssessmentId > 0)
                    i.Update(o1);
                else
                    i.Add(o1);
                i.SaveChanges();

                return o1.AssessmentId;
            }
        };
        #endregion

        //edited by Faith 4.9.13
        #region Barangays
        public static readonly Func<Barangay, int> Barangays = o =>
            {
                var b = new Barangay
                    {
                        BarangayId = o.BarangayId,
                        BarangayName = o.BarangayName,
                        MunCityId = o.MunCityId
                    };
            using (IDataRepository<Barangay> i = new DataRepository<Barangay>())
            {
                if (o.BarangayId > 0)
                    i.Update(b);
                else
                    i.Add(b);
                i.SaveChanges();
            }
            return b.BarangayId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region CouresMajor
        public static readonly Func<CourseMajor, int> CouresMajor = o =>
        {
            using (IDataRepository<CourseMajor> i = new DataRepository<CourseMajor>())
            {
                if (o.CourseMajorId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.CourseMajorId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region CouresMinor
        public static readonly Func<CourseMinor, int> CouresMinor = o =>
        {
            using (IDataRepository<CourseMinor> i = new DataRepository<CourseMinor>())
            {
                if (o.CourseMinorId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.CourseMinorId;
        };
        #endregion

        //edited by Faith 4.9.13 - Josh
        #region CourseSecSchedules
        public static readonly Func<CourseSecSchedule, int> CourseSecSchedules = o =>
        {
            var c = new CourseSecSchedule
                        {
                            CourseSecScheduleId = o.CourseSecScheduleId,
                            YearLevelId = o.YearLevelId,
                            CourseId = o.CourseId,
                            SectionId = o.SectionId,
                            Note = o.Note,
                            SemSyId = o.SemSyId,
                            IsActive = o.IsActive
                        };
            using (IDataRepository<CourseSecSchedule> i = new DataRepository<CourseSecSchedule>())
            {
                if (o.CourseSecScheduleId > 0)
                    i.Update(c);
                else
                    i.Add(c);
                i.SaveChanges();
            }
            return c.CourseSecScheduleId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region LaboratoryFees
        public static readonly Func<LaboratoryFee, int> LaboratoryFees = o =>
        {
            using (IDataRepository<LaboratoryFee> i = new DataRepository<LaboratoryFee>())
            {
                if (o.LaboratoryFeeId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.LaboratoryFeeId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region LabSubjects
        public static readonly Func<LabSubject, int> LabSubjects = o =>
        {
            using (IDataRepository<LabSubject> i = new DataRepository<LabSubject>())
            {
                if (o.LabSubjectId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.LabSubjectId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region DepartmentSubjects
        public static readonly Func<DepartmentSubject, int> DepartmentSubjects = o =>
        {
            var d = new DepartmentSubject
                        {
                            DepartmentId = o.DepartmentId,
                            DepartmentSubjectId = o.DepartmentSubjectId,
                            Note = o.Note,
                            DateAdded = o.DateAdded,
                            SubjectId = o.SubjectId
                        };
            using (IDataRepository<DepartmentSubject> i = new DataRepository<DepartmentSubject>())
            {
                if (o.DepartmentSubjectId > 0)
                    i.Update(d);
                else
                    i.Add(d);
                i.SaveChanges();
            }
            return d.DepartmentSubjectId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region Majors
        public static readonly Func<Major, int> Majors = o =>
        {
            using (IDataRepository<Major> i = new DataRepository<Major>())
            {
                if (o.MajorId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.MajorId;
        };
        #endregion
        //edited by Faith 4.9.13
        #region Minors
        public static readonly Func<Minor, int> Minors = o =>
        {
            using (IDataRepository<Minor> i = new DataRepository<Minor>())
            {
                if (o.MinorId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.MinorId;
        };
        #endregion
        //edited by Faith 4.9.13
        #region MunCitys
        public static readonly Func<MunCity, int> MinMunCitys = o =>
            {
                var m = new MunCity
                    {
                        MunCityId = o.MunCityId,
                        MunCityName = o.MunCityName,
                        ProvinceId = o.ProvinceId
                    };
            using (IDataRepository<MunCity> i = new DataRepository<MunCity>())
            {
                if (o.MunCityId > 0)
                    i.Update(m);
                else
                    i.Add(m);
                i.SaveChanges();
            }
            return m.MunCityId;
        };
        #endregion
        //edited by Faith 4.9.13
        #region PaidParticulars
        public static readonly Func<PaidParticular, int> PaidParticulars = o =>
        {
            using (IDataRepository<PaidParticular> i = new DataRepository<PaidParticular>())
            {
                if (o.PaidParicularId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.PaidParicularId;
        };
        #endregion
        //edited by Faith 4.9.13
        #region PreRequisites
        public static readonly Func<PreRequisite, int> PreRequisites = o =>
        {
            using (IDataRepository<PreRequisite> i = new DataRepository<PreRequisite>())
            {
                if (o.PreRequisiteId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.PreRequisiteId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region PresetFees
        public static readonly Func<PresetFee, int> PresetFees = o =>
        {
            var p = new PresetFee
                        {
                            PresetFeeId = o.PresetFeeId,
                            DateAdded = o.DateAdded,
                            ScheduleFeeId = o.ScheduleFeeId,
                            SetPresetFeeId = o.SetPresetFeeId
                        };
            using (IDataRepository<PresetFee> i = new DataRepository<PresetFee>())
            {
                if (o.PresetFeeId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.PresetFeeId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region Prospectuss
        public static readonly Func<Prospectus, int> Prospectuss = o =>
        {
            var p = new Prospectus
                        {
                            ProspectusId = o.ProspectusId,
                            ProspectusName = o.ProspectusName,
                            ProspectusDescription = o.ProspectusDescription,
                            Curriculum = o.Curriculum,
                            CourseId = o.CourseId
                        };
            using (IDataRepository<Prospectus> i = new DataRepository<Prospectus>())
            {
                if (o.ProspectusId > 0)
                    i.Update(p);
                else
                    i.Add(p);
                i.SaveChanges();
            }
            return p.ProspectusId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region ProspectusSemYrs
        public static readonly Func<ProspectusSemYr, int> ProspectusSemYrs = o =>
        {
            var p = new ProspectusSemYr
                        {
                            ProspectusSemYrId = o.ProspectusSemYrId,
                            Semester = o.Semester,
                            SemesterName = o.SemesterName,
                            Sy = o.Sy,
                            Note = o.Note,
                            ProspectusId = o.ProspectusId
                        };
            using (IDataRepository<ProspectusSemYr> i = new DataRepository<ProspectusSemYr>())
            {
                if (o.ProspectusSemYrId > 0)
                    i.Update(p);
                else
                    i.Add(p);
                i.SaveChanges();
            }
            return p.ProspectusSemYrId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region ProspectusSubjects
        public static readonly Func<ProspectusSubject, int> ProspectusSubjects = o =>
        {
            var p = new ProspectusSubject
                         {
                             ProspectusSemYrId = o.ProspectusSemYrId,
                             ProspectusSubjectId = o.ProspectusSubjectId,
                             SubjectId = o.SubjectId,
                             IsCounted = o.IsCounted
                         };
            using (IDataRepository<ProspectusSubject> i = new DataRepository<ProspectusSubject>())
            {
                if (o.ProspectusSubjectId > 0)
                    i.Update(p);
                else
                    i.Add(p);
                i.SaveChanges();
            }
            return p.ProspectusSubjectId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region Provinces
        public static readonly Func<Province, int> Provinces = o =>
            {
                var p = new Province
                    {
                        ProvinceId = o.ProvinceId,
                        ProvinceName = o.ProvinceName
                    };
            using (IDataRepository<Province> i = new DataRepository<Province>())
            {
                if (o.ProvinceId > 0)
                    i.Update(p);
                else
                    i.Add(p);
                i.SaveChanges();
            }
            return p.ProvinceId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region Receipts
        public static readonly Func<Receipt, int> Receipts = o =>
        {
            using (IDataRepository<Receipt> i = new DataRepository<Receipt>())
            {
                var r = new Receipt
                    {
                        ReceiptId = o.ReceiptId,
                        ReceiptNo = o.ReceiptNo,
                        ReceiptDate = o.ReceiptDate,
                        TenderedAmount = o.TenderedAmount,
                        PayDate = o.PayDate,
                        PayTime = o.PayTime,
                        IsValid = o.IsValid,
                        UserId = o.UserId,
                        RegistrationId = o.RegistrationId
                    };

                if (o.ReceiptId > 0)
                    i.Update(r);
                else
                    i.Add(r);
                
                i.SaveChanges();

                return r.ReceiptId;
            }
            
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region RegisteredSchedules
        public static readonly Func<RegisteredSchedule, int> RegisteredSchedules = o =>
        {
            var r = new RegisteredSchedule
                    {
                        RegisteredScheduleId = o.RegisteredScheduleId,
                        RegistrationId = o.RegistrationId,
                        ScheduleId = o.ScheduleId,
                        ScheduleCode = o.ScheduleCode,
                        IsAdded = o.IsAdded,
                        IsRegular = o.IsRegular,
                        IsDropped = o.IsDropped,
                        MidtermGrade = o.MidtermGrade,
                        FinalGrade = o.FinalGrade,
                        ReGrade = o.ReGrade,
                        FirstGrading = o.FirstGrading,
                        SecondGrading = o.SecondGrading,
                        ThirdGrading = o.ThirdGrading,
                        FourthGrading = o.FourthGrading,
                        FifthGrading = o.FifthGrading,
                        SixthGrading = o.SixthGrading,
                        Remark = o.Remark,
                        IsPosted = o.IsPosted,
                        IsPostEdited = o.IsPostEdited,
                        PostedDate = o.PostedDate,
                        PostEditedDate = o.PostEditedDate,
                        EditedBy = o.EditedBy
                    };
            using (var i = new DataRepository<RegisteredSchedule>())
            {
                if (o.RegisteredScheduleId > 0)
                    i.Update(r);
                else
                    i.Add(r);
                i.SaveChanges();
            }
            return r.RegisteredScheduleId;
        };
        #endregion
         
        //edited by Faith 4.9.13
        #region Registrations
        public static readonly Func<Registration, int> Registrations = o =>
        {
            using (IDataRepository<Registration> i = new DataRepository<Registration>())
            {
                if (o.RegistrationId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.RegistrationId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region Rooms
        public static readonly Func<Room, int> Rooms = o =>
        {
            var r = new Room
                        {
                            RoomId = o.RoomId,
                            RoomNo = o.RoomNo,
                            RoomDescription = o.RoomDescription,
                            Capacity = o.Capacity,
                            CollegeId = o.CollegeId
                        };
            using (IDataRepository<Room> i = new DataRepository<Room>())
            {
                if (o.RoomId > 0)
                    i.Update(r);
                else
                    i.Add(r);
                i.SaveChanges();
            }
            return r.RoomId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region ScheduleDetails
        public static readonly Func<ScheduleDetail, int> ScheduleDetails = o =>
        {
            using (IDataRepository<ScheduleDetail> i = new DataRepository<ScheduleDetail>())
            {
                if (o.ScheduleDetailId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.ScheduleDetailId;
        };
        #endregion

        //edited by Faith 4.9.13 - Josh
        #region ScheduleFees
        public static readonly Func<ScheduleFee, int> ScheduleFees = o =>
        {
            using (IDataRepository<ScheduleFee> i = new DataRepository<ScheduleFee>())
            {
                var s = new ScheduleFee
                            {
                                ScheduleFeeId = o.ScheduleFeeId,
                                Amount = o.Amount,
                                IsActive = o.IsActive,
                                DateAdded = o.DateAdded,
                                FeeParticularId = o.FeeParticularId,
                                ScheduleFeeNameId = o.ScheduleFeeNameId
                            };
                if (o.ScheduleFeeId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();

                return s.ScheduleFeeId;
            }
            
        };
        #endregion

        //edited by Faith 4.9.13 - Josh
        #region ScheduleFeeName
        public static readonly Func<ScheduleFeeName, int> ScheduleFeeNames = o =>
        {
            using (IDataRepository<ScheduleFeeName> i = new DataRepository<ScheduleFeeName>())
            {
                var s = new ScheduleFeeName
                            {
                                ScheduleFeeNameId = o.ScheduleFeeNameId,
                                ScheduleName = o.ScheduleName,
                                Description = o.Description
                            };
                if (o.ScheduleFeeNameId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
                return s.ScheduleFeeNameId;
            }
        };
        #endregion

        //edited by Faith 4.9.13
        #region Schedules
        public static readonly Func<Schedule, int> Schedules = o =>
        {
            using (IDataRepository<Schedule> i = new DataRepository<Schedule>())
            {
                var s = new Schedule
                    {
                        ScheduleId = o.ScheduleId,
                        ScheduleCode = o.ScheduleCode,
                        StudentLimit = o.StudentLimit,
                        StudentAdded = o.StudentAdded,
                        IsDeleted = o.IsDeleted,
                        IsRequested = o.IsRequested,
                        IsActive = o.IsActive,
                        ProspectusSubjectId = o.ProspectusSubjectId,
                        CourseSecScheduleId = o.CourseSecScheduleId
                    };
                if (o.ScheduleId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
                return s.ScheduleId;
            }
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region ScholarshipFees
        public static readonly Func<ScholarshipFee, int> ScholarshipFees = o =>
        {
            using (IDataRepository<ScholarshipFee> i = new DataRepository<ScholarshipFee>())
            {
                if (o.ScholarshipFeeId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.ScholarshipFeeId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region Scholarships
        public static readonly Func<Scholarship, int> Scholarships = o =>
        {
            using (IDataRepository<Scholarship> i = new DataRepository<Scholarship>())
            {
                if (o.ScholarshipId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.ScholarshipId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region SetPresetFees
        public static readonly Func<SetPresetFee, int> SetPresetFees = o =>
        {
            using (IDataRepository<SetPresetFee> i = new DataRepository<SetPresetFee>())
            {
                var s = new SetPresetFee
                            {
                                SetPresetFeeId = o.SetPresetFeeId,
                                SemSyId = o.SemSyId,
                                CourseId = o.CourseId,
                                Note = o.Note,
                                YearLevelId = o.YearLevelId
                            };
                if (o.SetPresetFeeId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();

                return s.SetPresetFeeId;
            }
        };
        #endregion

        //edited by Faith 4.9.13
        #region SetScheduleFees
        public static readonly Func<SetScheduleFee, int> SetScheduleFees = o =>
        {
            using (IDataRepository<SetScheduleFee> i = new DataRepository<SetScheduleFee>())
            {
                if (o.SetScheduleFeeId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.SetScheduleFeeId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region StreetHouss
        public static readonly Func<StreetHous, int> StreetHouss = o =>
            {
                var s = new StreetHous
                    {
                        StreetHouseId = o.StreetHouseId,
                        StreetName = o.StreetName,
                        HouseNumber = o.HouseNumber,
                        BarangayId = o.BarangayId
                    };
                using (IDataRepository<StreetHous> i = new DataRepository<StreetHous>())
                {
                    if (o.StreetHouseId > 0)
                        i.Update(o);
                    else
                        i.Add(o);
                    i.SaveChanges();
                }
                return o.StreetHouseId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region StudentPictures
        public static readonly Func<StudentPicture, int> StudentPictures = o =>
        {
            using (IDataRepository<StudentPicture> i = new DataRepository<StudentPicture>())
            {
                if (o.StudentPictureId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.StudentPictureId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region StudentStatuss
        public static readonly Func<StudentStatus, int> StudentStatuss = o =>
        {
            var s = new StudentStatus
                        {
                            StudentStatusId = o.StudentStatusId,
                            StatusName = o.StatusName,
                            StatusDescription = o.StatusDescription
                        };
            using (IDataRepository<StudentStatus> i = new DataRepository<StudentStatus>())
            {
                if (o.StudentStatusId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
            }
            return s.StudentStatusId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region StudentTypes
        public static readonly Func<StudentType, int> StudentTypes = o =>
        {
            var s = new StudentType
                        {
                            StudenTypeId = o.StudenTypeId,
                            StudentTypeName = o.StudentTypeName,
                            StudentTypeDescription = o.StudentTypeDescription
                        };
            using (IDataRepository<StudentType> i = new DataRepository<StudentType>())
            {
                if (o.StudenTypeId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
            }
            return s.StudenTypeId;
        };
        #endregion
        
        //edited by Faith 4.9.13 - Josh
        #region Subjects
        public static readonly Func<Subject, int> Subjects = o =>
        {
            var s = new Subject
                        {
                            SubjectId = o.SubjectId,
                            SubjectNo = o.SubjectNo,
                            SubjectDescriptiveTitle = o.SubjectDescriptiveTitle,
                            SubjectLecUnit = o.SubjectLecUnit,
                            SubjectLabUnit = o.SubjectLabUnit,
                            SubjectCreUnit = o.SubjectCreUnit,
                            IsCreditable = o.IsCreditable,
                            IsActive = o.IsActive,
                            IsDeleted = o.IsDeleted
                        };
            using (IDataRepository<Subject> i = new DataRepository<Subject>())
            {
                if (o.SubjectId > 0)
                    i.Update(s);
                else
                    i.Add(s);
                i.SaveChanges();
            }
            return s.SubjectId;
        };
        #endregion

        //edited by Faith 4.9.13
        #region UserAccesss
        public static readonly Func<UserAccess, int> UserAccesss = o =>
        {
            using (IDataRepository<UserAccess> i = new DataRepository<UserAccess>())
            {
                if (o.UserAccessId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.UserAccessId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region UserLevels
        public static readonly Func<UserLevel, int> UserLevels = o =>
        {
            using (IDataRepository<UserLevel> i = new DataRepository<UserLevel>())
            {
                if (o.UserLevelId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.UserLevelId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region UserRestrictions
        public static readonly Func<UserRestriction, int> UserRestrictions = o =>
        {
            using (IDataRepository<UserRestriction> i = new DataRepository<UserRestriction>())
            {
                if (o.UserRestrictionId > 0)
                    i.Update(o);
                else
                    i.Add(o);
                i.SaveChanges();
            }
            return o.UserRestrictionId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region Users
        public static readonly Func<User, int> Users = o =>
            {
                var u = new User
                    {
                        UserId = o.UserId,
                        UserName = o.UserName,
                        UserFullName = o.UserFullName,
                        UserLevelId = o.UserLevelId,
                        Password = o.Password,
                        IsActive = o.IsActive
                    };
            using (var i = new DataRepository<User>())
            {
                if (o.UserId > 0)
                    i.Update(u);
                else
                    i.Add(u);
                i.SaveChanges();
            }
            return u.UserId;
        };
        #endregion
        
        //edited by Faith 4.9.13
        #region Branch
        public static readonly Func<Branch, int> Branches = o =>
        {
            using (var i = new DataRepository<Branch>())
            {
                var branch = new Branch
                    {
                        BranchId = o.BranchId,
                        BranchName = o.BranchName,
                        BranchAddress = o.BranchAddress,
                        BranchShortAddress = o.BranchShortAddress,
                        BranchShortName = o.BranchShortName,
                        BranchActive = o.BranchActive
                    };
                if (o.BranchId > 0)
                    i.Update(branch);
                else
                    i.Add(branch);
                i.SaveChanges();
                return branch.BranchId;
            }
        };
        #endregion

        //edited by josh 8.30.13
        #region GradingPeriod
        public static readonly Func<GradingPeriod, int> GradingPeriods = o =>
        {
            using (var g = new DataRepository<GradingPeriod>())
            {
                var gradingPeriod = new GradingPeriod
                {
                    GradingLabelId = o.GradingLabelId,
                    FirstGrading = o.FirstGrading,
                    FirstGradingActive = o.FirstGradingActive,
                    SecondGrading = o.SecondGrading,
                    SecondGradingActive = o.SecondGradingActive,
                    ThirdGrading = o.ThirdGrading,
                    ThirdGradingActive = o.ThirdGradingActive,
                    FourthGrading = o.FourthGrading,
                    FourthGradingActive = o.FourthGradingActive,
                    FifthGrading = o.FifthGrading,
                    FifthGradingActive = o.FifthGradingActive,
                    SixthGrading = o.SixthGrading,
                    SixthGradingActive = o.SixthGradingActive
                };
                if (o.GradingLabelId > 0)
                    g.Update(gradingPeriod);
                else
                    g.Add(gradingPeriod);
                g.SaveChanges();
                return gradingPeriod.GradingLabelId;
            }
        };
        #endregion

        //edited by josh 8.30.13
        #region GradeBase
        public static readonly Func<GradeBas, int> GradeBases = o =>
        {
            using (var d = new DataRepository<GradeBas>())
            {
                var o1 = new GradeBas
                {
                    GradeBaseId = o.GradeBaseId,
                    GradeBaseName = o.GradeBaseName,
                    GradeBaseDescription = o.GradeBaseDescription,
                    GradeBaseActive = o.GradeBaseActive,
                    GradeBaseDefault = o.GradeBaseDefault
                };
                if (o.GradeBaseId > 0)
                    d.Update(o1);
                else
                    d.Add(o1);
                d.SaveChanges();
                return o1.GradeBaseId;
            }
        };
        #endregion

        //edited by josh 8.30.13
        #region GradeBaseValue
        public static readonly Func<GradeBaseValue, int> GradeBaseValues = o =>
        {
            using (var d = new DataRepository<GradeBaseValue>())
            {
                var o1 = new GradeBaseValue
                {
                    GradeBaseId = o.GradeBaseId,
                    GradeBaseValueId = o.GradeBaseValueId,
                    GradeBaseValueFrom = o.GradeBaseValueFrom,
                    GradeBaseValueTo = o.GradeBaseValueTo,
                    GradeBaseValueEqui = o.GradeBaseValueEqui,
                    GradeBaseValueRemark = o.GradeBaseValueRemark,
                    GradeBaseValueArrange = o.GradeBaseValueArrange
                };
                if (o.GradeBaseValueId > 0)
                    d.Update(o1);
                else
                    d.Add(o1);
                d.SaveChanges();
                return o1.GradeBaseValueId;
            }
        };
        #endregion

        //edited by josh 9.18.13
        #region Position
        public static readonly Func<Position, int> Positions = o =>
        {
            using (var d = new DataRepository<Position>())
            {
                var p = new Position
                    {
                        PositionId = o.PositionId,
                        PostitionName = o.PostitionName,
                        Description = o.Description
                    };

                if (o.PositionId > 0)
                    d.Update(p);
                else
                    d.Add(p);
                d.SaveChanges();
                return p.PositionId;
            }
        };
        #endregion

        //edited by josh 9.18.13
        #region EmpStatus
        public static readonly Func<EmpStatus, int> EmpStatuses = o =>
        {
            using (var d = new DataRepository<EmpStatus>())
            {
                var e = new EmpStatus
                {
                    EmpStatusId = o.EmpStatusId,
                    EmpStatusName = o.EmpStatusName,
                    Description = o.Description
                };

                if (o.EmpStatusId > 0)
                    d.Update(e);
                else
                    d.Add(e);
                d.SaveChanges();
                return e.EmpStatusId;
            }
        };
        #endregion

        //edited by josh 9.18.13
        #region Teachers
        public static readonly Func<Teacher, int> Teachers = o =>
        {
            using (var d = new DataRepository<Teacher>())
            {
                var o1 = new Teacher
                {
                    TeacherId = o.TeacherId,
                    LastName = o.LastName,
                    FirstName = o.FirstName,
                    MiddleName = o.MiddleName,
                    Sex = o.Sex,
                    BirthDate = o.BirthDate,
                    CivilStatus = o.CivilStatus,
                    PositionId = o.PositionId,
                    EmpStatusId = o.EmpStatusId,
                    TeacherNo = o.TeacherNo,
                    IsActive = o.IsActive,
                    Picture = o.Picture
                };

                if (o.TeacherId > 0)
                    d.Update(o1);
                else
                    d.Add(o1);
                d.SaveChanges();
                return o1.TeacherId;
            }
        };
        #endregion

        #region AssessmentLaboratory
        public static readonly Func<AssessmentLaboratory, int> AssessmentLaboratory = o =>
        {
            using (var d = new DataRepository<AssessmentLaboratory>())
            {
                var o1 = new AssessmentLaboratory
                {
                    AssessmentLaboratoryId = o.AssessmentLaboratoryId,
                    AssessmentId = o.AssessmentId,
                    LaboratoryFeeId = o.LaboratoryFeeId,
                    SubjectId = o.SubjectId,
                    LaboratoryName = o.LaboratoryName,
                    Amount = o.Amount
                };

                if (o.AssessmentLaboratoryId > 0)
                    d.Update(o1);
                else
                    d.Add(o1);
                d.SaveChanges();
                return o1.AssessmentLaboratoryId;
            }
        };
        #endregion
    }
}