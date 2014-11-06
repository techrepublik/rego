using System;
using System.Drawing;
using System.Windows.Forms;
using Module_1___School_Management_Central_Administration.forms.csm;
using Module_1___School_Management_Central_Administration.forms.gen;
using Module_1___School_Management_Central_Administration.forms.acc;
using Module_1___School_Management_Central_Administration.forms.reg;
using Module_1___School_Management_Central_Administration.forms.adm;
using GenDataLayer.repo.entities;
using GenDataLayer;

namespace Module_1___School_Management_Central_Administration
{
    public partial class Form1 : Form
    {
        public UserEntity UserEntity { get; set; }
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }

        private CollegeUnitListForm _cf;
        private AccountListForm _af;
        private SubjectListForm _sf;
        private CollegeRoomForm _rf;
        private CourseSubjectForm _cpf;
        private ScheduleListForm _sf1;
        private ScheduleFeeListForm _sf2;
        private PresetFeeListForm _sf3;
        private LaboratoryFeeListForm _sf4;
        private ScholarshipListForm _sf5;
        private EnrollmentSummaryForm _sf6;
        private ClassListForm _sf7;
        private StudentlistForm _sf8;
        private StudentLedgerForm _sf10;
        private UserListForm _sf11;
        private StudentBalancesForm _sf13;
        private StudentAcademicRecordForm _sf14;
        private RegistrarPreferencesForm _sf15;
        private TeacherListForm _sf16;
        private DepartmentTeacherExploreForm _sf17;
        private DepartmentSubjectForm _dsf;
        private StudentGradeEntryForm _sf19;
        private AssignSubjectTeacherForm _sf18;
        private PostGradeListForm _sf20;
        private FinalScreeningForm _sf21;

        public Form1()
        {
            InitializeComponent();
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "lnitialSetup":
                    using (var pf = new PreferencesForm())
                    {
                        pf.FormBorderStyle = FormBorderStyle.FixedSingle;
                        pf.StartPosition = FormStartPosition.CenterScreen;
                        pf.MinimizeBox = false;
                        pf.MaximizeBox = false;
                        pf.ShowDialog();
                    }
                    break;
                case "LookTables":
                    using (var lf = new LookUpTableForm())
                    {
                        lf.FormBorderStyle = FormBorderStyle.FixedSingle;
                        lf.StartPosition = FormStartPosition.CenterScreen;
                        lf.MinimizeBox = false;
                        lf.MaximizeBox = false;
                        lf.ShowDialog();
                    }
                    break;
                case "CollegeUnitList":
                    if ((_cf == null) || (_cf.IsDisposed))
                    {
                        _cf = new CollegeUnitListForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _cf.Show();
                    }

                    _cf.Show();
                    _cf.BringToFront();
                    break;
                case "AccountList":
                    if ((_af == null) || (_af.IsDisposed))
                    {
                        _af = new AccountListForm
                            {
                                MdiParent = this,
                                Branch = Branch,
                                SemSyEntity = SemSyEntity,
                                UserEntity = UserEntity
                            };
                        _af.Show();
                    }
                    _af.Show();
                    _af.BringToFront();
                    break;
                case "SubjectList":
                    if ((_sf == null) || (_sf.IsDisposed))
                    {
                        _sf = new SubjectListForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _sf.Show();
                    }
                    _sf.Show();
                    _sf.BringToFront();
                    break;
                case "Rooms":
                    if ((_rf == null) || (_rf.IsDisposed))
                    {
                        _rf = new CollegeRoomForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _rf.Show();
                    }

                    _rf.Show();
                    _rf.BringToFront();
                    break;
                case "CourseProspectuses":
                    if ((_cpf == null) || (_cpf.IsDisposed))
                    {
                        _cpf = new CourseSubjectForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _cpf.Show();
                    }
                    _cpf.Show();
                    _cpf.BringToFront();
                    break;
                case "DepartmentSubjects":
                    if ((_dsf == null) || (_dsf.IsDisposed))
                    {
                        _dsf = new DepartmentSubjectForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _dsf.Show();
                    }
                    _dsf.Show();
                    _dsf.BringToFront();
                    break;
                case "Scheduling":
                    if ((_sf1 == null) || (_sf1.IsDisposed))
                    {
                        _sf1 = new ScheduleListForm
                            {
                                MdiParent = this,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _sf1.Show();
                    }
                    _sf1.Show();
                    _sf1.BringToFront();
                    break;
                case "ScheduleFees":
                    if ((_sf2 == null) || (_sf2.IsDisposed))
                    {
                        _sf2 = new ScheduleFeeListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _sf2.Show();
                    }
                    _sf2.Show();
                    _sf2.BringToFront();
                    break;
                case "PresetFees":
                    if ((_sf3 == null) || (_sf3.IsDisposed))
                    {
                        _sf3 = new PresetFeeListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                    }
                    _sf3.Show();
                    _sf3.BringToFront();
                    break;
                case "LaboratoryFees":
                    if ((_sf4 == null) || (_sf4.IsDisposed))
                    {
                        _sf4 = new LaboratoryFeeListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized,
                                //Branch = Branch,
                                //SemSyEntity = SemSyEntity,
                                //UserEntity = UserEntity
                            };
                        _sf4.Show();
                    }
                    _sf4.Show();
                    _sf4.BringToFront();
                    break;
                case "ScholarshipFees":
                    if ((_sf5 == null) || (_sf5.IsDisposed))
                    {
                        _sf5 = new ScholarshipListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf5.Show();
                    }
                    _sf5.Show();
                    _sf5.BringToFront();
                    break;
                case "EnrollmentSummary":
                    if ((_sf6 == null) || (_sf6.IsDisposed))
                    {
                        _sf6 = new EnrollmentSummaryForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized,
                                Branch = Branch,
                                SemSyEntity = SemSyEntity,
                                UserEntity = UserEntity
                            };
                        _sf6.Show();
                    }
                    _sf6.Show();
                    _sf6.BringToFront();
                    break;
                case "ClassList":
                    if ((_sf7 == null) || (_sf7.IsDisposed))
                    {
                        _sf7 = new ClassListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized,
                                Branch = Branch,
                                SemSyEntity = SemSyEntity,
                                UserEntity = UserEntity
                            };
                        _sf7.Show();
                    }
                    _sf7.Show();
                    _sf7.BringToFront();
                    break;
                case "StudentList":
                    if ((_sf8 == null) || (_sf8.IsDisposed))
                    {
                        _sf8 = new StudentlistForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf8.Show();
                    }
                    _sf8.Show();
                    _sf8.BringToFront();
                    break;
                case "SchoolBranch":
                    using (var sf9 = new SchoolBranchForm())
                    {
                        sf9.StartPosition = FormStartPosition.CenterScreen;
                        sf9.FormBorderStyle = FormBorderStyle.FixedSingle;
                        sf9.MinimizeBox = false;
                        sf9.MaximizeBox = false;
                        sf9.ShowDialog();
                    }
                    break;
                case "StudentLedger":
                    //using (var sf10 = new StudentLedgerForm())
                    //{
                    //    //sf10.StartPosition = FormStartPosition.CenterScreen;
                    //    //sf10.ShowDialog();

                    //    sf10.WindowState = FormWindowState.Maximized;
                    //    sf10.MdiParent = this;
                    //    sf10.Show();
                    //}
                    if ((_sf10 == null) || (_sf10.IsDisposed))
                    {
                        _sf10 = new StudentLedgerForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                    }
                    _sf10.Show();
                    _sf10.BringToFront();
                    break;
                case "Users":
                    if ((_sf11 == null) || (_sf11.IsDisposed))
                    {
                        _sf11 = new UserListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf11.Show();
                    }
                    _sf11.Show();
                    _sf11.BringToFront();
                    break;
                case "Address":
                    using (var sf12 = new AddressListForm())
                    {
                        sf12.FormBorderStyle = FormBorderStyle.FixedSingle;
                        sf12.MaximizeBox = false;
                        sf12.MinimizeBox = false;
                        sf12.StartPosition = FormStartPosition.CenterScreen;
                        sf12.ShowDialog();
                    }
                    break;
                case "StudentBalances":
                    if ((_sf13 == null) || (_sf13.IsDisposed))
                    {
                        _sf13 = new StudentBalancesForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf13.Show();
                    }
                    _sf13.Show();
                    _sf13.BringToFront();
                    break;
                case "StudentRecord":
                    if ((_sf14 == null) || (_sf14.IsDisposed))
                    {
                        _sf14 = new StudentAcademicRecordForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf14.Show();
                    }
                    _sf14.Show();
                    _sf14.BringToFront();
                    break;
                case "RegPreferences":
                    if ((_sf15 == null) || (_sf15.IsDisposed))
                    {
                        _sf15 = new RegistrarPreferencesForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf15.Show();
                    }
                    _sf15.Show();
                    _sf15.BringToFront();
                    break;
                case "TeacherList":
                    if ((_sf16 == null) || (_sf16.IsDisposed))
                    {
                        _sf16 = new TeacherListForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf16.Show();
                    }
                    _sf16.Show();
                    _sf16.BringToFront();
                    break;
                case "DeparmentTeachers":
                    if ((_sf17 == null) || (_sf17.IsDisposed))
                    {
                        _sf17 = new DepartmentTeacherExploreForm
                            {
                                MdiParent = this,
                                WindowState = FormWindowState.Maximized
                            };
                        _sf17.Show();
                    }
                    _sf17.Show();
                    _sf17.BringToFront();
                    break;
                case "AssignSubjectTeacher":
                    if ((_sf18 == null) || (_sf19.IsDisposed))
                    {
                        _sf18 = new AssignSubjectTeacherForm
                            {
                                WindowState = FormWindowState.Maximized,
                                MdiParent = this
                            };
                        _sf18.Show();
                    }

                    _sf18.Show();
                    _sf18.BringToFront();
                    break;
                case "GradeEntry":
                    if ((_sf19 == null) || (_sf19.IsDisposed))
                    {
                        _sf19 = new StudentGradeEntryForm
                            {
                                WindowState = FormWindowState.Maximized,
                                MdiParent = this
                            };
                        _sf19.Show();
                    }

                    _sf19.Show();
                    _sf19.BringToFront();
                    break;
                case "PostedSubjectGrade":
                    if ((_sf20 == null) || (_sf20.IsDisposed))
                    {
                        _sf20 = new PostGradeListForm
                            {
                                WindowState = FormWindowState.Maximized,
                                MdiParent = this
                            };
                        _sf20.Show();
                    }

                    _sf20.Show();
                    _sf20.BringToFront();
                    break;
                case "FinancialReport":
                    using (var f = new ReportListReceiptsForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.Branch = Branch;
                        f.SemSyEntity = SemSyEntity;
                        f.ShowDialog();
                    }
                    break;
                case "UpdateAssessment":
                    using (var f = new UpdateAssessmentForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.MinimizeBox = false;
                        f.MaximizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case "FinalScreening":
                    if ((_sf21 == null) || (_sf21.IsDisposed))
                    {
                        _sf21 = new FinalScreeningForm
                            {
                                WindowState = FormWindowState.Maximized,
                                MdiParent = this,
                                Branch = Branch,
                                UserEntity = UserEntity,
                                SemSyEntity = SemSyEntity
                            };
                        _sf21.Show();
                    }

                    _sf21.Show();
                    _sf21.BringToFront();
                    break;
                default:
                    //MessageBox.Show(@"Invalid menu.", @"Menu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupPreferences();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing &&
                        MessageBox.Show(@"You're terminate the application. Continue...?",
                                        Text + @" Close Application",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2) != DialogResult.Yes);

            if (e.Cancel != true)
            {
                Application.Exit();
            }
        }

        private void SetupPreferences()
        {
            const string toolName = @"None";
            if (UserEntity != null)
            {
                ultraStatusBar1.Panels[2].Text = String.Format(@"User: {0}", UserEntity.UserFullName);
            }
            else
            {
                ultraStatusBar1.Panels[2].Text = String.Format(@"User: {0}", toolName);
            }

            if (Branch != null)
            {
                ultraStatusBar1.Panels[1].Text = String.Format(@"Branch: {0}", Branch.BranchName);
                this.Text = String.Format(@"Module 1 - Central Administration - [ {0} ]", Branch.BranchName);
            }
            else
            {
                ultraStatusBar1.Panels[1].Text = String.Format(@"Branch: {0}", toolName);
                this.Text = String.Format(@"Module 1 - Central Administration - [ {0} ]", toolName);
            }
            
            if (SemSyEntity != null)
            {
                ultraStatusBar1.Panels[3].Text = String.Format(@"Sem/Sy: {0}", SemSyEntity.SemSyName);
                ultraStatusBar1.Panels[2].Appearance.ForeColor = Color.Blue;
            }
            else
            {
                ultraStatusBar1.Panels[3].Text = String.Format(@"Sem/Sy: {0}", toolName);
                ultraStatusBar1.Panels[2].Appearance.ForeColor = Color.Red;
            }
                

                
        }
    }
}
