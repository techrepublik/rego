using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class ScholarshipListForm : Form
    {
        public ScholarshipListForm()
        {
            InitializeComponent();
        }

        private void ScholarshipListForm_Load(object sender, EventArgs e)
        {
            LoadRecords();
            toolStripButtonDelete.Enabled = false;
        }

        private void LoadRecords()
        {
            scholarshipBindingSource.DataSource = ObjectQueries.GetScholarships();
        }

        private void toolStripButtonScholarship_Click(object sender, EventArgs e)
        {
            using (var f = new UpdateScholarshipForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                if (scholarshipBindingSource.Current != null)
                    f.Scholarship = (Scholarship) scholarshipBindingSource.Current;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
                LoadRecords();
            }
        }

        private void toolStripButtonFees_Click(object sender, EventArgs e)
        {
            if (scholarshipBindingSource.Current != null)
            {
                using (var f = new UpdateScholarshipFeeForm())
                {
                    f.FormBorderStyle = FormBorderStyle.FixedSingle;
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Scholarship = (Scholarship)scholarshipBindingSource.Current;
                    f.MaximizeBox = false;
                    f.MinimizeBox = false;
                    f.ShowDialog();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scholarshipBindingSource.Current != null)
                scholarshipFeeEntityBindingSource.DataSource =
                    ObjectQueries.GetScholarshipFeeEntityScholarship(
                        ((Scholarship) scholarshipBindingSource.Current).ScholarshipId);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (scholarshipFeeEntityBindingSource.Current != null)
            {
                if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    bool bResult =
                        Remove.ScholarshipFee(
                            ((ScholarshipFeeEntity) scholarshipFeeEntityBindingSource.Current).ScholarshipFeeId);
                    UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                        scholarshipFeeEntityBindingSource.RemoveCurrent();
                }
            }
        }

        private void scholarshipFeeEntityDataGridView_Click(object sender, EventArgs e)
        {
            if (scholarshipFeeEntityDataGridView.Rows.Count > 0)
                toolStripButtonDelete.Enabled = true;
        }

        private void scholarshipFeeEntityDataGridView_Leave(object sender, EventArgs e)
        {
            if (scholarshipFeeEntityDataGridView.Rows.Count > 0)
                toolStripButtonDelete.Enabled = false;
        }
    }
}
