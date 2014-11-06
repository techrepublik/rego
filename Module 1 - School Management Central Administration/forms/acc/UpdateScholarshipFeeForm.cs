using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateScholarshipFeeForm : Form
    {
        public Scholarship Scholarship { get; set; }

        public UpdateScholarshipFeeForm()
        {
            InitializeComponent();
        }

        private void LoadScheduleFeeName()
        {
            scheduleFeeNameBindingSource.DataSource = ObjectQueries.GetScheduleFeeNames();
        }

        private void UpdateScholarshipFeeForm_Load(object sender, EventArgs e)
        {
            LoadScheduleFeeName();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scheduleFeeNameBindingSource.Current != null)
            {
                scholarshipFeeEntityBindingSource.DataSource =
                    ObjectQueries.GetScholarshipFeeEntityScheduleFee(
                        ((ScheduleFeeName) scheduleFeeNameBindingSource.Current).ScheduleFeeNameId);
            }
        }

        private void GetCheckedRows()
        {
            Validate();
            var i = 0;
            foreach (DataGridViewRow row in scholarshipFeeEntityDataGridView.Rows)
            {
                bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                if (bResult)
                {
                    var fee = (ScholarshipFeeEntity)row.DataBoundItem;
                    var s = new ScholarshipFee
                                {
                                    ScholarshipFeeId = 0,
                                    ScholarshipId = Scholarship.ScholarshipId,
                                    Percentage = fee.Percentage,
                                    ScheduleFeeId = fee.ScheduleFeeId
                                };
                    if (Save.ScholarshipFees(s) > 0)
                        i += 1;
                }
            }
            UtilClass.ShowSaveMessageBox(i);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            GetCheckedRows();
            Close();
        }
    }
}
