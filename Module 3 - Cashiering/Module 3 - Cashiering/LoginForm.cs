using System.Drawing;
using System.Threading;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;
using GenDataLayer.repo.statics;
using GenDataLayer.repo.entities;
using GenDataLayer;
using Module_3___Cashiering;

namespace Module_1___School_Management_Central_Administration
{
    public partial class LoginForm : Form
    {
        private UserEntity u = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((waterMarkTextBoxUserName.Text.Length > 0) && (waterMarkTextBoxPassword.Text.Length > 0))
            {
                u = ObjectQueries.GetUserByUserNamePassword(waterMarkTextBoxUserName.Text, waterMarkTextBoxPassword.Text);
                if (u != null)
                {
                    labelWarning.Text = String.Format(@"Welcome {0}. Loading preferences...", u.UserFullName);
                    Application.DoEvents();
                    Thread.Sleep(2000);
                    jTabWizard1.SelectedTab = tabPage2;
                    LoadPreferenceData();
                }
                else
                {
                    labelWarning.Text = @"Incorrect Username and Password.";
                }
            }
            else
            {
                labelWarning.Text = @"Username and Password should not be empty.";
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                this.Hide();
                var f = new Module3Form();
                if (u != null)
                    f.UserEntity = u;
                if (branchBindingSource.Current != null)
                    f.Branch = (Branch) branchBindingSource.Current;
                if (semSyEntityBindingSource.Current != null)
                    f.SemSyEntity = (SemSyEntity) semSyEntityBindingSource.Current;
                f.Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //CheckDatabaseConnection();
            waterMarkTextBoxUserName.Select();
            waterMarkTextBoxUserName.Focus();
        }

        private void LoadPreferenceData()
        {
            Cursor.Current = Cursors.WaitCursor;
            branchBindingSource.DataSource = ObjectQueries.GetBranches();
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            Cursor.Current = Cursors.Default;
        }

        private void waterMarkTextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonNext.PerformClick();
            }
        }

        private void CheckDatabaseConnection()
        {
            if (UtilityManager.util.UtilClass.CheckSQLServerConnection("MSSQL$SQLEXPRESS"))
            {
                tabPage1.Enabled = true;
                labelConnection.Text = @"Connected to server.";
                labelConnection.ForeColor = Color.Green;
                waterMarkTextBoxUserName.Focus();
            }
            else
            {
                tabPage1.Enabled = false;
                labelConnection.Text = @"Connection to server cannot be established.";
                labelConnection.ForeColor = Color.Red;
            }
        }

        private void labelConnection_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (UtilityManager.util.UtilClass.StartSQLServerConnection("MSSQL$SQLEXPRESS"))
            {
                tabPage1.Enabled = true;
                labelConnection.Text = @"Connected to server.";
                labelConnection.ForeColor = Color.Green;
                waterMarkTextBoxUserName.Focus();
            }
            else
            {
                tabPage1.Enabled = false;
                labelConnection.Text = @"Connection to server cannot be established.";
                labelConnection.ForeColor = Color.Red;
            }
            Cursor.Current = Cursors.Default;
        }

        private void jTabWizard1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                comboBox1.Focus();
            }
            else if (e.TabPageIndex == 0)
            {
                waterMarkTextBoxUserName.Select();
                waterMarkTextBoxUserName.Focus();
            }
        }

        private void waterMarkTextBoxUserName_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBoxUserName, true);
        }

        private void waterMarkTextBoxUserName_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBoxUserName, false);
        }

        private void waterMarkTextBoxPassword_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBoxPassword, true);
        }

        private void waterMarkTextBoxPassword_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBoxPassword, false);
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(comboBox1, true);
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(comboBox1, false);
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(comboBox2, true);
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(comboBox2, false);
        }
    }
}
