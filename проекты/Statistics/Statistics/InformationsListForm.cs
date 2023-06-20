using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class InformationsListForm : Form
    {
        private SqlConnection connection;
        private bool filterOn;
        private string filterText;
        private bool isOnOption;
        private string condition;
        private DateTime whereDate;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int GetInformations()
        {
            /*
            try
            {
                GetInformations("");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
             * */
            return GetInformations("");
        }
        private int DeleteInformation(string infID)
        {
            SqlTransaction transaction = connection.BeginTransaction("DelInformation");
            try
            {
                string delCmdStr = "delete from IncDocInform where infID = " + infID;
                    
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                delCmdStr = "delete from Informations where infID = " + infID;
                command.CommandText = delCmdStr;
                command.ExecuteNonQuery();
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex_tran)
                {
                    MessageBox.Show(ex_tran.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                   
                }
                
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetInformations(string where)
        {
            try               
            {
                if (filterTypeComboBox.SelectedIndex != -1)
                {
                    switch (filterTypeComboBox.SelectedItem.ToString())
                    {
                        case @"По входящему номеру входящего документа":
                            where = " AND (IncomingDocuments.idIncomeNumber like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По ДОУ":
                            where = " AND (IncomingDocuments.idDou like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По исполнителю":
                            where = " AND (Employees.empNotation like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По комментарию":
                            where = " AND (Informations.infText like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По номеру входящего документа":
                            where = " AND (IncomingDocuments.idNumber like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По номеру справки":
                            where = " AND (Informations.infNumber like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По Управлению":
                            where = " AND (Departments.depName like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По оперативнику":
                            where = " AND (Operatives.opNotation like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По стране":
                            where = " AND (Countries.ctName like '%" + ToSQLServerString(where) + "%')";
                            break;
                        default:
                            where = "";
                            break;
                    }
                }
                else
                {
                    where = "";
                }

                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (Informations.infDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string infCmdStr = @"select Informations.infID, 
                                            Informations.infNumber, 
                                            Informations.infDate, 
                                            IncomingDocuments.idDou, 
                                            TaskTypes.ttName, 
                                            Employees.empNotation, 
                                            Directions.dirName, 
                                            Departments.depName, 
                                            Operatives.opNotation,
                                            IncomingDocuments.idNumber, 
                                            IncomingDocuments.idIncomeNumber,
                                            Countries.ctName,
                                            Informations.infText,
                                            Informations.infCountNuvbersInfExist 
                                            from Informations left join IncDocInform on (IncDocInform.infID = Informations.infID)
                                            left join IncomingDocuments on (IncDocInform.idID = IncomingDocuments.idID)
                                            left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                            left join Departments on (Operatives.depID = departments.depID)
                                            left join Directions on (Departments.dirID = Directions.dirID)
                                            left join TaskTypes on (IncomingDocuments.ttID = TaskTypes.ttID)
                                            left join Employees on (Employees.empID = IncomingDocuments.empID)
                                            left join Countries on (Informations.ctID = Countries.ctID) where " + this.condition + " "
                                            + where + whereOption
                                    + " order by Informations.infDate Desc";
                SqlDataAdapter adapter = new SqlDataAdapter(infCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Informations");
                adapter.Fill(ds, "Informations");
                BindingSource bs = new BindingSource(ds, "Informations");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "infID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Подп.номер";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Дата";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "ДОУ";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[4].HeaderText = "Задача";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Исполнитель";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "Служба";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[7].HeaderText = "Управление";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[7].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[8].HeaderText = "Оперативник";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[9].HeaderText = "Номер вх.документа";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[10].HeaderText = "Вх.номер вх.документа";
                dataGrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[11].HeaderText = "Страна";
                dataGrid.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[11].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[12].HeaderText = "Комментарий";
                dataGrid.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[12].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[13].HeaderText = "Кол-во выявленных номеров";
                dataGrid.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public InformationsListForm(SqlConnection connection) : this (connection, -1)
        {
        }
        public InformationsListForm(SqlConnection connection, DateTime whereDate) : this (connection, whereDate, -1)
        {          
        }
        public InformationsListForm(SqlConnection connection, int idID)
        {
            if (idID == -1) condition = "(1 = 1)"; else condition = "(IncDocInform.idID = " + idID.ToString() + ")";
            isOnOption = false;
            this.whereDate = DateTime.Now;
            this.connection = connection;
            InitializeComponent();
        }
        public InformationsListForm (SqlConnection connection, DateTime whereDate, int idID)
        {
            if (idID == -1) condition = "(1 = 1)"; else condition = "(IncDocInform.idID = " + idID.ToString() + ")";
            isOnOption = true;
            this.whereDate = whereDate;
            this.connection = connection;
            InitializeComponent();
        }

        private void InformationsListForm_Load(object sender, EventArgs e)
        {
            if (GetInformations() != 0) Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;
                filterText = filterTextBox.Text;
                GetInformations(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterText = "";
            filterOn = false;
            filterTypeComboBox.SelectedIndex = -1;
            GetInformations();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetInformations(filterText);
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

        private void addMenu_Click(object sender, EventArgs e)
        {
            InformationEditForm informationEditForm = new InformationEditForm(connection, true);
            informationEditForm.ShowDialog();
            if (informationEditForm.IsChanged)
            {
                if (filterOn)
                {
                    GetInformations(filterText);
                }
                else
                {
                    GetInformations();
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
                InformationEditForm infForm = new InformationEditForm(connection, false, Convert.ToInt32(row.Cells[0].Value));
                infForm.ShowDialog();
                if (infForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetInformations(filterText);
                    }
                    else
                    {
                        GetInformations();
                    }
                }
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
                result = MessageBox.Show("Вы уверены, что хотите удалить № " + row.Cells[1].Value.ToString() + " от " + Convert.ToDateTime(row.Cells[2].Value).ToShortDateString() + "?", "Удалить ответ на запрос?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteInformation(row.Cells[0].Value.ToString()) == 0)
                    {
                        if (filterOn)
                        {
                            GetInformations(filterText);
                        }
                        else
                        {
                            GetInformations();
                        }
                    }
                    
                }




            }
        }
    }
}
