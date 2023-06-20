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
    public partial class DirectionsListForm : Form
    {
        private SqlConnection connection;       
        private int GetDirections()
        {
            try
            {
                string cmd = "SELECT dirID, dirName FROM Directions order by dirName";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd,connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Directions");
                adapter.Fill(ds, "Directions");
                BindingSource bs = new BindingSource(ds, "Directions");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "ID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Служба";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                return 0;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int DelDirections(int index)
        {
            try
            {
                string delCmdStr = "delete from directions where dirID = " + index.ToString();
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
        public DirectionsListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
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

        private void DirectionsListForm_Load(object sender, EventArgs e)
        {
            GetDirections();
        }

        private void RequeryMenu_Click(object sender, EventArgs e)
        {
            GetDirections();
        }

        private void AddMenu_Click(object sender, EventArgs e)
        {
            DirectionEditForm directForm = new DirectionEditForm(connection,true);
            directForm.ShowDialog();
            if (directForm.IsChanged) GetDirections();
        }

        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DirectionEditForm directForm = new DirectionEditForm(connection, false,
                Convert.ToInt32(row.Cells[0].Value.ToString()));
                directForm.ShowDialog();
                if (directForm.IsChanged) GetDirections();
            }
        }

        private void DelMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                if (MessageBox.Show("Вы действительно хотите удалить Службу " + row.Cells[1].Value.ToString() + "?", "Удаление", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DelDirections(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    GetDirections();
                }
            }
        }
    }
}
