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
    public partial class UKRFListForm : Form
    {
        private SqlConnection connection;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int GetUKRF()
        {
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select ukNumber, ukCaption from UKRF order by ukNumber", connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("UKRF");
                adapter.Fill(ds, "UKRF");
                BindingSource bs = new BindingSource(ds, "UKRF");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "Номер";
                dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[1].HeaderText = "Название";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DeleteUK(string currentUK)
        {
            try
            {
                string cmd = "delete from UKRF where ukNumber = '" + ToSQLServerString(currentUK) + "'";
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public UKRFListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void UKRFListForm_Load(object sender, EventArgs e)
        {
            GetUKRF();
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

        private void addMenu_Click(object sender, EventArgs e)
        {
            UKRFEditForm ukrfEditForm = new UKRFEditForm(connection, true);
            ukrfEditForm.ShowDialog();
            if (ukrfEditForm.IsChanged) GetUKRF();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetUKRF();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();             
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                UKRFEditForm ukrfEditForm = new UKRFEditForm(connection, false, row.Cells[0].Value.ToString());
                ukrfEditForm.ShowDialog();
                if (ukrfEditForm.IsChanged) GetUKRF();
            }
        }

        private void delMenu_Click(object sender, EventArgs e)
        {
            string currentUK = "";
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                currentUK = row.Cells[0].Value.ToString();
                if (
                    MessageBox.Show("Вы уверены, что хотите удалить из базы статью № " + currentUK + "?",
                        "Удалить статью", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(DeleteUK(currentUK) == 0) GetUKRF();
                }
                    
                
            }
        }
    }
}
