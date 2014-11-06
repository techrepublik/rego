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

namespace Module_1___School_Management_Central_Administration.forms.adm
{
    public partial class UserUpdateForm : Form
    {
        public User UserX { get;  set; }

        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void userBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (userBindingSource != null)
                userBindingNavigatorSaveItem.Enabled = true;
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (userBindingSource.Current != null)
            {
                Validate();
                userBindingSource.EndEdit();
                var iResult = Save.Users((User) userBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            }
        }

        private void GetUser()
        {
            if (UserX != null)
                userBindingSource.DataSource = UserX;
        }

        private void LoadUserLevels()
        {
            Cursor.Current = Cursors.WaitCursor;
            userLevelBindingSource.DataSource = LoadQueries.GetUserLevels();
            Cursor.Current = Cursors.Default;
        }

        private void UserUpdateForm_Load(object sender, EventArgs e)
        {
            LoadUserLevels();
            GetUser();
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length > 0)
            {
                if (textBoxPassword.Text.Length > 0)
                {
                    if (textBoxPassword.Text.Equals(passwordTextBox.Text))
                        errorProvider1.SetError(textBoxPassword,"");
                    else
                        errorProvider1.SetError(textBoxPassword,"Password not match.");
                }
                else
                {
                    errorProvider1.SetError(textBoxPassword, "Re-Password is left blank.");
                }
            }
        }

        private void userNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(userNameTextBox, userNameTextBox.Text.Length > 0 ? "" : "Username is left blank.");
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(passwordTextBox, passwordTextBox.Text.Length > 0 ? "" : "Password is left blank.");
        }

        private void userFullNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(userFullNameTextBox, userFullNameTextBox.Text.Length > 0 ? "" : "User Full Name is left blank.");
        }
    }
}
