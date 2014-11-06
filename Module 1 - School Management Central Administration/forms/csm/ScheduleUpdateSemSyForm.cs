using System;
using System.Windows.Forms;
using GenDataLayer.repo.entities;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class ScheduleUpdateSemSyForm : Form
    {
        public CourseSecScheduleEntity _CourseSecSchedule { get; set; }

        public ScheduleUpdateSemSyForm()
        {
            InitializeComponent();
        }

        private void ScheduleUpdateSemSyForm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (_CourseSecSchedule != null)
                GetCourseSecSchedule();
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            semSyEntityBindingSource.DataSource = ObjectQueries.GetSemSyEntities();
            coursBindingSource.DataSource = LoadQueries.GetCourses();
            yearLevelBindingSource.DataSource = LoadQueries.GetYearLevels();
            sectionBindingSource.DataSource = LoadQueries.GetSections();
            Cursor.Current = Cursors.Default;
        }

        private void GetCourseSecSchedule()
        {
            courseSecScheduleBindingSource.DataSource = GetCoureSecSchedule();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            courseSecScheduleBindingNavigatorSaveItem.Enabled = true;
            courseSecScheduleBindingSource.AddNew();
            semSyIdComboBox.Focus();
        }

        private void courseSecScheduleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            courseSecScheduleBindingSource.EndEdit();
            var c = new CourseSecSchedule
            {
                SemSyId = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).SemSyId,
                YearLevelId = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).YearLevelId,
                SectionId = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).SectionId,
                CourseId = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).CourseId,
                CourseSecScheduleId =
                    ((CourseSecSchedule)courseSecScheduleBindingSource.Current).CourseSecScheduleId,
                Note = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).Note,
                IsActive = ((CourseSecSchedule)courseSecScheduleBindingSource.Current).IsActive
                //IsActive = ((CourseSecScheduleEntity) courseSecScheduleBindingSource.Current).IsActive
            };
            int iResult = Save.CourseSecSchedules(c);
            UtilClass.ShowSaveMessageBox(iResult);
        }

        private CourseSecSchedule GetCoureSecSchedule()
        {
            var c1 = new CourseSecSchedule();
            if (_CourseSecSchedule != null)
            {
                var c = new CourseSecSchedule
                    {
                        SemSyId = _CourseSecSchedule.SemSyId,
                        YearLevelId = _CourseSecSchedule.YearLevelId,
                        SectionId = _CourseSecSchedule.SectionId,
                        CourseId = _CourseSecSchedule.CourseId,
                        CourseSecScheduleId = _CourseSecSchedule.CourseSecScheduleEntityId,
                        Note = _CourseSecSchedule.Note,
                        IsActive = _CourseSecSchedule.IsActive
                    };
                c1 = c;
            }
            return c1;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (courseSecScheduleBindingSource.Current != null)
            {
                if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                {
                    bool bResult =
                        Remove.CourseSecSchedules(
                            ((CourseSecSchedule) courseSecScheduleBindingSource.Current).CourseSecScheduleId);
                    UtilClass.ShowDeleteMessageBox(bResult);
                    if (bResult)
                    {
                        courseSecScheduleBindingSource.RemoveCurrent();
                        this.Close();
                    }
                }
            }
        }

        private void courseSecScheduleBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (courseSecScheduleBindingSource.Current != null)
                courseSecScheduleBindingNavigatorSaveItem.Enabled = true;
        }
    }
}
