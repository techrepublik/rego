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
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class UpdateDepartmentSubjectForm : Form
    {
        public Department _Department { get; set; }
        public UpdateDepartmentSubjectForm()
        {
            InitializeComponent();
        }

        public void LoadSubjects()
        {
            subjectBindingSource.DataSource = ObjectQueries.FindSubjectList(toolStripTextBoxSearch.Text);
        }

        private void UpdateDepartmentSubjectForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectBindingSource.DataSource = ObjectQueries.FindSubjectList(toolStripTextBoxSearch.Text);
            Cursor.Current = Cursors.Default;
        }

        private void toolStripTextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1.PerformClick();
            }
        }

        private void GetCheckedRows()
        {
            Validate();
            var i = 0;
            foreach (DataGridViewRow row in subjectDataGridView.Rows)
            {
                bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                if (bResult)
                {
                    var subject = (Subject) row.DataBoundItem;
                    var d = new DepartmentSubject
                    {
                        Department = _Department,
                        DepartmentSubjectId = 0,
                        DateAdded = DateTime.Now,
                        Note = @"None",
                        SubjectId = subject.SubjectId
                    };
                    if (Save.DepartmentSubjects(d) > 0)
                        i += 1;
                }
            }
            UtilClass.ShowSaveMessageBox(i);
        }

        private void subjectBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            GetCheckedRows();
        }
    }
}
