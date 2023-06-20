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
    public partial class OperativeEditForm : Form
    {
        private bool isNew;
        private int opID;
        private SqlConnection connection;
        private bool loadedDir;
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
        public OperativeEditForm(SqlConnection connection, bool isNew)
        {
            this.loadedDir = false;
            this.connection = connection;
            this.isNew = isNew;
            InitializeComponent();
        }

        public OperativeEditForm(SqlConnection connection, bool isNew, int opID) : this (connection, isNew)
        {
            this.connection = connection;
            this.opID = opID;
        }
        private string GetNotation()
        {
            string notation = "";
            notation = opSurnameTextBox.Text;
            if ((opNameTextBox.Text == "") | (opNameTextBox.Text == " ") | (opNameTextBox.Text == "-"))
            {
            }
            else
            {
                notation += " " + opNameTextBox.Text.Substring(0, 1) + ".";
            }
            if ((opPatronymicTextBox.Text == "") | (opPatronymicTextBox.Text == " ") | (opPatronymicTextBox.Text == "-"))
            {
            }
            else
            {
                notation += opPatronymicTextBox.Text.Substring(0, 1) + ".";
            }

            return notation;
        }
        private int GetDirections()
        {
            try
            {
                loadedDir = false;
                depComboBox.Enabled = false;
                newDepartmentsButton.Enabled = false;
                string dirCmdStr = @"SELECT dirID, dirName from Directions Order by Directions.dirName";
                SqlDataAdapter dirAdapter = new SqlDataAdapter(dirCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Directions");
                dirAdapter.Fill(ds, "Directions");
                BindingSource bs = new BindingSource(ds, "Directions");
                dirComboBox.DataSource = bs;
                dirComboBox.ValueMember = "dirID";
                dirComboBox.DisplayMember = "dirName";
                dirComboBox.SelectedIndex = -1;
                loadedDir = true;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetDepartments(int dirID)
        {
            try
            {
                string depCmdStr = @"SELECT depID, depName from Departments where dirID = " + dirID + " Order by depName";
                SqlDataAdapter depAdapter = new SqlDataAdapter(depCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Departmets");
                depAdapter.Fill(ds, "Departmets");
                BindingSource bs = new BindingSource(ds, "Departmets");
                depComboBox.DataSource = bs;
                depComboBox.ValueMember = "depID";
                depComboBox.DisplayMember = "depName";
                depComboBox.SelectedIndex = -1;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetOperatives(int opID)
        {
            try
            {
                string opCmdStr = "SELECT opID, operatives.depID, opSurname, opName, opPatronymic, " +
                                  "opOS, opOS2, opOS3, " +
                                  "opWorkPhone, opWorkPhone2, opWorkPhone3, " +
                                  "opMobilePhone, opMobilePhone2, opMobilePhone3, departments.dirID " +
                                  "FROM Operatives left join Departments on (Operatives.depID = Departments.depID) left join Directions on (Departments.dirID = Directions.dirID) " +
                                  "where opID = " + opID;
                SqlCommand command = new SqlCommand(opCmdStr, connection);
                SqlDataReader opReader = command.ExecuteReader();
                while (opReader.Read())
                {
                    this.opID = (int)opReader[0];
                    GetDirections();
                    dirComboBox.SelectedValue = opReader[14];
                    depComboBox.Enabled = true;
                    newDepartmentsButton.Enabled = true;
                    GetDepartments((int)dirComboBox.SelectedValue);
                    depComboBox.SelectedValue = opReader[1];
                    opSurnameTextBox.Text = opReader[2].ToString();
                    opNameTextBox.Text = opReader[3].ToString();
                    opPatronymicTextBox.Text = opReader[4].ToString();
                    opOS1TextBox.Text = opReader[5].ToString();
                    opOS2TextBox.Text = opReader[6].ToString();
                    opOS3TextBox.Text = opReader[7].ToString();
                    opWorkPhone1TextBox.Text = opReader[8].ToString();
                    opWorkPhone2TextBox.Text = opReader[9].ToString();
                    opWorkPhone3TextBox.Text = opReader[10].ToString();
                    opMobilePhone1TextBox.Text = opReader[11].ToString();
                    opMobilePhone2TextBox.Text = opReader[12].ToString();
                    opMobilePhone3TextBox.Text = opReader[13].ToString();
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddNewOperative()
        {
            try
            {
                string addCmdText = @"insert into Operatives (depID, opSurname, opName, opPatronymic, opNotation, opOS, opOS2, opOS3, opWorkPhone, opWorkPhone2, opWorkPhone3, opMobilePhone, opMobilePhone2, opMobilePhone3)" +
                                                   " values (" +
                                                             depComboBox.SelectedValue.ToString() + ", " +
                                                             "'" + ToSQLServerString(opSurnameTextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opNameTextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opPatronymicTextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(GetNotation()) + "', " +
                                                             "'" + ToSQLServerString(opOS1TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opOS2TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opOS3TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opWorkPhone1TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opWorkPhone2TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opWorkPhone3TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opMobilePhone1TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opMobilePhone2TextBox.Text) + "', " +
                                                             "'" + ToSQLServerString(opMobilePhone3TextBox.Text) + "')";
                SqlCommand command = new SqlCommand(addCmdText, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditOperative()
        {
            try
            {
                string editCmdText = @"update Operatives " +
                                     " set " +
                                        "depID = " + depComboBox.SelectedValue.ToString() + ", " +
                                        "opSurname = " + "'" + ToSQLServerString(opSurnameTextBox.Text) + "', " +
                                        "opName = " + "'" + ToSQLServerString(opNameTextBox.Text) + "', " +
                                        "opPatronymic = " + "'" + ToSQLServerString(opPatronymicTextBox.Text) + "', " +
                                        "opNotation = " + "'" + ToSQLServerString(GetNotation()) + "', " +
                                        "opOS = " + "'" + ToSQLServerString(opOS1TextBox.Text) + "', " +
                                        "opOS2 = " + "'" + ToSQLServerString(opOS2TextBox.Text) + "', " +
                                        "opOS3 = " + "'" + ToSQLServerString(opOS3TextBox.Text) + "', " +
                                        "opWorkPhone = " + "'" + ToSQLServerString(opWorkPhone1TextBox.Text) + "', " +
                                        "opWorkPhone2 = " + "'" + ToSQLServerString(opWorkPhone2TextBox.Text) + "', " +
                                        "opWorkPhone3 = " + "'" + ToSQLServerString(opWorkPhone3TextBox.Text) + "', " +
                                        "opMobilePhone = " + "'" + ToSQLServerString(opMobilePhone1TextBox.Text) + "', " +
                                        "opMobilePhone2 = " + "'" + ToSQLServerString(opMobilePhone2TextBox.Text) + "', " +
                                        "opMobilePhone3 = " + "'" + ToSQLServerString(opMobilePhone3TextBox.Text) + "'" +
                                        " where opID = " + opID;
                SqlCommand command = new SqlCommand(editCmdText, connection);
                command.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void OperativeEditForm_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                OKButton.Text = "Добавить";
                this.Text = "Добавить нового оперативника";
                GetDirections();
            }
            else
            {
                OKButton.Text = "Изменить";
                this.Text = "Изменить данные об оперативнике";
                GetOperatives(opID);
            }
        }

        private void dirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((loadedDir) & (dirComboBox.SelectedValue != null))
            {
                depComboBox.Enabled = true;
                newDepartmentsButton.Enabled = true;
                GetDepartments((int)dirComboBox.SelectedValue);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (dirComboBox.SelectedValue == null)
            {
                MessageBox.Show("Не заполнено поле Служба", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (depComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Не заполнено поле Управление", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (opSurnameTextBox.Text == "")
                    {
                        MessageBox.Show("Не заполнено поле Фамилия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (isNew)
                        {
                            if (AddNewOperative() == 0)
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
                            if (EditOperative() == 0)
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            this.Close();
        }

        private void newDirectionButton_Click(object sender, EventArgs e)
        {
            DirectionEditForm dirForm = new DirectionEditForm(connection, true);
            dirForm.ShowDialog();
            if (dirForm.IsChanged)
            {
                depComboBox.SelectedValue = -1;
                GetDirections();
            }
        }

        private void newDepartmentsButton_Click(object sender, EventArgs e)
        {
            DepartmentEditForm depForm = new DepartmentEditForm(connection, true);
            depForm.ShowDialog();
            if (depForm.IsChanged)
            {
                GetDepartments((int)dirComboBox.SelectedValue);
            }
        }
    }
}
