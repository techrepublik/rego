namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class UpdateFeeTitleForm
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
            System.Windows.Forms.Label feeTitleNameLabel;
            System.Windows.Forms.Label feeTitleDescriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFeeTitleForm));
            this.feeTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feeTitleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.feeTitleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.feeTitleNameTextBox = new System.Windows.Forms.TextBox();
            this.feeTitleDescriptionTextBox = new System.Windows.Forms.TextBox();
            feeTitleNameLabel = new System.Windows.Forms.Label();
            feeTitleDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingNavigator)).BeginInit();
            this.feeTitleBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // feeTitleNameLabel
            // 
            feeTitleNameLabel.AutoSize = true;
            feeTitleNameLabel.Location = new System.Drawing.Point(12, 40);
            feeTitleNameLabel.Name = "feeTitleNameLabel";
            feeTitleNameLabel.Size = new System.Drawing.Size(51, 13);
            feeTitleNameLabel.TabIndex = 1;
            feeTitleNameLabel.Text = "Fee Title:";
            // 
            // feeTitleDescriptionLabel
            // 
            feeTitleDescriptionLabel.AutoSize = true;
            feeTitleDescriptionLabel.Location = new System.Drawing.Point(12, 64);
            feeTitleDescriptionLabel.Name = "feeTitleDescriptionLabel";
            feeTitleDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            feeTitleDescriptionLabel.TabIndex = 3;
            feeTitleDescriptionLabel.Text = "Description:";
            // 
            // feeTitleBindingSource
            // 
            this.feeTitleBindingSource.DataSource = typeof(GenDataLayer.FeeTitle);
            this.feeTitleBindingSource.CurrentChanged += new System.EventHandler(this.feeTitleBindingSource_CurrentChanged);
            // 
            // feeTitleBindingNavigator
            // 
            this.feeTitleBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.feeTitleBindingNavigator.BindingSource = this.feeTitleBindingSource;
            this.feeTitleBindingNavigator.CountItem = null;
            this.feeTitleBindingNavigator.DeleteItem = null;
            this.feeTitleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.feeTitleBindingNavigatorSaveItem});
            this.feeTitleBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.feeTitleBindingNavigator.MoveFirstItem = null;
            this.feeTitleBindingNavigator.MoveLastItem = null;
            this.feeTitleBindingNavigator.MoveNextItem = null;
            this.feeTitleBindingNavigator.MovePreviousItem = null;
            this.feeTitleBindingNavigator.Name = "feeTitleBindingNavigator";
            this.feeTitleBindingNavigator.PositionItem = null;
            this.feeTitleBindingNavigator.Size = new System.Drawing.Size(487, 25);
            this.feeTitleBindingNavigator.TabIndex = 0;
            this.feeTitleBindingNavigator.Text = "bindingNavigator1";
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
            // feeTitleBindingNavigatorSaveItem
            // 
            this.feeTitleBindingNavigatorSaveItem.Enabled = false;
            this.feeTitleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("feeTitleBindingNavigatorSaveItem.Image")));
            this.feeTitleBindingNavigatorSaveItem.Name = "feeTitleBindingNavigatorSaveItem";
            this.feeTitleBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.feeTitleBindingNavigatorSaveItem.Text = "Save Data";
            this.feeTitleBindingNavigatorSaveItem.Click += new System.EventHandler(this.feeTitleBindingNavigatorSaveItem_Click);
            // 
            // feeTitleNameTextBox
            // 
            this.feeTitleNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeTitleBindingSource, "FeeTitleName", true));
            this.feeTitleNameTextBox.Location = new System.Drawing.Point(93, 37);
            this.feeTitleNameTextBox.Name = "feeTitleNameTextBox";
            this.feeTitleNameTextBox.Size = new System.Drawing.Size(387, 20);
            this.feeTitleNameTextBox.TabIndex = 2;
            // 
            // feeTitleDescriptionTextBox
            // 
            this.feeTitleDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeTitleBindingSource, "FeeTitleDescription", true));
            this.feeTitleDescriptionTextBox.Location = new System.Drawing.Point(93, 61);
            this.feeTitleDescriptionTextBox.Multiline = true;
            this.feeTitleDescriptionTextBox.Name = "feeTitleDescriptionTextBox";
            this.feeTitleDescriptionTextBox.Size = new System.Drawing.Size(387, 103);
            this.feeTitleDescriptionTextBox.TabIndex = 4;
            // 
            // UpdateFeeTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 172);
            this.Controls.Add(feeTitleDescriptionLabel);
            this.Controls.Add(this.feeTitleDescriptionTextBox);
            this.Controls.Add(feeTitleNameLabel);
            this.Controls.Add(this.feeTitleNameTextBox);
            this.Controls.Add(this.feeTitleBindingNavigator);
            this.Name = "UpdateFeeTitleForm";
            this.Text = "Update Fee Title Form";
            this.Load += new System.EventHandler(this.UpdateFeeTitleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeTitleBindingNavigator)).EndInit();
            this.feeTitleBindingNavigator.ResumeLayout(false);
            this.feeTitleBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource feeTitleBindingSource;
        private System.Windows.Forms.BindingNavigator feeTitleBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton feeTitleBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox feeTitleNameTextBox;
        private System.Windows.Forms.TextBox feeTitleDescriptionTextBox;
    }
}