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

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class StudentLedgerForm : Form
    {
        public YearLevelCourseSectionSemSyEntity StudentX { get; set; }

        private StudentSearchTreeForm searchForm = null;
        private UpdateAssessmentForm assessmentForm = null;
        public StudentLedgerForm()
        {
            InitializeComponent();
        }

        private void StudentLedgerForm_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = assessmentEntityBindingSource;
            ImageWatermark();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            using (searchForm = new StudentSearchTreeForm(this))
            {
                searchForm.StartPosition = FormStartPosition.CenterScreen;
                searchForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                if (!string.IsNullOrEmpty(waterMarkTextSearch.Text) && (waterMarkTextSearch.Text.Length > 0))
                    searchForm.SearchValue = waterMarkTextSearch.Text;
                searchForm.MaximizeBox = false;
                searchForm.MinimizeBox = false;
                //searchForm.ShowDialog();
                if (searchForm.ShowDialog() == DialogResult.OK)
                    LoadData01();
            }
        }

        private void LoadData01()
        {
            if (StudentX != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                waterMarkTextSearch.Text = StudentX.IdNo;
                textBoxName.Text = StudentX.FullName;
                textBoxCrsYrSec.Text = StudentX.CrsYearSection;
                textBoxScholarship.Text = StudentX.ScholarshipName;
                textBoxSemSy.Text = StudentX.SemSyName;
                if (StudentX.RegistrationId != null)
                {
                    studentLedgerEntityBindingSource.DataSource =
                        FinanceQueries.ListStudentLedgerByRegistration((int) StudentX.RegistrationId);
                    assessmentEntityBindingSource.DataSource =
                        FinanceQueries.ListStudentAssessmentByRegistration((int) StudentX.RegistrationId);
                    receiptDetailEntityBindingSource.DataSource =
                        FinanceQueries.ListStudentPaymentMadeyRegistration((int) StudentX.RegistrationId);
                }
                //computation
                ComputeLedgerSummary();
                ComputeAssessmentSummary();
                ComputePaymentSummary();
                Cursor.Current = Cursors.Default;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void waterMarkTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGo.PerformClick();
            }
        }

        private void ComputeLedgerSummary()
        {
            if (studentLedgerEntityBindingSource != null)
            {
                try
                {
                    var tempDebit = 0.00;
                    var tempCredit = 0.00;
                    var tempBalance = 0.00;
                    foreach (StudentLedgerEntity item in studentLedgerEntityBindingSource.List)
                    {
                        if (item.Debit != null) tempDebit += (double) item.Debit;
                        if (item.Credit != null) tempCredit += (double) item.Credit;
                        if (item.Balance != null) tempBalance += (double) item.Balance;
                    }
                    labelDebit.Text = String.Format(@"{0:#,000.00}", tempDebit);
                    labelCredit.Text = String.Format(@"{0:#,000.00}", tempCredit);
                    labelBalance.Text = String.Format(@"{0:#,000.00}", tempBalance);

                    if (tempBalance > 0)
                    {
                        labelBalance.ForeColor = Color.Red;
                    }
                    else if (tempBalance < 0)
                    {
                        labelBalance.ForeColor = Color.Purple;
                    }
                    else
                    {
                        labelBalance.ForeColor = Color.Black;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void ComputeAssessmentSummary()
        {
            if (assessmentEntityBindingSource != null)
            {
                try
                {
                    var tempGross = 0.00;
                    var tempDeduction = 0.00;
                    var tempNet = 0.00;
                    foreach (AssessmentEntity item in assessmentEntityBindingSource.List)
                    {
                        if (item.GrossAmt != null) tempGross += (double)item.GrossAmt;
                        if (item.Deduction != null) tempDeduction += (double)item.Deduction;
                        if (item.NetAmt != null) tempNet += (double)item.NetAmt;
                    }
                    labelGross.Text = String.Format(@"{0:#,000.00}", tempGross);
                    labelDeduction.Text = String.Format(@"{0:#,000.00}", tempDeduction);
                    labelNetAmount.Text = String.Format(@"{0:#,000.00}", tempNet);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void ComputePaymentSummary()
        {
            if (receiptDetailEntityBindingSource != null)
            {
                try
                {
                    var tempTotal = 0.00;
                    foreach (ReceiptDetailEntity item in receiptDetailEntityBindingSource.List)
                    {
                        if (item.PaidAmount != null) tempTotal += (double)item.PaidAmount;
                    }
                    labelPaidAmount.Text = String.Format(@"{0:#,000.00}", tempTotal);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void ImageWatermark()
        {
            if (pictureBox1.Image != null)
            {
                //Create image.
                Image tmp = pictureBox1.Image;
                //Create graphics object for alteration.
                Graphics g = Graphics.FromImage(tmp);

                //Create string to draw. 
                String wmString = "Josh Image Here...";
                //Create font and brush.
                Font wmFont = new Font("Trebuchet MS", 10);
                SolidBrush wmBrush = new SolidBrush(Color.Black);
                //Create point for upper-left corner of drawing. 
                PointF wmPoint = new PointF(10.0F, 10.0F);
                //Draw string to image.
                g.DrawString(wmString, wmFont, wmBrush, wmPoint);
                //Load the new image to picturebox 
                pictureBox1.Image = tmp;
                //Release graphics object. 
                g.Dispose();
            }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            if (StudentX != null)
            {
                using (assessmentForm = new UpdateAssessmentForm())
                {
                    assessmentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    assessmentForm.StartPosition = FormStartPosition.CenterScreen;
                    assessmentForm.MaximizeBox = false;
                    assessmentForm.MinimizeBox = false;
                    assessmentForm.Height = 520;
                    assessmentForm.StudentX = StudentX;
                    assessmentForm.ShowDialog();
                }
            }
        }
    }
}
