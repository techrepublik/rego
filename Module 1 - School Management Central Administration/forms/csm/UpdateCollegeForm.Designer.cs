namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class UpdateCollegeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCollegeForm));
            this.collegeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.collegeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.collegeBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.collegeNameTextBox = new System.Windows.Forms.TextBox();
            this.collegeDescriptionTextBox = new System.Windows.Forms.TextBox();
            collegeNameLabel = new System.Windows.Forms.Label();
            collegeDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingNavigator)).BeginInit();
            this.collegeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // collegeNameLabel
            // 
            collegeNameLabel.AutoSize = true;
            collegeNameLabel.Location = new System.Drawing.Point(12, 40);
            collegeNameLabel.Name = "collegeNameLabel";
            collegeNameLabel.Size = new System.Drawing.Size(76, 13);
            collegeNameLabel.TabIndex = 1;
            collegeNameLabel.Text = "College Name:";
            // 
            // collegeDescriptionLabel
            // 
            collegeDescriptionLabel.AutoSize = true;
            collegeDescriptionLabel.Location = new System.Drawing.Point(12, 65);
            collegeDescriptionLabel.Name = "collegeDescriptionLabel";
            collegeDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            collegeDescriptionLabel.TabIndex = 3;
            collegeDescriptionLabel.Text = "Description:";
            // 
            // collegeBindingNavigator
            // 
            this.collegeBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.collegeBindingNavigator.BindingSource = this.collegeBindingSource;
            this.collegeBindingNavigator.CountItem = null;
            this.collegeBindingNavigator.DeleteItem = null;
            this.collegeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.collegeBindingNavigatorSaveItem});
            this.collegeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.collegeBindingNavigator.MoveFirstItem = null;
            this.collegeBindingNavigator.MoveLastItem = null;
            this.collegeBindingNavigator.MoveNextItem = null;
            this.collegeBindingNavigator.MovePreviousItem = null;
            this.collegeBindingNavigator.Name = "collegeBindingNavigator";
            this.collegeBindingNavigator.PositionItem = null;
            this.collegeBindingNavigator.Size = new System.Drawing.Size(494, 25);
            this.collegeBindingNavigator.TabIndex = 0;
            this.collegeBindingNavigator.Text = "bindingNavigator1";
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
            // collegeBindingSource
            // 
            this.collegeBindingSource.DataSource = typeof(GenDataLayer.College);
            this.collegeBindingSource.CurrentChanged += new System.EventHandler(this.collegeBindingSource_CurrentChanged);
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
            // collegeBindingNavigatorSaveItem
            // 
            this.collegeBindingNavigatorSaveItem.Enabled = false;
            this.collegeBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("collegeBindingNavigatorSaveItem.Image")));
            this.collegeBindingNavigatorSaveItem.Name = "collegeBindingNavigatorSaveItem";
            this.collegeBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.collegeBindingNavigatorSaveItem.Text = "Save Data";
            this.collegeBindingNavigatorSaveItem.Click += new System.EventHandler(this.collegeBindingNavigatorSaveItem_Click);
            // 
            // collegeNameTextBox
            // 
            this.collegeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.collegeBindingSource, "CollegeName", true));
            this.collegeNameTextBox.Location = new System.Drawing.Point(94, 37);
            this.collegeNameTextBox.Name = "collegeNameTextBox";
            this.collegeNameTextBox.Size = new System.Drawing.Size(391, 20);
            this.collegeNameTextBox.TabIndex = 2;
            // 
            // collegeDescriptionTextBox
            // 
            this.collegeDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.collegeBindingSource, "CollegeDescription", true));
            this.collegeDescriptionTextBox.Location = new System.Drawing.Point(94, 62);
            this.collegeDescriptionTextBox.Multiline = true;
            this.collegeDescriptionTextBox.Name = "collegeDescriptionTextBox";
            this.collegeDescriptionTextBox.Size = new System.Drawing.Size(391, 78);
            this.collegeDescriptionTextBox.TabIndex = 4;
            // 
            // UpdateCollegeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 152);
            this.Controls.Add(collegeDescriptionLabel);
            this.Controls.Add(this.collegeDescriptionTextBox);
            this.Controls.Add(collegeNameLabel);
            this.Controls.Add(this.collegeNameTextBox);
            this.Controls.Add(this.collegeBindingNavigator);
            this.Name = "UpdateCollegeForm";
            this.Text = "Update College Form";
            this.Load += new System.EventHandler(this.UpdateCollegeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingNavigator)).EndInit();
            this.collegeBindingNavigator.ResumeLayout(false);
            this.collegeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collegeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource collegeBindingSource;
        private System.Windows.Forms.BindingNavigator collegeBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton collegeBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox collegeNameTextBox;
        private System.Windows.Forms.TextBox collegeDescriptionTextBox;
    }
}