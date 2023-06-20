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
    public partial class UKRFEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private string ukNumber;
        private bool isChanged;
        public bool IsChanged
        {
            get { return isChanged; }
        }
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int GetUKRF(string ukNumber)
        {
            try
            {
                string ukrfCmdStr = "select ukNumber, ukCaption from UKRF " +
                                  "where ukNumber = '" + ToSQLServerString(ukNumber) + "' order by ukNumber";
                SqlCommand command = new SqlCommand(ukrfCmdStr, connection);
                SqlDataReader ukrfReader = command.ExecuteReader();
                while (ukrfReader.Read())
                {
                    ukNumberTextBox.Text = ukrfReader[0].ToString();
                    ukCaptionTextBox.Text = ukrfReader[1].ToString();
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddUK()
        {
            try
            {
                string cmd = "insert into UKRF (ukNumber, ukCaption) values ('" + ToSQLServerString(ukNumberTextBox.Text) + "', '" + ToSQLServerString(ukCaptionTextBox.Text) + "')";
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditUK()
        {
            try
            {
                string cmd = "update UKRF set ukCaption =  '" + ToSQLServerString(ukCaptionTextBox.Text) + "' where ukNumber = '" + ToSQLServerString(ukNumberTextBox.Text) + "'";
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public UKRFEditForm(SqlConnection connection, bool isNew)
        {
            isChanged = false;
            this.connection = connection;
            this.isNew = isNew;
            InitializeComponent();
        }
        public UKRFEditForm(SqlConnection connection, bool isNew, string ukNumber) : this (connection, isNew)
        {
            this.ukNumber = ukNumber;
        }

        private void UKRFEditForm_Load(object sender, EventArgs e)
        {
            ukNumberTextBox.Enabled = isNew;
            if (isNew)
            {
                this.Text = "Добавить статью";
                OKButton.Text = "Добавить";
            }
            else
            {
                this.Text = "Изменить статью";
                OKButton.Text = "Изменить";
                GetUKRF(this.ukNumber);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ukNumberTextBox.Text == "")
            {
                MessageBox.Show("Введите номер статьи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ukCaptionTextBox.Text == "")
                {
                    MessageBox.Show("Введите заголовок статьи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (isNew)
                    {
                        if (AddUK() == 0)
                        {
                            isChanged = true;
                            Close();
                        }
                        else
                        {
                            isChanged = false;
                        }
                    }
                    else
                    {
                        if (EditUK() == 0)
                        {
                            isChanged = true;
                            Close();
                        }
                        else
                        {
                            isChanged = false;
                        }
                    }
                }
            }
        }



    }
}
