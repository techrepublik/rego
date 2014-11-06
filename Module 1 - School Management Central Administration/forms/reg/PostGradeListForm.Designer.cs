namespace Module_1___School_Management_Central_Administration.forms.reg
{
    partial class PostGradeListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostGradeListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.postGradeEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postGradeEntityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.postGradeEntityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.postGradeEntityDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSemSy = new System.Windows.Forms.ComboBox();
            this.semSyEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelSchedules = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityBindingNavigator)).BeginInit();
            this.postGradeEntityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 44);
            this.panel1.TabIndex = 4;
            // 
            // postGradeEntityBindingSource
            // 
            this.postGradeEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.PostGradeEntity);
            this.postGradeEntityBindingSource.Sort = "PostGradeDate, PostModeName, FullName";
            // 
            // postGradeEntityBindingNavigator
            // 
            this.postGradeEntityBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.postGradeEntityBindingNavigator.BindingSource = this.postGradeEntityBindingSource;
            this.postGradeEntityBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.postGradeEntityBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.postGradeEntityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.postGradeEntityBindingNavigatorSaveItem});
            this.postGradeEntityBindingNavigator.Location = new System.Drawing.Point(0, 44);
            this.postGradeEntityBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.postGradeEntityBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.postGradeEntityBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.postGradeEntityBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.postGradeEntityBindingNavigator.Name = "postGradeEntityBindingNavigator";
            this.postGradeEntityBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.postGradeEntityBindingNavigator.Size = new System.Drawing.Size(926, 25);
            this.postGradeEntityBindingNavigator.TabIndex = 5;
            this.postGradeEntityBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // postGradeEntityBindingNavigatorSaveItem
            // 
            this.postGradeEntityBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.postGradeEntityBindingNavigatorSaveItem.Enabled = false;
            this.postGradeEntityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("postGradeEntityBindingNavigatorSaveItem.Image")));
            this.postGradeEntityBindingNavigatorSaveItem.Name = "postGradeEntityBindingNavigatorSaveItem";
            this.postGradeEntityBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.postGradeEntityBindingNavigatorSaveItem.Text = "Save Data";
            this.postGradeEntityBindingNavigatorSaveItem.Visible = false;
            // 
            // postGradeEntityDataGridView
            // 
            this.postGradeEntityDataGridView.AllowUserToAddRows = false;
            this.postGradeEntityDataGridView.AllowUserToDeleteRows = false;
            this.postGradeEntityDataGridView.AutoGenerateColumns = false;
            this.postGradeEntityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postGradeEntityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn6});
            this.postGradeEntityDataGridView.DataSource = this.postGradeEntityBindingSource;
            this.postGradeEntityDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postGradeEntityDataGridView.Location = new System.Drawing.Point(0, 92);
            this.postGradeEntityDataGridView.Name = "postGradeEntityDataGridView";
            this.postGradeEntityDataGridView.ReadOnly = true;
            this.postGradeEntityDataGridView.RowHeadersWidth = 30;
            this.postGradeEntityDataGridView.Size = new System.Drawing.Size(926, 323);
            this.postGradeEntityDataGridView.TabIndex = 5;
            this.postGradeEntityDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.postGradeEntityDataGridView_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PostGradeNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Post No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PostGradeDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Post Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PostModeName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Post Mode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PostGradeNote";
            this.dataGridViewTextBoxColumn5.HeaderText = "Note";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "TeacherNo";
            this.dataGridViewTextBoxColumn24.HeaderText = "ID No";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn13.HeaderText = "Teacher Name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 250;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EditedBy";
            this.dataGridViewTextBoxColumn6.HeaderText = "Edited By";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.comboBoxSemSy);
            this.panel5.Controls.Add(this.labelSchedules);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 69);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(926, 23);
            this.panel5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(745, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sem, SY:";
            // 
            // comboBoxSemSy
            // 
            this.comboBoxSemSy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxSemSy.DataSource = this.semSyEntityBindingSource;
            this.comboBoxSemSy.DisplayMember = "SemSyName";
            this.comboBoxSemSy.FormattingEnabled = true;
            this.comboBoxSemSy.Location = new System.Drawing.Point(804, 1);
            this.comboBoxSemSy.Name = "comboBoxSemSy";
            this.comboBoxSemSy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSemSy.TabIndex = 1;
            this.comboBoxSemSy.ValueMember = "SemSyId";
            // 
            // semSyEntityBindingSource
            // 
            this.semSyEntityBindingSource.DataSource = typeof(GenDataLayer.repo.entities.SemSyEntity);
            this.semSyEntityBindingSource.CurrentChanged += new System.EventHandler(this.semSyEntityBindingSource_CurrentChanged);
            // 
            // labelSchedules
            // 
            this.labelSchedules.AutoSize = true;
            this.labelSchedules.ForeColor = System.Drawing.Color.White;
            this.labelSchedules.Location = new System.Drawing.Point(4, 4);
            this.labelSchedules.Name = "labelSchedules";
            this.labelSchedules.Size = new System.Drawing.Size(16, 13);
            this.labelSchedules.TabIndex = 0;
            this.labelSchedules.Text = "...";
            // 
            // PostGradeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 415);
            this.Controls.Add(this.postGradeEntityDataGridView);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.postGradeEntityBindingNavigator);
            this.Controls.Add(this.panel1);
            this.Name = "PostGradeListForm";
            this.Text = "Post Grade List";
            this.Load += new System.EventHandler(this.PostGradeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityBindingNavigator)).EndInit();
            this.postGradeEntityBindingNavigator.ResumeLayout(false);
            this.postGradeEntityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postGradeEntityDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semSyEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource postGradeEntityBindingSource;
        private System.Windows.Forms.BindingNavigator postGradeEntityBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton postGradeEntityBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView postGradeEntityDataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSemSy;
        private System.Windows.Forms.Label labelSchedules;
        private System.Windows.Forms.BindingSource semSyEntityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}