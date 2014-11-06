namespace Module_2___Registration.forms
{
    partial class ReportCertificateRegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RegistrationEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RegisteredSubjectEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AssessEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.UserEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SemSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RegistrationEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegisteredSubjectEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssessEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RegistrationEntityBindingSource
            // 
            this.RegistrationEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.RegistrationEntity);
            // 
            // RegisteredSubjectEntityBindingSource
            // 
            this.RegisteredSubjectEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.RegisteredSubjectEntity);
            // 
            // AssessEntityBindingSource
            // 
            this.AssessEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.AssessEntity);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Set1";
            reportDataSource1.Value = this.RegistrationEntityBindingSource;
            reportDataSource2.Name = "Set2";
            reportDataSource2.Value = this.RegisteredSubjectEntityBindingSource;
            reportDataSource3.Name = "Set3";
            reportDataSource3.Value = this.AssessEntityBindingSource;
            reportDataSource4.Name = "Set4";
            reportDataSource4.Value = this.UserEntityBindingSource;
            reportDataSource5.Name = "Set5";
            reportDataSource5.Value = this.SemSyEntityBindingSource;
            reportDataSource6.Name = "Set6";
            reportDataSource6.Value = this.BranchBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Module_2___Registration.reports.CertificateOfRegistration.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(824, 490);
            this.reportViewer1.TabIndex = 0;
            // 
            // UserEntityBindingSource
            // 
            this.UserEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.UserEntity);
            // 
            // SemSyEntityBindingSource
            // 
            this.SemSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // BranchBindingSource
            // 
            this.BranchBindingSource.DataSource = typeof(GenDataLayer.Branch);
            // 
            // ReportCertificateRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 490);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportCertificateRegistrationForm";
            this.Text = "Certificate of Registration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportCertificateRegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RegistrationEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegisteredSubjectEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssessEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RegistrationEntityBindingSource;
        private System.Windows.Forms.BindingSource RegisteredSubjectEntityBindingSource;
        private System.Windows.Forms.BindingSource AssessEntityBindingSource;
        private System.Windows.Forms.BindingSource UserEntityBindingSource;
        private System.Windows.Forms.BindingSource SemSyEntityBindingSource;
        private System.Windows.Forms.BindingSource BranchBindingSource;
    }
}