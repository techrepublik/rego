using System;
using System.ComponentModel;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.gen
{
    public partial class LookUpTableForm : Form
    {
        private int _menu = 0;
        public LookUpTableForm()
        {
            InitializeComponent();
        }

        private void LookUpTableForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyBindingSource.DataSource = LoadQueries.GetSemSy();
            yearLevelBindingSource.DataSource = LoadQueries.GetYearLevels();
            sectionBindingSource.DataSource = LoadQueries.GetSections();
            studentStatusBindingSource.DataSource = LoadQueries.GetStatus();
            studentTypeBindingSource.DataSource = LoadQueries.GetStudentType();
            gradingPeriodBindingSource.DataSource = ObjectQueries.GetGradingPeriod();
            Cursor.Current = Cursors.Default;
        }

        private void semSyDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (semSyDataGridView.Rows.Count > 0)
            {
                if (semSyBindingSource.Current != null)
                {
                    if (semSyDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        semSyBindingSource.EndEdit();
                        int i = Save.SemSy((SemSy) semSyBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void yearLevelDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (yearLevelDataGridView.Rows.Count > 0)
            {
                if (yearLevelBindingSource.Current != null)
                {
                    if (yearLevelDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        yearLevelBindingSource.EndEdit();
                        int i = Save.YearLevels((YearLevel) yearLevelBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void sectionDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (sectionDataGridView.Rows.Count > 0)
            {
                if (sectionBindingSource.Current != null)
                {
                    if (sectionDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        sectionBindingSource.EndEdit();
                        int i = Save.Sections((Section) sectionBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void studentStatusDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (studentStatusDataGridView.Rows.Count > 0)
            {
                if (studentStatusBindingSource.Current != null)
                {
                    if (studentStatusDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        sectionBindingSource.EndEdit();
                        int i = Save.StudentStatuss((StudentStatus) studentStatusBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void studentTypeDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (studentTypeDataGridView.Rows.Count > 0)
            {
                if (studentTypeBindingSource.Current != null)
                {
                    if (studentTypeDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        studentTypeBindingSource.EndEdit();
                        int i = Save.StudentTypes((StudentType) studentTypeBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            switch (_menu)
            {
                case 0:
                    if (semSyDataGridView.Rows.Count > 0)
                    {
                        if (semSyBindingSource.Current != null)
                        {
                            Validate();
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.SemSys(((SemSy) semSyBindingSource.Current).SemSyId);
                                UtilClass.ShowDeleteMessageBox(bResult);
                                if (bResult)
                                    semSyBindingSource.RemoveCurrent();
                            }
                        }
                    }
                    break;
                case 1:
                    if (yearLevelDataGridView.Rows.Count > 0)
                    {
                        if (yearLevelBindingSource.Current != null)
                        {
                            Validate();
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.YearLevels(((YearLevel)yearLevelBindingSource.Current).YearLevelId);
                                UtilClass.ShowDeleteMessageBox(bResult);
                                if (bResult)
                                    yearLevelBindingSource.RemoveCurrent();
                            }
                        }
                    }
                    break;
                case 2:
                    if (sectionDataGridView.Rows.Count > 0)
                    {
                        if (sectionBindingSource.Current != null)
                        {
                            Validate();
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.Sections(((Section)sectionBindingSource.Current).SectionId);
                                UtilClass.ShowDeleteMessageBox(bResult);
                                if (bResult)
                                    sectionBindingSource.RemoveCurrent();
                            }
                        }
                    }
                    break;
                case 3:
                    if (studentStatusDataGridView.Rows.Count > 0)
                    {
                        if (studentStatusBindingSource.Current != null)
                        {
                            Validate();
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.StudentStatuss(((StudentStatus)studentStatusBindingSource.Current).StudentStatusId);
                                UtilClass.ShowDeleteMessageBox(bResult);
                                if (bResult)
                                    studentStatusBindingSource.RemoveCurrent();
                            }
                        }
                    }
                    break;
                case 4:
                    if (studentTypeDataGridView.Rows.Count > 0)
                    {
                        if (studentTypeBindingSource.Current != null)
                        {
                            Validate();
                            if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                            {
                                bool bResult = Remove.StudentType(((StudentType)studentTypeBindingSource.Current).StudenTypeId);
                                UtilClass.ShowDeleteMessageBox(bResult);
                                if (bResult)
                                    studentTypeBindingSource.RemoveCurrent();
                            }
                        }
                    }
                    break;
                default:
                    break;

            }
        }

        private void semSyDataGridView_Click(object sender, EventArgs e)
        {
            _menu = 0;
        }

        private void yearLevelDataGridView_Click(object sender, EventArgs e)
        {
            _menu = 1;
        }

        private void sectionDataGridView_Click(object sender, EventArgs e)
        {
            _menu = 2;
        }

        private void studentStatusDataGridView_Click(object sender, EventArgs e)
        {
            _menu = 3;
        }

        private void studentTypeDataGridView_Click(object sender, EventArgs e)
        {
            _menu = 4;
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
                if (semSyDataGridView.Rows.Count > 0)
                {
                    if (semSyBindingSource.Current != null)
                    {
                        Validate();
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult = Remove.SemSys(((SemSy)semSyBindingSource.Current).SemSyId);
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                semSyBindingSource.RemoveCurrent();
                        }
                    }
                }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
                if (yearLevelDataGridView.Rows.Count > 0)
                {
                    if (yearLevelBindingSource.Current != null)
                    {
                        Validate();
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult = Remove.YearLevels(((YearLevel) yearLevelBindingSource.Current).YearLevelId);
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                yearLevelBindingSource.RemoveCurrent();
                        }
                    }
                }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
                if (sectionDataGridView.Rows.Count > 0)
                {
                    if (sectionBindingSource.Current != null)
                    {
                        Validate();
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult = Remove.Sections(((Section) sectionBindingSource.Current).SectionId);
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                sectionBindingSource.RemoveCurrent();
                        }
                    }
                }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (studentStatusBindingSource.Current != null)
            {
                if (studentStatusDataGridView.Rows.Count > 0)
                {
                    if (studentStatusBindingSource.Current != null)
                    {
                        Validate();
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult =
                                Remove.StudentStatuss(
                                    ((StudentStatus) studentStatusBindingSource.Current).StudentStatusId);
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                studentStatusBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorDeleteItem5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (studentStatusBindingSource.Current != null)
            {
                if (studentTypeDataGridView.Rows.Count > 0)
                {
                    if (studentTypeBindingSource.Current != null)
                    {
                        Validate();
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult =
                                Remove.StudentType(((StudentType) studentTypeBindingSource.Current).StudenTypeId);
                            UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                studentTypeBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (gradingPeriodBindingSource.Current != null)
            {
                Validate();
                gradingPeriodBindingSource.EndEdit();
                var iResult = Save.GradingPeriods((GradingPeriod) gradingPeriodBindingSource.Current);
                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            }
            Cursor.Current = Cursors.Default;
        }

        private void semSyBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void fifthGradingLabel_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }
}
