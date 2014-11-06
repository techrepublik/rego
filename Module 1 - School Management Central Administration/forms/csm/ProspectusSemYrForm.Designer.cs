namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class ProspectusSemYrForm
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
            System.Windows.Forms.Label semesterNameLabel;
            System.Windows.Forms.Label semesterLabel;
            System.Windows.Forms.Label syLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label prospectusIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectusSemYrForm));
            this.prospectusSemYrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prospectusSemYrBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.prospectusSemYrBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.semesterNameTextBox = new System.Windows.Forms.TextBox();
            this.semesterTextBox = new System.Windows.Forms.TextBox();
            this.syTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.prospectusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            semesterNameLabel = new System.Windows.Forms.Label();
            semesterLabel = new System.Windows.Forms.Label();
            syLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            prospectusIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusSemYrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusSemYrBindingNavigator)).BeginInit();
            this.prospectusSemYrBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // semesterNameLabel
            // 
            semesterNameLabel.AutoSize = true;
            semesterNameLabel.Location = new System.Drawing.Point(12, 65);
            semesterNameLabel.Name = "semesterNameLabel";
            semesterNameLabel.Size = new System.Drawing.Size(85, 13);
            semesterNameLabel.TabIndex = 1;
            semesterNameLabel.Text = "Semester Name:";
            // 
            // semesterLabel
            // 
            semesterLabel.AutoSize = true;
            semesterLabel.Location = new System.Drawing.Point(12, 92);
            semesterLabel.Name = "semesterLabel";
            semesterLabel.Size = new System.Drawing.Size(54, 13);
            semesterLabel.TabIndex = 3;
            semesterLabel.Text = "Semester:";
            // 
            // syLabel
            // 
            syLabel.AutoSize = true;
            syLabel.Location = new System.Drawing.Point(12, 118);
            syLabel.Name = "syLabel";
            syLabel.Size = new System.Drawing.Size(62, 13);
            syLabel.TabIndex = 5;
            syLabel.Text = "Year Lever:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(12, 142);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(33, 13);
            noteLabel.TabIndex = 7;
            noteLabel.Text = "Note:";
            // 
            // prospectusIdLabel
            // 
            prospectusIdLabel.AutoSize = true;
            prospectusIdLabel.Location = new System.Drawing.Point(12, 41);
            prospectusIdLabel.Name = "prospectusIdLabel";
            prospectusIdLabel.Size = new System.Drawing.Size(63, 13);
            prospectusIdLabel.TabIndex = 9;
            prospectusIdLabel.Text = "Prospectus:";
            // 
            // prospectusSemYrBindingSource
            // 
            this.prospectusSemYrBindingSource.DataSource = typeof(GenDataLayer.ProspectusSemYr);
            this.prospectusSemYrBindingSource.CurrentChanged += new System.EventHandler(this.prospectusSemYrBindingSource_CurrentChanged);
            // 
            // prospectusSemYrBindingNavigator
            // 
            this.prospectusSemYrBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.prospectusSemYrBindingNavigator.BindingSource = this.prospectusSemYrBindingSource;
            this.prospectusSemYrBindingNavigator.CountItem = null;
            this.prospectusSemYrBindingNavigator.DeleteItem = null;
            this.prospectusSemYrBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.prospectusSemYrBindingNavigatorSaveItem});
            this.prospectusSemYrBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.prospectusSemYrBindingNavigator.MoveFirstItem = null;
            this.prospectusSemYrBindingNavigator.MoveLastItem = null;
            this.prospectusSemYrBindingNavigator.MoveNextItem = null;
            this.prospectusSemYrBindingNavigator.MovePreviousItem = null;
            this.prospectusSemYrBindingNavigator.Name = "prospectusSemYrBindingNavigator";
            this.prospectusSemYrBindingNavigator.PositionItem = null;
            this.prospectusSemYrBindingNavigator.Size = new System.Drawing.Size(557, 25);
            this.prospectusSemYrBindingNavigator.TabIndex = 0;
            this.prospectusSemYrBindingNavigator.Text = "bindingNavigator1";
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
            // prospectusSemYrBindingNavigatorSaveItem
            // 
            this.prospectusSemYrBindingNavigatorSaveItem.Enabled = false;
            this.prospectusSemYrBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("prospectusSemYrBindingNavigatorSaveItem.Image")));
            this.prospectusSemYrBindingNavigatorSaveItem.Name = "prospectusSemYrBindingNavigatorSaveItem";
            this.prospectusSemYrBindingNavigatorSaveItem.Size = new System.Drawing.Size(78, 22);
            this.prospectusSemYrBindingNavigatorSaveItem.Text = "Save Data";
            this.prospectusSemYrBindingNavigatorSaveItem.Click += new System.EventHandler(this.prospectusSemYrBindingNavigatorSaveItem_Click);
            // 
            // semesterNameTextBox
            // 
            this.semesterNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusSemYrBindingSource, "SemesterName", true));
            this.semesterNameTextBox.Location = new System.Drawing.Point(103, 65);
            this.semesterNameTextBox.Name = "semesterNameTextBox";
            this.semesterNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.semesterNameTextBox.TabIndex = 2;
            // 
            // semesterTextBox
            // 
            this.semesterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusSemYrBindingSource, "Semester", true));
            this.semesterTextBox.Location = new System.Drawing.Point(103, 89);
            this.semesterTextBox.Name = "semesterTextBox";
            this.semesterTextBox.Size = new System.Drawing.Size(189, 20);
            this.semesterTextBox.TabIndex = 4;
            // 
            // syTextBox
            // 
            this.syTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusSemYrBindingSource, "Sy", true));
            this.syTextBox.Location = new System.Drawing.Point(103, 113);
            this.syTextBox.Name = "syTextBox";
            this.syTextBox.Size = new System.Drawing.Size(189, 20);
            this.syTextBox.TabIndex = 6;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prospectusSemYrBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(103, 139);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(434, 93);
            this.noteTextBox.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.prospectusSemYrBindingSource, "ProspectusId", true));
            this.comboBox1.DataSource = this.prospectusBindingSource;
            this.comboBox1.DisplayMember = "ProspectusName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(434, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.ValueMember = "ProspectusId";
            // 
            // prospectusBindingSource
            // 
            this.prospectusBindingSource.DataSource = typeof(GenDataLayer.Prospectus);
            // 
            // ProspectusSemYrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 244);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(prospectusIdLabel);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(syLabel);
            this.Controls.Add(this.syTextBox);
            this.Controls.Add(semesterLabel);
            this.Controls.Add(this.semesterTextBox);
            this.Controls.Add(semesterNameLabel);
            this.Controls.Add(this.semesterNameTextBox);
            this.Controls.Add(this.prospectusSemYrBindingNavigator);
            this.Name = "ProspectusSemYrForm";
            this.Text = "Prospectus SemYr Form";
            this.Load += new System.EventHandler(this.ProspectusSemYrForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prospectusSemYrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusSemYrBindingNavigator)).EndInit();
            this.prospectusSemYrBindingNavigator.ResumeLayout(false);
            this.prospectusSemYrBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prospectusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource prospectusSemYrBindingSource;
        private System.Windows.Forms.BindingNavigator prospectusSemYrBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton prospectusSemYrBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox semesterNameTextBox;
        private System.Windows.Forms.TextBox semesterTextBox;
        private System.Windows.Forms.TextBox syTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource prospectusBindingSource;
    }
}