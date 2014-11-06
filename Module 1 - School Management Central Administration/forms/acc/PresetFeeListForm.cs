using System;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class PresetFeeListForm : Form
    {
        private SetPresetFee _SetPresetFee;

        public PresetFeeListForm()
        {
            InitializeComponent();
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lSemSy = LoadQueries.GetSemSy();
            var lCrsEtAl = ObjectQueries.GetSetPresetFees();

            foreach (var semSy in lSemSy)
            {
                var nodeParent = new TreeNode(semSy.Semester + ", " + semSy.Sy);
                nodeParent.Name = "SemSy";
                nodeParent.Tag = semSy;

                foreach (var item in lCrsEtAl)
                {
                    if (item.SemYrId == semSy.SemSyId)
                    {
                        var nodeChild01 = new TreeNode(item.CourseAndYr);
                        nodeChild01.Name = "CourseYr";
                        nodeChild01.Tag = item;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (e.KeyCode)
            {
                case Keys.F9:
                    using (var f = new UpdateSetFeeForm())
                    {
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        if (_SetPresetFee != null)
                            f.SetPresetFee = _SetPresetFee;
                        f.MinimizeBox = false;
                        f.MaximizeBox = false;
                        f.ShowDialog();
                        FillTreeview();
                    }
                    break;
                case Keys.F10:
                    using (var f = new UpdatePresetFeeForm())
                    {
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.MinimizeBox = false;
                        f.MaximizeBox = false;
                        if (f.ShowDialog() == DialogResult.Yes)
                        {
                            LoadPresetFee(_SetPresetFee.SetPresetFeeId);
                        }
                    }
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonSetFees_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var f = new UpdateSetFeeForm())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedSingle;
                if (_SetPresetFee != null)
                    f.SetPresetFee = _SetPresetFee;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ShowDialog();
                FillTreeview();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PresetFeeListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            toolStripButtonDelete.Enabled = false;
            Cursor.Current = Cursors.Default;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "CourseYr":
                    if (e.Node.Tag != null)
                    {
                        jTabWizard1.SelectedTab = tabPage2;
                        _SetPresetFee = ObjectQueries.GetSetPresetFee(((SetPresetFeeEntity) e.Node.Tag).SetPresetFeeId);
                        if (_SetPresetFee != null)
                            LoadPresetFee(_SetPresetFee.SetPresetFeeId);
                    }
                    break;
                default:
                    break;
            }
        }

        private void toolStripButtonPreset_Click(object sender, EventArgs e)
        {
            if (_SetPresetFee != null)
            {
                using (var f = new UpdatePresetFeeForm())
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.FormBorderStyle = FormBorderStyle.FixedSingle;
                    f.SetPresetFeeId = _SetPresetFee.SetPresetFeeId;
                    f.MinimizeBox = false;
                    f.MaximizeBox = false;
                    f.ShowDialog();
                }
            }
        }

        private void LoadPresetFee(int iSetPresetFeeId)
        {
            Cursor.Current = Cursors.WaitCursor;
            presetFeeEntityBindingSource.DataSource = ObjectQueries.GetPresetFees(iSetPresetFeeId);
            Cursor.Current = Cursors.Default;
        }

        private void presetFeeEntityDataGridView_Click(object sender, EventArgs e)
        {
            if (presetFeeEntityBindingSource.CurrencyManager.List.Count > 0)
            {
                toolStripButtonDelete.Enabled = true;
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (presetFeeEntityBindingSource.CurrencyManager.List.Count > 0)
            {
                if (presetFeeEntityBindingSource.Current != null)
                {
                    if (UtilityManager.util.UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                    {
                        bool bResult =
                            Remove.PresetFees(((PresetFeeEntity) presetFeeEntityBindingSource.Current).PresetFeeId);
                        UtilityManager.util.UtilClass.ShowDeleteMessageBox(bResult);
                        if (bResult)
                            presetFeeEntityBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tabPage4;

        }
    }
}
