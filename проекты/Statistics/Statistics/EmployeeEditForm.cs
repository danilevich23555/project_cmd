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
    public partial class EmployeeEditForm : Form
    {
        private SqlConnection connection;
        private bool loadedSect;
        private int empID;
        private bool isNew;
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
        private string GetNotation()
        {
            string notation = "";
            notation = surnameTextBox.Text;
            if ((nameTextBox.Text == "") | (nameTextBox.Text == " ") | (nameTextBox.Text == "-"))
            {
            }
            else
            {
                notation += " " + nameTextBox.Text.Substring(0, 1) + ".";
            }
            if ((patronymicTextBox.Text == "") | (patronymicTextBox.Text == " ") | (patronymicTextBox.Text == "-"))
            {
            }
            else
            {
                notation += patronymicTextBox.Text.Substring(0, 1) + ".";
            }

            return notation;
        }
        private int GetSections()
        {
            try
            {
                subsectionComboBox.Enabled = false;
                loadedSect = false;
                string sectionStrCmd = @"SELECT sID, sName FROM Sections order by sName";
                SqlDataAdapter adapter = new SqlDataAdapter(sectionStrCmd, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Sections");
                adapter.Fill(ds, "Sections");
                BindingSource bs = new BindingSource(ds, "Sections");
                sectionComboBox.DataSource = bs;
                sectionComboBox.ValueMember = "sID";
                sectionComboBox.DisplayMember = "sName";
                sectionComboBox.SelectedIndex = -1;
                loadedSect = true;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetSubsections(int sID)
        {
            try
            {

                //loadedSubsect = false;
                string subsectionStrCmd = @"SELECT ssID, ssName FROM Subsections where sID = " + sID + " order by ssName";
                SqlDataAdapter adapter = new SqlDataAdapter(subsectionStrCmd, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Subsections");
                adapter.Fill(ds, "Subsections");
                BindingSource bs = new BindingSource(ds, "Subsections");
                subsectionComboBox.DataSource = bs;
                subsectionComboBox.ValueMember = "ssID";
                subsectionComboBox.DisplayMember = "ssName";
                subsectionComboBox.SelectedIndex = -1;
                //loadedSubsect = true;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddEmployee()
        {
            try
            {

                string insStrCmd = @"insert into Employees (empSurname, empName, empPatronymic, empNotation, ssID) values ("
                                    + "'" + ToSQLServerString(surnameTextBox.Text) + "', "
                                    + "'" + ToSQLServerString(nameTextBox.Text) + "', "
                                    + "'" + ToSQLServerString(patronymicTextBox.Text) + "', "
                                    + "'" + ToSQLServerString(GetNotation()) + "', "
                                    + subsectionComboBox.SelectedValue + ")";
                SqlCommand command = new SqlCommand(insStrCmd, connection);
                command.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditEmployee(int empID)
        {
            try
            {


                string insStrCmd = @"update Employees set "
                                    + " empSurname = '" + ToSQLServerString(surnameTextBox.Text) + "', "
                                    + " empName = '" + ToSQLServerString(nameTextBox.Text) + "', "
                                    + " empPatronymic = '" + ToSQLServerString(patronymicTextBox.Text) + "', "
                                    + " empNotation = '" + ToSQLServerString(GetNotation()) + "', "
                                    + " ssID = " + subsectionComboBox.SelectedValue + " "
                                    + " where empID = " + empID;

                SqlCommand command = new SqlCommand(insStrCmd, connection);
                command.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetEmployee(int empID)
        {
            try
            {
                string empStrCmd = @"SELECT empSurname, empName, empPatronymic, sID, employees.ssID FROM Employees join SubSections on (Employees.ssID = SubSections.ssID)  where Employees.empID = " + empID;
                SqlCommand command = new SqlCommand(empStrCmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (GetSections() == 0)
                    {
                        surnameTextBox.Text = reader[0].ToString();
                        nameTextBox.Text = reader[1].ToString();
                        patronymicTextBox.Text = reader[2].ToString();
                        sectionComboBox.SelectedValue = reader[3];
                        subsectionComboBox.Enabled = true;
                        GetSubsections((int)reader[3]);
                        subsectionComboBox.SelectedValue = reader[4];
                    }

                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public EmployeeEditForm(SqlConnection connection, bool isNew)
        {
            isChanged = false;
            loadedSect = false;
            this.connection = connection;
            this.isNew = isNew;
            InitializeComponent();
        }
        public EmployeeEditForm(SqlConnection connection, bool isNew, int empID) : this(connection, isNew)
        {
            this.empID = empID;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                OKButton.Text = "Добавить";
                this.Text = "Добавить нового сотрудника";
                GetSections();
            }
            else
            {
                OKButton.Text = "Изменить";
                this.Text = "Изменить данные об сотруднике";
                GetEmployee(empID);
            }

        }

        private void sectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((loadedSect) & (sectionComboBox.SelectedValue != null))
            {
                subsectionComboBox.Enabled = true;
                GetSubsections((int)sectionComboBox.SelectedValue);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (subsectionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Введите подразделение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (surnameTextBox.Text == "")
                {
                    MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (isNew)
                    {
                        if (AddEmployee() == 0)
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
                        if (EditEmployee(empID) == 0)
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
