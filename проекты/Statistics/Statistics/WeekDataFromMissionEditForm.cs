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
    public partial class WeekDataFromMissionEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int wdfmID;
        private bool isChanged;
        public bool IsChanged
        {
            get
            {
                return isChanged;
            }
        }
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        public WeekDataFromMissionEditForm(SqlConnection connection, bool isNew, int wdfmID)
        {
            isChanged = false;
            this.connection = connection;
            this.isNew = isNew;
            this.wdfmID = wdfmID;
            InitializeComponent();
        }
        public WeekDataFromMissionEditForm(SqlConnection connection) : this(connection, true, -1)
        {
            
        }

        private int GetMissions(DateTime date)
        {
            try
            {
                string misCmdStr = @"select mID, mtName + ': ' + empNotation  as mName from Missions
                                        left join Employees on (Missions.empID = Employees.empID)
                                        left join MissionTargets on (MissionTargets.mtID = Missions.mtID) " +
                                        "where (mStartDate <= '" + date.ToShortDateString() + "') AND (mFinishDate >= '" + date.ToShortDateString() + "')" +                                                             
                                        " order by mtName ";
                SqlDataAdapter mtAdapter = new SqlDataAdapter(misCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MissionTargets");
                mtAdapter.Fill(ds, "MissionTargets");
                BindingSource bs = new BindingSource(ds, "MissionTargets");
                missionsComboBox.DataSource = bs;
                missionsComboBox.ValueMember = "mID";
                missionsComboBox.DisplayMember = "mName";
                missionsComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetWeekDataFromMission()
        {
            try
            {
                string cmdStr = @"select wdfmDate, mID, wdfmCountInf, wdfmCountMat, wdfmCountSpr, wdfmCountVoice, wdfmCountFreq, wdfmCountBearingSource from WeekDatasFromMissions where wdfmID =  " + wdfmID;
                SqlCommand command = new SqlCommand(cmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datePicker.Value = Convert.ToDateTime(reader[0]);
                    missionsComboBox.SelectedValue = reader[1];
                    informNumeric.Value = Convert.ToInt32(reader[2]);
                    matNumeric.Value = Convert.ToInt32(reader[3]);
                    sprNumeric.Value = Convert.ToInt32(reader[4]);
                    voiceNumeric.Value = Convert.ToInt32(reader[5]);
                    freqNumeric.Value = Convert.ToInt32(reader[6]);
                    bearingNumeric.Value = Convert.ToInt32(reader[7]);
                }
                return 0;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        private int AddWeekDataFromMission()
        {
            try
            {
                string cmdStr = @"insert into WeekDatasFromMissions (wdfmDate, mID, wdfmCountInf, wdfmCountMat, wdfmCountSpr, wdfmCountVoice, wdfmCountFreq, wdfmCountBearingSource) values ("
                        + "'" + datePicker.Value.ToShortDateString() + "', "
                        + missionsComboBox.SelectedValue + ", "
                        + informNumeric.Value + ", "
                        + matNumeric.Value + ", "
                        + sprNumeric.Value + ", "
                        + voiceNumeric.Value + ", "
                        + freqNumeric.Value + ", "
                        + bearingNumeric.Value + ")";
                SqlCommand command = new SqlCommand(cmdStr, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        private int EditWeekDataFromMission()
        {
            
            string cmdStr = @"update WeekDatasFromMissions set "
                           + "wdfmDate = '" + datePicker.Value.ToShortDateString() + "', "
                           + "mID = " + missionsComboBox.SelectedValue + ", "
                           + "wdfmCountInf = " + informNumeric.Value + ", "
                           + "wdfmCountMat = " + matNumeric.Value + ", "
                           + "wdfmCountSpr = " + sprNumeric.Value + ", "
                           + "wdfmCountVoice = " + voiceNumeric.Value + ", "
                           + "wdfmCountFreq = " + freqNumeric.Value + ", "
                           + "wdfmCountBearingSource = " + bearingNumeric.Value 
                           + " where wdfmID = " + wdfmID;
            SqlCommand command = new SqlCommand(cmdStr, connection);
            command.ExecuteNonQuery();
            return 0;

        }
        private void WeekDataFromMissionEditForm_Load(object sender, EventArgs e)
        {
            GetMissions(datePicker.Value);
            if (this.isNew)
            {
                this.Text = "Добавлее данных из командировки";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменение данных из командировки";
                OKButton.Text = "Изменить";
                GetWeekDataFromMission();
            }
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            GetMissions(datePicker.Value);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (missionsComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите командировку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isNew)
                {
                    if (AddWeekDataFromMission() == 0)
                    {
                        isChanged = true;
                        this.Close();
                    }
                    else
                    {
                        isChanged = false;
                    }
                }
                else
                {

                    if (EditWeekDataFromMission() == 0)
                    {
                        isChanged = true;
                        this.Close();
                    }
                    else
                    {
                        isChanged = false;
                    }

                }
            }
        }

        private void addMissionButton_Click(object sender, EventArgs e)
        {
            MissionEditForm mission = new MissionEditForm(connection);
            mission.ShowDialog();
            if (mission.IsChanged) GetMissions(datePicker.Value);
        }
    }
}
