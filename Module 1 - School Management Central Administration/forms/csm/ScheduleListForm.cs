using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class ScheduleListForm : Form
    {
        private List<SchedulingEntity> lSched;
        private CourseSecScheduleEntity _CourseSecSchedule;
        private List<ProspectusSubjectEntity> _ListSubjects = null;

        private SemSy _SemSy;

        private int _Choice;

        public ScheduleListForm()
        {
            InitializeComponent();
        }

        private void ScheduleListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            LoadRooms();
            Cursor.Current = Cursors.Default;
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lSemSy = LoadQueries.GetSemSy();
            var lCrsEtAl = ObjectQueries.GetCourseSecScheduleEntities();

            foreach (var semSy in lSemSy)
            {
                var nodeParent = new TreeNode(semSy.Semester + ", " + semSy.Sy);
                nodeParent.Name = "SemSy";
                nodeParent.Tag = semSy;

                foreach (var item in lCrsEtAl)
                {
                    if (item.SemSyId == semSy.SemSyId)
                    {
                        var nodeChild01 = new TreeNode(item.DisplayCaption);
                        nodeChild01.Name = "CourseSecSchedule";
                        nodeChild01.Tag = item;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void LoadRooms()
        {
            roomBindingSource.DataSource  = ObjectQueries.GetRooms();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tabControl1.SelectedTab = tabPage1;
            switch (e.Node.Name)
            {
                case "SemSy":
                    _SemSy = (SemSy) e.Node.Tag;
                    if (_SemSy != null)
                    {
                        labelCrsSemSY.Text = e.Node.Text;
                        SubjectNo.DataSource =
                            ObjectQueries.GetProspectusSubjectEntitiesAll(Convert.ToInt32(_SemSy.Semester));
                        SubjectNo.ValueMember = "ProspectusSubjectId";
                        SubjectNo.DisplayMember = "SubjectNo";
                        LoadSchedulesAll();
                    }
                    break;
                case "CourseSecSchedule":
                    _CourseSecSchedule = (CourseSecScheduleEntity) e.Node.Tag;
                    if (_CourseSecSchedule != null)
                    {
                        labelCrsSemSY.Text = e.Node.Text;
                        SubjectNo.ValueMember = "ProspectusSubjectId";
                        SubjectNo.DisplayMember = "SubjectNo";
                        SubjectNo.DataSource = ObjectQueries.GetProspectusSubjectEntitiesProspectusCourse((int) _CourseSecSchedule.CourseId);
                        LoadSchedulesParticular();
                    }
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    using (var f = new ScheduleUpdateSemSyForm() )
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._CourseSecSchedule = _CourseSecSchedule;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F10:
                    using (var f = new SelectProspectusCourseForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.MinimizeBox = false;
                        f.MaximizeBox = false;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            SubjectNo.ValueMember = "ProspectusSubjectId";
                            SubjectNo.DisplayMember = "SubjectNo";
                            _ListSubjects = f._ListSubjectProspectus;
                            SubjectNo.DataSource = _ListSubjects;
                        }
                    }
                    break;
                case Keys.F5:
                    Cursor.Current = Cursors.WaitCursor;
                    FillTreeview();
                    Cursor.Current = Cursors.Default;
                    break;
                default:
                    break;
            }

            FillTreeview();
            treeView1.ExpandAll();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ComboBox comboBox;
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    comboBox = e.Control as ComboBox;
                    comboBox.SelectedIndexChanged += comboBoxSelectedItem;
                }
            }
        }

        private void comboBoxSelectedItem(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedValue != null)
            {
                dataGridView1.CurrentRow.Cells[2].Value = ((ProspectusSubjectEntity)comboBox.SelectedItem).DescriptiveTitle;
                dataGridView1.CurrentRow.Cells[3].Value = ((ProspectusSubjectEntity)comboBox.SelectedItem).Lecture + ", " + ((ProspectusSubjectEntity)comboBox.SelectedItem).Laboratory + ", " + ((ProspectusSubjectEntity)comboBox.SelectedItem).Credit;
                dataGridView1.CurrentRow.Cells[4].Value = 40;
                dataGridView1.CurrentRow.Cells[5].Value = 0;
                dataGridView1.CurrentRow.Cells[6].Value = bool.FalseString;
                dataGridView1.CurrentRow.Cells[7].Value = bool.TrueString;
                dataGridView1.CurrentRow.Tag = ((ProspectusSubjectEntity)comboBox.SelectedItem).ProspectusSubjectId;
            }
            else
            {
                dataGridView1.CurrentRow.Cells[2].Value = string.Empty;
                dataGridView1.CurrentRow.Cells[3].Value = string.Empty;
                dataGridView1.CurrentRow.Cells[4].Value = 40;
                dataGridView1.CurrentRow.Cells[5].Value = 0;
                dataGridView1.CurrentRow.Cells[6].Value = bool.FalseString;
                dataGridView1.CurrentRow.Cells[7].Value = bool.FalseString;
                dataGridView1.CurrentRow.Tag = string.Empty;
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.IsCurrentRowDirty)
                {
                    Validate();
                    //if (_CourseSecSchedule != null)
                    //{
                        if (dataGridView1.CurrentRow != null)
                        {
                            var crsSchedId = 0;
                            if (dataGridView1.CurrentRow.Cells[9].Value != null)
                                crsSchedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value);
                            else
                            {
                                if (_CourseSecSchedule != null)
                                    crsSchedId = _CourseSecSchedule.CourseSecScheduleEntityId;
                            }
                            if (crsSchedId > 0)
                            {
                                if (dataGridView1.CurrentRow.Tag != null)
                                {
                                    var s = new Schedule
                                        {
                                            CourseSecScheduleId = crsSchedId,
                                            ScheduleId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value),
                                            ProspectusSubjectId = Convert.ToInt32(dataGridView1.CurrentRow.Tag),
                                            StudentLimit = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value),
                                            StudentAdded = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value),
                                            IsRequested = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value),
                                            IsActive = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value),
                                            IsDeleted = false
                                        };
                                    int iResult = Save.Schedules(s);
                                    if (iResult > 0)
                                    {
                                        dataGridView1.CurrentRow.Cells[0].Value = iResult;
                                        dataGridView1.CurrentRow.Cells[8].Value = iResult;
                                        var s1 = s;
                                        s1.ScheduleCode = iResult.ToString();
                                        s1.ScheduleId = iResult;
                                        if (Save.Schedules(s1) > 1)
                                        {
                                            toolStripLabel1.Text = @"Schedule Code Updated..";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(@"Error on save. Please check your input.", @"Error on Save",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        
                    //}
                }
            }
        }

        private void LoadSchedulesAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_SemSy != null)
            {
                lSched = ObjectQueries.GetScheduleAll(_SemSy.SemSyId);
                int i = 0;
                dataGridView1.Rows.Clear();
                foreach (var item in lSched)
                {
                    dataGridView1.Rows.Add(String.Format("{0:00000}", item.ScheduleId), item.SubjectNo, item.SubjectDescriptiveTitle , item.SubjectLecUnit + ", " + item.SubjectLabUnit + ", " + item.SubjectCreUnit, 
                        item.Limit,item.Added, item.Requested, item.Active, item.ScheduleId, item.CourseSecScheduleId);
                    dataGridView1.Rows[i].Tag = item.ProspectusSubjectId;
                    i += 1;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void SearchSchedule(string criteria)
        {
            Cursor.Current = Cursors.WaitCursor;
            var lScheds = lSched.FindAll(s => (s.SubjectNo.StartsWith(criteria) | s.SubjectDescriptiveTitle.StartsWith(criteria)) | s.ScheduleCode == criteria);
            var i = 0;
            dataGridView1.Rows.Clear();
            foreach (var item in lScheds)
            {
                dataGridView1.Rows.Add(String.Format("{0:00000}", item.ScheduleId), item.SubjectNo, item.SubjectDescriptiveTitle, item.SubjectLecUnit + ", " + item.SubjectLabUnit + ", " + item.SubjectCreUnit,
                    item.Limit, item.Added, item.Requested, item.Active, item.ScheduleId, item.CourseSecScheduleId);
                dataGridView1.Rows[i].Tag = item.ProspectusSubjectId;
                i += 1;
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadSchedulesParticular()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_CourseSecSchedule != null)
            {
                var lSched = ObjectQueries.GetScheduleSet(_CourseSecSchedule.CourseSecScheduleEntityId);
                int i = 0;
                dataGridView1.Rows.Clear();
                foreach (var item in lSched)
                {
                    dataGridView1.Rows.Add(String.Format("{0:00000}", item.ScheduleId), item.SubjectNo, item.SubjectDescriptiveTitle, item.SubjectLecUnit + ", " + item.SubjectLabUnit + ", " + item.SubjectCreUnit,
                        item.Limit, item.Added, item.Requested, item.Active, item.ScheduleId, item.CourseSecScheduleId);
                    dataGridView1.Rows[i].Tag = item.ProspectusSubjectId;
                    i += 1;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            _Choice = 0;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (_Choice == 0)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        if (dataGridView1.CurrentRow.Cells[8].Value != null)
                        {
                            int iSchedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.Schedules(iSchedId);
                                if (bResult)
                                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                                UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                                
                            }
                            else
                            {
                                MessageBox.Show(@"Delete operation cancelled.", @"Cancelled Delete.",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                if (scheduleDetailDataGridView.Rows.Count > 0)
                {
                    if (scheduleDetailBindingSource.Current != null)
                    {
                        var iDetailId = ((ScheduleDetail) scheduleDetailBindingSource.Current).ScheduleDetailId;
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult = Remove.ScheduleDetails(iDetailId);
                            if (bResult)
                                scheduleDetailBindingSource.RemoveCurrent();
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                        }
                    }
                }
            }
        }

       private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.CurrentRow != null)
            {
                scheduleDetailBindingSource.DataSource = ObjectQueries.GetSchecduleDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value));
            }
            Cursor.Current = Cursors.Default;
        }

       private void scheduleDetailDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
       {
           if (scheduleDetailDataGridView.Rows.Count > 0)
           {
               if (scheduleDetailDataGridView.IsCurrentRowDirty)
               {
                   Validate();
                   if (roomBindingSource != null)
                   {
                       if (dataGridView1.CurrentRow != null)
                       {
                           ((ScheduleDetail)scheduleDetailBindingSource.Current).ScheduleId =
                               Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                           ((ScheduleDetail)scheduleDetailBindingSource.Current).RoomId =
                               ((Room)roomBindingSource.Current).RoomId;
                           int iResult = Save.ScheduleDetails((ScheduleDetail)scheduleDetailBindingSource.Current);
                           UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                       }
                   }
               }
           }
       }

       private void scheduleDetailDataGridView_Click(object sender, EventArgs e)
       {
           _Choice = 1;
       }

       private void toolStripButtonSemYr_Click(object sender, EventArgs e)
       {
           using (var f = new ScheduleUpdateSemSyForm())
           {
               f.FormBorderStyle = FormBorderStyle.FixedSingle;
               f.StartPosition = FormStartPosition.CenterScreen;
               f._CourseSecSchedule = _CourseSecSchedule;
               f.MaximizeBox = false;
               f.MinimizeBox = false;
               f.ShowDialog();
           }
       }

       private void toolStripButtonLoadSubject_Click(object sender, EventArgs e)
       {
           using (var f = new SelectProspectusCourseForm())
           {
               f.FormBorderStyle = FormBorderStyle.FixedSingle;
               f.MinimizeBox = false;
               f.MaximizeBox = false;
               f.StartPosition = FormStartPosition.CenterScreen;
               if (f.ShowDialog() == DialogResult.OK)
               {
                   SubjectNo.ValueMember = "ProspectusSubjectId";
                   SubjectNo.DisplayMember = "SubjectNo";
                   _ListSubjects = f._ListSubjectProspectus;
                   SubjectNo.DataSource = _ListSubjects;
               }
           }
       }

       private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           Cursor.Current = Cursors.WaitCursor;
           FillTreeview();
           Cursor.Current = Cursors.Default;
       }

       private void toolStripButtonGo_Click(object sender, EventArgs e)
       {
           if (lSched != null)
               SearchSchedule(toolStripTextBox1.Text);
           else
           {
               LoadSchedulesAll();
           }
       }

       private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
            toolStripButtonGo.PerformClick();
       }

       private void tabControl1_Selected(object sender, TabControlEventArgs e)
       {
           if (e.TabPage == tabPage2)
           {
               if (_SemSy != null)
               {
                   PrintScheduleClassBindingSource.DataSource = ObjectQueries.GetPrintSchedulesAll(_SemSy.SemSyId);
                   this.reportViewer1.RefreshReport();
               }
           }
       }

       private void toolStripButtonPrint_Click(object sender, EventArgs e)
       {
           tabControl1.SelectedTab = tabPage2;
           if (_SemSy != null)
           {
               PrintScheduleClassBindingSource.DataSource = ObjectQueries.GetPrintSchedulesAll(_SemSy.SemSyId);
               this.reportViewer1.RefreshReport();
           }
       }
    }
}
