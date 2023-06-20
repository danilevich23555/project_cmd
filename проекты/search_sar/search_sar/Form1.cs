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
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace search_sar
{


    

    
    public partial class serch_sar : Form
    {
        private const int MaxLength = 50;
        
        
        
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
        
        
         

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //gдсчет количества введенных строк
            
            int y = txtsearch.Lines.Length;
            if (String.IsNullOrEmpty(txtsearch.Lines[y-1]))
                        {
                           y = y - 1; 
                        }
         //подключение БД interbase
            //var cnsb = new OleDbConnectionStringBuilder();

            //cnsb["provider"] = "LCPI.IBProvider.3";

            //cnsb["location"] = "localhost:" + DbConnection(dbOpenFileDialog.FileName);

            //cnsb["user id"] = "SYSDBA";

            //cnsb["password"] = "masterkey";

           // cnsb["auto_commit"] = "true";

            //var cn = new OleDbConnection(cnsb.ConnectionString);

            //cn.Open();
            //MessageBox.Show("подключение установлено", "Search_sar");
         //__________________________________________________________________________________
           
                OleDbConnection dbcon = new OleDbConnection (@"Provider = Microsoft.Ace.OLEDB.12.0; Data Source =" + DbConnection(dbOpenFileDialog.FileName));
                dbcon.Open();
                DataTable dataTable = new DataTable();
                for (int schet = 0; schet < y; schet++)
                {

                    
                    
                   OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"SELECT * FROM 01_общий WHERE ([Имя Контакта] like '%" + txtsearch.Lines[schet] + "%') OR ([ТелефонвКниге] like '%" + txtsearch.Lines[schet] + "%') OR ([Username Telegram] like '%" + txtsearch.Lines[schet] + "%') OR ([Номер Объекта] like '%" + txtsearch.Lines[schet] + "%')", dbcon);
                   // OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"SELECT * FROM SPR_SPEECH_TABLE WHERE (S_USERNUMBER like '%" + txtsearch.Lines[schet] + "%') OR (S_TALKER like '%" + txtsearch.Lines[schet] + "%')", cn);
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
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        ExcelApp.Cells[i + 1, j + 1] = "Код";
                        ExcelApp.Cells[i + 1, j + 2] = "Русские";
                        ExcelApp.Cells[i + 1, j + 3] = "Дата выявления";
                        ExcelApp.Cells[i + 1, j + 4] = "Имя контакта";
                        ExcelApp.Cells[i + 1, j + 5] = "ТелефоновКниге";
                        ExcelApp.Cells[i + 1, j + 6] = "Username Telegram";
                        ExcelApp.Cells[i + 1, j + 7] = "объект";
                        ExcelApp.Cells[i + 1, j + 8] = "id объекта";
                        ExcelApp.Cells[i + 1, j + 9] = "номер объекта";
                        ExcelApp.Cells[i + 1, j + 10] = "ID_Учетки В системе Телеграм";
                        ExcelApp.Cells[i + 1, j + 11] = "Доп Номер Объекта";
                        ExcelApp.Cells[i + 1, j + 12] = "IMEI";
                        ExcelApp.Cells[i + 1, j + 13] = "IMSI";
                        ExcelApp.Cells[i + 1, j + 14] = "Примечание";
                        ExcelApp.Cells[i + 1, j + 15] = "Примечание2";

                        
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
                btn_change.Enabled = true;
                btnexport.Enabled = true;
                btnupdate.Enabled = true;
                btnanalitic.Enabled = true;
                btntwinscontact.Enabled = true;
                btnwheretable.Enabled = true;
                btn_IDobject.Enabled = true;
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

        
      

     
    }
    }
