using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class UpdateMunCityForm : Form
    {
        public MunCity MunCity { get; set; }

        public UpdateMunCityForm()
        {
            InitializeComponent();
        }

        private void UpdateMunCityForm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (MunCity != null)
                munCityBindingSource.DataSource = MunCity;
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            provinceBindingSource.DataSource = LoadQueries.GetProvinces();
            Cursor.Current = Cursors.Default;
        }

        private void munCityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (munCityBindingSource.Current != null)
            {
                munCityBindingNavigatorSaveItem.Enabled = true;
            }
        }

        private void munCityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (munCityBindingSource.Current != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Validate();
                munCityBindingSource.EndEdit();
                var iResult = Save.MinMunCitys((MunCity) munCityBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                Cursor.Current = Cursors.Default;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            provinceIdComboBox.Focus();
            if (MunCity != null)
                provinceIdComboBox.SelectedValue = MunCity.ProvinceId;
        }
    }
}
