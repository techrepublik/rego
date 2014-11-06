using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class ProspectusSemYrForm : Form
    {
        public ProspectusSemYr _ProspectusSemYr { get; set; }

        public ProspectusSemYrForm()
        {
            InitializeComponent();
        }

        private void LoadProspectus()
        {
            Cursor.Current = Cursors.WaitCursor;
            prospectusBindingSource.DataSource = LoadQueries.GetProspectuses();
            Cursor.Current = Cursors.Default;
        }

        private void GetProspectusSemYr()
        {
            if (_ProspectusSemYr != null)
                prospectusSemYrBindingSource.DataSource = _ProspectusSemYr;
        }

        private void prospectusSemYrBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (prospectusSemYrBindingSource.Current != null)
                prospectusSemYrBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            prospectusSemYrBindingNavigatorSaveItem.Enabled = true;
            prospectusSemYrBindingSource.AddNew();
            comboBox1.Focus();
        }

        private void ProspectusSemYrForm_Load(object sender, EventArgs e)
        {
            LoadProspectus();
            GetProspectusSemYr();
        }

        private void prospectusSemYrBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            prospectusSemYrBindingSource.EndEdit();
            int iResult = Save.ProspectusSemYrs((ProspectusSemYr) prospectusSemYrBindingSource.Current);
            UtilClass.ShowSaveMessageBox(iResult);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
            if (dResult == DialogResult.Yes)
            {
                var prospectus = (ProspectusSemYr)prospectusSemYrBindingSource.Current;
                if (prospectus != null)
                {
                    if (Remove.ProspectusSemYrs(prospectus.ProspectusSemYrId))
                    {
                        prospectusSemYrBindingSource.RemoveCurrent();
                    }
                }

            }
            Cursor.Current = Cursors.Default;
        }
    }
}
