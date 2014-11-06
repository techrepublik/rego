using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdatePresetFeeForm : Form
    {
        public int  SetPresetFeeId { get; set; }

        public UpdatePresetFeeForm()
        {
            InitializeComponent();
        }

        private void LoadScheduleFeeName()
        {
            scheduleFeeNameBindingSource.DataSource = ObjectQueries.GetScheduleFeeNames();
        }

        private void LoadScheduleFees()
        {
            if (scheduleFeeNameBindingSource.Current != null)
                scheduleFeeBindingSource.DataSource = ObjectQueries.GetScheduleFees(((ScheduleFeeName)scheduleFeeNameBindingSource.Current).ScheduleFeeNameId);
        }

        private void LoadFeeParticulars()
        {
            feeParticularBindingSource.DataSource = LoadQueries.GetFeeParticulars();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scheduleFeeNameBindingSource.Current != null)
            {
                LoadScheduleFees();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            GetCheckedRows();
            Close();
        }

        private void GetCheckedRows()
        {
            Validate();
            var i = 0;
            foreach (DataGridViewRow row in scheduleFeeDataGridView.Rows)
            {
                bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                if (bResult)
                {
                    var fee = (ScheduleFee) row.DataBoundItem;
                    var d = new PresetFee
                                {
                                    SetPresetFeeId = SetPresetFeeId,
                                    PresetFeeId = 0,
                                    DateAdded = DateTime.Now,
                                    ScheduleFeeId = fee.ScheduleFeeId
                                };
                    if (Save.PresetFees(d) > 0)
                        i += 1;
                }
            }
            UtilClass.ShowSaveMessageBox(i);
        }

        private void UpdatePresetFeeForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadScheduleFeeName();
            LoadFeeParticulars();
            Cursor.Current = Cursors.Default;
        }
    }
}
