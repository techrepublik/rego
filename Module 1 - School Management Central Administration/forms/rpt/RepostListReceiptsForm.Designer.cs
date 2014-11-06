namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    partial class RepostListReceiptsForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SemSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintReceiptClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintReceiptClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "Set1";
            reportDataSource4.Value = this.SemSyEntityBindingSource;
            reportDataSource5.Name = "Set2";
            reportDataSource5.Value = this.BranchBindingSource;
            reportDataSource6.Name = "Set3";
            reportDataSource6.Value = this.PrintReceiptClassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Module_1___School_Management_Central_Administration.reports.finance.ReportListRec" +
    "eipts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(664, 459);
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
            // PrintReceiptClassBindingSource
            // 
            this.PrintReceiptClassBindingSource.DataSource = typeof(GenDataLayer.repo.reportingentities.PrintReceiptClass);
            // 
            // RepostListReceiptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 459);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RepostListReceiptsForm";
            this.Text = "Report List Receipts";
            this.Load += new System.EventHandler(this.RepostListReceiptsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SemSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintReceiptClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SemSyEntityBindingSource;
        private System.Windows.Forms.BindingSource BranchBindingSource;
        private System.Windows.Forms.BindingSource PrintReceiptClassBindingSource;
    }
}