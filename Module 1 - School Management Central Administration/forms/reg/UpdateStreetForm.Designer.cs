namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class UpdateStreetForm
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
            System.Windows.Forms.Label barangayIdLabel;
            System.Windows.Forms.Label streetNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateStreetForm));
            this.streetHousBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.streetHousBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.streetHousBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.barangayIdComboBox = new System.Windows.Forms.ComboBox();
            this.barangayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.streetNameTextBox = new System.Windows.Forms.TextBox();
            barangayIdLabel = new System.Windows.Forms.Label();
            streetNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.streetHousBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetHousBindingNavigator)).BeginInit();
            this.streetHousBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barangayIdLabel
            // 
            barangayIdLabel.AutoSize = true;
            barangayIdLabel.Location = new System.Drawing.Point(6, 41);
            barangayIdLabel.Name = "barangayIdLabel";
            barangayIdLabel.Size = new System.Drawing.Size(55, 13);
            barangayIdLabel.TabIndex = 1;
            barangayIdLabel.Text = "Barangay:";
            // 
            // streetNameLabel
            // 
            streetNameLabel.AutoSize = true;
            streetNameLabel.Location = new System.Drawing.Point(6, 65);
            streetNameLabel.Name = "streetNameLabel";
            streetNameLabel.Size = new System.Drawing.Size(69, 13);
            streetNameLabel.TabIndex = 3;
            streetNameLabel.Text = "Street Name:";
            // 
            // streetHousBindingSource
            // 
            this.streetHousBindingSource.DataSource = typeof(GenDataLayer.StreetHous);
            this.streetHousBindingSource.CurrentChanged += new System.EventHandler(this.streetHousBindingSource_CurrentChanged);
            // 
            // streetHousBindingNavigator
            // 
            this.streetHousBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.streetHousBindingNavigator.BindingSource = this.streetHousBindingSource;
            this.streetHousBindingNavigator.CountItem = null;
            this.streetHousBindingNavigator.DeleteItem = null;
            this.streetHousBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.streetHousBindingNavigatorSaveItem});
            this.streetHousBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.streetHousBindingNavigator.MoveFirstItem = null;
            this.streetHousBindingNavigator.MoveLastItem = null;
            this.streetHousBindingNavigator.MoveNextItem = null;
            this.streetHousBindingNavigator.MovePreviousItem = null;
            this.streetHousBindingNavigator.Name = "streetHousBindingNavigator";
            this.streetHousBindingNavigator.PositionItem = null;
            this.streetHousBindingNavigator.Size = new System.Drawing.Size(531, 25);
            this.streetHousBindingNavigator.TabIndex = 0;
            this.streetHousBindingNavigator.Text = "bindingNavigator1";
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
            // streetHousBindingNavigatorSaveItem
            // 
            this.streetHousBindingNavigatorSaveItem.Enabled = false;
            this.streetHousBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("streetHousBindingNavigatorSaveItem.Image")));
            this.streetHousBindingNavigatorSaveItem.Name = "streetHousBindingNavigatorSaveItem";
            this.streetHousBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.streetHousBindingNavigatorSaveItem.Text = "Save &Data";
            this.streetHousBindingNavigatorSaveItem.Click += new System.EventHandler(this.streetHousBindingNavigatorSaveItem_Click);
            // 
            // barangayIdComboBox
            // 
            this.barangayIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.streetHousBindingSource, "BarangayId", true));
            this.barangayIdComboBox.DataSource = this.barangayBindingSource;
            this.barangayIdComboBox.DisplayMember = "BarangayName";
            this.barangayIdComboBox.FormattingEnabled = true;
            this.barangayIdComboBox.Location = new System.Drawing.Point(81, 38);
            this.barangayIdComboBox.Name = "barangayIdComboBox";
            this.barangayIdComboBox.Size = new System.Drawing.Size(438, 21);
            this.barangayIdComboBox.TabIndex = 2;
            this.barangayIdComboBox.ValueMember = "BarangayId";
            // 
            // barangayBindingSource
            // 
            this.barangayBindingSource.DataSource = typeof(GenDataLayer.Barangay);
            // 
            // streetNameTextBox
            // 
            this.streetNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.streetHousBindingSource, "StreetName", true));
            this.streetNameTextBox.Location = new System.Drawing.Point(81, 62);
            this.streetNameTextBox.Name = "streetNameTextBox";
            this.streetNameTextBox.Size = new System.Drawing.Size(438, 20);
            this.streetNameTextBox.TabIndex = 4;
            // 
            // UpdateStreetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 102);
            this.Controls.Add(streetNameLabel);
            this.Controls.Add(this.streetNameTextBox);
            this.Controls.Add(barangayIdLabel);
            this.Controls.Add(this.barangayIdComboBox);
            this.Controls.Add(this.streetHousBindingNavigator);
            this.Name = "UpdateStreetForm";
            this.Text = "UpdateStreetForm";
            this.Load += new System.EventHandler(this.UpdateStreetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.streetHousBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streetHousBindingNavigator)).EndInit();
            this.streetHousBindingNavigator.ResumeLayout(false);
            this.streetHousBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barangayBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource streetHousBindingSource;
        private System.Windows.Forms.BindingNavigator streetHousBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton streetHousBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox barangayIdComboBox;
        private System.Windows.Forms.TextBox streetNameTextBox;
        private System.Windows.Forms.BindingSource barangayBindingSource;
    }
}