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
    public partial class FeeSubTitleForm : Form
    {
        public FeeSubTitle _FeeSubTitle { get; set; }

        public FeeSubTitleForm()
        {
            InitializeComponent();
        }

        private void FeeSubTitleForm_Load(object sender, EventArgs e)
        {
            LoadFeeTitle();
            GetFeeSubTitle();
        }

        private void LoadFeeTitle()
        {
            Cursor.Current = Cursors.WaitCursor;
            feeTitleBindingSource.DataSource = LoadQueries.GetFeeTitles();
            Cursor.Current = Cursors.Default;
        }

        private void GetFeeSubTitle()
        {
            if (_FeeSubTitle != null)
                feeSubTitleBindingSource.DataSource = _FeeSubTitle;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            feeSubTitleBindingNavigatorSaveItem.Enabled = true;
            feeSubTitleBindingSource.AddNew();
            feeTitleIdComboBox.Focus();
        }

        private void feeSubTitleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            feeSubTitleBindingSource.EndEdit();
            int i = Save.FeeSubTitle((FeeSubTitle) feeSubTitleBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void feeSubTitleBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            feeSubTitleBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
