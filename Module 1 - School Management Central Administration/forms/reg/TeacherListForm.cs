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

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class TeacherListForm : Form
    {
        public TeacherListForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f = new UpdateTeacherForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                if (teacherEntityBindingSource.Current != null)
                    f.TeacherEntity = (TeacherEntity)teacherEntityBindingSource.Current;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ShowDialog();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteTeacher(); //delete teacher
        }

        private void DeleteTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (teacherEntityBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                var iId = Convert.ToInt32(((TeacherEntity)teacherEntityBindingSource.Current).TeacherId);
                if (iId > 0)
                {
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        teacherEntityBindingSource.EndEdit();
                        if (Remove.Teachers(iId))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            teacherEntityBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllTeachers()
        {
            Cursor.Current = Cursors.WaitCursor;
            teacherEntityBindingSource.DataSource = ObjectQueries.GetAllTeachers();
            Cursor.Current = Cursors.Default;
        }

        private void TeacherListForm_Load(object sender, EventArgs e)
        {
            GetAllTeachers(); // load all teachers
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            GetAllTeachers(); // load all teachers
        }
    }
}
