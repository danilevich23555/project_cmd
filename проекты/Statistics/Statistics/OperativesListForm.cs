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
    public partial class OperativesListForm : Form
    {
        private SqlConnection connection;

        private int GetOperatives()
        {
            try
            {

                string opCmdText = @"SELECT Directions.dirID, Directions.dirName, Departments.depID, Departments.depName, Operatives.opID, Operatives.opNotation
                                        FROM (Directions INNER JOIN Departments ON Directions.dirID = Departments.dirID) INNER JOIN Operatives ON Departments.depID = Operatives.depID
                                        order by Directions.dirName, Departments.depName,Operatives.opNotation";
                SqlDataAdapter opAdapter = new SqlDataAdapter(opCmdText, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Operatives");
                opAdapter.Fill(ds, "Operatives");
                BindingSource depBS = new BindingSource(ds, "Operatives");
                dataGrid.DataSource = depBS;
                dataGrid.Columns[0].HeaderText = "dirID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Служба";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "depID";
                dataGrid.Columns[2].Visible = false;
                dataGrid.Columns[3].HeaderText = "Управление";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[4].HeaderText = "opID";
                dataGrid.Columns[4].Visible = false;
                dataGrid.Columns[5].HeaderText = "Оперативник";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int deleteOperative(int opID)
        {
            try
            {
                string cmdText = "delete from Operatives where opID = " + opID;
                SqlCommand command = new SqlCommand (cmdText, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public OperativesListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void OperativesListForm_Load(object sender, EventArgs e)
        {
            GetOperatives();
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

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetOperatives();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            OperativeEditForm operativeEditForm = new OperativeEditForm(connection, true);
            operativeEditForm.ShowDialog();
            if (operativeEditForm.IsChanged) GetOperatives();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                OperativeEditForm operativeEditForm = new OperativeEditForm(connection, false, (int)row.Cells[4].Value);
                operativeEditForm.ShowDialog();
                if (operativeEditForm.IsChanged) GetOperatives();
            }
        }

        private void delMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                if (MessageBox.Show("Вы уверены, что хотите удалить \"" + row.Cells[5].Value.ToString() + "\"?", "Удалить оперативника", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteOperative((int)row.Cells[4].Value);
                    GetOperatives();
                }

            }
        }
    }
}
