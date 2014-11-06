using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_2___Registration.forms
{
    public partial class UpdateGetStudentRecordForm : Form
    {
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }
        public Branch Branch { get; set; }

        private StudentEntity _student;
        private RegistrationEntity _registrationEntity;

        private string _operation;

        private RegistrationForm _registrationForm;
        public UpdateGetStudentRecordForm(RegistrationForm form)
        {
            _registrationForm = form;
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            var index = jTabWizard1.SelectedIndex + 1;
            jTabWizard1.SelectTab(index);
            if (index == 2)
            {
                buttonNext.Enabled = false;
                buttonBack.Enabled = true;
                buttonOk.Text = @"&Save + Load Record";
                buttonOk.Enabled = true;
                GetAcquiredLabels((RegistrationEntity)registrationEntityBindingSource.Current);
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Blue;
            }
            else if (index == 0)
            {
                buttonNext.Enabled = true;
                buttonBack.Enabled = false;
                buttonOk.Text = @"&Ok + Load Record";
                buttonOk.Enabled = true;
                label1.ForeColor = Color.Blue;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
            }
            else
            {
                buttonNext.Enabled = true;
                buttonBack.Enabled = true;
                buttonOk.Text = @"&Update Record";
                buttonOk.Enabled = false;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Blue;
                label3.ForeColor = Color.Black;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var index = jTabWizard1.SelectedIndex - 1;
            jTabWizard1.SelectTab(index);
            if (index == 2)
            {
                buttonNext.Enabled = false;
                buttonBack.Enabled = true;
                buttonOk.Enabled = true;
                buttonOk.Text = @"&Save + Load Record";
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Blue;
            }
            else if (index == 0)
            {
                buttonNext.Enabled = true;
                buttonBack.Enabled = false;
                buttonOk.Enabled = true;
                buttonOk.Text = @"&Ok + Load Record";
                label1.ForeColor = Color.Blue;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
            }
            else
            {
                buttonNext.Enabled = true;
                buttonBack.Enabled = true;
                buttonOk.Enabled = false;
                buttonOk.Text = @"&Update Record";
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Blue;
                label3.ForeColor = Color.Black;
            }
        }

        private void UpdateGetStudentRecordForm_Load(object sender, EventArgs e)
        {
            GetPreferences();

            InitializedControlz();
            buttonOk.Enabled = false;
            buttonOk.Text = @"&Ok + Load Record";
            waterMarkTextBox1.Select();
            waterMarkTextBox1.Focus();
            jTabWizard1.SelectTab(0);
            buttonNext.Enabled = true;
            buttonBack.Enabled = false;
            studentEntityBindingSource.DataSource = null;
        }

        private void InitializedControlz()
        {
            if (SemSyEntity != null)
            {
                labelSemSy1.Text = SemSyEntity.SemSyNameLabel;
                labelSemSy2.Text = SemSyEntity.SemSyNameLabel;    
            }
            if (Branch != null)
            {
                labelBranch1.Text = Branch.BranchName;
                labelBranch2.Text = Branch.BranchName;    
            }
            
            
            labelEnrollmentLabel.Text = _operation;
            registrationDateDateTimePicker.Value = DateTime.Today;

            label1.ForeColor = Color.Blue;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void GetPreferences()
        {
            Cursor.Current = Cursors.WaitCursor;
            var listCourses = LoadQueries.GetCourses();
            var course = new Cours
                {
                    CourseName = @"--- Select Course ---"
                };
            listCourses.Insert(0, course);
            coursBindingSource.DataSource = listCourses;

            var listCurriculums = LoadQueries.GetProspectuses();
            var curriculum = new Prospectus
                {
                    ProspectusName = @"--- Select Prospectus ---"
                };
            listCurriculums.Insert(0, curriculum);
            prospectusBindingSource.DataSource = listCurriculums;

            var listYearLevels = LoadQueries.GetYearLevels();
            var yearLevel = new YearLevel
                {
                    YearLevelName = @"--- Year Level ---"
                };
            listYearLevels.Insert(0, yearLevel);
            yearLevelBindingSource.DataSource = listYearLevels;

            var listSections = LoadQueries.GetSections();
            var section = new Section
                {
                    SectionName = @"--- Section ---"
                };
            listSections.Insert(0, section);
            sectionBindingSource.DataSource = listSections;

            var listStatuses = LoadQueries.GetStatus();
            var status = new StudentStatus
                {
                    StatusName = @"--- Status ---"
                };
            listStatuses.Insert(0, status);
            studentStatusBindingSource.DataSource = listStatuses;

            var listTypes = LoadQueries.GetStudentType();
            var type = new StudentType
                {
                    StudentTypeName = @"--- Type ---"
                };
            listTypes.Insert(0, type);
            studentTypeBindingSource.DataSource = listTypes;

            var listScholarships = LoadQueries.GetScholarships();
            var scholarship = new Scholarship
                {
                    ScholarshipName = @"--- Select Scholarship ---"
                };
            listScholarships.Insert(0, scholarship);
            scholarshipBindingSource.DataSource = listScholarships;

            var listScholarships1 = LoadQueries.GetScholarships();
            var scholarship1 = new Scholarship
            {
                ScholarshipName = @"--- Select Scholarship ---"
            };
            listScholarships1.Insert(0, scholarship1);
            scholarshipBindingSource1.DataSource = listScholarships1;

            var listScholarships2 = LoadQueries.GetScholarships();
            var scholarship2 = new Scholarship
            {
                ScholarshipName = @"--- Select Scholarship ---"
            };
            listScholarships2.Insert(0, scholarship2);
            scholarshipBindingSource2.DataSource = listScholarships2;
            Cursor.Current = Cursors.Default;
        }

        private void GetProspectus(int iCourseId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var listCurriculums = ObjectQueries.GetProspectusCourse(iCourseId);
            var curriculum = new Prospectus
            {
                ProspectusName = @"--- Select Prospectus ---"
            };
            listCurriculums.Insert(0, curriculum);
            prospectusBindingSource.DataSource = listCurriculums;
            Cursor.Current = Cursors.Default;
        }

        private void SearchStudent()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (waterMarkTextBox1.Text.Length > 0)
            {
                studentEntityBindingSource.DataSource = ObjectQueries.GetStudentEntity02(waterMarkTextBox1.Text);
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }

        private void waterMarkTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchStudent();
            }
        }

        private void HotKeys(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;        
                default : break;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void coursBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (coursBindingSource.Current != null)
            {
                GetProspectus(((Cours)coursBindingSource.Current).CourseId);
            }
        }

        private void waterMarkTextBox1_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBox1, true);
        }

        private void waterMarkTextBox1_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBox1, false);
        }

        private void courseIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(courseIdComboBox, true);
        }

        private void courseIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(courseIdComboBox, false);
        }

        private void prospectusIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(prospectusIdComboBox, true);
        }

        private void prospectusIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(prospectusIdComboBox, false);
        }

        private void yearLevelIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(yearLevelIdComboBox, true);
        }

        private void yearLevelIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(yearLevelIdComboBox, false);
        }

        private void sectionIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(sectionIdComboBox, true);
        }

        private void sectionIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(sectionIdComboBox, false);
        }

        private void statusIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(statusIdComboBox, true);
        }

        private void statusIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(statusIdComboBox, false);
        }

        private void typeIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(typeIdComboBox, true);
        }

        private void typeIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(typeIdComboBox, false);
        }

        private void scholarshipIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipIdComboBox, true);
        }

        private void scholarshipIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipIdComboBox, false);
        }

        private void scholarshipId1ComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipId1ComboBox, true);
        }

        private void scholarshipId1ComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipId1ComboBox, false);
        }

        private void scholarshipId2ComboBox_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipId2ComboBox, true);
        }

        private void scholarshipId2ComboBox_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(scholarshipId2ComboBox, true);
        }

        private void studentEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
           
        }

        private void studentEntityBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (studentEntityBindingSource.Current != null)
            {
                _student = (StudentEntity)studentEntityBindingSource.Current;
                if (_student != null)
                {
                    toolStripStatusLabel1.Text = String.Format(@"{0} - {1}", _student.IdNo, _student.FullName);
                    if ((_student.StudentId > 0) && (SemSyEntity.SemSyId > 0))
                    {
                        GetRegistration();
                        if (ObjectQueries.CheckIfEnrolledSemSyStudent(SemSyEntity.SemSyId, _student.StudentId) != null)
                        {
                            _operation = @"Updating...";
                            toolStripStatusLabel1.ForeColor = Color.Red;
                            labelEnrollmentLabel.ForeColor = Color.Red;
                            labelEnrollment.ForeColor = Color.Red;
                            buttonOk.Enabled = true;
                        }
                        else
                        {
                            _operation = @"New Enrollment.";
                            toolStripStatusLabel1.ForeColor = Color.Black;
                            labelEnrollmentLabel.ForeColor = Color.Green;
                            labelEnrollment.ForeColor = Color.Green;
                            buttonOk.Enabled = false;
                        }
                        labelEnrollmentLabel.Text = _operation;
                        labelEnrollment.Text = _operation;
                    }
                }
            }
        }

        private void GetRegistration()
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((_student != null) && (SemSyEntity != null))
            {
                _registrationEntity = ObjectQueries.GetStudentRegistration(SemSyEntity.SemSyId, _student.StudentId);
                if (_registrationEntity != null)
                {
                    registrationEntityBindingSource.DataSource = _registrationEntity;

                    labelRegNo1.Text = _registrationEntity.RegistrationId.ToString();
                    labelIdNo1.Text = _registrationEntity.IdNo;
                    labelIdNo2.Text = _registrationEntity.IdNo;
                    labelFullName1.Text = _registrationEntity.FullName.ToUpper();
                    labelFullName2.Text = _registrationEntity.FullName.ToUpper();
                    labelYrCrsSec1.Text = _registrationEntity.YearCourseSection;
                }
                else
                {
                    registrationEntityBindingSource.AddNew();
                    _registrationEntity = ObjectQueries.GetStudentRegistrationById(_student.StudentId);
                    if (_registrationEntity == null)
                    {
                        _registrationEntity = new RegistrationEntity();
                        //_registrationEntity.RegistrationId = 0;
                        if (studentEntityBindingSource.Current != null)
                        {
                            var s = (StudentEntity)studentEntityBindingSource.Current;
                            labelRegNo1.Text = @"0";
                            labelIdNo1.Text = s.IdNo;
                            labelIdNo2.Text = s.IdNo;
                            labelFullName1.Text = s.FullName.ToUpper();
                            labelFullName2.Text = s.FullName.ToUpper();
                            labelYrCrsSec1.Text = s.YearCourseSection;
                        }
                    }
                    _registrationEntity.RegistrationId = 0;
                    if (studentEntityBindingSource.Current != null)
                    {
                        var s = (StudentEntity)studentEntityBindingSource.Current;
                        labelRegNo1.Text = @"0";
                        labelIdNo1.Text = s.IdNo;
                        labelIdNo2.Text = s.IdNo;
                        labelFullName1.Text = s.FullName.ToUpper();
                        labelFullName2.Text = s.FullName.ToUpper();
                        labelYrCrsSec1.Text = s.YearCourseSection;
                    }
                    _registrationEntity.Paid = false;
                    _registrationEntity.Enrolled = false;
                    _registrationEntity.Cancelled = false;
                    registrationDateDateTimePicker.Value = DateTime.Now;
                    _registrationEntity.RegistrationDate = DateTime.Now;
                    registrationEntityBindingSource.DataSource = _registrationEntity;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void studentEntityDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonNext.PerformClick();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (jTabWizard1.SelectedIndex == 2)
            {
                UpdateRegistration();
            }
            else if (jTabWizard1.SelectedIndex == 0)
            {
                if ((_student != null) && (SemSyEntity != null))
                    _registrationEntity = ObjectQueries.GetStudentRegistrationById(_student.StudentId, SemSyEntity.SemSyId);
                else
                {
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(@"Please select a record to load. Thank you.");
                    studentEntityDataGridView.Focus();
                }
            }
            _registrationForm.RegistrationEntity = null;
            _registrationForm.RegistrationEntity = _registrationEntity;
            Close();
        }

        private void UpdateRegistration()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (registrationEntityBindingSource.Current != null)
            {
                var r = (RegistrationEntity) registrationEntityBindingSource.Current;
                //if (CheckEntries(r))
                //{
                    if (r != null)
                    {
                        r.SemSyId = SemSyEntity.SemSyId;
                        r.BranchId = Branch.BranchId;
                        r.UserId = UserEntity.UserId;
                        r.StudentId = _student.StudentId;
                        var reg = new Registration
                        {
                            RegistrationId = Convert.ToInt32(r.RegistrationId),
                            RegistrationDate = r.RegistrationDate,
                            IsCancelled = r.Cancelled,
                            IsEnrolled = r.Enrolled,
                            IsPaid = r.Paid,
                            CourseId = r.CourseId,
                            ProspectusId = r.ProspectusId,
                            StudentTypeId = r.TypeId,
                            StudentStatusId = r.StatusId,
                            YearLevelId = r.YearLevelId,
                            SectionId = r.SectionId,
                            ScholarshipId = r.ScholarshipId,
                            ScholarshipId1 = r.ScholarshipId1,
                            ScholarshipId2 = r.ScholarshipId2,
                            SemSyId = r.SemSyId,
                            BranchId = r.BranchId,
                            UserId = r.UserId,
                            StudentId = r.StudentId
                        };

                        var iResult = Save.Registrations(reg);
                        if (iResult > 0)
                        {
                            //UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                            //GetAcquiredLabels(reg);
                            //buttonNext.PerformClick();
                            _registrationEntity = ObjectQueries.GetStudentRegistration(SemSyEntity.SemSyId, _student.StudentId);
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        }
                    //}
                }
                else
                {
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(@"Please double check the entries. Thank you.");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAcquiredLabels(RegistrationEntity reg)
        {
            labelRegNo2.Text = reg.RegistrationId.ToString();
            var yrCrsSec = String.Format(@"{0}/{1}/{2}",
                                         ((YearLevel) yearLevelBindingSource.Current).YearLevelName,
                                         ((Cours) coursBindingSource.Current).Abbreviation,
                                         ((Section) sectionBindingSource.Current).SectionName);
            labelYrCrsSec2.Text = yrCrsSec;
            labelDateRegistered.Text = String.Format(@"{0:d}", reg.RegistrationDate);
            labelCourse.Text = ((Cours) coursBindingSource.Current).CourseName;
            labelCurriculum.Text = ((Prospectus) prospectusBindingSource.Current).ProspectusName;
            labelYearSection.Text = String.Format(@"{0} / {1}",
                                                  ((YearLevel) yearLevelBindingSource.Current).YearLevelName,
                                                  ((Cours) coursBindingSource.Current).Abbreviation);
            labelStatusType.Text = String.Format(@"{0} / {1}",
                                                 ((StudentStatus) studentStatusBindingSource.Current)
                                                     .StatusName,
                                                 ((StudentType) studentTypeBindingSource.Current)
                                                     .StudentTypeName);
            labelScholarship1.Text = ((Scholarship) scholarshipBindingSource.Current).ScholarshipName;
            labelScholarship2.Text = ((Scholarship) scholarshipBindingSource1.Current).ScholarshipName;
            labelScholarship3.Text = ((Scholarship) scholarshipBindingSource2.Current).ScholarshipName;
        }

        private bool CheckEntries(RegistrationEntity registrationEntity)
        {
            var bResult = false;
            errorProvider1.SetError(courseIdComboBox,
                                    registrationEntity.CourseId > 0 ? @"Course should not be empty." : @"");
            errorProvider1.SetError(prospectusIdComboBox, registrationEntity.ProspectusId > 0 ? @"Curriculum should not be empty." : @"");
            errorProvider1.SetError(yearLevelIdComboBox, registrationEntity.YearLevelId > 0 ? @"Year level should not be empty." : @"");
            errorProvider1.SetError(sectionIdComboBox, registrationEntity.SectionId > 0 ? @"Section should not be empty." : @"");
            errorProvider1.SetError(statusIdComboBox, registrationEntity.StatusId > 0 ? @"Status should not be empty." : @"");
            errorProvider1.SetError(typeIdComboBox, registrationEntity.TypeId > 0 ? @"Type should not be empty." : @"");
            errorProvider1.SetError(scholarshipId1ComboBox, registrationEntity.ScholarshipId > 0 ? @"Scholarship should not be empty" : @"");
            if ((registrationEntity.CourseId > 0) && (registrationEntity.ProspectusId > 0)
                && (registrationEntity.YearLevelId > 0) && (registrationEntity.SectionId > 0)
                && (registrationEntity.StatusId > 0) && (registrationEntity.TypeId > 0)
                && (registrationEntity.ScholarshipId > 0))
            {
                bResult = true;
            }
            return bResult;
        }

        private void buttonR1_Click(object sender, EventArgs e)
        {
            scholarshipBindingSource1.Position = 0;
            ((RegistrationEntity) registrationEntityBindingSource.Current).ScholarshipId1 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scholarshipBindingSource2.Position = 0;
            ((RegistrationEntity)registrationEntityBindingSource.Current).ScholarshipId2 = null;
        }

        private void studentEntityDataGridView_DockChanged(object sender, EventArgs e)
        {

        }
    }
}
