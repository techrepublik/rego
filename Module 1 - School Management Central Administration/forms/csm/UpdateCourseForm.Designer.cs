namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class UpdateCourseForm
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
            System.Windows.Forms.Label courseNameLabel;
            System.Windows.Forms.Label abbreviationLabel;
            System.Windows.Forms.Label durationLabel;
            System.Windows.Forms.Label departmentIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCourseForm));
            this.coursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coursBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.coursBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.abbreviationTextBox = new System.Windows.Forms.TextBox();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            courseNameLabel = new System.Windows.Forms.Label();
            abbreviationLabel = new System.Windows.Forms.Label();
            durationLabel = new System.Windows.Forms.Label();
            departmentIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingNavigator)).BeginInit();
            this.coursBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // courseNameLabel
            // 
            courseNameLabel.AutoSize = true;
            courseNameLabel.Location = new System.Drawing.Point(12, 62);
            courseNameLabel.Name = "courseNameLabel";
            courseNameLabel.Size = new System.Drawing.Size(74, 13);
            courseNameLabel.TabIndex = 1;
            courseNameLabel.Text = "Course Name:";
            // 
            // abbreviationLabel
            // 
            abbreviationLabel.AutoSize = true;
            abbreviationLabel.Location = new System.Drawing.Point(12, 88);
            abbreviationLabel.Name = "abbreviationLabel";
            abbreviationLabel.Size = new System.Drawing.Size(69, 13);
            abbreviationLabel.TabIndex = 3;
            abbreviationLabel.Text = "Abbreviation:";
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new System.Drawing.Point(12, 113);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new System.Drawing.Size(50, 13);
            durationLabel.TabIndex = 5;
            durationLabel.Text = "Duration:";
            // 
            // departmentIdLabel
            // 
            departmentIdLabel.AutoSize = true;
            departmentIdLabel.Location = new System.Drawing.Point(11, 38);
            departmentIdLabel.Name = "departmentIdLabel";
            departmentIdLabel.Size = new System.Drawing.Size(65, 13);
            departmentIdLabel.TabIndex = 7;
            departmentIdLabel.Text = "Department:";
            // 
            // coursBindingSource
            // 
            this.coursBindingSource.DataSource = typeof(GenDataLayer.Cours);
            this.coursBindingSource.CurrentChanged += new System.EventHandler(this.coursBindingSource_CurrentChanged);
            // 
            // coursBindingNavigator
            // 
            this.coursBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.coursBindingNavigator.BindingSource = this.coursBindingSource;
            this.coursBindingNavigator.CountItem = null;
            this.coursBindingNavigator.DeleteItem = null;
            this.coursBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.coursBindingNavigatorSaveItem});
            this.coursBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.coursBindingNavigator.MoveFirstItem = null;
            this.coursBindingNavigator.MoveLastItem = null;
            this.coursBindingNavigator.MoveNextItem = null;
            this.coursBindingNavigator.MovePreviousItem = null;
            this.coursBindingNavigator.Name = "coursBindingNavigator";
            this.coursBindingNavigator.PositionItem = null;
            this.coursBindingNavigator.Size = new System.Drawing.Size(482, 25);
            this.coursBindingNavigator.TabIndex = 0;
            this.coursBindingNavigator.Text = "bindingNavigator1";
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
            // coursBindingNavigatorSaveItem
            // 
            this.coursBindingNavigatorSaveItem.Enabled = false;
            this.coursBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("coursBindingNavigatorSaveItem.Image")));
            this.coursBindingNavigatorSaveItem.Name = "coursBindingNavigatorSaveItem";
            this.coursBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.coursBindingNavigatorSaveItem.Text = "Save Data";
            this.coursBindingNavigatorSaveItem.Click += new System.EventHandler(this.coursBindingNavigatorSaveItem_Click);
            // 
            // courseNameTextBox
            // 
            this.courseNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "CourseName", true));
            this.courseNameTextBox.Location = new System.Drawing.Point(109, 62);
            this.courseNameTextBox.Name = "courseNameTextBox";
            this.courseNameTextBox.Size = new System.Drawing.Size(359, 20);
            this.courseNameTextBox.TabIndex = 2;
            // 
            // abbreviationTextBox
            // 
            this.abbreviationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "Abbreviation", true));
            this.abbreviationTextBox.Location = new System.Drawing.Point(109, 86);
            this.abbreviationTextBox.Name = "abbreviationTextBox";
            this.abbreviationTextBox.Size = new System.Drawing.Size(100, 20);
            this.abbreviationTextBox.TabIndex = 4;
            // 
            // durationTextBox
            // 
            this.durationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coursBindingSource, "Duration", true));
            this.durationTextBox.Location = new System.Drawing.Point(109, 110);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(100, 20);
            this.durationTextBox.TabIndex = 6;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(GenDataLayer.Department);
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.coursBindingSource, "DepartmentId", true));
            this.comboBoxDepartment.DataSource = this.departmentBindingSource;
            this.comboBoxDepartment.DisplayMember = "DepartmentName";
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(109, 35);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(359, 21);
            this.comboBoxDepartment.TabIndex = 8;
            this.comboBoxDepartment.ValueMember = "DepartmentId";
            // 
            // UpdateCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 140);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(departmentIdLabel);
            this.Controls.Add(durationLabel);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(abbreviationLabel);
            this.Controls.Add(this.abbreviationTextBox);
            this.Controls.Add(courseNameLabel);
            this.Controls.Add(this.courseNameTextBox);
            this.Controls.Add(this.coursBindingNavigator);
            this.Name = "UpdateCourseForm";
            this.Text = "Update Course";
            this.Load += new System.EventHandler(this.UpdateCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingNavigator)).EndInit();
            this.coursBindingNavigator.ResumeLayout(false);
            this.coursBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource coursBindingSource;
        private System.Windows.Forms.BindingNavigator coursBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton coursBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.TextBox abbreviationTextBox;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
    }
}