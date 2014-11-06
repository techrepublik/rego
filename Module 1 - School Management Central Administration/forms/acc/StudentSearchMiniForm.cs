using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class StudentSearchMiniForm : Form
    {
        public string SearchString { get; set; }

        private StudentLedgerForm ledgerForm = null;
        public StudentSearchMiniForm(StudentLedgerForm form)
        {
            ledgerForm = form;
            InitializeComponent();
        }

        private void StudentSearchMiniForm_Load(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        public void ExecuteSearch()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!string.IsNullOrEmpty(SearchString) && (SearchString.Length > 0))
                studentEntityBindingSource.DataSource = LoadQueries.GetStudentSearchEntity(SearchString);
            labelCount.Text = studentEntityBindingSource.Count > 0 ? String.Format(@"{0} record(s) found.", studentEntityBindingSource.Count) : @"...";
            Cursor.Current = Cursors.Default;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (studentEntityBindingSource.Current != null)
            {
                ledgerForm.StudentX = (StudentEntity) studentEntityBindingSource.Current;
            }
        }

        private void studentEntityDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void studentEntityDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }
    }
}
