namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class UpdateScheduleFeeNameForm
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
            System.Windows.Forms.Label scheduleNameLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateScheduleFeeNameForm));
            this.scheduleFeeNameBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.scheduleFeeNameBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.scheduleNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.scheduleFeeNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            scheduleNameLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleFeeNameBindingNavigator)).BeginInit();
            this.scheduleFeeNameBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleFeeNameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduleNameLabel
            // 
            scheduleNameLabel.AutoSize = true;
            scheduleNameLabel.Location = new System.Drawing.Point(12, 41);
            scheduleNameLabel.Name = "scheduleNameLabel";
            scheduleNameLabel.Size = new System.Drawing.Size(107, 13);
            scheduleNameLabel.TabIndex = 1;
            scheduleNameLabel.Text = "Schedule Fee Name:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(56, 66);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Description:";
            // 
            // scheduleFeeNameBindingNavigator
            // 
            this.scheduleFeeNameBindingNavigator.AddNewItem = null;
            this.scheduleFeeNameBindingNavigator.BindingSource = this.scheduleFeeNameBindingSource;
            this.scheduleFeeNameBindingNavigator.CountItem = null;
            this.scheduleFeeNameBindingNavigator.DeleteItem = null;
            this.scheduleFeeNameBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.scheduleFeeNameBindingNavigatorSaveItem});
            this.scheduleFeeNameBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.scheduleFeeNameBindingNavigator.MoveFirstItem = null;
            this.scheduleFeeNameBindingNavigator.MoveLastItem = null;
            this.scheduleFeeNameBindingNavigator.MoveNextItem = null;
            this.scheduleFeeNameBindingNavigator.MovePreviousItem = null;
            this.scheduleFeeNameBindingNavigator.Name = "scheduleFeeNameBindingNavigator";
            this.scheduleFeeNameBindingNavigator.PositionItem = null;
            this.scheduleFeeNameBindingNavigator.Size = new System.Drawing.Size(493, 25);
            this.scheduleFeeNameBindingNavigator.TabIndex = 0;
            this.scheduleFeeNameBindingNavigator.Text = "bindingNavigator1";
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
            // scheduleFeeNameBindingNavigatorSaveItem
            // 
            this.scheduleFeeNameBindingNavigatorSaveItem.Enabled = false;
            this.scheduleFeeNameBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleFeeNameBindingNavigatorSaveItem.Image")));
            this.scheduleFeeNameBindingNavigatorSaveItem.Name = "scheduleFeeNameBindingNavigatorSaveItem";
            this.scheduleFeeNameBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.scheduleFeeNameBindingNavigatorSaveItem.Text = "Save Data";
            this.scheduleFeeNameBindingNavigatorSaveItem.Click += new System.EventHandler(this.scheduleFeeNameBindingNavigatorSaveItem_Click);
            // 
            // scheduleNameTextBox
            // 
            this.scheduleNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scheduleFeeNameBindingSource, "ScheduleName", true));
            this.scheduleNameTextBox.Location = new System.Drawing.Point(125, 40);
            this.scheduleNameTextBox.Name = "scheduleNameTextBox";
            this.scheduleNameTextBox.Size = new System.Drawing.Size(358, 20);
            this.scheduleNameTextBox.TabIndex = 2;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scheduleFeeNameBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(125, 63);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(358, 123);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // scheduleFeeNameBindingSource
            // 
            this.scheduleFeeNameBindingSource.DataSource = typeof(GenDataLayer.ScheduleFeeName);
            this.scheduleFeeNameBindingSource.CurrentChanged += new System.EventHandler(this.scheduleFeeNameBindingSource_CurrentChanged);
            // 
            // UpdateScheduleFeeNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 195);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(scheduleNameLabel);
            this.Controls.Add(this.scheduleNameTextBox);
            this.Controls.Add(this.scheduleFeeNameBindingNavigator);
            this.Name = "UpdateScheduleFeeNameForm";
            this.Text = "Update Schedule Fee Name";
            this.Load += new System.EventHandler(this.UpdateScheduleFeeNameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleFeeNameBindingNavigator)).EndInit();
            this.scheduleFeeNameBindingNavigator.ResumeLayout(false);
            this.scheduleFeeNameBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleFeeNameBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource scheduleFeeNameBindingSource;
        private System.Windows.Forms.BindingNavigator scheduleFeeNameBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton scheduleFeeNameBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox scheduleNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}