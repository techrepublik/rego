using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateFeeParticularForm : Form
    {
        public FeeParticular _FeeParticular { get; set; }

        public UpdateFeeParticularForm()
        {
            InitializeComponent();
        }

        private void UpdateFeeParticularForm_Load(object sender, EventArgs e)
        {
            LoadFeeSubTitles();
            GetFeeParticular();
        }

        private void GetFeeParticular()
        {
            if (_FeeParticular != null)
                feeParticularsBindingSource.DataSource = _FeeParticular;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            feeParticularsBindingNavigatorSaveItem.Enabled = true;
            feeParticularsBindingSource.AddNew();
            feeSubTitleNameComboBox.Focus();
        }

        private void feeParticularsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            feeParticularsBindingSource.EndEdit();
            int i = Save.FeeParticular((FeeParticular) feeParticularsBindingSource.Current);
            UtilClass.ShowSaveMessageBox(i);
        }

        private void LoadFeeSubTitles()
        {
            Cursor.Current = Cursors.WaitCursor;
            feeSubTitleBindingSource.DataSource = LoadQueries.GetFeeSubTitles();
            Cursor.Current = Cursors.Default;
        }

        private void feeParticularsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            feeParticularsBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            Validate();
            if (feeParticularsBindingSource.Current != null)
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    bool bResult =
                        Remove.FeeParticulars(((FeeParticular) feeParticularsBindingSource.Current).FeeParticularId);
                    UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                        feeParticularsBindingSource.RemoveCurrent();
                }
            }
        }
    }
}
