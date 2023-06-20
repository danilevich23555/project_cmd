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
    public partial class EmployeesListForm : Form
    {
        private SqlConnection connection;

        private int GetEmployees()
        {
            try
            {
                string empStrCmd = @"SELECT Employees.empID, Sections.sName, Subsections.ssName, Employees.empSurname, Employees.empName, Employees.empPatronymic, Employees.empNotation
    FROM (Sections INNER JOIN Subsections ON Sections.sID = Subsections.sID) INNER JOIN Employees ON Subsections.ssID = Employees.ssID order by Sections.sName, Subsections.ssName, Employees.empSurname, Employees.empName, Employees.empPatronymic";
                SqlDataAdapter adapter = new SqlDataAdapter(empStrCmd, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Employees");
                adapter.Fill(ds, "Employees");
                BindingSource bs = new BindingSource(ds, "Employees");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "empID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Отдел";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[2].HeaderText = "Подразделение";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[3].HeaderText = "Фамилия";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[4].HeaderText = "Имя";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[5].HeaderText = "Отчество";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[6].HeaderText = "empNotation";
                dataGrid.Columns[6].Visible = false;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DeleteEmployee(int empID)
        {
            try
            {
                string empStrCmd = @"delete from employees where empID = " + empID;
                SqlCommand command = new SqlCommand(empStrCmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public EmployeesListForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void EmployeesListForm_Load(object sender, EventArgs e)
        {
            GetEmployees();
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
                EmployeeEditForm employeeEditForm = new EmployeeEditForm(connection, false, (int)row.Cells[0].Value);
                employeeEditForm.ShowDialog();
                if (employeeEditForm.IsChanged) GetEmployees();
            }
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            EmployeeEditForm employeeEditForm = new EmployeeEditForm(connection, true);
            employeeEditForm.ShowDialog();
            if (employeeEditForm.IsChanged) GetEmployees();
        }

        private void delMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                if (MessageBox.Show("Вы уверены, что хотите удалить \"" + row.Cells[6].Value.ToString() + "\"?", "Удалить сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteEmployee((int)row.Cells[0].Value);
                    GetEmployees();
                }

            }

        }
    }
}
