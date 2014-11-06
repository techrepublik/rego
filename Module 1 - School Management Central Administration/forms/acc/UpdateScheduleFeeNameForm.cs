using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateScheduleFeeNameForm : Form
    {
        public ScheduleFeeName ScheduleFeeName { get; set; }

        public UpdateScheduleFeeNameForm()
        {
            InitializeComponent();
        }

        private void scheduleFeeNameBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (scheduleFeeNameBindingSource.Current != null)
            {
                scheduleFeeNameBindingNavigatorSaveItem.Enabled = true;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            scheduleFeeNameBindingSource.AddNew();
            scheduleNameTextBox.Focus();
        }

        private void scheduleFeeNameBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            if (scheduleFeeNameBindingSource.Current != null)
            {
                var iResult = Save.ScheduleFeeNames((ScheduleFeeName) scheduleFeeNameBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (scheduleFeeNameBindingSource.Current != null)
            {
                if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    bool bResult =
                        Remove.ScheduleFeeNames(
                            ((ScheduleFeeName) scheduleFeeNameBindingSource.Current).ScheduleFeeNameId);
                    UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                        scheduleFeeNameBindingSource.RemoveCurrent();
                }
            }
        }

        private void UpdateScheduleFeeNameForm_Load(object sender, EventArgs e)
        {
            if (ScheduleFeeName != null)
                scheduleFeeNameBindingSource.DataSource = ScheduleFeeName;
        }
    }
}
