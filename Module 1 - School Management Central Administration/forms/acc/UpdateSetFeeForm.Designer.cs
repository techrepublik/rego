namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class UpdateSetFeeForm
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
            System.Windows.Forms.Label noteLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateSetFeeForm));
            this.setPresetFeeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.setPresetFeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.setPresetFeeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.semSyIdComboBox = new System.Windows.Forms.ComboBox();
            this.semSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseIdComboBox = new System.Windows.Forms.ComboBox();
            this.coursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yearLevelIdComboBox = new System.Windows.Forms.ComboBox();
            this.yearLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noteTextBox = new System.Windows.Forms.TextBox();
            semSyIdLabel = new System.Windows.Forms.Label();
            courseIdLabel = new System.Windows.Forms.Label();
            yearLevelIdLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.setPresetFeeBindingNavigator)).BeginInit();
            this.setPresetFeeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setPresetFeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearLevelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // semSyIdLabel
            // 
            semSyIdLabel.AutoSize = true;
            semSyIdLabel.Location = new System.Drawing.Point(12, 42);
            semSyIdLabel.Name = "semSyIdLabel";
            semSyIdLabel.Size = new System.Drawing.Size(51, 13);
            semSyIdLabel.TabIndex = 1;
            semSyIdLabel.Text = "Sem/Sy :";
            // 
            // courseIdLabel
            // 
            courseIdLabel.AutoSize = true;
            courseIdLabel.Location = new System.Drawing.Point(12, 71);
            courseIdLabel.Name = "courseIdLabel";
            courseIdLabel.Size = new System.Drawing.Size(43, 13);
            courseIdLabel.TabIndex = 3;
            courseIdLabel.Text = "Course:";
            // 
            // yearLevelIdLabel
            // 
            yearLevelIdLabel.AutoSize = true;
            yearLevelIdLabel.Location = new System.Drawing.Point(12, 95);
            yearLevelIdLabel.Name = "yearLevelIdLabel";
            yearLevelIdLabel.Size = new System.Drawing.Size(61, 13);
            yearLevelIdLabel.TabIndex = 5;
            yearLevelIdLabel.Text = "Year Level:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(12, 122);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(33, 13);
            noteLabel.TabIndex = 7;
            noteLabel.Text = "Note:";
            // 
            // setPresetFeeBindingNavigator
            // 
            this.setPresetFeeBindingNavigator.AddNewItem = null;
            this.setPresetFeeBindingNavigator.BindingSource = this.setPresetFeeBindingSource;
            this.setPresetFeeBindingNavigator.CountItem = null;
            this.setPresetFeeBindingNavigator.DeleteItem = null;
            this.setPresetFeeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.setPresetFeeBindingNavigatorSaveItem});
            this.setPresetFeeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.setPresetFeeBindingNavigator.MoveFirstItem = null;
            this.setPresetFeeBindingNavigator.MoveLastItem = null;
            this.setPresetFeeBindingNavigator.MoveNextItem = null;
            this.setPresetFeeBindingNavigator.MovePreviousItem = null;
            this.setPresetFeeBindingNavigator.Name = "setPresetFeeBindingNavigator";
            this.setPresetFeeBindingNavigator.PositionItem = null;
            this.setPresetFeeBindingNavigator.Size = new System.Drawing.Size(484, 25);
            this.setPresetFeeBindingNavigator.TabIndex = 0;
            this.setPresetFeeBindingNavigator.Text = "bindingNavigator1";
            // 
            // setPresetFeeBindingSource
            // 
            this.setPresetFeeBindingSource.DataSource = typeof(GenDataLayer.SetPresetFee);
            this.setPresetFeeBindingSource.CurrentChanged += new System.EventHandler(this.setPresetFeeBindingSource_CurrentChanged);
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
            // setPresetFeeBindingNavigatorSaveItem
            // 
            this.setPresetFeeBindingNavigatorSaveItem.Enabled = false;
            this.setPresetFeeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("setPresetFeeBindingNavigatorSaveItem.Image")));
            this.setPresetFeeBindingNavigatorSaveItem.Name = "setPresetFeeBindingNavigatorSaveItem";
            this.setPresetFeeBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.setPresetFeeBindingNavigatorSaveItem.Text = "Save Data";
            this.setPresetFeeBindingNavigatorSaveItem.Click += new System.EventHandler(this.setPresetFeeBindingNavigatorSaveItem_Click);
            // 
            // semSyIdComboBox
            // 
            this.semSyIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.setPresetFeeBindingSource, "SemSyId", true));
            this.semSyIdComboBox.DataSource = this.semSyEntityBindingSource;
            this.semSyIdComboBox.DisplayMember = "SemSyName";
            this.semSyIdComboBox.FormattingEnabled = true;
            this.semSyIdComboBox.Location = new System.Drawing.Point(76, 42);
            this.semSyIdComboBox.Name = "semSyIdComboBox";
            this.semSyIdComboBox.Size = new System.Drawing.Size(141, 21);
            this.semSyIdComboBox.TabIndex = 2;
            this.semSyIdComboBox.ValueMember = "SemSyId";
            // 
            // semSyEntityBindingSource
            // 
            this.semSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // courseIdComboBox
            // 
            this.courseIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.setPresetFeeBindingSource, "CourseId", true));
            this.courseIdComboBox.DataSource = this.coursBindingSource;
            this.courseIdComboBox.DisplayMember = "CourseName";
            this.courseIdComboBox.FormattingEnabled = true;
            this.courseIdComboBox.Location = new System.Drawing.Point(76, 68);
            this.courseIdComboBox.Name = "courseIdComboBox";
            this.courseIdComboBox.Size = new System.Drawing.Size(396, 21);
            this.courseIdComboBox.TabIndex = 4;
            this.courseIdComboBox.ValueMember = "CourseId";
            // 
            // coursBindingSource
            // 
            this.coursBindingSource.DataSource = typeof(GenDataLayer.Cours);
            // 
            // yearLevelIdComboBox
            // 
            this.yearLevelIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.setPresetFeeBindingSource, "YearLevelId", true));
            this.yearLevelIdComboBox.DataSource = this.yearLevelBindingSource;
            this.yearLevelIdComboBox.DisplayMember = "YearLevelName";
            this.yearLevelIdComboBox.FormattingEnabled = true;
            this.yearLevelIdComboBox.Location = new System.Drawing.Point(76, 92);
            this.yearLevelIdComboBox.Name = "yearLevelIdComboBox";
            this.yearLevelIdComboBox.Size = new System.Drawing.Size(141, 21);
            this.yearLevelIdComboBox.TabIndex = 6;
            this.yearLevelIdComboBox.ValueMember = "YearLevelId";
            // 
            // yearLevelBindingSource
            // 
            this.yearLevelBindingSource.DataSource = typeof(GenDataLayer.YearLevel);
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.setPresetFeeBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(76, 119);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(396, 70);
            this.noteTextBox.TabIndex = 8;
            // 
            // UpdateSetFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(yearLevelIdLabel);
            this.Controls.Add(this.yearLevelIdComboBox);
            this.Controls.Add(courseIdLabel);
            this.Controls.Add(this.courseIdComboBox);
            this.Controls.Add(semSyIdLabel);
            this.Controls.Add(this.semSyIdComboBox);
            this.Controls.Add(this.setPresetFeeBindingNavigator);
            this.Name = "UpdateSetFeeForm";
            this.Text = "Update Set Fee Form";
            this.Load += new System.EventHandler(this.UpdateSetFeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setPresetFeeBindingNavigator)).EndInit();
            this.setPresetFeeBindingNavigator.ResumeLayout(false);
            this.setPresetFeeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setPresetFeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearLevelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource setPresetFeeBindingSource;
        private System.Windows.Forms.BindingNavigator setPresetFeeBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton setPresetFeeBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox semSyIdComboBox;
        private System.Windows.Forms.ComboBox courseIdComboBox;
        private System.Windows.Forms.ComboBox yearLevelIdComboBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.BindingSource coursBindingSource;
        private System.Windows.Forms.BindingSource yearLevelBindingSource;
        private System.Windows.Forms.BindingSource semSyEntityBindingSource;
    }
}