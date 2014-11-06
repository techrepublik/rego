using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateSetFeeForm : Form
    {
        public SetPresetFee SetPresetFee { get; set; }

        public UpdateSetFeeForm()
        {
            InitializeComponent();
        }

        private void LoadPreRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            coursBindingSource.DataSource = LoadQueries.GetCourses();
            yearLevelBindingSource.DataSource = LoadQueries.GetYearLevels();
            Cursor.Current = Cursors.Default;
        }

        private void UpdateSetFeeForm_Load(object sender, EventArgs e)
        {
            LoadPreRecords();
            if (SetPresetFee != null)
                setPresetFeeBindingSource.DataSource = SetPresetFee;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            setPresetFeeBindingSource.AddNew();
            semSyIdComboBox.Focus();
        }

        private void setPresetFeeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (setPresetFeeBindingSource.Current != null)
                setPresetFeeBindingNavigatorSaveItem.Enabled = true;
        }

        private void setPresetFeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            setPresetFeeBindingSource.EndEdit();
            var iResult = Save.SetPresetFees((GenDataLayer.SetPresetFee) setPresetFeeBindingSource.Current);
            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (setPresetFeeBindingSource.Current != null)
            {
                if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    Validate();
                    bool bResult =
                        Remove.SetPresetFees(
                            ((GenDataLayer.SetPresetFee) setPresetFeeBindingSource.Current).SetPresetFeeId);
                    UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                        setPresetFeeBindingSource.RemoveCurrent();
                }
            }
        }
    }
}
