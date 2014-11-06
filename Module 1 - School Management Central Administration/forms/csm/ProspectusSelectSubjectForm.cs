using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.entities;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class ProspectusSelectSubjectForm : Form
    {
        public ProspectusSemYr _ProspectusSemYr { get; set; }

        private List<DepartmentSubjectEntity> lDs;

        public ProspectusSelectSubjectForm()
        {
            InitializeComponent();
        }

        private void ProspectusSelectSubjectForm_Load(object sender, EventArgs e)
        {
            FillTreeview();
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            //var lCourses = LoadQueries.GetCourses();

            foreach (var college in lColleges)
            {
                var nodeParent = new TreeNode(college.CollegeName);
                nodeParent.Name = "College";
                nodeParent.Tag = college;

                foreach (var department in lDepartments)
                {
                    if (department.CollegeId == college.CollegeId)
                    {
                        var nodeChild01 = new TreeNode(department.DepartmentName);
                        nodeChild01.Name = "Department";
                        nodeChild01.Tag = department;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "College":
                    break;
                case "Department":
                    lDs = ObjectQueries.GetDepartmentSubjectEntities(((Department) e.Node.Tag).DepartmentId);
                    departmentSubjectEntityBindingSource.DataSource = lDs;
                        
                    break;
                default:
                    break;
            }
        }

        private void departmentSubjectEntityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            GetCheckedRows();
        }

        private void GetCheckedRows()
        {
            Validate();
            var i = 0;
            foreach (DataGridViewRow row in departmentSubjectEntityDataGridView.Rows)
            {
                bool bResult = Convert.ToBoolean(row.Cells[0].Value);
                if (bResult)
                {
                    var subject = (DepartmentSubjectEntity)row.DataBoundItem;
                    var d = new ProspectusSubject
                    {
                        ProspectusSemYr = _ProspectusSemYr,
                        SubjectId = subject.SubjectId,
                        IsCounted = true
                    };
                    if (Save.ProspectusSubjects(d) > 0)
                        i += 1;
                }
            }
            UtilClass.ShowSaveMessageBox(i);
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            LocalSearch();
        }

        private void LocalSearch()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (toolStripTextBox1.Text.Length > 0)
                {
                    List<DepartmentSubjectEntity> lD1s = lDs;
                    departmentSubjectEntityBindingSource.DataSource =
                        lD1s.FindAll(s => (s.SubjectNo.StartsWith(toolStripTextBox1.Text) || (s.SubjectDescriptiveTitle.StartsWith(toolStripTextBox1.Text))));
                }
                else
                {
                    departmentSubjectEntityBindingSource.DataSource = lDs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(@"Error {0} occured", ex.Message), @"Error.",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalSearch();
            }
        }
    }
}
