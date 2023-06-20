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
    public partial class IncomingDocumentsListForm : Form
    {
        private SqlConnection connection;
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
        private int GetIncomingDocuments()
        {
            return GetIncomingDocuments("");
        }
        private int DeleteIncomingDocument(int idID)
        {
            try
            {

                string delCmdStr = "delete from Numbers where idID = " + idID;
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.ExecuteNonQuery();
                command.CommandText = "delete from IncomingDocuments where idID = " + idID;
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int ProlongIncomingDocument(string idID, int countDays)
        {
            try
            {
                string readDateCmd = @"select idFinishDate from IncomingDocuments where idID = " + idID;
                SqlCommand command = new SqlCommand(readDateCmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                DateTime currentFinishDate = DateTime.Now;
                string currentFinishDateStr = "";
                while (reader.Read())
                {
                    currentFinishDateStr = reader[0].ToString();

                }
                reader.Close();
                if (currentFinishDateStr == "")
                {
                    MessageBox.Show("Информацию о данном документе вносилась в старой версии программы, поэтому для продления необходимо проделать следующие действия: \n" +
                                    "1. В контекстном меню выбрать пункт \"Изменить\", после чего откроется форма изменения документа.\n" +
                                    "2. На форме нажить кнопку \"Изменить\".\n" +
                                    "3. В контекстном меню выбрать пункт \"Продлить\".\n" +
                                    "После исполнения данных действий срок исполнения документа продлится на 30 суток.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    currentFinishDate = Convert.ToDateTime(currentFinishDateStr);
                    command.CommandText = @"update IncomingDocuments 
                                       set idFinishDate = '" + currentFinishDate.AddDays(countDays).ToShortDateString() + "', " +
                                               " idProlonged = 1 " +
                                           " where idID = " + idID;
                    MessageBox.Show("Срок иcполнения документа продлен на " + countDays + " суток.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetIncomingDocuments(string where)
        {
            try
            {
                if (filterTypeComboBox.SelectedIndex != -1)
                {
                    switch (filterTypeComboBox.SelectedItem.ToString())
                    {
                        case @"По входящему номеру":
                            where = "AND (idIncomeNumber like '%" + ToSQLServerString(where) + "%') " ;                           
                            break;
                        case @"По ДОУ":
                            where = "AND (IncomingDocuments.idDou like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По исполнителю":
                            where = "AND (Employees.empNotation like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По комментарию":
                            where = "AND (IncomingDocuments.idCommentary like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По оперативнику":
                            where = "AND (opNotation like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По подписному номеру":
                            where = "AND (idNumber like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По стране":
                            where = "AND (Countries.ctName like '%" + ToSQLServerString(where) + "%') ";
                            break;
                        case @"По Управлению":
                            where = "AND (Departments.depName like '%" + ToSQLServerString(where) + "%') ";
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
                    whereOption = " AND (idDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string idCmdString = @"SELECT IncomingDocuments.idID, dirName, depName, opNotation, idNumber, idDate, idIncomeNumber, idIncomeDate, idSectionNumber, idSectionDate, idDou, ctName, idProlonged, idExecuted, empNotation, count (phoneNumber), idCommentary FROM IncomingDocuments
                                            left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                            left join Departments on (Operatives.depID = departments.depID)
                                            left join Directions on (Departments.dirID = Directions.dirID) 
                                            left join Countries on (IncomingDocuments.ctID = Countries.ctID)
                                            left join Employees on (Employees.empID = IncomingDocuments.empID) 
                                            left join Numbers on (IncomingDocuments.idID = Numbers.idID) " + 
                                            
                                            "where (1=1) " + where + whereOption +
                                            "group by IncomingDocuments.idID, dirName, depName, opNotation, idNumber, idDate, idIncomeNumber, idIncomeDate, idSectionNumber, idSectionDate, idDou, ctName, idProlonged, idExecuted, empNotation, idCommentary " + 
                                            " order by idSectionDate Desc, idDate desc";
                SqlDataAdapter adapter = new SqlDataAdapter(idCmdString, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("IncomingDocuments");
                adapter.Fill(ds, "IncomingDocuments");
                BindingSource bs = new BindingSource(ds, "IncomingDocuments");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "idID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Служба";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Управление";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[3].HeaderText = "Оперативник";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Номер";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Дата";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "Вх.номер";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[7].HeaderText = "Вх.дата";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[8].HeaderText = "Вх.номер (отдел)";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[9].HeaderText = "Вх.дата (отдел)";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[10].HeaderText = "ДОУ";
                dataGrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[10].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[11].HeaderText = "Страна";
                dataGrid.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[12].HeaderText = "idProlonged";
                dataGrid.Columns[12].Visible = false;
                dataGrid.Columns[13].HeaderText = "idExecuted";
                dataGrid.Columns[13].Visible = false;
                dataGrid.Columns[14].HeaderText = "Исполнитель";
                dataGrid.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[15].HeaderText = "Количество номеров";
                dataGrid.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[16].HeaderText = "Комментарий";
                dataGrid.Columns[16].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[16].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public IncomingDocumentsListForm(SqlConnection connection)
        {
            isOnOption = false;
            whereDate = DateTime.Now;
            filterOn = false;
            filterText = "";
            this.connection = connection;
            InitializeComponent();
        }
        public IncomingDocumentsListForm(SqlConnection connection, DateTime whereDate) : this (connection)
        {
            this.isOnOption = true;
            this.whereDate = whereDate;
        }
        private void IncomingDocumentsListForm_Load(object sender, EventArgs e)
        {
            if (GetIncomingDocuments() != 0) Close();            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterText = "";
            filterOn = false;
            filterTypeComboBox.SelectedIndex = -1;
            GetIncomingDocuments();
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

                    if ((Convert.ToBoolean(row.Cells[12].Value)) || (Convert.ToBoolean(row.Cells[13].Value)))
                    {
                        contextMenu.Items[4].Enabled = false;
                    }
                    else
                    {
                        contextMenu.Items[4].Enabled = true;
                    }

                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;
                filterText = filterTextBox.Text;
                GetIncomingDocuments(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetIncomingDocuments(filterText);
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            IncomingDocumentEditForm incomingDocementEditFofm = new IncomingDocumentEditForm(connection, true);
            incomingDocementEditFofm.ShowDialog();
            if (incomingDocementEditFofm.IsChanged)
            {
                if (filterOn) GetIncomingDocuments(filterText); else GetIncomingDocuments();
            }
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                IncomingDocumentEditForm idEditForm = new IncomingDocumentEditForm(connection, false, (int)row.Cells[0].Value);
                idEditForm.ShowDialog();
                if (idEditForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetIncomingDocuments(filterText);
                    }
                    else
                    {
                        GetIncomingDocuments();
                    }
                }
            }
        }

        private void prolongedMenu_Click(object sender, EventArgs e)
        {
            int days = 0;
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DialogResult result;
                AddDaysForm addDays = new AddDaysForm();
                addDays.ShowDialog();
                if (addDays.IsChanged)
                {
                    days = addDays.Days;
                    result =
                        MessageBox.Show(
                            "Вы уверены, что хотите продлить срок исполнения документа \n№ " +
                            row.Cells[4].Value.ToString() + " от " +
                            Convert.ToDateTime(row.Cells[5].Value).ToShortDateString() + " на " + days + " суток?",
                            "Продлить срок исполнения входящего документа", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        ProlongIncomingDocument(row.Cells[0].Value.ToString(), days);
                    }
                    else
                    {
                    }
                    if (filterOn)
                    {
                        GetIncomingDocuments();
                    }
                    else
                    {
                        GetIncomingDocuments(filterText);
                    }
                }
                else
                {
                    MessageBox.Show("Не было выбрано количество дней. Продление документа не произведено.","Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                result =
                    MessageBox.Show(
                        "Вы уверены, что хотите удалить № " + row.Cells[4].Value.ToString() + " от " +
                        Convert.ToDateTime(row.Cells[5].Value).ToShortDateString() + "?", "Удалить входящий документ",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteIncomingDocument((int) row.Cells[0].Value);
                }
                else
                {
                }
                if (filterOn)
                {
                    GetIncomingDocuments(filterText);
                }
                else
                {
                    GetIncomingDocuments();
                }
            }
        }

        private void executeMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                InformationsListForm infList;
                if (isOnOption)
                {
                    infList = new InformationsListForm(connection, whereDate, Convert.ToInt32(row.Cells[0].Value));
                }
                else
                {
                    infList = new InformationsListForm(connection, Convert.ToInt32(row.Cells[0].Value));
                }
                infList.ShowDialog();
                
                
            }
        }


    }
}
