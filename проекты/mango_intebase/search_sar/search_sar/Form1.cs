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

        private static byte GenByte(long i)
        {
            return (byte)(i % 253);
        }
        
         

        private void btnsearch_Click(object sender, EventArgs e)
        {

            btnsearch.Enabled = false;
            try
            {
                //подключение БД interbase
                var cnsb_mango = new OleDbConnectionStringBuilder();

                cnsb_mango["provider"] = "LCPI.IBProvider.3";

                cnsb_mango["location"] = "localhost:" + textBox1.Text;

                cnsb_mango["user id"] = textBox3.Text;

                cnsb_mango["password"] = textBox4.Text;

                cnsb_mango["auto_commit"] = "true";

                var cn = new OleDbConnection(cnsb_mango.ConnectionString);

              

                cn.Open();


                DataTable dataTable = new DataTable();
                



                
                OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter(@"select sessions.id, sessions.datetime, numbers.number, numbers.type_id, numbers.id, sessions.imsi_id, sessions.imei_id, sessions.tmsi, sessions.tfop_id,  
                                                                        sessions.FORWARD_FILE, sessions.tfop_corresp_id, sessions.cell_id, sessions.lac, sessions.time_sessions  from sessions left join numbers
                                                                            on numbers.id = sessions.imsi_id or sessions.imei_id = numbers.id or sessions.tfop_id = numbers.id or sessions.tfop_corresp_id = numbers.id", cn);



               
                
                 dbAdapter1.Fill(dataTable);
                

                dataTable.Columns.Add("IMSI", typeof(Int64));
                dataTable.Columns.Add("IMEI", typeof(Int64));
                dataTable.Columns.Add("TFOP", typeof(Int64));
                dataTable.Columns.Add("TFOP_talker", typeof(Int64));
                dataGridView1.DataSource = dataTable;






                //--------------------------------------------------------------------------------INTERBASE INSERT------------------------------------------------------------


                
                OleDbConnectionStringBuilder cnsb_IBS = new OleDbConnectionStringBuilder();

                cnsb_IBS["provider"] = "LCPI.IBProvider.3";

                cnsb_IBS["location"] = "localhost:" + textBox2.Text;

                cnsb_IBS["user id"] = textBox3.Text;

                cnsb_IBS["password"] = textBox4.Text;

                cnsb_IBS["auto_commit"] = "true";

                cnsb_IBS.Add("nested_trans", true);

                OleDbConnection cn1 = new OleDbConnection(cnsb_IBS.ConnectionString);










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


                    if (Equals(dataTable.Rows[i][4], dataTable.Rows[i][5]))
                    {
                        dataTable.Rows[i][14] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][4], dataTable.Rows[i][6]))
                    {
                        dataTable.Rows[i][15] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][4], dataTable.Rows[i][8]))
                    {
                        dataTable.Rows[i][16] = dataTable.Rows[i][2];
                    }
                    else if (Equals(dataTable.Rows[i][4], dataTable.Rows[i][10]))
                    {
                        dataTable.Rows[i][17] = dataTable.Rows[i][2];
                    }

                    if (dataTable.Rows[i][3].ToString() == Convert.ToString('3'))
                    {
                        dataTable.Rows[i][3] = Convert.ToString('1');
                    }
                    else
                    {
                        dataTable.Rows[i][3] = Convert.ToString('0');
                    }
                }



                dataTable.Columns.Remove("number");
                dataTable.Columns.Remove("id1");
                dataTable.Columns.Remove("imsi_id");
                dataTable.Columns.Remove("imei_id");
                dataTable.Columns.Remove("tfop_id");
                dataTable.Columns.Remove("tfop_corresp_id");
                
                cn.Close();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    Console.WriteLine(dataTable.Rows[i][0]);
                    Console.WriteLine(i);
                    string voice = @dataTable.Rows[i][4].ToString();
                    //string sms = dataTable.Rows[i][11].ToString();
                    if (voice != "")
                    {
                        cn1.Open();
                        OleDbTransaction tr1 = cn1.BeginTransaction(IsolationLevel.ReadCommitted);
                        byte[] readed_bytes = File.ReadAllBytes(voice);
                        OleDbParameter blob = new OleDbParameter();
                        blob.OleDbType = OleDbType.LongVarBinary;
                        blob.Value = readed_bytes;
                        OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER, S_EVENTCODE) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER, :S_EVENTCODE)", cn1, tr1);
                        cmd1.Parameters.AddWithValue(":S_TYPE", Convert.ToInt32(dataTable.Rows[i][2]));
                        cmd1.Parameters.AddWithValue(":S_INCKEY", i);
                        cmd1.Parameters.AddWithValue(":S_DATETIME", dataTable.Rows[i][1]);
                        cmd1.Parameters.AddWithValue(":S_SYSNUMBER2", dataTable.Rows[i][3]);
                        cmd1.Parameters.AddWithValue(":S_CID", dataTable.Rows[i][5]);
                        cmd1.Parameters.AddWithValue(":S_LAC", dataTable.Rows[i][6]);
                        cmd1.Parameters.AddWithValue(":S_SYSNUMBER", dataTable.Rows[i][8]);
                        cmd1.Parameters.AddWithValue(":S_USERNUMBER", dataTable.Rows[i][10]);
                        cmd1.Parameters.AddWithValue(":S_TALKER", dataTable.Rows[i][11]);
                        cmd1.Parameters.AddWithValue(":S_EVENTCODE", "PCM-128");
                        cmd1.ExecuteNonQuery();


                        OleDbCommand cmd = new OleDbCommand("insert into SPR_SP_DATA_1_TABLE (S_INCKEY, S_ORDER, S_RECORDTYPE, S_FSPEECH) values (:S_INCKEY, :S_ORDER, :S_RECORDTYPE, :S_FSPEECH)", cn1, tr1);
                        cmd.Parameters.AddWithValue(":S_INCKEY", i);
                        cmd.Parameters.AddWithValue(":S_ORDER", 0);
                        cmd.Parameters.AddWithValue(":S_RECORDTYPE", "PCM-128");
                        cmd.Parameters.Add(blob);
                        cmd.ExecuteNonQuery();
                        tr1.Commit();
                        cn1.Close();
                    }
                    else
                    {
                        cn1.Open();
                        OleDbTransaction tr1 = cn1.BeginTransaction(IsolationLevel.ReadCommitted);
                        OleDbCommand cmd1 = new OleDbCommand("insert into SPR_SPEECH_TABLE (S_TYPE, S_INCKEY, S_DATETIME, S_SYSNUMBER2, S_CID, S_LAC, S_SYSNUMBER, S_USERNUMBER, S_TALKER) values (:S_TYPE, :S_INCKEY, :S_DATETIME, :S_SYSNUMBER2, :S_CID, :S_LAC, :S_SYSNUMBER, :S_USERNUMBER, :S_TALKER)", cn1, tr1);
                        cmd1.Parameters.AddWithValue(":S_TYPE", Convert.ToInt32(dataTable.Rows[i][2]));
                        cmd1.Parameters.AddWithValue(":S_INCKEY", i);
                        cmd1.Parameters.AddWithValue(":S_DATETIME", dataTable.Rows[i][1]);
                        cmd1.Parameters.AddWithValue(":S_SYSNUMBER2", dataTable.Rows[i][3]);
                        cmd1.Parameters.AddWithValue(":S_CID", dataTable.Rows[i][5]);
                        cmd1.Parameters.AddWithValue(":S_LAC", dataTable.Rows[i][6]);
                        cmd1.Parameters.AddWithValue(":S_SYSNUMBER", dataTable.Rows[i][8]);
                        cmd1.Parameters.AddWithValue(":S_USERNUMBER", dataTable.Rows[i][10]);
                        cmd1.Parameters.AddWithValue(":S_TALKER", dataTable.Rows[i][11]);
                        cmd1.ExecuteNonQuery();
                        tr1.Commit();
                        cn1.Close();
                    }





                }
                btnsearch.Enabled = true;
            }

            catch (System.Data.OleDb.OleDbException)
            { MessageBox.Show("Введите пути для подключения к базам данных!", "MANGO_Replicate");
            btnsearch.Enabled = true;
            }

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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        
      

     
    }
    }
