using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using StudentRegistration.Forms;

namespace StudentRegistration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        int x = 0;

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Extra Design
            studentInformationPanel.Visible = true;
            #endregion


        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "New Registration":
                    using (var f = new RegistrationForm())
                    {
                        f.ShowDialog();
                    }
                    break;
                case "x":
                    using (var f = new RegistrationForm())
                    {
                        f.ShowDialog();
                    }
                    break;
                case "y":
                    break;
            }
        }

      
    }
}
