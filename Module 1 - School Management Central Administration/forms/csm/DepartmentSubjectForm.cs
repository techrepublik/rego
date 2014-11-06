using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class DepartmentSubjectForm : Form
    {
        private Department _department;
        public DepartmentSubjectForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();

            foreach (var college in lColleges)
            {
                var nodeParent = new TreeNode(college.CollegeName);
                nodeParent.Name = "College";
                nodeParent.Tag = college;

                foreach (var department in lDepartments)
                {
                    if (department.CollegeId == college.CollegeId)
                    {
                        var nodeChild01 = new TreeNode(department.DepartmentName);
                        nodeChild01.Name = "Department";
                        nodeChild01.Tag = department;
                        _department = department;
                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void DepartmentSubjectForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f = new UpdateDepartmentSubjectForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Text = @"Update Department Subject [ " + _department.DepartmentName + @" ]";
                f._Department = _department;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "College":

                    break;
                case "Department":
                    _department = (Department)e.Node.Tag;
                    departmentSubjectEntityBindingSource.DataSource =
                        ObjectQueries.GetDepartmentSubjectEntities(_department.DepartmentId);
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (departmentSubjectEntityDataGridView.Rows.Count > 0)
            {
                if (departmentSubjectEntityBindingSource.Current != null)
                {
                    if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                    {
                        bool bResult =
                            Remove.DepartmentSubjects(
                                ((DepartmentSubjectEntity) departmentSubjectEntityBindingSource.Current).DepartSubjectId);
                        UtilClass.ShowDeleteMessageBox(bResult);
                        departmentSubjectEntityBindingSource.RemoveCurrent();
                    }
                }
            }
        }
    }
}
