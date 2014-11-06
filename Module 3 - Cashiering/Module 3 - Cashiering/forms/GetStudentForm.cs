using System;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;

namespace Module_3___Cashiering.forms
{
    public partial class GetStudentForm : Form
    {
        private YearLevelCourseSectionSemSyEntity _studentEntity;
        private CashierForm _cashierForm;
        public GetStudentForm(CashierForm cashierForm)
        {
            _cashierForm = cashierForm;
            InitializeComponent();
        }

        private void GetStudentForm_Load(object sender, EventArgs e)
        {
            waterMarkTextBox1.Select();
            waterMarkTextBox1.Focus();
        }

        private void waterMarkTextBox1_Enter(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBox1, true);
        }

        private void waterMarkTextBox1_Leave(object sender, EventArgs e)
        {
            UtilityManager.util.UtilClass.ChangeColor(waterMarkTextBox1, false);
        }

        private void FillTreeView(string searchValue)
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();

            var tempId = 0;
            var q = ObjectQueries.GetStudentBySemSy(searchValue);
            foreach (var item1 in q)
            {
                if (tempId != item1.StudentId)
                {
                    var nodeParent = new TreeNode(String.Format(@"{0} - {1}", item1.IdNo, item1.FullName));
                    nodeParent.Name = @"Student";
                    nodeParent.Tag = item1;

                    foreach (var item2 in q)
                    {
                        if (item1.StudentId == item2.StudentId)
                        {
                            var nodeChild01 =
                                new TreeNode(String.Format(@"{0}, {1}/{2}/{3}", item2.SemSyName, item2.YearLevelName,
                                                           item2.CourseName, item2.SectionName));
                            nodeChild01.Name = @"SemYr";
                            nodeChild01.Tag = item2;

                            nodeParent.Nodes.Add(nodeChild01);
                        }
                    }
                    treeView1.Nodes.Add(nodeParent);
                }
                tempId = item1.StudentId;
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (waterMarkTextBox1.Text.Length > 0)
            {
                FillTreeView(waterMarkTextBox1.Text);
            }
        }

        private void waterMarkTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGo.PerformClick();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_studentEntity != null)
            {
                _cashierForm.Entity = _studentEntity;
            }
            Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Student":
                    break;
                case "SemYr":
                    _studentEntity = (YearLevelCourseSectionSemSyEntity)e.Node.Tag;
                    break;
                default:
                    break;
            }
        }
    }
}
