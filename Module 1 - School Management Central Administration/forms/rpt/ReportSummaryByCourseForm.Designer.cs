namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    partial class ReportSummaryByCourseForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource13 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource14 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PrintEnrolleeDepartmentClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SemSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintStudentClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.jTabWizard1 = new UtilityManager.ui.JTabWizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer5 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.PrintEnrolleeDepartmentClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintStudentClassBindingSource)).BeginInit();
            this.jTabWizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintEnrolleeDepartmentClassBindingSource
            // 
            this.PrintEnrolleeDepartmentClassBindingSource.DataSource = typeof(GenDataLayer.repo.reportingentities.PrintEnrolleeDepartmentClass);
            // 
            // BranchBindingSource
            // 
            this.BranchBindingSource.DataSource = typeof(GenDataLayer.Branch);
            // 
            // SemSyEntityBindingSource
            // 
            this.SemSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // PrintStudentClassBindingSource
            // 
            this.PrintStudentClassBindingSource.DataSource = typeof(GenDataLayer.repo.reportingentities.PrintStudentClass);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 40);
            this.panel1.TabIndex = 0;
            // 
            // jTabWizard1
            // 
            this.jTabWizard1.Controls.Add(this.tabPage1);
            this.jTabWizard1.Controls.Add(this.tabPage2);
            this.jTabWizard1.Controls.Add(this.tabPage3);
            this.jTabWizard1.Controls.Add(this.tabPage4);
            this.jTabWizard1.Controls.Add(this.tabPage5);
            this.jTabWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jTabWizard1.Location = new System.Drawing.Point(0, 40);
            this.jTabWizard1.Name = "jTabWizard1";
            this.jTabWizard1.SelectedIndex = 0;
            this.jTabWizard1.Size = new System.Drawing.Size(921, 418);
            this.jTabWizard1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(913, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ByCollege";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer5
            // 
            this.reportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ByCourse";
            reportDataSource1.Value = this.PrintEnrolleeDepartmentClassBindingSource;
            reportDataSource2.Name = "Set1";
            reportDataSource2.Value = this.BranchBindingSource;
            reportDataSource3.Name = "Set2";
            reportDataSource3.Value = this.SemSyEntityBindingSource;
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer5.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer5.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.SummaryByD" +
    "epartmentReport.rdlc";
            this.reportViewer5.Location = new System.Drawing.Point(3, 3);
            this.reportViewer5.Name = "reportViewer5";
            this.reportViewer5.Size = new System.Drawing.Size(907, 386);
            this.reportViewer5.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ByDepartment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "ByCourse";
            reportDataSource4.Value = this.PrintEnrolleeDepartmentClassBindingSource;
            reportDataSource5.Name = "Set1";
            reportDataSource5.Value = this.BranchBindingSource;
            reportDataSource6.Name = "Set2";
            reportDataSource6.Value = this.SemSyEntityBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.SummaryByC" +
    "ourseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(845, 283);
            this.reportViewer1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(851, 289);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ByCourse";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "ByCrsYrSec";
            reportDataSource7.Value = this.PrintEnrolleeDepartmentClassBindingSource;
            reportDataSource8.Name = "Set1";
            reportDataSource8.Value = this.BranchBindingSource;
            reportDataSource9.Name = "Set2";
            reportDataSource9.Value = this.SemSyEntityBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.SummaryByC" +
    "rsYrSecReport.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(851, 289);
            this.reportViewer3.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.reportViewer4);
            this.tabPage4.Controls.Add(this.reportViewer2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(851, 289);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ByCrsYrSec";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource10.Name = "StudentClass";
            reportDataSource10.Value = this.PrintStudentClassBindingSource;
            reportDataSource11.Name = "Set1";
            reportDataSource11.Value = this.BranchBindingSource;
            reportDataSource12.Name = "Set2";
            reportDataSource12.Value = this.SemSyEntityBindingSource;
            reportDataSource13.Name = "ByCourse";
            reportDataSource13.Value = this.PrintEnrolleeDepartmentClassBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource11);
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource12);
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource13);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.SummaryByS" +
    "tudentCrsYrSecReport.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(0, 0);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(851, 289);
            this.reportViewer4.TabIndex = 1;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource14.Name = "ByCrsYrSec";
            reportDataSource14.Value = this.PrintEnrolleeDepartmentClassBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource14);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.SummaryByC" +
    "rsYrSecReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(851, 289);
            this.reportViewer2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(851, 289);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ByStudent";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ReportSummaryByCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 458);
            this.Controls.Add(this.jTabWizard1);
            this.Controls.Add(this.panel1);
            this.Name = "ReportSummaryByCourseForm";
            this.Text = "Report Summary Enrollment Form";
            this.Load += new System.EventHandler(this.ReportSummaryByCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrintEnrolleeDepartmentClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintStudentClassBindingSource)).EndInit();
            this.jTabWizard1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PrintEnrolleeDepartmentClassBindingSource;
        private System.Windows.Forms.BindingSource PrintStudentClassBindingSource;
        private System.Windows.Forms.BindingSource BranchBindingSource;
        private System.Windows.Forms.BindingSource SemSyEntityBindingSource;
        private System.Windows.Forms.Panel panel1;
        private UtilityManager.ui.JTabWizard jTabWizard1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer5;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.TabPage tabPage4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.TabPage tabPage5;

    }
}