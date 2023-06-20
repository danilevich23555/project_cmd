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
    public partial class CheckForm : Form
    {
        private const int MaxLength = 50;
        private SqlConnection connection;
        private string numbers;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int GetResults()
        {

            try
            {
                string where = " where ((1=0)";
                string error = "Номер(а) ";
                for (int i = 0; i < checkNumbersRichTextBox.Lines.Length; i++)
                {
                    if (!((checkNumbersRichTextBox.Lines[i] == "") | (checkNumbersRichTextBox.Lines[i] == " ")))
                    {
                        if (checkNumbersRichTextBox.Lines[i].Length <= MaxLength)
                        {
                            where += "OR (Numbers.phoneNumber like '%" + checkNumbersRichTextBox.Lines[i] + "%')";
                        }
                        else
                        {
                            where += "OR (Numbers.phoneNumber like '%" + checkNumbersRichTextBox.Lines[i].Substring(0, MaxLength) + "%')";
                            error = error + checkNumbersRichTextBox.Lines[i];
                            
                        }
                    }
                }
                where += ")";
                 if (error != "Номер(а) ")
                {
                    error = error + @" слишком длинные, проверка производилась по первым " + MaxLength + " знакам";
                    MessageBox.Show(error, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                 string selectCmd = "SELECT IncomingDocuments.idID, Numbers.phoneNumber, IncomingDocuments.idNumber, IncomingDocuments.idDate, IncomingDocuments.idDou, Employees.empNotation, Directions.dirName, Departments.depName "
                                    + @" FROM Numbers left join IncomingDocuments on (Numbers.idID = IncomingDocuments.idID)
	                                                left join Operatives on (Operatives.opID = IncomingDocuments.opID)
                                                    left join Departments on (Operatives.depID = departments.depID)
                                                    left join Directions on (Departments.dirID = Directions.dirID) 
                                                    left join Employees on (Employees.empID = IncomingDocuments.empID)" + where + " order by Numbers.phoneNumber";

                SqlDataAdapter adapter = new SqlDataAdapter(selectCmd, connection);
                DataSet ds = new DataSet();
                adapter.SelectCommand.CommandTimeout = 600;
                ds.Tables.Add("Numbers");
                adapter.Fill(ds, "Numbers");
                BindingSource bs = new BindingSource(ds, "Numbers");
                resultGrid.DataSource = bs;
                resultGrid.Columns[0].HeaderText = "ID";
                resultGrid.Columns[0].Visible = false;
                resultGrid.Columns[1].HeaderText = "Телефон";
                resultGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid.Columns[2].HeaderText = "Номер";
                resultGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                resultGrid.Columns[3].HeaderText = "Дата";
                resultGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                resultGrid.Columns[4].HeaderText = "ДОУ";
                resultGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                resultGrid.Columns[5].HeaderText = "Исполнитель";
                resultGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                resultGrid.Columns[6].HeaderText = "Служба";
                resultGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                resultGrid.Columns[7].HeaderText = "Управление";
                resultGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                resultGrid.Columns[7].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                resultGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        
        }
        private int GetDataRegsResults()
        {

            try
            {
                string where = " where ((1=0)";
                string error = "Номер(а) ";
                for (int i = 0; i < checkNumbersRichTextBox.Lines.Length; i++)
                {
                    if (!((checkNumbersRichTextBox.Lines[i] == "") | (checkNumbersRichTextBox.Lines[i] == " ")))
                    {
                        if (checkNumbersRichTextBox.Lines[i].Length <= MaxLength)
                        {
                            where += "OR (prdNumber like '%" + checkNumbersRichTextBox.Lines[i] + "%')";
                        }
                        else
                        {
                            where += "OR (prdNumber like '%" + checkNumbersRichTextBox.Lines[i].Substring(0, MaxLength) + "%')";
                            error = error + checkNumbersRichTextBox.Lines[i];

                        }
                    }
                }
                where += ")";
                if (error != "Номер(а) ")
                {
                    error = error + @" слишком длинные, проверка производилась по первым " + MaxLength + " знакам";
                    MessageBox.Show(error, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string selectCmd = @"select prdID, prdDate, prdNumber, prdData, prdBase, emp.empNotation, empPriv.empNotation from PhoneRegDatas
                                        left join Employees emp on (emp.empID = PhoneRegDatas.empID)
                                        left join Employees empPriv on (empPriv.empID = PhoneRegDatas.empIDPriv) " + where + " order by prdNumber";

                SqlDataAdapter adapter = new SqlDataAdapter(selectCmd, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("PhoneRegDatas");
                adapter.Fill(ds, "PhoneRegDatas");
                BindingSource bs = new BindingSource(ds, "PhoneRegDatas");
                resultGrid2.DataSource = bs;
                resultGrid2.Columns[0].HeaderText = "prdID";
                resultGrid2.Columns[0].Visible = false;
                resultGrid2.Columns[1].HeaderText = "Дата";
                resultGrid2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid2.Columns[2].HeaderText = "Номер";
                resultGrid2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid2.Columns[3].HeaderText = "Установочные данные";
                resultGrid2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                resultGrid2.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                resultGrid2.Columns[4].HeaderText = "Основание";
                resultGrid2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid2.Columns[5].HeaderText = "Дающий установку";
                resultGrid2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid2.Columns[6].HeaderText = "От чьего имени";
                resultGrid2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                resultGrid2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        public CheckForm(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }
        public CheckForm(SqlConnection connection, string numbers) :this (connection)
        {
            this.numbers = numbers;
            checkNumbersRichTextBox.Text = numbers;
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            GetResults();
            GetDataRegsResults();
        }

        private void resultGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
                {
                    resultGrid.CurrentCell = resultGrid[e.ColumnIndex, e.RowIndex];
                    resultGrid.CurrentRow.Selected = true;
                    DataGridViewRow row = new DataGridViewRow();
                    row = resultGrid.Rows[e.RowIndex];
                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
            else
            {
                if ((e.Button == System.Windows.Forms.MouseButtons.Left) & (e.Clicks == 2))
                {
                    openDocumentMenu_Click(sender, e);
                }
            }
        }

        private void openDocumentMenu_Click(object sender, EventArgs e)
        {

            DataGridView dataGrid = new DataGridView();
            dataGrid = resultGrid;
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                IncomingDocumentEditForm idEditForm = new IncomingDocumentEditForm(connection, false, (int)row.Cells[0].Value);
                idEditForm.ShowDialog();
                if (idEditForm.IsChanged)
                {
                    GetResults();
                }
            }

        }

        private void executeMenu_Click(object sender, EventArgs e)
        {

            if (resultGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = resultGrid.CurrentCell.RowIndex;
                row = resultGrid.Rows[i];
                InformationsListForm infList;
                infList = new InformationsListForm(connection, Convert.ToInt32(row.Cells[0].Value));
                infList.ShowDialog();


            }
        }

    }
}
