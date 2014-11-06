using System.Linq;
using System.Text;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.managers.man;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Module_2___Registration.forms
{
    public partial class RegistrationForm : Form
    {
        public UserEntity UserEntity { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public Branch Branch { get; set; }

        public College College { get; set; }

        public RegistrationEntity RegistrationEntity { get; set; }
        private readonly UpdateGetStudentRecordForm _registrrtionForm;
        private AddDropForm _addDropForm;

        private List<ScheduleEntity> _listSchedules = null;
        public List<RegisteredSubjectEntity> _listRegisteredSubject = null;
        private List<AssessEntity> _listAssessedEntity = null;
        private List<LaboratoryFeesEntity> _listLaboratoryFeesEntities = null;

        private int _choice;
        private bool _operation = false;

        private bool _editCell = false;
        private double tempLec;
        private double tempLab;
        private double tempCre;

        private double _grossAmount;
        private double _lessAmount;
        private double _netAmount;

        private int _noOfRegistered;
        private int _noOfLimit;

        public RegistrationForm()
        {
            _registrrtionForm = new UpdateGetStudentRecordForm(this);
            _addDropForm = new AddDropForm(this);
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _registrrtionForm.StartPosition = FormStartPosition.CenterScreen;
            _registrrtionForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _registrrtionForm.SemSyEntity = SemSyEntity;
            _registrrtionForm.Branch = Branch;
            _registrrtionForm.UserEntity = UserEntity;
            _registrrtionForm.MinimizeBox = false;
            _registrrtionForm.MaximizeBox = false;
            if (_registrrtionForm.ShowDialog() == DialogResult.OK)
            {
                if (RegistrationEntity != null)
                {
                    labelRegNo.Text = RegistrationEntity.RegistrationId.ToString();
                    labelDate.Text = String.Format(@"{0:d}", RegistrationEntity.RegistrationDate);
                    labelName.Text = String.Format(@"[ {0} ] - {1}", RegistrationEntity.IdNo,
                                                   RegistrationEntity.FullName);
                    var scholarships = String.Format(@"{0}, {1}, {2}", RegistrationEntity.ScholarshipName,
                                                     RegistrationEntity.ScholarshipName1,
                                                     RegistrationEntity.ScholarshipName2);
                    textBoxDetail.Text = @"YrCrseSec: " + '\t' + RegistrationEntity.YearCourseSection + '\t' + '\t' +
                                         '\t' +
                                         @"Scholarship: " + '\t' + scholarships + '\r' + '\n' +
                                         @"Curriculum: " + '\t' + RegistrationEntity.CurriculumName + '\r' + '\n' +
                                         @"Status/Type: " + '\t' + RegistrationEntity.StatusName + @"/" +
                                         RegistrationEntity.TypeName;
                    checkBoxCacncelled.Checked = Convert.ToBoolean(RegistrationEntity.Cancelled);
                    checkBoxPaid.Checked = Convert.ToBoolean(RegistrationEntity.Paid);
                    checkBoxEnrolled.Checked = Convert.ToBoolean(RegistrationEntity.Enrolled);

                    _operation = false;

                    ReloadEnrolledItems();

                    //College = ScheduleManager.GetStudentCollege(Convert.ToInt32(RegistrationEntity.CourseId));
                }
                else
                {
                    labelName.Text = @"NO RECORD FOUND...";
                    textBoxDetail.Text = String.Empty;
                    labelRegNo.Text = @"<<..>>";
                    labelDate.Text = @"<<..>>;";
                    checkBoxCacncelled.Checked = false;
                    checkBoxPaid.Checked = false;
                    checkBoxEnrolled.Checked = false;
                }
            }
        }

        private void ReloadEnrolledItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (RegistrationEntity != null)
            {
                _listRegisteredSubject =
                    ScheduleManager.GetAllRegisteredSubjectEntity(Convert.ToInt32(RegistrationEntity.RegistrationId));
                if (_listRegisteredSubject != null)
                {
                    if (_listRegisteredSubject.Count > 0)
                    {
                        GetSubjectAndSchedulesSaved();
                        ComputeTotalUnits1();
                        //GetAssessmentComputed();
                    }
                    else
                    {
                        GetSubjectAndSchedules(Convert.ToInt32(RegistrationEntity.SemSyId),
                                               Convert.ToInt32(RegistrationEntity.CourseId),
                                               Convert.ToInt32(RegistrationEntity.YearLevelId),
                                               Convert.ToInt32(RegistrationEntity.SectionId));
                        ComputeTotalUnits();
                    }
                }

                GetAssessmentComputed1();
                //GetAssessmentComputed();
            }
            Cursor.Current = Cursors.Default;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HotKeys(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    //buttonUpdate.PerformClick();
                    break;
                case Keys.F3:
                    buttonRegister.PerformClick();
                    break;
                case Keys.Insert:
                    button5.PerformClick();
                    break;
                case Keys.F4:
                    button4.PerformClick();
                    break;
                case Keys.Delete:
                    button1.PerformClick();
                    break;
                case Keys.F6:
                    if (_choice == 1)
                        buttonAssessment.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeys(e);

            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        private void textBoxDetail_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeys(e);

            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            GetLaboratoryFeesEntity();
            splitContainer1.SplitterDistance = 0;
            splitContainer3.SplitterDistance = 0;
            comboBox1.Visible = false;
            labelCollege.Visible = false;
            buttonClear.Visible = false;
            buttonSelectAll.Visible = false;
            buttonAddSubject.Visible = false;
            p1.Visible = false;
            labelLimit.Visible = false;

            button1.Enabled = false;
            button5.Enabled = false;
            buttonRegister.Enabled = false;
            buttonAssessment.Enabled = false;
            buttonSaveAssessment.Enabled = false;
            buttonF10.Enabled = false;
            buttonPrint.Enabled = false;

            buttonClearSelectedFees.Visible = false;
            buttonSelectAllFees.Visible = false;
            buttonAddFees.Visible = false;
        }

        private void GetLaboratoryFeesEntity()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listLaboratoryFeesEntities = AssessmentManager.GetLaboratoryFeesEntity(SemSyEntity.SemSyId);
            Cursor.Current = Cursors.Default;
        }

        private void GetScheduleFeesEntitySemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (SemSyEntity != null)
                scheduleFeesEntityBindingSource.DataSource = AssessmentManager.GetScheduleFeesSemSy(SemSyEntity.SemSyId);
            Cursor.Current = Cursors.Default;
        }

        private void GetSubjectAndSchedules(int iSemId, int iCourseId, int iYearLevelId, int iSectionId)
        {
            Cursor.Current = Cursors.WaitCursor;
            _listSchedules = ScheduleManager.GetScheduleDetail(iSemId, iCourseId, iYearLevelId, iSectionId);
            dataGridView1.Rows.Clear();
            foreach (var item in _listSchedules)
            {
                dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                       item.ScheduleDetail, item.ScheduleId);
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetSubjectAndSchedulesSaved()
        {
            Cursor.Current = Cursors.WaitCursor;
            //_listSchedules = ScheduleManager.GetScheduleDetail(iSemId, iCourseId, iYearLevelId, iSectionId);
            dataGridView1.Rows.Clear();
            _listSchedules = new List<ScheduleEntity>();
            int iCouter = 0;
            foreach (var item in _listRegisteredSubject)
            {
                if ((item.Dropped == false) || (item.Dropped == null))
                {
                    var s = item;
                    dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                           item.ScheduleDetail, item.ScheduleId, item.RegisteredId, item.Added,
                                           item.Dropped, item.Regular);
                    dataGridView1.Rows[iCouter].DefaultCellStyle.ForeColor = Color.Black;
                    _listSchedules.Add(s);
                }
                else
                {
                    var s = item;
                    dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                           item.ScheduleDetail, item.ScheduleId, item.RegisteredId, item.Added,
                                           item.Dropped, item.Regular);
                    dataGridView1.Rows[iCouter].DefaultCellStyle.ForeColor = Color.Red;
                }
                iCouter++;
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetSubjectAndSchedulesSaved1()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listRegisteredSubject =
                ScheduleManager.GetAllRegisteredSubjectEntity(Convert.ToInt32(RegistrationEntity.RegistrationId));
            dataGridView1.Rows.Clear();
            var iCouter = 0;
            foreach (var item in _listRegisteredSubject)
            {
                if ((item.Dropped == false) || (item.Dropped == null))
                {
                    dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                           item.ScheduleDetail, item.ScheduleId, item.RegisteredId, item.Added,
                                           item.Dropped, item.Regular);
                    dataGridView1.Rows[iCouter].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                           item.ScheduleDetail, item.ScheduleId, item.RegisteredId, item.Added,
                                           item.Dropped, item.Regular);
                    dataGridView1.Rows[iCouter].DefaultCellStyle.ForeColor = Color.Red;
                }
                iCouter++;
            }
            Cursor.Current = Cursors.Default;
        }

        private void ComputeTotalUnits()
        {
            if (_listSchedules != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                tempLec = 0.00;
                tempLab = 0.00;
                tempCre = 0.00;
                foreach (var item in _listSchedules)
                {
                    tempLec += Convert.ToDouble(item.Lecture);
                    tempLab += Convert.ToDouble(item.Laboratory);
                    if (item.Credit > 0)
                    {
                        tempCre += Convert.ToDouble(item.Credit);
                    }
                }
                labelTotalUnits.Text = String.Format(@"{0} - {1} - {2}", tempLec, tempLab, tempCre);
                Cursor.Current = Cursors.Default;
            }
            else
            {
                labelTotalUnits.Text = @"...";
            }
        }

        private void ComputeTotalUnits1()
        {
            if (_listRegisteredSubject != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                tempLec = 0.00;
                tempLab = 0.00;
                tempCre = 0.00;
                foreach (var item in _listRegisteredSubject)
                {
                    if ((item.Dropped == false) || (item.Dropped == null))
                    {
                        tempLec += Convert.ToDouble(item.Lecture);
                        tempLab += Convert.ToDouble(item.Laboratory);
                        if (item.Credit > 0)
                        {
                            tempCre += Convert.ToDouble(item.Credit);
                        }
                    }
                }
                labelTotalUnits.Text = String.Format(@"{0} - {1} - {2}", tempLec, tempLab, tempCre);
                Cursor.Current = Cursors.Default;
            }
            else
            {
                labelTotalUnits.Text = @"...";
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterSubjects();
            dataGridView1.Focus();
        }

        private List<RegisteredSubjectEntity> GetCheckSubjects()
        {
            var tempListSchedules = new List<RegisteredSubjectEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    var tempRegId = 0;
                    tempRegId = row.Cells[7] != null ? Convert.ToInt32(row.Cells[7].Value) : 0;

                    var s = new RegisteredSubjectEntity
                        {
                            ScheduleId = Convert.ToInt32(row.Cells[6].Value),
                            ScheduleCode = row.Cells[1].Value.ToString(),
                            RegisteredId = tempRegId,
                            Regular = Convert.ToBoolean(row.Cells[10].Value),
                            Dropped = Convert.ToBoolean(row.Cells[9].Value),
                            Added = Convert.ToBoolean(row.Cells[8].Value)
                        };
                    tempListSchedules.Add(s);
                }
            }
            return tempListSchedules;
        }

        private void RegisterSubjects()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (RegistrationEntity != null)
            {
                if ((RegistrationEntity.StudentId > 0) && (RegistrationEntity.RegistrationId > 0))
                {
                    var iCounter = 0;
                    var tempList = GetCheckSubjects();
                    foreach (var item in tempList)
                    {
                        var r = new RegisteredSchedule
                            {
                                RegisteredScheduleId = item.RegisteredId,
                                RegistrationId = RegistrationEntity.RegistrationId,
                                ScheduleId = item.ScheduleId,
                                ScheduleCode = item.ScheduleCode,
                                IsRegular = item.Regular,
                                IsAdded = item.Added,
                                IsDropped = item.Dropped,
                                EditedBy = UserEntity.UserFullName
                            };
                        var iResult = Save.RegisteredSchedules(r);
                        if (iResult > 0)
                        {
                            iCounter += 1;
                        }
                    }

                    if (iCounter == tempList.Count)
                    {
                        _operation = true;
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
                        GetSubjectAndSchedulesSaved1();
                        ComputeTotalUnits1();
                        dataGridView2.Rows.Clear();
                        //GetAssessmentComputed();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (RegistrationEntity != null)
            //{
            //    GetSubjectAndSchedules(Convert.ToInt32(RegistrationEntity.SemSyId),
            //                           Convert.ToInt32(RegistrationEntity.CourseId),
            //                           Convert.ToInt32(RegistrationEntity.YearLevelId),
            //                           Convert.ToInt32(RegistrationEntity.SectionId));

            //    ComputeTotalUnits();
            //    //GetAssessmentComputed1();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_choice)
            {
                case 0:
                    if (dataGridView1.CurrentRow != null)
                    {
                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) > 0)
                        {
                            RemoveScheduleRegistered();
                            ComputeTotalUnits1();
                        }
                        else if ((dataGridView1.CurrentRow.Cells[7].Value == null) || (Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) == 0))
                        {
                            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                            {
                                if (selectedRow.Cells[6].Value != null)
                                    _listSchedules.RemoveAt(selectedRow.Index);
                                dataGridView1.Rows.Remove(selectedRow);
                            }
                            ComputeTotalUnits();
                        }
                    }
                    break;
                case 1:
                    if (dataGridView2 != null)
                    {
                        RemoveAssessedFees();
                        ComputeTotalAssessment();
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

        private void RemoveScheduleRegistered()
        {
            Cursor.Current = Cursors.WaitCursor;
            var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
            if (dResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    var iRegisteredScheduleId = Convert.ToInt32(selectedRow.Cells[7].Value);
                    if (Remove.RegisteredSchedules(iRegisteredScheduleId))
                    {
                        _listRegisteredSubject.RemoveAt(selectedRow.Index);
                        dataGridView1.Rows.Remove(selectedRow);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void RemoveAssessedFees()
        {
            Cursor.Current = Cursors.WaitCursor;
            var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
            if (dResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
                {
                    if (Convert.ToInt32(selectedRow.Cells[7].Value) > 0)
                    {
                        var iAssessedId = Convert.ToInt32(selectedRow.Cells[7].Value);
                        if (Remove.Assessment(iAssessedId))
                        {
                            _listAssessedEntity.RemoveAt(selectedRow.Index);
                            dataGridView2.Rows.Remove(selectedRow);
                        }
                    }
                    else
                    {
                        _listAssessedEntity.RemoveAt(selectedRow.Index);
                        dataGridView2.Rows.Remove(selectedRow);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (_editCell)
                {
                    var subjectSchedule = ScheduleManager.GetScheduleDetailByCode(e.FormattedValue.ToString());
                    if (subjectSchedule != null)
                    {
                        if (!CheckDuplicateSubjects(subjectSchedule.ScheduleId))
                        {
                            if ((dataGridView1.CurrentRow != null) && ((dataGridView1.CurrentRow.Cells[1].Value != null) || (Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) > 0)))
                            {
                                dataGridView1.CurrentRow.Cells[0].Value = true;
                                dataGridView1.CurrentRow.Cells[2].Value = subjectSchedule.SubjectCode;
                                dataGridView1.CurrentRow.Cells[3].Value = subjectSchedule.SubjectName;
                                dataGridView1.CurrentRow.Cells[4].Value = subjectSchedule.Units;
                                dataGridView1.CurrentRow.Cells[5].Value = subjectSchedule.ScheduleDetail;
                                dataGridView1.CurrentRow.Cells[6].Value = subjectSchedule.ScheduleId;
                                dataGridView1.CurrentRow.Cells[7].Value = 0;
                                dataGridView1.CurrentRow.Cells[8].Value = false;
                                dataGridView1.CurrentRow.Cells[9].Value = false;
                                dataGridView1.CurrentRow.Cells[10].Value = true;
                                _listSchedules.Add(subjectSchedule);
                            }
                        }
                        else
                        {
                            var subjectLabel = String.Format(@"{0} - {1} {2} ( {3} ) is already in the list of subject(s).",
                                                             subjectSchedule.ScheduleId, subjectSchedule.SubjectCode,
                                                             subjectSchedule.SubjectName, subjectSchedule.Units);
                            UtilityManager.util.UtilClass.ShowCutsomMessageBox(subjectLabel);
                            dataGridView1.Focus();
                        }
                    }
                    _editCell = false;
                }
                ComputeTotalUnits();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _editCell = e.ColumnIndex == 1;
        }

        private void buttonF10_Click(object sender, EventArgs e)
        {
            ReloadEnrolledItems();
            //GetAssessmentComputed1();
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            GetRegistrationCertificate();
        }

        private void GetRegistrationCertificate()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (toolStripTextBox1.Text.Length > 0)
            {
                registrationEntityBindingSource.DataSource =
                    ObjectQueries.GetStudentRegistrationCeritficate(toolStripTextBox1.Text, SemSyEntity.SemSyId);
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (registrationEntityBindingSource.Current != null)
            {
                var item = ((RegistrationEntity) registrationEntityBindingSource.Current);
                if ((item.Paid == false) || (item.Paid == null))
                {
                    var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                    if (dResult == DialogResult.Yes)
                    {
                        if (Remove.Registrations(Convert.ToInt32(item.RegistrationId)))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            registrationEntityBindingSource.RemoveCurrent();
                        }
                    }
                }
                else
                {
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(@"You are not allowed to delete this record. Thank you.");
                    registrationEntityDataGridView.Focus();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetRegistrationCertificate();
            }
        }

        private void buttonAssessment_Click(object sender, EventArgs e)
        {
            GetAssessmentComputed();
            dataGridView2.Focus();

            buttonAssessment.Enabled = true;
            buttonSaveAssessment.Enabled = true;
            button1.Enabled = true;
            //ReloadEnrolledItems();
        }

        private void SaveAssessment()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_listAssessedEntity != null)
            {
                var iCounter = 0;
                foreach (var item in _listAssessedEntity)
                {
                    var a = new Assessment
                        {
                            AssessmentId = item.AssessmentId,
                            Amount = Convert.ToDecimal(item.Amount),
                            AddAmount = Convert.ToDecimal(item.AddAmount),
                            Less = Convert.ToDecimal(item.Less),
                            AddLess = Convert.ToDecimal(item.AddLess),
                            PercentLess = Convert.ToDouble(item.PercentLess),
                            NetAmount = Convert.ToDecimal(item.NetAmount),
                            GrossAmount = Convert.ToDecimal(item.GrossAmount),
                            IsOriginal = true,
                            FeeParticularId = item.FeeParticularId,
                            RegistrationId = RegistrationEntity.RegistrationId
                        };
                    var iResult = Save.Assessment(a);
                    if (iResult > 0)
                    {
                        var a1 = _listLaboratoryFeesEntities.Find(f => f.FeeParticularId == a.FeeParticularId);
                        if (a1 != null)
                        {
                            var alab = new AssessmentLaboratory
                                {
                                    AssessmentLaboratoryId = 0,
                                    LaboratoryFeeId = a1.LaboratoryFeeId,
                                    SubjectId = item.SubjectId,
                                    LaboratoryName = item.Particulars,
                                    Amount = a1.Amount,
                                    AssessmentId = a.AssessmentId
                                };
                            var iResult1 = Save.AssessmentLaboratory(alab);
                            if (iResult1 > 0)
                            {
                                iCounter += 1;
                            }
                        }
                    }
                }
                if (iCounter > 0)
                {
                    UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAssessmentComputed()
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView2.Rows.Clear();
            if (RegistrationEntity != null)
            {
                _listAssessedEntity =
                    AssessmentManager.GetAssessedEntityByRegistrationId(
                        Convert.ToInt32(RegistrationEntity.RegistrationId));
                if (_listAssessedEntity != null)
                {
                    if (_listAssessedEntity.Count > 0)
                    {
                        ComputeTotalUnits1();
                        var listAssessedEntity = AssessmentManager.GetAssessEntity(SemSyEntity.SemSyId,
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.CourseId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.YearLevelId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.ScholarshipId),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId1),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId2),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.RegistrationId),
                                                                                   tempCre, _listRegisteredSubject);

                        foreach (var item in listAssessedEntity)
                        {
                            AssessEntity assessedItem;
                            if (item.SubjectId > 0)
                                assessedItem =
                                    _listAssessedEntity.Find(
                                        f =>
                                        (f.FeeParticularId == item.FeeParticularId) &&
                                        (f.SubjectId == item.SubjectId));
                            else
                            {
                                assessedItem =
                                    _listAssessedEntity.Find(f => f.FeeParticularId == item.FeeParticularId);
                            }

                            if (assessedItem != null)
                            {
                                if (Convert.ToBoolean(assessedItem.IsTuition))
                                {
                                    assessedItem.GrossAmount = item.GrossAmount;
                                    assessedItem.NetAmount = item.NetAmount;
                                    assessedItem.PercentLess = item.PercentLess;
                                    assessedItem.Less = item.Less;
                                    assessedItem.SubjectId = item.SubjectId;
                                    if (assessedItem.LabParticulars != null)
                                        assessedItem.Particulars = (item.Particulars.Length > 0
                                                                        ? item.Particulars
                                                                        : assessedItem.LabParticulars);
                                    else
                                    {
                                        assessedItem.Particulars = (item.Particulars.Length > 0
                                                                        ? item.Particulars
                                                                        : assessedItem.Particulars);
                                    }
                                }
                                else
                                {
                                    assessedItem.SubjectId = item.SubjectId;
                                    assessedItem.GrossAmount = item.GrossAmount;
                                    assessedItem.NetAmount = item.NetAmount;
                                    assessedItem.PercentLess = item.PercentLess;
                                    assessedItem.Less = item.Less;
                                    if (assessedItem.LabParticulars != null)
                                        assessedItem.Particulars = (item.Particulars.Length > 0
                                                                        ? item.Particulars
                                                                        : assessedItem.LabParticulars);
                                    else
                                    {
                                        assessedItem.Particulars = (item.Particulars.Length > 0
                                                                        ? item.Particulars
                                                                        : assessedItem.Particulars);
                                    }
                                }
                            }
                            else
                            {
                                assessedItem = item;
                                assessedItem.AssessmentId = 0;
                                assessedItem.GrossAmount = item.GrossAmount;
                                assessedItem.NetAmount = item.NetAmount;
                                assessedItem.PercentLess = item.PercentLess;
                                assessedItem.Less = item.Less;
                                assessedItem.SubjectId = item.SubjectId;
                                if (assessedItem.LabParticulars != null)
                                    assessedItem.Particulars = item.Particulars.Length > 0
                                                                   ? item.Particulars
                                                                   : assessedItem.LabParticulars;
                                else
                                {
                                    assessedItem.Particulars = (item.Particulars.Length > 0
                                                                    ? item.Particulars
                                                                    : assessedItem.Particulars);
                                }
                                _listAssessedEntity.Add(assessedItem);
                            }
                        }
                    }
                    else
                    {
                        ComputeTotalUnits1();
                        _listAssessedEntity = AssessmentManager.GetAssessEntity(SemSyEntity.SemSyId,
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.CourseId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.YearLevelId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.ScholarshipId),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId1),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId2),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.RegistrationId),
                                                                                   tempCre, _listRegisteredSubject);
                    }
                }
                else
                {
                    ComputeTotalUnits1();
                    _listAssessedEntity = AssessmentManager.GetAssessEntity(SemSyEntity.SemSyId,
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.CourseId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.YearLevelId),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.ScholarshipId),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId1),
                                                                                   Convert.ToInt32(RegistrationEntity.ScholarshipId2),
                                                                                   Convert.ToInt32(
                                                                                       RegistrationEntity.RegistrationId),
                                                                                   tempCre, _listRegisteredSubject);
                }

                foreach (var item in _listAssessedEntity)
                {
                    var labPartiulars = String.Format(@" - {0}", item.LabParticulars);
                    dataGridView2.Rows.Add(item.Particulars + labPartiulars, item.Amount, item.GrossAmt, item.PercentLess, item.Less,
                                               item.NetAmount, item.FeeParticularId, item.AssessmentId);
                }
                ComputeTotalAssessment();
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAssessmentComputed1()
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView2.Rows.Clear();
            if (RegistrationEntity != null)
            {
                _listAssessedEntity =
                    AssessmentManager.GetAssessedEntityByRegistrationId(
                        Convert.ToInt32(RegistrationEntity.RegistrationId));

                foreach (var item in _listAssessedEntity)
                {
                    var labPartiulars = String.Format(@" - {0}", item.LabParticulars);
                    dataGridView2.Rows.Add(item.Particulars + labPartiulars, item.Amount, item.GrossAmt, item.PercentLess, item.Less,
                                               item.NetAmount, item.FeeParticularId, item.AssessmentId);
                }
                ComputeTotalAssessment();
            }
            Cursor.Current = Cursors.Default;
        }

        //private void GetAssessmentComputed1()
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    dataGridView2.Rows.Clear();
        //    if (RegistrationEntity != null)
        //    {
        //        _listAssessedEntity = AssessmentManager.GetAssessEntity(SemSyEntity.SemSyId,
        //                                                                Convert.ToInt32(RegistrationEntity.CourseId),
        //                                                                Convert.ToInt32(RegistrationEntity.YearLevelId),
        //                                                                Convert.ToInt32(RegistrationEntity.ScholarshipId),
        //                                                                Convert.ToInt32(
        //                                                                    RegistrationEntity.RegistrationId),
        //                                                                tempCre, _listSchedules);

        //        foreach (var item in _listAssessedEntity)
        //        {
        //            dataGridView2.Rows.Add(item.Particulars, item.Amount, item.GrossAmt, item.PercentLess, item.Less,
        //                                   item.NetAmount);
        //        }
        //        ComputeTotalAssessment();
        //    }
        //    Cursor.Current = Cursors.Default;
        //}

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    buttonRegister.Enabled = true;
                    button4.Enabled = true;
                    buttonAssessment.Enabled = false;
                    buttonSaveAssessment.Enabled = false;
                    buttonF10.Enabled = true;
                    buttonPrint.Enabled = true;
                    _choice = 0;
                    break;
                case 1:
                    buttonRegister.Enabled = false;
                    button4.Enabled = false;
                    buttonAssessment.Enabled = true;
                    buttonSaveAssessment.Enabled = true;
                    buttonF10.Enabled = true;
                    buttonPrint.Enabled = true;
                    _choice = 1;
                    break;
                case 2:
                    buttonRegister.Enabled = false;
                    button4.Enabled = false;
                    buttonAssessment.Enabled = false;
                    _choice = 2;
                    break;
                default:
                    break;
            }
        }

        private void ComputeTotalAssessment()
        {
            Cursor.Current = Cursors.WaitCursor;
            _grossAmount = 0.00;
            _lessAmount = 0.00;
            _netAmount = 0.00;
            foreach (var item in _listAssessedEntity)
            {
                _grossAmount += Convert.ToDouble(item.GrossAmt);
                _lessAmount += Convert.ToDouble(item.Deduction);
                _netAmount += Convert.ToDouble(item.NetAmt);
            }
            labelGross.Text = String.Format(@"{0:#,##0.00}", _grossAmount);
            labelLess.Text = String.Format(@"{0:#,##0.00}", _lessAmount);
            labelNet.Text = String.Format(@"{0:#,##0.00}", _netAmount);
            Cursor.Current = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            SaveAssessment();
            buttonAssessment.Enabled = true;
            buttonSaveAssessment.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == @"Hide Schedule")
            {
                splitContainer1.SplitterDistance = 0;
                linkLabel1.Text = @"Show Schedule";
                comboBox1.Visible = false;
                labelCollege.Visible = false;
                buttonClear.Visible = false;
                buttonSelectAll.Visible = false;
                buttonAddSubject.Visible = false;
                p1.Visible = false;
                labelLimit.Visible = false;
            }
            else
            {
                splitContainer1.SplitterDistance = 200;
                linkLabel1.Text = @"Hide Schedule";
                comboBox1.Visible = true;
                labelCollege.Visible = true;
                buttonClear.Visible = true;
                buttonSelectAll.Visible = true;
                buttonAddSubject.Visible = true;
                p1.Visible = true;
                labelLimit.Visible = true;
                if (Branch != null)
                {
                    GetAllColleges(Branch.BranchId);
                    //comboBox1.SelectedIndex = collegeBindingSource.Find("CollegeId", College.CollegeId);
                    //collegeBindingSource.List.Insert(0, @"--- Select ---");
                    //comboBox1.SelectedIndex = comboBox1.Items.IndexOf(College.CollegeId);
                }
            }
        }

        //edited by josh 11.13.13

        #region Schedules

        private void GetAllColleges(int iBranchId)
        {
            Cursor.Current = Cursors.WaitCursor;
            collegeBindingSource.DataSource = ObjectQueries.GetAllColleges(iBranchId);
            Cursor.Current = Cursors.Default;
        }

        private void GetAllCollegesCrsYrSecSchedule(int iCollegeId)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (SemSyEntity != null)
            {
                courseSecScheduleEntityBindingSource.DataSource =
                    ScheduleManager.GetAllCourseSecScheduleEntity(iCollegeId, SemSyEntity.SemSyId);
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSchedules(int iCrsYearSecId)
        {
            Cursor.Current = Cursors.WaitCursor;
            scheduleEntityBindingSource.DataSource = ScheduleManager.GetScheduleDetail(iCrsYearSecId);
            Cursor.Current = Cursors.Default;
        }

        private void collegeBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (collegeBindingSource.Current != null)
            {
                var collegeId = ((College) collegeBindingSource.Current).CollegeId;
                if (collegeId > 0)
                {
                    GetAllCollegesCrsYrSecSchedule(collegeId);
                }
            }
        }

        private void courseSecScheduleEntityBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (courseSecScheduleEntityBindingSource.Current != null)
            {
                var courseSchedId =
                    ((CourseSecScheduleEntity)courseSecScheduleEntityBindingSource.Current).CourseSecScheduleEntityId;
                if (courseSchedId > 0)
                {
                    GetAllSchedules(courseSchedId);
                }
            }
        }

        private void scheduleEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (scheduleEntityBindingSource.Current != null)
            {
                _noOfRegistered = 0;
                var schedule = (ScheduleEntity)scheduleEntityBindingSource.Current;
                if (schedule != null)
                {
                    _noOfRegistered = ScheduleManager.GetRegisteredStudentsBySchedule(schedule.ScheduleId);
                    _noOfLimit = Convert.ToInt32(schedule.StudentLimit) + Convert.ToInt32(schedule.StudentAdded);
                    var text = String.Format(@"{0}/{1}", _noOfRegistered, _noOfLimit);
                    p1.Text = text;
                    if (_noOfRegistered > _noOfLimit)
                        _noOfRegistered = _noOfLimit;
                    p1.Maximum = _noOfLimit;
                    p1.Value = _noOfRegistered;
                    p1.Style = ProgressBarStyle.Continuous;
                    labelLimit.Text = text;
                }
            }
        }
        #endregion

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (RegistrationEntity != null)
            {
                using (var f = new ReportCertificateRegistrationForm())
                {
                    f.RegistrationEntity = RegistrationEntity;
                    f.ListRegisteredSubjectEntity = _listRegisteredSubject;
                    f.ListAssessEntity = _listAssessedEntity;
                    f.RegistrationEntity = RegistrationEntity;
                    f.UserEntity = UserEntity;
                    f.SemSyEntity = SemSyEntity;
                    f.Branch = Branch;
                    f.ShowDialog();
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            SelectAllSubjectsCrsYrSec();
        }

        private void SelectAllSubjectsCrsYrSec()
        {
            if (scheduleEntityDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleEntityDataGridView.Rows)
                {
                    //row.Selected = true;
                    row.Cells[0].Value = true;
                }
            }
        }

        private void SelectAllFees()
        {
            if (scheduleFeesEntityDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleFeesEntityDataGridView.Rows)
                {
                    //row.Selected = true;
                    row.Cells[0].Value = true;
                }
            }
        }

        private void ClearSelectedSubjectsCrsYrSec()
        {
            if (scheduleEntityDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleEntityDataGridView.Rows)
                {
                    //row.Selected = true;
                    row.Cells[0].Value = false;
                }
            }
        }

        private void ClearAllFees()
        {
            if (scheduleFeesEntityDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleFeesEntityDataGridView.Rows)
                {
                    //row.Selected = true;
                    row.Cells[0].Value = false;
                }
            }
        }

        private void scheduleEntityDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(e.FormattedValue))
                {
                    if (scheduleEntityDataGridView.CurrentRow != null)
                    {
                        var subjectSchedule = (ScheduleEntity)scheduleEntityDataGridView.CurrentRow.DataBoundItem;
                        if (subjectSchedule != null)
                        {
                            scheduleEntityDataGridView.CurrentRow.Selected = true;
                            
                        }
                        
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearSelectedSubjectsCrsYrSec();
        }

        private void buttonAddSubject_Click(object sender, EventArgs e)
        {
            var subjectLabel = new StringBuilder();
            var iCounter = 0;
            if (scheduleEntityDataGridView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in scheduleEntityDataGridView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        var schedule = (ScheduleEntity) row.DataBoundItem;
                        if (schedule != null)
                        {
                            if (!CheckDuplicateSubjects(schedule.ScheduleId))
                            {
                                dataGridView1.Rows.Add(true, schedule.ScheduleCode, schedule.SubjectCode,
                                                   schedule.SubjectName, schedule.Units, schedule.ScheduleDetail,
                                                   schedule.ScheduleId, 0);
                                if (_listSchedules != null)
                                    _listSchedules.Add(schedule);

                                ComputeTotalUnits();
                            }
                            else
                            {
                                var tempSubject = String.Format(@"{0} - {1} {2} ( {3} )", schedule.ScheduleId,
                                                                schedule.SubjectCode, schedule.SubjectName,
                                                                schedule.Units);
                                subjectLabel.AppendLine(tempSubject);
                                subjectLabel.AppendLine();
                                
                                iCounter += 1;
                            }
                        }
                    }
                }

                if (iCounter > 0)
                {
                    subjectLabel.AppendLine(@"are/is already in the list of subject(s).");
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(subjectLabel.ToString());
                }
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button5.Enabled = true;
            buttonRegister.Enabled = true;
            buttonF10.Enabled = true;
            buttonPrint.Enabled = true;
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            button1.Enabled = true;
            buttonAssessment.Enabled = true;
            buttonSaveAssessment.Enabled = true;
            buttonF10.Enabled = true;
            buttonPrint.Enabled = true;
        }

        private void dataGridView2_Leave(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text == @"Show Fees")
            {
                splitContainer3.SplitterDistance = 200;
                linkLabel2.Text = @"Hide Fees";
                GetScheduleFeesEntitySemSy();
                buttonClearSelectedFees.Visible = true;
                buttonSelectAllFees.Visible = true;
                buttonAddFees.Visible = true;
            }
            else
            {
                splitContainer3.SplitterDistance = 0;
                linkLabel2.Text = @"Show Fees";
                buttonClearSelectedFees.Visible = false;
                buttonSelectAllFees.Visible = false;
                buttonAddFees.Visible = false;
            }
        }

        private void buttonClearSelectedFees_Click(object sender, EventArgs e)
        {
            ClearAllFees();
        }

        private void scheduleFeesEntityDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(e.FormattedValue))
                {
                    if (scheduleFeesEntityDataGridView.CurrentRow != null)
                        scheduleFeesEntityDataGridView.CurrentRow.Selected = true;
                }
            }
        }

        private void buttonSelectAllFees_Click(object sender, EventArgs e)
        {
            SelectAllFees();
        }

        private void buttonAddFees_Click(object sender, EventArgs e)
        {
            if (scheduleFeesEntityDataGridView.SelectedRows.Count > 0)
            {
                var stringFees = new StringBuilder();
                var iCounter = 0;
                foreach (DataGridViewRow row in scheduleFeesEntityDataGridView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        var schedule = (ScheduleFeesEntity)row.DataBoundItem;
                        if (schedule != null)
                        {
                            //if (CheckDuplicateFees(schedule.FeeParticularId) != true)
                            //{
                                var percentage = GetAssessEntityWithDeduction(schedule.FeeParticularId);
                                var assess = new Assessment
                                    {
                                        Amount = schedule.Amount,
                                        PercentLess = Convert.ToDouble(percentage),
                                        Less = Convert.ToDecimal(schedule.Amount)*(percentage/100),
                                        GrossAmount = schedule.Amount,
                                        NetAmount =
                                            schedule.Amount - Convert.ToDecimal(schedule.Amount)*(percentage/100),
                                        IsOriginal = true,
                                        AssessmentId = 0,
                                        FeeParticularId = schedule.FeeParticularId,
                                        RegistrationId = RegistrationEntity.RegistrationId
                                    };
                                var iResult = Save.Assessment(assess);
                                if (iResult > 0)
                                {
                                    ReloadEnrolledItems();
                                    dataGridView2.Focus();
                                }
                            //}
                            //else
                            //{
                            //    iCounter += 1;
                            //    var tempFeeDescription = schedule.Particulars +  '\t' + '\t' + '\t' + @" - " + String.Format(@"{0:#,##0.00}", schedule.Amount);
                            //    stringFees.AppendLine(tempFeeDescription);
                            //    stringFees.AppendLine();
                            //}
                        }
                    }
                }
                if (iCounter > 0)
                {
                    stringFees.AppendLine(@"are/is already in the list of fees.");
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(stringFees.ToString());
                    scheduleEntityDataGridView.Select();
                    scheduleEntityDataGridView.Focus();
                }
                
                ComputeTotalAssessment();
            }
        }

        private decimal GetAssessEntityWithDeduction(int iFeeParticularId)
        {
            decimal percentage = 0;
            if (RegistrationEntity != null)
            {
                var scholaships = AssessmentManager.GetScholarshipFees(Convert.ToInt32(RegistrationEntity.ScholarshipId));
                if (scholaships.Count > 0)
                    try
                    {
                        percentage =
                            Convert.ToDecimal(scholaships.Find(f => f.FeeParticularId == iFeeParticularId).Percentage);
                    }
                    catch (Exception ex)
                    {
                        percentage = 0;
                    }
                else
                {
                    percentage = 0;
                }
            }
            return percentage;
        }

        private void RegistrationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        #region Validation
        private bool CheckDuplicateFees(int iFeeParticularId)
        {
            var bResult = false;
            var iCounter = 0;
            iCounter += dataGridView2.Rows.Cast<DataGridViewRow>().Count(row1 => Convert.ToInt32(row1.Cells[6].Value) == iFeeParticularId);

            if (iCounter > 0)
                bResult = true;

            return bResult;
        }

        private bool CheckDuplicateSubjects(int iScheduleId)
        {
            var bResult = false;
            var iCounter = 0;
            iCounter += dataGridView1.Rows.Cast<DataGridViewRow>().Count(row1 => Convert.ToInt32(row1.Cells[6].Value) == iScheduleId);

            if (iCounter > 0)
                bResult = true;

            return bResult;
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.ColumnIndex == 1)
           {
               if (dataGridView1.CurrentRow != null)
               {
                   var cell = dataGridView1.CurrentRow.Cells[1];
                   dataGridView1.CurrentCell = cell;
                   dataGridView1.BeginEdit(true);
               }
           }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        private void registrationEntityDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                buttonUpdate.PerformClick();
            }
        }

        private void buttonDropChange_Click(object sender, EventArgs e)
        {
            _addDropForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _addDropForm.StartPosition = FormStartPosition.CenterScreen;
            _addDropForm.MaximizeBox = false;
            _addDropForm.MinimizeBox = false;
            _addDropForm.RegistrationEntities = _listRegisteredSubject;
            if (_addDropForm.ShowDialog() == DialogResult.OK)
            {
                if (_listRegisteredSubject != null)
                {
                    GetSubjectAndSchedulesSaved();
                    ComputeTotalUnits();
                }
            }
        }
    }
}