using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class UpdateCourseForm : Form
    {
        public Cours _Cours { get; set; }

        public UpdateCourseForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            coursBindingNavigatorSaveItem.Enabled = true;
            coursBindingSource.AddNew();
            comboBoxDepartment.Focus();
        }

        private void LoadDepartments()
        {
            departmentBindingSource.DataSource = LoadQueries.GetDepartments();
        }

        private void UpdateCourseForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            GetCourse();
        }

        private void GetCourse()
        {
            if (_Cours != null)
                coursBindingSource.DataSource = _Cours;
        }

        private void coursBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            coursBindingSource.EndEdit();
            int i = Save.Cours((Cours) coursBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void coursBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            coursBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (coursBindingSource.Current != null)
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    var bResult = Remove.Course(((Cours) coursBindingSource.Current).CourseId);
                    UtilClass.ShowDeleteMessageBox(bResult);
                }
            }
        }
    }
}
