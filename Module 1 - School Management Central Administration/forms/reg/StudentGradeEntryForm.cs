using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.managers.man;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class StudentGradeEntryForm : Form
    {
        public PostGrade PostGrade { get; set; }

        private List<TeacherEntity> _listTeachers;
        private List<GradeBaseValue> _listGradeBaseValue;  
        private GradingPeriod _g;

        private int _semSyId;
        private int _scheduleId;
        private int _teacherSubjectId;
        private static int _clickCounter;

        private PostGradeForm _postGradeForm;
        public StudentGradeEntryForm()
        {
            _postGradeForm = new PostGradeForm(this);
            InitializeComponent();
        }

        private void StudentGradeEntryForm_Load(object sender, EventArgs e)
        {
            GetAllSemSy(); //load all semsy
            GetAllTeachers(); //load all teachers
            GetGradeBaseDefault(); //get grade base

            _g = ObjectQueries.GetGradingPeriod();
            if (_g != null)
            {
                ShowGridViewGradeColumn();
            }
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lTeachers = ObjectQueries.GetAllTeachers(waterMarkTextBox1.Text);
            if (lTeachers.Count > 0)
            {
                foreach (var teacher in lTeachers)
                {
                    var nodeParentParent = new TreeNode(teacher.FullName) {Name = "Teacher", Tag = teacher};

                    var lSubjects = AcademicQueries.GetAllTeacherSubjects(teacher.TeacherId, 2, _semSyId);
                    foreach (var subject in lSubjects)
                    {
                        var tempLabel = String.Format(@"{0} - {1}", subject.SubjectNo,
                                                      subject.SubjectDescriptiveTitle);
                        var nodeParent = new TreeNode(tempLabel) {Name = "Subject", Tag = subject};

                        nodeParentParent.Nodes.Add(nodeParent);
                    }
                    treeView1.Nodes.Add(nodeParentParent);
                }
            }
            else
            {
                treeView1.Nodes.Clear();
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSubjectSchedules()
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectEntityBindingSource.DataSource =
                AcademicQueries.GetAllSubjectByCriteria(waterMarkTextBoxSubjects.Text, _semSyId);
            Cursor.Current = Cursors.Default;
        }

        private void PopulateGridView(int iSemYr, int iScheduleId)
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectStudentEntityBindingSource.DataSource = AcademicQueries.GetAllStudentBySubject(iSemYr, iScheduleId);
            
            ShowGridViewGradeColumn();
            Cursor.Current = Cursors.Default;
        }

        private void ShowGridViewGradeColumn()
        {
            if (_g != null)
            {
                if (_g.FirstGradingActive == true)
                {
                    var first = dataGridView1.Columns["FirstGrade"];
                    if (first != null)
                    {
                        first.Visible = true;
                        first.HeaderText = _g.FirstGrading;
                        first.Width = 80;
                    }
                }
                else
                {
                    var first = dataGridView1.Columns["FirstGrade"];
                    if (first != null)
                        first.Visible = false;
                }
                if (_g.SecondGradingActive == true)
                {
                    var second = dataGridView1.Columns["SecondGrade"];
                    if (second != null)
                    {
                        second.Visible = true;
                        second.HeaderText = _g.SecondGrading;
                        second.Width = 80;
                    }
                }
                else
                {
                    var second = dataGridView1.Columns["SecondGrade"];
                    if (second != null)
                        second.Visible = false;
                }
                if (_g.ThirdGradingActive == true)
                {
                    var third = dataGridView1.Columns["ThirdGrade"];
                    if (third != null)
                    {
                        third.Visible = true;
                        third.HeaderText = _g.ThirdGrading;
                        third.Width = 80;
                    }
                }
                else
                {
                    var third = dataGridView1.Columns["ThirdGrade"];
                    if (third != null)
                        third.Visible = false;
                }
                if (_g.FourthGradingActive == true)
                {
                    var fourth = dataGridView1.Columns["FourthGrade"];
                    if (fourth != null)
                    {
                        fourth.Visible = true;
                        fourth.HeaderText = _g.FourthGrading;
                        fourth.Width = 80;
                    }
                }
                else
                {
                    var fourth = dataGridView1.Columns["FourthGrade"];
                    if (fourth != null)
                        fourth.Visible = false;
                }
                if (_g.FifthGradingActive == true)
                {
                    var fifth = dataGridView1.Columns["FifthGrade"];
                    if (fifth != null)
                    {
                        fifth.Visible = true;
                        fifth.HeaderText = _g.FifthGrading;
                        fifth.Width = 80;
                    }
                }
                else
                {
                    var fifth = dataGridView1.Columns["FifthGrade"];
                    if (fifth != null)
                        fifth.Visible = false;
                }
                if (_g.SixthGradingActive == true)
                {
                    var sixth = dataGridView1.Columns["SixthGrade"];
                    if (sixth != null)
                    {
                        sixth.Visible = true;
                        sixth.HeaderText = _g.SixthGrading;
                        sixth.Width = 80;
                    }
                }
                else
                {
                    var sixth = dataGridView1.Columns["SixthGrade"];
                    if (sixth != null)
                        sixth.Visible = false;
                }
            }
        }

        private void SaveGrades()
        {
            Cursor.Current = Cursors.WaitCursor;
            var iCounter = 0;
            foreach (SubjectStudentEntity entity in subjectStudentEntityBindingSource.List)
            {
                Validate();
                var r = new RegisteredSchedule
                    {
                        RegisteredScheduleId = Convert.ToInt32(entity.RegisterdSubjectId),
                        FirstGrading = entity.FirstGrade,
                        SecondGrading = entity.SecondGrade,
                        ThirdGrading = entity.ThirdGrade,
                        FourthGrading = entity.FourthGrade,
                        FifthGrading = entity.FifthGrade,
                        SixthGrading = entity.SixthGrade,
                        Remark = entity.Remarks,
                        IsPosted = entity.Posted,
                        IsPostEdited = entity.PostEdited,
                        PostedDate = entity.PostedDate, 
                        PostEditedDate = entity.PostEditedDate,
                        EditedBy = entity.EditedBy,
                        IsAdded = entity.Added,
                        IsRegular = entity.Regular,
                        IsDropped = entity.Dropped,
                        ScheduleCode = entity.ScheduleCode,
                        ScheduleId = entity.ScheduleId,
                        RegistrationId = entity.RegistrationId
                    };
                if (Save.RegisteredSchedules(r) > 0)
                {
                    iCounter += 1;
                }
            }
            if (subjectStudentEntityBindingSource.List.Count == iCounter)
            {
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
            }
            Cursor.Current = Cursors.Default;
        }

        private void SavePostGrade()
        {
            Cursor.Current = Cursors.WaitCursor;
            var iCounter = 0;
            var iiCounter = 0;
            foreach (SubjectStudentEntity entity in subjectStudentEntityBindingSource.List)
            {
                Validate();
                if (entity.Posted == true)
                {
                    iiCounter += 1;
                    var r = new RegisteredSchedule
                        {
                            RegisteredScheduleId = Convert.ToInt32(entity.RegisterdSubjectId),
                            FirstGrading = entity.FirstGrade,
                            SecondGrading = entity.SecondGrade,
                            ThirdGrading = entity.ThirdGrade,
                            FourthGrading = entity.FourthGrade,
                            FifthGrading = entity.FifthGrade,
                            SixthGrading = entity.SixthGrade,
                            Remark = entity.Remarks,
                            IsPosted = entity.Posted,
                            IsPostEdited = entity.PostEdited,
                            PostedDate = entity.PostedDate,
                            PostEditedDate = entity.PostEditedDate,
                            EditedBy = entity.EditedBy,
                            IsAdded = entity.Added,
                            IsRegular = entity.Regular,
                            IsDropped = entity.Dropped,
                            ScheduleCode = entity.ScheduleCode,
                            ScheduleId = entity.ScheduleId,
                            RegistrationId = entity.RegistrationId
                        };
                    if (Save.RegisteredSchedules(r) > 0)
                    {
                        iCounter += 1;
                    }

                }
            }

            if (iiCounter == iCounter)
            {
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
            }

            Cursor.Current = Cursors.Default;
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (semSyEntityBindingSource.Current != null)
            {
                _semSyId = Convert.ToInt32(((SemSyEntity) semSyEntityBindingSource.Current).SemSyId);
                if (_semSyId > 0)
                {
                    PopulateGridView(_semSyId, _scheduleId);
                }
            }
        }

        private void waterMarkTextBoxSubjects_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if ((waterMarkTextBoxSubjects.Text.Length > 0) && (_semSyId > 0))
                    {
                        GetAllSubjectSchedules(); //load subject & schedules
                    }
                    break;
                case Keys.Escape:
                    break;
                default: break;
            }
        }

        private void subjectEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (subjectEntityBindingSource.Current != null)
            {
                _scheduleId = Convert.ToInt32(((SubjectEntity) subjectEntityBindingSource.Current).ScheduleId);
                if ((_semSyId > 0) && (_scheduleId > 0))
                {
                    PopulateGridView(_semSyId, _scheduleId);
                    FormatDisplaySubjectInfo(_scheduleId);
                    
                }
            }
        }

        private void GetAllTeachers()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listTeachers = ObjectQueries.GetAllTeachers();
            Cursor.Current = Cursors.Default;
        }

        private void waterMarkTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (waterMarkTextBox1.Text.Length > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        FillTreeview();
                        break;
                    case Keys.Escape:
                        break;
                    default:
                        break;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Teacher": break;
                case "Subject":
                    if (e.Node.Tag != null)
                    {
                        _scheduleId = Convert.ToInt32(((TeacherSubjectEntity) e.Node.Tag).ScheduleId);
                        if ((_semSyId > 0) && (_scheduleId > 0))
                        {
                            PopulateGridView(_semSyId, _scheduleId);
                            FormatDisplaySubjectInfo(_scheduleId);
                        }    
                    }
                    break;
                default: break;
            }
        }

        private void subjectStudentEntityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            if (ValidateEntries() == false)
            {
                SaveGrades();    
            }
            else
            {
                MessageBox.Show(@"Please check all errors before saving.", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            Cursor.Current = Cursors.Default; 
        }

        private void GetGradeBaseDefault()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listGradeBaseValue = AcademicQueries.GetGradeBaseDefault();
            gradeBaseValueBindingSource.DataSource = _listGradeBaseValue;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonPost_Click(object sender, EventArgs e)
        {
            if (_teacherSubjectId > 0)
            {
                _postGradeForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                _postGradeForm.StartPosition = FormStartPosition.CenterScreen;
                _postGradeForm.MinimizeBox = false;
                _postGradeForm.MaximizeBox = false;
                _postGradeForm.TeacherSubjectId = _teacherSubjectId;
                if (_postGradeForm.ShowDialog() == DialogResult.OK)
                {
                    if (PostGrade != null)
                    {
                        if (PostGradeManager.Save(PostGrade) > 0)
                        {
                            //SavePostGrade();
                            SaveGrades();
                        }
                    }
                }
            }
        }

        private GradeBaseValue CheckGradeBaseValid(string value)
        {
            var q = _listGradeBaseValue.FirstOrDefault(o => o.GradeBaseValueEqui == value);
            return q;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private bool ValidateEntries()
        {
            Cursor.Current = Cursors.WaitCursor;
            //foreach (SubjectStudentEntity entity in subjectStudentEntityBindingSource.List)
            //{
            //    if (entity.FirstGrade != null)
            //    {
            //        if (CheckGradeBaseValid(entity.FirstGrade))
            //        {
            //            ((SubjectStudentEntity)subjectStudentEntityBindingSource.Current)
            //        }
            //    }

            //}
            var bResult = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Validate();
                if (row.Cells["FirstGrade"].Visible)
                {
                    var firstGrade = row.Cells["FirstGrade"].Value;
                    if (firstGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(firstGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["FirstGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["FirstGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                            break;
                        }
                    }
                    else
                    {
                        row.Cells["FirstGrade"].Style.BackColor = Color.White;
                    }
                }

                if (row.Cells["SecondGrade"].Visible)
                {
                    var secondGrade = row.Cells["SecondGrade"].Value;
                    if (secondGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(secondGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["SecondGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["SecondGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                        }
                    }
                    else
                    {
                        row.Cells["SecondGrade"].Style.BackColor = Color.White;
                    }
                }

                if (row.Cells["ThirdGrade"].Visible)
                {
                    var thirdGrade = row.Cells["ThirdGrade"].Value;
                    if (thirdGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(thirdGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["ThirdGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["ThirdGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                        }
                    }
                    else
                    {
                        row.Cells["ThirdGrade"].Style.BackColor = Color.White;
                    }
                }
                
                if (row.Cells["FourthGrade"].Visible)
                {
                    var fourhthGrade = row.Cells["FourthGrade"].Value;
                    if (fourhthGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(fourhthGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["FourthGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["FourthGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                        }
                    }
                    else
                    {
                        row.Cells["FourthGrade"].Style.BackColor = Color.White;
                    }
                }

                if (row.Cells["FifthGrade"].Visible)
                {
                    var fifthGrade = row.Cells["FifthGrade"].Value;
                    if (fifthGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(fifthGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["FifthGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["FifthGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                        }
                    }
                    else
                    {
                        row.Cells["FifthGrade"].Style.BackColor = Color.White;
                    }
                }

                if (row.Cells["SixthGrade"].Visible)
                {
                    var sixthGrade = row.Cells["SixthGrade"].Value;
                    if (sixthGrade != null)
                    {
                        var g1 = CheckGradeBaseValid(sixthGrade.ToString());
                        if (g1 != null)
                        {
                            row.Cells["SixthGrade"].Style.BackColor = Color.LightGreen;
                            row.Cells["Remarks"].Value = g1.GradeBaseValueRemark;
                        }
                        else
                        {
                            row.Cells["SixthGrade"].Style.BackColor = Color.Red;
                            row.Cells["Remarks"].Value = @"<Error>";
                            bResult = true;
                        }
                    }
                    else
                    {
                        row.Cells["SixthGrade"].Style.BackColor = Color.White;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return bResult;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            if (e.ColumnIndex > 3)
            {
                switch (e.ColumnIndex)
                {
                    case 4:
                        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[4].Visible)
                        {
                            var cell = dataGridView1.CurrentRow.Cells[4];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    case 5:
                        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[5].Visible)
                        {
                            var cell = dataGridView1.CurrentRow.Cells[5];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    default: break;
                }
            }
        }

        private void FormatDisplaySubjectInfo(int scheduleId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var display = new StringBuilder();
            if (scheduleId > 0)
            {
                var t = AcademicQueries.GetSubjectScheduleTeacher(scheduleId);
                if (t != null)
                {
                    display.AppendLine(@"Shedule Code " + '\t' + '\t' + ": " + t.ScheduleCode);
                    display.AppendLine(@"Subject No " + '\t' + '\t' + ": " + t.SubjectNo);
                    display.AppendLine(@"Descriptive Title " + '\t' + '\t' + ": " + t.SubjectDescriptiveTitle);
                    display.AppendLine(@"Units " + '\t' + '\t' + '\t' + ": " + t.FullUnits);
                    display.AppendLine();
                    display.AppendLine(@"Teacher ID No" + '\t' + '\t' + ": " + t.TeacherIdNo);
                    display.AppendLine(@"Teacher Name " + '\t' + '\t' + ": " + t.TeacherName);
                    textBoxSubjectInfo.Text = display.ToString();

                    _teacherSubjectId = Convert.ToInt32(t.TeacherSubjectId);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                {
                    Validate();
                    _clickCounter += 1;
                    if ((_clickCounter % 2) == 1)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            //((SubjectStudentEntity) row.DataBoundItem).Posted = true;
                            row.Cells["Posted"].Value = true;
                        }    
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            //((SubjectStudentEntity) row.DataBoundItem).Posted = true;
                            row.Cells["Posted"].Value = false;
                        }
                    }
                    
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex > 4)
            //{
            //    if (e.ColumnIndex == 5)
            //    {
            //        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[5].Visible)
            //        {
            //            var cell = dataGridView1.CurrentRow.Cells[5];
            //            dataGridView1.CurrentCell = cell;
            //            dataGridView1.BeginEdit(true);
            //        }
            //    }

            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 3)
            {
                switch (e.ColumnIndex)
                {
                    case 4:
                        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[4].Visible)
                        {
                            var cell = dataGridView1.CurrentRow.Cells[4];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    case 5:
                        if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[5].Visible)
                        {
                            var cell = dataGridView1.CurrentRow.Cells[5];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                        break;
                    default: break;
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                if (iColumn > 3)
                {
                    if ((iColumn == 4) && (dataGridView1.Columns[4].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                    else if ((iColumn == 5) && (dataGridView1.Columns[5].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                    else if ((iColumn == 6) && (dataGridView1.Columns[6].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                    else if ((iColumn == 7) && (dataGridView1.Columns[7].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                    else if ((iColumn == 8) && (dataGridView1.Columns[8].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                    else if ((iColumn == 9) && (dataGridView1.Columns[9].Visible))
                    {
                        var iRow = dataGridView1.CurrentCell.RowIndex;
                        if (iRow <= dataGridView1.Rows.Count - 1)
                        {
                            var cell = dataGridView1[iColumn, iRow];
                            dataGridView1.CurrentCell = cell;
                            dataGridView1.BeginEdit(true);
                        }
                    }
                }
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }
    }
}
