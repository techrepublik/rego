namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class AddressUpdateWizardForm
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
            this.jTabWizard1 = new UtilityManager.ui.JTabWizard();
            this.tabPageProvince = new System.Windows.Forms.TabPage();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageCity = new System.Windows.Forms.TabPage();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.labelProvinceDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageBarangay = new System.Windows.Forms.TabPage();
            this.comboBoxBarangay = new System.Windows.Forms.ComboBox();
            this.labelCItyDisplay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageStreet = new System.Windows.Forms.TabPage();
            this.comboBoxStreet = new System.Windows.Forms.ComboBox();
            this.labelBarangayDisplay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.labelProvince = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelBarangay = new System.Windows.Forms.Label();
            this.labelStreet = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.jTabWizard1.SuspendLayout();
            this.tabPageProvince.SuspendLayout();
            this.tabPageCity.SuspendLayout();
            this.tabPageBarangay.SuspendLayout();
            this.tabPageStreet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // jTabWizard1
            // 
            this.jTabWizard1.Controls.Add(this.tabPageProvince);
            this.jTabWizard1.Controls.Add(this.tabPageCity);
            this.jTabWizard1.Controls.Add(this.tabPageBarangay);
            this.jTabWizard1.Controls.Add(this.tabPageStreet);
            this.jTabWizard1.Location = new System.Drawing.Point(143, 12);
            this.jTabWizard1.Name = "jTabWizard1";
            this.jTabWizard1.SelectedIndex = 0;
            this.jTabWizard1.Size = new System.Drawing.Size(505, 143);
            this.jTabWizard1.TabIndex = 0;
            // 
            // tabPageProvince
            // 
            this.tabPageProvince.Controls.Add(this.comboBoxProvince);
            this.tabPageProvince.Controls.Add(this.label1);
            this.tabPageProvince.Location = new System.Drawing.Point(4, 22);
            this.tabPageProvince.Name = "tabPageProvince";
            this.tabPageProvince.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProvince.Size = new System.Drawing.Size(497, 117);
            this.tabPageProvince.TabIndex = 0;
            this.tabPageProvince.Text = "Province";
            this.tabPageProvince.UseVisualStyleBackColor = true;
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(66, 9);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(411, 21);
            this.comboBoxProvince.TabIndex = 1;
            this.comboBoxProvince.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvince_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Province:";
            // 
            // tabPageCity
            // 
            this.tabPageCity.Controls.Add(this.comboBoxCity);
            this.tabPageCity.Controls.Add(this.labelProvinceDisplay);
            this.tabPageCity.Controls.Add(this.label3);
            this.tabPageCity.Controls.Add(this.label2);
            this.tabPageCity.Location = new System.Drawing.Point(4, 22);
            this.tabPageCity.Name = "tabPageCity";
            this.tabPageCity.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCity.Size = new System.Drawing.Size(497, 117);
            this.tabPageCity.TabIndex = 1;
            this.tabPageCity.Text = "City/Municipality";
            this.tabPageCity.UseVisualStyleBackColor = true;
            this.tabPageCity.Click += new System.EventHandler(this.tabPageCity_Click);
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(108, 32);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(370, 21);
            this.comboBoxCity.TabIndex = 3;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBoxCity_SelectedIndexChanged);
            // 
            // labelProvinceDisplay
            // 
            this.labelProvinceDisplay.AutoSize = true;
            this.labelProvinceDisplay.Location = new System.Drawing.Point(105, 9);
            this.labelProvinceDisplay.Name = "labelProvinceDisplay";
            this.labelProvinceDisplay.Size = new System.Drawing.Size(16, 13);
            this.labelProvinceDisplay.TabIndex = 2;
            this.labelProvinceDisplay.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Province:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "City/Municipality:";
            // 
            // tabPageBarangay
            // 
            this.tabPageBarangay.Controls.Add(this.comboBoxBarangay);
            this.tabPageBarangay.Controls.Add(this.labelCItyDisplay);
            this.tabPageBarangay.Controls.Add(this.label4);
            this.tabPageBarangay.Controls.Add(this.label5);
            this.tabPageBarangay.Location = new System.Drawing.Point(4, 22);
            this.tabPageBarangay.Name = "tabPageBarangay";
            this.tabPageBarangay.Size = new System.Drawing.Size(497, 117);
            this.tabPageBarangay.TabIndex = 2;
            this.tabPageBarangay.Text = "Barangay";
            this.tabPageBarangay.UseVisualStyleBackColor = true;
            // 
            // comboBoxBarangay
            // 
            this.comboBoxBarangay.FormattingEnabled = true;
            this.comboBoxBarangay.Location = new System.Drawing.Point(110, 31);
            this.comboBoxBarangay.Name = "comboBoxBarangay";
            this.comboBoxBarangay.Size = new System.Drawing.Size(370, 21);
            this.comboBoxBarangay.TabIndex = 5;
            this.comboBoxBarangay.SelectedIndexChanged += new System.EventHandler(this.comboBoxBarangay_SelectedIndexChanged);
            // 
            // labelCItyDisplay
            // 
            this.labelCItyDisplay.AutoSize = true;
            this.labelCItyDisplay.Location = new System.Drawing.Point(107, 8);
            this.labelCItyDisplay.Name = "labelCItyDisplay";
            this.labelCItyDisplay.Size = new System.Drawing.Size(16, 13);
            this.labelCItyDisplay.TabIndex = 4;
            this.labelCItyDisplay.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Barangay:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "City/Municipality:";
            // 
            // tabPageStreet
            // 
            this.tabPageStreet.Controls.Add(this.comboBoxStreet);
            this.tabPageStreet.Controls.Add(this.labelBarangayDisplay);
            this.tabPageStreet.Controls.Add(this.label6);
            this.tabPageStreet.Controls.Add(this.label7);
            this.tabPageStreet.Location = new System.Drawing.Point(4, 22);
            this.tabPageStreet.Name = "tabPageStreet";
            this.tabPageStreet.Size = new System.Drawing.Size(497, 117);
            this.tabPageStreet.TabIndex = 3;
            this.tabPageStreet.Text = "Street";
            this.tabPageStreet.UseVisualStyleBackColor = true;
            // 
            // comboBoxStreet
            // 
            this.comboBoxStreet.FormattingEnabled = true;
            this.comboBoxStreet.Location = new System.Drawing.Point(82, 31);
            this.comboBoxStreet.Name = "comboBoxStreet";
            this.comboBoxStreet.Size = new System.Drawing.Size(403, 21);
            this.comboBoxStreet.TabIndex = 7;
            this.comboBoxStreet.SelectedIndexChanged += new System.EventHandler(this.comboBoxStreet_SelectedIndexChanged);
            // 
            // labelBarangayDisplay
            // 
            this.labelBarangayDisplay.AutoSize = true;
            this.labelBarangayDisplay.Location = new System.Drawing.Point(79, 9);
            this.labelBarangayDisplay.Name = "labelBarangayDisplay";
            this.labelBarangayDisplay.Size = new System.Drawing.Size(16, 13);
            this.labelBarangayDisplay.TabIndex = 6;
            this.labelBarangayDisplay.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Barangay:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Street:";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(570, 161);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinish.TabIndex = 1;
            this.buttonFinish.Text = "&Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(489, 161);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "&Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(142, 161);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "&New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // labelProvince
            // 
            this.labelProvince.AutoSize = true;
            this.labelProvince.Location = new System.Drawing.Point(13, 21);
            this.labelProvince.Name = "labelProvince";
            this.labelProvince.Size = new System.Drawing.Size(49, 13);
            this.labelProvince.TabIndex = 5;
            this.labelProvince.Text = "Province";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(13, 43);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(24, 13);
            this.labelCity.TabIndex = 6;
            this.labelCity.Text = "City";
            // 
            // labelBarangay
            // 
            this.labelBarangay.AutoSize = true;
            this.labelBarangay.Location = new System.Drawing.Point(13, 68);
            this.labelBarangay.Name = "labelBarangay";
            this.labelBarangay.Size = new System.Drawing.Size(52, 13);
            this.labelBarangay.TabIndex = 7;
            this.labelBarangay.Text = "Barangay";
            // 
            // labelStreet
            // 
            this.labelStreet.AutoSize = true;
            this.labelStreet.Location = new System.Drawing.Point(13, 90);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(35, 13);
            this.labelStreet.TabIndex = 8;
            this.labelStreet.Text = "Street";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddressUpdateWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 193);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.labelBarangay);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelProvince);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.jTabWizard1);
            this.Name = "AddressUpdateWizardForm";
            this.Text = "AddressUpdateWizardForm";
            this.Load += new System.EventHandler(this.AddressUpdateWizardForm_Load);
            this.jTabWizard1.ResumeLayout(false);
            this.tabPageProvince.ResumeLayout(false);
            this.tabPageProvince.PerformLayout();
            this.tabPageCity.ResumeLayout(false);
            this.tabPageCity.PerformLayout();
            this.tabPageBarangay.ResumeLayout(false);
            this.tabPageBarangay.PerformLayout();
            this.tabPageStreet.ResumeLayout(false);
            this.tabPageStreet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UtilityManager.ui.JTabWizard jTabWizard1;
        private System.Windows.Forms.TabPage tabPageProvince;
        private System.Windows.Forms.TabPage tabPageCity;
        private System.Windows.Forms.TabPage tabPageBarangay;
        private System.Windows.Forms.TabPage tabPageStreet;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Label labelProvince;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelBarangay;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelProvinceDisplay;
        private System.Windows.Forms.Label labelCItyDisplay;
        private System.Windows.Forms.Label labelBarangayDisplay;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.ComboBox comboBoxBarangay;
        private System.Windows.Forms.ComboBox comboBoxStreet;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}