using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateLabSubjectForm : Form
    {
        public int LabFeeId { get; set; }

        public UpdateLabSubjectForm()
        {
            InitializeComponent();
        }

        private void LoadSubjects()
        {
            Cursor.Current = Cursors.WaitCursor;
            subjectBindingSource.DataSource = ObjectQueries.FindSubjectList(toolStripTextBoxSearch.Text);
            Cursor.Current = Cursors.Default;
        }

        private void UpdateLabSubjectForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void subjectBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (VerifyCheck())
            {
                GetCheckedRows();
                Close();
            }
            else
                MessageBox.Show(@"Please select a subject.", @"Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private bool VerifyCheck()
        {
            var i = 0;
            bool bReturn = false;
            foreach (DataGridViewRow row in subjectDataGridView.Rows)
            {
                bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                if (bResult)
                {
                    i += 1;
                }
            }
            if (i > 0) bReturn = true;

            return bReturn;
        }

        private void GetCheckedRows()
        {
            Validate();
            if (LabFeeId > 0)
            {
                var i = 0;
                foreach (DataGridViewRow row in subjectDataGridView.Rows)
                {
                    bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                    if (bResult)
                    {
                        var fee = (Subject) row.DataBoundItem;
                        var s = new LabSubject
                                    {
                                        LabSubjectId = 0,
                                        SubjectId = fee.SubjectId,
                                        IsActive = true,
                                        LaboratoryFeeId = LabFeeId
                                    };
                        if (Save.LabSubjects(s) > 0)
                            i += 1;
                    }
                }
                UtilClass.ShowSaveMessageBox(i);
            }
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                LoadSubjects();
            }
        }

        
    }
}
