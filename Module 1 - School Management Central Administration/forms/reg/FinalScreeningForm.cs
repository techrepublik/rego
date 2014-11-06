using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class FinalScreeningForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        List<RegistrationEntity> _listRegistration = null; 

        private string _tempLabel;
        private int _iBrancId;
        private int _iSemSyId;

        private bool _bChoice;

        public FinalScreeningForm()
        {
            InitializeComponent();
        }

        private void FinalScreeningForm_Load(object sender, EventArgs e)
        {
            GetAllPreferences();
        }

        private void GetAllPreferences()
        {
            Cursor.Current = Cursors.WaitCursor;
            var listBranches = ObjectQueries.GetBranches();
            var branch = new Branch
                {
                    BranchName = @"--- Select Branch/Campus ---"
                };
            listBranches.Insert(0, branch);
            branchBindingSource.DataSource = listBranches;

            var listSemSy = ObjectQueries.GetSemSyEntities();
            var semSy = new SemSyEntity
                {
                    Semester = @"--- Select Semester/School Year ---"
                };
            listSemSy.Insert(0,semSy);
            semSyEntityBindingSource.DataSource = listSemSy;
            Cursor.Current = Cursors.Default;
        }

        private void FillTreeview(int iBranchId, int iSemId)
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lCourses = LoadQueries.GetCourses();
            var lCrsYrSec = ObjectQueries.GetCourseYearSection(iSemId);

            foreach (var college in lColleges)
            {
                TreeNode nodeParent = null;
                if (college.BranchId == iBranchId)
                {
                    nodeParent = new TreeNode(college.CollegeName) { Name = "College", Tag = college };

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
                                    var nodeChild02 = new TreeNode(course.CourseName) {Name = "Course", Tag = course};

                                    nodeChild01.Nodes.Add(nodeChild02);

                                    //var iCount = 0;
                                    foreach (var crs in lCrsYrSec)
                                    {
                                        if (crs.CourseId == course.CourseId)
                                        {
                                            //iCount += 1;
                                            //var tempDisplay = String.Format(@"{0} ({1})", crs.CrsYearSec, iCount);
                                            var nodeChild03 = new TreeNode(crs.CrsYearSec) {Name = "Crs", Tag = crs};

                                            nodeChild02.Nodes.Add(nodeChild03);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (nodeParent != null) treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void branchBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if ((branchBindingSource.Current != null) && (semSyEntityBindingSource.Current != null))
            {
                var branchId = ((Branch) branchBindingSource.Current).BranchId;
                var semSyId = ((SemSyEntity) semSyEntityBindingSource.Current).SemSyId;
                _iBrancId = branchId;
                FillTreeview(branchId, semSyId);
                if (checkBox1.Checked)
                {
                    GetAllRegistration();
                }
            }
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (branchBindingSource.Current != null)
            {
                var branchId = ((Branch)branchBindingSource.Current).BranchId;
                var semSyId = ((SemSyEntity)semSyEntityBindingSource.Current).SemSyId;
                _iSemSyId = semSyId;
                FillTreeview(branchId, semSyId);
                if (checkBox1.Checked)
                {
                    GetAllRegistration();
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _tempLabel = string.Empty;
            var tempCount = 0;
            switch (e.Node.Name)
            {
                case "College":
                    if (e.Node.Tag != null)
                    {
                        var iCollegeId = ((College)e.Node.Tag).CollegeId;
                        if ((_iBrancId > 0) && (_iSemSyId > 0) && (iCollegeId > 0))
                        {
                            _listRegistration = AcademicQueries.GetRegistrationEntity(_iSemSyId, _iBrancId, iCollegeId, 1);
                            registrationEntityBindingSource.DataSource = _listRegistration;
                            tempCount = registrationEntityBindingSource.Count;
                        }
                        _tempLabel = String.Format(@":: {0} : ({1})", e.Node.Text, tempCount);
                    }
                    break;
                case "Department":
                    if (e.Node.Tag != null)
                    {
                        var iDepartmentId = ((Department)e.Node.Tag).DepartmentId;
                        if ((_iBrancId > 0) && (_iSemSyId > 0) && (iDepartmentId > 0))
                        {
                            _listRegistration = AcademicQueries.GetRegistrationEntity(_iSemSyId, _iBrancId, iDepartmentId, 2);
                            registrationEntityBindingSource.DataSource = _listRegistration;
                            tempCount = registrationEntityBindingSource.Count;
                        }
                        _tempLabel = String.Format(@":: {0} : {1} : ({2})", e.Node.Parent.Text, e.Node.Text, tempCount);
                    }
                    break;
                case "Course":
                    if (e.Node.Tag != null)
                    {
                        var iCourseId = ((Cours)e.Node.Tag).CourseId;
                        if ((_iBrancId > 0) && (_iSemSyId > 0) && (iCourseId > 0))
                        {
                            _listRegistration = AcademicQueries.GetRegistrationEntity(_iSemSyId, _iBrancId, iCourseId, 3);
                            registrationEntityBindingSource.DataSource = _listRegistration;
                            tempCount = registrationEntityBindingSource.Count;
                        }
                        _tempLabel = String.Format(@":: {0} : {1} : {2} : ({3})", e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text, tempCount);
                    }
                    break;
                case "Crs":
                    if (e.Node.Tag != null)
                    {
                        var iYr = Convert.ToInt32(((CourseYearSectionEntity)e.Node.Tag).YearLevelId);
                        var iSec = Convert.ToInt32(((CourseYearSectionEntity)e.Node.Tag).SectionId);
                        var iCrs = Convert.ToInt32(((CourseYearSectionEntity)e.Node.Tag).CourseId);
                        if ((iYr > 0) && (iSec > 0) && (iCrs > 0))
                        {
                            _listRegistration = AcademicQueries.GetRegistrationEntity(_iSemSyId, _iBrancId, iYr, iSec, iCrs);
                            registrationEntityBindingSource.DataSource = _listRegistration;
                            tempCount = registrationEntityBindingSource.Count;
                        }
                        _tempLabel = String.Format(@":: {0} : {1} : {2} : {3} : ({4})", e.Node.Parent.Parent.Parent.Text, e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text, tempCount);
                    }
                    break;
                default:
                    MessageBox.Show(@"Please select an item from the treeview on the left side of the screen.",
                                    @"Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            label1.Text = _tempLabel;
            Cursor.Current = Cursors.Default;
        }

        private void GetAllRegisteredSubject(int iRegId)
        {
            Cursor.Current = Cursors.WaitCursor;
            registeredSubjectEntityBindingSource.DataSource = ScheduleManager.GetAllRegisteredSubjectEntity(iRegId);
            Cursor.Current = Cursors.Default;
        }

        private void registrationEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if ((registrationEntityBindingSource.Current != null) && (registrationEntityBindingSource.Count > 0))
            {
                var reg = Convert.ToInt32(((RegistrationEntity) registrationEntityBindingSource.Current).RegistrationId);
                if (reg > 0)
                {
                    GetAllRegisteredSubject(reg);
                    GetAllAssessment(reg);
                    GetAllPayment(reg);
                    if (registeredSubjectEntityBindingSource != null)
                        tabPage1.Text = String.Format(@"Subjects ({0})", registeredSubjectEntityBindingSource.Count);
                }
            }
        }

        private void GetAllPayment(int iRegId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var listReceipts = FinanceQueries.ListStudentPaymentMadeyRegistration(iRegId);
            receiptDetailEntityBindingSource.DataSource = listReceipts;
            var totalAmount = 0.00;
            foreach (var item in listReceipts)
            {
                totalAmount += Convert.ToDouble(item.PaidAmount);
            }
            labelPaid.Text = String.Format(@"{0:#,##0.00}", totalAmount);
            Cursor.Current = Cursors.Default;
        }

        private void GetAllAssessment(int iRegId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var listAssessEntity = new List<AssessEntity>();
            //assessEntityBindingSource.DataSource = listAssessEntity;
            var totalGross = 0.00;
            var totalDeduct = 0.00;
            var totalNet = 0.00;

            foreach (var item in AssessmentManager.GetAssessedEntityByRegistrationId(iRegId))
            {
                var a = item;
                if (!string.IsNullOrEmpty(item.LabParticulars))
                    a.Particulars += String.Format(@" - {0}", item.LabParticulars);
                totalGross += Convert.ToDouble(item.GrossAmt);
                totalDeduct += Convert.ToDouble(item.Deduction);
                totalNet += Convert.ToDouble(item.NetAmt);
                listAssessEntity.Add(a);
            }

            assessEntityBindingSource.DataSource = listAssessEntity;
            labelGross.Text = String.Format(@"{0:#,##0.00}", totalGross);
            labelDeduction.Text = String.Format(@"{0:#,##0.00}", totalDeduct);
            labelNet.Text = String.Format(@"{0:#,##0.00}", totalNet);
            Cursor.Current = Cursors.Default;
        }

        private void SearchRegistration(string criteria)
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((_listRegistration != null) && (_listRegistration.Count > 0))
            {
                registrationEntityBindingSource.DataSource =
                    _listRegistration.FindAll(f =>
                        (f.RegistrationId.ToString() == criteria) || (f.LastName.ToUpper().StartsWith(criteria)) ||
                        (f.FirstName.ToUpper().StartsWith(criteria)));
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            registrationEntityBindingSource.DataSource = _listRegistration;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 0)
            {
                SearchRegistration(toolStripTextBox1.Text.ToUpper());
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1.PerformClick();
            }
        }

        private void registrationEntityDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void registrationEntityDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void registrationEntityDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (registrationEntityBindingSource.Current != null)
                {
                    var tempString = new StringBuilder();
                    var r = (RegistrationEntity)registrationEntityBindingSource.Current;
                    if (r != null)
                    {
                        Validate();
                        var cell = r.Enrolled;
                        var tempIdNo = r.IdNo;
                        var tempName = r.FullName;
                        var tempCrsYrSec = r.YearCourseSection;
                        var tempRegNo = r.RegistrationId.ToString();
                        var tempRegDate = r.RegistrationDate;
                        var tempPaid = r.Paid == true ? @"YES" : @"NO";

                        tempString.AppendLine();
                        tempString.AppendLine(@"---------------------------------------------------");
                        tempString.AppendLine();
                        tempString.AppendLine(@"Reg. #: " + '\t' + '\t' + tempRegNo);
                        tempString.AppendLine(@"Date: " + '\t' + '\t' + String.Format(@"{0:d}", tempRegDate));
                        tempString.AppendLine();
                        tempString.AppendLine(@"ID No: " + '\t' + '\t' + tempIdNo);
                        tempString.AppendLine(@"Name: " + '\t' + '\t' + tempName);
                        tempString.AppendLine(@"CrsYrSec: " + '\t' + '\t' + tempCrsYrSec);
                        tempString.AppendLine(@"Paid: " + '\t' + '\t' + tempPaid);

                        var dDialog = new DialogResult();
                        if (Convert.ToBoolean(cell))
                        {
                            dDialog =
                                MessageBox.Show(
                                    @"Confirm this enrollment / MARK as enrolled?" + '\r' + '\n' + tempString.ToString(),
                                    @"Confirm/Final Screen Enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1);
                            if (dDialog == DialogResult.Yes)
                            {

                                var reg = ObjectQueries.GetRegistration(Convert.ToInt32(r.RegistrationId));
                                if (reg != null)
                                {
                                    reg.IsEnrolled = true;
                                    reg.FinalScreenedBy = UserEntity.UserId;
                                    var iResult = Save.Registrations(reg);
                                    UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                                }
                            }
                            else
                            {
                                registrationEntityDataGridView[8, e.RowIndex].Value = false;
                            }
                        }
                        else if (Convert.ToBoolean(cell) == false)
                        {
                            dDialog =
                                MessageBox.Show(
                                    @"Un-confirm this enrollment / MARK as NOT-enrolled?" + '\r' + '\n' +
                                    tempString.ToString(),
                                    @"Confirm/Final Screen Enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1);
                            if (dDialog == DialogResult.Yes)
                            {
                                Validate();
                                var reg = ObjectQueries.GetRegistration(Convert.ToInt32(r.RegistrationId));
                                if (reg != null)
                                {
                                    reg.IsEnrolled = false;
                                    reg.FinalScreenedBy = UserEntity.UserId;
                                    var iResult = Save.Registrations(reg);
                                    UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                                }
                            }
                            else
                            {
                                registrationEntityDataGridView[8, e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            //to do
                        }
                    }

                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GetAllRegistration();
            }
        }

        private void GetAllRegistration()
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((_iSemSyId > 0) && (_iBrancId > 0))
            {
                _listRegistration = AcademicQueries.GetRegistrationEntity(_iSemSyId, _iBrancId);
                registrationEntityBindingSource.DataSource = _listRegistration;
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
