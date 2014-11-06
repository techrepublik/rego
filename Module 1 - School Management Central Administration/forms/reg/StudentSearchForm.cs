using System;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using Module_1___School_Management_Central_Administration.forms.acc;
using Module_1___School_Management_Central_Administration.forms.csm;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class StudentSearchForm : Form
    {
        public string SearchValue { get; set; }

        private YearLevelCourseSectionSemSyEntity _studentEntity;
        private StudentAcademicRecordForm academicForm = null;

        public StudentSearchForm(StudentAcademicRecordForm form)
        {
            academicForm = form;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_studentEntity != null)
            {
                academicForm.StudentX = _studentEntity;
            }
        }

        private void FillTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();

            var tempId = 0;
            var q = ObjectQueries.GetStudentBySemSy(SearchValue);
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

        private void StudentSearchForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }
    }
}
