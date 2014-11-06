using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class UpdateCollegeWizardForm : Form
    {
        public UpdateCollegeWizardForm()
        {
            InitializeComponent();
        }

        private void UpdateCollegeWizardForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                label1.Enabled = true;
                label2.Enabled = false;
                label2.Enabled = false;
            }

            buttonBack.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }
    }
}
