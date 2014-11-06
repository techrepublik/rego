using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class SubjectListForm : Form
    {
        public SubjectListForm()
        {
            InitializeComponent();
        }

        private void LoadSubjects()
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectBindingSource.DataSource = ObjectQueries.GetSubjectList();
            Cursor.Current = Cursors.Default;
        }

        private void SubjectListForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            
        }

        private void subjectDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (subjectDataGridView.Rows.Count > 0)
            {
                if (subjectBindingSource.Current != null)
                {
                    if (subjectDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        subjectBindingSource.EndEdit();
                        int iResult = Save.Subjects((Subject) subjectBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(iResult);
                    }
                }
            }
        }

        private void subjectBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (subjectBindingSource != null)
                subjectBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (subjectDataGridView.Rows.Count > 0)
            {
                if (subjectBindingSource.Current != null)
                {
                    if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                    {
                        var bResult = Remove.Subjects(((Subject) subjectBindingSource.Current).SubjectId);
                        UtilClass.ShowDeleteMessageBox(bResult);
                        subjectBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FindSubjects(toolStripTextBoxSearch.Text);
            Cursor.Current = Cursors.Default;
        }

        private void FindSubjects(string sValue)
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectBindingSource.DataSource = ObjectQueries.FindSubjectList(sValue);
            Cursor.Current = Cursors.Default;
        }

        private void toolStripTextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonGo.PerformClick();
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (toolStripTextBoxSearch.Text.Length > 0)
            {
                subjectBindingSource.DataSource = ObjectQueries.FindSubjectList(toolStripTextBoxSearch.Text);
            }
            else
            {
                subjectBindingSource.DataSource = ObjectQueries.GetSubjectList();
            }
            Cursor.Current = Cursors.Default;
            this.reportViewer1.RefreshReport();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage2)
            {
                toolStripButtonPrint.PerformClick();
            }
        }
    }
}
