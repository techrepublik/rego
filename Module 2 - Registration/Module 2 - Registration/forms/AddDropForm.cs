using GenDataLayer.repo.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GenDataLayer.repo.managers.man;

namespace Module_2___Registration.forms
{
    public partial class AddDropForm : Form
    {
        private double _totalLecture = 0;
        private double _totalLaboratory = 0;
        private double _totalCredit = 0;
        private double _totalLecture1 = 0;
        private double _totalLaboratory1 = 0;
        private double _totalCredit1 = 0;

        public List<RegisteredSubjectEntity> RegistrationEntities { get; set; }

        private bool _editCell;
        private RegistrationForm _registrationForm;
        public AddDropForm(RegistrationForm form)
        {
            _registrationForm = form;
            InitializeComponent();
        }

        private void AddDropForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (RegistrationEntities != null)
            {
                dataGridView1.Rows.Clear();
                foreach (var item  in RegistrationEntities)
                {
                    dataGridView1.Rows.Add(true, item.ScheduleCode, item.SubjectCode, item.SubjectName, item.Units,
                                           item.ScheduleDetail, item.ScheduleId, item.RegisteredId, item.Added,
                                           item.Dropped, item.Regular);
                }
            }
            ComputerTotalUnits();
            Cursor.Current = Cursors.Default;
        }

        private void ComputerTotalUnits()
        {
            Cursor.Current = Cursors.WaitCursor;
            _totalLecture = 0;
            _totalLaboratory = 0;
            _totalCredit = 0;
            _totalLecture1 = 0;
            _totalLaboratory1 = 0;
            _totalCredit1 = 0;

            foreach (var item in PopulateRegisteredSubjectList())
            {
                if ((item.Dropped == false) || (item.Dropped == null))
                {
                    _totalLecture += Convert.ToDouble(item.Lecture);
                    _totalLaboratory += Convert.ToDouble(item.Laboratory);
                    if (item.Credit > 0)
                        _totalCredit += Convert.ToDouble(item.Credit);
                }
                else
                {
                    _totalLecture1 += Convert.ToDouble(item.Lecture);
                    _totalLaboratory1 += Convert.ToDouble(item.Laboratory);
                    if (item.Credit > 0)
                        _totalCredit1 += Convert.ToDouble(item.Credit);
                }
            }
            labelTotalUnits.Text = String.Format(@"{0} ( {1} )", _totalCredit, _totalCredit1);
            Cursor.Current = Cursors.Default;
        }

        private bool CheckDuplicateSubjects(int iScheduleId)
        {
            var bResult = false;
            var iCounter = 0;
            iCounter += dataGridView1.Rows.Cast<DataGridViewRow>().Count(row1 => Convert.ToInt32(row1.Cells[6].Value) == iScheduleId);

            if (iCounter > 0)
                bResult = true;

            return bResult;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (_editCell)
                {
                    var subjectSchedule = ScheduleManager.GetScheduleDetailByCode(e.FormattedValue.ToString());
                    if (subjectSchedule != null)
                    {
                        if (!CheckDuplicateSubjects(subjectSchedule.ScheduleId))
                        {
                            if ((dataGridView1.CurrentRow != null) && ((dataGridView1.CurrentRow.Cells[1].Value != null) || (Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) > 0)))
                            {
                                dataGridView1.CurrentRow.Cells[0].Value = true;
                                dataGridView1.CurrentRow.Cells[2].Value = subjectSchedule.SubjectCode;
                                dataGridView1.CurrentRow.Cells[3].Value = subjectSchedule.SubjectName;
                                dataGridView1.CurrentRow.Cells[4].Value = subjectSchedule.Units;
                                dataGridView1.CurrentRow.Cells[5].Value = subjectSchedule.ScheduleDetail;
                                dataGridView1.CurrentRow.Cells[6].Value = subjectSchedule.ScheduleId;
                                dataGridView1.CurrentRow.Cells[7].Value = 0;
                                dataGridView1.CurrentRow.Cells[8].Value = true;
                                dataGridView1.CurrentRow.Cells[9].Value = false;
                                dataGridView1.CurrentRow.Cells[10].Value = false;
                                //_listSchedules.Add(subjectSchedule);
                            }
                        }
                        else
                        {
                            var subjectLabel = String.Format(@"{0} - {1} {2} ( {3} ) is already in the list of subject(s).",
                                                             subjectSchedule.ScheduleId, subjectSchedule.SubjectCode,
                                                             subjectSchedule.SubjectName, subjectSchedule.Units);
                            UtilityManager.util.UtilClass.ShowCutsomMessageBox(subjectLabel);
                            dataGridView1.Focus();
                        }
                    }
                    _editCell = false;
                }
                //ComputeTotalUnits();
            }
            ComputerTotalUnits();
        }

        private List<RegisteredSubjectEntity> PopulateRegisteredSubjectList()
        {
            Cursor.Current = Cursors.WaitCursor;
            var tempList = new List<RegisteredSubjectEntity>();
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((Convert.ToInt32(row.Cells[6].Value) > 0) || (row.Cells[6].Value != null))
                    {
                        var r = new RegisteredSubjectEntity();
                        r.ScheduleCode = row.Cells[1].Value.ToString();
                        r.SubjectCode = row.Cells[2].Value.ToString();
                        r.SubjectName = row.Cells[3].Value.ToString();
                        var s = RegistrationEntities.SingleOrDefault(f => f.ScheduleId == Convert.ToInt32(row.Cells[6].Value));
                        if (s != null)
                        {
                            r.Lecture = s.Lecture;
                            r.Laboratory = s.Laboratory;
                            r.Credit = s.Credit;
                        }
                        else
                        {
                            var s1 = ScheduleManager.GetScheduleDetailByCode(r.ScheduleCode);
                            if (s1 != null)
                            {
                                r.Lecture = s1.Lecture;
                                r.Laboratory = s1.Laboratory;
                                r.Credit = s1.Credit;
                            }
                        }
                        r.ScheduleDetail = row.Cells[5].Value.ToString();
                        r.ScheduleId = Convert.ToInt32(row.Cells[6].Value);
                        r.RegisteredId = Convert.ToInt32(row.Cells[7].Value);
                        r.Added = Convert.ToBoolean(row.Cells[8].Value);
                        r.Dropped = Convert.ToBoolean(row.Cells[9].Value);
                        r.Regular = Convert.ToBoolean(row.Cells[10].Value);
                        tempList.Add(r);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return tempList;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _editCell = e.ColumnIndex == 1;
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (RegistrationEntities != null)
                _registrationForm._listRegisteredSubject = PopulateRegisteredSubjectList();
        }

        private void RemoveEmptyRow()
        {
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                if ((selectedRow.Cells[7].Value == null) || (Convert.ToInt32(selectedRow.Cells[7].Value) == 0))
                    dataGridView1.Rows.Remove(selectedRow);
            }
        }

        private void buttonRemoveRow_Click(object sender, EventArgs e)
        {
            RemoveEmptyRow();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if ((e.ColumnIndex == 9) || (e.ColumnIndex == 1))
            //{
            
            //}
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Validate();
            //try
            //{
            //    ComputerTotalUnits();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
