using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using System;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class StudentSearchTreeForm : Form
    {
        public string SearchValue { get; set; }

        private YearLevelCourseSectionSemSyEntity _studentEntity;
        private StudentLedgerForm ledgerForm = null;

        public StudentSearchTreeForm(StudentLedgerForm form)
        {
            ledgerForm = form;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_studentEntity != null)
            {
                ledgerForm.StudentX = _studentEntity;
            }
        }

        private void FillTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();

            var q = ObjectQueries.GetStudentBySemSy(SearchValue);
            var tempItem = 0;
            foreach (var item1 in q)
            {
                if (tempItem != item1.StudentId)
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
                tempItem = item1.StudentId;
            }
            Cursor.Current = Cursors.Default;
        }

        private void StudentSearchTreeForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Student":
                    break;
                case "SemYr":
                    _studentEntity = (YearLevelCourseSectionSemSyEntity) e.Node.Tag;
                    break;
                default:
                    break;
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    buttonOk.PerformClick();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
