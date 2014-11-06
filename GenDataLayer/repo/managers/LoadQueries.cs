using GenDataLayer.repo.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenDataLayer.repo.managers
{
    public static class LoadQueries
    {
        //edited by Josh 4.5.13
        #region "SemSY"
        public static readonly Func<List<SemSy>> GetSemSy = () =>
        {
            using (var sem = new DataRepository<SemSy>())
            {
                sem.LazyLoadingEnabled = false;
                return sem.Fetch().OrderByDescending(s => s.SemSyId).ToList();
            }
        };
        #endregion

        //edited by japz 4.11.13
        #region Students

        public static readonly Func<string, Student> IsStudentIdNoExist = idNo =>
        {
            using (var i = new DataRepository<Student>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().FirstOrDefault(c => c.IdNo == idNo);
            }
        };

        public static readonly Func<List<Student>> GetStudents = () =>
        {
            using (var i = new DataRepository<Student>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.LastName).ToList();
            }
        };

        public static List<Student> GetStudentSearch(string criteria)
        {
            using (var s = new DataRepository<Student>())
            {
                return s.Find(s1 => (s1.IdNo == criteria || s1.LastName.ToUpper().StartsWith(criteria)) || (s1.Gender == criteria) || (s1.Citizenship == criteria)).OrderBy(o => o.LastName) .ToList();
            }
        }

        public static List<StudentEntity> GetStudentSearchEntity(string criteria)
        {
            using (var s = new DataRepository<Student>())
            {
                var lResult = s.Find(s1 => s1.IdNo == criteria || s1.LastName.StartsWith(criteria)).ToList().OrderBy(a => a.LastName);
                return lResult.Select(item => new StudentEntity
                    {
                        IdNo = item.IdNo, StudentId = item.StudentId, LastName = item.LastName, FirstName = item.FirstName, MiddleName = item.MiddleName
                    }).ToList();
            }
        }
        #endregion

        #region Year Level
        public static readonly Func<List<YearLevel>> GetYearLevels = () =>
        {
            using (IDataRepository<YearLevel> i = new DataRepository<YearLevel>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.YearLevelName).ToList();
            }
        };

       
        #endregion

        #region Course

        public static readonly Func<List<Cours>> GetCourses = () =>
        {
            using (IDataRepository<Cours> i = new DataRepository<Cours>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.CourseName).ToList();
            }
        };
        #endregion

        #region Scholarship

        public static readonly Func<List<Scholarship>> GetScholarships = () =>
        {
            using (IDataRepository<Scholarship> i = new DataRepository<Scholarship>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.ScholarshipName).ToList();
            }
        };
        #endregion

        #region StudentStatus

        public static readonly Func<List<StudentStatus>> GetStatus = () =>
        {
            using (IDataRepository<StudentStatus> i = new DataRepository<StudentStatus>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.StatusName).ToList();
            }
        };
        #endregion

        //edited by Josh 4.9.13
        #region StudentType

        public static readonly Func<List<StudentType>> GetStudentType = () =>
        {
            using (IDataRepository<StudentType> i = new DataRepository<StudentType>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.StudentTypeName).ToList();
            }
        };
        #endregion

        #region Section

        public static readonly Func<List<Section>> GetSections = () =>
        {
            using (IDataRepository<Section> i = new DataRepository<Section>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.SectionName).ToList();
            }
        };
        #endregion

        #region Major

        public static readonly Func<List<Major>> GetMajors = () =>
        {
            using (IDataRepository<Major> i = new DataRepository<Major>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.MajorName).ToList();
            }
        };
        #endregion

        #region Minor

        public static readonly Func<List<Minor>> GetMinors = () =>
        {
            using (IDataRepository<Minor> i = new DataRepository<Minor>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.MinorName).ToList();
            }
        };

        #endregion

        //edited by Josh 4.5.13
        #region College

        public static readonly Func<List<College>> GetColleges = () =>
        {
            using (IDataRepository<College> i = new DataRepository<College>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.CollegeName).ToList();
            }
        };

        #endregion

        //edited by Josh 4.5.13
        #region Department

        public static readonly Func<List<Department>> GetDepartments = () =>
        {
            using (IDataRepository<Department> i = new DataRepository<Department>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.DepartmentName).ToList();
            }
        };

        #endregion

        //edited by Josh 4.9.13
        #region FeeTitle

        public static readonly Func<List<FeeTitle>> GetFeeTitles = () =>
        {
            using (IDataRepository<FeeTitle> i = new DataRepository<FeeTitle>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.FeeTitleName).ToList();
            }
        };

        #endregion

        //edited by Josh 4.9.13
        #region FeeSubTitle

        public static readonly Func<List<FeeSubTitle>> GetFeeSubTitles = () =>
        {
            using (IDataRepository<FeeSubTitle> i = new DataRepository<FeeSubTitle>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.FeeSubTitleName).ToList();
            }
        };

        #endregion

        //edited by Josh 4.9.13
        #region FeeParticulars

        public static readonly Func<List<FeeParticular>> GetFeeParticulars = () =>
        {
            using (IDataRepository<FeeParticular> i = new DataRepository<FeeParticular>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.Particulars).ToList();
            }
        };

        #endregion

        //edited by Josh 4.9.13
        #region Prospectus
        public static readonly Func<List<Prospectus>> GetProspectuses = () =>
        {
            using (IDataRepository<Prospectus> i = new DataRepository<Prospectus>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.ProspectusName).ToList();
            }
        };
        #endregion

        //edited by Josh 4.9.13
        #region ProspectusSemYr
        public static readonly Func<List<ProspectusSemYr>> GetProspectusSemYr = () =>
        {
            using (IDataRepository<ProspectusSemYr> i = new DataRepository<ProspectusSemYr>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.Sy).ToList();
            }
        };
        #endregion

        //edited by Josh 8.16.13
        #region Users
        public static readonly Func<List<User>> GetUsers = () =>
        {
            using (var i = new DataRepository<User>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.UserName).ToList();
            }
        };
        #endregion

        //edited by Josh 8.16.13
        #region UserLevel
        public static readonly Func<List<UserLevel>> GetUserLevels = () =>
        {
            using (var i = new DataRepository<UserLevel>())
            {
                i.LazyLoadingEnabled = false;
                return i.Fetch().OrderBy(c => c.UserLevelName).ToList();
            }
        };
        #endregion

        //edited by Josh 8.22.13
        #region Province
        public static readonly Func<List<Province>> GetProvinces = () =>
            {
                using (var d = new DataRepository<Province>())
                {
                    d.LazyLoadingEnabled = false;
                    return d.Fetch().OrderBy(o => o.ProvinceName).ToList();
                }
            };
        #endregion

        //edited by Josh 8.22.13
        #region MunCity
        public static readonly Func<List<MunCity>> GetMunCities = () =>
        {
            using (var d = new DataRepository<MunCity>())
            {
                d.LazyLoadingEnabled = false;
                return d.Fetch().OrderBy(o => o.MunCityName).ToList();
            }
        };

        public static readonly Func<Province, List<MunCity>> GetMunCitiesByProvince = p =>
        {
            using (var d = new DataRepository<MunCity>())
            {
                d.LazyLoadingEnabled = false;
                return d.Find(m => m.ProvinceId == p.ProvinceId).OrderBy(o => o.MunCityName).ToList();
            }
        };
        #endregion

        //edited by Josh 8.22.13
        #region Barangay
        public static readonly Func<List<Barangay>> GetBarangays = () =>
        {
            using (var d = new DataRepository<Barangay>())
            {
                d.LazyLoadingEnabled = false;
                return d.Fetch().OrderBy(o => o.BarangayName).ToList();
            }
        };

        public static readonly Func<MunCity, List<Barangay>> GetBarangaysByCity = m =>
        {
            using (var d = new DataRepository<Barangay>())
            {
                d.LazyLoadingEnabled = false;
                return d.Find(b => b.MunCityId == m.MunCityId).OrderBy(o => o.BarangayName).ToList();
            }
        };
        #endregion

        //edited by Josh 8.22.13
        #region StreetHouse
        public static readonly Func<List<StreetHous>> GetStreetHouses = () =>
        {
            using (var d = new DataRepository<StreetHous>())
            {
                d.LazyLoadingEnabled = false;
                return d.Fetch().OrderBy(o => o.StreetName).ToList();
            }
        };

        public static readonly Func<Barangay, List<StreetHous>> GetStreetHousesByBarangay = b =>
        {
            using (var d = new DataRepository<StreetHous>())
            {
                d.LazyLoadingEnabled = false;
                return d.Find(s => s.BarangayId == b.BarangayId).OrderBy(o => o.StreetName).ToList();
            }
        };
        #endregion

        //edited by Josh 9.3.2013
        #region GradeBase
        public static readonly Func<List<GradeBas>> GetGradeBases = () =>
            {
                using (var d = new DataRepository<GradeBas>())
                {
                    d.LazyLoadingEnabled = true;
                    return d.Fetch().OrderBy(o => o.GradeBaseName).ToList();
                }
            };
        #endregion

        //edited by Josh 9.3.2013
        #region GradeBaseValue
        public static readonly Func<List<GradeBaseValue>> GetGradeBaseValues = () =>
        {
            using (var d = new DataRepository<GradeBaseValue>())
            {
                d.LazyLoadingEnabled = true;
                return d.Fetch().OrderBy(o => o.GradeBaseId).ToList();
            }
        };

        public static readonly Func<GradeBas, List<GradeBaseValue>> GetGradeBaseValuesByGradeBaseList = gb =>
        {
            using (var d = new DataRepository<GradeBaseValue>())
            {
                d.LazyLoadingEnabled = false;
                return d.Find(g => g.GradeBaseId == gb.GradeBaseId).OrderBy(o => o.GradeBaseValueArrange).ToList();
            }
        };
        #endregion

        //edited by Josh 9.3.13
        #region Assessements

        public static readonly Func<int, List<Assessment>> GetAssessmentByRegistration = id =>
            {
                using (var e = new ESEntities())
                {
                    var q = from q0 in e.Assessments
                            where (q0.RegistrationId == id)
                            select q0;
                    return q.OrderBy(o => o.FeeParticular.Particulars).ToList();
                }
            };

        #endregion

        //edited by Josh 10.2.13
        #region Positions

        public static readonly Func<List<Position>> GetPositions = () =>
        {
            using (var d = new DataRepository<Position>())
            {
                d.LazyLoadingEnabled = true;
                return d.GetAll().OrderBy(o => o.PostitionName).ToList();
            }
        };

        #endregion

        //edited by Josh 10.2.13
        #region EmpStatuses

        public static readonly Func<List<EmpStatus>> GetEmpStatuses = () =>
        {
            using (var d = new DataRepository<EmpStatus>())
            {
                d.LazyLoadingEnabled = true;
                return d.GetAll().OrderBy(o => o.EmpStatusName).ToList();
            }
        };

        #endregion
    }
}
