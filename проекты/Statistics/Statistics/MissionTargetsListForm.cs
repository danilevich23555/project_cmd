using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class MissionTargetsListForm : Form
    {
        private SqlConnection connection;
        public MissionTargetsListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }
        private int GetMissionTargets()
        {
            try
            {
                string cmd = "SELECT mtID, mtName FROM MissionTargets order by mtName";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MissionTargets");
                adapter.Fill(ds, "MissionTargets");
                BindingSource bs = new BindingSource(ds, "MissionTargets");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "ID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Цель командирования";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DelMissionTarget(int index)
        {
            try
            {
                string delCmdStr = "delete from MissionTargets where mtID = " + index.ToString();
                SqlCommand delCommand = new SqlCommand(delCmdStr, connection);
                delCommand.ExecuteNonQuery();
                return 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void dataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
                {
                    dataGrid.CurrentCell = dataGrid[e.ColumnIndex, e.RowIndex];
                    dataGrid.CurrentRow.Selected = true;
                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void RequeryMenu_Click(object sender, EventArgs e)
        {
            GetMissionTargets();
        }

        private void MissionTargetListForm_Load(object sender, EventArgs e)
        {
            GetMissionTargets();
        }

        private void AddMenu_Click(object sender, EventArgs e)
        {
            MissionTargetEditForm mtEditForm = new MissionTargetEditForm(connection);
            mtEditForm.ShowDialog();
            if (mtEditForm.IsChanged) GetMissionTargets();
        }

        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                MissionTargetEditForm mtEditForm = new MissionTargetEditForm(connection, false,
                Convert.ToInt32(row.Cells[0].Value.ToString()));
                mtEditForm.ShowDialog();
                if (mtEditForm.IsChanged) GetMissionTargets();
            }
        }

        private void DelMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                if (MessageBox.Show("Вы действительно хотите удалить место командировния " + row.Cells[1].Value.ToString() + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DelMissionTarget(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    GetMissionTargets();
                }
            }
        }
    }
}
