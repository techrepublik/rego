using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class UpdateStreetForm : Form
    {
        public StreetHous StreetHous { get; set; }

        public UpdateStreetForm()
        {
            InitializeComponent();
        }

        private void UpdateStreetForm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (StreetHous != null)
                streetHousBindingSource.DataSource = StreetHous;
            
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            barangayBindingSource.DataSource = LoadQueries.GetBarangays();
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            barangayIdComboBox.Focus();
            if (StreetHous != null)
                barangayIdComboBox.SelectedValue = StreetHous.BarangayId;
        }

        private void streetHousBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (streetHousBindingSource.Current != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Validate();
                streetHousBindingSource.EndEdit();
                var iResult = Save.StreetHouss((StreetHous) streetHousBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                Cursor.Current = Cursors.Default;
            }
        }

        private void streetHousBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (streetHousBindingSource.Current != null)
                streetHousBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
