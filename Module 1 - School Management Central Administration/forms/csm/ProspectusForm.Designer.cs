namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class ProspectusForm
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
            System.Windows.Forms.Label courseIdLabel;
            System.Windows.Forms.Label prospectusNameLabel;
            System.Windows.Forms.Label curriculumLabel;
            System.Windows.Forms.Label prospectusDescriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectusForm));
            this.prospectusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prospectusBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.prospectusBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.courseIdComboBox = new System.Windows.Forms.ComboBox();
            this.coursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prospectusNameTextBox = new System.Windows.Forms.TextBox();
            this.curriculumTextBox = new System.Windows.Forms.TextBox();
            this.prospectusDescriptionTextBox = new System.Windows.Forms.TextBox();
            courseIdLabel = new System.Windows.Forms.Label();
            prospectusNameLabel = new System.Windows.Forms.Label();
            curriculumLabel = new System.Windows.Forms.Label();
            prospectusDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingNavigator)).BeginInit();
            this.prospectusBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // courseIdLabel
            // 
            courseIdLabel.AutoSize = true;
            courseIdLabel.Location = new System.Drawing.Point(11, 42);
            courseIdLabel.Name = "courseIdLabel";
            courseIdLabel.Size = new System.Drawing.Size(43, 13);
            courseIdLabel.TabIndex = 1;
            courseIdLabel.Text = "Course:";
            // 
            // prospectusNameLabel
            // 
            prospectusNameLabel.AutoSize = true;
            prospectusNameLabel.Location = new System.Drawing.Point(12, 65);
            prospectusNameLabel.Name = "prospectusNameLabel";
            prospectusNameLabel.Size = new System.Drawing.Size(94, 13);
            prospectusNameLabel.TabIndex = 3;
            prospectusNameLabel.Text = "Prospectus Name:";
            // 
            // curriculumLabel
            // 
            curriculumLabel.AutoSize = true;
            curriculumLabel.Location = new System.Drawing.Point(12, 92);
            curriculumLabel.Name = "curriculumLabel";
            curriculumLabel.Size = new System.Drawing.Size(59, 13);
            curriculumLabel.TabIndex = 5;
            curriculumLabel.Text = "Curriculum:";
            // 
            // prospectusDescriptionLabel
            // 
            prospectusDescriptionLabel.AutoSize = true;
            prospectusDescriptionLabel.Location = new System.Drawing.Point(12, 120);
            prospectusDescriptionLabel.Name = "prospectusDescriptionLabel";
            prospectusDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            prospectusDescriptionLabel.TabIndex = 7;
            prospectusDescriptionLabel.Text = "Description:";
            // 
            // prospectusBindingSource
            // 
            this.prospectusBindingSource.DataSource = typeof(GenDataLayer.Prospectus);
            this.prospectusBindingSource.CurrentChanged += new System.EventHandler(this.prospectusBindingSource_CurrentChanged);
            // 
            // prospectusBindingNavigator
            // 
            this.prospectusBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.prospectusBindingNavigator.BindingSource = this.prospectusBindingSource;
            this.prospectusBindingNavigator.CountItem = null;
            this.prospectusBindingNavigator.DeleteItem = null;
            this.prospectusBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.prospectusBindingNavigatorSaveItem});
            this.prospectusBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.prospectusBindingNavigator.MoveFirstItem = null;
            this.prospectusBindingNavigator.MoveLastItem = null;
            this.prospectusBindingNavigator.MoveNextItem = null;
            this.prospectusBindingNavigator.MovePreviousItem = null;
            this.prospectusBindingNavigator.Name = "prospectusBindingNavigator";
            this.prospectusBindingNavigator.PositionItem = null;
            this.prospectusBindingNavigator.Size = new System.Drawing.Size(561, 25);
            this.prospectusBindingNavigator.TabIndex = 0;
            this.prospectusBindingNavigator.Text = "bindingNavigator1";
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
            // prospectusBindingNavigatorSaveItem
            // 
            this.prospectusBindingNavigatorSaveItem.Enabled = false;
            this.prospectusBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("prospectusBindingNavigatorSaveItem.Image")));
            this.prospectusBindingNavigatorSaveItem.Name = "prospectusBindingNavigatorSaveItem";
            this.prospectusBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.prospectusBindingNavigatorSaveItem.Text = "Save Data";
            this.prospectusBindingNavigatorSaveItem.Click += new System.EventHandler(this.prospectusBindingNavigatorSaveItem_Click);
            // 
            // courseIdComboBox
            // 
            this.courseIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.prospectusBindingSource, "CourseId", true));
            this.courseIdComboBox.DataSource = this.coursBindingSource;
            this.courseIdComboBox.DisplayMember = "CourseName";
            this.courseIdComboBox.FormattingEnabled = true;
            this.courseIdComboBox.Location = new System.Drawing.Point(110, 39);
            this.courseIdComboBox.Name = "courseIdComboBox";
            this.courseIdComboBox.Size = new System.Drawing.Size(439, 21);
            this.courseIdComboBox.TabIndex = 2;
            this.courseIdComboBox.ValueMember = "CourseId";
            // 
            // coursBindingSource
            // 
            this.coursBindingSource.DataSource = typeof(GenDataLayer.Cours);
            // 
            // prospectusNameTextBox
            // 
            this.prospectusNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusBindingSource, "ProspectusName", true));
            this.prospectusNameTextBox.Location = new System.Drawing.Point(110, 65);
            this.prospectusNameTextBox.Name = "prospectusNameTextBox";
            this.prospectusNameTextBox.Size = new System.Drawing.Size(439, 20);
            this.prospectusNameTextBox.TabIndex = 4;
            // 
            // curriculumTextBox
            // 
            this.curriculumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusBindingSource, "Curriculum", true));
            this.curriculumTextBox.Location = new System.Drawing.Point(110, 89);
            this.curriculumTextBox.Name = "curriculumTextBox";
            this.curriculumTextBox.Size = new System.Drawing.Size(439, 20);
            this.curriculumTextBox.TabIndex = 6;
            // 
            // prospectusDescriptionTextBox
            // 
            this.prospectusDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusBindingSource, "ProspectusDescription", true));
            this.prospectusDescriptionTextBox.Location = new System.Drawing.Point(110, 113);
            this.prospectusDescriptionTextBox.Multiline = true;
            this.prospectusDescriptionTextBox.Name = "prospectusDescriptionTextBox";
            this.prospectusDescriptionTextBox.Size = new System.Drawing.Size(439, 95);
            this.prospectusDescriptionTextBox.TabIndex = 8;
            // 
            // ProspectusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 222);
            this.Controls.Add(prospectusDescriptionLabel);
            this.Controls.Add(this.prospectusDescriptionTextBox);
            this.Controls.Add(curriculumLabel);
            this.Controls.Add(this.curriculumTextBox);
            this.Controls.Add(prospectusNameLabel);
            this.Controls.Add(this.prospectusNameTextBox);
            this.Controls.Add(courseIdLabel);
            this.Controls.Add(this.courseIdComboBox);
            this.Controls.Add(this.prospectusBindingNavigator);
            this.Name = "ProspectusForm";
            this.Text = "Prospectus Form";
            this.Load += new System.EventHandler(this.ProspectusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingNavigator)).EndInit();
            this.prospectusBindingNavigator.ResumeLayout(false);
            this.prospectusBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coursBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource prospectusBindingSource;
        private System.Windows.Forms.BindingNavigator prospectusBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton prospectusBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox courseIdComboBox;
        private System.Windows.Forms.TextBox prospectusNameTextBox;
        private System.Windows.Forms.TextBox curriculumTextBox;
        private System.Windows.Forms.TextBox prospectusDescriptionTextBox;
        private System.Windows.Forms.BindingSource coursBindingSource;

    }
}