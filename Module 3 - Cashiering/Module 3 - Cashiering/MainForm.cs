using System;
using System.Windows.Forms;
using Module_3___Cashiering.forms;
using GenDataLayer.repo.entities;
using GenDataLayer;

namespace Module_3___Cashiering
{
    public partial class Module3Form : Form
    {
        public UserEntity UserEntity { get; set; }
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }

        public Module3Form()
        {
            InitializeComponent();
        }

        private void cashieringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CashierListForm
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized,
                    UserEntity = UserEntity,
                    Branch = Branch,
                    SemSyEntity = SemSyEntity
                };
            form.Show();
        }

        private void Module3Form_Load(object sender, EventArgs e)
        {

        }

        private void Module3Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing &&
                        MessageBox.Show(@"You're terminate the application. Continue...?",
                                        Text + @" Close Application",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2) != DialogResult.Yes);

            if (e.Cancel != true)
            {
                Application.Exit();
            }
        }
    }
}
