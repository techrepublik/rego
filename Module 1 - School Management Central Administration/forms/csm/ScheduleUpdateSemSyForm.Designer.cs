namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class ScheduleUpdateSemSyForm
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
            System.Windows.Forms.Label semSyIdLabel;
            System.Windows.Forms.Label courseIdLabel;
            System.Windows.Forms.Label yearLevelIdLabel;
            System.Windows.Forms.Label sectionIdLabel;
            System.Windows.Forms.Label isActiveLabel;
            System.Windows.Forms.Label noteLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleUpdateSemSyForm));
            this.courseSecScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseSecScheduleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.courseSecScheduleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.semSyIdComboBox = new System.Windows.Forms.ComboBox();
            this.semSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseIdComboBox = new System.Windows.Forms.ComboBox();
            this.coursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yearLevelIdComboBox = new System.Windows.Forms.ComboBox();
            this.yearLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectionIdComboBox = new System.Windows.Forms.ComboBox();
            this.sectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            semSyIdLabel = new System.Windows.Forms.Label();
            courseIdLabel = new System.Windows.Forms.Label();
            yearLevelIdLabel = new System.Windows.Forms.Label();
            sectionIdLabel = new System.Windows.Forms.Label();
            isActiveLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseSecScheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseSecScheduleBindingNavigator)).BeginInit();
            this.courseSecScheduleBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // semSyIdLabel
            // 
            semSyIdLabel.AutoSize = true;
            semSyIdLabel.Location = new System.Drawing.Point(12, 37);
            semSyIdLabel.Name = "semSyIdLabel";
            semSyIdLabel.Size = new System.Drawing.Size(48, 13);
            semSyIdLabel.TabIndex = 1;
            semSyIdLabel.Text = "Sem/Sy:";
            // 
            // courseIdLabel
            // 
            courseIdLabel.AutoSize = true;
            courseIdLabel.Location = new System.Drawing.Point(12, 62);
            courseIdLabel.Name = "courseIdLabel";
            courseIdLabel.Size = new System.Drawing.Size(43, 13);
            courseIdLabel.TabIndex = 3;
            courseIdLabel.Text = "Course:";
            // 
            // yearLevelIdLabel
            // 
            yearLevelIdLabel.AutoSize = true;
            yearLevelIdLabel.Location = new System.Drawing.Point(12, 86);
            yearLevelIdLabel.Name = "yearLevelIdLabel";
            yearLevelIdLabel.Size = new System.Drawing.Size(61, 13);
            yearLevelIdLabel.TabIndex = 5;
            yearLevelIdLabel.Text = "Year Level:";
            // 
            // sectionIdLabel
            // 
            sectionIdLabel.AutoSize = true;
            sectionIdLabel.Location = new System.Drawing.Point(12, 109);
            sectionIdLabel.Name = "sectionIdLabel";
            sectionIdLabel.Size = new System.Drawing.Size(46, 13);
            sectionIdLabel.TabIndex = 7;
            sectionIdLabel.Text = "Section:";
            // 
            // isActiveLabel
            // 
            isActiveLabel.AutoSize = true;
            isActiveLabel.Location = new System.Drawing.Point(12, 135);
            isActiveLabel.Name = "isActiveLabel";
            isActiveLabel.Size = new System.Drawing.Size(40, 13);
            isActiveLabel.TabIndex = 9;
            isActiveLabel.Text = "Active:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(12, 159);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(33, 13);
            noteLabel.TabIndex = 11;
            noteLabel.Text = "Note:";
            // 
            // courseSecScheduleBindingSource
            // 
            this.courseSecScheduleBindingSource.DataSource = typeof(GenDataLayer.CourseSecSchedule);
            this.courseSecScheduleBindingSource.CurrentChanged += new System.EventHandler(this.courseSecScheduleBindingSource_CurrentChanged);
            // 
            // courseSecScheduleBindingNavigator
            // 
            this.courseSecScheduleBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.courseSecScheduleBindingNavigator.BindingSource = this.courseSecScheduleBindingSource;
            this.courseSecScheduleBindingNavigator.CountItem = null;
            this.courseSecScheduleBindingNavigator.DeleteItem = null;
            this.courseSecScheduleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.courseSecScheduleBindingNavigatorSaveItem});
            this.courseSecScheduleBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.courseSecScheduleBindingNavigator.MoveFirstItem = null;
            this.courseSecScheduleBindingNavigator.MoveLastItem = null;
            this.courseSecScheduleBindingNavigator.MoveNextItem = null;
            this.courseSecScheduleBindingNavigator.MovePreviousItem = null;
            this.courseSecScheduleBindingNavigator.Name = "courseSecScheduleBindingNavigator";
            this.courseSecScheduleBindingNavigator.PositionItem = null;
            this.courseSecScheduleBindingNavigator.Size = new System.Drawing.Size(494, 25);
            this.courseSecScheduleBindingNavigator.TabIndex = 0;
            this.courseSecScheduleBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(74, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(60, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // courseSecScheduleBindingNavigatorSaveItem
            // 
            this.courseSecScheduleBindingNavigatorSaveItem.Enabled = false;
            this.courseSecScheduleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("courseSecScheduleBindingNavigatorSaveItem.Image")));
            this.courseSecScheduleBindingNavigatorSaveItem.Name = "courseSecScheduleBindingNavigatorSaveItem";
            this.courseSecScheduleBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.courseSecScheduleBindingNavigatorSaveItem.Text = "Save Data";
            this.courseSecScheduleBindingNavigatorSaveItem.Click += new System.EventHandler(this.courseSecScheduleBindingNavigatorSaveItem_Click);
            // 
            // semSyIdComboBox
            // 
            this.semSyIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.courseSecScheduleBindingSource, "SemSyId", true));
            this.semSyIdComboBox.DataSource = this.semSyEntityBindingSource;
            this.semSyIdComboBox.DisplayMember = "SemSyName";
            this.semSyIdComboBox.FormattingEnabled = true;
            this.semSyIdComboBox.Location = new System.Drawing.Point(77, 34);
            this.semSyIdComboBox.Name = "semSyIdComboBox";
            this.semSyIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.semSyIdComboBox.TabIndex = 3;
            this.semSyIdComboBox.ValueMember = "SemSyId";
            // 
            // semSyEntityBindingSource
            // 
            this.semSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // courseIdComboBox
            // 
            this.courseIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.courseSecScheduleBindingSource, "CourseId", true));
            this.courseIdComboBox.DataSource = this.coursBindingSource;
            this.courseIdComboBox.DisplayMember = "Abbreviation";
            this.courseIdComboBox.FormattingEnabled = true;
            this.courseIdComboBox.Location = new System.Drawing.Point(77, 59);
            this.courseIdComboBox.Name = "courseIdComboBox";
            this.courseIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.courseIdComboBox.TabIndex = 4;
            this.courseIdComboBox.ValueMember = "CourseId";
            // 
            // coursBindingSource
            // 
            this.coursBindingSource.DataSource = typeof(GenDataLayer.Cours);
            // 
            // yearLevelIdComboBox
            // 
            this.yearLevelIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.courseSecScheduleBindingSource, "YearLevelId", true));
            this.yearLevelIdComboBox.DataSource = this.yearLevelBindingSource;
            this.yearLevelIdComboBox.DisplayMember = "YearLevelName";
            this.yearLevelIdComboBox.FormattingEnabled = true;
            this.yearLevelIdComboBox.Location = new System.Drawing.Point(77, 83);
            this.yearLevelIdComboBox.Name = "yearLevelIdComboBox";
            this.yearLevelIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearLevelIdComboBox.TabIndex = 6;
            this.yearLevelIdComboBox.ValueMember = "YearLevelId";
            // 
            // yearLevelBindingSource
            // 
            this.yearLevelBindingSource.DataSource = typeof(GenDataLayer.YearLevel);
            // 
            // sectionIdComboBox
            // 
            this.sectionIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.courseSecScheduleBindingSource, "SectionId", true));
            this.sectionIdComboBox.DataSource = this.sectionBindingSource;
            this.sectionIdComboBox.DisplayMember = "SectionName";
            this.sectionIdComboBox.FormattingEnabled = true;
            this.sectionIdComboBox.Location = new System.Drawing.Point(77, 107);
            this.sectionIdComboBox.Name = "sectionIdComboBox";
            this.sectionIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.sectionIdComboBox.TabIndex = 9;
            this.sectionIdComboBox.ValueMember = "SectionId";
            // 
            // sectionBindingSource
            // 
            this.sectionBindingSource.DataSource = typeof(GenDataLayer.Section);
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.courseSecScheduleBindingSource, "IsActive", true));
            this.isActiveCheckBox.Location = new System.Drawing.Point(77, 129);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isActiveCheckBox.TabIndex = 10;
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseSecScheduleBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(77, 156);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(405, 58);
            this.noteTextBox.TabIndex = 12;
            // 
            // ScheduleUpdateSemSyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 226);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(isActiveLabel);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.sectionIdComboBox);
            this.Controls.Add(sectionIdLabel);
            this.Controls.Add(yearLevelIdLabel);
            this.Controls.Add(this.yearLevelIdComboBox);
            this.Controls.Add(courseIdLabel);
            this.Controls.Add(this.courseIdComboBox);
            this.Controls.Add(this.semSyIdComboBox);
            this.Controls.Add(semSyIdLabel);
            this.Controls.Add(this.courseSecScheduleBindingNavigator);
            this.Name = "ScheduleUpdateSemSyForm";
            this.Text = "Sem/Sy, Course, Year Level, Section...";
            this.Load += new System.EventHandler(this.ScheduleUpdateSemSyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseSecScheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseSecScheduleBindingNavigator)).EndInit();
            this.courseSecScheduleBindingNavigator.ResumeLayout(false);
            this.courseSecScheduleBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource courseSecScheduleBindingSource;
        private System.Windows.Forms.BindingNavigator courseSecScheduleBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton courseSecScheduleBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox semSyIdComboBox;
        private System.Windows.Forms.ComboBox courseIdComboBox;
        private System.Windows.Forms.ComboBox yearLevelIdComboBox;
        private System.Windows.Forms.ComboBox sectionIdComboBox;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.BindingSource coursBindingSource;
        private System.Windows.Forms.BindingSource yearLevelBindingSource;
        private System.Windows.Forms.BindingSource sectionBindingSource;
        private System.Windows.Forms.BindingSource semSyEntityBindingSource;
    }
}