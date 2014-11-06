using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class UpdateBarangayForm : Form
    {
        public Barangay Barangay { get; set; }

        public UpdateBarangayForm()
        {
            InitializeComponent();
        }

        private void UpdateBarangayForm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (Barangay != null)
                barangayBindingSource.DataSource = Barangay;
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            munCityBindingSource.DataSource = LoadQueries.GetMunCities();
            Cursor.Current = Cursors.Default;
        }

        private void barangayBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (barangayBindingSource.Current != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Validate();
                barangayBindingSource.EndEdit();
                var iResult = Save.Barangays((Barangay) barangayBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                Cursor.Current = Cursors.Default;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            munCityIdComboBox.Focus();
            if (Barangay != null)
                munCityIdComboBox.SelectedValue = Barangay.MunCityId;
        }

        private void barangayBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (barangayBindingSource.Current != null)
                barangayBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
