using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;
using Microsoft.Reporting.WinForms;

namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    public partial class RepostListReceiptsForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public List<PrintReceiptClass> PrintReceiptClasses { get; set; }

        public RepostListReceiptsForm()
        {
            InitializeComponent();
        }

        private void RepostListReceiptsForm_Load(object sender, EventArgs e)
        {
            BranchBindingSource.DataSource = Branch;
            SemSyEntityBindingSource.DataSource = SemSyEntity;
            PrintReceiptClassBindingSource.DataSource = PrintReceiptClasses;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            this.BringToFront();
        }
    }
}
