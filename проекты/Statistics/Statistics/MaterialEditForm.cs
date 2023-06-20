using System;
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
    public partial class MaterialEditForm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int mID;
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
        private int GetServiceTypes()
        {
            try
            {
                string stCmdStr = "SELECT stID, stName FROM ServiceTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(stCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("ServiceTypes");
                adapter.Fill(ds, "ServiceTypes");
                BindingSource bs = new BindingSource(ds, "ServiceTypes");
                mServiceTypeComboBox.DataSource = bs;
                mServiceTypeComboBox.ValueMember = "stID";
                mServiceTypeComboBox.DisplayMember = "stName";
                mServiceTypeComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetCallTypes()
        {
            try
            {
                string ctCmdStr = "SELECT ctID, ctName FROM CallTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(ctCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("CallTypes");
                adapter.Fill(ds, "CallTypes");
                BindingSource bs = new BindingSource(ds, "CallTypes");
                mCallTypeComboBox.DataSource = bs;
                mCallTypeComboBox.ValueMember = "ctID";
                mCallTypeComboBox.DisplayMember = "ctName";
                mCallTypeComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMobileOperators()
        {
            try
            {
                string moCmdStr = "SELECT moID, moName FROM MobileOperators Order by moName";
                SqlDataAdapter adapter = new SqlDataAdapter(moCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MobileOperators");
                adapter.Fill(ds, "MobileOperators");
                BindingSource bs = new BindingSource(ds, "MobileOperators");
                mMobileOperatorComboBox.DataSource = bs;
                mMobileOperatorComboBox.ValueMember = "moID";
                mMobileOperatorComboBox.DisplayMember = "moName";
                mMobileOperatorComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMaterialStatuses()
        {
            try
            {
                string msCmdStr = "SELECT msID, msName FROM MaterialStatuses";
                SqlDataAdapter adapter = new SqlDataAdapter(msCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("MaterialStatuses");
                adapter.Fill(ds, "MaterialStatuses");
                BindingSource bs = new BindingSource(ds, "MaterialStatuses");
                mMaterialStatusComboBox.DataSource = bs;
                mMaterialStatusComboBox.ValueMember = "msID";
                mMaterialStatusComboBox.DisplayMember = "msName";
                mMaterialStatusComboBox.SelectedIndex = -1;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetEmployees()
        {
            try
            {
                string empCmdStr = "SELECT empID, empNotation FROM Employees order by empNotation";
                SqlDataAdapter adapter = new SqlDataAdapter(empCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Employees");
                adapter.Fill(ds, "Employees");
                BindingSource bs = new BindingSource(ds, "Employees");
                mEmployeeComboBox.DataSource = bs;
                mEmployeeComboBox.ValueMember = "empID";
                mEmployeeComboBox.DisplayMember = "empNotation";
                mEmployeeComboBox.SelectedIndex = -1;
                return 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private int GetMaterial()
        {
            try
            {
                GetAllData();
                string matCmdStr = "SELECT mDateTime, mDuration, stID, ctID, moID, mBaseStation, mIMSI, mIMEI, mAbnNum, mTlkNum, empID, mPost, msID, mFirstReveal, mText FROM Materials where mID = " + this.mID;
                SqlCommand command = new SqlCommand(matCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mDateTime.Value = Convert.ToDateTime(reader[0]);
                    mDuration.Value = Convert.ToDateTime(reader[1]);
                    mServiceTypeComboBox.SelectedValue = reader[2];
                    mCallTypeComboBox.SelectedValue = reader[3];
                    mMobileOperatorComboBox.SelectedValue = reader[4];
                    mBaseStationTextBox.Text = reader[5].ToString();
                    mIMSITextBox.Text = reader[6].ToString();
                    mIMEITextBox.Text = reader[7].ToString();
                    mAbnNumTextBox.Text = reader[8].ToString();
                    mTlkNumTextBox.Text = reader[9].ToString();
                    mEmployeeComboBox.SelectedValue = reader[10];
                    mPostTextBox.Text = reader[11].ToString();
                    if (reader[12].ToString() != "") mMaterialStatusComboBox.SelectedValue = reader[12];
                    if (!DBNull.Value.Equals(reader[13])) 
                        fistCheckBox.Checked = Convert.ToBoolean(reader[13]); 
                        else fistCheckBox.Checked = false;
                    commentaryRichTextBox.Text = reader[14].ToString();
                }
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
            GetServiceTypes();
            GetCallTypes();
            GetMobileOperators();
            GetMaterialStatuses();
            GetEmployees();
        }

        private int GetMobileOperatorIndex(string netName)
        {
            try
            {
                int index = -1;
                string strCmd = "select moID from MobileOperators where moName = '" + netName + "'";
                SqlCommand cmd = new SqlCommand(strCmd, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index = Convert.ToInt32(reader[0]);
                }
                return index;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return -1;
            }
        }
        private int GetCallTypeIndex(string callTypeName)
        {
            try
            {
                int index = -1;
                string strCmd = "select ctID from CallTypes where ctName = '" + callTypeName + "'";
                SqlCommand cmd = new SqlCommand(strCmd, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index = Convert.ToInt32(reader[0]);
                }
                return index;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return -1;
            }
        }
        private int loadData(string path)
        {
            StreamReader file;
            string bs = "";
            string lac = "";
            string cid = "";
            string final;
            if (unicodeRadioButton.Checked) file = new StreamReader(path, Encoding.Unicode);
            else
            {
                if (win1251RadioButton.Checked) file = new StreamReader(path, Encoding.Default);
                else
                {
                    file = new StreamReader(path);
                }
            }
            try
            {
                
                string line = "";
                while ((line = file.ReadLine()) != null)
                {

                    if (line.Contains("•Длительность: "))
                    {
                        final = line.Substring(15);
                        mDuration.Value = Convert.ToDateTime(final);                        
                    }
                    else
                    {
                        if (line.Contains("•Дата/Время: "))
                        {
                            final = line.Substring(13);
                            mDateTime.Value = Convert.ToDateTime(final.Replace("-", "."));     
                        }
                        else
                        {
                            if (line.Contains("•Системный № источника: "))
                            {
                                final = line.Substring(24);
                                mIMSITextBox.Text = final;
                            }
                            else
                            {
                                if (line.Contains("•№ терминала источника: "))
                                {
                                    final = line.Substring(24);
                                    mIMEITextBox.Text = final;
                                }
                                else
                                {
                                    if (line.Contains("•Базовая станция: "))
                                    {
                                        final = line.Substring(18);
                                        //mBaseStationTextBox.Text = final;
                                        bs = final;
                                    }
                                    else
                                    {
                                        if (line.Contains("•Собеседник: "))
                                        {
                                            final = line.Substring(13);
                                            mTlkNumTextBox.Text = final;
                                        }
                                        else
                                        {
                                            if (line.Contains("•Пользовательский номер: "))
                                            {
                                                final = line.Substring(25);
                                                mAbnNumTextBox.Text = final;
                                            }
                                            else
                                            {
                                                if (line.Contains("•Пост: "))
                                                {
                                                    final = line.Substring(7);
                                                    mPostTextBox.Text = final;
                                                }
                                                else
                                                {
                                                    if (line.Contains("•Сеть: "))
                                                    {
                                                        final = line.Substring(7);
                                                        mMobileOperatorComboBox.SelectedValue = GetMobileOperatorIndex(final);
                                                    }
                                                    else
                                                    {
                                                        if (line.Contains("•Тип вызова: "))
                                                        {
                                                            final = line.Substring(13);
                                                            mCallTypeComboBox.SelectedValue = GetCallTypeIndex(final);
                                                        }
                                                        else
                                                        {
                                                            if (line.Contains("•БС CID: "))
                                                            {
                                                                cid = line.Substring(9);
                                                            }
                                                            else
                                                            {
                                                                if (line.Contains("•БС LAC: "))
                                                                {
                                                                    lac = line.Substring(9);
                                                                }
                                                                else
                                                                {

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
                if ((lac=="") & (cid =="") & (bs == ""))
                {
                    mBaseStationTextBox.Text = "-";
                }
                else
                {
                   if ((lac!="") | (cid !=""))
                   {
                       mBaseStationTextBox.Text = "LAC:" + lac + " CID:" + cid;
                   }
                   else
                   {
                       mBaseStationTextBox.Text = bs;
                   }
                }
                file.Close();
                return 0;
            }
            catch (Exception)
            {
                file.Close();
                return -1;
            }
        }
        public MaterialEditForm(SqlConnection connection, bool isNew)
        {
            
            this.isChanged = false;
            this.isNew = isNew;
            this.connection = connection;
            
            InitializeComponent();
        }
        public MaterialEditForm(SqlConnection connection, bool isNew, int mID) : this(connection, isNew)
        {
            this.mID = mID;
        }

        private int EditMaterial()
        {
            try
            {
                string editCmdStr = @"";
                int first = 0;
                if (fistCheckBox.Checked) first = 1;
                else first = 0;
                if (mMaterialStatusComboBox.SelectedValue == null)
                {
                    editCmdStr = "Update Materials set "

                               + "mDateTime = " + "'" + mDateTime.Value.ToString() + "', "
                               + "mDuration = " + "'" + mDuration.Value.ToLongTimeString() + "', "
                               + "stID = " + mServiceTypeComboBox.SelectedValue + ", "
                               + "ctID = " + mCallTypeComboBox.SelectedValue + ", "
                               + "moID = " + mMobileOperatorComboBox.SelectedValue + ", "
                               + "mBaseStation = " + "'" + ToSQLServerString(mBaseStationTextBox.Text) + "', "
                               + "mIMSI = " + "'" + ToSQLServerString(mIMSITextBox.Text) + "', "
                               + "mIMEI = " + "'" + ToSQLServerString(mIMEITextBox.Text) + "', "
                               + "mAbnNum = " + "'" + ToSQLServerString(mAbnNumTextBox.Text) + "', "
                               + "mTlkNum = " + "'" + ToSQLServerString(mTlkNumTextBox.Text) + "', "
                               + "empID = " + mEmployeeComboBox.SelectedValue + ", "
                               + "mPost = " + "'" + ToSQLServerString(mPostTextBox.Text) + "', "
                               + "msID = null, "
                               + "mFirstReveal = " + first + ", "
                               + "mText = '" + ToSQLServerString(commentaryRichTextBox.Text) + "'"
                               + "where mID = " + this.mID;
                }
                else
                {
                    editCmdStr = "Update Materials set "

                               + "mDateTime = " + "'" + mDateTime.Value.ToString() + "', "
                               + "mDuration = " + "'" + mDuration.Value.ToLongTimeString() + "', "
                               + "stID = " + mServiceTypeComboBox.SelectedValue + ", "
                               + "ctID = " + mCallTypeComboBox.SelectedValue + ", "
                               + "moID = " + mMobileOperatorComboBox.SelectedValue + ", "
                               + "mBaseStation = " + "'" + ToSQLServerString(mBaseStationTextBox.Text) + "', "
                               + "mIMSI = " + "'" + ToSQLServerString(mIMSITextBox.Text) + "', "
                               + "mIMEI = " + "'" + ToSQLServerString(mIMEITextBox.Text) + "', "
                               + "mAbnNum = " + "'" + ToSQLServerString(mAbnNumTextBox.Text) + "', "
                               + "mTlkNum = " + "'" + ToSQLServerString(mTlkNumTextBox.Text) + "', "
                               + "empID = " + mEmployeeComboBox.SelectedValue + ", "
                               + "mPost = " + "'" + ToSQLServerString(mPostTextBox.Text) + "', "
                               + "msID = " + mMaterialStatusComboBox.SelectedValue + ", " 
                               + "mFirstReveal = " + first + ", " 
                               + "mText = '"  + ToSQLServerString(commentaryRichTextBox.Text) + "'"
                               + "where mID = " + this.mID;
                }

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
        private int AddMaterial()
        {
            try
            {
                string addCmdStr = @"";
                int first = 0;
                if (fistCheckBox.Checked) first = 1;
                else first = 0;
                if (mMaterialStatusComboBox.SelectedValue == null)
                {
                    addCmdStr = "Insert into Materials (mDateTime, mDuration, stID, ctID, moID, mBaseStation, mIMSI, mIMEI, mAbnNum, mTlkNum, empID, mPost, msID, mFirstReveal, mText )  values ("
                               + "'" + mDateTime.Value.ToString() + "', "
                               + "'" + mDuration.Value.ToLongTimeString() + "', "
                               + mServiceTypeComboBox.SelectedValue + ", "
                               + mCallTypeComboBox.SelectedValue + ", "
                               + mMobileOperatorComboBox.SelectedValue + ", "
                               + "'" + ToSQLServerString(mBaseStationTextBox.Text) + "', "
                               + "'" + ToSQLServerString(mIMSITextBox.Text) + "', "
                               + "'" + ToSQLServerString(mIMEITextBox.Text) + "', "
                               + "'" + ToSQLServerString(mAbnNumTextBox.Text) + "', "
                               + "'" + ToSQLServerString(mTlkNumTextBox.Text) + "', "
                               + mEmployeeComboBox.SelectedValue + ", "
                               + "'" + ToSQLServerString(mPostTextBox.Text) + "', "
                               + "null" + ", "
                               + first + ", "
                               + "'"+ ToSQLServerString(commentaryRichTextBox.Text) + "')";
                }
                else
                {
                    addCmdStr = "Insert into Materials (mDateTime, mDuration, stID, ctID, moID, mBaseStation, mIMSI, mIMEI, mAbnNum, mTlkNum, empID, mPost, msID, mFirstReveal, mText )  values ("
                               + "'" + mDateTime.Value.ToString() + "', "
                               + "'" + mDuration.Value.ToLongTimeString() + "', "
                               + mServiceTypeComboBox.SelectedValue + ", "
                               + mCallTypeComboBox.SelectedValue + ", "
                               + mMobileOperatorComboBox.SelectedValue + ", "
                               + "'" + ToSQLServerString(mBaseStationTextBox.Text) + "', "
                               + "'" + ToSQLServerString(mIMSITextBox.Text) + "', "
                               + "'" + ToSQLServerString(mIMEITextBox.Text) + "', "
                               + "'" + ToSQLServerString(mAbnNumTextBox.Text) + "', "
                               + "'" + ToSQLServerString(mTlkNumTextBox.Text) + "', "
                               + mEmployeeComboBox.SelectedValue + ", "
                               + "'" +ToSQLServerString(mPostTextBox.Text) + "', "
                               + mMaterialStatusComboBox.SelectedValue + ", "
                               + first + ", "
                               + "'" + ToSQLServerString(commentaryRichTextBox.Text) + "')";
                    
                }

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
        private void MaterialEditForm_Load(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            GetAllData();
            if (isNew)
            {
                this.Text = "Добавить новый материал";
                OKButton.Text = "Добавить";
                mDuration.Value = Convert.ToDateTime("00:00:00");
            }
            else
            {
                this.Text = "Изменить данные о материале";
                OKButton.Text = "Изменить";
                GetMaterial();
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.isChanged = false;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            if (mServiceTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Не указан тип услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (mCallTypeComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Не указан тип вызова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (mMobileOperatorComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Не указан мобильный оператор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (mBaseStationTextBox.Text == "")
                        {
                            MessageBox.Show("Не указана базовая станция", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (mEmployeeComboBox.SelectedValue == null)
                            {
                                MessageBox.Show("Не указан сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (isNew)
                                {
                                    if (AddMaterial() == 0)
                                    {
                                        isChanged = true;
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    if (EditMaterial() == 0)
                                    {
                                        isChanged = true;
                                        this.Close();
                                    }
                                }
                                
                            }
                        }
                    }

                }
            }
        }

        private void cleadMatStatusButton_Click(object sender, EventArgs e)
        {
            mMaterialStatusComboBox.SelectedIndex = -1;
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            EmployeeEditForm empForm = new EmployeeEditForm(connection, true);
            empForm.ShowDialog();
            GetEmployees();
        }

        private void editEmpButton_Click(object sender, EventArgs e)
        {
            if (mEmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Для изменения вы должны выбрать сотрудника.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EmployeeEditForm empForm = new EmployeeEditForm(connection, false, (int)mEmployeeComboBox.SelectedValue);
                empForm.ShowDialog();
                if (empForm.IsChanged) GetEmployees();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadData(openFileDialog.FileName);
            }
        }


    }
}
