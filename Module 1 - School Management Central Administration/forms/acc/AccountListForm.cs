using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;
using Microsoft.Reporting.WinForms;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class AccountListForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        private FeeTitle _feeTitle;
        private FeeSubTitle _feeSubTitle;
        private FeeParticular _feeParticular;

        private List<int> lSemSyId;
        List<SemSy> lSemSy = LoadQueries.GetSemSy();

        private int _iSemId = 0;

        public AccountListForm()
        {
            InitializeComponent();
        }

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FillTreeview();
            LoadSemSy();
            Cursor.Current = Cursors.Default;
            
        }

        private void FillTreeview()
        {
            treeView1.Nodes.Clear();
            var lFeeTitles = LoadQueries.GetFeeTitles();
            var lFeeSubTitles = LoadQueries.GetFeeSubTitles();
            var lFeeParticulars = LoadQueries.GetFeeParticulars();

            foreach (var lFeeTitle in lFeeTitles)
            {
                var nodeParent = new TreeNode(lFeeTitle.FeeTitleName);
                nodeParent.Name = "FeeTitle";
                nodeParent.Tag = lFeeTitle;

                foreach (var lFeeSubTitle in lFeeSubTitles)
                {
                    if (lFeeSubTitle.FeeTitleId == lFeeTitle.FeeTitleId)
                    {
                        var nodeChild01 = new TreeNode(lFeeSubTitle.FeeSubTitleName);
                        nodeChild01.Name = "FeeSubTitle";
                        nodeChild01.Tag = lFeeSubTitle;

                        nodeParent.Nodes.Add(nodeChild01);

                        foreach (var lFeeParticular in lFeeParticulars)
                        {
                            if (lFeeParticular.FeeSubTitleId == lFeeSubTitle.FeeSubTitleId)
                            {
                                var nodeChild02 = new TreeNode(lFeeParticular.Particulars);
                                nodeChild02.Name = "FeeParticular";
                                nodeChild02.Tag = lFeeParticular;
                                
                                nodeChild01.Nodes.Add(nodeChild02);
                            }
                        }
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    using (var f = new UpdateFeeTitleForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._FeeTitle = _feeTitle;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F10:
                    using (var f = new FeeSubTitleForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._FeeSubTitle = _feeSubTitle;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                case Keys.F11:
                    using (var f = new UpdateFeeParticularForm())
                    {
                        f.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f._FeeParticular = _feeParticular;
                        f.MaximizeBox = false;
                        f.MinimizeBox = false;
                        f.ShowDialog();
                    }
                    break;
                default:
                    MessageBox.Show(@"Please verify your selection.", @"Verify", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
            FillTreeview();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var label = string.Empty;
            switch (e.Node.Name)
            {
                case "FeeTitle":
                    jTabWizard1.SelectTab(tabPage1);
                    if (e.Node.Tag != null)
                    {
                        _feeTitle = (FeeTitle) e.Node.Tag;
                        printFeeClassBindingSource.DataSource = ObjectQueries.GetPrintFeeClassFeeTitle(_iSemId,_feeTitle.FeeTitleId);
                    }
                    label = String.Format(@":: {0}", e.Node.Text);
                    break;
                case "FeeSubTitle":
                    jTabWizard1.SelectTab(tabPage2);
                    if (e.Node.Tag != null)
                    {
                        _feeSubTitle = (FeeSubTitle) e.Node.Tag;
                        printFeeClassBindingSource.DataSource = ObjectQueries.GetPrintFeeClassFeeSubTitle(_iSemId,_feeSubTitle.FeeSubTitleId);
                    }
                    label = String.Format(@":: {0} : {1}", e.Node.Parent.Text, e.Node.Text);
                    break;
                case "FeeParticular":
                    _feeParticular = (FeeParticular) e.Node.Tag;
                    label = String.Format(@":: {0} : {1} : {2}", e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text);
                    break;
                default:
                    MessageBox.Show(@"Please select an item from the treeview on the left side of the screen.",
                                    @"Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            label2.Text = label;
            Cursor.Current = Cursors.Default;
        }

        private void LoadSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            var tempList = ObjectQueries.GetSemSyEntities();
            var semSy = new SemSyEntity
            {
                Semester = @"--- Select Semester + School Year ---"
            };
            tempList.Insert(0, semSy);
            semSyEntityBindingSource.DataSource = tempList;
            Cursor.Current = Cursors.Default;
        }

        private void semSyEntityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (semSyEntityBindingSource.Current != null)
            {
                var semSy = (SemSyEntity)semSyEntityBindingSource.Current;
                if (semSy != null)
                {
                    SemSyEntity = ObjectQueries.GetSemSyEntity(semSy.SemSyId);
                    _iSemId = semSy.SemSyId;
                    FillTreeview();
                }
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage3);
            semSyEntityBindingSource.DataSource = SemSyEntity;
            BranchBindingSource.DataSource = Branch;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            label2.Text = label2.Text + @" => Print Preview";
        }
    }
}
