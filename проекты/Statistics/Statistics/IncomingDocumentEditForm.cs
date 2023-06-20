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
    public partial class IncomingDocumentEditForm : Form
    {
        private SqlConnection connection;
        private const int expressDays = 3;
        private bool isNew;
        private int idID;
        private bool isProlonged;
        private DateTime idFinishDate;
        private bool loadedDir;
        private bool loadedDep;
        private bool isChanged;
        private const int maxLenghtPhone = 50;
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
        public IncomingDocumentEditForm(SqlConnection connection, bool isNew)
        {
            this.isNew = isNew;
            loadedDir = false;
            loadedDep = false;
            isChanged = false;
            this.connection = connection;
            InitializeComponent();
        }
        public IncomingDocumentEditForm(SqlConnection connection, bool isNew, int idID) : this (connection, isNew)
        {
            this.idID = idID;
        }
       
        private int GetDaysDuration(int i, SqlCommand command)
        {
            try
            {

                string durCmdStr = @"select dtDays from DocTypes " +
                                    "where dtID = " + i.ToString();
                command.CommandText = durCmdStr;
                
               
                SqlDataReader reader = command.ExecuteReader();
                int k = -1;
                while (reader.Read())
                {
                   k = Convert.ToInt32(reader[0]);
                }
               reader.Close();
               return k;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddPhoneNumber(string cmdText, SqlCommand command)
        {
            try
            {
                command.CommandText = cmdText;
                command.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        private int AddPhoneNumbers(int idID, SqlCommand command)
        {
            try
            {
                string delCmdStr = "delete from Numbers where idID = " + idID;
                string error = "Номер(а) ";
                //SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.CommandText = delCmdStr;
                command.ExecuteNonQuery();
                string addCmdStr = "";
                for (int i = 0; i < numbersRichTextBox.Lines.Length; i++)
                {


                    if (!((numbersRichTextBox.Lines[i] == "") | (numbersRichTextBox.Lines[i] == " ")))
                    {
                        if (numbersRichTextBox.Lines[i].Length <= maxLenghtPhone)
                        {
                            addCmdStr = @"insert into Numbers (idID, phoneNumber) values (" + idID + ", '" + numbersRichTextBox.Lines[i] + "')";
                        }
                        else
                        {
                            error = error + numbersRichTextBox.Lines[i];
                            addCmdStr = @"insert into Numbers (idID, phoneNumber) values (" + idID + ", '" + numbersRichTextBox.Lines[i].Substring(0, maxLenghtPhone) + "')";
                        }
                        AddPhoneNumber(addCmdStr, command);

                    }
                }
                if (error != "Номер(а) ")
                {
                    error = error + @" слишком длинные, он(они) были урезаны до " + maxLenghtPhone + " знаков";
                    MessageBox.Show(error, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetDirections()
        {
            try
            {
                operComboBox.SelectedIndex = -1;
                depComboBox.SelectedIndex = -1;
                operComboBox.Enabled = false;
                depComboBox.Enabled = false;
                addOperButton.Enabled = false;
                editOperButton.Enabled = false;
                addDepButton.Enabled = false;
                loadedDir = false;
                loadedDep = false;
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
                operComboBox.SelectedIndex = -1;
                operComboBox.Enabled = false;
                addOperButton.Enabled = false;
                editOperButton.Enabled = false;
                loadedDep = false;
                string depCmdStr = @"SELECT depID, depName from Departments where dirID = " + dirID + " Order by depName";
                SqlDataAdapter depAdapter = new SqlDataAdapter(depCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Departmets");
                depAdapter.Fill(ds, "Departmets");
                BindingSource bs = new BindingSource(ds, "Departmets");
                depComboBox.DataSource = bs;
                depComboBox.ValueMember = "depID";
                depComboBox.DisplayMember = "depName";
                loadedDep = true;
                depComboBox.SelectedIndex = -1;


                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetOperatives(int depID)
        {
            try
            {

                string opCmdStr = @"SELECT opID, opNotation from Operatives where depID = " + depID + " Order by opNotation";
                SqlDataAdapter opAdapter = new SqlDataAdapter(opCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Operatives");
                opAdapter.Fill(ds, "Operatives");
                BindingSource bs = new BindingSource(ds, "Operatives");
                operComboBox.DataSource = bs;
                operComboBox.ValueMember = "opID";
                operComboBox.DisplayMember = "opNotation";
                operComboBox.SelectedIndex = -1;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetUKRF()
        {
            try
            {
                DataSet ds = new DataSet();
                string UKRFCmdStr = @"SELECT ukNumber, ukCaption FROM UKRF order by ukNumber";
                SqlDataAdapter UKRFAdapter = new SqlDataAdapter(UKRFCmdStr, connection);
                ds.Tables.Add("UKRF");
                UKRFAdapter.Fill(ds, "UKRF");
                BindingSource bsUKRF = new BindingSource(ds, "UKRF");
                UKRFComboBox.DataSource = bsUKRF;
                UKRFComboBox.ValueMember = "ukNumber";
                UKRFComboBox.DisplayMember = "ukNumber";
                UKRFComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetCountries()
        {
            try
            {
                string plCmdStr = @"select ctID, ctName from Countries order by ctIndex";
                SqlDataAdapter plAdapter = new SqlDataAdapter(plCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Countries");
                plAdapter.Fill(ds, "Countries");
                BindingSource bs = new BindingSource(ds, "Countries");
                countriesComboBox.DataSource = bs;
                countriesComboBox.ValueMember = "ctID";
                countriesComboBox.DisplayMember = "ctName";
                countriesComboBox.SelectedIndex = -1;
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
        private int GetOtherData()
        {
            try
            {
                DataSet ds = new DataSet();

                string taskTypeCmdStr = @"SELECT ttID, ttName FROM TaskTypes order by ttName";
                SqlDataAdapter taskTypeAdapter = new SqlDataAdapter(taskTypeCmdStr, connection);
                ds.Tables.Add("TaskType");
                taskTypeAdapter.Fill(ds, "TaskType");
                BindingSource bsTaskType = new BindingSource(ds, "TaskType");
                taskTypeComboBox.DataSource = bsTaskType;
                taskTypeComboBox.ValueMember = "ttID";
                taskTypeComboBox.DisplayMember = "ttName";
                taskTypeComboBox.SelectedIndex = -1;


                string docTypeCmdStr = @"SELECT dtID, dtName FROM DocTypes order by dtName";
                SqlDataAdapter docTypeAdapter = new SqlDataAdapter(docTypeCmdStr, connection);
                ds.Tables.Add("DocType");
                docTypeAdapter.Fill(ds, "DocType");
                BindingSource bsDocType = new BindingSource(ds, "DocType");
                docTypeComboBox.DataSource = bsDocType;
                docTypeComboBox.ValueMember = "dtID";
                docTypeComboBox.DisplayMember = "dtName";
                docTypeComboBox.SelectedIndex = -1;

                string UKRFCmdStr = @"SELECT ukNumber, ukCaption FROM UKRF order by ukNumber";
                SqlDataAdapter UKRFAdapter = new SqlDataAdapter(UKRFCmdStr, connection);
                ds.Tables.Add("UKRF");
                UKRFAdapter.Fill(ds, "UKRF");
                BindingSource bsUKRF = new BindingSource(ds, "UKRF");
                UKRFComboBox.DataSource = bsUKRF;
                UKRFComboBox.ValueMember = "ukNumber";
                UKRFComboBox.DisplayMember = "ukNumber";
                UKRFComboBox.SelectedIndex = -1;

                GetEmployees(only3CheckBox.Checked);
                GetCountries();

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetIncomingDocument(int idID)
        {
            try
            {
                string idCmdStr = @"SELECT IncomingDocuments.idID, 
                                           IncomingDocuments.idNumber, 
                                           IncomingDocuments.idDate, 
                                           IncomingDocuments.idIncomeNumber, 
                                           IncomingDocuments.idIncomeDate, 
                                           IncomingDocuments.empID, 
                                           IncomingDocuments.ttID, 
                                           IncomingDocuments.dtID, 
                                           IncomingDocuments.idDou, 
                                           IncomingDocuments.ukNumber, 
                                           IncomingDocuments.opID, 
                                           IncomingDocuments.idCommentary, 
                                           Directions.dirID, 
                                           Departments.depID, 
                                           IncomingDocuments.idExpress, 
                                           IncomingDocuments.idProlonged, 
                                           IncomingDocuments.idExecuted,
                                           IncomingDocuments.idFinishDate,
                                           IncomingDocuments.idSectionNumber, 
                                           IncomingDocuments.idSectionDate,
                                           IncomingDocuments.ctID
                                     FROM IncomingDocuments left join Operatives on (IncomingDocuments.opID = Operatives.opID)
									 left join Departments on (Operatives.depID = Departments.depID)
									 left join Directions on (Departments.dirID = Directions.dirID) " +
                                    "where idID = " + idID;
                SqlCommand command = new SqlCommand(idCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numberTextBox.Text = reader[1].ToString();
                    idDateTimePicker.Value = Convert.ToDateTime(reader[2]);
                    if ((reader[3].ToString() == "") & (reader[4].ToString() == ""))
                    {
                        IncomeNumberExistsCheckBox.Checked = true;
                    }
                    else
                    {
                        incomeNumberTextBox.Text = reader[3].ToString();
                        incomeDateTimePicker.Value = Convert.ToDateTime(reader[4]);
                    }
                    empComboBox.SelectedValue = reader[5];
                    taskTypeComboBox.SelectedValue = reader[6];
                    docTypeComboBox.SelectedValue = reader[7];
                    douTextBox.Text = reader[8].ToString();
                    if (reader[9].ToString() != "") UKRFComboBox.SelectedValue = reader[9];
                    commentaryRichTextBox.Text = reader[11].ToString();
                    if (reader[12].ToString() != "")
                    {
                        dirComboBox.SelectedValue = reader[12].ToString();
                        depComboBox.Enabled = true;
                        addDepButton.Enabled = true;
                        GetDepartments(Convert.ToInt32(dirComboBox.SelectedValue));
                        if (reader[13].ToString() != "")
                        {
                            depComboBox.SelectedValue = reader[13].ToString();
                            operComboBox.Enabled = true;
                            addOperButton.Enabled = true;
                            editOperButton.Enabled = true;
                            GetOperatives(Convert.ToInt32(depComboBox.SelectedValue));
                            operComboBox.SelectedValue = reader[10].ToString();
                        }
                    }
                    if (Convert.ToBoolean(reader[14])) expressCheckBox.Checked = true; else expressCheckBox.Checked = false;
                    isProlonged = Convert.ToBoolean(reader[15]);
                    if (Convert.ToBoolean(reader[16])) executeCheckBox.Checked = true; else executeCheckBox.Checked = false;
                    if (reader[17].ToString() != "") idFinishDate = Convert.ToDateTime(reader[17]); else idFinishDate = DateTime.Now;
                    incomeSectionNumberTextBox.Text = reader[18].ToString();
                    if (reader[19].ToString() != "") incomeSectionNumberDateTimePicker.Value = Convert.ToDateTime(reader[19]); else incomeSectionNumberDateTimePicker.Value = DateTime.Now;
                    GetNumbers((int)reader[0]);
                    if (reader[20].ToString() != "") countriesComboBox.SelectedValue = reader[20].ToString();
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetNumbers(int idID)
        {
            try
            {
                string numCmdStr = "Select phoneNumber from Numbers where idID = " + idID;
                SqlCommand command = new SqlCommand(numCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numbersRichTextBox.Text = numbersRichTextBox.Text + reader[0] + "\n";
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int AddIncomingDocument()
        {
            SqlTransaction transaction = connection.BeginTransaction("AddIncomingDocument");
            try
            {
                string idCommandText = "";
                int idExpress = 0;
                int idExecuted = 0;
                int countDays = 0;
                DateTime finishDate = new DateTime();
                SqlCommand command = new SqlCommand(idCommandText, connection);
                command.Transaction = transaction;
                if (expressCheckBox.Checked)
                {
                    countDays = expressDays;
                    idExpress = 1;
                }
                else
                {
                    idExpress = 0;
                    countDays = GetDaysDuration(Convert.ToInt32(docTypeComboBox.SelectedValue), command);
                }
                finishDate = incomeSectionNumberDateTimePicker.Value.AddDays(countDays);
                string incomeNumber = "";
                string incomeDate = "";
                if (IncomeNumberExistsCheckBox.Checked)
                {
                    incomeDate = "null";
                    incomeNumber = "null";
                }
                else
                {
                    incomeNumber = "'" + ToSQLServerString(incomeNumberTextBox.Text) + "'";
                    incomeDate = "'" + incomeDateTimePicker.Value.ToShortDateString() + "'";
                }
                if (executeCheckBox.Checked) idExecuted = 1; else idExecuted = 0;
                if (UKRFComboBox.SelectedValue == null)
                {
                    idCommandText = @"Insert into IncomingDocuments (idNumber, idDate, idIncomeNumber, idIncomeDate, idSectionNumber, idSectionDate,  empID, ttID, dtID, idDou, opID, idCommentary, idFinishDate, idExpress, idProlonged, idExecuted, ctID) values ("
                       + "'" + ToSQLServerString(numberTextBox.Text) + "', "
                       + "'" + idDateTimePicker.Value.ToShortDateString() + "', "
                       + incomeNumber + ", "
                       + incomeDate + ", "
                       + "'" + ToSQLServerString(incomeSectionNumberTextBox.Text) + "', "
                       + "'" + incomeSectionNumberDateTimePicker.Value.ToShortDateString() + "', "
                       + "'" + empComboBox.SelectedValue + "', "
                       + "'" + taskTypeComboBox.SelectedValue + "', "
                       + "'" + docTypeComboBox.SelectedValue + "', "
                       + "'" + ToSQLServerString(douTextBox.Text) + "', "
                       + "'" + operComboBox.SelectedValue + "', "
                       + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "', "
                       + "'" + finishDate.ToShortDateString() + "', "
                       + idExpress.ToString() + ", "
                       + " 0" + ", "
                       + idExecuted.ToString() + ", "
                       + countriesComboBox.SelectedValue.ToString()
                       + ") ";
                }
                else
                {
                    idCommandText = @"Insert into IncomingDocuments (idNumber, idDate, idIncomeNumber, idIncomeDate, idSectionNumber, idSectionDate, empID, ttID, dtID, idDou, opID, ukNumber, idCommentary, idFinishDate, idExpress, idProlonged, idExecuted, ctID) values ("
                       + "'" + ToSQLServerString(numberTextBox.Text) + "', "
                       + "'" + idDateTimePicker.Value.ToShortDateString() + "', "
                       + incomeNumber + ", "
                       + incomeDate + ", "
                       + "'" + ToSQLServerString(incomeSectionNumberTextBox.Text) + "', "
                       + "'" + incomeSectionNumberDateTimePicker.Value.ToShortDateString() + "', "
                       + "'" + empComboBox.SelectedValue + "', "
                       + "'" + taskTypeComboBox.SelectedValue + "', "
                       + "'" + docTypeComboBox.SelectedValue + "', "
                       + "'" + ToSQLServerString(douTextBox.Text) + "', "
                       + "'" + operComboBox.SelectedValue + "', "
                       + "'" + ToSQLServerString(UKRFComboBox.SelectedValue.ToString()) + "', "
                       + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "', "
                       + "'" + finishDate.ToShortDateString() + "', "
                       + idExpress.ToString() + ", "
                       + " 0" + ", "
                       + idExecuted.ToString() + ", "
                       + countriesComboBox.SelectedValue.ToString()
                       + ") ";
                }              
             
                
                command.CommandText = idCommandText;
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32(command.ExecuteScalar());
                AddPhoneNumbers(lastId, command);
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception exTran)
                {

                    MessageBox.Show(exTran.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
               
            }
        }
        private int EditIncomingDocument(int idID)
        {
            SqlTransaction transaction = connection.BeginTransaction("EditIncomingDocument");
            try
            {
                string idCommandText = "";
                SqlCommand command = new SqlCommand(idCommandText, connection);
                command.Transaction = transaction;
                int idExpress = 0;
                int idExecuted = 0;
                int countDays = 0;
                DateTime finishDate = new DateTime();
                if (isProlonged)
                {
                    finishDate = this.idFinishDate;
                }
                else
                {
                    if (expressCheckBox.Checked) countDays = expressDays; else countDays = GetDaysDuration(Convert.ToInt32(docTypeComboBox.SelectedValue),command);
                }
                if (expressCheckBox.Checked)
                {
                    idExpress = 1;
                }
                else
                {
                    idExpress = 0;
                }
                finishDate = incomeSectionNumberDateTimePicker.Value.AddDays(countDays);
                string incomeNumber = "";
                string incomeDate = "";
                if (IncomeNumberExistsCheckBox.Checked)
                {
                    incomeDate = "null";
                    incomeNumber = "null";
                }
                else
                {
                    incomeNumber = "'" + ToSQLServerString(incomeNumberTextBox.Text) + "'";
                    incomeDate = "'" + incomeDateTimePicker.Value.ToShortDateString() + "'";
                }
                if (executeCheckBox.Checked) idExecuted = 1; else idExecuted = 0;
                if (UKRFComboBox.SelectedValue == null)
                {
                    idCommandText = @"Update IncomingDocuments " +
                                      "set   idNumber = " + "'" + numberTextBox.Text + "', " +
                                      "idDate = " + "'" + idDateTimePicker.Value.ToShortDateString() + "', " +
                                      "idIncomeNumber = " + incomeNumber + ", " +
                                      "idIncomeDate = " + incomeDate + ", " +
                                      "idSectionNumber = " + "'" + ToSQLServerString(incomeSectionNumberTextBox.Text) + "', " +
                                      "idSectionDate = " + "'" + incomeSectionNumberDateTimePicker.Value.ToShortDateString() + "', " +
                                      "empID = " + "'" + empComboBox.SelectedValue + "', " +
                                      "ttID = " + "'" + taskTypeComboBox.SelectedValue + "', " +
                                      "dtID = " + "'" + docTypeComboBox.SelectedValue + "', " +
                                      "idDou = " + "'" + ToSQLServerString(douTextBox.Text) + "', " +
                                      "opID = " + "'" + operComboBox.SelectedValue + "', " +
                                      "ukNumber = " + "null, " +
                                      "idCommentary = " + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "' ," +
                                      "idFinishDate = " + "'" + finishDate.ToShortDateString() + "', " +
                                      "idExpress = " + idExpress.ToString() + ", " +
                                      "idExecuted = " + idExecuted.ToString() + ", " +
                                      "ctID = "+ countriesComboBox.SelectedValue + " " +
                                      " where idID = " + idID;
                }
                else
                {
                    idCommandText = @"Update IncomingDocuments " +
                                      "set   idNumber = " + "'" + ToSQLServerString(numberTextBox.Text) + "', " +
                                      "idDate = " + "'" + idDateTimePicker.Value.ToShortDateString() + "', " +
                                      "idIncomeNumber = " + incomeNumber + ", " +
                                      "idIncomeDate = " + incomeDate + ", " +
                                      "idSectionNumber = " + "'" + ToSQLServerString(incomeSectionNumberTextBox.Text) + "', " +
                                      "idSectionDate = " + "'" + incomeSectionNumberDateTimePicker.Value.ToShortDateString() + "', " +
                                      "empID = " + "'" + empComboBox.SelectedValue + "', " +
                                      "ttID = " + "'" + taskTypeComboBox.SelectedValue + "', " +
                                      "dtID = " + "'" + docTypeComboBox.SelectedValue + "', " +
                                      "idDou = " + "'" + ToSQLServerString(douTextBox.Text) + "', " +
                                      "opID = " + "'" + operComboBox.SelectedValue + "', " +
                                      "ukNumber = " + "'" + ToSQLServerString(UKRFComboBox.SelectedValue.ToString()) + "', " +
                                      "idCommentary = " + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "' ," +
                                      "idFinishDate = " + "'" + finishDate.ToShortDateString() + "', " +
                                      "idExpress = " + idExpress.ToString() + ", " +
                                      "idExecuted = " + idExecuted.ToString() + ", " +
                                      "ctID = " + countriesComboBox.SelectedValue + " " +
                                      " where idID = " + idID;
                }

                
                
                command.CommandText = idCommandText;
                command.ExecuteNonQuery();
                AddPhoneNumbers(idID,command);
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    transaction.Rollback();
                    return -1;
                }
                catch (Exception exTran)
                {

                    MessageBox.Show(exTran.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
               
            }
        }
        private void IncomingDocementEditFofm_Load(object sender, EventArgs e)
        {
            GetDirections();
            GetOtherData();
           
            if (this.isNew)
            {
                this.Text = "Добавление нового входящего документа";
                OKButton.Text = "Добавить";
                
            }
            else
            {
                this.Text = "Изменение входящего документа";
                OKButton.Text = "Изменить";
                GetIncomingDocument(this.idID);
            }

        }

        private void only3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GetEmployees(only3CheckBox.Checked);
        }

        private void dirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((dirComboBox.SelectedIndex > -1) & (loadedDir))
            {
                depComboBox.Enabled = true;
                addDepButton.Enabled = true;
                GetDepartments((int)dirComboBox.SelectedValue);
            }
        }

        private void depComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((depComboBox.SelectedIndex > -1) & (loadedDep))
            {
                GetOperatives((int)depComboBox.SelectedValue);
                operComboBox.Enabled = true;
                addOperButton.Enabled = true;
                editOperButton.Enabled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool DatesCorrect = true;
            if (numberTextBox.Text == "")
            {
                MessageBox.Show("Введите номер документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((!IncomeNumberExistsCheckBox.Checked) & (incomeNumberTextBox.Text == ""))
                {
                    MessageBox.Show("Введите входящий номер документа. Если он отсутствует - выберите опцию \"Отсутствует\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (incomeSectionNumberTextBox.Text == "")
                    {
                        MessageBox.Show("Введите входящий номер (отдела) документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (operComboBox.SelectedValue == null)
                        {
                            MessageBox.Show("Выберите оперативника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (taskTypeComboBox.SelectedValue == null)
                            {
                                MessageBox.Show("Выберите задачу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (docTypeComboBox.SelectedValue == null)
                                {
                                    MessageBox.Show("Выберите тип документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (empComboBox.SelectedValue == null)
                                    {
                                        MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (idDateTimePicker.Value > DateTime.Now)
                                        {
                                            MessageBox.Show("Дата подписи документа должна быть не больше " + DateTime.Now.ToShortDateString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if ((incomeDateTimePicker.Value > DateTime.Now) & !(IncomeNumberExistsCheckBox.Checked))
                                            {
                                                MessageBox.Show("Входящая дата документа должна быть не больше " + DateTime.Now.ToShortDateString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                if (incomeSectionNumberDateTimePicker.Value > DateTime.Now)
                                                {
                                                    MessageBox.Show("Входящая дата документа в отдел должна быть не больше " + DateTime.Now.ToShortDateString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    if (IncomeNumberExistsCheckBox.Checked)
                                                    {
                                                        if (idDateTimePicker.Value > incomeSectionNumberDateTimePicker.Value) DatesCorrect = false; else DatesCorrect = true;
                                                    }
                                                    else
                                                    {
                                                        if ((idDateTimePicker.Value > incomeSectionNumberDateTimePicker.Value) | (idDateTimePicker.Value > incomeDateTimePicker.Value) | (incomeDateTimePicker.Value > incomeSectionNumberDateTimePicker.Value))
                                                            DatesCorrect = false; else DatesCorrect = true;
                                                    }
                                                    if (!DatesCorrect)
                                                    {
                                                        MessageBox.Show("Ошибка, будьте внимательнее: дата подписи документа должна быть не больше входящей даты, которая в свою очередь не должна превышать входящую дату в отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    else
                                                    {
                                                        if (countriesComboBox.SelectedValue == null)
                                                        {
                                                            MessageBox.Show("Выберите страну", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        else
                                                        {
                                                            if (isNew)
                                                            {
                                                                if (AddIncomingDocument() == 0)
                                                                {
                                                                    isChanged = true;
                                                                    this.Close();
                                                                    CheckForm checkForm = new CheckForm(connection, numbersRichTextBox.Text);
                                                                    checkForm.ShowDialog();
                                                                }
                                                                else
                                                                {
                                                                    isChanged = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (EditIncomingDocument(idID) == 0)
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
                            }
                        }
                    }
                }
            }
        }

        private void clearUKRFButton_Click(object sender, EventArgs e)
        {
            UKRFComboBox.SelectedValue = -1;
        }

        private void clearNumbers_Click(object sender, EventArgs e)
        {
            numbersRichTextBox.Text = "";
        }

        private void editEmpButton_Click(object sender, EventArgs e)
        {
            if (empComboBox.SelectedValue == null)
            {
                MessageBox.Show("Для изменения вы должны выбрать оперативника.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EmployeeEditForm empForm = new EmployeeEditForm(connection, false, (int)empComboBox.SelectedValue);
                empForm.ShowDialog();
                if (empForm.IsChanged) GetEmployees(only3CheckBox.Checked);

            }
        }

        private void addDirButton_Click(object sender, EventArgs e)
        {
            DirectionEditForm dirForm = new DirectionEditForm(connection, true);
            dirForm.ShowDialog();
            if (dirForm.IsChanged)
            {
                depComboBox.SelectedValue = -1;
                GetDirections();
            }
        }

        private void addDepButton_Click(object sender, EventArgs e)
        {
            DepartmentEditForm depForm = new DepartmentEditForm(connection, true);
            depForm.ShowDialog();
            if (depForm.IsChanged)
            {
                GetDepartments((int)dirComboBox.SelectedValue);
            }

        }

        private void editOperButton_Click(object sender, EventArgs e)
        {
            if (operComboBox.SelectedValue == null)
            {
                MessageBox.Show("Для изменения вы должны выбрать оперативника.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OperativeEditForm operForm = new OperativeEditForm(connection, false, (int)operComboBox.SelectedValue);
                operForm.ShowDialog();
                if(operForm.IsChanged) GetOperatives((int)depComboBox.SelectedValue);
            }
        }

        private void addOperButton_Click(object sender, EventArgs e)
        {
            OperativeEditForm operForm = new OperativeEditForm(connection, true);
            operForm.ShowDialog();
            if (operForm.IsChanged) GetOperatives((int)depComboBox.SelectedValue);
        }

        private void addUKRFButton_Click(object sender, EventArgs e)
        {
            UKRFEditForm UKRFForm = new UKRFEditForm(connection, true);
            UKRFForm.ShowDialog();
            if (UKRFForm.IsChanged) GetUKRF();
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            EmployeeEditForm employeeEditForm = new EmployeeEditForm(connection,true);
            employeeEditForm.ShowDialog();
            if (employeeEditForm.IsChanged) GetEmployees(only3CheckBox.Checked);
        }

        private void IncomeNumberExistsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IncomeNumberExistsCheckBox.Checked)
            {
                incomeDateTimePicker.Enabled = false;
                incomeNumberTextBox.Enabled = false;
            }
            else
            {
                incomeDateTimePicker.Enabled = true;
                incomeNumberTextBox.Enabled = true;
            }
        }




    }
}
