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
    public partial class PhoneDatasListForm : Form
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
        public PhoneDatasListForm(SqlConnection connection)
        {
            isOnOption = false;
            whereDate = DateTime.Now;
            filterOn = false;
            filterText = "";
            this.connection = connection;
            InitializeComponent();
        }
        private int GetPhoneDatas(string where)
        {
            try
            {
                
                if (filterTypeComboBox.SelectedIndex != -1)
                {
                    switch (filterTypeComboBox.SelectedItem.ToString())
                    {
                        case @"По номеру":
                            where = "AND (prdNumber like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По установочным данным":
                            where = "AND (prdData like '%" + ToSQLServerString(where) + "%')";
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
                    whereOption = " AND (prdDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string phCmdStr = @"select prdID, prdDate, prdNumber, prdData, prdBase, emp.empNotation, empPriv.empNotation from PhoneRegDatas
                                        left join Employees emp on (emp.empID = PhoneRegDatas.empID)
                                        left join Employees empPriv on (empPriv.empID = PhoneRegDatas.empIDPriv)  where (1=1) " +
                                        where + whereOption + @" order by prdDate desc, prdNumber ";
                
                SqlDataAdapter adapter = new SqlDataAdapter(phCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("PhoneRegDatas");
                adapter.Fill(ds, "PhoneRegDatas");
                BindingSource bs = new BindingSource(ds, "PhoneRegDatas");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "prdID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Дата";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Номер";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Установочные данные";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[4].HeaderText = "Основание";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Дающий установку";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "От чьего имени";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DeletePhoneDatas(int prdID)
        {
            try
            {

                string delCmdStr = "delete from PhoneRegDatas where prdID = " + prdID;
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetPhoneDatas()
        {
            return GetPhoneDatas("");
        }
        public PhoneDatasListForm(SqlConnection connection, DateTime whereDate) : this(connection)
        {
            isOnOption = true;
            this.whereDate = whereDate;
        }
        private void PhoneDatasListForm_Load(object sender, EventArgs e)
        {
            GetPhoneDatas();
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
            PhoneDataEditForm phoneDataEditForm = new PhoneDataEditForm(connection, true);
            phoneDataEditForm.ShowDialog();
            if (phoneDataEditForm.IsChanged)
            {
                if (filterOn) GetPhoneDatas(filterText); else GetPhoneDatas();
            }
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                PhoneDataEditForm pdEditForm = new PhoneDataEditForm(connection, false, (int)row.Cells[0].Value);
                pdEditForm.ShowDialog();
                if (pdEditForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetPhoneDatas(filterText);
                    }
                    else
                    {
                        GetPhoneDatas();
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
                result =
                    MessageBox.Show(
                        "Вы уверены, что хотите удалить установочные данные по номеру телефона " + row.Cells[2].Value.ToString() + "?", "Удалить установочные данные",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletePhoneDatas((int)row.Cells[0].Value);
                    if (filterOn)
                    {
                        GetPhoneDatas(filterText);
                    }
                    else
                    {
                        GetPhoneDatas();
                    }
                }              

            }
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            if (filterOn)
            {
                GetPhoneDatas(filterText);
            }
            else
            {
                GetPhoneDatas();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterText = "";
            filterOn = false;
            filterTypeComboBox.SelectedIndex = -1;
            GetPhoneDatas();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;
                filterText = filterTextBox.Text;
                GetPhoneDatas(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
