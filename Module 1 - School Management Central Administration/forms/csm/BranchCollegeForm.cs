using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class BranchCollegeForm : Form
    {
        public BranchCollegeForm()
        {
            InitializeComponent();
        }

        private void BranchCollegeForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadBranches();
            LoadColleges();
            Cursor.Current = Cursors.Default;
        }

        private void LoadBranches()
        {
            branchBindingSource.DataSource = ObjectQueries.GetBranches();
        }

        private void LoadColleges()
        {
            collegeBindingSource.DataSource = LoadQueries.GetColleges();
        }

        private void collegeDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (collegeBindingSource.Current != null)
            {
                if (collegeDataGridView.Rows.Count > 0)
                {
                    if (collegeDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        collegeBindingSource.EndEdit();
                        var iResult = Save.College((College) collegeBindingSource.Current);
                        if (iResult > 0)
                        {
                            toolStripStatusLabel1.Text = @"Record saved...";
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = @"Record NOT saved...";
                        }
                    }
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (collegeBindingSource.Current != null)
            {
                if (collegeDataGridView.Rows.Count > 0)
                {
                    var dResult = MessageBox.Show(@"You are about to delete a record, continue?", @"Delete",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        var bResult = Remove.Colleges(((College) collegeBindingSource.Current).CollegeId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                        if (bResult)
                        {
                            toolStripStatusLabel1.Text = @"Record Deleted...";
                            collegeBindingSource.RemoveCurrent();
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = @"Record was NOT deleted...";
                        }
                    }
                }
            }
        }
    }
}
