using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
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
    public partial class UpdateTeacherForm : Form
    {
        public TeacherEntity TeacherEntity { get; set; }

        public UpdateTeacherForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            InitializeContorls();
        }

        private void InitializeContorls()
        {
            birthDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            birthDateDateTimePicker.CustomFormat = @" ";
        }

        private void GetAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            empStatusBindingSource.DataSource = LoadQueries.GetEmpStatuses();
            positionBindingSource.DataSource = LoadQueries.GetPositions();
            Cursor.Current = Cursors.Default;
        }

        private void SaveTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (teacherBindingSource.Current != null)
            {
                Validate();
                teacherBindingSource.EndEdit();
                if (Save.Teachers((Teacher) teacherBindingSource.Current) > 0)
                {
                    UtilityManager.util.UtilClass.ShowSaveMessageBox(1);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteTeacher(); //delete teacher
        }

        private void DeleteTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (teacherBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                var iId = Convert.ToInt32(((Teacher) teacherBindingSource.Current).TeacherId);
                if (iId > 0)
                {
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        teacherBindingSource.EndEdit();
                        if (Remove.Teachers(iId))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            teacherBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void teacherBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (teacherBindingSource.Current != null)
                teacherBindingNavigatorSaveItem.Enabled = true;
        }

        private void teacherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveTeacher(); //save teacher
        }

        private void birthDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            birthDateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void GetTeacher()
        {
            if (TeacherEntity != null)
            {
                teacherBindingSource.DataSource = TeacherEntity;
            }
        }

        private void UpdateTeacherForm_Load(object sender, EventArgs e)
        {
            GetAll(); //load all

            GetTeacher(); //get teacher profile
        }
    }
}
