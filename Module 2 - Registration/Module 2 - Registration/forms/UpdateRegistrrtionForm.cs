using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;

namespace Module_2___Registration.forms
{
    public partial class UpdateRegistrrtionForm : Form
    {
        public UserEntity UserEntity { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public Branch Branch { get; set; }

        public RegistrationEntity RegistrationEntity { get; set; }

        private readonly UpdateRegForm _updateRegForm;
        private readonly RegistrationForm _registrationForm;
        public UpdateRegistrrtionForm(RegistrationForm form)
        {
            _updateRegForm = new UpdateRegForm(this);
            _registrationForm = form;
            InitializeComponent();
        }

        private void UpdateRegistrrtionForm_Load(object sender, EventArgs e)
        {
            GetPreferences();
        }

        public void GetPreferences()
        {
            if (Branch != null)
            {
                labelBranch.Text = Branch.BranchName;
            }
            else
            {
                labelBranch.Text = @"<<..>>";
            }

            if (SemSyEntity != null)
            {
                labelSemSy.Text = SemSyEntity.SemSyName;
            }
            else
            {
                labelSemSy.Text = @"<<..>>";
            }

            const string tempLabel = @"<<..>>";
            if (RegistrationEntity != null)
            {
                labelId.Text = RegistrationEntity.IdNo;
                labelLast.Text = RegistrationEntity.LastName.ToUpper();
                labelFirst.Text = RegistrationEntity.FirstName.ToUpper();
                labelMiddle.Text = RegistrationEntity.MiddleName.ToUpper();
                labelCrsYrSec.Text = RegistrationEntity.YearCourseSection;
                checkBoxCancelled.Checked = Convert.ToBoolean(RegistrationEntity.Cancelled);
                checkBox1Paid.Checked = Convert.ToBoolean(RegistrationEntity.Paid);
                checkBoxEnrolled.Checked = Convert.ToBoolean(RegistrationEntity.Enrolled);
                labelCourse.Text = RegistrationEntity.CourseName;
                labelCurriculum.Text = RegistrationEntity.CurriculumName;
                labelStatus.Text = RegistrationEntity.StatusName;
                labelType.Text = RegistrationEntity.TypeName;
                textBoxScholarship.Text = RegistrationEntity.ScholarshipName;
                buttonOk.Enabled = true;
            }
            else
            {
                labelId.Text = tempLabel;
                labelLast.Text = tempLabel;
                labelFirst.Text = tempLabel;
                labelMiddle.Text = tempLabel;
                labelCrsYrSec.Text = tempLabel;
                checkBoxCancelled.Checked = false;
                checkBox1Paid.Checked = false;
                checkBoxEnrolled.Checked = false;
                labelCourse.Text = tempLabel;
                labelCurriculum.Text = tempLabel;
                labelStatus.Text = tempLabel;
                labelType.Text = tempLabel;
                textBoxScholarship.Text = tempLabel;
                buttonOk.Enabled = false;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _updateRegForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _updateRegForm.StartPosition = FormStartPosition.CenterScreen;
            _updateRegForm.MaximizeBox = false;
            _updateRegForm.MinimizeBox = false;
            _updateRegForm.UserEntity = UserEntity;
            _updateRegForm.SemSyEntity = SemSyEntity;
            _updateRegForm.Branch = Branch;
            if (RegistrationEntity != null)
            {
                _updateRegForm.RegistrationEntity = RegistrationEntity;
                //_updateRegForm.RegistrationEntity = null;
                //_updateRegForm.StudentEntity = null;
                _updateRegForm.GetStudentRegistration();
            }
            _updateRegForm.ShowDialog(); 
               
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (RegistrationEntity != null)
            {
                if ((RegistrationEntity.StudentId > 0) && (RegistrationEntity.SemSyId > 0))
                {
                    var cancelled = RegistrationEntity.Cancelled ?? false;
                    var enrolled = RegistrationEntity.Enrolled ?? false;
                    var paid = RegistrationEntity.Paid ?? false;

                    var r = new Registration
                        {
                            RegistrationId = Convert.ToInt32(RegistrationEntity.RegistrationId),
                            RegistrationDate = RegistrationEntity.RegistrationDate,
                            IsCancelled = cancelled, //RegistrationEntity.Cancelled,
                            IsEnrolled = enrolled, //RegistrationEntity.Enrolled,
                            IsPaid = paid, //RegistrationEntity.Paid,
                            CourseId = RegistrationEntity.CourseId,
                            ProspectusId = RegistrationEntity.ProspectusId,
                            StudentTypeId = RegistrationEntity.TypeId,
                            StudentStatusId = RegistrationEntity.StatusId,
                            YearLevelId = RegistrationEntity.YearLevelId,
                            SectionId = RegistrationEntity.SectionId,
                            ScholarshipId = RegistrationEntity.ScholarshipId,
                            StudentId = RegistrationEntity.StudentId,
                            SemSyId = RegistrationEntity.SemSyId,
                            BranchId = RegistrationEntity.BranchId,
                            UserId = RegistrationEntity.UserId,
                            ModifiedByUserId = RegistrationEntity.ModifiedById,
                        };
                    var iResult = Save.Registrations(r);
                    if (iResult > 0)
                    {
                        RegistrationEntity.RegistrationNo = iResult.ToString();
                        RegistrationEntity.RegistrationId = r.RegistrationId;
                        _registrationForm.RegistrationEntity = RegistrationEntity;        
                    }
                }
            }
        }

    }
}
