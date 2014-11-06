using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class SchoolBranchForm : Form
    {
        public SchoolBranchForm()
        {
            InitializeComponent();
        }

        private void SchoolBranchForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadBranches();
            Cursor.Current = Cursors.Default;
        }

        private void LoadBranches()
        {
            branchBindingSource.DataSource = ObjectQueries.GetBranches();
        }

        private void branchDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (branchBindingSource.Current != null)
            {
                if (branchDataGridView.Rows.Count > 0)
                {
                    if (branchDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        branchBindingSource.EndEdit();
                        var iResult = Save.Branches((Branch) branchBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(iResult);
                    }
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (branchBindingSource.Current != null)
            {
                if (branchDataGridView.Rows.Count > 0)
                {
                    var dResult = MessageBox.Show(@"You are about to delete a record, continue?", @"Delete",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        var bResult = Remove.Branches(((Branch) branchBindingSource.Current).BranchId);
                        UtilClass.ShowDeleteMessageBox(bResult);
                        if (bResult)
                        {
                            branchBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
        }

        private void toolStripButtonAssignCollege_Click(object sender, EventArgs e)
        {
            using (var f = new BranchCollegeForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
            }
        }
    }
}
