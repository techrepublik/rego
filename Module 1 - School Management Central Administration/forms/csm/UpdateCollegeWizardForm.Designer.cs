
namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class UpdateCollegeWizardForm
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
            System.Windows.Forms.Label collegeNameLabel;
            System.Windows.Forms.Label collegeDescriptionLabel;
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new UtilityManager.ui.JTabWizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.labelCollege = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.collegeDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.departmentDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.abbreviationTextBox = new System.Windows.Forms.TextBox();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.courseNameComboBox = new System.Windows.Forms.ComboBox();
            this.departmentNameComboBox = new System.Windows.Forms.ComboBox();
            this.collegeNameComboBox = new System.Windows.Forms.ComboBox();
            this.collegeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            collegeNameLabel = new System.Windows.Forms.Label();
            collegeDescriptionLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 220);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(98, 220);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(98, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 220);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "College";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Course";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonFinish);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 29);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 191);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.collegeDescriptionTextBox);
            this.tabPage1.Controls.Add(this.collegeNameComboBox);
            this.tabPage1.Controls.Add(collegeDescriptionLabel);
            this.tabPage1.Controls.Add(collegeNameLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 165);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "College";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.departmentDescriptionTextBox);
            this.tabPage2.Controls.Add(this.departmentNameComboBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelCollege);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(461, 165);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Department";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.durationTextBox);
            this.tabPage3.Controls.Add(this.abbreviationTextBox);
            this.tabPage3.Controls.Add(this.courseNameComboBox);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(461, 165);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Course";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(207, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "&Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(283, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "&Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(390, 3);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinish.TabIndex = 2;
            this.buttonFinish.Text = "&Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            // 
            // collegeNameLabel
            // 
            collegeNameLabel.AutoSize = true;
            collegeNameLabel.Location = new System.Drawing.Point(6, 14);
            collegeNameLabel.Name = "collegeNameLabel";
            collegeNameLabel.Size = new System.Drawing.Size(76, 13);
            collegeNameLabel.TabIndex = 0;
            collegeNameLabel.Text = "College Name:";
            // 
            // collegeDescriptionLabel
            // 
            collegeDescriptionLabel.AutoSize = true;
            collegeDescriptionLabel.Location = new System.Drawing.Point(6, 37);
            collegeDescriptionLabel.Name = "collegeDescriptionLabel";
            collegeDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            collegeDescriptionLabel.TabIndex = 2;
            collegeDescriptionLabel.Text = "Description:";
            // 
            // labelCollege
            // 
            this.labelCollege.AutoSize = true;
            this.labelCollege.ForeColor = System.Drawing.Color.Red;
            this.labelCollege.Location = new System.Drawing.Point(7, 7);
            this.labelCollege.Name = "labelCollege";
            this.labelCollege.Size = new System.Drawing.Size(51, 13);
            this.labelCollege.TabIndex = 0;
            this.labelCollege.Text = "College...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Department Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Short Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Course Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(5, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Department...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Duration:";
            // 
            // collegeDescriptionTextBox
            // 
            this.collegeDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.collegeBindingSource, "CollegeDescription", true));
            this.collegeDescriptionTextBox.Location = new System.Drawing.Point(88, 39);
            this.collegeDescriptionTextBox.Multiline = true;
            this.collegeDescriptionTextBox.Name = "collegeDescriptionTextBox";
            this.collegeDescriptionTextBox.Size = new System.Drawing.Size(365, 123);
            this.collegeDescriptionTextBox.TabIndex = 4;
            // 
            // departmentDescriptionTextBox
            // 
            this.departmentDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource, "DepartmentDescription", true));
            this.departmentDescriptionTextBox.Location = new System.Drawing.Point(108, 49);
            this.departmentDescriptionTextBox.Multiline = true;
            this.departmentDescriptionTextBox.Name = "departmentDescriptionTextBox";
            this.departmentDescriptionTextBox.Size = new System.Drawing.Size(345, 110);
            this.departmentDescriptionTextBox.TabIndex = 5;
            // 
            // abbreviationTextBox
            // 
            this.abbreviationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "Abbreviation", true));
            this.abbreviationTextBox.Location = new System.Drawing.Point(78, 50);
            this.abbreviationTextBox.Name = "abbreviationTextBox";
            this.abbreviationTextBox.Size = new System.Drawing.Size(100, 20);
            this.abbreviationTextBox.TabIndex = 9;
            // 
            // durationTextBox
            // 
            this.durationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "Duration", true));
            this.durationTextBox.Location = new System.Drawing.Point(78, 75);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(100, 20);
            this.durationTextBox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "&New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // courseNameComboBox
            // 
            this.courseNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "CourseName", true));
            this.courseNameComboBox.FormattingEnabled = true;
            this.courseNameComboBox.Location = new System.Drawing.Point(78, 25);
            this.courseNameComboBox.Name = "courseNameComboBox";
            this.courseNameComboBox.Size = new System.Drawing.Size(375, 21);
            this.courseNameComboBox.TabIndex = 8;
            // 
            // departmentNameComboBox
            // 
            this.departmentNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource, "DepartmentName", true));
            this.departmentNameComboBox.FormattingEnabled = true;
            this.departmentNameComboBox.Location = new System.Drawing.Point(108, 26);
            this.departmentNameComboBox.Name = "departmentNameComboBox";
            this.departmentNameComboBox.Size = new System.Drawing.Size(345, 21);
            this.departmentNameComboBox.TabIndex = 4;
            // 
            // collegeNameComboBox
            // 
            this.collegeNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.collegeBindingSource, "CollegeName", true));
            this.collegeNameComboBox.FormattingEnabled = true;
            this.collegeNameComboBox.Location = new System.Drawing.Point(88, 14);
            this.collegeNameComboBox.Name = "collegeNameComboBox";
            this.collegeNameComboBox.Size = new System.Drawing.Size(365, 21);
            this.collegeNameComboBox.TabIndex = 3;
            // 
            // collegeBindingSource
            // 
            this.collegeBindingSource.DataSource = typeof(GenDataLayer.College);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(GenDataLayer.Department);
            // 
            // coursBindingSource
            // 
            this.coursBindingSource.DataSource = typeof(GenDataLayer.Cours);
            // 
            // UpdateCollegeWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 242);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "UpdateCollegeWizardForm";
            this.Text = "Update College Wizard Form";
            this.Load += new System.EventHandler(this.UpdateCollegeWizardForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UtilityManager.ui.JTabWizard tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.BindingSource collegeBindingSource;
        private System.Windows.Forms.Label labelCollege;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox collegeDescriptionTextBox;
        private System.Windows.Forms.TextBox departmentDescriptionTextBox;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.BindingSource coursBindingSource;
        private System.Windows.Forms.TextBox abbreviationTextBox;
        private System.Windows.Forms.ComboBox collegeNameComboBox;
        private System.Windows.Forms.ComboBox departmentNameComboBox;
        private System.Windows.Forms.ComboBox courseNameComboBox;
        private System.Windows.Forms.Button button1;
    }
}