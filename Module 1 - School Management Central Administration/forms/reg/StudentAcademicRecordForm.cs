using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using Module_1___School_Management_Central_Administration.forms.reg;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class StudentAcademicRecordForm : Form
    {
        public YearLevelCourseSectionSemSyEntity StudentX { get; set; }

        private StudentSearchForm searchForm = null;

        public StudentAcademicRecordForm()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            using (searchForm = new StudentSearchForm(this))
            {
                searchForm.StartPosition = FormStartPosition.CenterScreen;
                searchForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                if (!string.IsNullOrEmpty(waterMarkTextSearch.Text) && (waterMarkTextSearch.Text.Length > 0))
                    searchForm.SearchValue = waterMarkTextSearch.Text;
                searchForm.MaximizeBox = false;
                searchForm.MinimizeBox = false;
                //searchForm.ShowDialog();
                if (searchForm.ShowDialog() == DialogResult.OK)
                    LoadData01();
            }
        }

        private void LoadData01()
        {
            if (StudentX != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                waterMarkTextSearch.Text = StudentX.IdNo;
                textBoxName.Text = StudentX.FullName;
                textBoxCrsYrSec.Text = StudentX.CrsYearSection;
                textBoxScholarship.Text = StudentX.ScholarshipName;
                textBoxSemSy.Text = StudentX.SemSyName;

                GetStudentPicture(StudentX.StudentId);

                if (StudentX.RegistrationId != null)
                {
                    FillTreeView(Convert.ToInt32(StudentX.StudentId));
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void GetStudentPicture(int iStudentId)
        {
            if (iStudentId > 0)
            {
                var s = ObjectQueries.GetStudentPicture(iStudentId);
                if (s != null)
                {
                    if (Convert.ToBoolean(s.IsActive))
                    {
                        pictureBox1.Image = UtilityManager.util.ImageClass.ByteToImage(s.Picture);
                    }
                }
            }
        }

        private void waterMarkTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGo.PerformClick();
            }
        }

        public void FillTreeView(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();

            var q = AcademicQueries.LoadYearLevelSemSyByRegistration(iStudentId);
            foreach (var item1 in q)
            {
                var nodeParent = new TreeNode(String.Format(@"{0}", item1.SemSyName));
                nodeParent.Name = @"SemYr";
                nodeParent.Tag = item1;

                foreach (var item2 in q)
                {
                    if (item1.SemSyId == item2.SemSyId)
                    {
                        var nodeChild01 =
                            new TreeNode(String.Format(@"{0}/{1}/{2} - {3}", item2.YearLevelName,
                                                       item2.CourseName, item2.SectionName, item2.ScholarshipName));
                        nodeChild01.Name = @"CrsYrSec";
                        nodeChild01.Tag = item2;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void StudentAcademicRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void PopulatDataGridView(int iRegistrationId)
        {
            Cursor.Current = Cursors.WaitCursor;
            bindingSource1.DataSource = AcademicQueries.LoadStudentSubjectEntityByRegistration(iRegistrationId);
            dataGridView1.DataSource = bindingSource1;
            var gradingPeriod = ObjectQueries.GetGradingPeriod();
            if (gradingPeriod != null)
            {
                //var id = dataGridView1.Columns["SubjectScheduleId"];
                //if (id != null)
                //    id.Visible = false;
                //var mid = dataGridView1.Columns["Midterm"];
                //if (mid != null)
                //    mid.Visible = false;
                //var fin = dataGridView1.Columns["FinalTerm"];
                //if (fin != null) fin.Visible = false;
                //var reg = dataGridView1.Columns["ReGrade"];
                //if (reg != null) reg.Visible = false;

                //var scheduleCode = dataGridView1.Columns["ScheduleCode"];
                //if (scheduleCode != null)
                //{
                //    scheduleCode.Visible = true;
                //    scheduleCode.HeaderText = @"Code";
                //    scheduleCode.Width = 80;
                //}

                //var subjectNo = dataGridView1.Columns["SubjectNo"];
                //if (subjectNo != null)
                //{
                //    subjectNo.Visible = true;
                //    subjectNo.HeaderText = @"Subject No";
                //}

                //var descriptiveTitle = dataGridView1.Columns["DescriptiveTitle"];
                //if (descriptiveTitle != null)
                //{
                //    descriptiveTitle.Visible = true;
                //    descriptiveTitle.HeaderText = @"Descriptive Title";
                //    descriptiveTitle.Width = 250;
                //}

                //var unit1 = dataGridView1.Columns["LaboratoryUnit"];
                //if (unit1 != null)
                //{
                //    unit1.Visible = true;
                //    unit1.HeaderText = @"Lab";
                //    unit1.Width = 60;
                //    unit1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //}

                //var unit2 = dataGridView1.Columns["LectureUnit"];
                //if (unit2 != null)
                //{
                //    unit2.Visible = true;
                //    unit2.HeaderText = @"Lec";
                //    unit2.Width = 60;
                //    unit2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    
                //}

                //var unit3 = dataGridView1.Columns["CreditUnit"];
                //if (unit3 != null)
                //{
                //    unit3.Visible = true;
                //    unit3.HeaderText = @"Credit";
                //    unit3.Width = 60;
                //    unit3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //}

                //var remark = dataGridView1.Columns["Remark"];
                //if (remark != null)
                //{
                //    remark.Visible = true;
                //    remark.HeaderText = @"Remark";
                //    remark.Width = 100;
                //}

                if (gradingPeriod.FirstGradingActive == true)
                {
                    var first = dataGridView1.Columns["FirstGrade"];
                    if (first != null)
                    {
                        first.Visible = true;
                        first.HeaderText = gradingPeriod.FirstGrading;
                        first.Width = 80;
                    }
                }
                else
                {
                    var first = dataGridView1.Columns["FirstGrade"];
                    if (first != null)
                        first.Visible = false;
                }
                if (gradingPeriod.SecondGradingActive == true)
                {
                    var second = dataGridView1.Columns["SecondGrade"];
                    if (second != null)
                    {
                        second.Visible = true;
                        second.HeaderText = gradingPeriod.SecondGrading;
                        second.Width = 80;
                    }
                }
                else
                {
                    var second = dataGridView1.Columns["SecondGrade"];
                    if (second != null)
                        second.Visible = false;
                }
                if (gradingPeriod.ThirdGradingActive == true)
                {
                    var third = dataGridView1.Columns["ThirdGrade"];
                    if (third != null)
                    {
                        third.Visible = true;
                        third.HeaderText = gradingPeriod.ThirdGrading;
                        third.Width = 80;
                    }
                }
                else
                {
                    var third = dataGridView1.Columns["ThirdGrade"];
                    if (third != null)
                        third.Visible = false;
                }
                if (gradingPeriod.FourthGradingActive == true)
                {
                    var fourth = dataGridView1.Columns["FourthGrade"];
                    if (fourth != null)
                    {
                        fourth.Visible = true;
                        fourth.HeaderText = gradingPeriod.FourthGrading;
                        fourth.Width = 80;
                    }
                }
                else
                {
                    var fourth = dataGridView1.Columns["FourthGrade"];
                    if (fourth != null)
                        fourth.Visible = false;
                }
                if (gradingPeriod.FifthGradingActive == true)
                {
                    var fifth = dataGridView1.Columns["FifthGrade"];
                    if (fifth != null)
                    {
                        fifth.Visible = true;
                        fifth.HeaderText = gradingPeriod.FifthGrading;
                        fifth.Width = 80;
                    }
                }
                else
                {
                    var fifth = dataGridView1.Columns["FifthGrade"];
                    if (fifth != null)
                        fifth.Visible = false;
                }
                if (gradingPeriod.SixthGradingActive == true)
                {
                    var sixth = dataGridView1.Columns["SixthGrade"];
                    if (sixth != null)
                    {
                        sixth.Visible = true;
                        sixth.HeaderText = gradingPeriod.SixthGrading;
                        sixth.Width = 80;
                    }
                }
                else
                {
                    var sixth = dataGridView1.Columns["SixthGrade"];
                    if (sixth != null)
                        sixth.Visible = false;
                }
            }

            studentSubjectEntityBindingNavigator.BindingSource = bindingSource1;
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "CrsYrSec":
                    var registrationId = ((YearLevelCourseSectionSemSyEntity) e.Node.Tag).RegistrationId;
                    if (registrationId != null)
                        PopulatDataGridView((int) registrationId);
                    break;
                default:
                    break;
            }
        }
    }
}
