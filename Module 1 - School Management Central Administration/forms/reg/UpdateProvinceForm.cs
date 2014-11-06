using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class UpdateProvinceForm : Form
    {
        public Province Province { get; set; }

        public UpdateProvinceForm()
        {
            InitializeComponent();
        }

        private void provinceBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (provinceNameTextBox.Text.Length > 0)
            {
                Validate();    
                provinceBindingSource.EndEdit();
                var iResult = Save.Provinces((Province) provinceBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            }
            Cursor.Current = Cursors.Default;
        }

        private void UpdateProvinceForm_Load(object sender, EventArgs e)
        {
            if (Province != null)
                provinceBindingSource.DataSource = Province;
        }

        private void provinceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (provinceBindingSource.Current != null)
                provinceBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
