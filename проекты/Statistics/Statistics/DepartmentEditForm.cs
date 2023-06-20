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
    public partial class DepartmentEditForm : Form
    {
        private bool isNew;
        private int depID;
        private SqlConnection connection;
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

        private int GetDirections()
        {
            try
            {
               
                string dirCmdStr = @"SELECT dirID, dirName from Directions Order by Directions.dirName";
                SqlDataAdapter dirAdapter = new SqlDataAdapter(dirCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Directions");
                dirAdapter.Fill(ds, "Directions");
                BindingSource bs = new BindingSource(ds, "Directions");
                directionСomboBox.DataSource = bs;
                directionСomboBox.ValueMember = "dirID";
                directionСomboBox.DisplayMember = "dirName";
                directionСomboBox.SelectedIndex = -1;
                departmentsTextBox.Enabled = false;
               return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetDepartments(int depID)
        {
            try
            {
                string depCmdStr = @"SELECT dirID, depName from Departments where depID = " + depID + " Order by depName";
                SqlCommand command = new SqlCommand(depCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    directionСomboBox.SelectedValue = Convert.ToInt32(reader[0]);
                    departmentsTextBox.Text = reader[1].ToString();
                }
                reader.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int AddDepartments(int dirID, string depName)
        {
            try
            {
                string cmdText = "insert into Departments (dirID, depName) values (" + dirID + ", '" + ToSQLServerString(depName) + "')";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "insert into Operatives (depID, opSurname, opNotation) values (" + lastId.ToString() + ", '-', '-')";
                command.ExecuteNonQuery();
                return 0;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditDepartments(int dirID, string depName)
        {
            try
            {
                string cmdText = "update Departments " +
                                 "set dirID = " + dirID + ", " +
                                 "depName = '" + ToSQLServerString(depName) + "' " +
                                 "where depID = " + this.depID;
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
        public DepartmentEditForm(SqlConnection connection, bool isNew)
        {

            this.connection = connection;
            this.isNew = isNew;
            InitializeComponent();
        }
        public DepartmentEditForm(SqlConnection connection, bool isNew, int depID) : this(connection, isNew)
        {
            this.depID = depID;
        }

        private void DepartmentsEditForm_Load(object sender, EventArgs e)
        {
            GetDirections();
            if (isNew)
            {
                this.Text = @"Добавить новое управление";
                OKButton.Text = @"Добавить";
            }
            else
            {
                this.Text = @"Изменить управление";
                OKButton.Text = @"Изменить";
                GetDepartments(depID);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void directionСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentsTextBox.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (directionСomboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите Службу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (departmentsTextBox.Text == "")
                {
                    MessageBox.Show("Введите наименование Управления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (isNew)
                    {
                        if (AddDepartments((int)directionСomboBox.SelectedValue, departmentsTextBox.Text) == 0)
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
                        if (EditDepartments((int)directionСomboBox.SelectedValue, departmentsTextBox.Text) == 0)
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
