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
    public partial class DepartmentsListForm : Form
    {
        private SqlConnection connection;
        private int DeleteDepartment(int depID)
        {
            try
            {
                string cmdText = "delete from Departments where depID = " + depID;
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetDepartments()
        {
            try
            {
                string depCmdStr = "select depID, dirName, depName, Directions.dirID from Departments join Directions on (Departments.dirID = Directions.dirID) order by dirName, depName";
                DataSet ds = new DataSet();
                ds.Tables.Add("Departments");
                SqlDataAdapter adapter = new SqlDataAdapter(depCmdStr, connection);
                adapter.Fill(ds, "Departments");
                BindingSource bs = new BindingSource(ds, "Departments");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "depID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Служба";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Управление";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[3].HeaderText = "dirID";
                dataGrid.Columns[3].Visible = false;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                
                return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public DepartmentsListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void DepartmentsListForm_Load(object sender, EventArgs e)
        {
            GetDepartments();
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

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DepartmentEditForm departmentsEditForm = new DepartmentEditForm(connection, false,
                Convert.ToInt32(row.Cells[0].Value.ToString()));
                departmentsEditForm.ShowDialog();
                if (departmentsEditForm.IsChanged) GetDepartments();
            }             
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            DepartmentEditForm departmentsEditForm = new DepartmentEditForm(connection, true);
            departmentsEditForm.ShowDialog();
            if (departmentsEditForm.IsChanged) GetDepartments();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetDepartments();
        }

        private void delMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DialogResult result;
                result = MessageBox.Show("Вы уверены, что хотите удалить \"" + row.Cells[2].Value.ToString() + "\"?", "Удалить Управление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteDepartment((int)row.Cells[0].Value);
                    GetDepartments();
                }
                else
                {
                }
               
            }
        }

    }
}
