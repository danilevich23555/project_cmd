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
    public partial class IncomingDocementEditFofm : Form
    {
        private SqlConnection connection;
        private bool isNew;
        private int idID;
        private bool loadedDir;
        private bool loadedDep;
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
        public IncomingDocementEditFofm(SqlConnection connection, bool isNew)
        {
            this.isNew = isNew;
            loadedDir = false;
            loadedDep = false;
            isChanged = false;
            this.connection = connection;
            InitializeComponent();
        }
        public IncomingDocementEditFofm(SqlConnection connection, bool isNew, int idID) : this (connection, isNew)
        {
            this.idID = idID;
        }
        private int GetDaysDuration(int i)
        {
            try
            {

                string durCmdStr = @"select dtDays from DocType " +
                                    "where dtID = " + i.ToString();
                SqlCommand command = new SqlCommand(durCmdStr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
                }
                return -1;
            }
            catch
            {
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
                //GetIncomingDocument(this.idID);
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
    }
}
