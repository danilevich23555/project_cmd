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
    public partial class MaterialsListForm : Form
    {
        private SqlConnection connection;
        private bool filterOn;
        private string filterText;
        private bool isOnOption;
        private DateTime whereDate;
        private string ToSQLServerString(string str)
        {
            string finalStr = "";
            finalStr = str.Replace("'", "''");
            return finalStr;
        }
        private int DeleteMaterial(string mID)
        {
            try
            {
                string delCmdStr = @"delete from Materials where mID = " + mID;
                SqlCommand delCommand = new SqlCommand(delCmdStr, connection);
                delCommand.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetMaterials()
        {
            return GetMaterials("");
        }
        private int GetMaterials(string where)
        {
            try
            {
                if (filterTypeComboBox.SelectedIndex != -1)
                {
                    switch (filterTypeComboBox.SelectedItem.ToString())
                    {
                        case @"По IMEI":
                            where = " AND (Materials.mIMEI like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По IMSI":
                            where = " AND (Materials.mIMSI like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По сотруднику":
                            where = " AND (Employees.empNotation like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По базовой станции":
                            where = " AND (Materials.mBaseStation like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По абоненту":
                            where = " AND (Materials.mAbnNum like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По собеседнику":
                            where = " AND (Materials.mTlkNum like '%" + ToSQLServerString(where) + "%')";
                            break;
                        case @"По посту":
                            where = " AND (Materials.mPost like '%" + ToSQLServerString(where) + "%')";
                            break;
                        default:
                            where = "";
                            break;
                    }
                }
                else
                {
                    where = "";
                }
                string whereOption = "";
                if (isOnOption)
                {
                    whereOption = " AND (Materials.mDateTime >= '" + whereDate.ToShortDateString() + "') ";
                }
                string matCmdStr = @"SELECT Materials.mID, Materials.mDateTime, Materials.mDuration, MobileOperators.moName, Materials.mBaseStation, Materials.mIMSI, Materials.mIMEI, Materials.mAbnNum, Materials.mTlkNum, Employees.empNotation, mPost,
                                            case mFirstReveal
                                            when 1 then 'Первичное выявление'
                                            when 0 then ''
                                            end
                                     from Materials left join Employees on (Employees.empID = Materials.empID)
                                     left join MobileOperators on (MobileOperators.moID = Materials.moID)
                                     where (1=1)" + where + whereOption + " order by Materials.mDateTime desc";
                SqlDataAdapter adapter = new SqlDataAdapter(matCmdStr, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("Materials");
                adapter.Fill(ds, "Materials");
                BindingSource bs = new BindingSource(ds, "Materials");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "mID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Дата-время";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[1].DefaultCellStyle.Format = "dd.MM.yy HH:mm:ss";
                dataGrid.Columns[2].HeaderText = "Длительность";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].DefaultCellStyle.Format = "HH:mm:ss";
                dataGrid.Columns[3].HeaderText = "Моб.оператор";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "БС";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[5].HeaderText = "IMSI";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "IMEI";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[7].HeaderText = "Абонент";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[8].HeaderText = "Собеседник";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[9].HeaderText = "Сотрудник";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[10].HeaderText = "Пост";
                dataGrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[11].HeaderText = "Первичное выявление";
                dataGrid.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public MaterialsListForm(SqlConnection connection)
        {
            this.connection = connection;
            this.isOnOption = false;
            this.whereDate = DateTime.Now;
            InitializeComponent();
        }
        public MaterialsListForm(SqlConnection connection, DateTime whereDate) : this (connection)
        {
            this.isOnOption = true;
            this.whereDate = whereDate;
        }
        private void MaterialsListForm_Load(object sender, EventArgs e)
        {
            GetMaterials();
        }

        private void dataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
                {
                    dataGrid.CurrentCell = dataGrid[e.ColumnIndex, e.RowIndex];
                    dataGrid.CurrentRow.Selected = true;
                    contextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                MaterialEditForm matEditForm = new MaterialEditForm(connection, false, (int) row.Cells[0].Value);
                matEditForm.ShowDialog();
                if (matEditForm.IsChanged) GetMaterials();
                
            }
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            MaterialEditForm matForm = new MaterialEditForm(connection,true);
            matForm.ShowDialog();
            if (matForm.IsChanged) GetMaterials();
        }

        private void requeryMenu_Click(object sender, EventArgs e)
        {
            GetMaterials();
        }

        private void delMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DialogResult result;
                result =
                    MessageBox.Show(
                        "Вы уверены, что хотите удалить материал от " + Convert.ToDateTime(row.Cells[1].Value) +
                        " длительностью " + Convert.ToDateTime(row.Cells[2].Value).ToLongTimeString() + "?",
                        "Удалить материал", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteMaterial(row.Cells[0].Value.ToString());
                }
                else
                {
                }
                GetMaterials();
            }
        }

        private void informationToolMenu_Click(object sender, EventArgs e)
        {
            if (dataGrid.RowCount > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                int i = dataGrid.CurrentCell.RowIndex;
                row = dataGrid.Rows[i];
                DataForm dataForm = new DataForm(connection, (int)row.Cells[0].Value);
                dataForm.ShowDialog();

            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filterTypeComboBox.SelectedIndex != -1)
            {
                filterOn = true;
                filterText = filterTextBox.Text;
                GetMaterials(filterText);
            }
            else
            {
                MessageBox.Show("Выберите поле для фильтрации", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            filterText = "";
            filterOn = false;
            filterTypeComboBox.SelectedIndex = -1;
            GetMaterials();
        }
    }
}
