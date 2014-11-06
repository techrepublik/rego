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
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f1 = new UserUpdateForm())
            {
                f1.FormBorderStyle = FormBorderStyle.FixedDialog;
                f1.MaximizeBox = false;
                f1.MinimizeBox = false;
                f1.StartPosition = FormStartPosition.CenterScreen;
                if (userBindingSource.Current != null)
                    f1.UserX = (User) userBindingSource.Current;
                f1.ShowDialog();
            }
        }

        private void LoadUsers()
        {
            Cursor.Current = Cursors.WaitCursor;
            userLevelBindingSource.DataSource = LoadQueries.GetUserLevels();
            userBindingSource.DataSource = LoadQueries.GetUsers();
            Cursor.Current = Cursors.Default;
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
