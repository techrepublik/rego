using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_2___School_Subject_Management.forms
{
    public partial class SubjectManagementMainForm : Form
    {
        public SubjectManagementMainForm()
        {
            InitializeComponent();
        }

        private void SubjectManagementMainForm_Load(object sender, EventArgs e)
        {

        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Open":
                    MessageBox.Show("Open");
                    break;
                default:
                    break;
            }
        }
    }
}
