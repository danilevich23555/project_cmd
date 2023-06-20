using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class InformationEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int infID;
        private bool loadedDir;
        private bool loadedDep;
        private bool isChanged;
        private bool ValidatePath (string path, string number)
        {
            try
            {
                if (Directory.Exists (path))
                {
                    int index = number.IndexOf("-");
                    string doc = string.Concat(path, @"\", number.Substring(index+1), ".doc");
                    string docx = string.Concat(path, @"\", number.Substring(index + 1), ".docx");
                    if (File.Exists(doc)) 
                        return File.Exists(doc);
                    else
                    {
                        return File.Exists(docx);
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool IsChanged
        {
            get
            {
                return isChanged;
            }
        }
        public InformationEditForm(SqlConnection connection, bool isNew)
        {
            this.loadedDir = false;
            this.loadedDep = false;
            this.isChanged = false;
            
            this.isNew = isNew;
            this.connection = connection;
            InitializeComponent();
        }
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        public InformationEditForm(SqlConnection connection, bool isNew, int infID) : this(connection, isNew)
        {
            this.infID = infID;
        }
        private int GetDirections()
        {
            try
            {
                
                depComboBox.SelectedIndex = -1;
                depComboBox.Enabled = false;
                addDepButton.Enabled = false;
                incomingDocumentsCheckedListBox.Enabled = false;
                addIDButton.Enabled = false;
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
                incomingDocumentsCheckedListBox.DataSource = null;
                incomingDocumentsCheckedListBox.Enabled = false;
                addIDButton.Enabled = false;
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

        private int GetIncomingDocuments(int depID)
        {
            try
            {
                string idCmdStr = "SELECT IncomingDocuments.idID, IncomingDocuments.idNumber + ' от ' + Convert(varchar,IncomingDocuments.idDate,104) AS Document " +
                                 " FROM Operatives INNER JOIN IncomingDocuments ON Operatives.opID = IncomingDocuments.opID " +
                                  "where Operatives.depID = " + depID + " order by IncomingDocuments.idDate Desc";
                SqlDataAdapter idAdapter = new SqlDataAdapter(idCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("IncomingDocuments");
                idAdapter.Fill(ds, "IncomingDocuments");
                BindingSource bs = new BindingSource(ds, "IncomingDocuments");
                incomingDocumentsCheckedListBox.DataSource = bs;
                incomingDocumentsCheckedListBox.ValueMember = "idID";
                incomingDocumentsCheckedListBox.DisplayMember = "Document";
                incomingDocumentsCheckedListBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetItemsOfPlan()
        {
            try
            {
                string plCmdStr = @"SELECT pID, pText FROM ItemsOfPlan";
                SqlDataAdapter plAdapter = new SqlDataAdapter(plCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("ItemsOfPlan");
                plAdapter.Fill(ds, "ItemsOfPlan");
                BindingSource bs = new BindingSource(ds, "ItemsOfPlan");
                wpComboBox.DataSource = bs;
                wpComboBox.ValueMember = "pID";
                wpComboBox.DisplayMember = "pText";
                wpComboBox.SelectedIndex = -1;
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
        private int GetInformation(int infID)
        {
            try
            {
                string idCmdStr = @"select Informations.infID, infNumber, infDate, infText,infURL, infExist, infOut, tID, ctID, pID, infCountNuvbersInfExist from Informations "
                                     + "where infID = " + infID;
                SqlCommand command = new SqlCommand(idCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numberTextBox.Text = reader[1].ToString();
                    dateTimePicker.Value = Convert.ToDateTime(reader[2]);
                    commentaryRichTextBox.Text = reader[3].ToString();
                    openFolder.Text = reader[4].ToString();
                    informationFolderBrowserDialog.SelectedPath = reader[4].ToString();
                    if (Convert.ToBoolean(reader[5])) existRadioButton.Checked = true; else emptyRadioButton.Checked = true;
                    if (Convert.ToBoolean(reader[6])) initiatorRadioButton.Checked = true; else inRRadioButton.Checked = true;
                    themesComboBox.SelectedValue = reader[7];
                    countriesComboBox.SelectedValue = reader[8];
                    wpComboBox.SelectedValue = reader[9];
                    if (reader[10].ToString() != "")
                        countNumbersUpDown.Value = (int)reader[10];
                    else
                        countNumbersUpDown.Value = 0;
                }
                reader.Close();
                idCmdStr = @"select distinct Directions.dirID, Departments.depID from Directions 
                                left join Departments on (Departments.dirID = Directions.dirID)
                                left join Operatives on (Departments.depID = Operatives.depID)
                                left join IncomingDocuments on (IncomingDocuments.opID = Operatives.opID)
                                join IncDocInform on (IncomingDocuments.idID = IncDocInform.idID)
                                where IncDocInform.infID = " + infID;
                command.CommandText = idCmdStr;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetDirections();
                    dirComboBox.SelectedValue = reader[0];
                    depComboBox.Enabled = true;
                    addDepButton.Enabled = true;
                    GetDepartments((int) reader[0]);
                    incomingDocumentsCheckedListBox.Enabled = true;
                    addIDButton.Enabled = true;
                    depComboBox.SelectedValue = reader[1];
                    GetIncomingDocuments((int) reader[1]);
                }
                reader.Close();
                idCmdStr = @"select idid from IncDocInform where infID = " + infID;
                command.CommandText = idCmdStr;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    incomingDocumentsCheckedListBox.SelectedValue = reader[0];
                    incomingDocumentsCheckedListBox.SetItemChecked(incomingDocumentsCheckedListBox.SelectedIndex, true);
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

        private int GetThemes()
        {
            try
            {
                string thCmdStr = @"SELECT tID, tName FROM Themes";
                SqlDataAdapter thAdapter = new SqlDataAdapter(thCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Themes");
                thAdapter.Fill(ds, "Themes");
                BindingSource bs = new BindingSource(ds, "Themes");
                themesComboBox.DataSource = bs;
                themesComboBox.ValueMember = "tID";
                themesComboBox.DisplayMember = "tName";
                themesComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        } 
        private int GetCountNumbers(int idID)
        {
            try
            {
                int count = 0;
                string commandStr = @"select count(distinct phoneNumber) from Numbers where idID = " + idID;
                SqlCommand command = new SqlCommand(commandStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0]);
                }
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private bool validateCountNumbers()
        {
            int countNumbers = 0;
            foreach (object itemChecked in incomingDocumentsCheckedListBox.CheckedItems)
            {
                DataRowView row = (DataRowView)itemChecked;
                countNumbers += GetCountNumbers(Convert.ToInt32(row[0]));

            }
            if (countNumbers < countNumbersUpDown.Value )
            {
              //  MessageBox.Show("Количество номеров, по которым найдена информация больше, чем номеров в документе","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            
            
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            Close();
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
                incomingDocumentsCheckedListBox.Enabled = true;
                GetIncomingDocuments((int) depComboBox.SelectedValue);
                addIDButton.Enabled = true;

            }
        }

        private int AddIncomingDocument(int infID, SqlCommand command, int idID)
        {
            try
            {
                string cmdStr = @"insert into IncDocInform  (idID, infID) values (" + idID + ", " + infID + ")";
                command.CommandText = cmdStr;
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;

            }
        }
        private int AddIncomingDocuments(int infID, SqlCommand command)
        {
            try
            {
                string cmdStr = @"delete from IncDocInform where infID = " + infID;
                command.CommandText = cmdStr;
                command.ExecuteNonQuery();
                foreach (object itemChecked in incomingDocumentsCheckedListBox.CheckedItems)
                {
                    DataRowView row = (DataRowView)itemChecked;              
                    AddIncomingDocument(infID, command, (int) row[0]);
                    ExecuteDoc(command, (int) row[0]);

                }
                return 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int ExecuteDoc(SqlCommand command, int idID)
        {
            try
            {
                string execIDCmd = @"update IncomingDocuments
                                     set idExecuted = 1
                                     where idID = " + idID;
                command.CommandText = execIDCmd;
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddInformation()
        {
            SqlTransaction transaction = connection.BeginTransaction("AddInformation");
            try
            {
                int infExist = 0;
                int infOut = 0;
                if (existRadioButton.Checked) infExist = 1; else infExist = 0;
                if (initiatorRadioButton.Checked) infOut = 1; else infOut = 0;
                string addCmdStr = "Insert into Informations (infNumber, infDate, infText, infURL, infExist, infOut, tID, ctID, pID, infCountNuvbersInfExist) values ("
                                    + "'" + ToSQLServerString(numberTextBox.Text) + "', "
                                    + "'" + dateTimePicker.Value.ToShortDateString() + "', "
                                    + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "', "
                                    + "'" + ToSQLServerString(openFolder.Text) + "', "
                                    + infExist.ToString() + ", "
                                    + infOut.ToString() + ", "
                                    + themesComboBox.SelectedValue.ToString() + ", "
                                    + countriesComboBox.SelectedValue.ToString() + ", "
                                    + wpComboBox.SelectedValue.ToString() + ", " 
                                    + countNumbersUpDown.Value + ")";
                SqlCommand command = new SqlCommand(addCmdStr, connection);
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32(command.ExecuteScalar());
                AddIncomingDocuments(lastId, command);
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex_tran)
                {
                    MessageBox.Show(ex_tran.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                    
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int EditInformation()
        {
            SqlTransaction transaction = connection.BeginTransaction("AddInformation");
            try
            {
                int infExist = 0;
                int infOut = 0;
                if (existRadioButton.Checked) infExist = 1; else infExist = 0;
                if (initiatorRadioButton.Checked) infOut = 1; else infOut = 0;

                string editCmdStr = "Update Informations set " +
                                    "infNumber = " + "'" + ToSQLServerString(numberTextBox.Text) + "', " +
                                    "infDate = " + "'" + dateTimePicker.Value.ToShortDateString() + "', " +
                                    "infText = " + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "', " +
                                    "infURL = " + "'" + ToSQLServerString(openFolder.Text) + "', " + 
                                    "infExist = " + infExist.ToString() + ", " +
                                    "infOut = " + infOut.ToString() + ", " +
                                    "ctID = " + countriesComboBox.SelectedValue.ToString() + ", " +
                                    "pID = " + wpComboBox.SelectedValue.ToString() + ", " +
                                    "tID = " + themesComboBox.SelectedValue.ToString() + ", " +
                                    "infCountNuvbersInfExist = " + countNumbersUpDown.Value +
                                    " where infID = " + infID;
                SqlCommand command = new SqlCommand(editCmdStr, connection);
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                AddIncomingDocuments(infID, command);
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex_tran)
                {
                    MessageBox.Show(ex_tran.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private void InformationEditForm_Load(object sender, EventArgs e)
        {
            GetDirections();
            GetThemes();
            GetItemsOfPlan();
            GetCountries();
            if (this.isNew)
            {
                this.Text = "Добавление нового ответа на запрос";
                OKButton.Text = "Добавить";

            }
            else
            {
                this.Text = "Изменение ответа на запрос";
                OKButton.Text = "Изменить";
                GetInformation(this.infID);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool makeInfo = false;
            if ((incomingDocumentsCheckedListBox.CheckedItems.Count < 1) | (incomingDocumentsCheckedListBox.DataSource == null))
            {
                MessageBox.Show("Выберите входящий документ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((numberTextBox.Text == "") | (numberTextBox.Text == @"12/Р/с2/3-"))
                {
                    MessageBox.Show("Введите номер входящего документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (themesComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Выберите окраску", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (wpComboBox.SelectedValue == null)
                        {
                            MessageBox.Show("Выберите пункт плана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (countriesComboBox.SelectedValue == null)
                            {
                                MessageBox.Show("Выберите страну", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                    if (!((existRadioButton.Checked) | (emptyRadioButton.Checked)))
                                    {
                                        MessageBox.Show("Выберите выявлена ли информация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (!((inRRadioButton.Checked) | (initiatorRadioButton.Checked)))
                                        {
                                            MessageBox.Show("Выберите куда передана информация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if (openFolder.Text == "")
                                            {
                                                MessageBox.Show("Введите ссылку на папку со справкой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                if (dateTimePicker.Value > DateTime.Now)
                                                {
                                                    MessageBox.Show("Дата подписи документа должна быть не больше " + DateTime.Now.ToShortDateString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    if (ValidatePath(openFolder.Text, numberTextBox.Text))
                                                    {
                                                        if (validateCountNumbers())
                                                        {
                                                            makeInfo = true;
                                                        }
                                                        else
                                                        {
                                                            if (MessageBox.Show("Количество номеров, по которым выявлена информация, больше, чем в запросе. Вы уверены что","Вопрос",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                                            {
                                                                makeInfo = true;
                                                            }
                                                            else
                                                            {
                                                                makeInfo = false;
                                                            }
                                                        }
                                                        if (makeInfo)
                                                        {
                                                            if (isNew)
                                                            {
                                                                if (AddInformation() == 0)
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

                                                                if (EditInformation() == 0)
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
                                                        else
                                                        {

                                                        }
                                                        
                                                      
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Скопируйте файл в выбранную папку. Файл должен называться по номеру письма и иметь расширение *.doc или *.docx", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void editLinkButton_Click(object sender, EventArgs e)
        {
            if (informationFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFolder.Text = informationFolderBrowserDialog.SelectedPath;
                openFolder.LinkVisited = false;
            }
        }

        private void openFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if ((informationFolderBrowserDialog.SelectedPath != "") | (openFolder.Text != ""))
                {
                    System.Diagnostics.Process.Start(openFolder.Text);
                    openFolder.LinkVisited = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addIDButton_Click(object sender, EventArgs e)
        {
            IncomingDocumentEditForm incomingDocumentEditForm = new IncomingDocumentEditForm(connection,true);
            incomingDocumentEditForm.ShowDialog();
            if (incomingDocumentEditForm.IsChanged) GetIncomingDocuments((int)depComboBox.SelectedValue);
        }

        private void addDepButton_Click(object sender, EventArgs e)
        {
            DepartmentEditForm departmentEditForm = new DepartmentEditForm(connection, true);
            departmentEditForm.ShowDialog();
            if (departmentEditForm.IsChanged) GetDepartments((int) dirComboBox.SelectedValue);
        }

        private void addDirButton_Click(object sender, EventArgs e)
        {
            DirectionEditForm directionEditForm = new DirectionEditForm(connection, true);
            directionEditForm.ShowDialog();
            if (directionEditForm.IsChanged) GetDirections();
        }

        private void emptyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            countNumbersUpDown.Value = 0;
            countNumbersUpDown.Enabled = false;
        }

        private void existRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            countNumbersUpDown.Value = 1;
            countNumbersUpDown.Enabled = true;
        }


    }
}
