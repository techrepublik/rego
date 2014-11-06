namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class UpdateScholarshipForm
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
            System.Windows.Forms.Label scholarshipNameLabel;
            System.Windows.Forms.Label scholarshipAbbreviationLabel;
            System.Windows.Forms.Label sponsorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateScholarshipForm));
            this.scholarshipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scholarshipBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.scholarshipBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.scholarshipNameTextBox = new System.Windows.Forms.TextBox();
            this.scholarshipAbbreviationTextBox = new System.Windows.Forms.TextBox();
            this.sponsorTextBox = new System.Windows.Forms.TextBox();
            scholarshipNameLabel = new System.Windows.Forms.Label();
            scholarshipAbbreviationLabel = new System.Windows.Forms.Label();
            sponsorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scholarshipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scholarshipBindingNavigator)).BeginInit();
            this.scholarshipBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // scholarshipNameLabel
            // 
            scholarshipNameLabel.AutoSize = true;
            scholarshipNameLabel.Location = new System.Drawing.Point(12, 44);
            scholarshipNameLabel.Name = "scholarshipNameLabel";
            scholarshipNameLabel.Size = new System.Drawing.Size(96, 13);
            scholarshipNameLabel.TabIndex = 1;
            scholarshipNameLabel.Text = "Scholarship Name:";
            // 
            // scholarshipAbbreviationLabel
            // 
            scholarshipAbbreviationLabel.AutoSize = true;
            scholarshipAbbreviationLabel.Location = new System.Drawing.Point(12, 68);
            scholarshipAbbreviationLabel.Name = "scholarshipAbbreviationLabel";
            scholarshipAbbreviationLabel.Size = new System.Drawing.Size(69, 13);
            scholarshipAbbreviationLabel.TabIndex = 3;
            scholarshipAbbreviationLabel.Text = "Abbreviation:";
            // 
            // sponsorLabel
            // 
            sponsorLabel.AutoSize = true;
            sponsorLabel.Location = new System.Drawing.Point(12, 94);
            sponsorLabel.Name = "sponsorLabel";
            sponsorLabel.Size = new System.Drawing.Size(49, 13);
            sponsorLabel.TabIndex = 5;
            sponsorLabel.Text = "Sponsor:";
            // 
            // scholarshipBindingSource
            // 
            this.scholarshipBindingSource.DataSource = typeof(GenDataLayer.Scholarship);
            this.scholarshipBindingSource.CurrentChanged += new System.EventHandler(this.scholarshipBindingSource_CurrentChanged);
            // 
            // scholarshipBindingNavigator
            // 
            this.scholarshipBindingNavigator.AddNewItem = null;
            this.scholarshipBindingNavigator.BindingSource = this.scholarshipBindingSource;
            this.scholarshipBindingNavigator.CountItem = null;
            this.scholarshipBindingNavigator.DeleteItem = null;
            this.scholarshipBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.scholarshipBindingNavigatorSaveItem});
            this.scholarshipBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.scholarshipBindingNavigator.MoveFirstItem = null;
            this.scholarshipBindingNavigator.MoveLastItem = null;
            this.scholarshipBindingNavigator.MoveNextItem = null;
            this.scholarshipBindingNavigator.MovePreviousItem = null;
            this.scholarshipBindingNavigator.Name = "scholarshipBindingNavigator";
            this.scholarshipBindingNavigator.PositionItem = null;
            this.scholarshipBindingNavigator.Size = new System.Drawing.Size(543, 25);
            this.scholarshipBindingNavigator.TabIndex = 0;
            this.scholarshipBindingNavigator.Text = "bindingNavigator1";
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
            // scholarshipBindingNavigatorSaveItem
            // 
            this.scholarshipBindingNavigatorSaveItem.Enabled = false;
            this.scholarshipBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("scholarshipBindingNavigatorSaveItem.Image")));
            this.scholarshipBindingNavigatorSaveItem.Name = "scholarshipBindingNavigatorSaveItem";
            this.scholarshipBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.scholarshipBindingNavigatorSaveItem.Text = "Save Data";
            this.scholarshipBindingNavigatorSaveItem.Click += new System.EventHandler(this.scholarshipBindingNavigatorSaveItem_Click);
            // 
            // scholarshipNameTextBox
            // 
            this.scholarshipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scholarshipBindingSource, "ScholarshipName", true));
            this.scholarshipNameTextBox.Location = new System.Drawing.Point(124, 41);
            this.scholarshipNameTextBox.Name = "scholarshipNameTextBox";
            this.scholarshipNameTextBox.Size = new System.Drawing.Size(408, 20);
            this.scholarshipNameTextBox.TabIndex = 2;
            // 
            // scholarshipAbbreviationTextBox
            // 
            this.scholarshipAbbreviationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scholarshipBindingSource, "ScholarshipAbbreviation", true));
            this.scholarshipAbbreviationTextBox.Location = new System.Drawing.Point(124, 65);
            this.scholarshipAbbreviationTextBox.Name = "scholarshipAbbreviationTextBox";
            this.scholarshipAbbreviationTextBox.Size = new System.Drawing.Size(234, 20);
            this.scholarshipAbbreviationTextBox.TabIndex = 4;
            // 
            // sponsorTextBox
            // 
            this.sponsorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scholarshipBindingSource, "Sponsor", true));
            this.sponsorTextBox.Location = new System.Drawing.Point(124, 91);
            this.sponsorTextBox.Multiline = true;
            this.sponsorTextBox.Name = "sponsorTextBox";
            this.sponsorTextBox.Size = new System.Drawing.Size(408, 82);
            this.sponsorTextBox.TabIndex = 6;
            // 
            // UpdateScholarshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 187);
            this.Controls.Add(sponsorLabel);
            this.Controls.Add(this.sponsorTextBox);
            this.Controls.Add(scholarshipAbbreviationLabel);
            this.Controls.Add(this.scholarshipAbbreviationTextBox);
            this.Controls.Add(scholarshipNameLabel);
            this.Controls.Add(this.scholarshipNameTextBox);
            this.Controls.Add(this.scholarshipBindingNavigator);
            this.Name = "UpdateScholarshipForm";
            this.Text = "Update Scholarship Form";
            this.Load += new System.EventHandler(this.UpdateScholarshipForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scholarshipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scholarshipBindingNavigator)).EndInit();
            this.scholarshipBindingNavigator.ResumeLayout(false);
            this.scholarshipBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource scholarshipBindingSource;
        private System.Windows.Forms.BindingNavigator scholarshipBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton scholarshipBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox scholarshipNameTextBox;
        private System.Windows.Forms.TextBox scholarshipAbbreviationTextBox;
        private System.Windows.Forms.TextBox sponsorTextBox;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    }
}