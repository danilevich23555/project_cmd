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
    public partial class ConclutionsListForm : Form
    {
        private SqlConnection connection;
        private int lID;
        private bool filterOn;
        private string filterText;
        private bool isOnOption;

        private DateTime whereDate;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int DelConclutions(string cID)
        {
            try
            {
                string delCmdStr = @"delete from Conclutions where cID = " + cID;
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetResults()
        {
            try
            {
                string resCmdStr = @"SELECT MatResults.mrID, MatResults.mrName FROM MatResults";
                SqlDataAdapter adapter = new SqlDataAdapter(resCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MatResults");
                adapter.Fill(ds, "MatResults");
                BindingSource bs = new BindingSource(ds, "MatResults");
                resultComboBox.DataSource = bs;
                resultComboBox.ValueMember = "mrID";
                resultComboBox.DisplayMember = "mrName";
                resultComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetEmployees()
        {
            try
            {
                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (lDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string resCmdStr = @"SELECT empID, empNotation FROM Employees where empID in 
                                  (select distinct empID from Conclutions
                                    join Letters on (Letters.lID = Conclutions.lID)
                                    where (1=1)" + whereOption +" ) order by empNotation";
                SqlDataAdapter adapter = new SqlDataAdapter(resCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Employees");
                adapter.Fill(ds, "Employees");
                BindingSource bs = new BindingSource(ds, "Employees");
                resultComboBox.DataSource = bs;
                resultComboBox.ValueMember = "empID";
                resultComboBox.DisplayMember = "empNotation";
                resultComboBox.SelectedIndex = -1;
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
                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (lDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string depCmdStr = @"SELECT depID, depName from Departments where (1=1) and depID in 
                                  (select distinct depID from Conclutions
                                    join Letters on (Letters.lID = Conclutions.lID)
                                    join Operatives on (Conclutions.opID = Operatives.opID) where (1=1)" + whereOption +" )"
                                  + " Order by depName";
                SqlDataAdapter depAdapter = new SqlDataAdapter(depCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Departmets");
                depAdapter.Fill(ds, "Departmets");
                BindingSource bs = new BindingSource(ds, "Departmets");
                resultComboBox.DataSource = bs;
                resultComboBox.ValueMember = "depID";
                resultComboBox.DisplayMember = "depName";
                resultComboBox.SelectedIndex = -1;


                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetConclutions(string where)
        {
            try
            {
                if (filterOn)
                {
                    if (filterTypeComboBox.SelectedIndex != -1)
                    {
                        switch (filterTypeComboBox.SelectedItem.ToString())
                        {
                            case @"По комментарию":
                                where = "where (Conclutions.cText like '%" + ToSQLServerString(where) + "%') ";
                                break;
                            case @"По номеру":
                                where = "where (Letters.lNumber like '%" + ToSQLServerString(where) + "%') ";
                                break;
                            case @"По оценке":
                                where = "where (Conclutions.cRating like '%" + ToSQLServerString(where) + "%') ";
                                break;
                            case @"По содержанию":
                                where = "where (Letters.lText like '%" + ToSQLServerString(where) + "%') ";
                                break;
                            case @"По Управлению":
                                where = "where (Departments.depID = " + ToSQLServerString(where) + ") ";
                                break;
                            case @"По сотруднику":
                                where = "where (Employees.empID = " + ToSQLServerString(where) + ") ";
                                break;
                            case @"По результату":

                                if (where == "null")
                                {
                                    where = "where (Conclutions.mrID is null ) ";
                                }
                                else
                                {
                                    where = "where (Conclutions.mrID = " + where + ") ";
                                }
                                break;
                            default:
                                where = "where (1=1) ";
                                break;
                        }
                    }
                }
                else
                {
                    where = "where (1=1) ";
                }
                if (lID != -1)
                {
                    where += " AND (Conclutions.lID = " + lID + ") ";
                }
                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (lDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string conCmdStr = @"select Conclutions.cID, lNumber, lDate, dirName, depName, empNotation,lText, cRating, mrName, count(mID), cText from Conclutions left join Letters on (Letters.lID = Conclutions.lID)
                                            left join MaterialLetter on (Letters.lID = MaterialLetter.lID)
                                            left join Operatives on (Operatives.opID = Conclutions.opID)
                                            left join Departments on (Departments.depID = Operatives.depID)
                                            left join Directions on (Departments.dirID = Directions.dirID)
                                            left join Employees on (Employees.empID = Letters.empID)
                                            left join MatResults on (MatResults.mrID = Conclutions.mrID) " + where + whereOption +
                                            "group by Conclutions.cID, lNumber, lDate, dirName, depName, empNotation,lText, cRating, mrName, cText order by Letters.lDate Desc";
                SqlDataAdapter adapter = new SqlDataAdapter(conCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Conclutions");
                adapter.Fill(ds, "Conclutions");
                BindingSource bs = new BindingSource(ds, "Conclutions");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "cID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Номер";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Дата";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Служба";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Управление";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[5].HeaderText = "Сотрудник";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "Текст";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[7].HeaderText = "Оценка";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[8].HeaderText = "Результат";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[9].HeaderText = "Кол-во информаций";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[10].HeaderText = "Комментарий";
                dataGrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[10].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetConclutions()
        {
            try
            {
                GetConclutions("");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public ConclutionsListForm(SqlConnection connection)
        {
            this.connection = connection;
            lID = -1;
            filterText = "";
            filterOn = false;
            isOnOption = false;
            this.whereDate = DateTime.Now;
            InitializeComponent();
        }
        public ConclutionsListForm(SqlConnection connection, DateTime whereDate) : this (connection)
        {
            isOnOption = true;
            this.whereDate = whereDate;
        }
        public ConclutionsListForm(SqlConnection connection, int lID) : this (connection)
        {
            this.lID = lID;
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            if (filterOn)
            {
                filterTypeComboBox.Enabled = true;
                filterText = "";
                filterOn = false;
                switch (filterTypeComboBox.SelectedItem.ToString())
                {
                    case @"По номеру":
                    case @"По оценке":
                    case @"По содержанию":
                    case @"По Управлению":
                        break;
                    case @"По результату":
                        break;
                    default:
                        break;
                }   

            }

            GetConclutions();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;             
                switch (filterTypeComboBox.SelectedItem.ToString())
                {
                    case @"По комментарию":
                    case @"По номеру":
                    case @"По оценке":
                    case @"По содержанию":
                        filterText = filterTextBox.Text;
                        filterTypeComboBox.Enabled = false;
                        break;
                    case @"По результату":
                    case @"По сотруднику":
                    case @"По Управлению":
                        filterTypeComboBox.Enabled = false;
                        if (resultComboBox.SelectedValue == null) filterText = "null";
                        else
                        {
                            filterText = resultComboBox.SelectedValue.ToString();
                        }
                        break;


                    default:
                        break;
                }             
                GetConclutions(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                switch (filterTypeComboBox.SelectedItem.ToString())
                {
                    case @"По номеру":
                    case @"По оценке":
                    case @"По содержанию":
                        if (resultComboBox.SelectedItem != null) resultComboBox.SelectedItem = null;
                        filterTextBox.Enabled = true;
                        resultComboBox.Enabled = false;
                        break;                      
                    case @"По Управлению":
                        filterTextBox.Text = "";
                        filterTextBox.Enabled = false;
                        resultComboBox.Enabled = true;
                        GetDepartments();
                        break;
                    case @"По результату":
                        filterTextBox.Text = "";
                        filterTextBox.Enabled = false;
                        resultComboBox.Enabled = true;
                        GetResults();
                        break;
                    case @"По сотруднику":
                        filterTextBox.Text = "";
                        filterTextBox.Enabled = false;
                        resultComboBox.Enabled = true;
                        GetEmployees();
                        break;
                    default:
                      break;
                }
            }
            else
            {

            }
        }

        private void ConclutionsListForm_Load(object sender, EventArgs e)
        {
            GetConclutions();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            ConclutionEditForm conclutionEditForm = new ConclutionEditForm(connection, true);
            conclutionEditForm.ShowDialog();
            if (conclutionEditForm.IsChanged)
            {
                if (filterOn)
                {
                    GetConclutions(filterText);
                }
                else
                {
                    GetConclutions();
                }
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
                    DataGridViewRow row = new DataGridViewRow();
                    row = dataGrid.Rows[e.RowIndex];
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
                ConclutionEditForm concEditForm = new ConclutionEditForm(connection, false, (int)row.Cells[0].Value);
                concEditForm.ShowDialog();

                if (concEditForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetConclutions(filterText);
                    }
                    else
                    {
                        GetConclutions();
                    }
                }
            }
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            if (filterOn)
            {
                GetConclutions(filterText);
            }
            else
            {
                GetConclutions();
            }
        }

        private void delMenu_Click(object sender, EventArgs e)
        {

            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DialogResult result;
                result = MessageBox.Show("Вы уверены, что хотите удалить экземпляр письма № " + row.Cells[1].Value.ToString() + " от " + Convert.ToDateTime(row.Cells[2].Value).ToShortDateString() + ", адресатом которого является "
                    + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString() + "?", "Удалить экземпляр", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DelConclutions(row.Cells[0].Value.ToString());

                    if (filterOn)
                    {
                        GetConclutions(filterText);
                    }
                    else
                    {
                        GetConclutions();
                    }
                }
                else
                {
                }

            }  
        }
    }
}
