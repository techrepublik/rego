using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class CourseSubjectForm : Form
    {
        private Prospectus _prospectus;
        private ProspectusSemYr _prospectusSemYr;

        public CourseSubjectForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lCourses = LoadQueries.GetCourses();
            var lProspectuses = LoadQueries.GetProspectuses();
            var lProspectusSemYr = LoadQueries.GetProspectusSemYr();

            foreach (var course in lCourses)
            {
                var nodeParent = new TreeNode(course.CourseName);
                nodeParent.Name = "Course";
                nodeParent.Tag = course;

                foreach (var prospectus in lProspectuses)
                {
                    if (prospectus.CourseId == course.CourseId)
                    {
                        var nodeChild01 = new TreeNode(prospectus.ProspectusName);
                        nodeChild01.Name = "Prospectus";
                        nodeChild01.Tag = prospectus;

                        nodeParent.Nodes.Add(nodeChild01);

                        foreach (var prospectusSemYr in lProspectusSemYr)
                        {
                            if (prospectusSemYr.ProspectusId == prospectus.ProspectusId)
                            {
                                var nodeChild02 = new TreeNode(prospectusSemYr.Semester.ToString() + ", " + prospectusSemYr.Sy );
                                nodeChild02.Name = "ProspectusSemYr";
                                nodeChild02.Tag = prospectusSemYr;

                                nodeChild01.Nodes.Add(nodeChild02);

                                ////foreach (var prospectusSemYr in lProspectusSemYr)
                                ////{
                                ////    if (prospectusSemYr.ProspectusId == prospectus.ProspectusId)
                                ////    {
                                //        var nodeChild03 = new TreeNode(prospectusSemYr.Semester.ToString() + ", " + prospectusSemYr.Sy);
                                //        nodeChild03.Name = "ProspectusSubject";
                                //        nodeChild03.Tag = prospectusSemYr;

                                //        nodeChild02.Nodes.Add(nodeChild03);
                                ////    }
                                ////}
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }


        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    using (var f = new ProspectusForm())
                    {
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f._Prospectus = _prospectus;
                        f.MaximizeBox = true;
                        f.MinimizeBox = true;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F10:
                    using (var f = new ProspectusSemYrForm())
                    {
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f._ProspectusSemYr = _prospectusSemYr;
                        f.MaximizeBox = true;
                        f.MinimizeBox = true;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F11:
                    using (var f = new ProspectusUpdateSubjectForm())
                    {
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f._ProspectusSemYr = _prospectusSemYr;
                        f.MaximizeBox = true;
                        f.MinimizeBox = true;
                        f.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
            FillTreeview();
            //treeView1.ExpandAll();
        }

        private void CourseSubjectForm_Load(object sender, EventArgs e)
        {
            FillTreeview();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Course":
                    break;
                case"Prospectus":
                    jTabWizard1.SelectedTab = tabPage1;
                    if (e.Node.Tag != null)
                    {
                        _prospectus = (Prospectus) e.Node.Tag;
                        PrintProspectusClassBindingSource.DataSource =
                            ObjectQueries.GetPrintProspectus(_prospectus.ProspectusId);
                        this.reportViewer1.RefreshReport();
                    }

                    break;
                case "ProspectusSemYr":
                    _prospectusSemYr = (ProspectusSemYr) e.Node.Tag;
                    //jTabWizard1.SelectedTab = tabPage2;
                    jTabWizard1.SelectedTab = tabPage3;
                    if (_prospectusSemYr != null)
                    {
                        prospectusSubjectEntityBindingSource.DataSource =
                            ObjectQueries.GetProspectusSubjectEntities(_prospectusSemYr.ProspectusSemYrId);

                        labelSemYrLevel.Text = String.Format(@"{0}/{1}", ((ProspectusSemYr) e.Node.Tag).SemesterName,
                                                             ((ProspectusSemYr) e.Node.Tag).Sy);
                        GetSumaary();
                    }
                    break;
                case "ProspectusSubject":
                    //_prospectusSubject = (ProspectusSubject) e.Node.Tag;
                    _prospectusSemYr = (ProspectusSemYr)e.Node.Parent.Tag;
                    jTabWizard1.SelectedTab = tabPage3;
                    if (_prospectusSemYr != null)
                    {
                        prospectusSubjectEntityBindingSource.DataSource =
                            ObjectQueries.GetProspectusSubjectEntities(_prospectusSemYr.ProspectusSemYrId);

                        labelSemYrLevel.Text = String.Format(@"{0}/{1}", ((ProspectusSemYr)e.Node.Tag).Semester,
                                                             ((ProspectusSemYr)e.Node.Tag).Sy);
                        GetSumaary();
                    }
                    break;
                default:
                    break;
            }
        }

        private void prospectusSubjectEntityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (prospectusSubjectEntityDataGridView.Rows.Count > 0)
            {
                if (prospectusSubjectEntityBindingSource.Current != null)
                    prospectusSubjectPreReqEntityBindingSource.DataSource =
                        ObjectQueries.GetProspectusSubjectPreReqEntities((int)((ProspectusSubjectEntity) prospectusSubjectEntityBindingSource.Current).ProspectusSubjectId);
                
            }
        }

        private void GetSumaary()
        {
            if (prospectusSubjectEntityBindingSource.DataSource != null)
            {
                var iSubjects = prospectusSubjectEntityBindingSource.Count;
                var fLecture = 0.00;
                var fLab = 0.00;
                var fCredit = 0.00;

                foreach (ProspectusSubjectEntity item in prospectusSubjectEntityBindingSource.List)
                {
                    if (item != null) fLecture += Convert.ToDouble(item.Lecture);
                    if (item != null) fLab += Convert.ToDouble(item.Laboratory);
                    if (item != null)
                    {
                        if (item.Credit >= 0)
                            fCredit += Convert.ToDouble(item.Credit);
                    }
                }

                labelNoSubjects.Text = iSubjects.ToString();
                labelLectureUnit.Text = fLecture.ToString();
                labelLaboratoryUnit.Text = fLab.ToString();
                labelCreditUnit.Text = fCredit.ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillTreeview();
        }
    }
}
