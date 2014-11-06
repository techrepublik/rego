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

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateFeeTitleForm : Form
    {
        public FeeTitle _FeeTitle { get; set; }

        public UpdateFeeTitleForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            feeTitleBindingNavigatorSaveItem.Enabled = false;
            feeTitleBindingSource.AddNew();
            feeTitleNameTextBox.Focus();
        }

        private void feeTitleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            feeTitleBindingSource.EndEdit();
            int i = Save.FeeTitle((FeeTitle) feeTitleBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void feeTitleBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            feeTitleBindingNavigatorSaveItem.Enabled = true;
        }

        private void UpdateFeeTitleForm_Load(object sender, EventArgs e)
        {
            GetFeeTitle();
        }

        private void GetFeeTitle()
        {
            if (_FeeTitle != null)
                feeTitleBindingSource.DataSource = _FeeTitle;
        }
    }
}
