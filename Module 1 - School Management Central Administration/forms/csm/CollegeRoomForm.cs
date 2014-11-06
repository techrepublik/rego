using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenDataLayer;
using GenDataLayer.repo.managers;
using UtilityManager.util;

namespace Module_1___School_Management_Central_Administration.forms.csm
{
    public partial class CollegeRoomForm : Form
    {
        public CollegeRoomForm()
        {
            InitializeComponent();
        }

        private void CollegeRoomForm_Load(object sender, EventArgs e)
        {
            LoadCollege();
            this.reportViewer1.RefreshReport();
        }

        private void LoadCollege()
        {
            Cursor.Current = Cursors.WaitCursor;
            collegeBindingSource.DataSource = LoadQueries.GetColleges();
            Cursor.Current = Cursors.Default;
        }

        private void LoadRooms(int iCollegeId)
        {
            Cursor.Current = Cursors.WaitCursor;
            roomBindingSource.DataSource = ObjectQueries.GetRoomListByCollege(iCollegeId);
            Cursor.Current = Cursors.Default;
        }

        private void roomDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (roomDataGridView.Rows.Count > 0)
            {
                if (roomBindingSource.Current != null)
                {
                    if (roomDataGridView.IsCurrentRowDirty)
                    {
                        Validate();
                        roomBindingSource.EndEdit();
                        ((Room)roomBindingSource.Current).CollegeId =
                            ((College)collegeBindingSource.Current).CollegeId;
                        int i = Save.Rooms((Room) roomBindingSource.Current);
                        UtilClass.ShowSaveMessageBox(i);
                    }
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (roomDataGridView.Rows.Count > 0)
            {
                if (roomBindingSource.Current != null)
                {
                    if (UtilClass.ShowDeleteMessageQuestion() == DialogResult.Yes)
                    {
                        var bResult = Remove.Rooms(((Room) roomBindingSource.Current).RoomId);
                        UtilClass.ShowDeleteMessageBox(bResult);
                        roomBindingSource.RemoveCurrent();
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (collegeBindingSource.CurrencyManager.List.Count > 0)
            {
                tabControl1.SelectedTab = tabPage1;
                LoadRooms(((College) collegeBindingSource.Current).CollegeId);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage2)
            {
                
            }
        }
    }
}
