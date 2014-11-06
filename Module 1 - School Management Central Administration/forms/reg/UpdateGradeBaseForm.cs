using GenDataLayer;
using GenDataLayer.repo.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class UpdateGradeBaseForm : Form
    {
        public GradeBas GradeBase { get; set; }

        private enum Selection
        {
            GradeBase,
            GradeBaseValue
        };

        private Selection selection;
        public UpdateGradeBaseForm()
        {
            InitializeComponent();
        }

        private void UpdateGradeBaseForm_Load(object sender, EventArgs e)
        {
            if (GradeBase != null)
            {
                gradeBasBindingSource.DataSource = GradeBase;
                GetAllGradeBaseValues();
            }
        }

        private int SaveGradeBase()
        {
            var iResult = 0;
            if (gradeBasBindingSource != null)
            {
                if (gradeBasBindingSource.Current != null)
                {
                    Validate();
                    gradeBasBindingSource.EndEdit();
                    iResult = Save.GradeBases((GradeBas) gradeBasBindingSource.Current);
                }
            }
            return iResult;
        }

        private void SaveAll()
        {
            Cursor.Current = Cursors.WaitCursor;
            var iResult = SaveGradeBase();
            var iCounter = 0;
            if (iResult > 0)
            {
                if (gradeBaseValuesBindingSource != null)
                {
                    foreach (GradeBaseValue item in gradeBaseValuesBindingSource.List)
                    {
                        Validate();
                        item.GradeBaseId = iResult;
                        gradeBaseValuesBindingSource.EndEdit();
                        if (Save.GradeBaseValues(item) > 0)
                            iCounter += 1;

                        if (gradeBaseValuesBindingSource.List.Count == iCounter)
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iCounter);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void gradeBasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveAll(); //save all items
        }

        private void gradeBasBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            gradeBasBindingNavigatorSaveItem.Enabled = true;
        }

        private void gradeBasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            gradeBasBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (selection)
            {
                case Selection.GradeBase:
                    gradeBaseValuesBindingSource.Clear();
                    gradeBaseNameTextBox.Focus();
                    break;
                case Selection.GradeBaseValue:
                    gradeBaseValuesDataGridView.Focus();
                    break;
                default:
                    break;
            }

            

        }

        private void GetAllGradeBaseValues()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (GradeBase != null)
            {
                gradeBaseValuesBindingSource.DataSource = LoadQueries.GetGradeBaseValuesByGradeBaseList(GradeBase);
            }
            Cursor.Current = Cursors.Default; 
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            switch (selection)
            {
                case Selection.GradeBase:
                    DeleteGradeBase(); //delete gradebase
                    break;
                case Selection.GradeBaseValue:
                    DeleteGradeBaseValue(); //delete gradebasevalue
                    break;
                default:
                    break;
            }
        }

        private void DeleteGradeBase()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (gradeBasBindingSource.Current != null)
            {
                var iId = Convert.ToInt32(((GradeBas) gradeBasBindingSource.Current).GradeBaseId);
                if (iId > 0)
                {
                    var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        gradeBasBindingSource.EndEdit();
                        if (Remove.GradeBases(iId))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            gradeBasBindingSource.RemoveCurrent();
                            gradeBaseValuesBindingSource.Clear();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteGradeBaseValue()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (gradeBaseValuesBindingSource.Current != null)
            {
                var iId = Convert.ToInt32(((GradeBaseValue) gradeBaseValuesBindingSource.Current).GradeBaseValueId);
                if (iId > 0)
                {
                    var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                    if (dResult == DialogResult.Yes)
                    {
                        Validate();
                        gradeBaseValuesBindingSource.EndEdit();
                        if (Remove.GradeBaseValues(iId))
                        {
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(true);
                            gradeBaseValuesBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void gradeBaseNameTextBox_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBasBindingSource;
            selection = Selection.GradeBase;
        }

        private void gradeBaseDescriptionTextBox_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBasBindingSource;
            selection = Selection.GradeBase;
        }

        private void gradeBaseActiveCheckBox_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBasBindingSource;
            selection = Selection.GradeBase;
        }

        private void gradeBaseDefaultCheckBox_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBasBindingSource;
            selection = Selection.GradeBase;
        }

        private void gradeBaseValuesDataGridView_Enter(object sender, EventArgs e)
        {
            gradeBasBindingNavigator.BindingSource = gradeBaseValuesBindingSource;
            selection = Selection.GradeBaseValue;
        }
    }
}
