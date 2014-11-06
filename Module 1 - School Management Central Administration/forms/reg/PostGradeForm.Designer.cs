namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class PostGradeForm
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
            System.Windows.Forms.Label postGradeNoLabel;
            System.Windows.Forms.Label postGradeDateLabel;
            System.Windows.Forms.Label postGradeNoteLabel;
            System.Windows.Forms.Label label1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.postGradeNoTextBox = new System.Windows.Forms.TextBox();
            this.postGradeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postGradeDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.postGradeNoteTextBox = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.postModeIdComboBox = new System.Windows.Forms.ComboBox();
            this.postModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            postGradeNoLabel = new System.Windows.Forms.Label();
            postGradeDateLabel = new System.Windows.Forms.Label();
            postGradeNoteLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postModeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // postGradeNoLabel
            // 
            postGradeNoLabel.AutoSize = true;
            postGradeNoLabel.Location = new System.Drawing.Point(7, 64);
            postGradeNoLabel.Name = "postGradeNoLabel";
            postGradeNoLabel.Size = new System.Drawing.Size(48, 13);
            postGradeNoLabel.TabIndex = 6;
            postGradeNoLabel.Text = "Post No:";
            // 
            // postGradeDateLabel
            // 
            postGradeDateLabel.AutoSize = true;
            postGradeDateLabel.Location = new System.Drawing.Point(7, 90);
            postGradeDateLabel.Name = "postGradeDateLabel";
            postGradeDateLabel.Size = new System.Drawing.Size(57, 13);
            postGradeDateLabel.TabIndex = 7;
            postGradeDateLabel.Text = "Post Date:";
            // 
            // postGradeNoteLabel
            // 
            postGradeNoteLabel.AutoSize = true;
            postGradeNoteLabel.Location = new System.Drawing.Point(6, 144);
            postGradeNoteLabel.Name = "postGradeNoteLabel";
            postGradeNoteLabel.Size = new System.Drawing.Size(57, 13);
            postGradeNoteLabel.TabIndex = 9;
            postGradeNoteLabel.Text = "Post Note:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 44);
            this.panel1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(508, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // postGradeNoTextBox
            // 
            this.postGradeNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postGradeBindingSource, "PostGradeNo", true));
            this.postGradeNoTextBox.Location = new System.Drawing.Point(93, 61);
            this.postGradeNoTextBox.Name = "postGradeNoTextBox";
            this.postGradeNoTextBox.Size = new System.Drawing.Size(132, 20);
            this.postGradeNoTextBox.TabIndex = 0;
            // 
            // postGradeBindingSource
            // 
            this.postGradeBindingSource.DataSource = typeof(GenDataLayer.PostGrade);
            // 
            // postGradeDateDateTimePicker
            // 
            this.postGradeDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.postGradeBindingSource, "PostGradeDate", true));
            this.postGradeDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.postGradeDateDateTimePicker.Location = new System.Drawing.Point(93, 86);
            this.postGradeDateDateTimePicker.Name = "postGradeDateDateTimePicker";
            this.postGradeDateDateTimePicker.Size = new System.Drawing.Size(132, 20);
            this.postGradeDateDateTimePicker.TabIndex = 1;
            // 
            // postGradeNoteTextBox
            // 
            this.postGradeNoteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postGradeBindingSource, "PostGradeNote", true));
            this.postGradeNoteTextBox.Location = new System.Drawing.Point(92, 141);
            this.postGradeNoteTextBox.Multiline = true;
            this.postGradeNoteTextBox.Name = "postGradeNoteTextBox";
            this.postGradeNoteTextBox.Size = new System.Drawing.Size(396, 91);
            this.postGradeNoteTextBox.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(398, 242);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(90, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 116);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 13);
            label1.TabIndex = 10;
            label1.Text = "Post Mode:";
            // 
            // postModeIdComboBox
            // 
            this.postModeIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.postGradeBindingSource, "PostModeId", true));
            this.postModeIdComboBox.DataSource = this.postModeBindingSource;
            this.postModeIdComboBox.DisplayMember = "PostModeName";
            this.postModeIdComboBox.FormattingEnabled = true;
            this.postModeIdComboBox.Location = new System.Drawing.Point(92, 113);
            this.postModeIdComboBox.Name = "postModeIdComboBox";
            this.postModeIdComboBox.Size = new System.Drawing.Size(239, 21);
            this.postModeIdComboBox.TabIndex = 2;
            this.postModeIdComboBox.ValueMember = "PostModeId";
            // 
            // postModeBindingSource
            // 
            this.postModeBindingSource.DataSource = typeof(GenDataLayer.PostMode);
            // 
            // PostGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 304);
            this.Controls.Add(this.postModeIdComboBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(postGradeNoteLabel);
            this.Controls.Add(this.postGradeNoteTextBox);
            this.Controls.Add(postGradeDateLabel);
            this.Controls.Add(this.postGradeDateDateTimePicker);
            this.Controls.Add(postGradeNoLabel);
            this.Controls.Add(this.postGradeNoTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "PostGradeForm";
            this.Text = "Post Grade";
            this.Load += new System.EventHandler(this.PostGradeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postGradeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postModeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.BindingSource postGradeBindingSource;
        private System.Windows.Forms.TextBox postGradeNoTextBox;
        private System.Windows.Forms.DateTimePicker postGradeDateDateTimePicker;
        private System.Windows.Forms.TextBox postGradeNoteTextBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox postModeIdComboBox;
        private System.Windows.Forms.BindingSource postModeBindingSource;
    }
}