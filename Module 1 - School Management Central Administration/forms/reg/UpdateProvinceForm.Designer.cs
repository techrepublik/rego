namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class UpdateProvinceForm
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
            System.Windows.Forms.Label provinceNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProvinceForm));
            this.provinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinceBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.provinceBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.provinceNameTextBox = new System.Windows.Forms.TextBox();
            provinceNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingNavigator)).BeginInit();
            this.provinceBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // provinceNameLabel
            // 
            provinceNameLabel.AutoSize = true;
            provinceNameLabel.Location = new System.Drawing.Point(12, 48);
            provinceNameLabel.Name = "provinceNameLabel";
            provinceNameLabel.Size = new System.Drawing.Size(83, 13);
            provinceNameLabel.TabIndex = 1;
            provinceNameLabel.Text = "Province Name:";
            // 
            // provinceBindingSource
            // 
            this.provinceBindingSource.DataSource = typeof(GenDataLayer.Province);
            this.provinceBindingSource.CurrentChanged += new System.EventHandler(this.provinceBindingSource_CurrentChanged);
            // 
            // provinceBindingNavigator
            // 
            this.provinceBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.provinceBindingNavigator.BindingSource = this.provinceBindingSource;
            this.provinceBindingNavigator.CountItem = null;
            this.provinceBindingNavigator.DeleteItem = null;
            this.provinceBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.provinceBindingNavigatorSaveItem});
            this.provinceBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.provinceBindingNavigator.MoveFirstItem = null;
            this.provinceBindingNavigator.MoveLastItem = null;
            this.provinceBindingNavigator.MoveNextItem = null;
            this.provinceBindingNavigator.MovePreviousItem = null;
            this.provinceBindingNavigator.Name = "provinceBindingNavigator";
            this.provinceBindingNavigator.PositionItem = null;
            this.provinceBindingNavigator.Size = new System.Drawing.Size(552, 25);
            this.provinceBindingNavigator.TabIndex = 0;
            this.provinceBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(76, 22);
            this.bindingNavigatorAddNewItem.Text = "Add &New";
            // 
            // provinceBindingNavigatorSaveItem
            // 
            this.provinceBindingNavigatorSaveItem.Enabled = false;
            this.provinceBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("provinceBindingNavigatorSaveItem.Image")));
            this.provinceBindingNavigatorSaveItem.Name = "provinceBindingNavigatorSaveItem";
            this.provinceBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.provinceBindingNavigatorSaveItem.Text = "&Save Data";
            this.provinceBindingNavigatorSaveItem.Click += new System.EventHandler(this.provinceBindingNavigatorSaveItem_Click);
            // 
            // provinceNameTextBox
            // 
            this.provinceNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.provinceBindingSource, "ProvinceName", true));
            this.provinceNameTextBox.Location = new System.Drawing.Point(101, 45);
            this.provinceNameTextBox.Name = "provinceNameTextBox";
            this.provinceNameTextBox.Size = new System.Drawing.Size(439, 20);
            this.provinceNameTextBox.TabIndex = 2;
            // 
            // UpdateProvinceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 95);
            this.Controls.Add(provinceNameLabel);
            this.Controls.Add(this.provinceNameTextBox);
            this.Controls.Add(this.provinceBindingNavigator);
            this.Name = "UpdateProvinceForm";
            this.Text = "UpdateProvinceForm";
            this.Load += new System.EventHandler(this.UpdateProvinceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingNavigator)).EndInit();
            this.provinceBindingNavigator.ResumeLayout(false);
            this.provinceBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource provinceBindingSource;
        private System.Windows.Forms.BindingNavigator provinceBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton provinceBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox provinceNameTextBox;
    }
}