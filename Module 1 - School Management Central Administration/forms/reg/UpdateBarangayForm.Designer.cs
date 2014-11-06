namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class UpdateBarangayForm
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
            System.Windows.Forms.Label munCityIdLabel;
            System.Windows.Forms.Label barangayNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateBarangayForm));
            this.barangayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barangayBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.barangayBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.munCityIdComboBox = new System.Windows.Forms.ComboBox();
            this.munCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barangayNameTextBox = new System.Windows.Forms.TextBox();
            munCityIdLabel = new System.Windows.Forms.Label();
            barangayNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingNavigator)).BeginInit();
            this.barangayBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // munCityIdLabel
            // 
            munCityIdLabel.AutoSize = true;
            munCityIdLabel.Location = new System.Drawing.Point(12, 43);
            munCityIdLabel.Name = "munCityIdLabel";
            munCityIdLabel.Size = new System.Drawing.Size(53, 13);
            munCityIdLabel.TabIndex = 1;
            munCityIdLabel.Text = "Mun/City:";
            // 
            // barangayNameLabel
            // 
            barangayNameLabel.AutoSize = true;
            barangayNameLabel.Location = new System.Drawing.Point(12, 68);
            barangayNameLabel.Name = "barangayNameLabel";
            barangayNameLabel.Size = new System.Drawing.Size(55, 13);
            barangayNameLabel.TabIndex = 3;
            barangayNameLabel.Text = "Barangay:";
            // 
            // barangayBindingSource
            // 
            this.barangayBindingSource.DataSource = typeof(GenDataLayer.Barangay);
            this.barangayBindingSource.CurrentChanged += new System.EventHandler(this.barangayBindingSource_CurrentChanged);
            // 
            // barangayBindingNavigator
            // 
            this.barangayBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.barangayBindingNavigator.BindingSource = this.barangayBindingSource;
            this.barangayBindingNavigator.CountItem = null;
            this.barangayBindingNavigator.DeleteItem = null;
            this.barangayBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.barangayBindingNavigatorSaveItem});
            this.barangayBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.barangayBindingNavigator.MoveFirstItem = null;
            this.barangayBindingNavigator.MoveLastItem = null;
            this.barangayBindingNavigator.MoveNextItem = null;
            this.barangayBindingNavigator.MovePreviousItem = null;
            this.barangayBindingNavigator.Name = "barangayBindingNavigator";
            this.barangayBindingNavigator.PositionItem = null;
            this.barangayBindingNavigator.Size = new System.Drawing.Size(539, 25);
            this.barangayBindingNavigator.TabIndex = 0;
            this.barangayBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(76, 22);
            this.bindingNavigatorAddNewItem.Text = "Add &New";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // barangayBindingNavigatorSaveItem
            // 
            this.barangayBindingNavigatorSaveItem.Enabled = false;
            this.barangayBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("barangayBindingNavigatorSaveItem.Image")));
            this.barangayBindingNavigatorSaveItem.Name = "barangayBindingNavigatorSaveItem";
            this.barangayBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.barangayBindingNavigatorSaveItem.Text = "&Save Data";
            this.barangayBindingNavigatorSaveItem.Click += new System.EventHandler(this.barangayBindingNavigatorSaveItem_Click);
            // 
            // munCityIdComboBox
            // 
            this.munCityIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.barangayBindingSource, "MunCityId", true));
            this.munCityIdComboBox.DataSource = this.munCityBindingSource;
            this.munCityIdComboBox.DisplayMember = "MunCityName";
            this.munCityIdComboBox.FormattingEnabled = true;
            this.munCityIdComboBox.Location = new System.Drawing.Point(81, 40);
            this.munCityIdComboBox.Name = "munCityIdComboBox";
            this.munCityIdComboBox.Size = new System.Drawing.Size(446, 21);
            this.munCityIdComboBox.TabIndex = 2;
            this.munCityIdComboBox.ValueMember = "MunCityId";
            // 
            // munCityBindingSource
            // 
            this.munCityBindingSource.DataSource = typeof(GenDataLayer.MunCity);
            // 
            // barangayNameTextBox
            // 
            this.barangayNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.barangayBindingSource, "BarangayName", true));
            this.barangayNameTextBox.Location = new System.Drawing.Point(81, 65);
            this.barangayNameTextBox.Name = "barangayNameTextBox";
            this.barangayNameTextBox.Size = new System.Drawing.Size(446, 20);
            this.barangayNameTextBox.TabIndex = 4;
            // 
            // UpdateBarangayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 104);
            this.Controls.Add(barangayNameLabel);
            this.Controls.Add(this.barangayNameTextBox);
            this.Controls.Add(munCityIdLabel);
            this.Controls.Add(this.munCityIdComboBox);
            this.Controls.Add(this.barangayBindingNavigator);
            this.Name = "UpdateBarangayForm";
            this.Text = "UpdateBarangayForm";
            this.Load += new System.EventHandler(this.UpdateBarangayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingNavigator)).EndInit();
            this.barangayBindingNavigator.ResumeLayout(false);
            this.barangayBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.munCityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource barangayBindingSource;
        private System.Windows.Forms.BindingNavigator barangayBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton barangayBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox munCityIdComboBox;
        private System.Windows.Forms.TextBox barangayNameTextBox;
        private System.Windows.Forms.BindingSource munCityBindingSource;
    }
}