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
    public partial class ConclutionEditForm : Form
    {
        private bool isNew;
        private bool loadedDir;
        private bool loadedDep;
        private bool isCnahged;
        public bool IsChanged
        {
            get
            {
                return isCnahged;
            }
        }
        private int lID;
        private int cID;
        private SqlConnection connection;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int GetConclution()
        {
            try
            {
                string conStrCmd = @"select Conclutions.lID, Conclutions.opID, cCopyNumber, cRating, cText, Operatives.opID, Departments.depID, Directions.dirID, mrID, inID, cReturnDate from Conclutions left join Letters on (Letters.lID = Conclutions.lID)
                                        left join Operatives on (Conclutions.opID = Operatives.opID)
                                        left join Departments on (Operatives.depID = Departments.depID)
                                        left join Directions on (Departments.dirID = Directions.dirID) "
                                        + " where cID = " + cID;
                SqlCommand command = new SqlCommand(conStrCmd, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lettersComboBox.SelectedValue = reader[0];
                    if (reader[7].ToString() != "")
                    {
                        dirComboBox.SelectedValue = reader[7];
                        GetDepartments(reader[7].ToString());
                        if (reader[6].ToString() != "")
                        {
                            depComboBox.SelectedValue = reader[6];
                            GetOperatives(reader[6].ToString());
                            operComboBox.SelectedValue = reader[5];
                        }
                    }
                        rankComboBox.Text = reader[3].ToString();
                        cCopyNumberComboBox.Text = reader[2].ToString();
                        conclutionRichTextBox.Text = reader[4].ToString();
                        matResultsComboBox.SelectedValue = reader[8];
                        interestComboBox.SelectedValue = reader[9];
                    
                    if (reader[10].ToString() == "")
                    {
                        dateLabel.Text = "";
                        addReturnDateButton.Enabled = true;
                        editReturnDateButton.Enabled = false;
                        deleteReturnDateButton.Enabled = false;
                    }
                    else
                    {
                        dateLabel.Text = Convert.ToDateTime(reader[10]).ToLongDateString();
                        addReturnDateButton.Enabled = false;
                        editReturnDateButton.Enabled = true;
                        deleteReturnDateButton.Enabled = true;
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
        private int EditConclution()
        {
            try
            {
                string rank = "";
                if (rankComboBox.Text == "")
                {
                    rank = "null";
                }
                else
                {
                    rank = rankComboBox.Text;
                }

                string editCmdStr = "Update Conclutions set "
                                   + "lID = " + lettersComboBox.SelectedValue + ", "
                                   + "opID = " + operComboBox.SelectedValue + ", "
                                   + "cCopyNumber = " + cCopyNumberComboBox.Text + ", "
                                   + "cRating = " + rank + ", ";
                if (matResultsComboBox.SelectedValue != null)
                {
                    editCmdStr += "mrID = " + matResultsComboBox.SelectedValue + ", ";
                }
                else
                {
                    editCmdStr += "mrID = " + "null" + ", ";
                }

                if (interestComboBox.SelectedValue != null)
                {
                    editCmdStr += "inID = " + interestComboBox.SelectedValue + ", ";
                }
                else
                {
                    editCmdStr += "inID = " + "null" + ", ";
                }
                if (dateLabel.Text != "")
                {
                    editCmdStr += "cReturnDate = '" + Convert.ToDateTime(dateLabel.Text).ToShortDateString() + "', ";
                }
                else
                {
                    editCmdStr += "cReturnDate = " + "null" + ", ";
                }
                    editCmdStr += "cText = " + "'" + ToSQLServerString(conclutionRichTextBox.Text) + "'"
                                   + " where cID = " + cID;

                SqlCommand command = new SqlCommand(editCmdStr, connection);
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int AddConclution()
        {
            try
            {
                string rank = "";
                string result = "";
                string interest = "";
                string returnDate = "";
                if (rankComboBox.Text == "")
                {
                    rank = "null";
                }
                else
                {
                    rank = rankComboBox.Text;
                }
                if (matResultsComboBox.Text == "")
                {
                    result = "null";
                }
                else
                {
                    result = matResultsComboBox.SelectedValue.ToString();
                }
                if (interestComboBox.Text == "")
                {
                    interest = "null";
                }
                else
                {
                    interest = interestComboBox.SelectedValue.ToString();
                }
                if (dateLabel.Text != "")
                {
                   returnDate = "'" + Convert.ToDateTime(dateLabel.Text).ToShortDateString() + "'";
                }
                else
                {
                    returnDate = "null";
                }
                string addCmdStr = "insert into Conclutions (lID, opID, cCopyNumber, cRating, mrID, inID, cText, cReturnDate) values ("
                                   + lettersComboBox.SelectedValue + ", "
                                   + operComboBox.SelectedValue + ", " 
                                   + cCopyNumberComboBox.Text + ", "
                                   + rank + ", "
                                   + result + ", "
                                   + interest + ", "
                                   + "'" + ToSQLServerString(conclutionRichTextBox.Text) + "', " 
                                   + returnDate +")";

                SqlCommand command = new SqlCommand(addCmdStr, connection);
                command.ExecuteNonQuery();
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
                addDepartmentButton.Enabled = false;
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
        private int GetLetters()
        {
            try
            {
                string letCmdStr = "SELECT lID, lNumber + ' от ' + Convert(varchar, lDate, 104) as lInfo  from Letters Order by lDate desc";
                SqlDataAdapter letAdapter = new SqlDataAdapter(letCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Letters");
                letAdapter.Fill(ds, "Letters");
                BindingSource bs = new BindingSource(ds, "Letters");
                lettersComboBox.DataSource = bs;
                lettersComboBox.ValueMember = "lID";
                lettersComboBox.DisplayMember = "lInfo";
                lettersComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetDepartments(string dirID)
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
        private int GetOperatives(string depID)
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
        private int GetResults()
        {
            try
            {
                string resCmdStr = @"SELECT MatResults.mrID, MatResults.mrName FROM MatResults";
                SqlDataAdapter adapter = new SqlDataAdapter(resCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MatResults");
                adapter.Fill(ds, "MatResults");
                BindingSource bs = new BindingSource(ds, "MatResults");
                matResultsComboBox.DataSource = bs;
                matResultsComboBox.ValueMember = "mrID";
                matResultsComboBox.DisplayMember = "mrName";
                matResultsComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private int GetInterests()
        {
            try
            {
                string intCmdStr = @"SELECT inID, inText FROM InterestAboutAddition";
                SqlDataAdapter adapter = new SqlDataAdapter(intCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("InterestAboutAddition");
                adapter.Fill(ds, "InterestAboutAddition");
                BindingSource bs = new BindingSource(ds, "InterestAboutAddition");
                interestComboBox.DataSource = bs;
                interestComboBox.ValueMember = "inID";
                interestComboBox.DisplayMember = "inText";
                interestComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        public ConclutionEditForm(SqlConnection connection, bool isNew)
        {
            InitializeComponent();
            this.connection = connection;
            this.isNew = isNew;
            this.loadedDir = false;
            this.loadedDep = false;
            this.isCnahged = false;
            lID = -1;
            cID = -1;
        }
        public ConclutionEditForm(SqlConnection connection, bool isNew, int cID) : this(connection,isNew)
           
        {
            this.cID = cID;
        }

        public ConclutionEditForm(SqlConnection connection, bool isNew, int cID, int lID) : this (connection, isNew, cID)
        {
            this.lID = lID;
        }
        private void dirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((dirComboBox.SelectedIndex > -1) & (loadedDir))
            {
                depComboBox.Enabled = true;
                addDepartmentButton.Enabled = true;
                GetDepartments(dirComboBox.SelectedValue.ToString());
            }
        }
        private void depComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((depComboBox.SelectedIndex > -1) & (loadedDep))
            {
                GetOperatives(depComboBox.SelectedValue.ToString());
                operComboBox.Enabled = true;
                addOperButton.Enabled = true;
                editOperButton.Enabled = true;
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
                GetOperatives(depComboBox.SelectedValue.ToString());
            }
        }
        private void addDirectionButton_Click(object sender, EventArgs e)
        {
            DirectionsListForm dirForm = new DirectionsListForm(connection);
            dirForm.ShowDialog();
            GetDirections();
        }
        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            DepartmentsListForm depForm = new DepartmentsListForm(connection);
            depForm.ShowDialog();
            GetDepartments(dirComboBox.SelectedValue.ToString());
        }
        private void addOperButton_Click(object sender, EventArgs e)
        {
            OperativeEditForm operForm = new OperativeEditForm(connection,true);
            operForm.ShowDialog();
            GetOperatives(depComboBox.SelectedValue.ToString());
        }
        private void ConclutionEditForm_Load(object sender, EventArgs e)
        {
            GetLetters();
            GetResults();
            GetInterests();
            if (lID != -1)
            {
                lettersComboBox.SelectedValue = lID;
                lettersComboBox.Enabled = false;
            }
            GetDirections();
            if (isNew)
            {
                OKButton.Text = "Добавить";
                this.Text = "Добавить экземпляр";
            }
            else
            {
                OKButton.Text = "Изменить";
                this.Text = "Изменить данные об экземпляре";
                GetConclution();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.isCnahged = false;
            this.Close();
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (lettersComboBox.SelectedValue == null)
            {
                MessageBox.Show("Письмо не выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dirComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Служба не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (depComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Управление не выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (operComboBox.SelectedValue == null)
                        {
                            MessageBox.Show("Не выбран оперативник. Если это новый экземпляр - выберите значение '-'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (cCopyNumberComboBox.Text == "")
                            {
                                MessageBox.Show("Укажите номер экземпляра", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (((matResultsComboBox.Text != "") | (rankComboBox.Text != "") | (interestComboBox.Text != "")) & (dateLabel.Text ==""))
                                {
                                    MessageBox.Show("Укажите дату возврата заключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (isNew)
                                    {
                                        if (AddConclution() == 0)
                                        {
                                            this.isCnahged = true;
                                            this.Close();
                                        }
                                        else
                                        {
                                            this.isCnahged = false;
                                        }
                                    }
                                    else
                                    {
                                        if (EditConclution() == 0)
                                        {
                                            this.isCnahged = true;
                                            this.Close();
                                        }
                                        else
                                        {
                                            this.isCnahged = false;
                                        }
                                    }
                                }
                               

                            }
                        }
                    }
                }
            }
        }
        private void addLetterButton_Click(object sender, EventArgs e)
        {
            
            LetterEditForm addLetter = new LetterEditForm(connection,true);
            addLetter.ShowDialog();
            GetLetters();
             
        }
        private void editLetterButton_Click(object sender, EventArgs e)
        {
            if (lettersComboBox.SelectedValue == null)
            {
                MessageBox.Show("Для изменения вы должны письмо.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                LetterEditForm addLetter = new LetterEditForm(connection, false,  (int)lettersComboBox.SelectedValue);
                addLetter.ShowDialog();
                GetLetters();
                
            }
        }
        private void clearRankButton_Click(object sender, EventArgs e)
        {
            rankComboBox.SelectedIndex = -1;
        }
        private void clearResultButton_Click(object sender, EventArgs e)
        {
            matResultsComboBox.SelectedValue = -1;
        }

        private void clearInterestButton_Click(object sender, EventArgs e)
        {
            interestComboBox.SelectedIndex = -1;
        }

        private void addReturnDateButton_Click(object sender, EventArgs e)
        {
            DateForm date = new DateForm();
            date.ShowDialog();
            if (date.IsChanged)
            {
                dateLabel.Text = date.ConclutionReturnDate.ToLongDateString();
                addReturnDateButton.Enabled = false;
                editReturnDateButton.Enabled = true;
                deleteReturnDateButton.Enabled = true;
            }
        }

        private void editReturnDateButton_Click(object sender, EventArgs e)
        {
            DateForm date = new DateForm(Convert.ToDateTime(dateLabel.Text));
            date.ShowDialog();
            if (date.IsChanged)
            {
                dateLabel.Text = date.ConclutionReturnDate.ToLongDateString();
                addReturnDateButton.Enabled = false;
                editReturnDateButton.Enabled = true;
                deleteReturnDateButton.Enabled = true;
            }
        }

        private void deleteReturnDateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить дату возврата заключения?","Удалить",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                addReturnDateButton.Enabled = true;
                editReturnDateButton.Enabled = false;
                deleteReturnDateButton.Enabled = false;
                dateLabel.Text = "";
            }
        }

    }
}
