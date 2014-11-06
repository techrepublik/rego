namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class FeeSubTitleForm
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
            System.Windows.Forms.Label feeSubTitleNameLabel;
            System.Windows.Forms.Label feeTitleNameLabel;
            System.Windows.Forms.Label feeSubTitleDescriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeSubTitleForm));
            this.feeSubTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feeSubTitleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.feeSubTitleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.feeSubTitleNameTextBox = new System.Windows.Forms.TextBox();
            this.feeSubTitleDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.feeTitleIdComboBox = new System.Windows.Forms.ComboBox();
            this.feeTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            feeSubTitleNameLabel = new System.Windows.Forms.Label();
            feeTitleNameLabel = new System.Windows.Forms.Label();
            feeSubTitleDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingNavigator)).BeginInit();
            this.feeSubTitleBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // feeSubTitleNameLabel
            // 
            feeSubTitleNameLabel.AutoSize = true;
            feeSubTitleNameLabel.Location = new System.Drawing.Point(12, 61);
            feeSubTitleNameLabel.Name = "feeSubTitleNameLabel";
            feeSubTitleNameLabel.Size = new System.Drawing.Size(73, 13);
            feeSubTitleNameLabel.TabIndex = 1;
            feeSubTitleNameLabel.Text = "Fee Sub-Title:";
            // 
            // feeTitleNameLabel
            // 
            feeTitleNameLabel.AutoSize = true;
            feeTitleNameLabel.Location = new System.Drawing.Point(12, 38);
            feeTitleNameLabel.Name = "feeTitleNameLabel";
            feeTitleNameLabel.Size = new System.Drawing.Size(51, 13);
            feeTitleNameLabel.TabIndex = 3;
            feeTitleNameLabel.Text = "Fee Title:";
            // 
            // feeSubTitleDescriptionLabel
            // 
            feeSubTitleDescriptionLabel.AutoSize = true;
            feeSubTitleDescriptionLabel.Location = new System.Drawing.Point(12, 86);
            feeSubTitleDescriptionLabel.Name = "feeSubTitleDescriptionLabel";
            feeSubTitleDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            feeSubTitleDescriptionLabel.TabIndex = 5;
            feeSubTitleDescriptionLabel.Text = "Description:";
            // 
            // feeSubTitleBindingSource
            // 
            this.feeSubTitleBindingSource.DataSource = typeof(GenDataLayer.FeeSubTitle);
            this.feeSubTitleBindingSource.CurrentChanged += new System.EventHandler(this.feeSubTitleBindingSource_CurrentChanged);
            // 
            // feeSubTitleBindingNavigator
            // 
            this.feeSubTitleBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.feeSubTitleBindingNavigator.BindingSource = this.feeSubTitleBindingSource;
            this.feeSubTitleBindingNavigator.CountItem = null;
            this.feeSubTitleBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.feeSubTitleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.feeSubTitleBindingNavigatorSaveItem});
            this.feeSubTitleBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.feeSubTitleBindingNavigator.MoveFirstItem = null;
            this.feeSubTitleBindingNavigator.MoveLastItem = null;
            this.feeSubTitleBindingNavigator.MoveNextItem = null;
            this.feeSubTitleBindingNavigator.MovePreviousItem = null;
            this.feeSubTitleBindingNavigator.Name = "feeSubTitleBindingNavigator";
            this.feeSubTitleBindingNavigator.PositionItem = null;
            this.feeSubTitleBindingNavigator.Size = new System.Drawing.Size(494, 25);
            this.feeSubTitleBindingNavigator.TabIndex = 6;
            this.feeSubTitleBindingNavigator.Text = "bindingNavigator1";
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
            // 
            // feeSubTitleBindingNavigatorSaveItem
            // 
            this.feeSubTitleBindingNavigatorSaveItem.Enabled = false;
            this.feeSubTitleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("feeSubTitleBindingNavigatorSaveItem.Image")));
            this.feeSubTitleBindingNavigatorSaveItem.Name = "feeSubTitleBindingNavigatorSaveItem";
            this.feeSubTitleBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.feeSubTitleBindingNavigatorSaveItem.Text = "Save Data";
            this.feeSubTitleBindingNavigatorSaveItem.Click += new System.EventHandler(this.feeSubTitleBindingNavigatorSaveItem_Click);
            // 
            // feeSubTitleNameTextBox
            // 
            this.feeSubTitleNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeSubTitleBindingSource, "FeeSubTitleName", true));
            this.feeSubTitleNameTextBox.Location = new System.Drawing.Point(91, 58);
            this.feeSubTitleNameTextBox.Name = "feeSubTitleNameTextBox";
            this.feeSubTitleNameTextBox.Size = new System.Drawing.Size(393, 20);
            this.feeSubTitleNameTextBox.TabIndex = 7;
            // 
            // feeSubTitleDescriptionTextBox
            // 
            this.feeSubTitleDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeSubTitleBindingSource, "FeeSubTitleDescription", true));
            this.feeSubTitleDescriptionTextBox.Location = new System.Drawing.Point(91, 83);
            this.feeSubTitleDescriptionTextBox.Multiline = true;
            this.feeSubTitleDescriptionTextBox.Name = "feeSubTitleDescriptionTextBox";
            this.feeSubTitleDescriptionTextBox.Size = new System.Drawing.Size(393, 106);
            this.feeSubTitleDescriptionTextBox.TabIndex = 8;
            // 
            // feeTitleIdComboBox
            // 
            this.feeTitleIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.feeSubTitleBindingSource, "FeeTitleId", true));
            this.feeTitleIdComboBox.DataSource = this.feeTitleBindingSource;
            this.feeTitleIdComboBox.DisplayMember = "FeeTitleName";
            this.feeTitleIdComboBox.FormattingEnabled = true;
            this.feeTitleIdComboBox.Location = new System.Drawing.Point(91, 35);
            this.feeTitleIdComboBox.Name = "feeTitleIdComboBox";
            this.feeTitleIdComboBox.Size = new System.Drawing.Size(393, 21);
            this.feeTitleIdComboBox.TabIndex = 9;
            this.feeTitleIdComboBox.ValueMember = "FeeTitleId";
            // 
            // feeTitleBindingSource
            // 
            this.feeTitleBindingSource.DataSource = typeof(GenDataLayer.FeeTitle);
            // 
            // FeeSubTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 194);
            this.Controls.Add(this.feeTitleIdComboBox);
            this.Controls.Add(this.feeSubTitleDescriptionTextBox);
            this.Controls.Add(this.feeSubTitleNameTextBox);
            this.Controls.Add(this.feeSubTitleBindingNavigator);
            this.Controls.Add(feeSubTitleDescriptionLabel);
            this.Controls.Add(feeTitleNameLabel);
            this.Controls.Add(feeSubTitleNameLabel);
            this.Name = "FeeSubTitleForm";
            this.Text = "Fee Sub-Title ";
            this.Load += new System.EventHandler(this.FeeSubTitleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingNavigator)).EndInit();
            this.feeSubTitleBindingNavigator.ResumeLayout(false);
            this.feeSubTitleBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource feeSubTitleBindingSource;
        private System.Windows.Forms.BindingNavigator feeSubTitleBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton feeSubTitleBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox feeSubTitleNameTextBox;
        private System.Windows.Forms.TextBox feeSubTitleDescriptionTextBox;
        private System.Windows.Forms.ComboBox feeTitleIdComboBox;
        private System.Windows.Forms.BindingSource feeTitleBindingSource;

    }
}