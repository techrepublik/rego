using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.reportingentities;
using Module_1___School_Management_Central_Administration.forms.rpt;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class EnrollmentSummaryForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        List<SemSy> lSemSy = LoadQueries.GetSemSy();

        private List<GenDataLayer.repo.reportingentities.PrintEnrolleeDepartmentClass> lDepartmentClass = new List<PrintEnrolleeDepartmentClass>(); 
        List<PrintStudentClass> lStudentClass = new List<PrintStudentClass>(); 
        private List<int> lSemSyId;
        private int _iSemId;

        string _tempLabel = string.Empty;

        private string menu;

        public EnrollmentSummaryForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lBranches = ObjectQueries.GetBranches();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lCourses = LoadQueries.GetCourses();
            var lCrsYrSec = ObjectQueries.GetCourseYearSection(_iSemId);

            foreach (var branch in lBranches)
            {
                var nodeParent1 = new TreeNode(branch.BranchName) { Name = "Branch", Tag = Branch };

                foreach (var college in lColleges)
                {
                    var nodeParent = new TreeNode(college.CollegeName) { Name = "College", Tag = college };

                    nodeParent1.Nodes.Add(nodeParent);
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
                                    var nodeChild02 = new TreeNode(course.CourseName) { Name = "Course", Tag = course };

                                    nodeChild01.Nodes.Add(nodeChild02);

                                    //var iCount = 0;
                                    foreach (var crs in lCrsYrSec)
                                    {
                                        if (crs.CourseId == course.CourseId)
                                        {
                                            //iCount += 1;
                                            //var tempDisplay = String.Format(@"{0} ({1})", crs.CrsYearSec, iCount);
                                            var nodeChild03 = new TreeNode(crs.CrsYearSec) { Name = "Crs", Tag = crs };

                                            nodeChild02.Nodes.Add(nodeChild03);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParent1);
            }
            Cursor.Current = Cursors.Default;
        }

        private void EnrollmentSummaryForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadSemSy();
            FillTreeview();
            Cursor.Current = Cursors.Default;
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _tempLabel = string.Empty;
            switch (e.Node.Name)
            {
                case "Branch":
                    _tempLabel = @"::" + e.Node.Text;
                    break;
                case "College":
                    jTabWizard1.SelectedTab = tabPage1;
                    if (e.Node.Tag != null)
                    {
                        var iCollegeId = ((College)e.Node.Tag).CollegeId;
                        lDepartmentClass = ObjectQueries.GetPrintEnrolleeDepartments(iCollegeId, _iSemId);
                        printEnrolleeDepartmentClassBindingSource.DataSource = lDepartmentClass;
                        menu = "College";
                        _tempLabel = @"::" + e.Node.Parent.Text + @" : " + e.Node.Text;
                    }
                    break;
                case "Department":
                    jTabWizard1.SelectedTab = tabPage2;
                    if (e.Node.Tag != null)
                    {
                        var iDepartmentId = ((Department) e.Node.Tag).DepartmentId;
                        lDepartmentClass = ObjectQueries.GetPrintEnrolleeCourses(iDepartmentId, _iSemId); 
                        //ObjectQueries.GetPrintEnrolleeCourses(iDepartmentId, _iSemId);
                        bindingSource1.DataSource = lDepartmentClass;
                        menu = "Department";
                        _tempLabel = @"::" + e.Node.Parent.Parent.Text + @" : " + e.Node.Parent.Text + @" : " + e.Node.Text;
                    }
                    break;
                case "Course":
                    jTabWizard1.SelectedTab = tabPage3;
                    if (e.Node.Tag != null)
                    {
                        var iCourseId = ((Cours)e.Node.Tag).CourseId;
                        lDepartmentClass = ObjectQueries.GetPrintEnrolleeCoursesYrSec(iCourseId, _iSemId);
                        bindingSource1.DataSource = lDepartmentClass;
                        menu = "Course";
                        _tempLabel = @"::" + e.Node.Parent.Parent.Parent.Text + @" : " + e.Node.Parent.Parent.Text + @" : " + e.Node.Parent.Text + @" : " + e.Node.Text;
                    }
                    break;
                case "Crs":
                    jTabWizard1.SelectTab(tabPage4);
                    if (e.Node.Tag != null)
                    {
                        int? iYr = ((GenDataLayer.repo.entities.CourseYearSectionEntity) e.Node.Tag).YearLevelId;
                        int? iSec = ((GenDataLayer.repo.entities.CourseYearSectionEntity) e.Node.Tag).SectionId;
                        int? iCrs = ((GenDataLayer.repo.entities.CourseYearSectionEntity) e.Node.Tag).CourseId;
                        if ((iYr > 0) && (iSec > 0) && (iCrs > 0))
                        {
                            lStudentClass = ObjectQueries.GetPrintStudentClass(_iSemId, iYr, iSec, iCrs);
                            printStudentClassBindingSource.DataSource = lStudentClass;
                            //e.Node.Text += @" (" + lStudentClass.Count + @")";
                        }
                        menu = "Crs";
                        _tempLabel = @"::" + e.Node.Parent.Parent.Parent.Parent.Text + @" : " + e.Node.Parent.Parent.Parent.Text + @" : " + e.Node.Parent.Parent.Text + @" : " + e.Node.Parent.Text + @" : " + e.Node.Text;
                    }
                    break;
                default:
                    MessageBox.Show(@"Please select an item from the treeview on the left side of the screen.",
                                    @"Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            label2.Text = _tempLabel;
            Cursor.Current = Cursors.Default;
        }

        private void LoadSemSy()
        {
            //toolStripComboBox1.Items.Clear();
            //lSemSyId = new List<int>();
            //foreach (var semSy in lSemSy)
            //{
            //    toolStripComboBox1.Items.Add(String.Format(@"{0} - {1}", semSy.Semester, semSy.Sy));
            //    lSemSyId.Add(semSy.SemSyId);
            //}
            //if (toolStripComboBox1.Items.Count > 0)
            //{
            //    toolStripComboBox1.SelectedIndex = 0;
            //}

            Cursor.Current = Cursors.WaitCursor;
            var tempList = ObjectQueries.GetSemSyEntities();
            var semSy = new SemSyEntity
                {
                    Semester = @"--- Select Semester + School Year ---"
                };
            tempList.Insert(0,semSy);
            semSyEntityBindingSource1.DataSource = tempList;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            using (var f = new ReportSummaryByCourseForm())
            {
                f.Branch = Branch;
                f.SemSyEntity = SemSyEntity;

                switch (menu)
                {
                    case "College":
                        f.myMenu = ReportSummaryByCourseForm.menu.College;
                        f.DepartmentClassesCourse = lDepartmentClass;
                        f.PrintData();
                        break;
                    case "Department":
                        f.myMenu = ReportSummaryByCourseForm.menu.Department;
                        f.DepartmentClassesCourse = lDepartmentClass;
                        f.PrintData();
                        break;
                    case "Course":
                        f.myMenu = ReportSummaryByCourseForm.menu.Course;
                        f.DepartmentClassesCourse = lDepartmentClass;
                        f.PrintData();
                        break;
                    case "Crs":
                        f.myMenu = ReportSummaryByCourseForm.menu.CrsYrSec;
                        f.DepartmentClassesCourse = lDepartmentClass;
                        f.PrintStudentClassesCrsYrSec = lStudentClass;
                        f.PrintData();
                        break;
                    default:
                        f.myMenu = ReportSummaryByCourseForm.menu.Student;
                        f.DepartmentClassesCourse = lDepartmentClass;
                        f.PrintStudentClassesCrsYrSec = lStudentClass;
                        f.PrintData();
                        break;
                }
                f.ShowDialog();
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void semSyEntityBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (semSyEntityBindingSource1.Current != null)
            {
                var semSy = (SemSyEntity) semSyEntityBindingSource1.Current;
                if (semSy != null)
                {
                    SemSyEntity = ObjectQueries.GetSemSyEntity(semSy.SemSyId);
                    _iSemId = semSy.SemSyId;
                    FillTreeview();
                }
            }
        }
    }
}
