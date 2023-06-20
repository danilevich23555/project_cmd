using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forD
{
    public partial class SQLCommandForm : Form
    {
        private string server;
        private string schema;
        private string password;
        public SQLCommandForm(string server, string schema, string password)
        {
            this.server = server;
            this.schema = schema;
            this.password = password;
            InitializeComponent();
        }
        private string makeSQLCommandString(string strSQL, long start, long finish)
        {
            int index = strSQL.IndexOf("where");
            if (index > 0)
            {
                strSQL = strSQL + " and (s_inckey between " + start + " AND " + finish + ")";
            }
            else
            {
                strSQL = strSQL + " where (s_inckey between " + start + " AND " + finish + ")";
            }
            return strSQL;
        }
        private void executeSQL(string strSQL, Int64 step)
        {
            long minPK = 0, maxPK = 0;
            string str = strSQL;
            OracleConnection connection = new OracleConnection(@"Data Source=" + server + "; User ID=sysdba; password=" + password + ";");
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            string path = "";
            path = DateTime.Now.ToString();
            path = path.Replace(":", "_") + " sql command.log";
            StreamWriter file = new StreamWriter(path, false, Encoding.Unicode);
            try
            {

                Application.DoEvents();

                if (startPKCheckBox.Checked)
                {
                    minPK = Convert.ToInt64(startPKTextBox.Text);
                }
                else
                {
                    minPK = 0;
                }
                if (finishPKCheckBox.Checked)
                {
                    maxPK = Convert.ToInt64(finishPKTextBox.Text);
                }
                else
                {

                    string cmd = @"select max(s_inckey) from " + schema + ".spr_speech_table";
                    OracleCommand command1 = new OracleCommand(cmd, connection);
                    command1.Transaction = transaction;
                    OracleDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        maxPK = Convert.ToInt64(reader[0]);
                    }
                    transaction.Commit();
                    transaction = connection.BeginTransaction();
                }
                string question = "Вы действительно хотите выполнить SQL команду \n" + strSQL +"\n на диапазоне записей с " + minPK + " по " + maxPK + "?";
                long currentStartIndex = minPK + 1;
                if (MessageBox.Show(question, "Обработка записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    infoAboutProcessRichTextBox.Text += DateTime.Now.ToString();
                    infoAboutProcessRichTextBox.Text += @": производится выполнение команды." + "\n";
                    file.WriteLine(DateTime.Now.ToString() + @": производится выполнение команды.");
                    long currentFinishIndex = 0;

                    while (currentStartIndex <= maxPK)
                    {
                        if ((currentStartIndex + step - 1) < maxPK)
                        {
                            currentFinishIndex = currentStartIndex + step - 1;
                        }
                        else
                        {
                            currentFinishIndex = maxPK;
                        }
                        infoAboutProcessRichTextBox.Text += DateTime.Now.ToString();
                        infoAboutProcessRichTextBox.Text += @": обработка записей с " + currentStartIndex + " по " + currentFinishIndex + "... ";
                        file.Write(DateTime.Now.ToString() + @": обработка записей с " + currentStartIndex + " по " + currentFinishIndex + "... ");
                        str = strSQL;
                        str = makeSQLCommandString(str, currentStartIndex, currentFinishIndex);
                        
                      //  if (MessageBox.Show(str,"",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            OracleCommand command = new OracleCommand(str, connection);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            infoAboutProcessRichTextBox.Text += "Успешно. \n";
                            file.WriteLine("Успешно.");
                            Application.DoEvents();
                            currentStartIndex += step;
                            transaction = connection.BeginTransaction();
                        }
                        
                    }
                    transaction.Rollback();
                    MessageBox.Show("Обработка успешно завершена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    infoAboutProcessRichTextBox.Text += "Обработка успешно завершена. \n";
                    file.WriteLine("Обработка успешно завершена.");
                    file.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                infoAboutProcessRichTextBox.Text += ex.Message.ToString();
                infoAboutProcessRichTextBox.Text += " Ошибка. \n";
                file.WriteLine("Ошибка.");
                file.Close();
            }
        }
        private void startPKCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startPKCheckBox.Checked)
            {
                startPKTextBox.Enabled = true;
            }
            else
            {
                startPKTextBox.Enabled = false;
            }
        }

        private void finishPKCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (finishPKCheckBox.Checked)
            {
                finishPKTextBox.Enabled = true;
            }
            else
            {
                finishPKTextBox.Enabled = false;
            }
        }

        private void ExecSQLButton_Click(object sender, EventArgs e)
        {
            executeSQL(SQLCommandRichTextBox.Text, (long)numericUpDown.Value);
        }

        private void SQLCommandForm_Load(object sender, EventArgs e)
        {
            this.Text = "Выполнение SQL команды. Сервер:" + server;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(makeSQLCommandString(SQLCommandRichTextBox.Text, 1, 10000));
        }
 
    }
}
