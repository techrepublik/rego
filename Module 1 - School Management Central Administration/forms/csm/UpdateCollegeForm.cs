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
    public partial class UpdateCollegeForm : Form
    {
        public College _College { get; set; }

        public UpdateCollegeForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            collegeBindingNavigatorSaveItem.Enabled = true;
            collegeBindingSource.AddNew();
            collegeNameTextBox.Focus();
        }

        private void GetCollege()
        {
            if (_College != null)
                collegeBindingSource.DataSource = _College;
        }

        private void collegeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            collegeBindingNavigatorSaveItem.Enabled = true;
        }

        private void collegeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            collegeBindingSource.EndEdit();
            int i = Save.College((College) collegeBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void UpdateCollegeForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetCollege();
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (collegeBindingSource.Current != null)
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    var bResult = Remove.Colleges(((College) collegeBindingSource.Current).CollegeId);
                    UtilClass.ShowDeleteMessageBox(bResult);
                }
            }
        }
    }
}
