using GenDataLayer;
using GenDataLayer.repo.entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Module_2___Registration.forms
{
    public partial class ReportCertificateRegistrationForm : Form
    {
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }
        public Branch Branch { get; set; }

        public RegistrationEntity RegistrationEntity { get; set; }
        public List<RegisteredSubjectEntity> ListRegisteredSubjectEntity { get; set; }
        public List<AssessEntity> ListAssessEntity { get; set; }

        public ReportCertificateRegistrationForm()
        {
            InitializeComponent();
        }

        private void ReportCertificateRegistrationForm_Load(object sender, EventArgs e)
        {
            RegistrationEntityBindingSource.DataSource = RegistrationEntity;
            RegisteredSubjectEntityBindingSource.DataSource = ListRegisteredSubjectEntity;
            AssessEntityBindingSource.DataSource = ListAssessEntity;
            BranchBindingSource.DataSource = Branch;
            SemSyEntityBindingSource.DataSource = SemSyEntity;
            UserEntityBindingSource.DataSource = UserEntity;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }
    }
}
