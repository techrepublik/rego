using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateGrossAmountForm : Form
    {
        public UpdateGrossAmountForm()
        {
            InitializeComponent();
        }

        private void assessmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (assessmentBindingSource.Current != null)
                assessmentBindingNavigatorSaveItem.Enabled = true;
        }

        private void assessmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            UpdateAssessment();
        }

        private void UpdateGrossAmountForm_Load(object sender, EventArgs e)
        {
            assessmentBindingSource.DataSource = FinanceQueries.ListAssessmentNullGross();
        }

        private void UpdateAssessment()
        {
            Cursor.Current = Cursors.WaitCursor;
            Validate();
            assessmentBindingSource.EndEdit();
            var iCounter = 0;
            foreach (Assessment item in assessmentBindingSource.List)
            {
                var item1 = item;
                if ((item.NetAmount == 0) || (item.NetAmount == null))
                    item1.GrossAmount = Convert.ToDecimal(item.Less);
                else if (item.NetAmount > 0)
                    item1.GrossAmount = item.NetAmount;
                
                if (Save.Assessment(item1) > 0)
                {
                    iCounter += 1;
                }
            }
            
            UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
            Cursor.Current = Cursors.Default;
        }
    }
}
