using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class AddressListForm : Form
    {
        private int _iActive;

        public AddressListForm()
        {
            InitializeComponent();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    using (var f1 = new AddressUpdateWizardForm())
                    {
                        f1.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f1.StartPosition = FormStartPosition.CenterScreen;
                        f1.MaximizeBox = false;
                        f1.MinimizeBox = false;
                        f1.ShowDialog();
                    }
                    break;
                case Keys.F6:
                    ActivateFormProvince();
                    break;
                case Keys.F7:
                    ActivateFormMunCity();
                    break;
                case Keys.F8:
                    ActivateFormBarangay();
                    break;
                case Keys.F9:
                    ActivateFormStreetHouse();
                    break;
                default:
                    MessageBox.Show(@"Please select item from the treeview.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
            FillTreeview();
        }

        private void ActivateFormStreetHouse()
        {
            using (var f5 = new UpdateStreetForm())
            {
                f5.FormBorderStyle = FormBorderStyle.FixedSingle;
                f5.StartPosition = FormStartPosition.CenterScreen;
                if (treeView1.SelectedNode.Tag != null)
                    f5.StreetHous = (StreetHous) treeView1.SelectedNode.Tag;
                f5.MinimizeBox = false;
                f5.MaximizeBox = false;
                f5.ShowDialog();
            }
        }

        private void ActivateFormBarangay()
        {
            using (var f4 = new UpdateBarangayForm())
            {
                f4.FormBorderStyle = FormBorderStyle.FixedSingle;
                f4.StartPosition = FormStartPosition.CenterScreen;
                if (treeView1.SelectedNode.Tag != null)
                    f4.Barangay = (Barangay) treeView1.SelectedNode.Tag;
                f4.MinimizeBox = false;
                f4.MaximizeBox = false;
                f4.ShowDialog();
            }
        }

        private void ActivateFormMunCity()
        {
            using (var f3 = new UpdateMunCityForm())
            {
                f3.FormBorderStyle = FormBorderStyle.FixedSingle;
                f3.StartPosition = FormStartPosition.CenterScreen;
                if (treeView1.SelectedNode.Tag != null)
                    f3.MunCity = (MunCity) treeView1.SelectedNode.Tag;
                f3.MinimizeBox = false;
                f3.MaximizeBox = false;
                f3.ShowDialog();
            }
        }

        private void ActivateFormProvince()
        {
            using (var f2 = new UpdateProvinceForm())
            {
                f2.FormBorderStyle = FormBorderStyle.FixedSingle;
                f2.StartPosition = FormStartPosition.CenterScreen;
                if (treeView1.SelectedNode.Tag != null)
                    f2.Province = (Province) treeView1.SelectedNode.Tag;
                f2.MinimizeBox = false;
                f2.MaximizeBox = false;
                f2.ShowDialog();
            }
        }

        private void AddressListForm_Load(object sender, EventArgs e)
        {
            FillTreeview();
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lProvince = LoadQueries.GetProvinces();
            var lMunCity = LoadQueries.GetMunCities();
            var lBarangay = LoadQueries.GetBarangays();
            var lStreet = LoadQueries.GetStreetHouses();

            foreach (var province in lProvince)
            {
                var nodeParent = new TreeNode(province.ProvinceName) {Name = "Province", Tag = province};

                foreach (var munCity in lMunCity)
                {
                    if (province.ProvinceId == munCity.ProvinceId)
                    {
                        var nodeChild01 = new TreeNode(munCity.MunCityName) {Name = "MunCity", Tag = munCity};

                        nodeParent.Nodes.Add(nodeChild01);

                        foreach (var barangay in lBarangay)
                        {
                            if (munCity.MunCityId == barangay.MunCityId)
                            {
                                var nodeChild02 = new TreeNode(barangay.BarangayName)
                                    {
                                        Name = "Barangay",
                                        Tag = barangay
                                    };

                                nodeChild01.Nodes.Add(nodeChild02);

                                foreach (var street in lStreet)
                                {
                                    if (street.BarangayId == barangay.BarangayId)
                                    {
                                        var nodeChild03 = new TreeNode(street.StreetName)
                                            {
                                                Name = "Street",
                                                Tag = street
                                            };

                                        nodeChild02.Nodes.Add(nodeChild03);
                                    }
                                }
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.Node.Name)
            {
                case "Province":
                    jTabWizard1.SelectTab(tabPage1);
                    munCityEntityBindingSource.DataSource = ObjectQueries.GetMunCityProvince((Province)e.Node.Tag);
                    label2.Text = String.Format(@"{0}", e.Node.Text);
                    _iActive = 0;
                    break;
                case "MunCity":
                    jTabWizard1.SelectTab(tabPage2);
                    barangayEntityBindingSource.DataSource = ObjectQueries.GetBarangayMunCity((MunCity) e.Node.Tag);
                    label2.Text = String.Format(@"{0} -> {1}", e.Node.Parent.Text,
                                                e.Node.Text);
                    _iActive = 1;
                    break;
                case "Barangay":
                    jTabWizard1.SelectTab(tabPage3);
                    streetEntityBindingSource.DataSource = ObjectQueries.GetStreetBarangay((Barangay) e.Node.Tag);
                    label2.Text = String.Format(@"{0} -> {1} -> {2}", e.Node.Parent.Parent.Text, e.Node.Parent.Text,
                                                e.Node.Text);
                    _iActive = 2;
                    break;
                case "Street":
                    _iActive = 3;
                    break;
                default:
                    label2.Text = @"...";
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (_iActive)
            {
                case 0:
                    ActivateFormProvince();
                    break;
                case 1:
                    ActivateFormMunCity();
                    break;
                case 2:
                    ActivateFormBarangay();
                    break;
                case 3:
                    ActivateFormStreetHouse();
                    break;
                default:
                    MessageBox.Show(@"Please select item from the treeview.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
            FillTreeview();
        }

        private void toolStripButtonAddWizard_Click(object sender, EventArgs e)
        {
            using (var f = new AddressUpdateWizardForm())
            {
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ShowDialog();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show(@"You are about to delete a record, continue?", @"Delete",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dResult == DialogResult.Yes)
            {
                switch (_iActive)
                {
                    case 0:
                        var bResult1 = Remove.Provinces(((Province) treeView1.SelectedNode.Tag).ProvinceId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult1);
                        treeView1.SelectedNode.Remove();
                        break;
                    case 1:
                        var bResult2 = Remove.MunCitys(((MunCity) treeView1.SelectedNode.Tag).MunCityId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult2);
                        treeView1.SelectedNode.Remove();
                        break;
                    case 2:
                        var bResult3 = Remove.Barangays(((Barangay) treeView1.SelectedNode.Tag).BarangayId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult3);
                        treeView1.SelectedNode.Remove();
                        break;
                    case 3:
                        var bResult4 = Remove.StreetHouss(((StreetHous) treeView1.SelectedNode.Tag).StreetHouseId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult4);
                        treeView1.SelectedNode.Remove();
                        break;
                    default:
                        MessageBox.Show(@"Please select item from the treeview.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        break;
                }
            }
        }
    }
}
