using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{

    public partial class LetterEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int lID;
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
        private bool ValidatePath(string path, string number)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    int index = number.IndexOf("-");
                    string doc = string.Concat(path, @"\", number.Substring(index + 1), ".doc");
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
        private int AddMaterials(int lID)
        {
            try
            {
                string delCmdStr = "delete from MaterialLetter where lID = " + lID;
                SqlCommand command = new SqlCommand(delCmdStr, connection);
                command.ExecuteNonQuery();
                string addCmdStr = "";
                for (int i = 0; i < selectedMaterialGrid.RowCount; i++)
                {
                    addCmdStr = @"insert into MaterialLetter (lID, mID) values (" + lID + ", '" + selectedMaterialGrid.Rows[i].Cells[0].Value.ToString() + "')";
                    command.CommandText = addCmdStr;
                    command.ExecuteNonQuery();
                }
                string addInfoStr = "";
                for (int i = 0; i < selectedMaterialGrid.RowCount; i++)
                {
                    addInfoStr = @"update Materials
                                   set msID = 2 
                                   where mID = " + selectedMaterialGrid.Rows[i].Cells[0].Value.ToString();
                    command.CommandText = addInfoStr;
                    command.ExecuteNonQuery();
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int EditLetter()
        {
            try
            {
                int addInf = 0;
                if (additionCheckBox.Checked) addInf = 1;
                else addInf = 0;
                string addCmdStr = "update Letters  set "
                                    + "lNumber = " + "'" + lNumberTextBox.Text + "', "
                                    + "lDate = " + "'" + lDatePicker.Value.ToShortDateString() + "', "
                                    + "empID = " + lEmpComboBox.SelectedValue.ToString() + ", "
                                    + "lText = " + "'" + ToSQLServerString(letterRichTextBox.Text) + "', "
                                    + "lURL = " + "'" + ToSQLServerString(openFolder.Text) + "', "
                                    + "tID = " + themesComboBox.SelectedValue.ToString() + ", "
                                    + "pID = " + wpComboBox.SelectedValue.ToString() + ", "
                                    + "lAddition = " + addInf + " "
                                    + "where lID = " + lID;
                SqlCommand command = new SqlCommand(addCmdStr, connection);
                command.ExecuteNonQuery();
                AddMaterials(lID);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddLetter()
        {
            try
            {
                int countEx = 0;
                int addInf = 0;
                if (additionCheckBox.Checked) addInf = 1;
                else addInf = 0;
                string addCmdStr = "insert into Letters (lNumber, lDate, empID, lText, lURL, tID, pID, lAddition) values ("
                                    + "'" + lNumberTextBox.Text + "', "
                                    + "'" + lDatePicker.Value.ToShortDateString() + "', "
                                    + lEmpComboBox.SelectedValue.ToString() + ", "
                                    + "'" + ToSQLServerString(letterRichTextBox.Text) + "', "
                                    + "'" + ToSQLServerString(openFolder.Text) + "', "
                                    + themesComboBox.SelectedValue.ToString() + ", "
                                    + wpComboBox.SelectedValue.ToString() + ", " 
                                    + addInf + ")";
                SqlCommand command = new SqlCommand(addCmdStr, connection);
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32(command.ExecuteScalar());
                AddMaterials(lastId);
                do
                {
                    ConclutionEditForm conclutionForm = new ConclutionEditForm(connection,true, -1,lastId);
                    conclutionForm.ShowDialog();
                    if (conclutionForm.IsChanged)
                    {
                        countEx++;
                    }
                    if (countEx < 3)
                    {
                        if (
                            MessageBox.Show("Вы хотите добавить еще один экземпляр?", "Добавить экземпляр",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            break;
                        }
                    }

                } while (countEx < 3);
                if (countEx == 0)
                {
                    this.isChanged = false;
                    command.CommandText = "delete from MaterialLetter where lID = " + lastId.ToString();
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from Letters where lID = " + lastId.ToString();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Не добавлено ни одного экземпляра письма, поэтому добавление материала в базу данных не произведено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.isChanged = true;    
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.isChanged = false;
                return -1;
            }
        }
        private int RowTransporter(DataGridView fromDataGrid, DataGridView inDataGrid)
        {
            try
            {
                if (fromDataGrid.RowCount > 0)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int index = fromDataGrid.CurrentCell.RowIndex;
                    inDataGrid.Rows.Add((DataGridViewRow)fromDataGrid.Rows[index].Clone());
                    for (int i = 0; i < fromDataGrid.Rows[index].Cells.Count; i++)
                    {
                        inDataGrid.Rows[inDataGrid.Rows.Count - 1].Cells[i].Value = fromDataGrid.Rows[index].Cells[i].Value;
                    }
                    fromDataGrid.Rows.RemoveAt(index);
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public LetterEditForm(SqlConnection connection, bool isNew)
        {
            InitializeComponent();
            this.isNew = isNew;
            this.connection = connection;
            this.isChanged = false;
        }
        public LetterEditForm(SqlConnection connection, bool isNew, int lID) : this (connection, isNew)
        {

            this.lID = lID;

        }

        private void AddColumns(DataGridView grid)
        {
            grid.Columns.Add("mID", "mID");
            grid.Columns.Add("mDateTime", "Дата-время");
            grid.Columns.Add("mDuration", "Длительность");
            grid.Columns.Add("moName", "Моб.оператор");
            grid.Columns.Add("mBaseStation", "БС");
            grid.Columns.Add("mIMSI", "IMSI");
            grid.Columns.Add("mIMEI", "IMEI");
            grid.Columns.Add("mTlkNum", "Собеседник");
            grid.Columns.Add("empNotation", "Сотрудник");
            grid.Columns[0].Visible = false;
            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[1].DefaultCellStyle.Format = "dd.MM.yy HH:mm:ss";
            grid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[2].DefaultCellStyle.Format = "HH:mm:ss";
            grid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                lEmpComboBox.DataSource = bsEmp;
                lEmpComboBox.ValueMember = "empID";
                lEmpComboBox.DisplayMember = "empNotation";
                lEmpComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        } 
        private int GetMaterials()
        {
            try
            {
                string where = "";
                if (selectedMaterialGrid.RowCount > 0)
                {
                    where = "where ((1=1)";
                    for (int i = 0; i < selectedMaterialGrid.RowCount; i++)
                    {
                        where += " AND (Materials.mID <> " + selectedMaterialGrid.Rows[i].Cells[0].Value.ToString() + ")";
                    }
                    where += ")";
                }
                string matCmdStr = @"SELECT Materials.mID, Materials.mDateTime, Materials.mDuration, MobileOperators.moName, Materials.mBaseStation, Materials.mIMSI, Materials.mIMEI, Materials.mTlkNum, Employees.empNotation
                FROM Employees INNER JOIN (MobileOperators INNER JOIN Materials ON MobileOperators.moID = Materials.moID) ON Employees.empID = Materials.empID " + where +" order by Materials.mDateTime desc";
                SqlCommand command = new SqlCommand(matCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                materialsDataGrid.Rows.Clear();
                while (reader.Read())
                {
                    materialsDataGrid.Rows.Add(1);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        materialsDataGrid.Rows[materialsDataGrid.Rows.Count - 1].Cells[i].Value = reader[i];
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetSelectedMaterials(int lID)
        {
            try
            {
                List <int> mID = new List<int>();
                string getMatNum = "select mID from MaterialLetter where lID = " + lID;
                SqlCommand command = new SqlCommand(getMatNum, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mID.Add(Convert.ToInt32(reader[0]));
                }
                if (mID.Count > 0)
                {
                    string where = " where (";
                    for (int i = 0; i < mID.Count; i++)
                    {
                        where += "(mID = " + mID[i].ToString() + ")";
                        if (i < (mID.Count - 1))
                        {
                            where += " or ";
                        }
                    }
                    where += ")";
                    string selMatCmd = @"SELECT Materials.mID, Materials.mDateTime, Materials.mDuration, MobileOperators.moName, Materials.mBaseStation, Materials.mIMSI, Materials.mIMEI, Materials.mTlkNum, Employees.empNotation
                                        FROM Employees INNER JOIN (MobileOperators INNER JOIN Materials ON MobileOperators.moID = Materials.moID) ON Employees.empID = Materials.empID " + where + " order by Materials.mDateTime desc";
                    SqlCommand getCommand = new SqlCommand(selMatCmd, connection);
                    selectedMaterialGrid.Rows.Clear();
                    SqlDataReader getReader = getCommand.ExecuteReader();
                    while (getReader.Read())
                    {
                        selectedMaterialGrid.Rows.Add(1);
                        for (int i = 0; i < getReader.FieldCount; i++)
                        {
                            selectedMaterialGrid.Rows[selectedMaterialGrid.Rows.Count - 1].Cells[i].Value = getReader[i];
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetLetter(int lID)
        {
            try
            {
                GetEmployees(only3CheckBox.Checked);
                string getLetCmd = "SELECT lNumber, lDate, empID, lText, lURL, tID, pID, lAddition FROM Letters where lID = " + lID;
                SqlCommand command = new SqlCommand(getLetCmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lNumberTextBox.Text = reader[0].ToString();
                    lDatePicker.Value = Convert.ToDateTime(reader[1]);
                    lEmpComboBox.SelectedValue = reader[2];
                    letterRichTextBox.Text = reader[3].ToString();
                    openFolder.Text = reader[4].ToString();
                    letterFolderBrowserDialog.SelectedPath = reader[4].ToString();
                    themesComboBox.SelectedValue = reader[5];
                    wpComboBox.SelectedValue = reader[6];
                    additionCheckBox.Checked = Convert.ToBoolean(reader[7]);          
                }
                GetSelectedMaterials(lID);
                GetMaterials();
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
        private void GetAllData()
        {
            GetMaterials();
            GetEmployees(only3CheckBox.Checked);
        }
        private void LetterEditForm_Load(object sender, EventArgs e)
        {
            AddColumns(materialsDataGrid);
            AddColumns(selectedMaterialGrid);
            GetThemes();
            GetItemsOfPlan();
            if (isNew)
            {
                this.Text = "Добавить новый материал";
                OKButton.Text = "Добавить";
                GetAllData();         
            }
            else
            {
                this.Text = "Изменить материал";
                OKButton.Text = "Изменить";
                GetLetter(lID);                      
            }
        }
        private void materialsDataGrid_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dataGrid = new DataGridView();
            dataGrid = materialsDataGrid;
            if (dataGrid.RowCount > 0)
            {
                RowTransporter(materialsDataGrid, selectedMaterialGrid);
            }
        }
        private void selectedMaterialGrid_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dataGrid = new DataGridView();
            dataGrid = selectedMaterialGrid;
            if (dataGrid.RowCount > 0)
            {
                RowTransporter(selectedMaterialGrid, materialsDataGrid);
            }
        }
        private void addNewMaterial_Click(object sender, EventArgs e)
        {
            MaterialEditForm matForm = new MaterialEditForm(connection, true);
            matForm.ShowDialog();
            GetMaterials();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            isChanged = false;
            this.Close();
        }
        private void addLinkButton_Click(object sender, EventArgs e)
        {
            if (letterFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFolder.Text = letterFolderBrowserDialog.SelectedPath;
                openFolder.LinkVisited = false;
            }
        }
        private void openFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if ((letterFolderBrowserDialog.SelectedPath != "") | (openFolder.Text != ""))
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
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (lNumberTextBox.Text == "")
            {
                MessageBox.Show("Введите номер письма", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lEmpComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            
                            if (selectedMaterialGrid.RowCount == 0)
                            {
                                MessageBox.Show("Выберите хотя бы один материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (letterRichTextBox.Text == "")
                                {
                                    MessageBox.Show("Введите текст письма", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (openFolder.Text == "")
                                    {
                                        MessageBox.Show("Выберите папку с письмом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (ValidatePath(openFolder.Text, lNumberTextBox.Text))
                                        {
                                            if (isNew)
                                            {
                                                if (AddLetter() == 0)
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
                                                if (EditLetter() == 0)
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
        private void only3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GetEmployees(only3CheckBox.Checked);
        }


    }
}
