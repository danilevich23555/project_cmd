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
    public partial class WeekDataFromMissionListForm : Form
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
        public WeekDataFromMissionListForm(SqlConnection connection)
        {
            isOnOption = false;
            whereDate = DateTime.Now;
            filterOn = false;
            filterText = "";
            this.connection = connection;
            InitializeComponent();
        }
        private int DeleteWeekDataFromMission(int wdfmID)
        {
            try
            {
                string cmdText = "delete from WeekDatasFromMissions where wdfmID = " + wdfmID;
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
        public WeekDataFromMissionListForm(SqlConnection connection, DateTime whereDate) : this (connection)
        {
            isOnOption = true;
            this.whereDate = whereDate;
        }
        private int GetMissionsData(string where)
        {
            try
            {
                /*
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
                 * */
                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (wdfmDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string misCmdStr = @"select wdfmID, wdfmDate, mtName, empNotation, wdfmCountInf, wdfmCountMat, wdfmCountSpr, wdfmCountVoice, wdfmCountFreq, wdfmCountBearingSource from WeekDatasFromMissions
                                        left join Missions on (Missions.mID = WeekDatasFromMissions.mID)
                                        left join Employees on (Missions.empID = Employees.empID)
                                        left join MissionTargets on (MissionTargets.mtID = Missions.mtID) where (1=1) " +
                                     where + whereOption + @" order by wdfmDate desc, mtName";
                SqlDataAdapter adapter = new SqlDataAdapter(misCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("WeekDatasFromMissions");
                adapter.Fill(ds, "WeekDatasFromMissions");
                BindingSource bs = new BindingSource(ds, "WeekDatasFromMissions");
                dataGrid.DataSource = bs;
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "wdfmID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Дата";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Место командирования";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Сотрудник";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Кол-во информаций";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Кол-во материалов";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "Кол-во справок";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[7].HeaderText = "Кол-во источников";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[8].HeaderText = "Кол-во частот";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[9].HeaderText = "Кол-во пеленгов источников";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMissionsData()
        {
            try
            {
                GetMissionsData("");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void WeekDataFromMissionForm_Load(object sender, EventArgs e)
        {
            GetMissionsData();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            WeekDataFromMissionEditForm weekData = new WeekDataFromMissionEditForm(connection);
            weekData.ShowDialog();
            if (weekData.IsChanged) GetMissionsData();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetMissionsData();
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
                WeekDataFromMissionEditForm wdfmForm = new WeekDataFromMissionEditForm(connection, false, Convert.ToInt32(row.Cells[0].Value));
                wdfmForm.ShowDialog();
                if (wdfmForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetMissionsData(filterText);
                    }
                    else
                    {
                        GetMissionsData();
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
                result = MessageBox.Show("Вы дейстаительно хотите удалить занные за " + Convert.ToDateTime(row.Cells[1].Value).ToShortDateString() + " из командировки " + row.Cells[2].Value + "?", "Удалить данные из командировки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteWeekDataFromMission(Convert.ToInt32(row.Cells[0].Value)) == 0)
                    {
                        if (filterOn)
                        {
                            GetMissionsData(filterText);
                        }
                        else
                        {
                            GetMissionsData();
                        }
                    }

                }




            }
        }
    }
}
