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
    public partial class PhoneDataEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int prdID;
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
        public PhoneDataEditForm(SqlConnection connection, bool isNew)
        {
            this.connection = connection;
            this.isNew = isNew;
            isChanged = false;
            InitializeComponent();
        }
        public PhoneDataEditForm(SqlConnection connection, bool isNew, int prdID) : this (connection, isNew)
        {
            this.prdID = prdID;
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
        private int GetEmpWithPriv()
        {
            try
            {
                DataSet ds = new DataSet();
                string empCmdStr = "";
                empCmdStr = @"SELECT empID, empNotation FROM Employees
                              where empPhonePrivilege = 1  ORDER BY Employees.empNotation";
                SqlDataAdapter empAdapter = new SqlDataAdapter(empCmdStr, connection);
                ds.Tables.Add("Employees");
                empAdapter.Fill(ds, "Employees");
                BindingSource bsEmp = new BindingSource(ds, "Employees");
                empPrivComboBox.DataSource = bsEmp;
                empPrivComboBox.ValueMember = "empID";
                empPrivComboBox.DisplayMember = "empNotation";
                empPrivComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetPhoneRegData(int prdID)
        {
            try
            {
                string strCmd =
                    "select prdDate, empID, empIDPriv, prdNumber, prdData, prdBase FROM  PhoneRegDatas  where prdID = " +
                    prdID;                        
                SqlCommand command = new SqlCommand(strCmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prdDatePicker.Value = Convert.ToDateTime(reader[0]);
                    empComboBox.SelectedValue = reader[1];
                    empPrivComboBox.SelectedValue = reader[2];
                    prdPhoneTextBox.Text = reader[3].ToString();
                    phoneDataRichTextBox.Text = reader[4].ToString();
                    baseTextBox.Text = reader[5].ToString();
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
        private int AddPhoneRegData()
        {
            try
            {
                string strCmd = "insert into PhoneRegDatas (prdDate , empID , empIDPriv , prdNumber , prdData , prdBase ) " +
                                "values (" +
                                "'" + prdDatePicker.Value.ToShortDateString() + "', " +
                                empComboBox.SelectedValue + ", " +
                                empPrivComboBox.SelectedValue + ", " +
                                "'" + ToSQLServerString(prdPhoneTextBox.Text) + "', " +
                                "'" + ToSQLServerString(phoneDataRichTextBox.Text) + "', " +
                                "'" + ToSQLServerString(baseTextBox.Text) + "'" +
                                ")";
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
        private int EditPhoneRegData(int prdID)
        {
            try
            {
                string strCmd = "update PhoneRegDatas " +
                                "set " +
                                "prdDate = " + "'" + prdDatePicker.Value.ToShortDateString() + "', " +
                                "empID = " + empComboBox.SelectedValue +", " +
                                "empIDPriv = " + empPrivComboBox.SelectedValue + "," +
                                "prdNumber = " + "'" + ToSQLServerString(prdPhoneTextBox.Text) + "', " +
                                "prdData = " +"'" + ToSQLServerString(phoneDataRichTextBox.Text) + "', " +
                                " prdBase  = " + "'" + ToSQLServerString(baseTextBox.Text) + "'" +
                                "where prdID = " + prdID;
                                
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
        private void PhoneDataEditForm_Load(object sender, EventArgs e)
        {
            GetEmployees(only3NaprCheckBox.Checked);
            GetEmpWithPriv();
            if (this.isNew)
            {
                this.Text = "Добавление новой установки";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменение установки";
                OKButton.Text = "Изменить";
                GetPhoneRegData(this.prdID);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (prdPhoneTextBox.Text == "")
            {
                MessageBox.Show("Введите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                    if (empComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Выберите дающего телефон в установку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (empPrivComboBox.SelectedValue == null)
                        {
                            MessageBox.Show("Выберите от чьего имени дается телефон в установку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (baseTextBox.Text == "")
                            {
                                MessageBox.Show("Введите основание для дачи номера телефона в установку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                
                                    if (isNew)
                                    {
                                        if (AddPhoneRegData() == 0)
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
                                        
                                        if (EditPhoneRegData(this.prdID) == 0)
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
                }
            }
        }
    
}
