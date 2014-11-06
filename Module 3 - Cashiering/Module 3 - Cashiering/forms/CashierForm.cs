using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;
using GenDataLayer.repo.managers.man;
using GenDataLayer.repo.reportingentities;

namespace Module_3___Cashiering.forms
{
    public partial class CashierForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        public YearLevelCourseSectionSemSyEntity Entity { get; set; }

        const string TempString = @"<<..>>";
        private readonly GetStudentForm _getStudentForm;

        private List<StudentLedgerEntity> _listStudentLedger;
        private List<StudentLedgerEntity> _tempListStudentLedger;
        private decimal _gross;
        private decimal _deduct;
        private decimal _balance;
        private double _runningBalance;
        private double _tenderedAmount;
        
        public CashierForm()
        {
            _getStudentForm = new GetStudentForm(this);
            InitializeComponent();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {

            
        }

        public void FillTreeView(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            treeView1.Nodes.Clear();

            var q = AcademicQueries.LoadYearLevelSemSyByRegistration(iStudentId);
            foreach (var item1 in q)
            {
                var nodeParent = new TreeNode(String.Format(@"{0}", item1.SemSyName));
                nodeParent.Name = @"SemYr";
                nodeParent.Tag = item1;

                foreach (var item2 in q)
                {
                    if (item1.SemSyId == item2.SemSyId)
                    {
                        var nodeChild01 =
                            new TreeNode(String.Format(@"{0}/{1}/{2} - {3}", item2.YearLevelName,
                                                       item2.CourseName, item2.SectionName, item2.ScholarshipName));
                        nodeChild01.Name = @"CrsYrSec";
                        nodeChild01.Tag = item2;

                        nodeParent.Nodes.Add(nodeChild01);
                    }
                }
                treeView1.Nodes.Add(nodeParent);
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            _getStudentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _getStudentForm.StartPosition = FormStartPosition.CenterScreen;
            _getStudentForm.MaximizeBox = false;
            _getStudentForm.MinimizeBox = false;
            if (_getStudentForm.ShowDialog() == DialogResult.Yes)
            {
                if (Entity != null)
                {
                    labelSemSy.Text = Entity.SemSyName;
                    labelIdNo.Text = Entity.IdNo;
                    labelFullName.Text = Entity.FullName.ToUpper();
                    labelYrCrsSec.Text = Entity.CrsYearSection;
                    labelRegNo.Text = String.Format(@"{0} / {1:M}, {2:yyyy}", Entity.RegistrationId, Entity.RegistrationDate, Entity.RegistrationDate);
                    labelScholarship.Text = Entity.ScholarshipName;

                    if (Entity.RegistrationId > 0)
                    {
                        GetBalances(Convert.ToInt32(Entity.RegistrationId));
                        FillTreeView(Entity.StudentId);
                        GetAllReceiptByStudent(Entity.StudentId);
                    }
                    else
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                else
                {
                    labelSemSy.Text = TempString;
                    labelIdNo.Text = TempString;
                    labelFullName.Text = TempString;
                    labelYrCrsSec.Text = TempString;
                    labelRegNo.Text = TempString;
                }
                
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(1);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(0);
        }

        private void GetBalances(int iRegistrationId)
        {
            Cursor.Current = Cursors.WaitCursor;
            _listStudentLedger = FinanceQueries.ListStudentLedgerByRegistration(iRegistrationId);
            if (_listStudentLedger != null)
            {
                dataGridView1.Rows.Clear();
                _gross = 0;
                _deduct = 0;
                _balance = 0;
                var index = 0;
                foreach (var item in _listStudentLedger)
                {
                    //if ((item.Valid == false) || (item.Valid == null))
                    //{
                        if (item.Balance > 0)
                        {
                            dataGridView1.Rows.Add(true, item.ParticularName, item.Balance);
                            dataGridView1.Rows[index].Tag = item;
                            index += 1;
                        }
                        _gross += Convert.ToDecimal(item.Debit);
                        _deduct += Convert.ToDecimal(item.Credit);
                        _balance += Convert.ToDecimal(item.Balance);
                    //}
                }
            }
            labelGross.Text = String.Format(@"{0:#,##0.00}", _gross);
            labelDeduct.Text = String.Format(@"{0:#,##0.0}", _deduct);
            labelNet.Text = String.Format(@"{0:#,##0.00}", _balance);
            labelRunningBalance.Text = String.Format(@"{0:#,##0.00}", _balance);
            labelBalance.Text = String.Format(@"{0:#,##0.00}", _balance);
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                MessageBox.Show(@"Clicked");
            }
        }

        private void waterMarkTextBoxTendered_TextChanged(object sender, EventArgs e)
        {
            var tempChange = 0.00;
            var tempTendered = 0.00;
            var tempActualBalance = 0.00;
            if (double.TryParse(waterMarkTextBoxTendered.Text, out tempTendered))
            {
                var tempBalance = Convert.ToDouble(_balance);
                if (tempTendered >  tempBalance)
                    tempChange = tempTendered - tempBalance;

                tempActualBalance = tempBalance - tempTendered;
            }

            labelChange.Text = String.Format(@"{0:#,##0.00}", tempChange);
            labelRemainingBalance.Text = String.Format(@"{0:#,##0.00}", tempActualBalance);
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Validate();
            if (e.ColumnIndex == 0)
            {
                var tempRunningBalance = 0.0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        tempRunningBalance += Convert.ToDouble(row.Cells[2].Value);
                    }
                }
                _runningBalance = tempRunningBalance;
                labelRunningBalance.Text = String.Format(@"{0:#,##0.00}", tempRunningBalance);
                labelBalance.Text = String.Format(@"{0:#,##0.00}", _runningBalance);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F12:
                    buttonPayment.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void SavePayment()
        {
            Cursor.Current = Cursors.WaitCursor;
            var iReceiptId = GetReceiptId();
            if (iReceiptId > 0)
            {
                var tempTenderedMinus = _tenderedAmount;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        if (tempTenderedMinus > 0)
                        {
                            var item = (StudentLedgerEntity) row.Tag;
                            var r = new ReceiptDetail();
                            r.AssessmentId = item.AssessmentId;
                            r.ReceiptId = iReceiptId;
                            r.FeeParticularId = item.ParticularId;
                            if (tempTenderedMinus >= Convert.ToDouble(item.Balance))
                                r.Amount = item.Balance;
                            else
                                r.Amount = Convert.ToDecimal(tempTenderedMinus);
                            r.IsValid = true;
                            r.CollectionName = item.ParticularName;
                            var iResult = ReceiptDetailManager.Save(r);
                            if (iResult > 0)
                            {
                                //update student registration
                                //UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                                //tempTenderedAdd += Convert.ToDouble(item.Balance);
                                tempTenderedMinus -= Convert.ToDouble(item.Balance);

                                if (tempTenderedMinus < 1)
                                {
                                    UtilityManager.util.UtilClass.ShowSaveMessageBox(1);
                                }
                                //this.reportViewer1.RefreshReport();
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private int GetReceiptId()
        {
            Validate();
            var iResult = 0;
            var tempTendered = 0.00;
            if (double.TryParse(waterMarkTextBoxTendered.Text, out tempTendered))
            {
                _tenderedAmount = tempTendered;
                if ((textBoxReceiptNo.Text.Length > 0) && (Entity.RegistrationId > 0) && (_tenderedAmount > 0))
                {
                    var r = new Receipt();
                    r.ReceiptNo = textBoxReceiptNo.Text;
                    r.ReceiptDate = dateTimePickerDate.Value;
                    r.PayDate = dateTimePickerDate.Value;
                    r.PayTime = dateTimePickerDate.Value.TimeOfDay;
                    r.IsValid = true;
                    r.RegistrationId = Entity.RegistrationId;
                    r.UserId = UserEntity.UserId;
                    iResult = Save.Receipts(r);
                }
                else
                {
                    UtilityManager.util.UtilClass.ShowCutsomMessageBox(@"Please check the RECEIPT NO. It should not be empty.");
                }
            }
            return iResult;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(4);
        }

        private void buttonBackLedger_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(0);
        }

        private void GetAllReceiptByStudent(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            printReceiptClassBindingSource.DataSource = FinanceQueries.ListReceiptsByStudent(iStudentId);
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(3);
        }

        private void printReceiptClassDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Validate();
            if (e.ColumnIndex == 5)
            {
                if (Convert.ToBoolean(printReceiptClassDataGridView[5, e.RowIndex].Value) == false)
                {
                    var dResult = MessageBox.Show(@"You are about to cancel this receipt, continue?",
                                                  @"Warning: O.R. Cancellation", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (dResult == DialogResult.Yes)
                    {
                        var r = (PrintReceiptClass)printReceiptClassBindingSource.Current;
                        UtilityManager.util.UtilClass.ShowCutsomMessageBox(CancelReceipt(r.ReceiptId)
                                                                               ? @"Receipt was cancelled successfully."
                                                                               : @"Receipt was NOT cancelled. Please verify or call administrator for assistance.");
                    }
                    else
                    {
                        printReceiptClassDataGridView[5, e.RowIndex].Value = true;
                    }
                }
            }
        }

        private bool CancelReceipt(int iReceiptId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var dResult = false;
            var iCounter = 0;
            var receipt = ReceiptManager.GetReceipt(iReceiptId);
            receipt.IsValid = false;
            var iResult = Save.Receipts(receipt);
            if (iResult > 0)
            {
                var receiptDetails = ReceiptDetailManager.GetAllReceiptDetail(iReceiptId);
                foreach (var item in receiptDetails)
                {
                    item.IsValid = false;
                    if (ReceiptDetailManager.Save(item) > 0)
                    {
                        iCounter += 1;
                    }
                }
                dResult = receiptDetails.Count == iCounter;
            }
            Cursor.Current = Cursors.Default;
            return dResult;
        }
    }
}
