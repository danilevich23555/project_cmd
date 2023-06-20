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
    public partial class DataForm : Form
    {
        private SqlConnection connection;
        private int mID;

        private int GetDataAboutMaterial()
        {
            try
            {
                string idCmdString = @"select Materials.mID, lNumber, lDate,  dirName, depName, opNotation, opOS, cRating, mrName, cText
                                            from Materials
                                            join MaterialLetter on (MaterialLetter.mID = Materials.mID)
                                            join Letters on (Letters.lID = MaterialLetter.lID)
                                            join Conclutions on (Conclutions.lID = Letters.lID)
                                            join Operatives on (Operatives.opID = Conclutions.opID)
                                            join Departments on (Departments.depID = Operatives.depID)
                                            join Directions on (Directions.dirID = Departments.dirID)
                                            left join MatResults on (MatResults.mrID = Conclutions.mrID)
                                            where Materials.mID = " + mID +
                                            "order by lDate, lNumber, dirName, depName";
                SqlDataAdapter adapter = new SqlDataAdapter(idCmdString, connection);
                DataSet ds = new DataSet();
                ds.Tables.Add("DataAboutMaterial");
                adapter.Fill(ds, "DataAboutMaterial");
                BindingSource bs = new BindingSource(ds, "DataAboutMaterial");
                dataGrid.DataSource = bs;
                dataGrid.Columns[0].HeaderText = "mID";
                dataGrid.Columns[0].Visible = false;
                dataGrid.Columns[1].HeaderText = "Номер";
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[2].HeaderText = "Дата";
                dataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[3].HeaderText = "Служба";
                dataGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[4].HeaderText = "Управление";
                dataGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[5].HeaderText = "Оперативник";
                dataGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[6].HeaderText = "ОС";
                dataGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGrid.Columns[7].HeaderText = "Оценка";
                dataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[8].HeaderText = "Результат";
                dataGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.Columns[9].HeaderText = "Комментарий";
                dataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGrid.Columns[9].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public DataForm(SqlConnection connection, int mID)
        {
            this.connection = connection;
            this.mID = mID;
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            GetDataAboutMaterial();
        }
    }
}
