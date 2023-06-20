using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Заявки___Администратор
{
    public partial class Form2 : Form
    {

        Form1 F1 = new Form1();
        public Form2()
        {
            InitializeComponent();

            Form F1 = new Form();

            tbFam2.Enabled = false;
            tbIm2.Enabled = false;
            tbOt2.Enabled = false;
            tbOtd.Enabled = false;
            tbDate.Enabled = false;
            rtbApp.Enabled = false;

        }

        OleDbDataAdapter thisAdapter = new OleDbDataAdapter();
        //DataSet ds = new DataSet();
        DataSet thisDataSet = new DataSet();

        private void Form2_Load(object sender, EventArgs e)
        {
            string a;
            a = tbFam2.Text;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source=G:\\Заявки.mdb"; // строка подключения к БД
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString); // создаем подключение
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();  // создаем запрос к бд
            //myOleDbCommand.CommandText = "SELECT * FROM tableTest WHERE surname like '%" + tbFam2.Text + "%'";
            myOleDbCommand.CommandText = "SELECT * FROM tableTest WHERE surname like '%" + a + "%'";
            myOleDbConnection.Open(); // открываем базу

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader(); // выполняем запрос

            while (myOleDbDataReader.Read())    // построчно считываем результат запроса
            {
                int h = myOleDbDataReader.GetOrdinal("surname");  // получение номера столбца Наименование
                int i = myOleDbDataReader.GetOrdinal("name");  // получение номера столбца Наименование
                int j = myOleDbDataReader.GetOrdinal("patronymic");  // получение номера столбца Наименование
                int k = myOleDbDataReader.GetOrdinal("departament");  // получение номера столбца Наименование
                int l = myOleDbDataReader.GetOrdinal("content");  // получение номера столбца Наименование
                int m = myOleDbDataReader.GetOrdinal("filing_date");  // получение номера столбца Наименование
                int n = myOleDbDataReader.GetOrdinal("result");  // получение номера столбца Наименование
                int o = myOleDbDataReader.GetOrdinal("result_date");  // получение номера столбца Наименование

                tbFam2.Text = Convert.ToString(myOleDbDataReader.GetValue(h)); // столбец A
                tbIm2.Text = Convert.ToString(myOleDbDataReader.GetValue(i));
                tbOt2.Text = Convert.ToString(myOleDbDataReader.GetValue(j));
                tbOtd.Text = Convert.ToString(myOleDbDataReader.GetValue(k));
                rtbApp.Text = Convert.ToString(myOleDbDataReader.GetValue(l));
                tbDate.Text = Convert.ToString(myOleDbDataReader.GetValue(m));
                rtbMess.Text = Convert.ToString(myOleDbDataReader.GetValue(n));
                //dataGridView1.Rows[z].Cells[7].Value = Convert.ToString(myOleDbDataReader.GetValue(o));

                //F2.tbFam2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //F2.tbIm2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //F2.tbOt2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //F2.tbOtd.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                //F2.rtbApp.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //F2.tbDate.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                //dataGridView1.Rows[z].Cells[0].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                //dataGridView1.Rows[z].Cells[1].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                //dataGridView1.Rows[z].Cells[2].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                //dataGridView1.Rows[z].Cells[3].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                //dataGridView1.Rows[z].Cells[4].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                //dataGridView1.Rows[z].Cells[5].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                //dataGridView1.Rows[z].Cells[6].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                //dataGridView1.Rows[z].Cells[7].Style.BackColor = System.Drawing.Color.LightSteelBlue;

                //tbFam1.Clear();
                //tbIm1.Clear();
                //tbOt1.Clear();
            }
            myOleDbConnection.Close();

            OleDbConnection thisConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\Заявки.mdb");
            OleDbCommand command = new OleDbCommand("Select * from tableTest", thisConnection);
            thisAdapter = new OleDbDataAdapter();
            thisAdapter.SelectCommand = command;
            OleDbCommandBuilder bulder = new OleDbCommandBuilder(thisAdapter);
            thisAdapter.InsertCommand = bulder.GetInsertCommand();
            thisAdapter.Fill(thisDataSet);
            thisAdapter.Update(thisDataSet, "tableTest");

            thisAdapter.UpdateCommand = new OleDbCommand("UPDATE result,result_date FROM tableTest", thisConnection);
            thisAdapter.UpdateCommand.Parameters.Add("@result", OleDbType.VarChar, 0, "result").Value = rtbMess.Text.ToString();
            thisAdapter.UpdateCommand.Parameters.Add("@result_date", OleDbType.VarChar, 0, "result_date").Value = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            //string U;
            //U = dateTimePicker1.Text;

            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            thisConnection.Open();

            thisAdapter.Fill(thisDataSet, "tableTest");
            DataRow thisRow = thisDataSet.Tables["tableTest"].NewRow();
            thisRow["result"] = tbFam2.Text;
            thisRow["result_date"] = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            thisDataSet.Tables["tableTest"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "tableTest");
            thisConnection.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            thisAdapter.Update(thisDataSet, "tableTest");
        }

        public void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
