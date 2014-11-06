using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_3___Cashiering.forms
{
    public partial class CashierListForm : Form
    {
        public UserEntity UserEntity { get; set; }
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }


        public CashierListForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (var f = new CashierForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.UserEntity = UserEntity;
                f.Branch = Branch;
                f.SemSyEntity = SemSyEntity;
                f.ShowDialog();
            }
        }

        private void CashierListForm_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 0;
        }


    }
}
