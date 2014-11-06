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
    public partial class ProspectusUpdateSubjectForm : Form
    {
        public ProspectusSemYr _ProspectusSemYr { get; set; }

        private enum delete
        {
            subject,
            prereq
        } ;

        private delete myDelete;

        public ProspectusUpdateSubjectForm()
        {
            InitializeComponent();
        }

        private void ProspectusUpdateSubjectForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadProspectusSubjects();
            LoadComboRecords();
            //subjectBindingSource.DataSource = ObjectQueries.GetSubjectList();
            toolStripStatusLabel1.Text = @"Ready...";
            Cursor.Current = Cursors.Default;
        }

        private void LoadComboRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            SubjectNo1.ValueMember = "SubjectId";
            SubjectNo1.DisplayMember = "SubjectNo";
            SubjectNo1.DataPropertyName = "SubjectNo";
            SubjectNo1.DataSource = ObjectQueries.GetSubjectList();
            Cursor.Current = Cursors.Default;
        }

        private void comboBoxSelectedItem(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedValue != null)
            {
                dataGridView2.CurrentRow.Cells[1].Value = ((Subject) comboBox.SelectedItem).SubjectDescriptiveTitle;
                dataGridView2.CurrentRow.Cells[2].Value = ((Subject)comboBox.SelectedItem).SubjectLecUnit;
                dataGridView2.CurrentRow.Cells[3].Value = ((Subject)comboBox.SelectedItem).SubjectLabUnit;
                dataGridView2.CurrentRow.Cells[4].Value = ((Subject)comboBox.SelectedItem).SubjectCreUnit;
                dataGridView2.CurrentRow.Tag = ((Subject) comboBox.SelectedItem).SubjectId;
            }
            else
            {
                dataGridView2.CurrentRow.Cells[1].Value = string.Empty;
                dataGridView2.CurrentRow.Cells[2].Value = string.Empty;
                dataGridView2.CurrentRow.Cells[3].Value = string.Empty;
                dataGridView2.CurrentRow.Cells[4].Value = string.Empty;
                dataGridView2.CurrentRow.Tag = string.Empty;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ComboBox comboBox;
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    comboBox = e.Control as ComboBox;
                    comboBox.SelectedIndexChanged += comboBoxSelectedItem;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var f= new ProspectusSelectSubjectForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f._ProspectusSemYr = _ProspectusSemYr;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
            }
        }

        private void LoadProspectusSubjects()
        {
            if (_ProspectusSemYr != null)
            {
                var lPros = ObjectQueries.GetProspectusSubjectEntities(_ProspectusSemYr.ProspectusSemYrId);
                int i = 0;
                foreach (var item in lPros)
                {
                    dataGridView1.Rows.Add(item.SubjectNo, item.DescriptiveTitle, item.Lecture, item.Laboratory,
                                           item.Credit, item.IsCounted);
                    dataGridView1.Rows[i].Tag = item.ProspectusSubjectId;
                    i += 1;
                }
            }
        }

        private void LoadProspectusSubjectsPreRequisites()
        {
            if (dataGridView1.CurrentRow != null)
            {
                var iProSubjectId = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                if (iProSubjectId > 0)
                {
                    var lPros = ObjectQueries.GetProspectusSubjectPreReqEntities(iProSubjectId) ;
                    int i = 0;
                    dataGridView2.Rows.Clear();
                    foreach (var item in lPros)
                    {
                        dataGridView2.Rows.Add(item.SubjectNo, item.DescriptiveTitle, item.Lecture, item.Laboratory,
                                               item.Credit, item.IsAndOr, item.Note, item.ProspectusSubjectPreReqId);
                        dataGridView2.Rows[i].Tag = item.SubjectId;
                        i += 1;
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count > 0) | (dataGridView2.Rows.Count > 0))
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    if (myDelete == delete.subject)
                    {
                        if (dataGridView1.CurrentRow.Tag != null)
                        {
                            bool bResult = Remove.ProspectusSubjects((Convert.ToInt32(dataGridView1.CurrentRow.Tag)));
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        }
                    }
                    else
                    {
                        if (dataGridView2.CurrentRow.Tag != null)
                        {
                            bool bResult = Remove.PreRequisites((Convert.ToInt32(dataGridView2.CurrentRow.Cells[7].Value)));
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                        }
                    }

                }
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ComboBox comboBox;
                if (dataGridView2.CurrentCell.ColumnIndex == 0)
                {
                    comboBox = e.Control as ComboBox;
                    comboBox.SelectedIndexChanged += comboBoxSelectedItem;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = @"Subject grid selected...";
            myDelete = delete.subject;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = @"Pre-requisite grid selected...";
            myDelete = delete.prereq;
        }

        private void ProspectusUpdateSubjectForm_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = @"Ready...";
        }

        private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var iProSubjectId = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                    if (iProSubjectId > 0)
                    {
                        if (dataGridView2.IsCurrentRowDirty)
                        {
                            Validate();
                            var p = new PreRequisite
                                        {
                                            PreRequisiteId = dataGridView2.CurrentRow.Cells[7].Value != null ? Convert.ToInt32(dataGridView2.CurrentRow.Cells[7].Value) : 0,
                                            SubjectId = Convert.ToInt32(dataGridView2.CurrentRow.Tag),
                                            ProspectusSubjectId = iProSubjectId, 
                                            IsAndOr = dataGridView2.CurrentRow.Cells[5].Value != null ? Convert.ToBoolean(dataGridView2.CurrentRow.Cells[5].Value) : false,
                                            Note = dataGridView2.CurrentRow.Cells[6].Value != null ? dataGridView2.CurrentRow.Cells[6].Value.ToString() : string.Empty
                                        };

                            int iResult = Save.PreRequisites(p);
                            UtilClass.ShowSaveMessageBox(iResult);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Please select subject first.", @"Select a subject.", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        dataGridView1.Focus();
                    }
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //LoadProspectusSubjectsPreRequisites();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            LoadProspectusSubjectsPreRequisites();
        }
    }
}
