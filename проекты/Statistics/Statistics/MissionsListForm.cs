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
    public partial class MissionsListForm : Form
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
        public MissionsListForm(SqlConnection connection)
        {
            isOnOption = false;
            whereDate = DateTime.Now;
            filterOn = false;
            filterText = "";
            this.connection = connection;
            InitializeComponent();
        }
        public MissionsListForm(SqlConnection connection, DateTime whereDate) : this(connection)
        {
            isOnOption = true;
            this.whereDate = whereDate;

        }
        private int DelMission(int mID)
        {
            try
            {
                string cmdText = "delete from Missions where mID = " + mID;
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
        private int GetMissions(string where)
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
                    whereOption = " AND (mFinishDate >= '" + whereDate.ToShortDateString() + "') ";
                }
                string misCmdStr = @"select Missions.mID, mtName, empNotation, mStartDate, mCountDays, mFinishDate from Missions 
                                     left join MissionTargets on (Missions.mtID = MissionTargets.mtID)
                                     left join Employees on (Employees.empID = Missions.empID) where (1=1) " +
                                     where + whereOption + @" order by  mFinishDate desc, mtName, empName desc";
                SqlDataAdapter adapter = new SqlDataAdapter(misCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Missions");
                adapter.Fill(ds, "Missions");
                BindingSource bs = new BindingSource(ds, "Missions");
                dataGrid.DataSource = bs;
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "mID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Место командирования";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[2].HeaderText = "Сотрудник";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Начало командирования";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Кол-во суток";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "Конец командирования";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMissions()
        {
            try
            {
                GetMissions("");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            MissionEditForm missionEditForm = new MissionEditForm(connection);
            missionEditForm.ShowDialog();
            if (missionEditForm.IsChanged) GetMissions();
        }

        private void MissionsListForm_Load(object sender, EventArgs e)
        {
            GetMissions();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetMissions();
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
                MissionEditForm letForm = new MissionEditForm(connection, false, (int)row.Cells[0].Value);
                letForm.ShowDialog();
                if (letForm.IsChanged)
                {
                    if (filterOn)
                    {
                        GetMissions(filterText);
                    }
                    else
                    {
                        GetMissions();
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
                if (
                    MessageBox.Show(
                        "Вы действительно хотите удалить командровку: " + row.Cells[1].Value.ToString() + " - " + row.Cells[2].Value.ToString() + " с " +
                        Convert.ToDateTime(row.Cells[3].Value).ToShortDateString() + " на " + row.Cells[4].Value + "суток?",
                        "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    DelMission((int) row.Cells[0].Value);
                    if (filterOn)
                    {
                        GetMissions(filterText);
                    }
                    else
                    {
                        GetMissions();
                    }

                }
            }
        }   
    }
}
