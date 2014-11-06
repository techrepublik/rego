using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class SelectProspectusCourseForm : Form
    {
        public List<DepartmentSubjectEntity> _ListSubjectsDepartment = null;
        public List<ProspectusSubjectEntity> _ListSubjectProspectus = null;

        private Department _department;

        public SelectProspectusCourseForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lCourses = LoadQueries.GetCourses();
            var lProspectuses = LoadQueries.GetProspectuses();
            var lSemYrs = LoadQueries.GetProspectusSemYr();

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

                        foreach (var course in lCourses)
                        {
                            if (course.DepartmentId == department.DepartmentId)
                            {
                                var nodeChild02 = new TreeNode(course.CourseName);
                                nodeChild02.Name = "Course";
                                nodeChild02.Tag = course;
                                //_department = department;
                                nodeChild01.Nodes.Add(nodeChild02);

                                foreach (var prospectus in lProspectuses)
                                {
                                    if (prospectus.CourseId == course.CourseId)
                                    {
                                        var nodeChild03 = new TreeNode(prospectus.ProspectusName);
                                        nodeChild03.Name = "Prospectus";
                                        nodeChild03.Tag = prospectus;
                                        //_department = department;
                                        nodeChild02.Nodes.Add(nodeChild03);

                                        foreach (var semyr in lSemYrs)
                                        {
                                            if (semyr.ProspectusId == prospectus.ProspectusId)
                                            {
                                                var nodeChild04 = new TreeNode(semyr.Semester + ", " + semyr.Sy);
                                                nodeChild04.Name = "SemYr";
                                                nodeChild04.Tag = semyr;
                                                //_department = department;
                                                nodeChild03.Nodes.Add(nodeChild04);
                                            }
                                        }
                                    }
                                }
                            }

                            
                        }
                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }

                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void SelectProspectusCourseForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "College":
                    jTabWizard1.SelectedTab = tabPage1;
                    break;
                case "Department":
                    jTabWizard1.SelectedTab = tabPage2;
                    _department = (Department)e.Node.Tag;
                    _ListSubjectsDepartment = ObjectQueries.GetDepartmentSubjectEntities(_department.DepartmentId);
                    departmentSubjectEntityBindingSource.DataSource = _ListSubjectsDepartment;
                    break;
                case "Course":
                    jTabWizard1.SelectedTab = tabPage3;

                    break;
                case "Prospectus":
                    jTabWizard1.SelectedTab = tabPage5;
                    _ListSubjectProspectus = (List<ProspectusSubjectEntity>) ObjectQueries.GetProspectusSubjectEntitiesProspectus(((Prospectus)e.Node.Tag).ProspectusId);
                    prospectusSubjectEntityBindingSource.DataSource = _ListSubjectProspectus;
                    break;
                case "SemYr":
                    jTabWizard1.SelectedTab = tabPage5;
                    _ListSubjectProspectus = (List<ProspectusSubjectEntity>) ObjectQueries.GetProspectusSubjectEntities(((ProspectusSemYr)e.Node.Tag).ProspectusSemYrId);
                    prospectusSubjectEntityBindingSource.DataSource = _ListSubjectProspectus;
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
