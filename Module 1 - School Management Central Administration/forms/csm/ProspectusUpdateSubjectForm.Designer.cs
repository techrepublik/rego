namespace Module_1___School_Management_Central_Administration.forms.csm
{
    partial class ProspectusUpdateSubjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SubjectNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptiveTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Laboratory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.SubjectNo1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DescriptiveTitle1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lecture1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Laboratory1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAndOr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.subjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(872, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Module_1___School_Management_Central_Administration.Properties.Resources.Extensions;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(104, 22);
            this.toolStripButton1.Text = "Add Subject(s)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Module_1___School_Management_Central_Administration.Properties.Resources.Stop_2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "&Delete";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectNo,
            this.DescriptiveTitle,
            this.Lecture,
            this.Laboratory,
            this.Credit,
            this.Count});
            this.dataGridView1.Location = new System.Drawing.Point(5, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(855, 266);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // SubjectNo
            // 
            this.SubjectNo.HeaderText = "Subject No";
            this.SubjectNo.Name = "SubjectNo";
            this.SubjectNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DescriptiveTitle
            // 
            this.DescriptiveTitle.HeaderText = "Descriptive Title";
            this.DescriptiveTitle.Name = "DescriptiveTitle";
            this.DescriptiveTitle.Width = 450;
            // 
            // Lecture
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Lecture.DefaultCellStyle = dataGridViewCellStyle7;
            this.Lecture.HeaderText = "Lecture";
            this.Lecture.Name = "Lecture";
            this.Lecture.Width = 60;
            // 
            // Laboratory
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Laboratory.DefaultCellStyle = dataGridViewCellStyle8;
            this.Laboratory.HeaderText = "Laboratory";
            this.Laboratory.Name = "Laboratory";
            this.Laboratory.Width = 60;
            // 
            // Credit
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle9;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 60;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pre-requisite(s)";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectNo1,
            this.DescriptiveTitle1,
            this.Lecture1,
            this.Laboratory1,
            this.Credit1,
            this.IsAndOr,
            this.Note,
            this.PreId});
            this.dataGridView2.Location = new System.Drawing.Point(5, 317);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 30;
            this.dataGridView2.Size = new System.Drawing.Size(855, 174);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);
            this.dataGridView2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView2_EditingControlShowing);
            this.dataGridView2.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowLeave);
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // SubjectNo1
            // 
            this.SubjectNo1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SubjectNo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubjectNo1.HeaderText = "Subject No";
            this.SubjectNo1.Name = "SubjectNo1";
            this.SubjectNo1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubjectNo1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DescriptiveTitle1
            // 
            this.DescriptiveTitle1.HeaderText = "Descriptive Title";
            this.DescriptiveTitle1.Name = "DescriptiveTitle1";
            this.DescriptiveTitle1.Width = 250;
            // 
            // Lecture1
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Lecture1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Lecture1.HeaderText = "Lecture";
            this.Lecture1.Name = "Lecture1";
            this.Lecture1.Width = 80;
            // 
            // Laboratory1
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Laboratory1.DefaultCellStyle = dataGridViewCellStyle11;
            this.Laboratory1.HeaderText = "Laboratory";
            this.Laboratory1.Name = "Laboratory1";
            this.Laboratory1.Width = 80;
            // 
            // Credit1
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit1.DefaultCellStyle = dataGridViewCellStyle12;
            this.Credit1.HeaderText = "Credit";
            this.Credit1.Name = "Credit1";
            this.Credit1.Width = 80;
            // 
            // IsAndOr
            // 
            this.IsAndOr.HeaderText = "Or(And)";
            this.IsAndOr.Name = "IsAndOr";
            this.IsAndOr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAndOr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsAndOr.Width = 60;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.Width = 150;
            // 
            // PreId
            // 
            this.PreId.HeaderText = "PreId";
            this.PreId.Name = "PreId";
            this.PreId.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // subjectBindingSource
            // 
            this.subjectBindingSource.DataSource = typeof(GenDataLayer.Subject);
            // 
            // ProspectusUpdateSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProspectusUpdateSubjectForm";
            this.Text = "ProspectusUpdateSubjectForm";
            this.Load += new System.EventHandler(this.ProspectusUpdateSubjectForm_Load);
            this.Click += new System.EventHandler(this.ProspectusUpdateSubjectForm_Click);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource subjectBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptiveTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lecture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Laboratory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Count;
        private System.Windows.Forms.DataGridViewComboBoxColumn SubjectNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptiveTitle1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lecture1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Laboratory1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAndOr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreId;

    }
}