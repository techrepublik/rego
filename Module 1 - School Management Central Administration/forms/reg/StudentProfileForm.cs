using System;
using System.Windows.Forms;
using GenDataLayer.repo.managers;
using GenDataLayer;
using UtilityManager.util;
using GenDataLayer.repo.managers.man;

namespace Module_1___School_Management_Central_Administration.forms.reg
{
    public partial class StudentProfileForm : Form
    {
        public Student Student { get; set; }

        public StudentProfileForm()
        {
            InitializeComponent();
        }

        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (studentBindingSource.Current != null)
            {
                toolStripButtonSave.Enabled = true;
                PopulateLabels();
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            idNoTextBox.Focus();
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxItems(); // static items

            LoadProvinces(); //dynamic items
            LoadProvinces1();

            if (Student != null)
            {
                studentBindingSource.DataSource = Student;
                GetSchoolEducation(Student.StudentId);
                GetRequirements(Student.StudentId);
                GetStudentPicture();
            }
        }

        private void GetSchoolEducation(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            schoolEducationBindingSource.DataSource = StudentEducationManager.GetAllSchoolEducationByStudent(iStudentId);
            Cursor.Current = Cursors.Default;
        }

        private void GetRequirements(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            studentRequirementBindingSource.DataSource =
                StudentRequirementManager.GetAllStudentRequirementsByStudent(iStudentId);
            Cursor.Current = Cursors.Default;
        }

        private void LoadComboBoxItems()
        {
            citizenshipComboBox.Items.Add(@"Filipino");
            citizenshipComboBox.Items.Add(@"Others");
            citizenshipComboBox.SelectedIndex = 0;

            civilStatusComboBox.Items.Add(@"Single");
            civilStatusComboBox.Items.Add(@"Married");
            civilStatusComboBox.Items.Add(@"Widow");
            civilStatusComboBox.Items.Add(@"Widower");
            civilStatusComboBox.Items.Add(@"Divorce");
            civilStatusComboBox.SelectedIndex = 0;

            LoadPreferences(); //load alliedSchools, educationalLevel, and requirements
        }

        #region Address
        private void LoadProvinces()
        {
            Cursor.Current = Cursors.WaitCursor;
            var listProvinces = LoadQueries.GetProvinces();
            var province = new Province
                {
                    ProvinceName = @"--- Select Province ---"
                };
            listProvinces.Insert(0, province);
            provinceBindingSource.DataSource = LoadQueries.GetProvinces();
            if (provinceBindingSource.Count > 0)
                provinceIdComboBox.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;
        }

        private void LoadMunCities(Province province)
        {
            Cursor.Current = Cursors.WaitCursor;
            munCityBindingSource.DataSource = LoadQueries.GetMunCitiesByProvince(province);
            Cursor.Current = Cursors.Default;
        }

        private void LoadBarangay(MunCity munCity)
        {
            Cursor.Current = Cursors.WaitCursor;
            barangayBindingSource.DataSource = LoadQueries.GetBarangaysByCity(munCity);
            Cursor.Current = Cursors.Default;
        }

        private void LoadStreet(Barangay barangay)
        {
            Cursor.Current = Cursors.WaitCursor;
            streetHousBindingSource.DataSource = LoadQueries.GetStreetHousesByBarangay(barangay);
            Cursor.Current = Cursors.Default;
        }


        private void LoadProvinces1()
        {
            Cursor.Current = Cursors.WaitCursor;
            provinceBindingSource1.DataSource = LoadQueries.GetProvinces();
            if (provinceBindingSource.Count > 0)
                provinceIdComboBox.SelectedIndex = 0;
            Cursor.Current = Cursors.Default;
        }

        private void LoadMunCities1(Province province)
        {
            Cursor.Current = Cursors.WaitCursor;
            munCityBindingSource1.DataSource = LoadQueries.GetMunCitiesByProvince(province);
            Cursor.Current = Cursors.Default;
        }

        private void LoadBarangay1(MunCity munCity)
        {
            Cursor.Current = Cursors.WaitCursor;
            barangayBindingSource1.DataSource = LoadQueries.GetBarangaysByCity(munCity);
            Cursor.Current = Cursors.Default;
        }

        private void LoadStreet1(Barangay barangay)
        {
            Cursor.Current = Cursors.WaitCursor;
            streetHousBindingSource1.DataSource = LoadQueries.GetStreetHousesByBarangay(barangay);
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void provinceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (provinceBindingSource.Current != null)
            {
                LoadMunCities((Province) provinceBindingSource.Current);
            }
            else
            {
                provinceBindingSource.DataSource = null;
            }
        }

        private void munCityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (munCityBindingSource.Current != null)
            {
                LoadBarangay((MunCity) munCityBindingSource.Current);
            }
            else
            {
                munCityBindingSource.DataSource = null;
            }
        }

        private void barangayBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (barangayBindingSource.Current != null)
            {
                LoadStreet((Barangay)barangayBindingSource.Current);
            }
            else
            {
                streetHousBindingSource.DataSource = null;
            }
                
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (studentBindingSource.Current != null)
            {
                var student = Validation.CheckStudentDuplicateIdNo(idNoTextBox.Text);
                if (student != null)
                {
                    var fullName = String.Format(@"{0} - {1}, {2} {3}", student.IdNo, student.LastName,
                                                 student.FirstName, student.MiddleName);
                    var dResult = MessageBox.Show(
                        String.Format(@"This ID No is assigned to {0}. Would you like to continue?", fullName.ToUpper()), @"Duplicate Exist.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dResult == DialogResult.Yes)
                    {
                        errorProvider1.SetError(idNoTextBox, @"");

                        //save student record
                        Validate();
                        studentBindingSource.EndEdit();
                        var iResult = Save.Student((Student)studentBindingSource.Current);
                        UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                    }
                    else
                    {
                        errorProvider1.SetError(idNoTextBox, @"Duplicate Id No exist.");
                        idNoTextBox.Focus();
                    }
                }
                else
                {
                     //save student record
                     Validate();
                     studentBindingSource.EndEdit();
                     var iResult = Save.Student((Student)studentBindingSource.Current);
                     UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void idNoTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((idNoTextBox.Text.Length > 0) && (idNoTextBox.Text != string.Empty))
            {
               errorProvider1.SetError(idNoTextBox, @"");
            }
            else
            {
                errorProvider1.SetError(idNoTextBox, @"ID No should not be empty.");
                idNoTextBox.Focus();
            }
        }

        private void firstNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((firstNameTextBox.Text.Length > 0) && (firstNameTextBox.Text != string.Empty))
            {
                errorProvider1.SetError(firstNameTextBox, @"");
            }
            else
            {
                errorProvider1.SetError(firstNameTextBox, @"First Name should not be empty.");
                firstNameTextBox.Focus();
            }
        }

        private void middleNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((middleNameTextBox.Text.Length > 0) && (middleNameTextBox.Text != string.Empty))
            {
                errorProvider1.SetError(middleNameTextBox, @"");
            }
            else
            {
                errorProvider1.SetError(middleNameTextBox, @"Middle Name should not be empty.");
                middleNameTextBox.Focus();
            }
        }

        private void lastNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((lastNameTextBox.Text.Length > 0) && (lastNameTextBox.Text != string.Empty))
            {
                errorProvider1.SetError(middleNameTextBox, @"");
            }
            else
            {
                errorProvider1.SetError(middleNameTextBox, @"Middle Name should not be empty.");
                lastNameTextBox.Focus();
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = @"Jpeg (*.jpg)|*.jpg|Jpeg (*.jpeg)|*.jpeg|Png (*.png) |*.png|Gif (*.gif) | *.gif";
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = openDialog.FileName;
                var tempBuffer = ImageClass.ReadFile(openDialog.FileName);
                pictureBox1.Image = ImageClass.ByteToImage(tempBuffer);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void provinceBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (provinceBindingSource1.Current != null)
            {
                LoadMunCities1((Province)provinceBindingSource1.Current);
                munCityId1ComboBox.Focus();
            }
            else
            {
                provinceBindingSource1.DataSource = null;
            }
        }

        private void munCityBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (munCityBindingSource1.Current != null)
            {
                LoadBarangay1((MunCity)munCityBindingSource1.Current);
            }
            else
            {
                munCityBindingSource1.DataSource = null;
            }
        }

        private void barangayBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (barangayBindingSource1.Current != null)
            {
                LoadStreet1((Barangay)barangayBindingSource1.Current);
            }
            else
            {
                streetHousBindingSource1.DataSource = null;
            }
        }

        private void checkBoxHomeAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHomeAddress.Checked)
            {
                provinceBindingSource1.Position = provinceBindingSource.Position;
                munCityBindingSource1.Position = munCityBindingSource.Position;
                barangayBindingSource1.Position = barangayBindingSource.Position;
                streetHousBindingSource1.Position = streetHousBindingSource.Position;
            }
            else
            {
                provinceBindingSource1.Position = 0;
            }
        }

        private void provinceBindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (provinceBindingSource1.Current != null)
            {
                LoadMunCities1((Province)provinceBindingSource1.Current);
            }
            else
            {
                provinceBindingSource1.DataSource = null;
            }
        }

        private void schoolEducationDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (schoolEducationDataGridView.Rows.Count > 0)
            {
                if (schoolEducationBindingSource.Current != null)
                {
                    if (schoolEducationDataGridView.IsCurrentRowDirty)
                    {
                        var student = ((Student) studentBindingSource.Current);
                        Validate();
                        ((SchoolEducation) schoolEducationBindingSource.Current).StudentId = student.StudentId;
                        schoolEducationBindingSource.EndEdit();
                        var iResult =
                            StudentEducationManager.Save((SchoolEducation) schoolEducationBindingSource.Current);
                        if (iResult > 0)
                        {
                            GetAllSchoolEducation(student.StudentId);
                            toolStripStatusLabel1.Text = @"Record Saved.";
                        }
                        else
                        {
                            UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);       
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void GetAllSchoolEducation(int iStudentId)
        {
            Cursor.Current = Cursors.WaitCursor;
            schoolEducationBindingSource.DataSource = StudentEducationManager.GetAllSchoolEducationByStudent(iStudentId);
            Cursor.Current = Cursors.Default;
        }

        private void LoadPreferences()
        {
            Cursor.Current = Cursors.WaitCursor;
            alliedSchoolBindingSource.DataSource = AlliedSchoolsManager.GetAllAlliedShools();
            educationLevelBindingSource.DataSource = EducationLevelManager.GetAllEducationLevels();
            requirementBindingSource.DataSource = RequirementManager.GetAllRequirements();
            Cursor.Current = Cursors.Default;
        }

        private void studentRequirementDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (studentRequirementDataGridView.Rows.Count > 0)
            {
                if (studentRequirementBindingSource.Current != null)
                {
                    if (studentRequirementDataGridView.IsCurrentRowDirty)
                    {
                        var student = ((Student) studentBindingSource.Current);
                        if (student != null)
                        {
                            Validate();
                            ((StudentRequirement) studentRequirementBindingSource.Current).StudentId = student.StudentId;
                            studentRequirementBindingSource.EndEdit();
                            var iResult = StudentRequirementManager.Save((StudentRequirement) studentRequirementBindingSource.Current);
                            if (iResult > 0)
                            {
                                studentRequirementBindingSource.DataSource =
                                    StudentRequirementManager.GetAllStudentRequirementsByStudent(student.StudentId);
                                toolStripStatusLabel1.Text = @"Record Saved.";
                            }
                            else
                            {
                                UtilityManager.util.UtilClass.ShowSaveMessageBox(iResult);
                            }
                        }

                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    toolStripStatusLabel3.Text = @"Student Profile.";
                    toolStripStatusLabel1.Text = @"Ready...";
                    bindingNavigator1.BindingSource = studentBindingSource;
                    break;
                case 1:
                    toolStripStatusLabel3.Text = @"Student Education.";
                    toolStripStatusLabel1.Text = @"Ready...";
                    bindingNavigator1.BindingSource = schoolEducationBindingSource;
                    break;
                case 2:
                    toolStripStatusLabel3.Text = @"Requirement Checklist.";
                    toolStripStatusLabel1.Text = @"Ready...";
                    bindingNavigator1.BindingSource = studentRequirementBindingSource;
                    break;
                default: break;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                DeleteEducation();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                DeleteRequirement();
            }
        }

        private void DeleteEducation()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (schoolEducationDataGridView.Rows.Count > 0)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in schoolEducationDataGridView.Rows)
                        {
                            var s = (SchoolEducation)row.DataBoundItem;
                            if (StudentEducationManager.Delete(s))
                            {
                                schoolEducationDataGridView.Rows.Remove(row);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void DeleteRequirement()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (studentRequirementDataGridView.Rows.Count > 0)
            {
                var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in studentRequirementDataGridView.Rows)
                        {
                            var s = (StudentRequirement)row.DataBoundItem;
                            if (StudentRequirementManager.Delete(s))
                            {
                                studentRequirementDataGridView.Rows.Remove(row);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void PopulateLabels()
        {
            if (studentBindingSource.Current != null)
            {
                var s = (Student) studentBindingSource.Current;
                if (s != null)
                {
                    try
                    {
                        labelIdNo.Text = s.IdNo;
                        labelLastName.Text = s.LastName.ToUpper();
                        labelFirstName.Text = s.FirstName.ToUpper();
                        labelMiddleName.Text = s.MiddleName.ToUpper();
                        labelGender.Text = s.Gender;
                        labelBirthDate.Text = String.Format(@"{0:#,##0.00}", s.BirthDate);

                        labelIDNo1.Text = s.IdNo;
                        labelLastName1.Text = s.LastName.ToUpper();
                        labelFirstName1.Text = s.FirstName.ToUpper();
                        labelMiddleName1.Text = s.MiddleName.ToUpper();
                        labelGender1.Text = s.Gender;
                        labelBirthDate1.Text = String.Format(@"{0:#,##0.00}", s.BirthDate);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void GetStudentPicture()
        {
            if (Student != null)
            {
                var s = ObjectQueries.GetStudentPicture(Student.StudentId);
                if (s != null)
                {
                    if (Convert.ToBoolean(s.IsActive))
                    {
                        pictureBox1.Image = UtilityManager.util.ImageClass.ByteToImage(s.Picture);
                    }
                }
            }
        }
    }
}
