using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;

namespace GenDataLayer.repo.managers
{
    public class FinanceQueries
    {
        public static List<StudentLedgerEntity> ListStudentLedgerByRegistration(int iRegistrationId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Assessments
                        join q1a in _e.FeeParticulars on q0.FeeParticularId equals q1a.FeeParticularId
                        join q1 in _e.ReceiptDetails on q0.AssessmentId equals q1.AssessmentId into q01
                        from q01a in q01.DefaultIfEmpty()
                        join q2 in _e.AssessmentLaboratories on q0.AssessmentId equals q2.AssessmentId into q02 from q02a in q02.DefaultIfEmpty()
                        where (q0.RegistrationId == iRegistrationId)
                        group q0 by new
                            {
                                RegistrationId = q0.RegistrationId,
                                ParticularId = q1a.FeeParticularId,
                                ParticularName = q1a.Particulars,
                                ParticularName1 = q02a.LaboratoryName,
                                Valid = q01a.IsValid, q0.AssessmentId,
                                q0.GrossAmount, q0.AddAmount, q0.Less, q0.AddLess
                            }
                        into qSum
                        select new StudentLedgerEntity
                            {
                                RegistrationId = qSum.Key.RegistrationId,
                                ParticularId = qSum.Key.ParticularId,
                                ParticularName = qSum.Key.ParticularName,
                                ParticularName1 = qSum.Key.ParticularName1,
                                Valid = qSum.Key.Valid,
                                AssessmentId = qSum.Key.AssessmentId,
                                AssessedAmount = qSum.Key.GrossAmount,
                                AssessedAdd = qSum.Key.AddAmount,
                                AssessedDeduction = qSum.Key.Less,
                                AssessedDeducAdd = qSum.Key.AddLess,
                                PaidAmount = qSum.Sum(a => a.ReceiptDetails.Sum(b => b.Amount))
                            };

                //string query = ((ObjectQuery) q).ToTraceString();
                //Console.Write(query.ToString());

                var tempList = new List<StudentLedgerEntity>();
                foreach (var item in q)
                {
                    var s = item;
                    if (item.ParticularName1 != null && ((item.ParticularName1 != null) || (item.ParticularName1.Length > 0)))
                    {
                        s.ParticularName = item.ParticularName1;
                    }
                    else
                    {
                        s.ParticularName = item.ParticularName;
                    }

                    tempList.Add(s);

                    //if (tempList.Exists(e => (e.ParticularId == item.ParticularId) && (item.Valid == false)))
                    //{
                    //    //s.AssessedAmount -= item.AssessedAmount;
                    //    //s.AssessedAdd -= item.AssessedAdd;
                    //    //s.AssessedDeduction -= item.AssessedDeduction;
                    //    //s.AssessedDeducAdd -= item.AssessedDeducAdd;
                    //    s.PaidAmount -= item.PaidAmount;
                    //}
                }
                return tempList;
            }
        }

        public static List<StudentLedgerEntity> ListStudentLedgerByRegistrationNotValid(int iRegistrationId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Assessments
                        join q1a in _e.FeeParticulars on q0.FeeParticularId equals q1a.FeeParticularId
                        join q1 in _e.ReceiptDetails on q0.AssessmentId equals q1.AssessmentId into q01
                        from q01a in q01.DefaultIfEmpty()
                        join q2 in _e.AssessmentLaboratories on q0.AssessmentId equals q2.AssessmentId into q02
                        from q02a in q02.DefaultIfEmpty()
                        where (q0.RegistrationId == iRegistrationId)
                        group q0 by new
                        {
                            RegistrationId = q0.RegistrationId,
                            ParticularId = q1a.FeeParticularId,
                            ParticularName = q1a.Particulars,
                            ParticularName1 = q02a.LaboratoryName,
                            Valid = q01a.IsValid,
                            q0.AssessmentId
                        }
                            into qSum
                            select new StudentLedgerEntity
                            {
                                RegistrationId = qSum.Key.RegistrationId,
                                ParticularId = qSum.Key.ParticularId,
                                ParticularName = qSum.Key.ParticularName,
                                ParticularName1 = qSum.Key.ParticularName1,
                                Valid = qSum.Key.Valid,
                                AssessmentId = qSum.Key.AssessmentId,
                                AssessedAmount = qSum.Sum(a => a.GrossAmount),
                                AssessedAdd = qSum.Sum(a => a.AddAmount),
                                AssessedDeduction = qSum.Sum(a => a.Less),
                                AssessedDeducAdd = qSum.Sum(a => a.AddLess),
                                PaidAmount = qSum.Sum(a => a.ReceiptDetails.Sum(b => b.Amount))
                            };

                var tempList = new List<StudentLedgerEntity>();
                foreach (var item in q)
                {
                    var s = item;
                    if (item.ParticularName1 != null && ((item.ParticularName1 != null) || (item.ParticularName1.Length > 0)))
                    {
                        s.ParticularName = item.ParticularName1;
                    }
                    else
                    {
                        s.ParticularName = item.ParticularName;
                    }
                    tempList.Add(s);
                }
                return tempList;
            }
        }

        public static List<AssessmentEntity> ListStudentAssessmentByRegistration(int iRegistrationId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Assessments
                        join q1a in _e.FeeParticulars on q0.FeeParticularId equals q1a.FeeParticularId
                        where (q0.RegistrationId == iRegistrationId)
                        select new AssessmentEntity
                            {
                                RegistrationId = q0.RegistrationId,
                                AssessmentId = q0.AssessmentId,
                                Particulars = q0.FeeParticular.Particulars,
                                Amount = q0.Amount,
                                AddAmount = q0.AddAmount,
                                Less = q0.Less,
                                AddLess = q0.AddLess,
                                GrossAmount = q0.GrossAmount,
                                PercentLess = q0.PercentLess,
                                IsOriginal = q0.IsOriginal
                            };
                return q.ToList();
            }
        }

        public static List<ReceiptDetailEntity> ListStudentPaymentMadeyRegistration(int iRegistrationId)
        {
            using (var _e = new ESEntities())
            {
                var q = from q0 in _e.Assessments
                        join q1 in _e.ReceiptDetails on q0.AssessmentId equals q1.AssessmentId
                        join q1a in _e.FeeParticulars on q1.FeeParticularId equals q1a.FeeParticularId
                        join q2 in _e.Receipts on q1.ReceiptId equals q2.ReceiptId
                        where ((q0.RegistrationId == iRegistrationId) && (q2.IsValid == true))
                        select new ReceiptDetailEntity
                        {
                            ReceiptDetailId = q1.ReceiptDetailId,
                            AssessmentId = q0.AssessmentId,
                            Particulars = q0.FeeParticular.Particulars,
                            PaidAmount = q1.Amount,
                            ReceiptNo = q2.ReceiptNo,
                            ReceiptDate = q2.ReceiptDate,
                            Valid = q1.IsValid
                        };
                return q.ToList();
            }
        }

        //student balances
        public static List<StudentBalanceEntity> ListStudentBalancesBySemSy(SemSyEntity semSy)
        {
            using (var _e = new ESEntities())
            {
                var q = from r in _e.Registrations
                        join c in  _e.Courses on r.CourseId equals c.CourseId
                        join s0 in _e.Sections on r.SectionId equals s0.SectionId
                        join y0 in _e.YearLevels on r.YearLevelId equals y0.YearLevelId
                        join s1 in _e.Scholarships on r.ScholarshipId equals s1.ScholarshipId
                        join q0 in _e.Assessments on r.RegistrationId equals q0.RegistrationId
                        join q1 in _e.ReceiptDetails on q0.AssessmentId equals q1.AssessmentId into q01
                        from q01a in q01.DefaultIfEmpty()
                        where (r.SemSyId == semSy.SemSyId)
                        group q0 by new
                        {
                            RegistrationId = q0.RegistrationId,
                            IdNo = r.Student.IdNo,
                            LastName = r.Student.LastName,
                            FirstName = r.Student.FirstName,
                            MiddleName = r.Student.MiddleName,
                            Course = r.Cours.Abbreviation,
                            Sec = r.Section.SectionName,
                            Yr = r.YearLevel.YearLevelName,
                            Scholar = r.Scholarship.ScholarshipName,
                            ScholarId = r.ScholarshipId
                        }
                            into qSum
                            select new StudentBalanceEntity
                            {
                                IdNo = qSum.Key.IdNo,
                                LastName = qSum.Key.LastName,
                                FirstName = qSum.Key.FirstName,
                                MiddleName = qSum.Key.MiddleName,
                                CourseName = qSum.Key.Course,
                                YearLevelName = qSum.Key.Yr,
                                SectionName = qSum.Key.Sec,
                                ScholarshipName = qSum.Key.Scholar,
                                ScholarshipId = qSum.Key.ScholarId,
                                RegistrationId = qSum.Key.RegistrationId,
                                AssessedAmount = qSum.Sum(a => a.GrossAmount),
                                AssessedAdd = qSum.Sum(a => a.AddAmount),
                                AssessedDeduction = qSum.Sum(a => a.Less),
                                AssessedDeducAdd = qSum.Sum(a => a.AddLess),
                                PaidAmount = qSum.Sum(a => a.ReceiptDetails.Sum(b => b.Amount))
                            };
                return q.OrderBy(o => o.LastName).ToList();
            }
        }

        public static List<PrintReceiptClass> ListReceipts(int iSemSy)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Receipts
                        join q1 in e.Registrations on q0.RegistrationId equals q1.RegistrationId
                        join q2 in e.Students on q1.StudentId equals q2.StudentId
                        join q4 in e.Users on q0.UserId equals q4.UserId
                        where ((q1.SemSyId == iSemSy) && (q0.IsValid == true))
                        select new PrintReceiptClass
                            {
                                ReceiptId = q0.ReceiptId,
                                ReceiptNo = q0.ReceiptNo,
                                ReceiptDate = q0.ReceiptDate,
                                StudentIdNo = q2.IdNo,
                                LastName = q2.LastName,
                                FirstName = q2.FirstName,
                                MiddleName = q2.MiddleName,
                                Valid = q0.IsValid,
                                Collector = q4.UserFullName
                            };
                return q.OrderBy(o => o.ReceiptId).ToList();
            }
        }

        public static List<PrintReceiptClass> ListReceiptsByStudent(int iStudentId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Receipts
                        join q1 in e.Registrations on q0.RegistrationId equals q1.RegistrationId
                        join q2 in e.Students on q1.StudentId equals q2.StudentId
                        join q3 in e.ReceiptDetails on q0.ReceiptId equals q3.ReceiptId
                        join q4 in e.Users on q0.UserId equals q4.UserId
                        where (q2.StudentId == iStudentId)
                        group q3 by new
                        {
                            q0.ReceiptId, q0.ReceiptNo, q0.ReceiptDate, q0.IsValid,
                            StudentIdNo = q2.IdNo, q2.LastName, q2.FirstName, q2.MiddleName,
                            UserName = q4.UserFullName
                        }
                            into qSum
                            select new PrintReceiptClass
                            {
                                ReceiptId = qSum.Key.ReceiptId,
                                ReceiptNo = qSum.Key.ReceiptNo,
                                ReceiptDate = qSum.Key.ReceiptDate,
                                StudentIdNo = qSum.Key.StudentIdNo,
                                LastName = qSum.Key.LastName,
                                FirstName = qSum.Key.FirstName,
                                MiddleName = qSum.Key.MiddleName,
                                Valid = qSum.Key.IsValid,
                                Collector = qSum.Key.UserName,
                                Amount = qSum.Sum(r => r.Amount)
                            };
                return q.OrderBy(o => o.ReceiptNo).ToList();
            }
        }

        public static List<PrintReceiptClass> ListReceiptsWithAmount(int iSemSy)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.Receipts
                        join q1 in e.Registrations on q0.RegistrationId equals q1.RegistrationId
                        join q2 in e.Students on q1.StudentId equals q2.StudentId
                        join q3 in e.ReceiptDetails on q0.ReceiptId equals q3.ReceiptId
                        join q4 in e.Users on q0.UserId equals q4.UserId
                        where ((q1.SemSyId == iSemSy) && (q0.IsValid == true))
                        group q3 by new
                            {
                                ReceiptId = q0.ReceiptId,
                                ReceiptNo = q0.ReceiptNo,
                                ReceiptDate  = q0.ReceiptDate,
                                IsValid = q0.IsValid,
                                StudentIdNo = q2.IdNo,
                                LastName = q2.LastName,
                                FirstName = q2.FirstName,
                                MiddleName = q2.MiddleName,
                                UserName = q4.UserFullName
                            }
                        into qSum
                        select new PrintReceiptClass
                            {
                                ReceiptId = qSum.Key.ReceiptId,
                                ReceiptNo = qSum.Key.ReceiptNo,
                                ReceiptDate = qSum.Key.ReceiptDate,
                                StudentIdNo = qSum.Key.StudentIdNo,
                                LastName = qSum.Key.LastName,
                                FirstName = qSum.Key.FirstName,
                                MiddleName = qSum.Key.MiddleName,
                                Valid = qSum.Key.IsValid,
                                Collector = qSum.Key.UserName,
                                Amount = qSum.Sum(r => r.Amount)
                            };
                return q.OrderBy(o => o.ReceiptNo).ToList();
            }
        }

        public static List<Assessment> ListAssessmentNullGross()
        {
            using (var d = new DataRepository<Assessment>())
            {
                d.LazyLoadingEnabled = true;
                return d.Find(f => f.GrossAmount == null).ToList();
            }
        }
    }
}
