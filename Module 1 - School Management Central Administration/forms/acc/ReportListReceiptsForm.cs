using GenDataLayer;
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
using Module_1___School_Management_Central_Administration.forms.rpt;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class ReportListReceiptsForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }

        private bool _selection;
        public ReportListReceiptsForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            _selection = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            _selection = true;
        }

        private void ReportListReceiptsForm_Load(object sender, EventArgs e)
        {
            LoadAllPreferences();

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void LoadAllPreferences()
        {
            Cursor.Current = Cursors.WaitCursor;
            var tempListSemSy = ObjectQueries.GetSemSyEntities();
            var tempSemSy = new SemSyEntity
                {
                    Semester = @"--- Select Sem & S.Y. ---"
                };
            tempListSemSy.Insert(0,tempSemSy);
            semSyEntityBindingSource.DataSource = tempListSemSy;

            var tempListSemSy1 = ObjectQueries.GetSemSyEntities();
            var tempSemSy1 = new SemSyEntity
            {
                Semester = @"--- Select Sem & S.Y. ---"
            };
            tempListSemSy1.Insert(0, tempSemSy);
            semSyEntityBindingSource1.DataSource = tempListSemSy1;

            var tempListUsers = LoadQueries.GetUsers();
            var tempUser = new User
                {
                    UserFullName = @"--- Select User ---"
                };
            tempListUsers.Insert(0, tempUser);
            userBindingSource.DataSource = tempListUsers;
            Cursor.Current = Cursors.Default;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var f = new RepostListReceiptsForm();
            f.WindowState = FormWindowState.Maximized;
            f.Branch = Branch;
            f.SemSyEntity = SemSyEntity;
            if (_selection)
            {
                //var tempSem = (SemSyEntity)semSyEntityBindingSource
                //f.PrintReceiptClasses = FinanceQueries.ListReceipts(SemSyEntity.SemSyId);
            }
            else
            {
                var tempSem = (SemSyEntity) semSyEntityBindingSource.Current;
                if ((tempSem != null) && (tempSem.SemSyId > 0))
                {
                    f.PrintReceiptClasses = FinanceQueries.ListReceiptsWithAmount(tempSem.SemSyId);
                }
            }
            f.Show();
            this.Close();
        }
    }
}
