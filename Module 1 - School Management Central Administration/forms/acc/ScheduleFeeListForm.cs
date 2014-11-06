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

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class ScheduleFeeListForm : Form
    {
        public ScheduleFeeListForm()
        {
            InitializeComponent();
        }

        private void toolStripButtonName_Click(object sender, EventArgs e)
        {
            using (var f = new UpdateScheduleFeeNameForm() )
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                if (scheduleFeeNameBindingSource.Current != null)
                    f.ScheduleFeeName = (ScheduleFeeName)scheduleFeeNameBindingSource.Current;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
                LoadScheduleFeeName();
            }
        }

        private void ScheduleFeeListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadScheduleFeeName();
            LoadFeeParticulars();

            toolStripButtonDelete.Enabled = false;
            Cursor.Current = Cursors.Default;
            
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
            tabControl1.SelectedTab = tabPage1;
            if (scheduleFeeNameBindingSource.Current != null)
                LoadScheduleFees();

            toolStripButtonDelete.Enabled = false;
        }

        private void scheduleFeeDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (scheduleFeeBindingSource.Current != null)
            {
                if (scheduleFeeDataGridView.IsCurrentRowDirty)
                {
                    Validate();
                    if (scheduleFeeNameBindingSource.Current != null)
                    {
                        ((ScheduleFee) scheduleFeeBindingSource.Current).ScheduleFeeNameId =
                            ((ScheduleFeeName) scheduleFeeNameBindingSource.Current).ScheduleFeeNameId;
                        scheduleFeeBindingSource.EndEdit();
                        var iResult = Save.ScheduleFees((ScheduleFee) scheduleFeeBindingSource.Current);
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                    }
                }
            }
        }

        private void scheduleFeeDataGridView_Click(object sender, EventArgs e)
        {
            if (scheduleFeeDataGridView.Rows.Count > 0)
                toolStripButtonDelete.Enabled = true;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (scheduleFeeDataGridView.Rows.Count > 0)
            {
                if (scheduleFeeBindingSource.Current != null)
                {
                    if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                    {
                        Validate();
                        bool bResult =
                            Remove.ScheduleFees(((ScheduleFee) scheduleFeeBindingSource.Current).ScheduleFeeId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                        if (bResult)
                            scheduleFeeBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            if (scheduleFeeNameBindingSource.Current != null)
            {
                tabControl1.SelectedTab = tabPage2;
                PrintScheduleFeeClassBindingSource.DataSource =
                    ObjectQueries.GetPrintScheduleFees(
                        ((ScheduleFeeName) scheduleFeeNameBindingSource.Current).ScheduleFeeNameId);
                this.reportViewer1.RefreshReport();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage2)
                toolStripButtonPrint.PerformClick();
        }
    }
}
