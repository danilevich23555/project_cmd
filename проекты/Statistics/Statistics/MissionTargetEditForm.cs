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
    public partial class MissionTargetEditForm : Form
    {
        private bool isNew;
        private int mtID;
        private bool isChanged;

        public bool IsChanged
        {
            get { return isChanged; }
        }
        private SqlConnection connection;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        public MissionTargetEditForm(SqlConnection connection, bool isNew, int mtID)
        {
            this.isNew = isNew;
            isChanged = false;
            this.mtID = mtID;
            this.connection = connection;
            InitializeComponent();
        }
        public MissionTargetEditForm(SqlConnection connection) : this (connection, true, -1)
        {
            
        }
        private int AddMissionTarget()
        {
            try
            {
                string strCmd = "insert into MissionTargets (mtName) values ('" + ToSQLServerString(targetTextBox.Text) + "')";
                SqlCommand command = new SqlCommand(strCmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditMissionTarget()
        {
            try
            {
                string strCmd = "update MissionTargets set mtName = '" + ToSQLServerString(targetTextBox.Text) + "' where mtID = " + mtID.ToString();
                SqlCommand command = new SqlCommand(strCmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMissionTarget(int mtID)
        {
            try
            {
                string cmd = "SELECT mtName FROM MissionTargets where mtID = " + mtID.ToString();
                SqlCommand command = new SqlCommand(cmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    targetTextBox.Text = reader[0].ToString();
                }
                reader.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
        }

        private void MissionTargetsEditForm_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                this.Text = "Добавить место командирования";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменить место командирования";
                OKButton.Text = "Изменить";
                GetMissionTarget(mtID);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                if (AddMissionTarget() == 0)
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
                if (EditMissionTarget() == 0)
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
}
