using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class LaboratoryFeeListForm : Form
    {
        private int _LabFeeId;

        private int _Choise = 0;

        public LaboratoryFeeListForm()
        {
            InitializeComponent();
        }

        private void LoadRequisites()
        {
            feeParticularBindingSource.DataSource = LoadQueries.GetFeeParticulars();
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            laboratoryFeeBindingSource.DataSource = ObjectQueries.GetLaboratoryFees();
        }

        private void LaboratoryFeeListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            LoadRequisites();
            Cursor.Current = Cursors.Default;
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lSemSy = ObjectQueries.GetSemSyEntities();
            var lLabFees = ObjectQueries.GetLaboratoryFeesEntity();

            foreach (var semsy in lSemSy)
            {
                var nodeParent = new TreeNode(semsy.SemSyName);
                nodeParent.Name = "SemSy";
                nodeParent.Tag = semsy;

                foreach (var labFee in lLabFees)
                {
                    if (labFee.SemYrId == semsy.SemSyId)
                    {
                        var nodeChild01 = new TreeNode(labFee.DisplayLabel);
                        nodeChild01.Name = "LabFee";
                        nodeChild01.Tag = labFee;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void laboratoryFeeDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (laboratoryFeeBindingSource.CurrencyManager.List.Count > 0)
            {
                if (laboratoryFeeBindingSource.Current != null)
                {
                    if (laboratoryFeeDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        laboratoryFeeBindingSource.EndEdit();
                        var iResult = Save.LaboratoryFees((LaboratoryFee) laboratoryFeeBindingSource.Current);
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        if (iResult > 0)
                            FillTreeview();
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "SemSy":
                    jTabWizard1.SelectedTab = tabPage1;
                    if (e.Node.Tag != null)
                        laboratoryFeeBindingSource.DataSource =
                            ObjectQueries.GetLaboratoryFees(((SemSyEntity) e.Node.Tag).SemSyId);
                    break;
                case "LabFee":
                    jTabWizard1.SelectedTab = tabPage2;
                    if (e.Node.Tag != null)
                    {
                        _LabFeeId = ((LaboratoryFeesEntity) e.Node.Tag).LaboratoryFeeId;
                        laboratorySubjectEntityBindingSource.DataSource = ObjectQueries.GetLaboratorySubjects(_LabFeeId);
                    }
                    break;
                default:
                    break;
            }
        }

        private void toolStripButtonLoadSubject_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectedTab = tabPage2;
            using(var f = new UpdateLabSubjectForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                f.LabFeeId = _LabFeeId;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_Choise == 0)
            {
                if (laboratoryFeeBindingSource.CurrencyManager.List.Count > 0)
                {
                    if (laboratoryFeeBindingSource.Current != null)
                    {
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult =
                                Remove.LaboratoryFees(
                                    ((LaboratoryFee) laboratoryFeeBindingSource.Current).LaboratoryFeeId);
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                laboratoryFeeBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
            else
            {
                if (laboratorySubjectEntityBindingSource.CurrencyManager.List.Count > 0)
                {
                    if (laboratorySubjectEntityBindingSource.Current != null)
                    {
                        if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                        {
                            bool bResult =
                                Remove.LabSubjects(
                                    ((LaboratorySubjectEntity)laboratorySubjectEntityBindingSource.Current).LabSubjectId);
                            UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                            if (bResult)
                                laboratorySubjectEntityBindingSource.RemoveCurrent();
                        }
                    }
                }
            }
        }

        private void laboratoryFeeDataGridView_Click(object sender, EventArgs e)
        {
            _Choise = 0;
        }

        private void laboratorySubjectEntityDataGridView_Click(object sender, EventArgs e)
        {
            _Choise = 1;
        }
    }
}
