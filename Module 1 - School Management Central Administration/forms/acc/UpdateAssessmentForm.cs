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

namespace Module_1___School_Management_Central_Administration.forms.acc
{
    public partial class UpdateAssessmentForm : Form
    {
        public YearLevelCourseSectionSemSyEntity StudentX { get; set; }

        public UpdateAssessmentForm()
        {
            InitializeComponent();
        }

        private void UpdateAssessmentForm_Load(object sender, EventArgs e)
        {
            LoadFeePartiulars(); //load FeeParticulars

            if (StudentX != null)
            {
                if (StudentX.RegistrationId != null) LoadAssessments((int) StudentX.RegistrationId);
                if (StudentX.RegistrationId != null) LoadSubjects((int) StudentX.RegistrationId);
            }
        }

        private void LoadFeePartiulars()
        {
            Cursor.Current = Cursors.WaitCursor;
            feeParticularBindingSource.DataSource = LoadQueries.GetFeeParticulars();
            Cursor.Current = Cursors.Default;
        }

        private void LoadAssessments(int iRegistrationId)
        {
            Cursor.Current = Cursors.WaitCursor;
            assessmentBindingSource.DataSource = LoadQueries.GetAssessmentByRegistration(iRegistrationId);
            if (assessmentBindingSource != null)
                ComputeTotalAssessedAmount(); //compute total amount
            Cursor.Current = Cursors.Default;
        }

        private void LoadSubjects(int iRegistrationId)
        {
            Cursor.Current = Cursors.WaitCursor;
            studentSubjectEntityBindingSource.DataSource =
                AcademicQueries.LoadStudentSubjectEntityByRegistration(iRegistrationId);
            if (studentSubjectEntityBindingSource != null)
                ComputeTotalCreditUnits(); //compute total credit
            Cursor.Current = Cursors.Default;
        }

        private void ComputeTotalAssessedAmount()
        {
            Cursor.Current = Cursors.WaitCursor;
            var gross = 0.00;
            var less = 0.00;
            var net = 0.00;

            foreach (Assessment item in assessmentBindingSource.List)
            {
                gross += Convert.ToDouble(item.Amount) + Convert.ToDouble(item.AddAmount);
                less += Convert.ToDouble(item.Less) + Convert.ToDouble(item.AddLess);
                net += Convert.ToDouble(item.NetAmount);
            }
            labelGross.Text = String.Format(@"{0:#,000.00}", gross);
            labelLess.Text = String.Format(@"{0:#,000.00}", less);
            labelNet.Text = String.Format(@"{0:#,000.00}", net);
            Cursor.Current = Cursors.Default;
        }

        private void ComputeTotalCreditUnits()
        {
            Cursor.Current = Cursors.WaitCursor;
            var lab = 0.00;
            var lec = 0.00;
            var credit = 0.00;

            foreach (StudentSubjectEntity item in studentSubjectEntityBindingSource.List)
            {
                lab += Convert.ToDouble(item.LaboratoryUnit);
                lec += Convert.ToDouble(item.LectureUnit);
                credit += Convert.ToDouble(item.CreditUnit);
            }
            labelLab.Text = String.Format(@"{0}", lab);
            labelLec.Text = String.Format(@"{0}", lec);
            labelCredit.Text = String.Format(@"{0}", credit);
            Cursor.Current = Cursors.Default;
        }

        private void assessmentDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (assessmentBindingSource.Current != null)
            {
                if (assessmentDataGridView.Rows.Count > 0)
                {
                    if (assessmentDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        assessmentBindingSource.EndEdit();
                        var iResult = Save.Assessment((Assessment) assessmentBindingSource.Current);
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                        if (iResult > 0)
                            ComputeTotalAssessedAmount();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
