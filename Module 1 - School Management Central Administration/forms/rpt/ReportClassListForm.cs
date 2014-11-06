using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    public partial class ReportClassListForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public SchedulingEntity SchedulingEntity { get; set; }
        public PrintStudentClass PrintStudentClass { get; set; }

        public ReportClassListForm()
        {
            InitializeComponent();
        }

        private void ReportClassListForm_Load(object sender, EventArgs e)
        {
            BranchBindingSource.DataSource = Branch;
            SemSyEntityBindingSource.DataSource = SemSyEntity;
            SchedulingEntityBindingSource.DataSource = SchedulingEntity;
            PrintStudentClassBindingSource.DataSource = PrintStudentClass;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }
    }
}
