using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenDataLayer.repo.entities;

namespace GenDataLayer.repo.managers.man
{
    public class AssessmentManager
    {
        public static List<PresetFeeEntity> GetPreFees(int iSemSyId, int iCourseId, int iYearLevelId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.PresetFees
                        join q1 in e.SetPresetFees on q0.SetPresetFeeId equals q1.SetPresetFeeId
                        join q2 in e.ScheduleFees on q0.ScheduleFeeId equals q2.ScheduleFeeId
                        join q3 in e.FeeParticulars on q2.FeeParticularId equals q3.FeeParticularId
                        where
                            ((q1.SemSyId == iSemSyId) && (q1.CourseId == iCourseId) && (q1.YearLevelId == iYearLevelId))
                             
                        select new PresetFeeEntity
                            {
                                PresetFeeId = q0.PresetFeeId,
                                Amount = q2.Amount,
                                FeeParticularId = q3.FeeParticularId,
                                Particular = q3.Particulars,
                                Active = q2.IsActive,
                                Tuition = q3.IsTuition,
                                OrderBy = q3.OrderBy
                            };
                return q.OrderBy(o => o.OrderBy).ToList();
            }
        }

        public static List<ScholarshipFeeEntity> GetScholarshipFees(int iScholarshipId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.ScholarshipFees
                        join q1 in e.Scholarships on q0.ScholarshipId equals q1.ScholarshipId
                        join q2 in e.ScheduleFees on q0.ScheduleFeeId equals q2.ScheduleFeeId
                        join q3 in e.FeeParticulars on q2.FeeParticularId equals q3.FeeParticularId
                        where (q1.ScholarshipId == iScholarshipId)
                        select new ScholarshipFeeEntity
                            {
                                ScholarshipId = q1.ScholarshipId,
                                ScholarshipFeeId = q0.ScholarshipFeeId,
                                ScheduleFeeId = q2.ScheduleFeeId,
                                FeeParticularId = q3.FeeParticularId,
                                Percentage = q0.Percentage
                            };
                return q.ToList();
            }
        }

        public static List<LaboratoryFeesEntity> GetLaboratoryFeesEntity(int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.LabSubjects
                        join q1 in e.LaboratoryFees on q0.LaboratoryFeeId equals q1.LaboratoryFeeId
                        join q2 in e.FeeParticulars on q1.FeeParticularId equals q2.FeeParticularId
                        join q3 in e.Subjects on q0.SubjectId equals q3.SubjectId
                        where (q1.SemSyId == iSemSyId)
                        select new LaboratoryFeesEntity
                            {
                                LaboratoryFeeId = q1.LaboratoryFeeId,
                                SemYrId = q1.SemSyId,
                                FeeParticularId = q2.FeeParticularId,
                                Particular = q2.Particulars,
                                Amount = q1.Amount,
                                SubjectId = q0.SubjectId,
                                SubectNo = q3.SubjectNo
                            };
                return q.ToList();
            }
        }

        public static LaboratoryFeesEntity GetLaboratoryFeeEntity(int iFeeParticularId, int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.LabSubjects
                        join q1 in e.LaboratoryFees on q0.LaboratoryFeeId equals q1.LaboratoryFeeId
                        join q2 in e.FeeParticulars on q1.FeeParticularId equals q2.FeeParticularId
                        join q3 in e.Subjects on q0.SubjectId equals q3.SubjectId
                        where((q2.FeeParticularId == iFeeParticularId) && (q1.SemSyId == iSemSyId))
                        select new LaboratoryFeesEntity
                        {
                            LaboratoryFeeId = q1.LaboratoryFeeId,
                            SemYrId = q1.SemSyId,
                            FeeParticularId = q2.FeeParticularId,
                            Particular = q2.Particulars,
                            Amount = q1.Amount,
                            SubjectId = q0.SubjectId,
                            SubectNo = q3.SubjectNo
                        };
                return q.SingleOrDefault();
            }
        }

        public static List<AssessEntity> GetAssessEntity(int iSemSyId, int iCourseId, int iYearLevelId, int iScholarship1, int iScholarship2,
            int iScholarship3, int iRegistrationId, double totalUnits, List<RegisteredSubjectEntity> listRegisteredSubjects)
        {
            var presets = GetPreFees(iSemSyId, iCourseId, iYearLevelId);
            var scholaships = GetScholarshipFees(iScholarship1);
            var scholarships1 = GetScholarshipFees(iScholarship2);
            var scholarships2 = GetScholarshipFees(iScholarship3);
            var labsubjects = GetLaboratoryFeesEntity(iSemSyId);
            var listAssessment = new List<AssessEntity>();
            foreach (var item in presets)
            {
                var a = new AssessEntity();
                if (Convert.ToBoolean(item.Active))
                {
                    var percentage = 0.00;
                    var percentage1 = 0.00;
                    var percentage2 = 0.00;
                    var totalPercentage = 0.00;
                    if (scholaships.Count > 0)
                        try
                        {
                            percentage = Convert.ToDouble(scholaships.Find(f => f.FeeParticularId == item.FeeParticularId).Percentage);
                        }
                        catch (Exception ex)
                        {
                            percentage = 0;
                        }
                    else
                    {
                        percentage = 0;
                    }

                    if (scholarships1.Count > 0)
                        try
                        {
                            percentage1 = Convert.ToDouble(scholarships1.Find(f => f.FeeParticularId == item.FeeParticularId).Percentage);
                        }
                        catch (Exception ex)
                        {
                            percentage1 = 0;
                        }
                    else
                    {
                        percentage1 = 0;
                    }

                    if (scholarships2.Count > 0)
                        try
                        {
                            percentage2 = Convert.ToDouble(scholarships2.Find(f => f.FeeParticularId == item.FeeParticularId).Percentage);
                        }
                        catch (Exception ex)
                        {
                            percentage2 = 0;
                        }
                    else
                    {
                        percentage2 = 0;
                    }

                    totalPercentage = percentage + percentage1 + percentage2;
                    if (totalPercentage > 100)
                        totalPercentage = 100;
                    
                    if (Convert.ToBoolean(item.Tuition))
                    {
                        a.Amount = Convert.ToDouble(item.Amount);
                        a.PercentLess = totalPercentage;
                        a.Less = (Convert.ToDouble(item.Amount) * totalUnits) * (totalPercentage / 100);
                        a.GrossAmount = (Convert.ToDouble(item.Amount)*totalUnits);
                        a.NetAmount = (Convert.ToDouble(item.Amount)*totalUnits) - a.Less;
                        a.Original = true;
                        a.FeeParticularId = Convert.ToInt32(item.FeeParticularId);
                        a.RegistrationId = iRegistrationId;
                        a.Particulars = item.Particular;
                    }
                    else
                    {
                        a.Amount = Convert.ToDouble(item.Amount);
                        a.PercentLess = totalPercentage;
                        a.Less = (Convert.ToDouble(item.Amount)) * (totalPercentage / 100);
                        a.GrossAmount = (Convert.ToDouble(item.Amount));
                        a.NetAmount = (Convert.ToDouble(item.Amount)) - a.Less;
                        a.Original = true;
                        a.FeeParticularId = Convert.ToInt32(item.FeeParticularId);
                        a.RegistrationId = iRegistrationId;
                        a.Particulars = item.Particular; 
                    }
                }
                listAssessment.Add(a);
            }

            //remove lab fee w/o subjectid
            foreach (var item in labsubjects)
            {
                var remove = listAssessment.SingleOrDefault(f => f.FeeParticularId == item.FeeParticularId);
                if (remove != null)
                {
                    listAssessment.Remove(remove);
                }
            }

            //for laboratory
            foreach (var item in listRegisteredSubjects)
            {
                var listLab = labsubjects.FindAll( f => f.SubjectId == item.SubjectId);
                foreach (var lab in listLab)
                {
                    var a1 = new AssessEntity();
                    if (lab != null)
                    {
                        var percentage = 0.00;
                        var percentage1 = 0.00;
                        var percentage2 = 0.00;
                        var totalPercentage = 0.00;
                        if (scholaships.Count > 0)
                            try
                            {
                                percentage = Convert.ToDouble(scholaships.Find(f => f.FeeParticularId == lab.FeeParticularId).Percentage);
                            }
                            catch (Exception ex)
                            {
                                percentage = 0;
                            }
                        else
                        {
                            percentage = 0;
                        }

                        if (scholarships1.Count > 0)
                            try
                            {
                                percentage1 = Convert.ToDouble(scholarships1.Find(f => f.FeeParticularId == lab.FeeParticularId).Percentage);
                            }
                            catch (Exception ex)
                            {
                                percentage1 = 0;
                            }
                        else
                        {
                            percentage1 = 0;
                        }

                        if (scholarships2.Count > 0)
                            try
                            {
                                percentage2 = Convert.ToDouble(scholarships2.Find(f => f.FeeParticularId == lab.FeeParticularId).Percentage);
                            }
                            catch (Exception ex)
                            {
                                percentage2 = 0;
                            }
                        else
                        {
                            percentage2 = 0;
                        }

                        totalPercentage = percentage + percentage1 + percentage2;
                        if (totalPercentage > 100)
                            totalPercentage = 100;

                        a1.Amount = Convert.ToDouble(lab.Amount);
                        a1.PercentLess = totalPercentage;
                        a1.Less = (Convert.ToDouble(lab.Amount)) * (totalPercentage / 100);
                        a1.GrossAmount = (Convert.ToDouble(lab.Amount));
                        a1.NetAmount = (Convert.ToDouble(lab.Amount)) - a1.Less;
                        a1.Original = true;
                        a1.FeeParticularId = Convert.ToInt32(lab.FeeParticularId);
                        a1.RegistrationId = iRegistrationId;
                        a1.Particulars = lab.ParticularLabel;
                        a1.SubjectId = lab.SubjectId;
                        listAssessment.Add(a1);
                    }    
                }
                
            }
            return listAssessment;
        }

        public static List<AssessEntity> GetAssessedEntityByRegistrationId(int iRegistrationId)
        {
            using (var e = new ESEntities())
            {
                var q = (from q0 in e.Assessments
                        join q1 in e.FeeParticulars on q0.FeeParticularId equals q1.FeeParticularId
                        join q2 in e.AssessmentLaboratories on q0.AssessmentId equals q2.AssessmentId into q02
                        from q02a in q02.DefaultIfEmpty()
                        where (q0.RegistrationId == iRegistrationId)
                        select new AssessEntity
                            {
                                AssessmentId = q0.AssessmentId,
                                Amount = (double) q0.Amount,
                                AddAmount = (double) q0.AddAmount,
                                Less = (double) q0.Less,
                                AddLess = (double) q0.AddLess,
                                PercentLess = (double) q0.PercentLess,
                                NetAmount = (double) q0.NetAmount,
                                GrossAmount = (double) q0.GrossAmount,
                                Original =  q0.IsOriginal,
                                FeeParticularId = (int) q0.FeeParticularId,
                                RegistrationId = q0.RegistrationId,
                                Particulars = q1.Particulars,
                                LabParticulars = q02a.LaboratoryName,
                                SubjectId = q02a.SubjectId,
                                IsTuition = q1.IsTuition
                            }).Distinct();
                return q.ToList();
            }
        }

        public static List<ScheduleFeesEntity> GetScheduleFeesSemSy(int iSemSyId)
        {
            using (var e = new ESEntities())
            {
                var q = from q0 in e.ScheduleFees
                        join q1 in e.FeeParticulars on q0.FeeParticularId equals q1.FeeParticularId
                        join q2 in e.ScheduleFeeNames on q0.ScheduleFeeNameId equals q2.ScheduleFeeNameId
                        where (q2.SemSyId == iSemSyId)
                        select new ScheduleFeesEntity
                            {
                                ScheduleFeeId = q0.ScheduleFeeId,
                                Particulars = q1.Particulars,
                                Amount = q0.Amount,
                                Active = q0.IsActive,
                                FeeParticularId = q1.FeeParticularId
                            };
                return q.ToList();
            }
        }
    }
}
