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
    public partial class UpdateDepartmentForm : Form
    {
        public Department _Department { get; set; }

        public UpdateDepartmentForm()
        {
            InitializeComponent();
        }

        private void UpdateDepartmentForm_Load(object sender, EventArgs e)
        {
            LoadColleges();
            GetDepartment();
        }

        private void GetDepartment()
        {
            if (_Department != null)
                departmentBindingSource.DataSource = _Department;
        }

        private void LoadColleges()
        {
            Cursor.Current = Cursors.WaitCursor;
            collegeBindingSource.DataSource = LoadQueries.GetColleges();
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            departmentBindingNavigatorSaveItem.Enabled = true;
            departmentBindingSource.AddNew();
            collegeIdComboBox.Focus();
        }

        private void departmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            departmentBindingSource.EndEdit();
            int i = Save.Department((Department) departmentBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            departmentBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (departmentBindingSource.Current != null)
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    var bResult = Remove.Departments(((Department) departmentBindingSource.Current).DepartmentId);
                    UtilClass.ShowDeleteMessageBox(bResult);
                }
            }
        }
    }
}
