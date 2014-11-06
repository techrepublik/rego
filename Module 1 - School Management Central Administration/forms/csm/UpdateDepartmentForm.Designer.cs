namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class UpdateDepartmentForm
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
            System.Windows.Forms.Label departmentNameLabel;
            System.Windows.Forms.Label departmentDescriptionLabel;
            System.Windows.Forms.Label collegeNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDepartmentForm));
            this.departmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.departmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.departmentNameTextBox = new System.Windows.Forms.TextBox();
            this.departmentDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.collegeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collegeIdComboBox = new System.Windows.Forms.ComboBox();
            departmentNameLabel = new System.Windows.Forms.Label();
            departmentDescriptionLabel = new System.Windows.Forms.Label();
            collegeNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingNavigator)).BeginInit();
            this.departmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentNameLabel
            // 
            departmentNameLabel.AutoSize = true;
            departmentNameLabel.Location = new System.Drawing.Point(12, 57);
            departmentNameLabel.Name = "departmentNameLabel";
            departmentNameLabel.Size = new System.Drawing.Size(96, 13);
            departmentNameLabel.TabIndex = 1;
            departmentNameLabel.Text = "Department Name:";
            // 
            // departmentDescriptionLabel
            // 
            departmentDescriptionLabel.AutoSize = true;
            departmentDescriptionLabel.Location = new System.Drawing.Point(12, 83);
            departmentDescriptionLabel.Name = "departmentDescriptionLabel";
            departmentDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            departmentDescriptionLabel.TabIndex = 3;
            departmentDescriptionLabel.Text = "Description:";
            // 
            // collegeNameLabel
            // 
            collegeNameLabel.AutoSize = true;
            collegeNameLabel.Location = new System.Drawing.Point(12, 33);
            collegeNameLabel.Name = "collegeNameLabel";
            collegeNameLabel.Size = new System.Drawing.Size(76, 13);
            collegeNameLabel.TabIndex = 5;
            collegeNameLabel.Text = "College Name:";
            // 
            // departmentBindingNavigator
            // 
            this.departmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.departmentBindingNavigator.BindingSource = this.departmentBindingSource;
            this.departmentBindingNavigator.CountItem = null;
            this.departmentBindingNavigator.DeleteItem = null;
            this.departmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.departmentBindingNavigatorSaveItem});
            this.departmentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.departmentBindingNavigator.MoveFirstItem = null;
            this.departmentBindingNavigator.MoveLastItem = null;
            this.departmentBindingNavigator.MoveNextItem = null;
            this.departmentBindingNavigator.MovePreviousItem = null;
            this.departmentBindingNavigator.Name = "departmentBindingNavigator";
            this.departmentBindingNavigator.PositionItem = null;
            this.departmentBindingNavigator.Size = new System.Drawing.Size(504, 25);
            this.departmentBindingNavigator.TabIndex = 0;
            this.departmentBindingNavigator.Text = "bindingNavigator1";
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
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(GenDataLayer.Department);
            this.departmentBindingSource.CurrentChanged += new System.EventHandler(this.departmentBindingSource_CurrentChanged);
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
            // departmentBindingNavigatorSaveItem
            // 
            this.departmentBindingNavigatorSaveItem.Enabled = false;
            this.departmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("departmentBindingNavigatorSaveItem.Image")));
            this.departmentBindingNavigatorSaveItem.Name = "departmentBindingNavigatorSaveItem";
            this.departmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.departmentBindingNavigatorSaveItem.Text = "Save Data";
            this.departmentBindingNavigatorSaveItem.Click += new System.EventHandler(this.departmentBindingNavigatorSaveItem_Click);
            // 
            // departmentNameTextBox
            // 
            this.departmentNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource, "DepartmentName", true));
            this.departmentNameTextBox.Location = new System.Drawing.Point(114, 55);
            this.departmentNameTextBox.Name = "departmentNameTextBox";
            this.departmentNameTextBox.Size = new System.Drawing.Size(370, 20);
            this.departmentNameTextBox.TabIndex = 2;
            // 
            // departmentDescriptionTextBox
            // 
            this.departmentDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.departmentBindingSource, "DepartmentDescription", true));
            this.departmentDescriptionTextBox.Location = new System.Drawing.Point(114, 79);
            this.departmentDescriptionTextBox.Multiline = true;
            this.departmentDescriptionTextBox.Name = "departmentDescriptionTextBox";
            this.departmentDescriptionTextBox.Size = new System.Drawing.Size(370, 124);
            this.departmentDescriptionTextBox.TabIndex = 4;
            // 
            // collegeBindingSource
            // 
            this.collegeBindingSource.DataSource = typeof(GenDataLayer.College);
            // 
            // collegeIdComboBox
            // 
            this.collegeIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.departmentBindingSource, "CollegeId", true));
            this.collegeIdComboBox.DataSource = this.collegeBindingSource;
            this.collegeIdComboBox.DisplayMember = "CollegeName";
            this.collegeIdComboBox.FormattingEnabled = true;
            this.collegeIdComboBox.Location = new System.Drawing.Point(114, 30);
            this.collegeIdComboBox.Name = "collegeIdComboBox";
            this.collegeIdComboBox.Size = new System.Drawing.Size(370, 21);
            this.collegeIdComboBox.TabIndex = 7;
            this.collegeIdComboBox.ValueMember = "CollegeId";
            // 
            // UpdateDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 223);
            this.Controls.Add(this.collegeIdComboBox);
            this.Controls.Add(collegeNameLabel);
            this.Controls.Add(departmentDescriptionLabel);
            this.Controls.Add(this.departmentDescriptionTextBox);
            this.Controls.Add(departmentNameLabel);
            this.Controls.Add(this.departmentNameTextBox);
            this.Controls.Add(this.departmentBindingNavigator);
            this.Name = "UpdateDepartmentForm";
            this.Text = "Update Department Form";
            this.Load += new System.EventHandler(this.UpdateDepartmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingNavigator)).EndInit();
            this.departmentBindingNavigator.ResumeLayout(false);
            this.departmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.BindingNavigator departmentBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton departmentBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox departmentNameTextBox;
        private System.Windows.Forms.TextBox departmentDescriptionTextBox;
        private System.Windows.Forms.BindingSource collegeBindingSource;
        private System.Windows.Forms.ComboBox collegeIdComboBox;
    }
}