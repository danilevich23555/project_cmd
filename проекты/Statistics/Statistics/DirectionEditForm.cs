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
    public partial class DirectionEditForm : Form
    {
        private bool isNew;
        private int dirID;
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
        private int AddDirection()
        {
            try
            {
                string strCmd = "insert into Directions (dirName) values ('" + ToSQLServerString(directionTextBox.Text) +"')";
                SqlCommand command = new SqlCommand(strCmd,connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditDirection()
        {
            try
            {
                string strCmd = "update Directions set dirName = '" + ToSQLServerString(directionTextBox.Text) + "' where dirID = " + dirID.ToString();
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
        private int GetDirection(int dirID)
        {
            try
            {
                string cmd = "SELECT dirName FROM Directions where dirID = " + dirID.ToString();
                SqlCommand command = new SqlCommand(cmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    directionTextBox.Text = reader[0].ToString();
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
        public DirectionEditForm(SqlConnection connection, bool isNew, int dirID)
        {
            this.connection = connection;
            this.isNew = isNew;
            this.dirID = dirID;
            InitializeComponent();
        }
        public DirectionEditForm(SqlConnection connection, bool isNew) : this(connection, isNew, -1)
        {              
        }
        private void DirectionEditForm_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                this.Text = "Добавить новую Службу";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменить новую Службу";
                OKButton.Text = "Изменить";
                GetDirection(dirID);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                if (AddDirection() == 0)
                {
                    isChanged = true;
                }
                else
                {
                    isChanged = false;
                }
                this.Close();              
            }
            else
            {
                if (EditDirection() == 0)
                {
                    isChanged = true;
                }
                else
                {
                    isChanged = false;
                }
                this.Close();  
            }
        }
    }
}
