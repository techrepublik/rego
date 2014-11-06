using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.entities;

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class StudentBalancesForm : Form
    {
        private List<SemSyEntity> _listSemSyEntities = null;
        private List<Branch> _listBranches = null;
 
        public StudentBalancesForm()
        {
            InitializeComponent();
        }

        private void StudentBalancesForm_Load(object sender, EventArgs e)
        {
            LoadBranchSemSy();  //load Branches and SemSy
            LoadScholarship();  //load scholarships
            LoadBalanceMenu();  //balance menu

            panel1.Enabled = true;
        }

        private void LoadStudentBalances(SemSyEntity semSyEntity)
        {
            Cursor.Current = Cursors.WaitCursor;
            studentBalanceEntityBindingSource.DataSource = FinanceQueries.ListStudentBalancesBySemSy(semSyEntity);
            Cursor.Current = Cursors.Default;
        }

        private void LoadBranchSemSy()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listBranches = ObjectQueries.GetBranches();
            foreach (var branch in _listBranches)
            {
                toolStripComboBoxBranch.Items.Add(branch.BranchName);
            }
            if (_listBranches.Count > 0)
                toolStripComboBoxBranch.SelectedIndex = 0;

            _listSemSyEntities = ObjectQueries.GetSemSyEntities();
            foreach (var semSyEntity in _listSemSyEntities)
            {
                toolStripComboBoxSemSy.Items.Add(semSyEntity.SemSyName);
            }
            if (_listSemSyEntities.Count > 0)
                toolStripComboBoxSemSy.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;
        }

        private void toolStripComboBoxSemSy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxSemSy.Items.Count > 0)
            {
                LoadStudentBalances(_listSemSyEntities[toolStripComboBoxSemSy.SelectedIndex]);
                panel1.Enabled = true;
            }
        }

        private void LoadScholarship()
        {
            Cursor.Current = Cursors.WaitCursor;
            scholarshipBindingSource.DataSource = LoadQueries.GetScholarships();
            Cursor.Current = Cursors.Default;
        }

        private void LoadBalanceMenu()
        {
            comboBoxBalance.Items.Clear();
            comboBoxBalance.Items.Add("All");
            comboBoxBalance.Items.Add("With Balance");
            comboBoxBalance.Items.Add("No Balance");

            comboBoxBalance.SelectedIndex = 0;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            SearchIdNoOrName();
            panel1.Enabled = false;
        }

        private void SearchIdNoOrName()
        {
            if ((toolStripTextBox1.Text.Length > 0) && (toolStripTextBox1.Text != string.Empty))
            {
                Cursor.Current = Cursors.WaitCursor;
                if (studentBalanceEntityBindingSource.Count > 0)
                {
                    var listStudentBalance = studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>().Where(item => (item.LastName.StartsWith(toolStripTextBox1.Text)) || (item.IdNo.Equals(toolStripTextBox1.Text))).ToList();
                    studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void FilterByScholarship(Scholarship scholarship)
        {
            if ((comboBoxComboBox.Text.Length > 0) && (comboBoxComboBox.SelectedIndex > -1))
            {
                Cursor.Current = Cursors.WaitCursor;
                if (studentBalanceEntityBindingSource.Count > 0)
                {
                    var listStudentBalance = studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>().Where(item => (item.ScholarshipId.Equals(scholarship.ScholarshipId))).ToList();
                    studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void FilterByBalance(int option)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (option)
            {
                case 0:
                    if (checkBoxScholarship.Checked == false)
                    {
                        if (toolStripComboBoxSemSy.Items.Count > 0)
                        {
                            LoadStudentBalances(_listSemSyEntities[toolStripComboBoxSemSy.SelectedIndex]);
                            panel1.Enabled = true;
                        }
                    }
                    break;
                case 1:
                    if (checkBoxScholarship.Checked == false)
                    {
                        if (studentBalanceEntityBindingSource.Count > 0)
                        {
                            var listStudentBalance =
                                studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>()
                                                                 .Where(item => (item.Balance > 0))
                                                                 .ToList();
                            studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                        }
                    }
                    break;
                case 2:
                    if (checkBoxScholarship.Checked == false)
                    {
                        if (studentBalanceEntityBindingSource.Count > 0)
                        {
                            var listStudentBalance =
                                studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>()
                                                                 .Where(item => (item.Balance <= 0))
                                                                 .ToList();
                            studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                        }
                    }
                    break;
                case 3:
                    if (checkBoxScholarship.Checked)
                    {
                        if (studentBalanceEntityBindingSource.Count > 0)
                        {
                            var listStudentBalance =
                                studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>()
                                                                 .Where(item => ((item.Balance > 0) &&(item.ScholarshipId.Equals(((Scholarship) scholarshipBindingSource.Current).ScholarshipId)))).ToList();
                            studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                        }
                    }
                    break;
                case 4:
                    if (checkBoxScholarship.Checked)
                    {
                        if (studentBalanceEntityBindingSource.Count > 0)
                        {
                            var listStudentBalance =
                                studentBalanceEntityBindingSource.List.Cast<StudentBalanceEntity>()
                                                                 .Where(item => ((item.Balance <= 0) && (item.ScholarshipId.Equals(((Scholarship)scholarshipBindingSource.Current).ScholarshipId)))).ToList();
                            studentBalanceEntityBindingSource.DataSource = listStudentBalance;
                        }
                    }
                    break;
                default:
                    Console.Write(@"Selection needed.");
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxSemSy.Items.Count > 0)
            {
                LoadStudentBalances(_listSemSyEntities[toolStripComboBoxSemSy.SelectedIndex]);
                panel1.Enabled = true;
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButtonGo.PerformClick();
            }
        }

        private void scholarshipBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (scholarshipBindingSource.Current != null)
            {
                if ((comboBoxBalance.SelectedIndex == 0) && (checkBoxScholarship.Checked))
                    FilterByScholarship((Scholarship)scholarshipBindingSource.Current);
                else if ((comboBoxBalance.SelectedIndex == 1) && (checkBoxScholarship.Checked))
                    FilterByBalance(3);
                else if ((comboBoxBalance.SelectedIndex == 2) && (checkBoxScholarship.Checked))
                    FilterByBalance(4);
            }
        }

        private void comboBoxBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBalance.SelectedIndex > -1)
            {
                switch (comboBoxBalance.SelectedIndex)
                {
                    case 0:
                        FilterByBalance(0);
                        break;
                    case 1:
                        FilterByBalance(1);
                        break;
                    case 2:
                        FilterByBalance(2);
                        break;
                    default:
                        Console.Write(@"Selection needed.");
                        break;
                }
            }
        }

        private void comboBoxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
