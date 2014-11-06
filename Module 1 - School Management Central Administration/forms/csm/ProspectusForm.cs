using System;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class ProspectusForm : Form
    {
        public Prospectus _Prospectus { get; set; }

        public ProspectusForm()
        {
            InitializeComponent();
        }

        private void prospectusBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (prospectusBindingSource.Current != null)
                prospectusBindingNavigatorSaveItem.Enabled = true;
        }

        private void LoadCourses()
        {
            Cursor.Current = Cursors.WaitCursor;
            coursBindingSource.DataSource = LoadQueries.GetCourses();
            Cursor.Current = Cursors.Default;
        }

        private void GetProspectus()
        {
            if (_Prospectus != null)
                prospectusBindingSource.DataSource = _Prospectus;
        }

        private void ProspectusForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            GetProspectus();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            prospectusBindingNavigatorSaveItem.Enabled = true;
            coursBindingSource.AddNew();
            courseIdComboBox.Focus();
        }

        private void prospectusBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            prospectusBindingSource.EndEdit();
            int iResult = Save.Prospectuss((Prospectus) prospectusBindingSource.Current);
            UtilClass.ShowSaveMessageBox(iResult);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var dResult = UtilityManager.util.UtilClass.ShowDeleteMessageQuestion();
            if (dResult == DialogResult.Yes)
            {
                var prospectus = (Prospectus) prospectusBindingSource.Current;
                if (prospectus != null)
                {
                    if (Remove.Prospectusss(prospectus.ProspectusId))
                    {
                        prospectusBindingSource.RemoveCurrent();
                    }
                }
                
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
