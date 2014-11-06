using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class AssignSubjectTeacherForm : Form
    {
        public AssignSubjectTeacherForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            var lColleges = LoadQueries.GetColleges();
            var lDepartments = LoadQueries.GetDepartments();
            var lTeachers = ObjectQueries.GetAllTeachersWithDepartment();
            var lBranches = ObjectQueries.GetBranches();

            foreach (var branch in lBranches)
            {
                var nodeParentParent = new TreeNode(branch.BranchName) { Name = "Branch", Tag = branch };

                foreach (var college in lColleges)
                {
                    if (college.BranchId == branch.BranchId)
                    {
                        var nodeParent = new TreeNode(college.CollegeName) { Name = "College", Tag = college };

                        nodeParentParent.Nodes.Add(nodeParent);

                        foreach (var department in lDepartments)
                        {
                            if (department.CollegeId == college.CollegeId)
                            {
                                var nodeChild01 = new TreeNode(department.DepartmentName)
                                {
                                    Name = "Department",
                                    Tag = department
                                };

                                nodeParent.Nodes.Add(nodeChild01);

                                foreach (var teacher in lTeachers)
                                {
                                    if (teacher.DepartmentId == department.DepartmentId)
                                    {
                                        var nodeChild02 = new TreeNode(teacher.FullName)
                                        {
                                            Name = "Teacher",
                                            Tag = teacher
                                        };

                                        nodeChild01.Nodes.Add(nodeChild02);
                                    }
                                }
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParentParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void AssignSubjectTeacherForm_Load(object sender, EventArgs e)
        {
            FillTreeview(); //fill out treeview
            GetAllSemSy(); //load all semsy
            GetAllRooms(); //load all rooms
        }

        private void GetAllRooms()
        {
            Cursor.Current = Cursors.WaitCursor;
            roomBindingSource.DataSource = ObjectQueries.GetRooms();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllTeacherSubjects(int iId, int iChoice)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (semSyEntityBindingSource.Count > 0)
            {
                teacherSubjectEntityBindingSource.DataSource = AcademicQueries.GetAllTeacherSubjects(iId, iChoice, ((SemSyEntity)semSyEntityBindingSource.Current).SemSyId);    
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllTeachers()
        {
            Cursor.Current = Cursors.WaitCursor;
            teacherEntityBindingSource.DataSource = ObjectQueries.GetAllTeachers();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllScheduleDetails(int iId)
        {
            Cursor.Current = Cursors.WaitCursor;
            scheduleDetailBindingSource.DataSource = ObjectQueries.GetSchecduleDetails(iId);
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "College":
                    if ((e.Node.Tag != null))
                    {
                        GetAllTeacherSubjects(((College)e.Node.Tag).CollegeId, 1);
                    }
                    break;
                case "Department":
                    if (e.Node.Tag != null)
                    {
                        GetAllTeacherSubjects(((Department)e.Node.Tag).DepartmentId, 0);
                    }
                    break;
                case "Teacher":
                    if (e.Node.Tag != null)
                    {
                        GetAllTeacherSubjects(((TeacherEntity)e.Node.Tag).TeacherId, 2);
                    }
                    break;
                default:
                    break;
            }
        }

        private void teacherSubjectEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (teacherSubjectEntityBindingSource.Current != null)
            {
                GetAllScheduleDetails(
                    Convert.ToInt32(((TeacherSubjectEntity) teacherSubjectEntityBindingSource.Current).ScheduleId));
                teacherSubjectEntityBindingNavigatorSaveItem.Enabled = true;
            }
        }

        private void SaveTeacherSubject()
        {
            Cursor.Current = Cursors.WaitCursor;
            //if (teacherSubjectEntityBindingSource.Current != null)
            //{
                //if (teacherSubjectEntityDataGridView.Rows.Count > 0)
                //{
                    //if (teacherSubjectEntityDataGridView.IsCurrentRowDirty)
                    //{
                    //    Validate();
                    //    var tempT = (TeacherSubjectEntity)teacherSubjectEntityBindingSource.Current;
                    //    var t = new TeacherSubject
                    //        {
                    //            TeacherSubjectId = Convert.ToInt32(tempT.TeacherSubjectId),
                    //            TeacherSubjectNote = tempT.TeacherSubjectNote,
                    //            TeacherId = tempT.TeacherId,
                    //            ScheduleId = tempT.ScheduleId,
                    //            TeacherSubjectIsActive = tempT.Active,
                    //            TeacherSubjectOnUs = tempT.OnUs,
                    //            TeacherSubjectPosted = tempT.Posted,
                    //            TeacherSubjectPostEdited = tempT.PostEdited,
                    //            TeacherSubjectPostedDate = tempT.PostedDate,
                    //            TeacherSubjectPostMode = tempT.Mode,
                    //            TeacherSubjectPostedBy = tempT.PostedBy
                    //        };
                    //    var iResult = TeacherSubjectManager.Save(t) > 0;
                    //    if (iResult)
                    //    {
                    //        ((TeacherSubjectEntity)teacherSubjectEntityBindingSource.Current).TeacherSubjectId = Convert.ToInt32(iResult);
                    //        UtilityManager.util.UtilClass.ShowSaveMessageBox(1);
                    //    }
                    //}
                //}
            //}

            if (teacherSubjectEntityBindingSource != null)
            {
                var iCounter = 0;
                var iiCounter = 0;
                if (teacherSubjectEntityDataGridView.Rows.Count > 0)
                {
                    Validate();
                    foreach (TeacherSubjectEntity item in teacherSubjectEntityBindingSource.List)
                    {
                        if (item.TeacherId > 0)
                        {
                            iiCounter += 1;
                            var t = new TeacherSubject
                                {
                                    TeacherSubjectId = Convert.ToInt32(item.TeacherSubjectId),
                                    TeacherSubjectNote = item.TeacherSubjectNote,
                                    TeacherId = item.TeacherId,
                                    ScheduleId = item.ScheduleId,
                                    TeacherSubjectIsActive = item.Active,
                                    TeacherSubjectOnUs = item.OnUs,
                                    TeacherSubjectPosted = item.Posted,
                                    TeacherSubjectPostEdited = item.PostEdited,
                                    TeacherSubjectPostedDate = item.PostedDate,
                                    TeacherSubjectPostMode = item.Mode,
                                    TeacherSubjectPostedBy = item.PostedBy
                                };

                            var iResult = TeacherSubjectManager.Save(t) > 0;
                            if (iResult)
                            {
                                iCounter += 1;
                            }
                        }
                    }
                }

                if (iCounter == iiCounter)
                    UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
            }
            Cursor.Current = Cursors.Default;
        }

        private void teacherSubjectEntityDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //SaveTeacherSubject();
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            GetAllTeachers(); //load out all teachers
        }

        private void teacherSubjectEntityDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void teacherSubjectEntityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveTeacherSubject(); //save teacher subject
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteTeacherSubject(); //delete
        }

        private void DeleteTeacherSubject()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (teacherSubjectEntityBindingSource.Current != null)
            {
                var o = (TeacherSubjectEntity) teacherSubjectEntityBindingSource.Current;
                if (o != null)
                {
                    if (o.TeacherSubjectId > 0)
                    {
                        var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                        if (dResult == DialogResult.Yes)
                        {
                            if (TeacherSubjectManager.Delete(Convert.ToInt32(o.TeacherSubjectId)))
                            {
                                UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                                teacherSubjectEntityBindingSource.RemoveCurrent();
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
