using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; // *
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
        int counter;
        bool flag_stop = false;
        bool flag_finish;
        
       
        
        public serch_sar()
        {
            InitializeComponent();
            btnstop.Enabled = false;
        }

        
        private static string DbConnection(string filePath)
        {
                string conStr = "";
                conStr =  filePath;
                return conStr; 
        }

        private static byte GenByte(long i)
        {
            return (byte)(i % 253);
        }
        
         
        // private void ExportData(CancellationToken token)
        private async void ExportData()
        {
            timer1.Enabled = false;
            flag_finish = false;
            counter = 10;
            label_timer.Text = "ВРЕМЯ (СЕК) ДО СЛЕДУЮЩЕЙ РЕПЛИКАЦИИ: ВЫПОЛНЯЕТСЯ";

            await Task.Run(() =>
            {
                Console.WriteLine("-----------------------СТАРТ РЕПЛИКАЦИИ, ОЖИДАЙТЕ--------------------\n");

                string gdb_meta;
                string ibs_meta;
                string dts_gdb;
                string dts_ibs;
                string[] gdb;
                string[] ibs;
                int id;
                int inckey = 0;
                string request;

                string s_1 = "";
                string s_2 = "";

                if (File.Exists("[MANGO_Replicator]id_check.txt") == false)
                {
                    File.Create("[MANGO_Replicator]id_check.txt").Dispose();
                }
                using (StreamReader stream = new StreamReader("[MANGO_Replicator]id_check.txt"))
                {
                    gdb_meta = stream.ReadLine();
                    ibs_meta = stream.ReadLine();
                }
                Console.WriteLine("gdb_meta: " + gdb_meta + "\r\nibs_meta: " + ibs_meta);

                // DateTime dt_gdb = File.GetCreationTime("localhost:" + textBox1.Text);  //@"M:\Tolya\Разные задачи\mango\Репликатор\TEST_GDB.GDB"
                // DateTime dt_ibs = File.GetCreationTime("localhost:" + textBox2.Text);  //@"M:\Tolya\Разные задачи\mango\Репликатор\TEST_IBS.IBS"

                s_1 = textBox1.Text;
                s_2 = textBox2.Text;

                DateTime dt_gdb = File.GetCreationTime(s_1);
                DateTime dt_ibs = File.GetCreationTime(s_2);

                dts_gdb = dt_gdb.ToString();
                dts_ibs = dt_ibs.ToString();

                if ((gdb_meta != "") && (ibs_meta != "") && (gdb_meta != null) && (ibs_meta != null))
                {
                    gdb = gdb_meta.Split('+');
                    ibs = ibs_meta.Split('+');

                    if (gdb[0] != dts_gdb)
                    {
                        Console.WriteLine("[gdb] Not Equal Dates");
                        request = @"select sessions.id, sessions.datetime, numbers.number, numbers.id,
                                                                    sessions.imsi_id, sessions.imei_id, sessions.tmsi, sessions.tfop_id,  
                                                                    sessions.FORWARD_FILE, sessions.tfop_corresp_id, sessions.cell_id, sessions.lac, 
                                                                    sessions.time_sessions  from sessions left join numbers on numbers.id = sessions.imsi_id 
                                                                    or sessions.imei_id = numbers.id or sessions.tfop_id = numbers.id 
                                                                    or sessions.tfop_corresp_id = numbers.id";
                    }
                    else 
                    {
                        Console.WriteLine("[gdb] Equal Dates");
                        id = int.Parse(gdb[1]);
                        request = @"select sessions.id, sessions.datetime, numbers.number, numbers.id,
                                                                    sessions.imsi_id, sessions.imei_id, sessions.tmsi, sessions.tfop_id,  
                                                                    sessions.FORWARD_FILE, sessions.tfop_corresp_id, sessions.cell_id, sessions.lac, 
                                                                    sessions.time_sessions  from sessions left join numbers on numbers.id = sessions.imsi_id 
                                                                    or sessions.imei_id = numbers.id or sessions.tfop_id = numbers.id 
                                                                    or sessions.tfop_corresp_id = numbers.id where sessions.id > " + id.ToString();
                    }

                    if (ibs[0] != dts_ibs)
                    {
                        Console.WriteLine("[ibs] Not Equal Dates");
                        // inckey = 0;
                        inckey = int.Parse(ibs[1]) + 1;
                    }
                    else
                    {
                        Console.WriteLine("[ibs] Equal Dates");
                        inckey = int.Parse(ibs[1]) + 1;
                    }

                    // Console.WriteLine("gdb_date: " + gdb[0] + "\r\ndts_gdb: " + dts_gdb + "\r\nid: " + id + "\r\n");
                    // Console.WriteLine("ibs_date: " + ibs[0] + "\r\ndts_ibs: " + dts_ibs + "\r\ns_inckey: " + inckey);
                }
                else
                {
                    inckey = 0;
                    request = @"select sessions.id, sessions.datetime, numbers.number, numbers.id,
                                                                    sessions.imsi_id, sessions.imei_id, sessions.tmsi, sessions.tfop_id,  
                                                                    sessions.FORWARD_FILE, sessions.tfop_corresp_id, sessions.cell_id, sessions.lac, 
                                                                    sessions.time_sessions  from sessions left join numbers on numbers.id = sessions.imsi_id 
                                                                    or sessions.imei_id = numbers.id or sessions.tfop_id = numbers.id 
                                                                    or sessions.tfop_corresp_id = numbers.id";
                }

                // try
                // {
                //подключение БД interbase
                var cnsb_mango = new OleDbConnectionStringBuilder();

                cnsb_mango["provider"] = "LCPI.IBProvider.3";

                cnsb_mango["location"] = "localhost:" + textBox1.Text; //; @"M:\Tolya\Разные задачи\mango\Репликатор\TEST_GDB.GDB"
                // cnsb_mango["location"] = @"M:\Tolya\Разные задачи\mango\Репликатор\TEST_GDB.GDB";

                cnsb_mango["user id"] = "sysdba"; // textBox3.Text;

                cnsb_mango["password"] = "masterkey"; // textBox4.Text;

                cnsb_mango["auto_commit"] = "true";

                var cn = new OleDbConnection(cnsb_mango.ConnectionString);
                cn.Open();

                DataTable dataTable = new DataTable();

                if (flag_stop == true)
                {
                    // ready_to_start_flag = true;
                    btnsearch.Enabled = true;
                    Console.WriteLine("-----------------------ПРИЛОЖЕНИЕ ГОТОВО К РАБОТЕ--------------------\n");
                    flag_stop = false;
                    return;
                }



                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(request, cn);  // в первой строке было - numbers.type_id


                

                // Console.WriteLine(":)");

                dbAdapter1.Fill(dataTable);

                if (flag_stop == true)
                {
                    // ready_to_start_flag = true;
                    btnsearch.Enabled = true;
                    Console.WriteLine("-----------------------ПРИЛОЖЕНИЕ ГОТОВО К РАБОТЕ--------------------\n");
                    Console.WriteLine("1");
                    flag_stop = false;
                    return;                  
                }

                // Console.WriteLine(":)");


                dataTable.Columns.Add("IMSI", typeof(Int64));
                dataTable.Columns.Add("IMEI", typeof(Int64));
                dataTable.Columns.Add("TFOP", typeof(Int64));
                dataTable.Columns.Add("TFOP_talker", typeof(Int64));

                

                //--------------------------------------------------------------------------------INTERBASE INSERT------------------------------------------------------------



                OleDbConnectionStringBuilder cnsb_IBS = new OleDbConnectionStringBuilder();

                cnsb_IBS["provider"] = "LCPI.IBProvider.3";

                cnsb_IBS["location"] = "localhost:" + textBox2.Text; // @"M:\Tolya\Разные задачи\mango\Репликатор\TEST_IBS.IBS"
                // cnsb_IBS["location"] = @"M:\Tolya\Разные задачи\mango\Репликатор\TEST_IBS.IBS";

                cnsb_IBS["user id"] = "sysdba"; // textBox3.Text;

                cnsb_IBS["password"] = "masterkey"; // textBox4.Text;

                cnsb_IBS["auto_commit"] = "true";

                cnsb_IBS.Add("nested_trans", true);

                OleDbConnection cn1 = new OleDbConnection(cnsb_IBS.ConnectionString);

                // Console.WriteLine(":)");


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    /*string unicode_sms = dataTable.Rows[i][11].ToString();
                    if (unicode_sms != "")
                    {

                        string text = unicode_sms.Substring(9);
                        string[] hexBytes = new string[text.Length / 2];
                        for (int j = 0; j < hexBytes.Length; j++)
                        {
                            hexBytes[j] = text.Substring(j * 2, 2);
                        }
                        byte[] resultBytes = hexBytes.Select(value => Convert.ToByte(value, 16)).ToArray();
                          
                    }*/


                    if (Equals(dataTable.Rows[i][3], dataTable.Rows[i][4]))
                    {
                        dataTable.Rows[i][13] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][3], dataTable.Rows[i][5]))
                    {
                        dataTable.Rows[i][14] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][3], dataTable.Rows[i][7]))
                    {
                        dataTable.Rows[i][15] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][3], dataTable.Rows[i][9]))
                    {
                        dataTable.Rows[i][16] = dataTable.Rows[i][2];
                    }

                }


                dataTable.Columns.Remove("number");
                dataTable.Columns.Remove("id1");
                dataTable.Columns.Remove("imsi_id");
                dataTable.Columns.Remove("imei_id");
                dataTable.Columns.Remove("tfop_id");
                dataTable.Columns.Remove("tfop_corresp_id");
                // dataGridView1.DataSource = dataTable;  // ----------------------------------------DataGrid
                cn.Close();

                TimeSpan duration;
                
                Console.WriteLine("TABLE_COUNT: " + dataTable.Rows.Count);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                // for (int i = inckey; i < dataTable.Rows.Count; i++)
                {
                    try
                    {
                    // if (i < 300) // для отладки
                    // {
                        Console.WriteLine(i);
                        // Console.WriteLine("ONE");

                        // Console.WriteLine("INCKEY: " + inckey);
                        
                        if (flag_stop == true)
                        {
                            // Console.WriteLine("TWO");
                            // break;
                            // ready_to_start_flag = true;
                            btnsearch.Enabled = true;
                            Console.WriteLine("-----------------------ПРИЛОЖЕНИЕ ГОТОВО К РАБОТЕ--------------------\n");
                            flag_stop = false;
                            inckey++;

                            // cn1.Dispose();
                            return;
                        }
                        // Console.WriteLine("THREE");
                                     
                        duration = TimeSpan.FromSeconds((double)dataTable.Rows[i][6]);
                        string voice = @dataTable.Rows[i][3].ToString();

                        Console.WriteLine("inckey: " + inckey);
                        //string sms = dataTable.Rows[i][11].ToString();

                        // Console.WriteLine("GDB: " + File.GetCreationTime(@"M:\Tolya\Разные задачи\mango\Репликатор\TEST_GDB.GDB"));  //"localhost:" + textBox1.Text;
                        // Console.WriteLine("IBS: " + File.GetCreationTime(@"M:\Tolya\Разные задачи\mango\Репликатор\TEST_IBS.IBS"));  // "localhost:" + textBox2.Text;                  
                        
                        if (voice != "")
                        {
                            Console.WriteLine("A_1");
                            
                            cn1.Open();
                            OleDbTransaction tr1 = cn1.BeginTransaction(IsolationLevel.ReadCommitted);
                            byte[] readed_bytes = File.ReadAllBytes(voice);
                            OleDbParameter blob = new OleDbParameter();
                            blob.OleDbType = OleDbType.LongVarBinary;
                            blob.Value = readed_bytes;
                            OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_DURATION, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER, S_EVENTCODE) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_DURATION, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER, :S_EVENTCODE)", cn1, tr1);
                            // OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER, S_EVENTCODE) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER, :S_EVENTCODE)", cn1, tr1);
                            cmd1.Parameters.AddWithValue(":S_TYPE", 0);
                            cmd1.Parameters.AddWithValue(":S_INCKEY", inckey);
                            cmd1.Parameters.AddWithValue(":S_DATETIME", dataTable.Rows[i][1]);
                            cmd1.Parameters.AddWithValue(":S_DURATION", duration);
                            cmd1.Parameters.AddWithValue(":S_SYSNUMBER2", dataTable.Rows[i][2]);
                            cmd1.Parameters.AddWithValue(":S_CID", dataTable.Rows[i][4]);
                            cmd1.Parameters.AddWithValue(":S_LAC", dataTable.Rows[i][5]);
                            cmd1.Parameters.AddWithValue(":S_SYSNUMBER", dataTable.Rows[i][7]);
                            cmd1.Parameters.AddWithValue(":S_USERNUMBER", dataTable.Rows[i][9]);
                            cmd1.Parameters.AddWithValue(":S_TALKER", dataTable.Rows[i][10]);
                            cmd1.Parameters.AddWithValue(":S_EVENTCODE", "PCM-128");

                            using (StreamWriter stream = new StreamWriter("[MANGO_Replicator]id_check.txt", false))
                            {
                                // stream.Write(dts_gdb + "+" + dataTable.Rows[i][0].ToString() + "\r\n" + dts_ibs + "+" + i.ToString());
                                stream.Write(dts_gdb + "+" + dataTable.Rows[i][0].ToString() + "\r\n" + dts_ibs + "+" + inckey.ToString());
                            }

                            cmd1.ExecuteNonQuery();

                            OleDbCommand cmd = new OleDbCommand("insert into SPR_SP_DATA_1_TABLE (S_INCKEY, S_ORDER, S_RECORDTYPE, S_FSPEECH) values (:S_INCKEY, :S_ORDER, :S_RECORDTYPE, :S_FSPEECH)", cn1, tr1);
                            cmd.Parameters.AddWithValue(":S_INCKEY", inckey);
                            cmd.Parameters.AddWithValue(":S_ORDER", 0);
                            cmd.Parameters.AddWithValue(":S_RECORDTYPE", "PCM-128");
                            cmd.Parameters.Add(blob);
                            cmd.ExecuteNonQuery();
                            tr1.Commit();

                            cn1.Close();
                            cmd1.Dispose();
                            tr1.Dispose();
                            // cn1.Dispose();
                            Console.WriteLine("A_2");
                        }
                        else
                        {
                            Console.WriteLine("B_1");                        
                            cn1.Open();
                            OleDbTransaction tr1 = cn1.BeginTransaction(IsolationLevel.ReadCommitted);
                            OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_DURATION, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_DURATION, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER)", cn1, tr1);
                            // OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER)", cn1, tr1);
                            cmd1.Parameters.AddWithValue(":S_TYPE", 0); //dataTable.Rows[i][2]);
                            cmd1.Parameters.AddWithValue(":S_INCKEY", inckey);
                            cmd1.Parameters.AddWithValue(":S_DATETIME", dataTable.Rows[i][1]);
                            cmd1.Parameters.AddWithValue(":S_DURATION", duration);
                            cmd1.Parameters.AddWithValue(":S_SYSNUMBER2", dataTable.Rows[i][2]);
                            cmd1.Parameters.AddWithValue(":S_CID", dataTable.Rows[i][4]);
                            cmd1.Parameters.AddWithValue(":S_LAC", dataTable.Rows[i][5]);
                            cmd1.Parameters.AddWithValue(":S_SYSNUMBER", dataTable.Rows[i][7]);
                            cmd1.Parameters.AddWithValue(":S_USERNUMBER", dataTable.Rows[i][9]);
                            cmd1.Parameters.AddWithValue(":S_TALKER", dataTable.Rows[i][10]);

                            using (StreamWriter stream = new StreamWriter("[MANGO_Replicator]id_check.txt", false))
                            {
                                // stream.Write(dts_gdb + "+" + dataTable.Rows[i][0].ToString() + "\r\n" + dts_ibs + "+" + i.ToString());
                                stream.Write(dts_gdb + "+" + dataTable.Rows[i][0].ToString() + "\r\n" + dts_ibs + "+" + inckey.ToString());
                            }

                            cmd1.ExecuteNonQuery();
                            tr1.Commit();
                            // cn1.Dispose();
                            cn1.Close();

                            cmd1.Dispose();
                            tr1.Dispose();
                            Console.WriteLine("B_2");  
                        }                    
                    // }
                    inckey++;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        cn1.Close();
                        Console.WriteLine("Вероятно, несоответствие данных в базе и на диске");
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////// Ошибка с запуском остановленного во время передачи д-х в DataTable репликатора,
                // когда часть данных уже была реплицирована
      
                Console.WriteLine("---------------------ОЖИДАНИЕ СЛЕДУЮЩЕЙ РЕПЛИКАЦИИ-----------------\n");

                flag_stop = false;
                flag_finish = true;
                // btnstop.Enabled = false;
                // btnsearch.Enabled = true;

                
            });

            // Console.WriteLine(":(");

            

            if ((btnstop.Enabled == true) && (btnsearch.Enabled == false))
            {
                timer1.Enabled = true;
            }


            // Console.WriteLine(":((");


            //} 

            //catch (System.Data.OleDb.OleDbException)
            //{ 
            //MessageBox.Show("Введите пути для подключения к базам данных!", "MANGO_Replicate");
            //btnsearch.Enabled = true;
            //}
        }


        private void btnsearch_Click(object sender, EventArgs e)
        {
            btnsearch.Enabled = false;
            btnstop.Enabled = true;

            ExportData();        
        }


        private void btnstop_Click(object sender, EventArgs e)
        {
            
            label_timer.Text = "ВРЕМЯ (СЕК) ДО СЛЕДУЮЩЕЙ РЕПЛИКАЦИИ: ";

            timer1.Enabled = false;
            btnstop.Enabled = false;
            // btnsearch.Enabled = true;
            flag_stop = true;
            
            Console.WriteLine("--------------------ВЫПОЛНЯЕТСЯ ОСТАНОВКА РЕПЛИКАЦИИ-------------------\n");

            if ((flag_stop == true) && ((counter != 10) || (flag_finish == true)))
            {
                btnsearch.Enabled = true;
                Console.WriteLine("-----------------------ПРИЛОЖЕНИЕ ГОТОВО К РАБОТЕ--------------------\n");
                flag_stop = false;
                // Console.WriteLine("2");
            }

            counter = 10; // для отладки
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Console.WriteLine(":)");
                
            counter--;
            label_timer.Text = "ВРЕМЯ (СЕК) ДО СЛЕДУЮЩЕЙ РЕПЛИКАЦИИ: " + counter.ToString();
            if (counter == 0)
            {
                // Console.WriteLine("-_-");
                label_timer.Text = "ВРЕМЯ (СЕК) ДО СЛЕДУЮЩЕЙ РЕПЛИКАЦИИ: ВЫПОЛНЯЕТСЯ";

                ExportData();
                // counter = 10;
            }
            //}
            
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
      

     
    }
}
