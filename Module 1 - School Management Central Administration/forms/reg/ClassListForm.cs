using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;
using Microsoft.Reporting.WinForms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class ClassListForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        private College _college;
        private Department _department;
        private Cours _cours;

        private int _semSyId;

        public ClassListForm()
        {
            InitializeComponent();
        }

        private void ClassListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetAllSemSy();
            FillTreeview(); //fill treeview1
            FillTreeview2(); //fill treeview2
            Cursor.Current = Cursors.Default;
            
        }

        private void FillTreeview2()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView2.Nodes.Clear();
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

                                        var subjects = ObjectQueries.GetScheduleSemSyTeacher(_semSyId, teacher.TeacherId);
                                        foreach (var item in subjects)
                                        {
                                            var nodeChild03 = new TreeNode(String.Format(@"[ {0} ] {1}", item.ScheduleCode,
                                                                           item.SubjectProfile))
                                                    {
                                                        Name = "Subject",
                                                        Tag = item
                                                    };
                                            nodeChild02.Nodes.Add(nodeChild03);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                treeView2.Nodes.Add(nodeParentParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();

            foreach (var college in lColleges)
            {
                var nodeParent = new TreeNode(college.CollegeName) {Name = "College", Tag = college};

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

                        var listSubjects = ObjectQueries.GetScheduleSemSyDepartmentId(_semSyId, department.DepartmentId);
                        {
                            foreach (var list in listSubjects)
                            {
                                var nodeChild02 = new TreeNode(String.Format(@"[ {0} ] {1}", list.ScheduleCode, list.SubjectProfile))
                                    {
                                        Name = "Subject",
                                        Tag = list
                                    };

                                nodeChild01.Nodes.Add(nodeChild02);
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "College":
                    _college = (College)e.Node.Tag;
                    schedulingEntityDataGridView.Visible = false;
                    printStudentClassDataGridView.Visible = false;
                    break;
                case "Department":
                    printStudentClassDataGridView.Visible = false;
                    schedulingEntityDataGridView.Visible = true;
                    schedulingEntityDataGridView.Dock = DockStyle.Fill;
                    _department = (Department)e.Node.Tag;
                    if ((_department != null) && (_semSyId > 0))
                        schedulingEntityBindingSource.DataSource = ObjectQueries.GetScheduleSemSyDepartmentId(_semSyId, _department.DepartmentId);
                    break;
                case "Subject":
                    schedulingEntityDataGridView.Visible = false;
                    printStudentClassDataGridView.Visible = true;
                    printStudentClassDataGridView.Dock = DockStyle.Fill;
                    var subject = (SchedulingEntity)e.Node.Tag;
                    if (subject != null)
                    {
                        printStudentClassBindingSource.DataSource =
                            AcademicQueries.GetPrintStudentClass(subject.ScheduleId);
                    }
                    break;
                default:
                    MessageBox.Show(@"Invalid selection.", @"Out of selection", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllTeachers()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (waterMarkTextBox2.Text.Length > 0)
            {
                teacherEntityBindingSource.DataSource = ObjectQueries.GetAllTeachers(waterMarkTextBox2.Text);    
            }
            Cursor.Current = Cursors.Default;
        }

        private void waterMarkTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GetAllTeachers();
                    break;
                case Keys.Escape: break;
                default: break;
            }
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (semSyEntityBindingSource.Current != null)
            {
                _semSyId = ((SemSyEntity)semSyEntityBindingSource.Current).SemSyId;
                if (_semSyId > 0)
                {
                    FillTreeview(); //fill treeview1
                    FillTreeview2(); //fill treeview2
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "College": break;
                case "Department": 
                    printStudentClassDataGridView.Visible = false;
                    schedulingEntityDataGridView.Visible = true;
                    schedulingEntityDataGridView.Dock = DockStyle.Fill;
                    _department = (Department)e.Node.Tag;
                    if ((_department != null) && (_semSyId > 0))
                        schedulingEntityBindingSource.DataSource = ObjectQueries.GetScheduleSemSyDepartmentId(_semSyId, _department.DepartmentId);
                    break;
                case "Teacher": 
                    printStudentClassDataGridView.Visible = false;
                    schedulingEntityDataGridView.Visible = true;
                    schedulingEntityDataGridView.Dock = DockStyle.Fill;
                    var teacher = (TeacherEntity)e.Node.Tag;
                    if (teacher != null)
                    {
                        schedulingEntityBindingSource.DataSource = ObjectQueries.GetScheduleSemSyTeacher(_semSyId, teacher.TeacherId);
                    }
                    break;
                case "Subject":
                    schedulingEntityDataGridView.Visible = false;
                    printStudentClassDataGridView.Visible = true;
                    printStudentClassDataGridView.Dock = DockStyle.Fill;
                    var subject = (SchedulingEntity)e.Node.Tag;
                    if (subject != null)
                    {
                        printStudentClassBindingSource.DataSource =
                            AcademicQueries.GetPrintStudentClass(subject.ScheduleId);
                    }
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(1);
            BranchBindingSource.DataSource = Branch;
            bindingSource1.DataSource = semSyEntityBindingSource.Current;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }
    }
}
