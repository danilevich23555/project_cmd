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
    public partial class LettersListForm : Form
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
        private int DelLetter(int lID)
        {
            SqlTransaction transaction = connection.BeginTransaction("DelLetter");
            try
            {

                string delCmdStr = "delete from MaterialLetter where lID = " + lID;
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                delCmdStr = "delete from Conclutions where lID = " + lID;
                command.CommandText = delCmdStr;
                command.ExecuteNonQuery();
                delCmdStr = "delete from Letters where lID = " + lID;
                command.CommandText = delCmdStr;
                command.ExecuteNonQuery();
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                try
                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return -1;

                }
                catch (Exception exception)
                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }
        private int GetLetters(string where)
        {
            try
            {

                if (filterTypeComboBox.SelectedIndex != -1)
                {
                    switch (filterTypeComboBox.SelectedItem.ToString())
                    {
                        case @"По номеру":
                            where = "AND (Letters.lNumber like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По содержанию":
                            where = "AND (Letters.lText like '%" + ToSQLServerString(where) + "%')";
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
                    whereOption = " AND (lDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string letCmdStr = @"select Letters.lID, lNumber, lDate, empNotation, COUNT(MaterialLetter.mID), pNum, lText
                                        from Letters left join MaterialLetter on (Letters.lID  = MaterialLetter.lID)
                                        left join Employees on (Employees.empID = Letters.empID)
                                        left join Materials on (MaterialLetter.mID = Materials.mID)
                                        left join ItemsOfPlan on (Letters.pID = ItemsOfPlan.pID) where (1=1) " +
                                     where + whereOption + @" group by Letters.lID, lNumber, lDate, empNotation, pNum, lText
                                        order by ldate desc";
                SqlDataAdapter adapter = new SqlDataAdapter(letCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Letters");
                adapter.Fill(ds, "Letters");
                BindingSource bs = new BindingSource(ds, "Letters");
                dataGrid.DataSource = bs;
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "lID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Номер";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Дата";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Исполнитель";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Кол-во инф.";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Пункт плана";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "Текст";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetLetters()
        {
            try
            {
                GetLetters("");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public LettersListForm(SqlConnection connection)
        {
            this.connection = connection;
            whereDate = DateTime.Now;
            isOnOption = false;
            filterOn = false;
            filterText = "";
            InitializeComponent();
        }
        public LettersListForm(SqlConnection connection, DateTime whereDate)
            : this(connection)
        {
            this.whereDate = whereDate;
            isOnOption = true;
        }
        private void LettersListForm_Load(object sender, EventArgs e)
        {
            GetLetters();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterText = "";
            filterOn = false;
            filterTypeComboBox.SelectedIndex = -1;
            GetLetters();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;
                filterText = filterTextBox.Text;
                GetLetters(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

        private void addMenu_Click(object sender, EventArgs e)
        {
            LetterEditForm letterEditForm = new LetterEditForm(connection, true);
            letterEditForm.ShowDialog();
            if (letterEditForm.IsChanged)
            {
                if (filterOn)
                {
                    GetLetters(filterText);
                }
                else
                {
                    GetLetters();
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
                LetterEditForm letForm = new LetterEditForm(connection, false, (int)row.Cells[0].Value);
                letForm.ShowDialog();
                if (letForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetLetters(filterText);
                    }
                    else
                    {
                        GetLetters();
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
                if (MessageBox.Show("Вы действительно хотите письмо № " + row.Cells[1].Value.ToString() + " от " + Convert.ToDateTime(row.Cells[2].Value).ToShortDateString() + " и все заключения к нему?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DelLetter((int)row.Cells[0].Value);
                    if (filterOn)
                    {
                        GetLetters(filterText);
                    }
                    else
                    {
                        GetLetters();

                    }

                }
            }
        }

        private void copyesMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                ConclutionsListForm concList = new ConclutionsListForm (connection, Convert.ToInt32(row.Cells[0].Value));
                concList.ShowDialog();
                
            }
        }
    }
}
