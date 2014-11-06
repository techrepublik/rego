namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class UpdateMunCityForm
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
            System.Windows.Forms.Label provinceIdLabel;
            System.Windows.Forms.Label munCityNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMunCityForm));
            this.munCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.munCityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.munCityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.provinceIdComboBox = new System.Windows.Forms.ComboBox();
            this.provinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.munCityNameTextBox = new System.Windows.Forms.TextBox();
            provinceIdLabel = new System.Windows.Forms.Label();
            munCityNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingNavigator)).BeginInit();
            this.munCityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // provinceIdLabel
            // 
            provinceIdLabel.AutoSize = true;
            provinceIdLabel.Location = new System.Drawing.Point(12, 45);
            provinceIdLabel.Name = "provinceIdLabel";
            provinceIdLabel.Size = new System.Drawing.Size(52, 13);
            provinceIdLabel.TabIndex = 1;
            provinceIdLabel.Text = "Province:";
            // 
            // munCityNameLabel
            // 
            munCityNameLabel.AutoSize = true;
            munCityNameLabel.Location = new System.Drawing.Point(12, 71);
            munCityNameLabel.Name = "munCityNameLabel";
            munCityNameLabel.Size = new System.Drawing.Size(53, 13);
            munCityNameLabel.TabIndex = 3;
            munCityNameLabel.Text = "Mun/City:";
            // 
            // munCityBindingSource
            // 
            this.munCityBindingSource.DataSource = typeof(GenDataLayer.MunCity);
            this.munCityBindingSource.CurrentChanged += new System.EventHandler(this.munCityBindingSource_CurrentChanged);
            // 
            // munCityBindingNavigator
            // 
            this.munCityBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.munCityBindingNavigator.BindingSource = this.munCityBindingSource;
            this.munCityBindingNavigator.CountItem = null;
            this.munCityBindingNavigator.DeleteItem = null;
            this.munCityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.munCityBindingNavigatorSaveItem});
            this.munCityBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.munCityBindingNavigator.MoveFirstItem = null;
            this.munCityBindingNavigator.MoveLastItem = null;
            this.munCityBindingNavigator.MoveNextItem = null;
            this.munCityBindingNavigator.MovePreviousItem = null;
            this.munCityBindingNavigator.Name = "munCityBindingNavigator";
            this.munCityBindingNavigator.PositionItem = null;
            this.munCityBindingNavigator.Size = new System.Drawing.Size(539, 25);
            this.munCityBindingNavigator.TabIndex = 0;
            this.munCityBindingNavigator.Text = "bindingNavigator1";
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
            // munCityBindingNavigatorSaveItem
            // 
            this.munCityBindingNavigatorSaveItem.Enabled = false;
            this.munCityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("munCityBindingNavigatorSaveItem.Image")));
            this.munCityBindingNavigatorSaveItem.Name = "munCityBindingNavigatorSaveItem";
            this.munCityBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.munCityBindingNavigatorSaveItem.Text = "Save Data";
            this.munCityBindingNavigatorSaveItem.Click += new System.EventHandler(this.munCityBindingNavigatorSaveItem_Click);
            // 
            // provinceIdComboBox
            // 
            this.provinceIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.munCityBindingSource, "ProvinceId", true));
            this.provinceIdComboBox.DataSource = this.provinceBindingSource;
            this.provinceIdComboBox.DisplayMember = "ProvinceName";
            this.provinceIdComboBox.FormattingEnabled = true;
            this.provinceIdComboBox.Location = new System.Drawing.Point(71, 42);
            this.provinceIdComboBox.Name = "provinceIdComboBox";
            this.provinceIdComboBox.Size = new System.Drawing.Size(457, 21);
            this.provinceIdComboBox.TabIndex = 2;
            this.provinceIdComboBox.ValueMember = "ProvinceId";
            // 
            // provinceBindingSource
            // 
            this.provinceBindingSource.DataSource = typeof(GenDataLayer.Province);
            // 
            // munCityNameTextBox
            // 
            this.munCityNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.munCityBindingSource, "MunCityName", true));
            this.munCityNameTextBox.Location = new System.Drawing.Point(71, 68);
            this.munCityNameTextBox.Name = "munCityNameTextBox";
            this.munCityNameTextBox.Size = new System.Drawing.Size(456, 20);
            this.munCityNameTextBox.TabIndex = 4;
            // 
            // UpdateMunCityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 113);
            this.Controls.Add(munCityNameLabel);
            this.Controls.Add(this.munCityNameTextBox);
            this.Controls.Add(provinceIdLabel);
            this.Controls.Add(this.provinceIdComboBox);
            this.Controls.Add(this.munCityBindingNavigator);
            this.Name = "UpdateMunCityForm";
            this.Text = "UpdateMunCityForm";
            this.Load += new System.EventHandler(this.UpdateMunCityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingNavigator)).EndInit();
            this.munCityBindingNavigator.ResumeLayout(false);
            this.munCityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource munCityBindingSource;
        private System.Windows.Forms.BindingNavigator munCityBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton munCityBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox provinceIdComboBox;
        private System.Windows.Forms.TextBox munCityNameTextBox;
        private System.Windows.Forms.BindingSource provinceBindingSource;
    }
}