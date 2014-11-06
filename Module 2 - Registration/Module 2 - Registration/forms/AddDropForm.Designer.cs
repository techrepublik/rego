namespace Module_2___Registration.forms
{
    partial class AddDropForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonRemoveRow = new System.Windows.Forms.Button();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptiveTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisteredScheduleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Dropped = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Regular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotalUnits = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 39);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTotalUnits);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonRemoveRow);
            this.panel2.Controls.Add(this.buttonAddRow);
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 31);
            this.panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Code,
            this.SubjectNo,
            this.DescriptiveTitle,
            this.Units,
            this.Schedule,
            this.ScheduleId,
            this.RegisteredScheduleId,
            this.Added,
            this.Dropped,
            this.Regular});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1141, 372);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(1002, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(135, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(775, 4);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(91, 23);
            this.buttonAddRow.TabIndex = 1;
            this.buttonAddRow.Text = "&Add Row";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonRemoveRow
            // 
            this.buttonRemoveRow.Location = new System.Drawing.Point(872, 4);
            this.buttonRemoveRow.Name = "buttonRemoveRow";
            this.buttonRemoveRow.Size = new System.Drawing.Size(91, 23);
            this.buttonRemoveRow.TabIndex = 2;
            this.buttonRemoveRow.Text = "&Remove Row";
            this.buttonRemoveRow.UseVisualStyleBackColor = true;
            this.buttonRemoveRow.Click += new System.EventHandler(this.buttonRemoveRow_Click);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.Width = 40;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Code.Width = 80;
            // 
            // SubjectNo
            // 
            this.SubjectNo.HeaderText = "Subject No";
            this.SubjectNo.Name = "SubjectNo";
            this.SubjectNo.ReadOnly = true;
            // 
            // DescriptiveTitle
            // 
            this.DescriptiveTitle.HeaderText = "Descriptive Title";
            this.DescriptiveTitle.Name = "DescriptiveTitle";
            this.DescriptiveTitle.ReadOnly = true;
            this.DescriptiveTitle.Width = 250;
            // 
            // Units
            // 
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            this.Units.ReadOnly = true;
            this.Units.Width = 60;
            // 
            // Schedule
            // 
            this.Schedule.HeaderText = "Schedule";
            this.Schedule.Name = "Schedule";
            this.Schedule.ReadOnly = true;
            this.Schedule.Width = 400;
            // 
            // ScheduleId
            // 
            this.ScheduleId.HeaderText = "ScheduleId";
            this.ScheduleId.Name = "ScheduleId";
            this.ScheduleId.Visible = false;
            // 
            // RegisteredScheduleId
            // 
            this.RegisteredScheduleId.HeaderText = "RegisteredScheduleId";
            this.RegisteredScheduleId.Name = "RegisteredScheduleId";
            this.RegisteredScheduleId.Visible = false;
            // 
            // Added
            // 
            this.Added.HeaderText = "Added";
            this.Added.Name = "Added";
            this.Added.ReadOnly = true;
            this.Added.Width = 50;
            // 
            // Dropped
            // 
            this.Dropped.HeaderText = "Dropped";
            this.Dropped.Name = "Dropped";
            this.Dropped.Width = 50;
            // 
            // Regular
            // 
            this.Regular.HeaderText = "Regular";
            this.Regular.Name = "Regular";
            this.Regular.ReadOnly = true;
            this.Regular.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Units:: Credit (Dropped):";
            // 
            // labelTotalUnits
            // 
            this.labelTotalUnits.AutoSize = true;
            this.labelTotalUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalUnits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelTotalUnits.Location = new System.Drawing.Point(505, 7);
            this.labelTotalUnits.Name = "labelTotalUnits";
            this.labelTotalUnits.Size = new System.Drawing.Size(33, 13);
            this.labelTotalUnits.TabIndex = 4;
            this.labelTotalUnits.Text = "0 (0)";
            // 
            // AddDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "AddDropForm";
            this.Text = "Add/Drop/Change Subject";
            this.Load += new System.EventHandler(this.AddDropForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonRemoveRow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptiveTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisteredScheduleId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Added;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Dropped;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Regular;
        private System.Windows.Forms.Label labelTotalUnits;
        private System.Windows.Forms.Label label1;
    }
}