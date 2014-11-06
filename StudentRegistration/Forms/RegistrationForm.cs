using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo;
using GenDataLayer.repo.managers;
using StudentRegistration.Helpers;
using GenDataLayer.repo.entities;
using Infragistics.Win.UltraWinGrid;

namespace StudentRegistration.Forms
{
    public sealed partial class RegistrationForm : Form
    {
        private List<AccountInformation> _accountInfo;
        //private AssessmentEntity _tempTuitionFeeInfo;

        private static readonly Func<int, int, int, List<SubjectEntity>> GetSubjectsByYearLevelCourseSection = (yearLevelId, courseId, sectionId) =>
        {
            using (var con = new ESEntities())
                return CompiledQueries.GetSubjectsByYearLevelCourseSection.Invoke(con, yearLevelId, courseId, sectionId).ToList();
        };
        private static readonly Func<string, SubjectEntity> GetSubjectsByScheduleCode = scheduleCode =>
        {
            using (var con = new ESEntities())
                return CompiledQueries.GetSubjectsByScheduleCode.Invoke(con, scheduleCode).FirstOrDefault();
        };
        private static readonly Func<List<SubjectEntity>, string> GetTotalUnit = source =>
            source.Where(c => c.IsValid.HasValue && c.IsValid.Value).Sum(c => (decimal)c.SubjectLecUnit).ToString("#,#0.00");

        //private static readonly Func<string> GetOrderMaxNo = () =>
        //{
        //    int x = 0;
        //    int? max = LoadQueries.GetRegistrationMaxNo.Invoke();
        //    if (max != null)
        //        x = max.Value;
        //    return (x == 0 ? "0000000001" : string.Format("{0:#0000000000}", x + 1));
        //};

        private string _originalScheduleCode = string.Empty;

        private readonly NoFocusRectUltraTabControl _noFocusUltra = new NoFocusRectUltraTabControl();

        public RegistrationForm()
        {
            InitializeComponent();

            #region Load Lookups
            using (var con = new ESEntities())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    studentTypeBindingSource.DataSource = CompiledQueries.GetStudentTypes.Invoke(con).ToList();
                    studentStatusBindingSource.DataSource = CompiledQueries.GetStudentStatuses.Invoke(con).ToList();
                    courseEntityBindingSource.DataSource = CompiledQueries.GetCoursesEntity.Invoke(con).ToList();
                    scholarshipBindingSource.DataSource = CompiledQueries.GetScholarships.Invoke(con).ToList();
                    majorBindingSource.DataSource = CompiledQueries.GetMajors.Invoke(con).ToList();
                    minorBindingSource.DataSource = CompiledQueries.GetMinors.Invoke(con).ToList();
                    yearLevelBindingSource.DataSource = CompiledQueries.GetYearLevels.Invoke(con).ToList();
                    sectionBindingSource.DataSource = CompiledQueries.GetSections.Invoke(con).ToList();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            #endregion

            #region Scholarship ComboBox Design
            scholarshipComboBox.DataSource = scholarshipBindingSource;
            scholarshipComboBox.DisplayMember = "ScholarshipName";
            scholarshipComboBox.ValueMember = "ScholarshipId";
            scholarshipComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            scholarshipComboBox.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            #endregion

            #region Course ComboBox Design
            courseComboBox.DataSource = courseEntityBindingSource;
            courseComboBox.DisplayMember = "CourseName";
            courseComboBox.ValueMember = "CourseId";
            courseComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            #endregion

            #region Propectus ComboBox Design
            prospectusComboBox.DataSource = prospectusBindingSource;
            prospectusComboBox.DisplayMember = "ProspectusName";
            prospectusComboBox.ValueMember = "ProspectusId";
            prospectusComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            #endregion

            #region Major ComboBox Design
            majorComboBox.DataSource = majorBindingSource;
            majorComboBox.DisplayMember = "MajorName";
            majorComboBox.ValueMember = "MajorId";
            #endregion

            #region Minor ComboBox Design
            minorComboBox.DataSource = minorBindingSource;
            minorComboBox.DisplayMember = "MinorName";
            minorComboBox.ValueMember = "MinorId";
            minorComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            #endregion

            #region Course Major
            courseMajorComboBox.DataSource = courseMajorEntityBindingSource;
            courseMajorComboBox.DisplayMember = "MajorName";
            courseMajorComboBox.ValueMember = "CourseMajorId";
            courseMajorComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            #endregion

            #region Course Minor
            courseMinorComboBox.DataSource = courseMinorEntityBindingSource;
            courseMinorComboBox.DisplayMember = "MinorName";
            courseMinorComboBox.ValueMember = "CourseMinorId";
            courseMinorComboBox.DropDownResizeHandleStyle = Infragistics.Win.DropDownResizeHandleStyle.VerticalResize;
            #endregion

            #region Other Desgin
            ultraTabControl1.DrawFilter = _noFocusUltra;
            var dataGridViewColumn = subjectEntityDataGridView.Columns["scheduleCodeDataGridViewTextBoxColumn"];
            if (dataGridViewColumn != null)
                dataGridViewColumn
                    .HeaderCell.Style.Font = new Font("Arial", 8.25f, FontStyle.Bold);

            #endregion
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            studentTypeComboBox.SelectedIndex = -1;
            studentStatusComboBox.SelectedIndex = -1;
            scholarshipComboBox.Value = null;
            yearLevelComboBox.SelectedIndex = -1;
            courseComboBox.Value = null;
            sectionComboBox.SelectedIndex = -1;
            prospectusComboBox.Value = null;
            majorComboBox.Value = null;
            minorComboBox.Value = null;

            #region Account Information
            _accountInfo = new List<AccountInformation>();

            _accountInfo.Add(new AccountInformation
                        {
                            Name = "Registration No.",
                            Numbers = GetOrderMaxNo.Invoke()
                        });
            _accountInfo.Add(new AccountInformation
                {
                    Name = "Tuition Fee",
                    Numbers = string.Empty
                });
            _accountInfo.Add(new AccountInformation
                {
                    Name = "Unit",
                    Numbers = string.Empty
                });

            accountInformationBindingSource.DataSource = _accountInfo.ToList();
            #endregion


            idNoTextBox.Focus();
            idNoTextBox.Select();
        }

        private void scholarshipComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ScholarshipId"].Hidden = true;
            e.Layout.Bands[0].Columns["ScholarshipName"].Header.Caption = "Scholarship";
            e.Layout.Bands[0].Columns["ScholarshipName"].Width = 250;
            e.Layout.Bands[0].Columns["ScholarshipAbbreviation"].Header.Caption = "Abbreviation";
            e.Layout.Bands[0].Columns["ScholarshipName"].Width = 150;
            e.Layout.Bands[0].Columns["Sponsor"].Width = 200;
        }

        private void courseComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["CourseId"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseName"].Header.Caption = "Course";
            e.Layout.Bands[0].Columns["CourseName"].Width = 200;
            e.Layout.Bands[0].Columns["Abbreviation"].Width = 100;
            e.Layout.Bands[0].Columns["Duration"].Width = 75;
            e.Layout.Bands[0].Columns["DepartmentId"].Hidden = true;
            e.Layout.Bands[0].Columns["Department"].Hidden = true;
            e.Layout.Bands[0].Columns["DepartmentName"].Width = 200;
            e.Layout.Bands[0].Columns["DepartmentName"].Header.Caption = "Deparment";
            e.Layout.Bands[0].Columns["DepartmentName"].Header.VisiblePosition = 4;
        }

        private void courseComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (courseComboBox.SelectedRow == null)
            {
                courseComboBox.Value = null;

                subjectEntityBindingSource.Clear();
                assessmentEntityBindingSource.Clear();
                subjectEntityBindingSource.Clear();
                LoadAccountInformation();
            }
        }

        private void prospectusComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (prospectusComboBox.SelectedRow == null)
            {
                prospectusComboBox.Value = null;
            }
        }

        private void prospectusComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ProspectusId"].Hidden = true;
            e.Layout.Bands[0].Columns["ProspectusName"].Header.Caption = "Prospectus";
            e.Layout.Bands[0].Columns["ProspectusName"].Width = 250;
            e.Layout.Bands[0].Columns["Curriculum"].Width = 150;
            e.Layout.Bands[0].Columns["ProspectusDescription"].Header.Caption = "Description";
            e.Layout.Bands[0].Columns["ProspectusDescription"].Width = 150;
            e.Layout.Bands[0].Columns["Note"].Width = 200;
            e.Layout.Bands[0].Columns["Cours"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseId"].Hidden = true;
        }

        private void majorComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["MajorId"].Hidden = true;
            e.Layout.Bands[0].Columns["MajorName"].Header.Caption = "Major";
            e.Layout.Bands[0].Columns["MajorName"].Width = 250;
            e.Layout.Bands[0].Columns["MajorDescription"].Header.Caption = "Description";
            e.Layout.Bands[0].Columns["MajorDescription"].Width = 300;
        }

        private void minorComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["MinorId"].Hidden = true;
            e.Layout.Bands[0].Columns["MinorName"].Header.Caption = "Minor";
            e.Layout.Bands[0].Columns["MinorName"].Width = 250;
            e.Layout.Bands[0].Columns["MinorDescription"].Header.Caption = "Description";
            e.Layout.Bands[0].Columns["MinorDescription"].Width = 300;
        }

        private void yearLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yearLevelComboBox.SelectedValue != null && courseComboBox.SelectedRow != null && sectionComboBox.SelectedValue != null)
                subjectEntityBindingSource.DataSource = LoadSubjectsByYearLevelCourseSection();

            if (yearLevelComboBox.SelectedValue != null && courseComboBox.SelectedRow != null)
                assessmentEntityBindingSource.DataSource = LoadAssessmentsByYearLevelCourse();
            LoadAccountInformation();
        }

        private void courseComboBox_ValueChanged(object sender, EventArgs e)
        {
            if (courseComboBox.SelectedRow == null)
            {
                prospectusComboBox.Enabled = false;
                courseMajorComboBox.Enabled = false;
                prospectusComboBox.SelectedRow = null;
                courseMajorComboBox.SelectedRow = null;
                return;
            }
            int courseId;
            if (int.TryParse(courseComboBox.Value.ToString(), out courseId))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    using (var con = new ESEntities())
                    {
                        prospectusBindingSource.DataSource = CompiledQueries.GetProspectusByCourseId.Invoke(con, courseId).ToList();
                        courseMajorEntityBindingSource.DataSource = CompiledQueries.GetCourseMajorEntityByCourseId.Invoke(con, courseId).ToList();
                    }

                    prospectusComboBox.Enabled = true;
                    courseMajorComboBox.Enabled = true;

                    prospectusComboBox.SelectedRow = null;
                    courseMajorComboBox.SelectedRow = null;

                    if (yearLevelComboBox.SelectedValue != null && courseComboBox.SelectedRow != null && sectionComboBox.SelectedValue != null)
                        subjectEntityBindingSource.DataSource = LoadSubjectsByYearLevelCourseSection();

                    if (yearLevelComboBox.SelectedValue != null || courseComboBox.SelectedRow != null)
                        assessmentEntityBindingSource.DataSource = LoadAssessmentsByYearLevelCourse();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            LoadAccountInformation();
        }

        private void sectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yearLevelComboBox.SelectedValue != null && courseComboBox.SelectedRow != null && sectionComboBox.SelectedValue != null)
                subjectEntityBindingSource.DataSource = LoadSubjectsByYearLevelCourseSection();

            if (yearLevelComboBox.SelectedValue != null && courseComboBox.SelectedRow != null)
                assessmentEntityBindingSource.DataSource = LoadAssessmentsByYearLevelCourse();
            LoadAccountInformation();
        }

        private List<SubjectEntity> LoadSubjectsByYearLevelCourseSection()
        {
            var subjects = new List<SubjectEntity>();
            try
            {
                using (var con = new ESEntities())
                {
                    #region Subjects
                    Cursor = Cursors.WaitCursor;
                    var q1 = GetSubjectsByYearLevelCourseSection.Invoke((int)yearLevelComboBox.SelectedValue, (int)courseComboBox.Value, (int)sectionComboBox.SelectedValue);
                    var esEntities = con;
                    var q2 = (from x in q1
                              let y = CompiledQueries.GetScheduleDetailsByScheduleId
                              .Invoke(esEntities, x.ScheduleId).Select(c => c.TimeIn + "-" + c.TimeOut +
                                           (!string.IsNullOrEmpty(c.Days) ? "[" + c.Days + "]" : string.Empty) +
                                           (!string.IsNullOrEmpty(c.LecLab) ? "[" + c.LecLab + "]" : string.Empty) +
                                           (!string.IsNullOrEmpty(c.RomeNo) ? "[" + c.RomeNo + "]" : string.Empty)).ToArray()
                              select new SubjectEntity
                              {
                                  ScheduleId = x.ScheduleId,
                                  SubjectId = x.SubjectId,
                                  ScheduleCode = x.ScheduleCode,
                                  TotalToBeRegisteredStudent = x.TotalToBeRegisteredStudent,
                                  SubjectNo = x.SubjectNo,
                                  SubjectDescriptiveTitle = x.SubjectDescriptiveTitle,
                                  Units = x.SubjectLecUnit + ", " + x.SubjectLabUnit + ", " + x.SubjectCreUnit,
                                  SubjectLecUnit = x.SubjectLecUnit,
                                  SubjectLabUnit = x.SubjectLabUnit,
                                  SubjectCreUnit = x.SubjectCreUnit,
                                  ConcanatedSchedule = string.Join(" / ", y)
                              }).ToList();

                    foreach (var x in q2)
                    {
                        var totalRegistered = CompiledQueries.GetTotalStudentRegisteredByScheduleId.Invoke(con, x.ScheduleId);
                        int totalRegistered1 = 0;
                        if (totalRegistered != null)
                            totalRegistered1 = totalRegistered.Value;
                        x.IsValid = x.TotalToBeRegisteredStudent > totalRegistered1;
                        subjects.Add(x);
                    }
                    #endregion
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return subjects;
        }

        private List<AssessmentEntity> LoadAssessmentsByYearLevelCourse()
        {
            var assessment = new List<AssessmentEntity>();
            try
            {
                Cursor = Cursors.WaitCursor;
                using (var con = new ESEntities())
                {
                    #region Assessment

                    foreach (var a in CompiledQueries.GetAssessmentEntityByYearLevelIdCourseIdSemSyId.Invoke(con,
                                      (int)yearLevelComboBox.SelectedValue, (int)courseComboBox.Value).ToList())
                    {
                        if (a.IsTuition != null && a.IsTuition.Value)
                        {
                            _tempTuitionFeeInfo = a;
                        }
                        assessment.Add(a);
                    }
                    #endregion
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return assessment;
        }

        private void LoadAccountInformation()
        {
            if (_accountInfo == null) return;
            var subject = subjectEntityBindingSource.List.Cast<SubjectEntity>().ToList();
            if (subject.Any())
            {
                _accountInfo[2].Numbers = GetTotalUnit.Invoke(subject); //No of Unit
                if (decimal.Parse(_accountInfo[2].Numbers) == 0)
                {
                    _accountInfo[2].Numbers = string.Empty; //No of Unit

                    var assessment = assessmentEntityBindingSource.List.Cast<AssessmentEntity>().FirstOrDefault(c => c.IsTuition.HasValue && c.IsTuition.Value);
                    if (assessment != null)
                    {
                        assessmentEntityBindingSource.Remove(assessment);
                        _accountInfo[1].Numbers = string.Empty; //Tuition Amount
                    }
                }
                else
                {
                    var assessment = assessmentEntityBindingSource.List.Cast<AssessmentEntity>().FirstOrDefault(c => c.IsTuition.HasValue && c.IsTuition.Value);
                    if (assessment != null)
                    {
                        var isExist = assessmentEntityBindingSource.List.Cast<AssessmentEntity>().Any(c => c.IsTuition.HasValue && c.IsTuition.Value);
                        if (!isExist)
                            assessmentEntityBindingSource.Insert(0, assessment);
                        _accountInfo[1].Numbers = assessment.Amount.Value.ToString("#,#0.00"); //Tuition Amount
                    }
                    else
                    {
                        assessmentEntityBindingSource.Insert(0, _tempTuitionFeeInfo);
                        _accountInfo[1].Numbers = _tempTuitionFeeInfo.Amount.Value.ToString("#,#0.00"); //Tuition Amount
                    }
                }
            }
            else
            {
                _accountInfo[2].Numbers = string.Empty; //No of Unit

                var assessment = assessmentEntityBindingSource.List.Cast<AssessmentEntity>().FirstOrDefault(c => c.IsTuition.HasValue && c.IsTuition.Value);
                if (assessment != null)
                {
                    assessmentEntityBindingSource.Remove(assessment);
                    _accountInfo[1].Numbers = string.Empty; //Tuition Amount
                }
            }
            accountInformationDataGridView.Refresh();
        }

        private void subjectEntityDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Right) return;
            //var dgv = sender as DataGridView;
            //if (dgv != null)
            //{
            //    DataGridView.HitTestInfo hit = dgv.HitTest(e.X, e.Y);

            //    if (hit.Type == DataGridViewHitTestType.Cell || hit.Type == DataGridViewHitTestType.RowHeader)
            //    {
            //        if (subjectEntityBindingSource.Current != null)
            //        {
            //            if (hit.ColumnIndex != -1)
            //                subjectEntityDataGridView.CurrentCell = subjectEntityDataGridView[hit.ColumnIndex, hit.RowIndex];
            //            else
            //            {
            //                subjectEntityDataGridView.CurrentCell = subjectEntityDataGridView[0, hit.RowIndex];
            //                subjectEntityDataGridView.Rows[hit.RowIndex].Selected = true;
            //            }

            //            var o = (SubjectEntity)subjectEntityBindingSource.Current;
            //            ultraToolbarsManager1.Tools["View Detailed Schedules"].SharedProps.Enabled = o.SubjectId > 0;
            //        }
            //        else
            //        {
            //            ultraToolbarsManager1.Tools["View Detailed Schedules"].SharedProps.Enabled = false;
            //        }
            //    }
            //    else 
            //    {
            //        ultraToolbarsManager1.Tools["View Detailed Schedules"].SharedProps.Enabled = false;
            //    }
            //    ultraToolbarsManager1.ShowPopup("File", dgv);
            //}
        }

        private void majorByCourseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (majorByCourseCheckBox.Checked)
            {
                courseMajorComboBox.Visible = true;
                courseMinorComboBox.Visible = true;
                majorComboBox.Visible = false;
                minorComboBox.Visible = false;
            }
            else
            {
                courseMajorComboBox.Visible = false;
                courseMinorComboBox.Visible = false;
                majorComboBox.Visible = true;
                minorComboBox.Visible = true;
            }
        }

        private void courseMajorComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["CourseMajorId"].Hidden = true;
            e.Layout.Bands[0].Columns["MajorId"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseId"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseName"].Hidden = true;
            e.Layout.Bands[0].Columns["Cours"].Hidden = true;
            e.Layout.Bands[0].Columns["Major"].Hidden = true;
            e.Layout.Bands[0].Columns["MajorName"].Header.Caption = "Major";
            e.Layout.Bands[0].Columns["MajorName"].Width = 250;
            e.Layout.Bands[0].Columns["Note"].Width = 300;
        }

        private void courseMajorComboBox_ValueChanged(object sender, EventArgs e)
        {
            if (courseMajorComboBox.SelectedRow == null)
            {
                courseMinorComboBox.Enabled = false;
                courseMinorComboBox.SelectedRow = null;
                return;
            }

            int courseMajorId;
            if (int.TryParse(courseMajorComboBox.Value.ToString(), out courseMajorId))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    using (var con = new ESEntities())
                    {
                        courseMinorEntityBindingSource.DataSource = CompiledQueries.GetCourseMinorEntityByCourseMajorId.Invoke(con, courseMajorId).ToList();
                    }
                    courseMinorComboBox.Enabled = true;
                    courseMinorComboBox.SelectedRow = null;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                courseMinorComboBox.SelectedRow = null;
            }
        }

        private void courseMajorComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (courseMajorComboBox.SelectedRow == null)
            {
                courseMajorComboBox.Value = null;
            }
        }

        private void courseMinorComboBox_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["CourseMajorName"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseMinorId"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseMajorId"].Hidden = true;
            e.Layout.Bands[0].Columns["MinorId"].Hidden = true;
            e.Layout.Bands[0].Columns["Minor"].Hidden = true;
            e.Layout.Bands[0].Columns["CourseMajor"].Hidden = true;
            e.Layout.Bands[0].Columns["MinorName"].Header.Caption = "Minor";
            e.Layout.Bands[0].Columns["MinorName"].Width = 250;
            e.Layout.Bands[0].Columns["Note"].Width = 300;
        }

        private void courseMinorComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (courseMinorComboBox.SelectedRow == null)
            {
                courseMinorComboBox.Value = null;
            }
        }

        private void subjectEntityDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
                _originalScheduleCode = subjectEntityDataGridView[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim();
        }

        private void subjectEntityDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!subjectEntityDataGridView.IsCurrentCellDirty) return;

            var scheduleCode = subjectEntityDataGridView[1, e.RowIndex].EditedFormattedValue.ToString();
            if (e.ColumnIndex == 1)
            {
                if (_originalScheduleCode != scheduleCode.Trim())
                {
                    if (subjectEntityBindingSource.List.Cast<SubjectEntity>().Any(c => c.ScheduleCode == scheduleCode.Trim()))
                    {
                        e.Cancel = true;
                        MessageBox.Show("The Schedule Code is already exist." + JMessage.EscapeMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(scheduleCode))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var o = (SubjectEntity)subjectEntityBindingSource.Current;
                    subjectEntityBindingSource.EndEdit();
                    using (var con = new ESEntities())
                    {
                        Cursor = Cursors.WaitCursor;
                        var q1 = GetSubjectsByScheduleCode.Invoke(scheduleCode.Trim());

                        if (q1 != null)
                        {
                            var q2 = CompiledQueries.GetScheduleDetailsByScheduleId
                                      .Invoke(con, q1.ScheduleId).Select(c => c.TimeIn + "-" + c.TimeOut +
                                                   (!string.IsNullOrEmpty(c.Days) ? "[" + c.Days + "]" : string.Empty) +
                                                   (!string.IsNullOrEmpty(c.LecLab) ? "[" + c.LecLab + "]" : string.Empty) +
                                                   (!string.IsNullOrEmpty(c.RomeNo) ? "[" + c.RomeNo + "]" : string.Empty)).ToArray();

                            o.ScheduleId = q1.ScheduleId;
                            o.SubjectId = q1.SubjectId;
                            o.ScheduleCode = q1.ScheduleCode;
                            o.TotalToBeRegisteredStudent = q1.TotalToBeRegisteredStudent;
                            o.SubjectNo = q1.SubjectNo;
                            o.SubjectDescriptiveTitle = q1.SubjectDescriptiveTitle;
                            o.Units = q1.SubjectLecUnit + ", " + q1.SubjectLabUnit + ", " + q1.SubjectCreUnit;
                            o.SubjectLecUnit = q1.SubjectLecUnit;
                            o.SubjectLabUnit = q1.SubjectLabUnit;
                            o.SubjectCreUnit = q1.SubjectCreUnit;
                            o.ConcanatedSchedule = string.Join(" / ", q2);

                            var totalRegistered = CompiledQueries.GetTotalStudentRegisteredByScheduleId.Invoke(con, q1.ScheduleId);
                            int totalRegistered1 = 0;
                            if (totalRegistered != null)
                                totalRegistered1 = totalRegistered.Value;
                            o.IsValid = o.TotalToBeRegisteredStudent > totalRegistered1;
                            subjectEntityDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
                            LoadAccountInformation();
                        }
                        else
                        {
                            o.ScheduleId = null;
                            o.SubjectId = 0;
                            o.ScheduleCode = scheduleCode;
                            o.TotalToBeRegisteredStudent = null;
                            o.SubjectNo = null;
                            o.SubjectDescriptiveTitle = null;
                            o.Units = null;
                            o.IsValid = null;
                            o.ConcanatedSchedule = null;
                            subjectEntityDataGridView.Rows[e.RowIndex].ErrorText = "The code is not valid.";
                        }
                        subjectEntityDataGridView.Refresh();
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Please enter the Schedule Code." + JMessage.EscapeMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void subjectEntityDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 5) return;
            if (e.Value != null)
                if (!(bool)e.Value)
                    subjectEntityDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(227, 117, 117);
                else
                    subjectEntityDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            else
                subjectEntityDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void subjectEntityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = subjectEntityDataGridView.SelectedRows.Cast<DataGridViewRow>().Any();
            if (rowSelected)
            {
                if (!subjectEntityDataGridView.AreAllCellsSelected(true))
                {
                    if (subjectEntityBindingSource.Current != null)
                    {
                        var x = ((SubjectEntity)subjectEntityBindingSource.Current).SubjectId != 0;
                        removeSubjectToolStripButton.Enabled = x;
                        viewDetailedSchedulesToolStripButton.Enabled = x;
                    }
                    else
                    {
                        removeSubjectToolStripButton.Enabled = false;
                        viewDetailedSchedulesToolStripButton.Enabled = false;
                    }
                }
                else
                {
                    if (subjectEntityBindingSource.Current != null)
                    {
                        var x = ((SubjectEntity)subjectEntityBindingSource.Current).SubjectId != 0;
                        removeSubjectToolStripButton.Enabled = x;
                        viewDetailedSchedulesToolStripButton.Enabled = x;
                    }
                    else
                    {
                        removeSubjectToolStripButton.Enabled = false;
                        viewDetailedSchedulesToolStripButton.Enabled = false;
                    }
                }
            }
            else
            {
                removeSubjectToolStripButton.Enabled = false;
                viewDetailedSchedulesToolStripButton.Enabled = false;
            }
        }

        private void subjectEntityDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            removeSubjectToolStripButton.PerformClick();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void removeSubjectToolStripButton_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> rows = subjectEntityDataGridView.GetDataGridViewRow();
            DataGridViewRow[] dataGridViewRows = rows as DataGridViewRow[] ?? rows.ToArray();
            int countSelected = dataGridViewRows.Count();
            if (countSelected == 0) return;

            DialogResult response = JDialogs.MessageShowDelete(countSelected, "Subject(s)", MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
                foreach (DataGridViewRow r in dataGridViewRows.ToList().Where(r => r.Cells[0].Value != null & r.Index > -1))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        var bs = subjectEntityDataGridView.DataSource as BindingSource;
                        var id = (int)r.Cells[0].Value;
                        if (bs != null) bs.RemoveAt(r.Index);
                        LoadAccountInformation();
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }

        }

        private void assessmentEntityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            removeParticularToolStripButton.Enabled = assessmentEntityDataGridView.SelectedRows.Cast<DataGridViewRow>().Any();
        }

        private void removeParticularToolStripButton_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> rows = assessmentEntityDataGridView.GetDataGridViewRow();
            DataGridViewRow[] dataGridViewRows = rows as DataGridViewRow[] ?? rows.ToArray();
            int countSelected = dataGridViewRows.Count();
            if (countSelected == 0) return;

            DialogResult response = JDialogs.MessageShowDelete(countSelected, "Particular(s)", MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
                foreach (DataGridViewRow r in dataGridViewRows.ToList().Where(r => r.Cells[0].Value != null & r.Index > -1))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        var bs = assessmentEntityDataGridView.DataSource as BindingSource;
                        var id = (int)r.Cells[0].Value;
                        var assessment = bs.List.Cast<AssessmentEntity>().FirstOrDefault(c => c.FeeParticularId == id && c.IsTuition.HasValue && c.IsTuition.Value);
                        if (assessment != null)
                        {
                            if (!_accountInfo[2].Numbers.IsEmpty())
                            {
                                MessageBox.Show("You could not delete the Tuition Fee because there is Creditable Unit in the Subject(s).", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                continue;
                            }
                        }
                       
                        if (bs != null) bs.RemoveAt(r.Index);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
        }

        private void assessmentEntityDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            removeParticularToolStripButton.PerformClick();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void accountInformationDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }

    public class AccountInformation
    {
        public string Name { get; set; }
        public string Numbers { get; set; }
    }

}
