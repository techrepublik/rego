using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class CollegeUnitListForm : Form
    {
        private College _college;
        private Department _department;
        private Cours _cours;

        public CollegeUnitListForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new UpdateCollegeWizardForm();
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    using (var f = new UpdateCollegeForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._College = _college;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F10:
                    using (var f = new UpdateDepartmentForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._Department = _department;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F11:
                    using (var f = new UpdateCourseForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._Cours = _cours;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                default:
                    Console.Write(@"Selection needed.");
                    break;
            }

            FillTreeview();
            treeView1.ExpandAll();
        }

        private void CollegeUnitListForm_Load(object sender, EventArgs e)
        {
            FillTreeview();
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lCourses = LoadQueries.GetCourses();
            var lBranches = ObjectQueries.GetBranches();

            foreach (var branch in lBranches)
            {
                var nodeParentParent = new TreeNode(branch.BranchName) {Name = "Branch", Tag = branch};

                foreach (var college in lColleges)
                {
                    if (college.BranchId == branch.BranchId)
                    {
                        var nodeParent = new TreeNode(college.CollegeName) {Name = "College", Tag = college};

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

                                foreach (var course in lCourses)
                                {
                                    if (course.DepartmentId == department.DepartmentId)
                                    {
                                        var nodeChild02 = new TreeNode(course.CourseName)
                                            {
                                                Name = "Course",
                                                Tag = course
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
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "College":
                    jTabWizard1.SelectedTab = tabPage1;
                    _college = (College) e.Node.Tag;
                    if (_college != null)
                        departmentBindingSource.DataSource = ObjectQueries.GetDepartmentsCollege(_college.CollegeId);
                    break;
                case "Department":
                    jTabWizard1.SelectedTab = tabPage2;
                    _department = (Department) e.Node.Tag;
                    if (_department != null)
                        coursBindingSource.DataSource = ObjectQueries.GetCourseDepartment(_department.DepartmentId);
                    break;
                case "Course":
                    jTabWizard1.SelectedTab = tabPage3;
                    _cours = (Cours) e.Node.Tag;
                    if (_cours != null)
                        prospectusBindingSource.DataSource = ObjectQueries.GetProspectusCourse(_cours.CourseId);
                    break;
                default:
                    Console.Write(@"Selection needed.");
                    break;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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
