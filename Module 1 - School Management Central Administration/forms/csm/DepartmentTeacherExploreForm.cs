using System;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class DepartmentTeacherExploreForm : Form
    {
        public DepartmentTeacherExploreForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lTeachers = ObjectQueries.GetAllTeachersWithDepartment();
            var lBranches = ObjectQueries.GetBranches();

            foreach (var branch in lBranches)
            {
                var nodeParentParent = new TreeNode(branch.BranchName) { Name = "Branch", Tag = branch };

                foreach (var college in lColleges)
                {
                    if (college.BranchId == branch.BranchId)
                    {
                        var nodeParent = new TreeNode(college.CollegeName) { Name = "College", Tag = college };

                        nodeParentParent.Nodes.Add(nodeParent);

                        foreach (var department in lDepartments)
                        {
                            if (department.CollegeId == college.CollegeId)
                            {
                                var nodeChild01 = new TreeNode(department.DepartmentName)
                                {
                                    Name = "Department",
                                    Tag = department
                                };

                                nodeParent.Nodes.Add(nodeChild01);

                                foreach (var teacher in lTeachers)
                                {
                                    if (teacher.DepartmentId == department.DepartmentId)
                                    {
                                        var nodeChild02 = new TreeNode(teacher.FullName)
                                        {
                                            Name = "Teacher",
                                            Tag = teacher
                                        };

                                        nodeChild01.Nodes.Add(nodeChild02);
                                    }
                                }
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParentParent);
            }
            Cursor.Current = Cursors.Default;  
        }

        private void DepartmentTeacherExploreForm_Load(object sender, EventArgs e)
        {
            FillTreeview();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "College":
                    if ((e.Node.Tag != null))
                    {
                        departmentTeacherEntityBindingSource.DataSource =
                            ObjectQueries.GetAllDepartmentTeacherByDepartmentId(((College) e.Node.Tag).CollegeId, 1);
                    }
                    break;
                case "Department":
                    if (e.Node.Tag != null)
                    {
                        departmentTeacherEntityBindingSource.DataSource =
                            ObjectQueries.GetAllDepartmentTeacherByDepartmentId(((Department)e.Node.Tag).DepartmentId, 0);
                    }
                    break;
                case "Teacher": break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f = new DepartmentTeacherListForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ShowDialog();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteDepartmentTeacher(); //delete
        }

        private void DeleteDepartmentTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (departmentTeacherEntityBindingSource != null)
            {
                var iId = ((DepartmentTeacherEntity) departmentTeacherEntityBindingSource.Current).DepartmentTeacherId;
                if (iId > 0)
                {
                    var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                    if (dResult == DialogResult.Yes)
                    {
                        if (DepartmentTeacherManager.Delete(Convert.ToInt32(iId)))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            departmentTeacherEntityBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
