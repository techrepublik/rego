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
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class RegistrarPreferencesForm : Form
    {
        private enum Selection
        {
            GradeBase,
            Position,
            EmpStatus,
            PostMode,
            Schools,
            Requirements,
            Levels
        };

        private Selection _selection;

        public RegistrarPreferencesForm()
        {
            InitializeComponent();
        }

        private void gradeBasDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //if (gradeBasBindingSource.Current != null)
            //{
            //    if (gradeBasDataGridView.Rows.Count > 0)
            //    {
            //        if (gradeBasDataGridView.IsCurrentRowDirty)
            //        {
            //            Validate();
            //            gradeBasBindingSource.EndEdit();
            //            var iResult = Save.GradeBases((GradeBas) gradeBasBindingSource.Current);
            //            if (iResult > 0)
            //            {
            //                LoadData(); //load data from the database
            //                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
            //            }
            //        }
            //    }
            //}
            //Cursor.Current = Cursors.Default;
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            gradeBasBindingSource.DataSource = LoadQueries.GetGradeBases();
            positionBindingSource.DataSource = LoadQueries.GetPositions();
            empStatusBindingSource.DataSource = LoadQueries.GetEmpStatuses();
            alliedSchoolBindingSource.DataSource = AlliedSchoolsManager.GetAllAlliedShools();
            educationLevelBindingSource.DataSource = EducationLevelManager.GetAllEducationLevels();
            requirementBindingSource.DataSource = RequirementManager.GetAllRequirements();
            Cursor.Current = Cursors.Default;
        }

        private void LoadGradeBaseValues()
        {
            Cursor.Current = Cursors.WaitCursor;
            gradeBaseValuesBindingSource.DataSource =
                LoadQueries.GetGradeBaseValuesByGradeBaseList((GradeBas) gradeBasBindingSource.Current);
            Cursor.Current = Cursors.Default;
        }

        private void RegistrarPreferencesForm_Load(object sender, EventArgs e)
        {
            LoadData(); //load data from gradebase
            GetAllPostModes(); //load post mode
            bindingNavigatorDeleteItem.Enabled = false;
        }

        private void gradeBasBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (_selection)
            {
                case Selection.GradeBase:
                    using (var f = new UpdateGradeBaseForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        if (gradeBasBindingSource.Current != null)
                            f.GradeBase = ((GradeBas)gradeBasBindingSource.Current);
                        f.MinimizeBox = false;
                        f.MaximizeBox = false;
                        f.ShowDialog();
                    }
                    bindingNavigatorDeleteItem.Enabled = false;
                    break;
                case Selection.Position:
                    gradeBasBindingNavigator.BindingSource = positionBindingSource;
                    positionBindingSource.AddNew();
                    positionDataGridView.Focus();
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                case Selection.EmpStatus:
                    gradeBasBindingNavigator.BindingSource = empStatusBindingSource;
                    empStatusBindingSource.AddNew();
                    empStatusDataGridView.Focus();
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                case Selection.PostMode:
                    gradeBasBindingNavigator.BindingSource = postModeBindingSource;
                    postModeBindingSource.AddNew();
                    postModeDataGridView.Focus();
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                default:
                    MessageBox.Show(@"Please select the proper tab and grid for actions.", @"Information",
                                    MessageBoxButtons.OK);
                    break;
            }
        }

        private void gradeBasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (gradeBasBindingSource != null)
            {
                LoadGradeBaseValues(); //load data from gradebasevalues
            }
        }

        private void gradeBasDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBasBindingSource;
        }

        private void gradeBaseValuesDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBaseValuesBindingSource;
        }

        private void positionDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = positionBindingSource;
        }

        private void empStatusDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = empStatusBindingSource;
        }

        private void positionDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            SavePosition(); //save position (teacher)
        }

        private void SavePosition()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (positionBindingSource.Current != null)
            {
                if (positionDataGridView.Rows.Count > 0)
                {
                    if (positionDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        positionBindingSource.EndEdit();
                        if (Save.Positions((Position) positionBindingSource.Current) > 0)
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(1);
                            positionBindingSource.DataSource = LoadQueries.GetPositions();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void empStatusDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            SaveEmpStatus(); //save empstatus (teacher)
        }

        private void SaveEmpStatus()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (empStatusBindingSource.Current != null)
            {
                if (empStatusDataGridView.Rows.Count > 0)
                {
                    if (empStatusDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        empStatusBindingSource.EndEdit();
                        if (Save.EmpStatuses((EmpStatus) empStatusBindingSource.Current) > 0)
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(1);
                            empStatusBindingSource.DataSource = LoadQueries.GetEmpStatuses();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    _selection = Selection.GradeBase;
                    bindingNavigatorDeleteItem.Enabled = false;
                    break;
                case 1:
                    _selection = Selection.Position;
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                case 2:
                    _selection = Selection.EmpStatus;
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                case 3:
                    _selection = Selection.PostMode;
                    bindingNavigatorDeleteItem.Enabled = true;
                    break;
                case 4:
                    _selection = Selection.Schools;
                    bindingNavigatorDeleteItem.Enabled = true;
                    gradeBasBindingNavigator.BindingSource = alliedSchoolBindingSource;
                    break;
                case 5:
                    _selection = Selection.Requirements;
                    bindingNavigatorDeleteItem.Enabled = true;
                    gradeBasBindingNavigator.BindingSource = requirementBindingSource;
                    break;
                case 6:
                    _selection = Selection.Levels;
                    bindingNavigatorDeleteItem.Enabled = true;
                    gradeBasBindingNavigator.BindingSource = educationLevelBindingSource;
                    break;
                default: break;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            switch (_selection)
            {
                case Selection.GradeBase: break;
                case Selection.Position:
                    DeletePosition(); //delete positions
                    break;
                case Selection.EmpStatus:
                    DeleteEmpstatus(); //delete empstatus
                    break;
                case Selection.PostMode:
                    DeletePostMode(); //delete postmode
                    break;
                case Selection.Schools:
                    DeleteAlliedSchools(); //delete alliedSchools
                    break;
                case Selection.Requirements:
                    DeleteRequirements(); //delete requirements
                    break;
                case Selection.Levels:
                    DeleteEducationLevel(); //delete educationLevels
                    break;
                default:
                    MessageBox.Show(@"Please select the proper tab and grid for actions.", @"Information",
                                    MessageBoxButtons.OK);
                    break;
            }
        }

        private void DeleteEducationLevel()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (educationLevelBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    educationLevelBindingSource.EndEdit();
                    if (EducationLevelManager.Delete((EducationLevel)educationLevelBindingSource.Current))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        educationLevelBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteRequirements()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (requirementBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    requirementBindingSource.EndEdit();
                    if (RequirementManager.Delete((Requirement) requirementBindingSource.Current))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        requirementBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteAlliedSchools()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (alliedSchoolBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    alliedSchoolBindingSource.EndEdit();
                    if (AlliedSchoolsManager.Delete((AlliedSchool) alliedSchoolBindingSource.Current))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        alliedSchoolBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeletePosition()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (positionBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    positionBindingSource.EndEdit();
                    if (Remove.Positions(((Position)positionBindingSource.Current).PositionId))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        positionBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteEmpstatus()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (empStatusBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    empStatusBindingSource.EndEdit();
                    if (Remove.EmpStatuses(((EmpStatus) empStatusBindingSource.Current).EmpStatusId))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        empStatusBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeletePostMode()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (postModeBindingSource.Current != null)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    Validate();
                    postModeBindingSource.EndEdit();
                    if (PostModeManager.Delete((PostMode) postModeBindingSource.Current))
                    {
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                        postModeBindingSource.RemoveCurrent();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData(); //load all
        }

        private void postModeDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            SavePostMode(); //save
        }

        private void GetAllPostModes()
        {
            Cursor.Current = Cursors.WaitCursor;
            postModeBindingSource.DataSource = PostModeManager.GetAll();
            Cursor.Current = Cursors.Default;
        }

        private void SavePostMode()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (postModeBindingSource.Current != null)
            {
                if (postModeDataGridView.Rows.Count > 0)
                {
                    if (postModeDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        postModeBindingSource.EndEdit();
                        if (PostModeManager.Save((PostMode) postModeBindingSource.Current) > 0)
                        {
                            postModeBindingSource.DataSource = PostModeManager.GetAll();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void postModeDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = postModeBindingSource;
        }

        private void alliedSchoolDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (alliedSchoolDataGridView.Rows.Count > 0)
            {
                if (alliedSchoolBindingSource.Current != null)
                {
                    if (alliedSchoolDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        alliedSchoolBindingSource.EndEdit();
                        var iResult = AlliedSchoolsManager.Save((AlliedSchool) alliedSchoolBindingSource.Current);
                        if (iResult > 0)
                        {
                            alliedSchoolBindingSource.DataSource = AlliedSchoolsManager.GetAllAlliedShools();
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void requirementDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (requirementDataGridView.Rows.Count > 0)
            {
                if (requirementBindingSource.Current != null)
                {
                    if (requirementDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        requirementBindingSource.EndEdit();
                        var iResult = RequirementManager.Save((Requirement) requirementBindingSource.Current);
                        if (iResult > 0)
                        {
                            requirementBindingSource.DataSource = RequirementManager.GetAllRequirements();
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void educationLevelDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (educationLevelDataGridView.Rows.Count > 0)
            {
                if (educationLevelBindingSource.Current != null)
                {
                    if (educationLevelDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        educationLevelBindingSource.EndEdit();
                        var iResult = EducationLevelManager.Save(((EducationLevel) educationLevelBindingSource.Current));
                        if (iResult > 0)
                        {
                            educationLevelBindingSource.DataSource = EducationLevelManager.GetAllEducationLevels();
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
