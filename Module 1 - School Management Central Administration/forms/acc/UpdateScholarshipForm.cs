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

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateScholarshipForm : Form
    {
        public Scholarship Scholarship { get; set; }

        public UpdateScholarshipForm()
        {
            InitializeComponent();
        }

        private void scholarshipBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (scholarshipBindingSource.Current != null)
                scholarshipBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            scholarshipBindingNavigatorSaveItem.Enabled = true;
            scholarshipBindingSource.AddNew();
            scholarshipNameTextBox.Focus();
        }

        private void scholarshipBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            scholarshipBindingSource.EndEdit();
            var iResult = Save.Scholarships((Scholarship) scholarshipBindingSource.Current);
            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (scholarshipBindingSource.Current != null)
            {
                if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    bool bResult = Remove.Scholarshp(((Scholarship) scholarshipBindingSource.Current).ScholarshipId);
                    UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                        scholarshipBindingSource.RemoveCurrent();
                }
            }
        }

        private void UpdateScholarshipForm_Load(object sender, EventArgs e)
        {
            if (Scholarship != null)
                scholarshipBindingSource.DataSource = Scholarship;
        }
    }
}

