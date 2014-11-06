using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.reportingentities;
using Microsoft.Reporting.WinForms;

namespace Module_1___School_Management_Central_Administration.forms.rpt
{
    public partial class ReportSummaryByCourseForm : Form
    {
        public Branch Branch { get; set; }
        public SemSyEntity SemSyEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        public List<PrintEnrolleeDepartmentClass> DepartmentClassesCourse { get; set; }
        public List<PrintStudentClass> PrintStudentClassesCrsYrSec { get; set; }

        public enum menu
        {
            College,
            Department,
            Course,
            CrsYrSec,
            Student
        };

        public menu myMenu;

        public ReportSummaryByCourseForm()
        {
            InitializeComponent();
        }

        private void ReportSummaryByCourseForm_Load(object sender, EventArgs e)
        {
            BranchBindingSource.DataSource = Branch;
            SemSyEntityBindingSource.DataSource = SemSyEntity;
        }

        public void PrintData()
        {
            switch (myMenu)
            {
                case menu.College:
                    jTabWizard1.SelectTab(tabPage1);
                    PrintEnrolleeDepartmentClassBindingSource.DataSource = DepartmentClassesCourse;
                    this.reportViewer5.RefreshReport();
                    reportViewer5.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer5.ZoomMode = ZoomMode.Percent;
                    reportViewer5.ZoomPercent = 100;
                    break;
                case menu.Department:
                    jTabWizard1.SelectTab(tabPage2);
                    PrintEnrolleeDepartmentClassBindingSource.DataSource = DepartmentClassesCourse;
                    this.reportViewer1.RefreshReport();
                    reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                    break;
                case menu.CrsYrSec:
                    jTabWizard1.SelectTab(tabPage4);
                    PrintStudentClassBindingSource.DataSource = PrintStudentClassesCrsYrSec;
                    PrintEnrolleeDepartmentClassBindingSource.DataSource = DepartmentClassesCourse;
                    this.reportViewer4.RefreshReport();
                    reportViewer4.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer4.ZoomMode = ZoomMode.Percent;
                    reportViewer4.ZoomPercent = 100;
                    break;
                case menu.Course:
                    jTabWizard1.SelectTab(tabPage3);
                    PrintEnrolleeDepartmentClassBindingSource.DataSource = DepartmentClassesCourse;
                    this.reportViewer3.RefreshReport();
                    reportViewer3.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer3.ZoomMode = ZoomMode.Percent;
                    reportViewer3.ZoomPercent = 100;
                    break;
                case menu.Student:
                    jTabWizard1.SelectTab(tabPage5);
                    PrintEnrolleeDepartmentClassBindingSource.DataSource = DepartmentClassesCourse;
                    PrintStudentClassBindingSource.DataSource = PrintStudentClassesCrsYrSec;
                    this.reportViewer4.RefreshReport();
                    reportViewer4.SetDisplayMode(DisplayMode.PrintLayout);
                    reportViewer4.ZoomMode = ZoomMode.Percent;
                    reportViewer4.ZoomPercent = 100;
                    break;
                default:
                    break;
            }
            
        }
    }
}
