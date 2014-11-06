using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;

namespace Module_2___Registration.forms
{
    public partial class SearchStudentForm : Form
    {
        public UserEntity UserEntity { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public Branch Branch { get; set; }

        public string SearchCriteria { get; set; }

        private StudentEntity _student ;
        private RegistrationEntity _registrationEntity;

        private readonly UpdateRegForm _updateRegForm;
        public SearchStudentForm(UpdateRegForm form)
        {
            _updateRegForm = form;
            InitializeComponent();
        }

        private void SearchStudentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void GetStudents()
        {
            if (waterMarkTextBox1.Text != string.Empty)
            {
                Cursor.Current = Cursors.WaitCursor;
                studentEntityBindingSource.DataSource =  ObjectQueries.GetStudentEntity01(waterMarkTextBox1.Text);
                Cursor.Current = Cursors.Default;
            }
        }

        private void studentEntityDataGridView_Enter(object sender, EventArgs e)
        {
            
        }

        private void studentEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (studentEntityBindingSource.Current != null)
            {
                _student = (StudentEntity)studentEntityBindingSource.Current;
                toolStripStatusLabel1.Text = string.Format(@"{0} - {1}", _student.IdNo, _student.FullName);
                //if ((_student.StudentId > 0) && (SemSyEntity.SemSyId > 0))
                //{
                //    if (ObjectQueries.CheckIfEnrolledSemSyStudent(SemSyEntity.SemSyId, _student.StudentId) > 0)
                //    {
                //        buttonNew.Enabled = false;
                //        buttonUpdate.Enabled = true;
                //    }
                //    else
                //    {
                //        buttonNew.Enabled = true;
                //        buttonUpdate.Enabled = false;
                //    }
                //}
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (_student != null)
            {
                _registrationEntity = ObjectQueries.GetStudentRegistration(SemSyEntity.SemSyId, _student.StudentId);
                _updateRegForm.RegistrationEntity = _registrationEntity;
                _updateRegForm.UpdateAction = true;
                _updateRegForm.StudentEntity = _student;
                _updateRegForm.UserEntity = UserEntity;
                _updateRegForm.SemSyEntity = SemSyEntity;
                _updateRegForm.Branch = Branch;
                _updateRegForm.UpdateAction = true;
                _updateRegForm.GetStudentRegistration();
                if ((_updateRegForm == null) || (_updateRegForm.IsDisposed))
                    _updateRegForm.ShowDialog();         
            }
            Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_student != null)
            {
                _registrationEntity = ObjectQueries.GetStudentRegistration(SemSyEntity.SemSyId, _student.StudentId);
                _updateRegForm.UpdateAction = false;
                _updateRegForm.RegistrationEntity = _registrationEntity;
                _updateRegForm.StudentEntity = _student;
                _updateRegForm.UserEntity = UserEntity;
                _updateRegForm.SemSyEntity = SemSyEntity;
                _updateRegForm.Branch = Branch;
                _updateRegForm.UpdateAction = false;
                _updateRegForm.GetStudentRegistration();
                if ((_updateRegForm == null) || (_updateRegForm.IsDisposed))
                    _updateRegForm.ShowDialog();        
            }
            Close();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            GetStudents();
        }

        private void waterMarkTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    buttonGo.PerformClick();
                    break;
                default: break;
            }
        }

        private void studentEntityBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (studentEntityBindingSource.Current != null)
            {
                _student = (RegistrationEntity)studentEntityBindingSource.Current;
                //toolStripStatusLabel1.Text = string.Format(@"{0} - {1}, [ {2} ]", _student.IdNo, _student.FullName,
                //                                           _student.YearCourseSection);
                if ((_student.StudentId > 0) && (SemSyEntity.SemSyId > 0))
                {
                    if (ObjectQueries.CheckIfEnrolledSemSyStudent(SemSyEntity.SemSyId, _student.StudentId) != null)
                    {

                        buttonNew.Enabled = false;
                        buttonUpdate.Enabled = true;
                        toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                    else
                    {
                        buttonNew.Enabled = true;
                        buttonUpdate.Enabled = false;
                        toolStripStatusLabel1.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //if (studentBindingSource.Current != null)
            //{
            //    _student = (StudentEntity)studentBindingSource.Current;
            //    toolStripStatusLabel1.Text = string.Format(@"{0} - {1}", _student.IdNo, _student.FullName);
            //    if ((_student.StudentId > 0) && (SemSyEntity.SemSyId > 0))
            //    {
            //        if (ObjectQueries.CheckIfEnrolledSemSyStudent(SemSyEntity.SemSyId, _student.StudentId) > 0)
            //        {
            //            buttonNew.Enabled = false;
            //            buttonUpdate.Enabled = true;
            //        }
            //        else
            //        {
            //            buttonNew.Enabled = true;
            //            buttonUpdate.Enabled = false;
            //        }
            //    }
            //}
        }

        private void studentBindingSource_PositionChanged(object sender, EventArgs e)
        {
            //if (studentBindingSource.Current != null)
            //{
            //    _student = (StudentEntity)studentBindingSource.Current;
            //    //toolStripStatusLabel1.Text = string.Format(@"{0} - {1}, [ {2} ]", _student.IdNo, _student.FullName,
            //    //                                           _student.YearCourseSection);
            //    if ((_student.StudentId > 0) && (SemSyEntity.SemSyId > 0))
            //    {
            //        if (ObjectQueries.CheckIfEnrolledSemSyStudent(SemSyEntity.SemSyId, _student.StudentId) != null)
            //        {

            //            buttonNew.Enabled = false;
            //            buttonUpdate.Enabled = true;
            //            toolStripStatusLabel1.ForeColor = Color.Red;
            //        }
            //        else
            //        {
            //            buttonNew.Enabled = true;
            //            buttonUpdate.Enabled = false;
            //            toolStripStatusLabel1.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }
    }
}
