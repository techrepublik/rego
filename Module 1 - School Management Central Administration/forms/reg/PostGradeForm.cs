using GenDataLayer;
using GenDataLayer.repo.managers.man;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class PostGradeForm : Form
    {
        public int TeacherSubjectId { get; set; }

        private readonly StudentGradeEntryForm _studentGradeEntryForm;
        public PostGradeForm(StudentGradeEntryForm form)
        {
            _studentGradeEntryForm = form;
            InitializeComponent();
        }

        private void PostGradeForm_Load(object sender, EventArgs e)
        {
            GetLastNo();
            GetAllPosModes(); //load post modes

            postGradeDateDateTimePicker.Value = DateTime.Now;
        }

        private void GetLastNo()
        {
            Cursor.Current = Cursors.WaitCursor;
            postGradeBindingSource.AddNew();
            ((PostGrade) postGradeBindingSource.Current).PostGradeNo = PostGradeManager.GetLastNo().ToString();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllPosModes()
        {
            Cursor.Current = Cursors.WaitCursor;
            postModeBindingSource.DataSource = PostModeManager.GetAll();
            Cursor.Current = Cursors.Default;
        }

        private PostGrade SavePostGrade()
        {
            Cursor.Current = Cursors.WaitCursor;
            var post = new PostGrade();
            if (postGradeBindingSource.Current != null)
            {
                Validate();
                var p = (PostGrade) postGradeBindingSource.Current;
                if (p != null)
                {
                    if (p.PostModeId > 0)
                    {
                        post = p;
                        post.TeacherSubjectId = TeacherSubjectId;
                        post.EditedBy = @"Admin";
                        post.PostGradeDate = p.PostGradeDate ?? DateTime.Today;
                    }
                    else
                    {
                        post = null;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return post;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //SavePostGrade(); //save post grade
            if (SavePostGrade() != null)
            {
                _studentGradeEntryForm.PostGrade = SavePostGrade();
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(@"Please select a post mode.", @"Post Mode", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                postModeIdComboBox.Focus();
            }
        }
    }
}
