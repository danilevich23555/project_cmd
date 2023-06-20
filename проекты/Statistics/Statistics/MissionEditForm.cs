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
    public partial class MissionEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int mID;
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
        public MissionEditForm(SqlConnection connection, bool isNew, int mID)
        {
            isChanged = false;
            this.connection = connection;
            this.isNew = isNew;
            this.mID = mID;
            InitializeComponent();
        }
        public MissionEditForm(SqlConnection connection) : this (connection, true, -1)
        {
        }
        private int GetMission(int mID)
        {
            try
            {
                string misCmdStr = "select mtID, empID, mStartDate, mCountDays from Missions where mID = " + mID;
                SqlCommand command = new SqlCommand(misCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    missionTargetComboBox.SelectedValue = reader[0];
                    empComboBox.SelectedValue = reader[1];
                    startMissionDatePicker.Value = Convert.ToDateTime(reader[2]);
                    countDaysNumeric.Value = Convert.ToInt32(reader[3]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetMissionTargets()
        {
            try
            {
                string thCmdStr = @"SELECT mtID, mtName FROM MissionTargets";
                SqlDataAdapter mtAdapter = new SqlDataAdapter(thCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MissionTargets");
                mtAdapter.Fill(ds, "MissionTargets");
                BindingSource bs = new BindingSource(ds, "MissionTargets");
                missionTargetComboBox.DataSource = bs;
                missionTargetComboBox.ValueMember = "mtID";
                missionTargetComboBox.DisplayMember = "mtName";
                missionTargetComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetEmployees(bool napr3)
        {
            try
            {
                DataSet ds = new DataSet();
                string empCmdStr = "";
                if (napr3)
                {
                    empCmdStr = @"SELECT empID, empNotation FROM Sections INNER JOIN (Subsections INNER JOIN Employees ON Subsections.ssID = Employees.ssID) ON Sections.sID = Subsections.sID " +
                                 "WHERE (((Subsections.ssName)='3 направление') AND ((Sections.sName)='3 отдел')) ORDER BY Employees.empNotation";
                }
                else
                {
                    empCmdStr = @"SELECT empID, empNotation FROM Sections INNER JOIN (Subsections INNER JOIN Employees ON Subsections.ssID = Employees.ssID) ON Sections.sID = Subsections.sID " +
                                 "WHERE (((Sections.sName)='3 отдел')) ORDER BY Employees.empNotation";
                }

                SqlDataAdapter empAdapter = new SqlDataAdapter(empCmdStr, connection);
                ds.Tables.Add("Employees");
                empAdapter.Fill(ds, "Employees");
                BindingSource bsEmp = new BindingSource(ds, "Employees");
                empComboBox.DataSource = bsEmp;
                empComboBox.ValueMember = "empID";
                empComboBox.DisplayMember = "empNotation";
                empComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddMission()
        {
            try
            {
                string empID = "";
                if (empComboBox.SelectedValue == null) empID = "null";
                else empID = empComboBox.SelectedValue.ToString();
                string cmdStr = @"insert into Missions (mtID, empID, mStartDate, mCountDays, mFinishDate) values ("
                                    + missionTargetComboBox.SelectedValue + ", "
                                    + empID + ", "
                                    + "'" + startMissionDatePicker.Value.ToShortDateString() + "', "
                                    + countDaysNumeric.Value + ", "
                                    + "'" + startMissionDatePicker.Value.AddDays((double)countDaysNumeric.Value - 1) + "')";
                SqlCommand command = new SqlCommand(cmdStr, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;

            }
        }
        private int EditMission()
        {
            try
            {
                string empID = "";
                if (empComboBox.SelectedValue == null) empID = "null";
                else empID = empComboBox.SelectedValue.ToString();
                string cmdStr = @"Update Missions 
                                    set empID = " + empID + ", " +
                                "mStartDate = '" + startMissionDatePicker.Value.ToShortDateString() + "', " +
                                "mCountDays = " + countDaysNumeric.Value + ", " +
                                "mFinishDate = '" +
                                startMissionDatePicker.Value.AddDays((double) countDaysNumeric.Value - 1) + "'" +
                                "where mID = " + mID;
                SqlCommand command = new SqlCommand(cmdStr, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;

            }
        }
        private void MissionEditForm_Load(object sender, EventArgs e)
        {
            GetMissionTargets();
            GetEmployees(only3NaprCheckBox.Checked);
            if (this.isNew)
            {
                this.Text = "Добавление новой командировки";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменение командировки";
                OKButton.Text = "Изменить";
                GetMission(this.mID);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (missionTargetComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите место командирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isNew)
                {
                    if (AddMission() == 0)
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

                    if (EditMission() == 0)
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

        private void clearEmpButton_Click(object sender, EventArgs e)
        {
            empComboBox.SelectedIndex = -1;
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            EmployeeEditForm employeeEditForm = new EmployeeEditForm(connection, true);
            employeeEditForm.ShowDialog();
            if (employeeEditForm.IsChanged) GetEmployees(only3NaprCheckBox.Checked);
        }

        private void only3NaprCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GetEmployees(only3NaprCheckBox.Checked);
        }

        private void addTargetButton_Click(object sender, EventArgs e)
        {
            MissionTargetEditForm missionTarget = new MissionTargetEditForm(connection);
            missionTarget.ShowDialog();
            if (missionTarget.IsChanged) GetMissionTargets();
        }
    }
}
