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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "заявкиDataSet.tableTest". При необходимости она может быть перемещена или удалена.
            this.tableTestTableAdapter.Fill(this.заявкиDataSet.tableTest);
            Form2 F2 = new Form2();

            btSearch.Enabled = false;
            btPrev1.Enabled = false;

            lb4.Text = "";

            this.Enabled = true;
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Visible = true;
            }
        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Visible = false;
            }
        }


        public void btSearch_Click(object sender, EventArgs e)
        {
            string a;
            a = tbFam1.Text;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source=C:\\Заявки.mdb"; // строка подключения к БД
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString); // создаем подключение
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();  // создаем запрос к бд
            //myOleDbCommand.CommandText = "SELECT * FROM tableTest WHERE surname like '%" + tbFam2.Text + "%'";
            myOleDbCommand.CommandText = "SELECT * FROM tableTest WHERE surname like '%" + a + "%'";
            myOleDbConnection.Open(); // открываем базу

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader(); // выполняем запрос

            while (myOleDbDataReader.Read())    // построчно считываем результат запроса
            {
                //button1.Enabled = false;

                ////////////int h = myOleDbDataReader.GetOrdinal("surname");  // получение номера столбца Наименование
                ////////////int i = myOleDbDataReader.GetOrdinal("name");  // получение номера столбца Наименование
                ////////////int j = myOleDbDataReader.GetOrdinal("patronymic");  // получение номера столбца Наименование
                ////////////int k = myOleDbDataReader.GetOrdinal("filing_date");  // получение номера столбца Наименование
                ////////////int l = myOleDbDataReader.GetOrdinal("result");  // получение номера столбца Наименование
                ////////////int m = myOleDbDataReader.GetOrdinal("result_date");  // получение номера столбца Наименование

                //int g = myOleDbDataReader.GetOrdinal("number");  // получение номера столбца Наименование
                int h = myOleDbDataReader.GetOrdinal("surname");  // получение номера столбца Наименование
                int i = myOleDbDataReader.GetOrdinal("name");  // получение номера столбца Наименование
                int j = myOleDbDataReader.GetOrdinal("patronymic");  // получение номера столбца Наименование
                int k = myOleDbDataReader.GetOrdinal("departament");  // получение номера столбца Наименование
                int l = myOleDbDataReader.GetOrdinal("content");  // получение номера столбца Наименование
                int m = myOleDbDataReader.GetOrdinal("filing_date");  // получение номера столбца Наименование
                int n = myOleDbDataReader.GetOrdinal("result");  // получение номера столбца Наименование
                int o = myOleDbDataReader.GetOrdinal("result_date");  // получение номера столбца Наименование

                int z = dataGridView1.Rows.Add();
                //dataGridView1.Rows[n].Cells[0].Value = Convert.ToString(myOleDbDataReader.GetValue(g)); // столбец A
                dataGridView1.Rows[z].Cells[0].Value = Convert.ToString(myOleDbDataReader.GetValue(h)); // столбец A
                dataGridView1.Rows[z].Cells[1].Value = Convert.ToString(myOleDbDataReader.GetValue(i));
                dataGridView1.Rows[z].Cells[2].Value = Convert.ToString(myOleDbDataReader.GetValue(j));
                dataGridView1.Rows[z].Cells[3].Value = Convert.ToString(myOleDbDataReader.GetValue(k));
                dataGridView1.Rows[z].Cells[4].Value = Convert.ToString(myOleDbDataReader.GetValue(l));
                dataGridView1.Rows[z].Cells[5].Value = (DateTime)myOleDbDataReader.GetValue(m);
                dataGridView1.Rows[z].Cells[6].Value = Convert.ToString(myOleDbDataReader.GetValue(n));
                dataGridView1.Rows[z].Cells[7].Value = Convert.ToString(myOleDbDataReader.GetValue(o));

                //dataGridView1.Rows[n].Cells[0].Value = (string)myOleDbDataReader.GetValue(h); // столбец A
                //dataGridView1.Rows[n].Cells[1].Value = (string)myOleDbDataReader.GetValue(i); // столбец A
                //dataGridView1.Rows[n].Cells[2].Value = (string)myOleDbDataReader.GetValue(j); // столбец B
                //dataGridView1.Rows[n].Cells[3].Value = (DateTime)myOleDbDataReader.GetValue(k); // столбец C
                //dataGridView1.Rows[n].Cells[4].Value = (string)myOleDbDataReader.GetValue(l); // столбец D
                //dataGridView1.Rows[n].Cells[5].Value = (DateTime)myOleDbDataReader.GetValue(m); // столбец E


                dataGridView1.Rows[z].Cells[0].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                dataGridView1.Rows[z].Cells[1].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                dataGridView1.Rows[z].Cells[2].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                dataGridView1.Rows[z].Cells[3].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                dataGridView1.Rows[z].Cells[4].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                dataGridView1.Rows[z].Cells[5].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                dataGridView1.Rows[z].Cells[6].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                dataGridView1.Rows[z].Cells[7].Style.BackColor = System.Drawing.Color.LightSteelBlue;

                tbFam1.Clear();
                tbIm1.Clear();
                tbOt1.Clear();
            }
            myOleDbConnection.Close(); // закрываем соединение с бд


            btSearch.Enabled = false;

            //if (dataGridView1.Rows[0].Cells[0].Value == null)
            //{
            //    MessageBox.Show("Поиск успешно завершон, искомый результат найден", "Ошибка.");
            //}

            if (tbFam1.Text == "")
            {
                MessageBox.Show("Поиск успешно завершон, искомый результат найден", "Ошибка.");
                btPrev1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Поиск не дал результатов", "Ошибка.");
                btPrev1.Enabled = false;
            }

            //tbRes.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString() + " - имеется сообщение";
        }


        public void tbFam1_TextChanged(object sender, EventArgs e)
        {
            btSearch.Enabled = true;

            if (btSearch.Enabled == true)
            {
                dataGridView1.Rows.Clear();
            }
        }

        public void dataGridView1_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.tbFam2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //F2.tbIm2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //F2.tbOt2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //F2.tbOtd.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //F2.rtbApp.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //F2.tbDate.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        public void btPrev1_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.tbFam2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //F2.tbIm2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //F2.tbOt2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //F2.tbOtd.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //F2.rtbApp.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //F2.tbDate.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //F2.rtbMess.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            F2.Show();
            //F2.ShowDialog();
            //F2.StartPosition = FormStartPosition.CenterScreen;
            //this.Enabled = false;
        }
    }
}
