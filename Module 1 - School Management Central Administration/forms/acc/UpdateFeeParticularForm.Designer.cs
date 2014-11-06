namespace Module_1___School_Management_Central_Administration.forms.acc
{
    partial class UpdateFeeParticularForm
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
            System.Windows.Forms.Label particularsLabel;
            System.Windows.Forms.Label descriptionsLabel;
            System.Windows.Forms.Label isTuitionLabel;
            System.Windows.Forms.Label feeSubTitleNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFeeParticularForm));
            this.feeParticularsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feeParticularsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.feeParticularsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.particularsTextBox = new System.Windows.Forms.TextBox();
            this.descriptionsTextBox = new System.Windows.Forms.TextBox();
            this.isTuitionCheckBox = new System.Windows.Forms.CheckBox();
            this.feeSubTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feeSubTitleNameComboBox = new System.Windows.Forms.ComboBox();
            particularsLabel = new System.Windows.Forms.Label();
            descriptionsLabel = new System.Windows.Forms.Label();
            isTuitionLabel = new System.Windows.Forms.Label();
            feeSubTitleNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feeParticularsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeParticularsBindingNavigator)).BeginInit();
            this.feeParticularsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // particularsLabel
            // 
            particularsLabel.AutoSize = true;
            particularsLabel.Location = new System.Drawing.Point(12, 65);
            particularsLabel.Name = "particularsLabel";
            particularsLabel.Size = new System.Drawing.Size(59, 13);
            particularsLabel.TabIndex = 1;
            particularsLabel.Text = "Particulars:";
            // 
            // descriptionsLabel
            // 
            descriptionsLabel.AutoSize = true;
            descriptionsLabel.Location = new System.Drawing.Point(12, 88);
            descriptionsLabel.Name = "descriptionsLabel";
            descriptionsLabel.Size = new System.Drawing.Size(68, 13);
            descriptionsLabel.TabIndex = 3;
            descriptionsLabel.Text = "Descriptions:";
            // 
            // isTuitionLabel
            // 
            isTuitionLabel.AutoSize = true;
            isTuitionLabel.Location = new System.Drawing.Point(12, 179);
            isTuitionLabel.Name = "isTuitionLabel";
            isTuitionLabel.Size = new System.Drawing.Size(42, 13);
            isTuitionLabel.TabIndex = 5;
            isTuitionLabel.Text = "Tuition:";
            // 
            // feeSubTitleNameLabel
            // 
            feeSubTitleNameLabel.AutoSize = true;
            feeSubTitleNameLabel.Location = new System.Drawing.Point(12, 40);
            feeSubTitleNameLabel.Name = "feeSubTitleNameLabel";
            feeSubTitleNameLabel.Size = new System.Drawing.Size(73, 13);
            feeSubTitleNameLabel.TabIndex = 7;
            feeSubTitleNameLabel.Text = "Fee Sub-Title:";
            // 
            // feeParticularsBindingSource
            // 
            this.feeParticularsBindingSource.DataSource = typeof(System.Data.Objects.DataClasses.EntityCollection<GenDataLayer.FeeParticular>);
            this.feeParticularsBindingSource.CurrentChanged += new System.EventHandler(this.feeParticularsBindingSource_CurrentChanged);
            // 
            // feeParticularsBindingNavigator
            // 
            this.feeParticularsBindingNavigator.AddNewItem = null;
            this.feeParticularsBindingNavigator.BindingSource = this.feeParticularsBindingSource;
            this.feeParticularsBindingNavigator.CountItem = null;
            this.feeParticularsBindingNavigator.DeleteItem = null;
            this.feeParticularsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.feeParticularsBindingNavigatorSaveItem});
            this.feeParticularsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.feeParticularsBindingNavigator.MoveFirstItem = null;
            this.feeParticularsBindingNavigator.MoveLastItem = null;
            this.feeParticularsBindingNavigator.MoveNextItem = null;
            this.feeParticularsBindingNavigator.MovePreviousItem = null;
            this.feeParticularsBindingNavigator.Name = "feeParticularsBindingNavigator";
            this.feeParticularsBindingNavigator.PositionItem = null;
            this.feeParticularsBindingNavigator.Size = new System.Drawing.Size(492, 25);
            this.feeParticularsBindingNavigator.TabIndex = 0;
            this.feeParticularsBindingNavigator.Text = "bindingNavigator1";
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
            // feeParticularsBindingNavigatorSaveItem
            // 
            this.feeParticularsBindingNavigatorSaveItem.Enabled = false;
            this.feeParticularsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("feeParticularsBindingNavigatorSaveItem.Image")));
            this.feeParticularsBindingNavigatorSaveItem.Name = "feeParticularsBindingNavigatorSaveItem";
            this.feeParticularsBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.feeParticularsBindingNavigatorSaveItem.Text = "Save Data";
            this.feeParticularsBindingNavigatorSaveItem.Click += new System.EventHandler(this.feeParticularsBindingNavigatorSaveItem_Click);
            // 
            // particularsTextBox
            // 
            this.particularsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeParticularsBindingSource, "Particulars", true));
            this.particularsTextBox.Location = new System.Drawing.Point(90, 62);
            this.particularsTextBox.Name = "particularsTextBox";
            this.particularsTextBox.Size = new System.Drawing.Size(390, 20);
            this.particularsTextBox.TabIndex = 2;
            // 
            // descriptionsTextBox
            // 
            this.descriptionsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feeParticularsBindingSource, "Descriptions", true));
            this.descriptionsTextBox.Location = new System.Drawing.Point(90, 85);
            this.descriptionsTextBox.Multiline = true;
            this.descriptionsTextBox.Name = "descriptionsTextBox";
            this.descriptionsTextBox.Size = new System.Drawing.Size(390, 83);
            this.descriptionsTextBox.TabIndex = 4;
            // 
            // isTuitionCheckBox
            // 
            this.isTuitionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.feeParticularsBindingSource, "IsTuition", true));
            this.isTuitionCheckBox.Location = new System.Drawing.Point(90, 174);
            this.isTuitionCheckBox.Name = "isTuitionCheckBox";
            this.isTuitionCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isTuitionCheckBox.TabIndex = 6;
            this.isTuitionCheckBox.UseVisualStyleBackColor = true;
            // 
            // feeSubTitleBindingSource
            // 
            this.feeSubTitleBindingSource.DataSource = typeof(GenDataLayer.FeeSubTitle);
            // 
            // feeSubTitleNameComboBox
            // 
            this.feeSubTitleNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.feeParticularsBindingSource, "FeeSubTitleId", true));
            this.feeSubTitleNameComboBox.DataSource = this.feeSubTitleBindingSource;
            this.feeSubTitleNameComboBox.DisplayMember = "FeeSubTitleName";
            this.feeSubTitleNameComboBox.FormattingEnabled = true;
            this.feeSubTitleNameComboBox.Location = new System.Drawing.Point(90, 37);
            this.feeSubTitleNameComboBox.Name = "feeSubTitleNameComboBox";
            this.feeSubTitleNameComboBox.Size = new System.Drawing.Size(390, 21);
            this.feeSubTitleNameComboBox.TabIndex = 8;
            this.feeSubTitleNameComboBox.ValueMember = "FeeSubTitleId";
            // 
            // UpdateFeeParticularForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 211);
            this.Controls.Add(feeSubTitleNameLabel);
            this.Controls.Add(this.feeSubTitleNameComboBox);
            this.Controls.Add(isTuitionLabel);
            this.Controls.Add(this.isTuitionCheckBox);
            this.Controls.Add(descriptionsLabel);
            this.Controls.Add(this.descriptionsTextBox);
            this.Controls.Add(particularsLabel);
            this.Controls.Add(this.particularsTextBox);
            this.Controls.Add(this.feeParticularsBindingNavigator);
            this.Name = "UpdateFeeParticularForm";
            this.Text = "Update Fee Particular";
            this.Load += new System.EventHandler(this.UpdateFeeParticularForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feeParticularsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeParticularsBindingNavigator)).EndInit();
            this.feeParticularsBindingNavigator.ResumeLayout(false);
            this.feeParticularsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeSubTitleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource feeParticularsBindingSource;
        private System.Windows.Forms.BindingNavigator feeParticularsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton feeParticularsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox particularsTextBox;
        private System.Windows.Forms.TextBox descriptionsTextBox;
        private System.Windows.Forms.CheckBox isTuitionCheckBox;
        private System.Windows.Forms.BindingSource feeSubTitleBindingSource;
        private System.Windows.Forms.ComboBox feeSubTitleNameComboBox;


    }
}