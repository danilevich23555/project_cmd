using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Threading;




namespace search_sar
{


    

   

    
    public partial class serch_sar : Form
    {
        private const int MaxLength = 50;

        
        static void SHOW_FORM3()
        {
           
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            
        }
        
        public serch_sar()
        {
            InitializeComponent();
        }

        

        private static string DbConnection(string filePath)
        {

                string conStr = "";
                conStr =  filePath;
                return conStr;
             
        }

        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" + DbConnection(dbOpenFileDialog.FileName) + ";" + "Version=3;New=True;Compress=True;");
            // Open the connection:
            Console.WriteLine("подключение установленно");
            sqlite_conn.Open();
            return sqlite_conn;
        }

        static string ReadData4(SQLiteConnection conn, string sql_command)
        {

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql_command;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            string result="";
            while (sqlite_datareader.Read())
            {
                Console.WriteLine(sql_command);
                var count_name_contact = sqlite_datareader.GetString(0);
                result = count_name_contact;
            }
            return result;
        }

        static List<List<string>> ReadData(SQLiteConnection conn, string sql_command)
        {
        
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql_command;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            var result = new List<List<string>>();
            while (sqlite_datareader.Read())
            {
                string abonent_number = sqlite_datareader.GetString(0);
                string contact_number = sqlite_datareader.GetString(1);
                string name_contact = sqlite_datareader.GetString(2);
                var str = new List<string>() { abonent_number, contact_number, name_contact};
                result.Add(str);
            }
            return result;
        }

        static string ReadData3(SQLiteConnection conn, string sql_command)
        {

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql_command;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            string result = "";
            while (sqlite_datareader.Read())
            {
                var name_contact = sqlite_datareader.GetString(0);
                result = result + ", " + name_contact;
            }
            return result;


        }

        static List<List<string>> ReadData2(SQLiteConnection conn, string sql_command)
        {

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql_command;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            var result = new List<List<string>>();
            while (sqlite_datareader.Read())
            {
                string number = sqlite_datareader.GetString(0);
                string fio = sqlite_datareader.GetString(1);
                string address = sqlite_datareader.GetString(2);
                string passport = sqlite_datareader.GetString(3);
                string date_place = sqlite_datareader.GetString(4);
                string cod006 = sqlite_datareader.GetString(5);
                var str = new List<string>() { number, fio, address, passport, date_place, cod006 };
                result.Add(str);
            }
            return result;
        }
         
         

        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnsearch.Enabled = false;
            btnexport.Enabled = false;
            button_tag_search.Enabled = false;
            Thread myTheard = new Thread(SHOW_FORM3);
            myTheard.Start();
            

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "abonent_number";
            dataGridView1.Columns[1].Name = "contact_number";
            dataGridView1.Columns[2].Name = "name_contact";


            dataGridView2.Rows.Clear();
            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "number";
            dataGridView2.Columns[1].Name = "fio";
            dataGridView2.Columns[2].Name = "address";
            dataGridView2.Columns[3].Name = "passport";
            dataGridView2.Columns[4].Name = "date_place";
            dataGridView2.Columns[5].Name = "cod006";
           
            //gдсчет количества введенных строк
            
            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y-1]))
                        {
                           y = y - 1; 
                        }
                SQLiteConnection con = CreateConnection();
                string a="";
                int flag = 0;
                for (int schet = 0; schet < y; schet++)
                {
                    string k = txtsearch.Lines[schet];
                    if ((k[0] != '1') && (k[0] != '2') && (k[0] != '3') && (k[0] != '4') && (k[0] != '5') && (k[0] != '6') && (k[0] != '7') && (k[0] != '8') && (k[0] != '9'))
                    {
                        string textinfo = k.First().ToString().ToUpper() + String.Concat(k.Skip(1)).ToLower();
                        List<string> tuple1 = new List<string>() { k.ToUpper(), k.ToLower(), textinfo };
                        for (int l = 0; l < 3; l++)
                        {
                            Console.WriteLine(tuple1[l]);
                            string sql_comand = "SELECT * FROM contacts where (name_contact like '%" + tuple1[l] + "%')";
                            string sql_comand_reg = "SELECT * FROM reg_data where (fio like '%" + tuple1[l] + "%')";
                            foreach (var i in ReadData(con, sql_comand))
                            {
                                string[] row = new string[] { i[0], i[1], i[2] };
                                dataGridView1.Rows.Add(row);

                            }
                            foreach (var z in ReadData2(con, sql_comand_reg))
                            {
                                string[] row1 = new string[] { z[0], z[1], z[2], z[3], z[4], z[5] };
                                dataGridView2.Rows.Add(row1);

                            }
                        }

                    }
                    else
                    {
                        flag = 1;
                        if (schet + 1 == y)
                        {
                            string s = txtsearch.Lines[schet];
                            a = a + s;
                        }
                        else
                        {
                            string s = txtsearch.Lines[schet];
                            a = a + s + ",";
                        }
                    }
                   
                   

                   
                       
                   //dataGridView1.DataSource = ReadData(con, s);
              
                    
                }
                Console.WriteLine(a);
                if (flag ==1)
                 {
                     //Console.WriteLine("обрабатывается номер" + a + ", обработано " + schet + " номеров из " + y + " ,осталось " + (-schet + y));
                     string sql_comand1 = "SELECT * FROM contacts where abonent_number in (" + a + ") or contact_number in (" + a + ")";
                     //string sql_comand_name = "SELECT distinct name_contact FROM contacts where  (contact_number like '%" + a + "%')";
                     //string result_name = ReadData3(con, sql_comand_name);



                     foreach (var i in ReadData(con, sql_comand1))
                     {

                         string[] row = new string[] { i[0], i[1], i[2] };
                         dataGridView1.Rows.Add(row);



                     }
                     string sql_comand2 = "SELECT * FROM reg_data where number in (" + a + ")";
                     foreach (var z in ReadData2(con, sql_comand2))
                     {

                         string[] row1 = new string[] { z[0], z[1], z[2], z[3], z[4], z[5] };
                         dataGridView2.Rows.Add(row1);
                     }

                    }
                
                y = 0;
                con.Close();
                btnsearch.Enabled = true;
                btnexport.Enabled = true;
                button_tag_search.Enabled = true;
                
              
            

            if (dataGridView1.Rows.Count == 0)
            {
                myTheard.Abort();
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                myTheard.Abort();
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");
               

            }
             
        }

       
        

        private void btnexport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            { 
                MessageBox.Show("Введите данные для поиска", "Search_sar");
            }
            else
            {
            //Приложение
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.Add();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        ExcelApp.Cells[i + 1, j + 1] = "number";
                        ExcelApp.Cells[i + 1, j + 2] = "fio";
                        ExcelApp.Cells[i + 1, j + 3] = "address";
                        ExcelApp.Cells[i + 1, j + 4] = "passport";
                        ExcelApp.Cells[i + 1, j + 5] = "date_place";
                        ExcelApp.Cells[i + 1, j + 6] = "code006";



                    }
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                }
            }
            
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.Add();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        ExcelApp.Cells[i + 1, j + 1] = "Номер объекта";
                        ExcelApp.Cells[i + 1, j + 2] = "Номер контакта";
                        ExcelApp.Cells[i + 1, j + 3] = "Имя контакта";




                    }
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            
            //Вызываем excel файл.
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        }


        private void connectMenu_Click(object sender, EventArgs e)
        {
            
            if (dbOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DbConnection(dbOpenFileDialog.FileName);
                btnsearch.Enabled = true;
                btnexport.Enabled = true;
                button_tag_search.Enabled = true;
               
                
            }
            
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
       {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }



            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
            dbcon.Open();
            DataTable dataTable = new DataTable();
            for (int schet = 0; schet < y; schet++)
            {

                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"SELECT distinct [Номер Объекта], IMEI FROM 01_общий WHERE (([IMEI] like '%" + txtsearch.Lines[schet] + "%') OR ([Номер Объекта] like '%" + txtsearch.Lines[schet] + "%')) and (TFOP is not null) and (IMEI is not null) order by TFOP desc", dbcon);
                dbAdapter1.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dbcon.Close();
            y = 0;
        }

        public static string str_connect { get; set; }
          
        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
            Form2 newfrm = new Form2();
            newfrm.Show();
          
      
           
        }

        private void btnanalitic_Click(object sender, EventArgs e)
        {
            //gдсчет количества введенных строк

            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }



            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
            dbcon.Open();
            DataTable dataTable = new DataTable();
            for (int schet = 0; schet < y; schet++)
            {
                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"select test.ТелефонвКниге, count(test.ТелефонвКниге) as интенсивность from (select * from 01_общий where Примечание like '%" + txtsearch.Lines[schet] + "%') as test group by test.ТелефонвКниге having (count(test.ТелефонвКниге)) > 1 order by count(test.ТелефонвКниге) desc ", dbcon);
                  dbAdapter1.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dbcon.Close();
            y = 0;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");


            }

        }

        private void btntwinscontact_Click(object sender, EventArgs e)
        {
            //gдсчет количества введенных строк

            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }



            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
           dbcon.Open();
            DataTable dataTable = new DataTable();
           for (int schet = 0; schet < y; schet++)
           {
               OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"select distinct [Номер Объекта], ТелефонвКниге  from 01_общий WHERE [01_общий].[Номер Объекта] = '" + txtsearch.Lines[schet] + "'", dbcon);
               dbAdapter1.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
           }

           //string [] cells = dataTable.Rows.Contains;   

            dbcon.Close();
           
            y = 0;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");


            }
        }

        private void btnwheretable_Click(object sender, EventArgs e)
        {
            //gдсчет количества введенных строк

            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }



            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
            dbcon.Open();
            DataTable dataTable = new DataTable();
            for (int schet = 0; schet < y; schet++)
            {
                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"(SELECT distinct [01_общий].[ТелефонвКниге], 'Телеграмм контакты' FROM 01_общий WHERE ((([01_общий].ТелефонвКниге) = '" + txtsearch.Lines[schet] + "'))) union (SELECT distinct [02_телеграмм].НОМЕР, 'Телеграмм объект' FROM  02_телеграмм WHERE ((([02_телеграмм].НОМЕР) = '" + txtsearch.Lines[schet] + "'))) union (SELECT distinct  [07_Input].[HP], 'Input' FROM  07_Input  where ((([07_Input].[HP]) = '" + txtsearch.Lines[schet] + "')))", dbcon);
                dbAdapter1.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dbcon.Close();
            y = 0;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");


            }
        }

        private void btn_IDobject_Click(object sender, EventArgs e)
        {
            //gдсчет количества введенных строк

            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }



            OleDbConnection dbcon = new OleDbConnection(@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
            dbcon.Open();
            DataTable dataTable = new DataTable();
            for (int schet = 0; schet < y; schet++)
            {

                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"SELECT * FROM 01_общий WHERE ([ID объекта] = '" + txtsearch.Lines[schet] + "') OR ([ID_Учетки В системе Телеграм] = '" + txtsearch.Lines[schet] + "')", dbcon);
                dbAdapter1.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            dbcon.Close();
            y = 0;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");


            }

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            btnsearch.Enabled = false;
            btnexport.Enabled = false;
            button_tag_search.Enabled = false;
            Thread myTheard = new Thread(SHOW_FORM3);
            myTheard.Start();


            dataGridView3.Rows.Clear();
            dataGridView3.ColumnCount = 3;
            dataGridView3.Columns[0].Name = "abonent_number";
            dataGridView3.Columns[1].Name = "TAG";
            dataGridView3.Columns[2].Name = "Количество";
            


           

            //gдсчет количества введенных строк

            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y - 1]))
            {
                y = y - 1;
            }
            SQLiteConnection con = CreateConnection();
            string a = "";
            int flag = 0;
            for (int schet = 0; schet < y; schet++)
            {
                string s = txtsearch.Lines[schet];
                string sql_comand2 = "SELECT distinct name_contact FROM contacts where  contact_number = " + s + "";
                string sql_comand4 = "select count(*) from (SELECT distinct name_contact FROM contacts where  contact_number = " + s + ")";
                string result = ReadData3(con, sql_comand2);
                string result_count = (result.Split(',').Count() - 1).ToString();
                string[] row = new string[] { s, result,  result_count };
                Console.WriteLine("осталось " + (y - schet) + " номеров из " + y );
                dataGridView3.Rows.Add(row);



                
                
                    
                





                //dataGridView1.DataSource = ReadData(con, s);


            }
            Console.WriteLine(a);
            
                

            

            y = 0;
            con.Close();
            btnsearch.Enabled = true;
            btnexport.Enabled = true;
            button_tag_search.Enabled = true;




            if (dataGridView1.Rows.Count == 0)
            {
                myTheard.Abort();
                MessageBox.Show("Поиск не дал результатов", "Search_sar");

            }
            else
            {
                myTheard.Abort();
                MessageBox.Show("Поиск успешно завершен, искомый результат найден", "Search_sar");


            }
        }

        
      

     
    }
    }
