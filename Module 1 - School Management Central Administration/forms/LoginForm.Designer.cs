namespace Module_1___School_Management_Central_Administration
{
    partial class LoginForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jTabWizard1 = new UtilityManager.ui.JTabWizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelWarning = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.waterMarkTextBoxPassword = new UtilityManager.ui.WaterMarkTextBox();
            this.waterMarkTextBoxUserName = new UtilityManager.ui.WaterMarkTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSet = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.semSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.branchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelConnection = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.jTabWizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jTabWizard1);
            this.groupBox1.Location = new System.Drawing.Point(140, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Preferences";
            // 
            // jTabWizard1
            // 
            this.jTabWizard1.Controls.Add(this.tabPage1);
            this.jTabWizard1.Controls.Add(this.tabPage2);
            this.jTabWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jTabWizard1.Location = new System.Drawing.Point(3, 16);
            this.jTabWizard1.Name = "jTabWizard1";
            this.jTabWizard1.SelectedIndex = 0;
            this.jTabWizard1.Size = new System.Drawing.Size(403, 164);
            this.jTabWizard1.TabIndex = 3;
            this.jTabWizard1.Selected += new System.Windows.Forms.TabControlEventHandler(this.jTabWizard1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelWarning);
            this.tabPage1.Controls.Add(this.buttonNext);
            this.tabPage1.Controls.Add(this.waterMarkTextBoxPassword);
            this.tabPage1.Controls.Add(this.waterMarkTextBoxUserName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(395, 138);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(69, 79);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(16, 13);
            this.labelWarning.TabIndex = 3;
            this.labelWarning.Text = "...";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(314, 109);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "&Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // waterMarkTextBoxPassword
            // 
            this.waterMarkTextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBoxPassword.Location = new System.Drawing.Point(69, 38);
            this.waterMarkTextBoxPassword.Name = "waterMarkTextBoxPassword";
            this.waterMarkTextBoxPassword.Size = new System.Drawing.Size(320, 20);
            this.waterMarkTextBoxPassword.TabIndex = 1;
            this.waterMarkTextBoxPassword.UseSystemPasswordChar = true;
            this.waterMarkTextBoxPassword.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBoxPassword.WaterMarkText = "<< Password >>";
            this.waterMarkTextBoxPassword.Enter += new System.EventHandler(this.waterMarkTextBoxPassword_Enter);
            this.waterMarkTextBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.waterMarkTextBoxPassword_KeyDown);
            this.waterMarkTextBoxPassword.Leave += new System.EventHandler(this.waterMarkTextBoxPassword_Leave);
            // 
            // waterMarkTextBoxUserName
            // 
            this.waterMarkTextBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.waterMarkTextBoxUserName.Location = new System.Drawing.Point(69, 11);
            this.waterMarkTextBoxUserName.Name = "waterMarkTextBoxUserName";
            this.waterMarkTextBoxUserName.Size = new System.Drawing.Size(320, 20);
            this.waterMarkTextBoxUserName.TabIndex = 0;
            this.waterMarkTextBoxUserName.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBoxUserName.WaterMarkText = "<< User Name >>";
            this.waterMarkTextBoxUserName.Enter += new System.EventHandler(this.waterMarkTextBoxUserName_Enter);
            this.waterMarkTextBoxUserName.Leave += new System.EventHandler(this.waterMarkTextBoxUserName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSet);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(395, 138);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Preferences";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(314, 109);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 5;
            this.buttonSet.Text = "&Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.semSyEntityBindingSource;
            this.comboBox2.DisplayMember = "SemSyName";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(94, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.ValueMember = "SemSyId";
            this.comboBox2.Enter += new System.EventHandler(this.comboBox2_Enter);
            this.comboBox2.Leave += new System.EventHandler(this.comboBox2_Leave);
            // 
            // semSyEntityBindingSource
            // 
            this.semSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.branchBindingSource;
            this.comboBox1.DisplayMember = "BranchName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(295, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "BranchId";
            this.comboBox1.Enter += new System.EventHandler(this.comboBox1_Enter);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // branchBindingSource
            // 
            this.branchBindingSource.DataSource = typeof(GenDataLayer.Branch);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "SY/Sem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "School Branch:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(461, 274);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(136, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "IZMART ENROLLMENT SYSTEM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Module_1___School_Management_Central_Administration.Properties.Resources.sqle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 301);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnection.Location = new System.Drawing.Point(144, 277);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(20, 17);
            this.labelConnection.TabIndex = 4;
            this.labelConnection.Text = "...";
            this.labelConnection.DoubleClick += new System.EventHandler(this.labelConnection_DoubleClick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(555, 306);
            this.Controls.Add(this.labelConnection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.jTabWizard1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UtilityManager.ui.JTabWizard jTabWizard1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UtilityManager.ui.WaterMarkTextBox waterMarkTextBoxPassword;
        private UtilityManager.ui.WaterMarkTextBox waterMarkTextBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource branchBindingSource;
        private System.Windows.Forms.BindingSource semSyEntityBindingSource;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelConnection;
    }
}