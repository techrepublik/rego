using System.Globalization;
using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class AddressUpdateWizardForm : Form
    {
        private Province _province;
        private MunCity _munCity;
        private Barangay _barangay;
        private StreetHous _streetHous;

        private List<Province> _listProvince;
        private List<MunCity> _listMunCity;
        private List<Barangay> _listBarangay;
        private List<StreetHous> _listStreetHouse;

        private int _selectedIndexProvince;
        private int _selectedIndexCity;
        private int _selectedIndexBarangay;
        private int _selectedStreet;

        private bool _isAction = false;
        private bool _isProvince, _isMunCity, _isBarangay, _isStreet;

        public AddressUpdateWizardForm()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (jTabWizard1.SelectedTab == tabPageProvince)
            {
                jTabWizard1.SelectedTab = tabPageCity;
                labelCity.ForeColor = Color.Green;
                labelProvince.ForeColor = Color.Black;
                labelBarangay.ForeColor = Color.Black;
                labelStreet.ForeColor = Color.Black;
                button2.Enabled = true;
            }
            else if (jTabWizard1.SelectedTab == tabPageCity)
            {
                jTabWizard1.SelectedTab = tabPageBarangay;
                labelBarangay.ForeColor = Color.Green;
                labelCity.ForeColor = Color.Black;
                labelProvince.ForeColor = Color.Black;
                labelStreet.ForeColor = Color.Black;
                button2.Enabled = true;
            }
            else if (jTabWizard1.SelectedTab == tabPageBarangay)
            {
                jTabWizard1.SelectedTab = tabPageStreet;
                labelStreet.ForeColor = Color.Green;
                labelProvince.ForeColor = Color.Black;
                labelCity.ForeColor = Color.Black;
                labelBarangay.ForeColor = Color.Black;
                buttonNext.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (jTabWizard1.SelectedTab == tabPageStreet)
            {
                jTabWizard1.SelectedTab = tabPageBarangay;
                labelBarangay.ForeColor = Color.Blue;
                labelProvince.ForeColor = Color.Black;
                labelCity.ForeColor = Color.Black;
                labelStreet.ForeColor = Color.Black;
                buttonNext.Enabled = true;
            }
            else if (jTabWizard1.SelectedTab == tabPageBarangay)
            {
                jTabWizard1.SelectedTab = tabPageCity;
                labelCity .ForeColor = Color.Blue;
                labelProvince.ForeColor = Color.Black;
                labelBarangay.ForeColor = Color.Black;
                labelStreet.ForeColor = Color.Black;
                buttonNext.Enabled = true;
            }
            else if (jTabWizard1.SelectedTab == tabPageCity)
            {
                jTabWizard1.SelectedTab = tabPageProvince;
                labelProvince.ForeColor = Color.Blue;
                labelCity.ForeColor = Color.Black;
                labelBarangay.ForeColor = Color.Black;
                labelStreet.ForeColor = Color.Black;
                button2.Enabled = false;
                buttonNext.Enabled = true;
            }
        }

        private void AddressUpdateWizardForm_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            labelProvince.ForeColor = Color.Green;
            LoadData();
        }

        private void tabPageCity_Click(object sender, EventArgs e)
        {

        }

        private bool CheckData(bool action)
        {
            
            var isValid = false;
            var tempProvinceId = 0;
            var tempMunCityId = 0;
            var tempBarangayId = 0;
            var tempStreetId = 0;

            if (comboBoxProvince.SelectedIndex > -1)
            {
                tempProvinceId = _listProvince[comboBoxProvince.SelectedIndex].ProvinceId;
            }
            else
            {
                tempProvinceId = 0;
            }

            if ((comboBoxCity.Items.Count > 0) && (comboBoxCity.SelectedIndex > -1))
            {
                tempMunCityId = _listMunCity[comboBoxCity.SelectedIndex].MunCityId;
            }
            else
            {
                tempMunCityId = 0;
            }

            if ((comboBoxBarangay.Items.Count > 0) && (comboBoxBarangay.SelectedIndex > -1))
            {
                tempBarangayId = _listBarangay[comboBoxBarangay.SelectedIndex].BarangayId;
            }
            else
            {
                tempBarangayId = 0;
            }

            if ((comboBoxStreet.Items.Count > 0) && (comboBoxStreet.SelectedIndex > -1))
            {
                tempStreetId = _listStreetHouse[comboBoxStreet.SelectedIndex].StreetHouseId;
            }
            else
            {
                tempStreetId = 0;
            }

            try
            {
                if (action == true)
                {
                    if (comboBoxProvince.Text.Length > 0)
                    {
                        _province = new Province { ProvinceName = comboBoxProvince.Text, ProvinceId = tempProvinceId };
                        _isProvince = true;
                    }
                    else
                    {
                        _isProvince = false;
                    }

                    if (comboBoxCity.Text.Length > 0)
                    {
                        _munCity = new MunCity { MunCityName = comboBoxCity.Text, MunCityId = tempMunCityId, ProvinceId = tempProvinceId };
                        _isMunCity = true;
                    }
                    else
                    {
                        _isMunCity = false;
                    }

                    if (comboBoxBarangay.Text.Length > 0)
                    {
                        _barangay = new Barangay
                        {
                            BarangayName = comboBoxBarangay.Text,
                            BarangayId = tempBarangayId,
                            MunCityId = tempMunCityId
                        };
                        _isBarangay = true;
                    }
                    else
                    {
                        _isBarangay = false;
                    }

                    if (comboBoxStreet.Text.Length > 0)
                    {
                        _streetHous = new StreetHous
                        {
                            StreetName = comboBoxStreet.Text,
                            StreetHouseId = tempStreetId,
                            BarangayId = tempBarangayId
                        };
                        _isStreet = true;
                    }
                    else
                    {
                        _isStreet = false;
                    }
                }
                else
                {
                    if (comboBoxProvince.Text.Length > 0)
                    {
                        _province = new Province
                        {
                            ProvinceName = comboBoxProvince.Text,
                            ProvinceId = _listProvince[_selectedIndexProvince].ProvinceId
                        };
                        _isProvince = true;
                    }
                    else
                    {
                        _isProvince = false;
                    }

                    if (comboBoxCity.Text.Length > 0)
                    {
                        _munCity = new MunCity
                        {
                            MunCityName = comboBoxCity.Text,
                            MunCityId = _listMunCity[_selectedIndexCity].MunCityId,
                            ProvinceId = tempProvinceId
                        };
                        _isMunCity = true;
                    }
                    else
                    {
                        _isMunCity = false;
                    }

                    if (comboBoxBarangay.Text.Length > 0)
                    {
                        _barangay = new Barangay
                        {
                            BarangayName = comboBoxBarangay.Text,
                            BarangayId = _listBarangay[_selectedIndexBarangay].BarangayId,
                            MunCityId = tempMunCityId
                        };
                        _isBarangay = true;
                    }
                    else
                    {
                        _isBarangay = false;
                    }

                    if (comboBoxStreet.Text.Length > 0)
                    {
                        _streetHous = new StreetHous
                        {
                            StreetName = comboBoxStreet.Text,
                            StreetHouseId = _listStreetHouse[_selectedStreet].StreetHouseId,
                            BarangayId = tempBarangayId
                        };
                        _isStreet = true;
                    }
                    else
                    {
                        _isStreet = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString(CultureInfo.InvariantCulture));
                MessageBox.Show(@"Please verify your entries and try again.", @"Save.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

            if ((_isProvince) && (_isMunCity) && (_isBarangay) && (_isStreet))
            {
                errorProvider1.Clear();
                isValid = true;
            }

            return isValid;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _isAction = true;
            _province = null;
            _munCity = null;
            _barangay = null;
            _streetHous = null;

            comboBoxProvince.SelectedIndex = -1;
            comboBoxCity.SelectedIndex = -1;
            comboBoxBarangay.SelectedIndex = -1;
            comboBoxStreet.SelectedIndex = -1;

            jTabWizard1.SelectTab(tabPageProvince);
            comboBoxProvince.Focus();
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            GetProvince();
            Cursor.Current = Cursors.Default;
        }

        private void GetProvince()
        {
            _listProvince = LoadQueries.GetProvinces();
            comboBoxProvince.DataSource = _listProvince;
            comboBoxProvince.DisplayMember = "ProvinceName";
            comboBoxProvince.ValueMember = "ProvinceId";
        }

        private void GetMunCity(Province province)
        {
            _listMunCity = LoadQueries.GetMunCitiesByProvince(province);
            comboBoxCity.DataSource = _listMunCity;
            comboBoxCity.DisplayMember = "MunCityName";
            comboBoxCity.ValueMember = "MunCityId";
        }

        private void GetBarangay(MunCity munCity)
        {
            _listBarangay = LoadQueries.GetBarangaysByCity(munCity);
            comboBoxBarangay.DataSource = _listBarangay;
            comboBoxBarangay.DisplayMember = "BarangayName";
            comboBoxBarangay.ValueMember = "BarangayId";
        }

        private void GetStreetHouse(Barangay barangay)
        {
            _listStreetHouse = LoadQueries.GetStreetHousesByBarangay(barangay);
            comboBoxStreet.DataSource = _listStreetHouse;
            comboBoxStreet.DisplayMember = "StreetName";
            comboBoxStreet.ValueMember = "StreetHouseId";
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (CheckData(_isAction))
            {
                try
                {
                    var iProvince = Save.Provinces(_province);
                    if (iProvince > 0)
                    {
                        _munCity.ProvinceId = iProvince;
                        var iCity = Save.MinMunCitys(_munCity);
                        if (iCity > 0)
                        {
                            _barangay.MunCityId = iCity;
                            var iBarangay = Save.Barangays(_barangay);
                            if (iBarangay > 0)
                            {
                                _streetHous.BarangayId = iBarangay;
                                var iStreetHouse = Save.StreetHouss(_streetHous);
                                if (iStreetHouse > 0)
                                {
                                    var dResult =
                                        MessageBox.Show(
                                            @"Address was successfully saved. Click YES to add Another or NO to end.",
                                            @"Save/Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dResult == DialogResult.Yes)
                                    {
                                        buttonNew.PerformClick();
                                    }
                                    else
                                    {
                                        Close();
                                    }
                                }
                                else
                                {
                                    UtilityManager.util.UtilClass.ShowSaveMessageBox(iStreetHouse);
                                }
                            }
                            else
                            {
                                UtilityManager.util.UtilClass.ShowSaveMessageBox(iBarangay);
                            }
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iCity);
                        }
                    }
                    else
                    {
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iProvince);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message.ToString(CultureInfo.InvariantCulture));
                }
            }
            else
            {
                if (_isProvince == false)
                {
                    jTabWizard1.SelectTab(tabPageProvince);
                    comboBoxProvince.Focus();
                    errorProvider1.SetError(comboBoxProvince, @"Province should not be emplty.");

                    labelBarangay.ForeColor = Color.Black;
                    labelCity.ForeColor = Color.Black;
                    labelProvince.ForeColor = Color.Red;
                    labelStreet.ForeColor = Color.Black;
                    button2.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(comboBoxProvince, @"");
                }
                if (_isMunCity == false)
                {
                    jTabWizard1.SelectTab(tabPageCity);
                    comboBoxCity.Focus();
                    errorProvider1.SetError(comboBoxCity, @"City should not be empty.");

                    labelBarangay.ForeColor = Color.Black;
                    labelCity.ForeColor = Color.Red;
                    labelProvince.ForeColor = Color.Black;
                    labelStreet.ForeColor = Color.Black;
                    button2.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(comboBoxCity, @"");
                }
                if (_isBarangay == false)
                {
                    jTabWizard1.SelectTab(tabPageBarangay);
                    comboBoxBarangay.Focus();
                    errorProvider1.SetError(comboBoxBarangay, @"Barangay should not be empty.");

                    labelBarangay.ForeColor = Color.Red;
                    labelCity.ForeColor = Color.Black;
                    labelProvince.ForeColor = Color.Black;
                    labelStreet.ForeColor = Color.Black;
                    button2.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(comboBoxBarangay, @"");
                }
                if (_isStreet == false)
                {
                    jTabWizard1.SelectTab(tabPageStreet);
                    comboBoxStreet.Focus();
                    errorProvider1.SetError(comboBoxStreet, @"Street should not be empty.");

                    labelBarangay.ForeColor = Color.Black;
                    labelCity.ForeColor = Color.Black;
                    labelProvince.ForeColor = Color.Black;
                    labelStreet.ForeColor = Color.Red;
                    button2.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(comboBoxStreet, @"");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxProvince.SelectedIndex > -1)
            {
                _selectedIndexProvince = comboBoxProvince.SelectedIndex;
                GetMunCity(_listProvince[_selectedIndexProvince]);
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxCity.SelectedIndex > -1)
            {
                _selectedIndexCity = comboBoxCity.SelectedIndex;
                GetBarangay(_listMunCity[_selectedIndexCity]);
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBoxBarangay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxBarangay.SelectedIndex > -1)
            {
                _selectedIndexBarangay = comboBoxBarangay.SelectedIndex;
                GetStreetHouse(_listBarangay[_selectedIndexBarangay]);
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBoxStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStreet.SelectedIndex > -1)
            {
                _selectedStreet = comboBoxStreet.SelectedIndex;
            }
        }
    }
}
