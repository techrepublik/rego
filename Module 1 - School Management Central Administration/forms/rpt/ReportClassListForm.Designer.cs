namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    partial class ReportClassListForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SemSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SchedulingEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintStudentClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulingEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintStudentClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "Set1";
            reportDataSource5.Value = this.SemSyEntityBindingSource;
            reportDataSource6.Name = "Set2";
            reportDataSource6.Value = this.BranchBindingSource;
            reportDataSource7.Name = "Set3";
            reportDataSource7.Value = this.SchedulingEntityBindingSource;
            reportDataSource8.Name = "Set4";
            reportDataSource8.Value = this.PrintStudentClassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.enrollment.ClassListR" +
    "eport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(745, 489);
            this.reportViewer1.TabIndex = 0;
            // 
            // SemSyEntityBindingSource
            // 
            this.SemSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // BranchBindingSource
            // 
            this.BranchBindingSource.DataSource = typeof(GenDataLayer.Branch);
            // 
            // SchedulingEntityBindingSource
            // 
            this.SchedulingEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SchedulingEntity);
            // 
            // PrintStudentClassBindingSource
            // 
            this.PrintStudentClassBindingSource.DataSource = typeof(GenDataLayer.repo.reportingentities.PrintStudentClass);
            // 
            // ReportClassListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 489);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportClassListForm";
            this.Text = "Student / Class List";
            this.Load += new System.EventHandler(this.ReportClassListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulingEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintStudentClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SemSyEntityBindingSource;
        private System.Windows.Forms.BindingSource BranchBindingSource;
        private System.Windows.Forms.BindingSource SchedulingEntityBindingSource;
        private System.Windows.Forms.BindingSource PrintStudentClassBindingSource;
    }
}