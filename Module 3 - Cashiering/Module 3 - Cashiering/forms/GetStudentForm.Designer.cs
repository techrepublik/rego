namespace Module_3___Cashiering.forms
{
    partial class GetStudentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.waterMarkTextBox1 = new UtilityManager.ui.WaterMarkTextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 41);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter ID No., or Last Name:";
            // 
            // waterMarkTextBox1
            // 
            this.waterMarkTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.waterMarkTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBox1.Location = new System.Drawing.Point(4, 67);
            this.waterMarkTextBox1.Name = "waterMarkTextBox1";
            this.waterMarkTextBox1.Size = new System.Drawing.Size(300, 20);
            this.waterMarkTextBox1.TabIndex = 4;
            this.waterMarkTextBox1.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox1.WaterMarkText = "SEARCH (i.e. 99-00362 or DELA CRUZ)";
            this.waterMarkTextBox1.Enter += new System.EventHandler(this.waterMarkTextBox1_Enter);
            this.waterMarkTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.waterMarkTextBox1_KeyDown);
            this.waterMarkTextBox1.Leave += new System.EventHandler(this.waterMarkTextBox1_Leave);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(310, 65);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(54, 23);
            this.buttonGo.TabIndex = 5;
            this.buttonGo.Text = "&Go...";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(4, 92);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(360, 303);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonOk.Location = new System.Drawing.Point(290, 400);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(74, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(6, 404);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(37, 13);
            this.labelBalance.TabIndex = 8;
            this.labelBalance.Text = "<<..>>";
            // 
            // GetStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 430);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.waterMarkTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "GetStudentForm";
            this.Text = "Get Student";
            this.Load += new System.EventHandler(this.GetStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private UtilityManager.ui.WaterMarkTextBox waterMarkTextBox1;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelBalance;
    }
}