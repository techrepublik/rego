using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class StudentlistForm : Form
    {
        private List<Branch> b = null;
        private List<SemSyEntity> s = null;

        private Branch _branch;
        private SemSyEntity _semSyEntity;
        public StudentlistForm()
        {
            InitializeComponent();
        }

        private void StudentlistForm_Load(object sender, EventArgs e)
        {
            LoadStudentList();
            LoadBranchSemSY();
        }

        private void LoadStudentList()
        {
            Cursor.Current = Cursors.WaitCursor;
            studentBindingSource.DataSource = LoadQueries.GetStudents();
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            studentBindingSource.DataSource = LoadQueries.GetStudentSearch(toolStripTextBoxSearch.Text);
            Cursor.Current = Cursors.Default;
        }

        private void studentDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (studentDataGridView.Rows.Count > 0)
            //{
            //    if (studentBindingSource != null)
            //    {
            //        try
            //        {
            //            if (studentDataGridView.IsCurrentRowDirty)
            //            {
            //                Validate();
            //                studentBindingSource.EndEdit();
            //                var iResult = Save.Student((Student)studentBindingSource.Current);
            //                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.Write(ex.Message.ToString());
            //            MessageBox.Show(@"Please provide a valid date format..i.e: 8/21/13", @"Date Format",
            //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
                    
            //    }
            //}
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonGo.PerformClick();
            }
        }

        private void studentDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DateTime dt;
                if (!DateTime.TryParse(e.FormattedValue.ToString(), out dt))
                    MessageBox.Show(@"Please provide a valid date format..i.e: 8/21/13", @"Date Format",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void studentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void studentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 7)
            //{
            //    if (e.Value == null)
            //    {
            //        DateTime dt;
            //        if (!DateTime.TryParse(e.Value.ToString(), out dt))
            //            MessageBox.Show(@"Please provide a valid date format..i.e: 8/21/13", @"Date Format",
            //                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void studentDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"Please provide a valid date format..i.e: 8/21/13", @"Date Format",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            this.reportViewer1.RefreshReport();
        }

        private void LoadBranchSemSY()
        {
            Cursor.Current = Cursors.WaitCursor;
            b = ObjectQueries.GetBranches();
            foreach (var branch in b)
            {
                toolStripComboBoxBranch.Items.Add(branch.BranchName);
            }
            if (b.Count > 0)
                toolStripComboBoxBranch.SelectedIndex = 0;

            s = ObjectQueries.GetSemSyEntities();
            foreach (var semSyEntity in s)
            {
                toolStripComboBoxSemSY.Items.Add(semSyEntity.SemSyName);
            }
            if (s.Count > 0)
                toolStripComboBoxSemSY.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripComboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(b[toolStripComboBoxBranch.SelectedIndex].BranchName);
            if (toolStripComboBoxBranch.Items.Count > 0)
                _branch = b[toolStripComboBoxBranch.SelectedIndex];
        }

        private void toolStripComboBoxSemSY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxSemSY.Items.Count > 0)
                _semSyEntity = s[toolStripComboBoxSemSY.SelectedIndex];
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f = new StudentProfileForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                if (studentBindingSource.Current != null)
                    f.Student = (Student) studentBindingSource.Current;
                f.ShowDialog();
            }
        }
    }
}
