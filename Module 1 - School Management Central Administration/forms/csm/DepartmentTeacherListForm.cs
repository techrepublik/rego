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
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class DepartmentTeacherListForm : Form
    {
        public DepartmentTeacherListForm()
        {
            InitializeComponent();
        }

        private void DepartmentTeacherListForm_Load(object sender, EventArgs e)
        {
            GetAllDepartments();
            GetAllDepartmentTeachers();
        }

        private void GetAllDepartments()
        {
            Cursor.Current = Cursors.WaitCursor;
            departmentBindingSource.DataSource = LoadQueries.GetDepartments();
            Cursor.Current = Cursors.Default;
        }

        private void SaveDepartmentTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (departmentTeacherEntityBindingSource.Current != null)
            {
                Validate();
                var tempD = (DepartmentTeacherEntity) departmentTeacherEntityBindingSource.Current;
                if (tempD != null)
                {
                    var d = new DepartmentTeacher
                        {
                            DepartmentTeacherId = Convert.ToInt32(tempD.DepartmentTeacherId),
                            DepartmentTeacherNote  = tempD.Note,
                            DepartmentTeacherIsActive = tempD.Active,
                            DepartmentId = tempD.DepartmentId,
                            TeacherId = tempD.TeacherId
                        };
                    if (DepartmentTeacherManager.Save(d) > 0)
                    {
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(1);    
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteDepartmentTeacher()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (departmentTeacherEntityBindingSource.Current != null)
            {
                var iId = ((DepartmentTeacherEntity) departmentTeacherEntityBindingSource.Current).DepartmentTeacherId;
                if (iId > 0)
                {
                    var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                    if (dResult == DialogResult.Yes)
                    {
                        if (DepartmentTeacherManager.Delete(Convert.ToInt32(iId)))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            departmentTeacherEntityBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void departmentTeacherEntityDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (departmentTeacherEntityDataGridView.Rows.Count > 0)
            {
                if (departmentTeacherEntityDataGridView.IsCurrentRowDirty)
                {
                    SaveDepartmentTeacher(); //save
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (departmentTeacherEntityDataGridView.Rows.Count > 0)
            {
                DeleteDepartmentTeacher(); //delete
            }
        }

        private void GetAllDepartmentTeachers()
        {
            Cursor.Current = Cursors.WaitCursor;
            departmentTeacherEntityBindingSource.DataSource = ObjectQueries.GetAllDepartmentTeachers();
            Cursor.Current = Cursors.Default;
        }
    }
}
