using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class PostGradeListForm : Form
    {
        public PostGradeListForm()
        {
            InitializeComponent();
        }

        private void PostGradeListForm_Load(object sender, EventArgs e)
        {
            GetAllSemSy(); //load semsy
        }

        private void GetAllSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllPostGrades(int iSemSyId, int iChoice)
        {
            Cursor.Current = Cursors.WaitCursor;
            postGradeEntityBindingSource.DataSource = AcademicQueries.GetAllPostGrades(iSemSyId, iChoice);
            Cursor.Current = Cursors.Default;
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (semSyEntityBindingSource.Current != null)
            {
                var iId = ((SemSyEntity)semSyEntityBindingSource.Current).SemSyId;
                if (iId > 0)
                {
                    GetAllPostGrades(iId, 1);
                }
            }
        }

        private void postGradeEntityDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
