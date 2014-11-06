using System.Diagnostics;
using GenDataLayer.repo.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;

namespace Module_2___Registration.forms
{
    public partial class UpdateRegForm : Form
    {
        public UserEntity UserEntity { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public Branch Branch { get; set; }

        public bool UpdateAction { get; set; }
        public RegistrationEntity RegistrationEntity { get; set; }
        public Student StudentEntity { get; set; }

        private readonly SearchStudentForm _searchStudentForm;
        private readonly UpdateRegistrrtionForm _updateRegistrrtionForm;
        public UpdateRegForm(UpdateRegistrrtionForm form)
        {
            _searchStudentForm = new SearchStudentForm(this);
            _updateRegistrrtionForm = form;
            InitializeComponent();
        }

        private void UpdateRegForm_Load(object sender, EventArgs e)
        {
            GetAllReferences();
            

            GetStudentRegistration();
            GetPreferences();

            if (RegistrationEntity == null)
                SetInitialStateContorls();
        }

        private void GetPreferences()
        {
            if (SemSyEntity != null)
            {
                labelSemSy.Text = SemSyEntity.SemSyName;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (RegistrationEntity == null)
            {
                RegistrationEntity = new RegistrationEntity();
                RegistrationEntity.IdNo = StudentEntity.IdNo;
                RegistrationEntity.StudentId = StudentEntity.StudentId;
                RegistrationEntity.LastName = StudentEntity.LastName;
                RegistrationEntity.FirstName = StudentEntity.FirstName;
                RegistrationEntity.MiddleName = StudentEntity.MiddleName;
            }

            if (RegistrationEntity.RegistrationDate == null)
                RegistrationEntity.RegistrationDate = DateTime.Now;
            RegistrationEntity.SemSyId = SemSyEntity.SemSyId;
            RegistrationEntity.BranchId = Branch.BranchId;
            RegistrationEntity.UserId = UserEntity.UserId;
            RegistrationEntity.ModifiedById = UserEntity.UserId;
            //if (UpdateAction)
            //{
                RegistrationEntity.CourseId = ((Cours) coursBindingSource.Current).CourseId;
                RegistrationEntity.CourseName = ((Cours)coursBindingSource.Current).CourseName;
                RegistrationEntity.Course = ((Cours)coursBindingSource.Current).Abbreviation;
                RegistrationEntity.ProspectusId = ((Prospectus) prospectusBindingSource.Current).ProspectusId;
                RegistrationEntity.CurriculumName = ((Prospectus)prospectusBindingSource.Current).ProspectusName;
                RegistrationEntity.YearLevelId = ((YearLevel) yearLevelBindingSource.Current).YearLevelId;
                RegistrationEntity.YearLevel = ((YearLevel)yearLevelBindingSource.Current).YearLevelName;
                RegistrationEntity.SectionId = ((Section) sectionBindingSource.Current).SectionId;
                RegistrationEntity.Section = ((Section)sectionBindingSource.Current).SectionName;
                RegistrationEntity.StatusId = ((StudentStatus) studentStatusBindingSource.Current).StudentStatusId;
                RegistrationEntity.StatusName = ((StudentStatus)studentStatusBindingSource.Current).StatusName;
                RegistrationEntity.TypeId = ((StudentType) studentTypeBindingSource.Current).StudenTypeId;
                RegistrationEntity.TypeName = ((StudentType)studentTypeBindingSource.Current).StudentTypeName;
                RegistrationEntity.ScholarshipId = ((Scholarship) scholarshipBindingSource.Current).ScholarshipId;
                RegistrationEntity.ScholarshipName= ((Scholarship)scholarshipBindingSource.Current).ScholarshipName;
            //}
             _updateRegistrrtionForm.RegistrationEntity = RegistrationEntity;
            _updateRegistrrtionForm.GetPreferences();
            Close();
        }

        private void GetAllReferences()
        {
            Cursor.Current = Cursors.WaitCursor;
            coursBindingSource.DataSource = LoadQueries.GetCourses();
            yearLevelBindingSource.DataSource = LoadQueries.GetYearLevels();
            sectionBindingSource.DataSource = LoadQueries.GetSections();
            studentStatusBindingSource.DataSource = LoadQueries.GetStatus();
            studentTypeBindingSource.DataSource = LoadQueries.GetStudentType();
            scholarshipBindingSource.DataSource = LoadQueries.GetScholarships();
            prospectusBindingSource.DataSource = LoadQueries.GetProspectuses();
            Cursor.Current = Cursors.Default;
        }

        public void GetStudentRegistration()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (UpdateAction == true)
                labelAction.Text = @"New Enrollment";
            else
                labelAction.Text = @"Updating...";

            if (RegistrationEntity != null)
            {
                labelIdNo.Text = RegistrationEntity.IdNo;
                labelFullName.Text = RegistrationEntity.FullName;
                labelCrsYrSec.Text = RegistrationEntity.YearCourseSection;
                checkBoxCancelled.Checked = Convert.ToBoolean(RegistrationEntity.Cancelled);
                checkBox1Paid.Checked = Convert.ToBoolean(RegistrationEntity.Paid);
                checkBoxEnrolled.Checked = Convert.ToBoolean(RegistrationEntity.Enrolled);
                if (UpdateAction)
                {
                    RegistrationEntity.RegistrationId = 0;

                    //if (RegistrationEntity.CourseId > 0)
                    //    comboBoxCourse.SelectedValue = RegistrationEntity.CourseId;
                    //else
                    comboBoxCourse.SelectedIndex = -1;

                    //if (RegistrationEntity.ProspectusId > 0)
                    //    comboBoxCurriculum.SelectedValue = RegistrationEntity.ProspectusId;
                    //else
                    comboBoxCurriculum.SelectedIndex = -1;

                    //if (RegistrationEntity.YearLevelId > 0)
                    //    comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                    //else
                    comboBoxYearLevel.SelectedIndex = -1;

                    //if (RegistrationEntity.SectionId > 0)
                    //    comboBoxSection.SelectedValue = RegistrationEntity.SectionId;
                    //else
                    comboBoxSection.SelectedIndex = -1;

                    //if (RegistrationEntity.ScholarshipId > 0)
                    //    comboBoxScholarship.SelectedValue = RegistrationEntity.ScholarshipId;
                    //else
                    comboBoxScholarship.SelectedIndex = -1;

                    //if (RegistrationEntity.StatusId > 0)
                    //    comboBoxStatus.SelectedValue = RegistrationEntity.StatusId;
                    //else
                    comboBoxStatus.SelectedIndex = -1;

                    //if (RegistrationEntity.YearLevelId > 0)
                    //    comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                    //else
                    comboBoxYearLevel.SelectedIndex = -1;

                    //if (RegistrationEntity.TypeId > 0)
                    //    comboBoxType.SelectedValue = RegistrationEntity.TypeId;
                    //else
                    comboBoxType.SelectedIndex = -1;
                }
                else
                {
                    if (RegistrationEntity.CourseId > 0)
                        comboBoxCourse.SelectedValue = RegistrationEntity.CourseId;
                    else
                        comboBoxCourse.SelectedIndex = -1;

                    if (RegistrationEntity.ProspectusId > 0)
                        comboBoxCurriculum.SelectedValue = RegistrationEntity.ProspectusId;
                    else
                        comboBoxCurriculum.SelectedIndex = -1;

                    if (RegistrationEntity.YearLevelId > 0)
                        comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                    else
                        comboBoxYearLevel.SelectedIndex = -1;

                    if (RegistrationEntity.SectionId > 0)
                        comboBoxSection.SelectedValue = RegistrationEntity.SectionId;
                    else
                        comboBoxSection.SelectedIndex = -1;

                    if (RegistrationEntity.ScholarshipId > 0)
                    {
                        comboBoxScholarship.SelectedValue = RegistrationEntity.ScholarshipId;

                    }
                    else
                        comboBoxScholarship.SelectedIndex = -1;

                    if (RegistrationEntity.StatusId > 0)
                        comboBoxStatus.SelectedValue = RegistrationEntity.StatusId;
                    else
                        comboBoxStatus.SelectedIndex = -1;

                    if (RegistrationEntity.YearLevelId > 0)
                        comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                    else
                        comboBoxYearLevel.SelectedIndex = -1;

                    if (RegistrationEntity.TypeId > 0)
                        comboBoxType.SelectedValue = RegistrationEntity.TypeId;
                    else
                        comboBoxType.SelectedIndex = -1;
                }
            }
            else
            {
                if (StudentEntity != null)
                {
                    labelIdNo.Text = StudentEntity.IdNo;
                    var r = new RegistrationEntity();
                    r.StudentId = StudentEntity.StudentId;
                    r.IdNo = StudentEntity.IdNo;
                    r.LastName = StudentEntity.LastName;
                    r.FirstName = StudentEntity.FirstName;
                    r.MiddleName = StudentEntity.MiddleName;
                    r.RegistrationId = 0;
                    var newStud = ObjectQueries.GetStudentRegistrationById(StudentEntity.StudentId);
                    labelFullName.Text = r.FullName;
                    if (newStud != null)
                    {
                        r.CourseId = newStud.CourseId;
                        r.ProspectusId = newStud.ProspectusId;
                        r.YearLevelId = newStud.YearLevelId;
                        r.SectionId = newStud.SectionId;
                        r.StatusId = newStud.StatusId;
                        r.TypeId = newStud.TypeId;
                        r.Course = newStud.Course;
                        r.YearLevel = newStud.YearLevel;
                        r.Section = newStud.Section;
                        RegistrationEntity = r;
                        labelCrsYrSec.Text = RegistrationEntity.YearCourseSection;
                        if (RegistrationEntity.CourseId > 0)
                            comboBoxCourse.SelectedValue = RegistrationEntity.CourseId;
                        else
                            comboBoxCourse.SelectedIndex = -1;

                        if (RegistrationEntity.ProspectusId > 0)
                            comboBoxCurriculum.SelectedValue = RegistrationEntity.ProspectusId;
                        else
                            comboBoxCurriculum.SelectedIndex = -1;

                        if (RegistrationEntity.YearLevelId > 0)
                            comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                        else
                            comboBoxYearLevel.SelectedIndex = -1;

                        if (RegistrationEntity.SectionId > 0)
                            comboBoxSection.SelectedValue = RegistrationEntity.SectionId;
                        else
                            comboBoxSection.SelectedIndex = -1;

                        if (RegistrationEntity.ScholarshipId > 0)
                        {
                            comboBoxScholarship.SelectedValue = RegistrationEntity.ScholarshipId;
                        }
                        else
                            comboBoxScholarship.SelectedIndex = -1;

                        if (RegistrationEntity.StatusId > 0)
                            comboBoxStatus.SelectedValue = RegistrationEntity.StatusId;
                        else
                            comboBoxStatus.SelectedIndex = -1;

                        if (RegistrationEntity.YearLevelId > 0)
                            comboBoxYearLevel.SelectedValue = RegistrationEntity.YearLevelId;
                        else
                            comboBoxYearLevel.SelectedIndex = -1;

                        if (RegistrationEntity.TypeId > 0)
                            comboBoxType.SelectedValue = RegistrationEntity.TypeId;
                        else
                            comboBoxType.SelectedIndex = -1;
                    }
                    else
                    {
                        comboBoxCourse.SelectedIndex = -1;
                        comboBoxCurriculum.SelectedIndex = -1;
                        comboBoxYearLevel.SelectedIndex = -1;
                        comboBoxSection.SelectedIndex = -1;
                        comboBoxScholarship.SelectedIndex = -1;
                        comboBoxStatus.SelectedIndex = -1;
                        comboBoxYearLevel.SelectedIndex = -1;
                        comboBoxType.SelectedIndex = -1;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void coursBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (coursBindingSource.Current != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                prospectusBindingSource.DataSource = null;
                prospectusBindingSource.DataSource =
                    ObjectQueries.GetProspectusCourse(((Cours) coursBindingSource.Current).CourseId);
                Cursor.Current = Cursors.Default;
            }
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            _searchStudentForm.StartPosition = FormStartPosition.CenterScreen;
            _searchStudentForm.MaximizeBox = false;
            _searchStudentForm.MinimizeBox = false;
            _searchStudentForm.SemSyEntity = SemSyEntity;
            _searchStudentForm.Branch = Branch;
            _searchStudentForm.UserEntity = UserEntity;
            _searchStudentForm.ShowDialog();   
        }

        public void SetInitialStateContorls()
        {
            comboBoxCourse.SelectedIndex = -1;
            comboBoxScholarship.SelectedIndex = -1;
            comboBoxCurriculum.SelectedIndex = -1;
            comboBoxSection.SelectedIndex = -1;
            comboBoxYearLevel.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            comboBoxType.SelectedIndex = -1;
            listBoxScholarship.Items.Clear();
        }
    }
}
