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
    public partial class MainForm : Form
    {
        private void ButtonsOff()
        {
            calcNumButton.Enabled = false;
            deleteButton.Enabled = false;
            forgetButton.Enabled = false;
            makeScriptButton.Enabled = false;
            makeScriptFileButton.Enabled = false;
            updateSMSButton.Enabled = false;
        }
        private void ButtonsOn()
        {
            calcNumButton.Enabled = true;
            deleteButton.Enabled = true;
            forgetButton.Enabled = true;
            makeScriptButton.Enabled = true;
            makeScriptFileButton.Enabled = true;
            updateSMSButton.Enabled = true;
        }
        private string GetPost()
        {
            DateTime now = DateTime.Now;
            string day = "";
            string month = "";
            if (now.Day < 10) day = "0" + now.Day; else day = now.Day.ToString();
            if (now.Month < 10) month = "0" + now.Month; else month = now.Month.ToString();
            try
            {
                return now.Year + "-" + month + "-" + day + " XXX";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void calcNumButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            Application.DoEvents();
            if (serverTextBox.Text == "")
            {
                MessageBox.Show("Введите псевдоним сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (schemaTextBox.Text == "")
                {
                    MessageBox.Show("Введите название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (passwordTextBox.Text == "")
                    {
                        MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        OracleConnection connection = new OracleConnection(@"Data Source=" + serverTextBox.Text + "; User ID=sysdba; password=" +  passwordTextBox.Text +";");
                        string str = @"";
                        try
                        {
                            connection.Open();
                            string cmd = @"select max(s_inckey) from " + schemaTextBox.Text + ".spr_speech_table";
                            OracleCommand command = new OracleCommand(cmd, connection);
                            OracleDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                str = reader[0].ToString();
                                inckeyTextBox.Text = str;
                            }
                            if (inckeyTextBox.Text == "") inckeyTextBox.Text = "0";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    
                }

            }
            ButtonsOn();
            Application.DoEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            postTextBox.Text = GetPost();
        }
        private void makeScriptButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            Application.DoEvents();
            if (serverTextBox.Text == "")
            {
                MessageBox.Show("Введите псевдоним сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (schemaTextBox.Text == "")
                {
                    MessageBox.Show("Введите название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OracleConnection connection = new OracleConnection(@"Data Source=" + serverTextBox.Text + "; User ID=sysdba; password=" + passwordTextBox.Text + ";");
                    string str = @"";
                    OracleTransaction transaction;
                    try
                    {
                        infoAboutProcessRichTextBox.Text += @"Производится обработка базы." + "\n";
                        Application.DoEvents();
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        try
                        {
                            string cmd1 = @"update " + schemaTextBox.Text + ".spr_speech_table " +
                                          @"set
                                        S_TALKER_SN =  S_SYSNUMBER,
                                        S_SYSNUMBER = '',
                                        S_TALKER =  S_TALKERNAME,
                                        S_TALKERNAME =  S_DEVICEID
                                        where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKERNAME is not null) and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "')";
                            OracleCommand command = new OracleCommand(cmd1, connection);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            infoAboutProcessRichTextBox.Text += @"Выражение № 1 выполнено." + "\n";
                            Application.DoEvents();
                            string cmd2 = @"update " + schemaTextBox.Text + ".spr_speech_table " +
                                         @"set
                                        S_TALKER =  CONCAT('380', S_TALKER)
                                        where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKER like '_________') and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "')";
                            command.CommandText = cmd2;
                            command.ExecuteNonQuery();
                            infoAboutProcessRichTextBox.Text += @"Выражение № 2 выполнено." + "\n";
                            Application.DoEvents();
                            string cmd3 = @"update " + schemaTextBox.Text + ".spr_speech_table " +
                                        @"set
                                            S_TALKER = S_USERNUMBER,
                                            S_USERNUMBER = '',
                                            S_CALLTYPE = 0
                                        where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKER is null) and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "')";
                            command.CommandText = cmd3;
                            command.ExecuteNonQuery();
                            infoAboutProcessRichTextBox.Text += @"Выражение № 3 выполнено." + "\n";
                            Application.DoEvents();
                            string cmd4 = @"update " + schemaTextBox.Text + ".spr_speech_table " +
                                        @"set
                                            S_USERNUMBER = concat('380',substr(s_deviceid, 1,length(s_deviceid)-1))                                            
                                        where   (s_inckey > " + inckeyTextBox.Text + ") and (S_SOURCENAME = 'billing') and (s_usernumber is null) and (S_CALLTYPE = 0) and (S_POSTID = '" + postTextBox.Text + "')";
                            command.CommandText = cmd4;
                            command.ExecuteNonQuery();
                            infoAboutProcessRichTextBox.Text += @"Выражение № 4 выполнено." + "\n";
                            Application.DoEvents();
                            transaction.Commit();
                            infoAboutProcessRichTextBox.Text += @"Изменение базы успешно произведено." + "\n";
                        }
                        catch (Exception ex)
                        { 
                            transaction.Rollback();
                            MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            ButtonsOn();
            Application.DoEvents();
        }

        private void forgetButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            Application.DoEvents();
            if (serverTextBox.Text == "")
            {
                MessageBox.Show("Введите псевдоним сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (schemaTextBox.Text == "")
                {
                    MessageBox.Show("Введите название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OracleConnection connection = new OracleConnection(@"Data Source=" + serverTextBox.Text + "; User ID=sysdba; password=" + passwordTextBox.Text + ";");
                    string str = @"";
                    infoAboutProcessRichTextBox.Text += "Производится поиск ключа... \n";
                    Application.DoEvents();
                    try
                    {
                        connection.Open();
                        string cmd = @"select max(s_inckey) from " + schemaTextBox.Text + ".spr_speech_table where s_postID != '" + postTextBox.Text +"'";
                        OracleCommand command = new OracleCommand(cmd, connection);
                        OracleDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            str = reader[0].ToString();
                            inckeyTextBox.Text = str;
                        }
                        infoAboutProcessRichTextBox.Text += "Успешно. \n";
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        infoAboutProcessRichTextBox.Text += "Ошибка. \n";
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            ButtonsOn();
            Application.DoEvents();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            long minPK =0, maxPK = 0;
            string str;
            OracleConnection connection = new OracleConnection(@"Data Source=" + serverTextBox.Text + "; User ID=sysdba; password=" + passwordTextBox.Text + ";");
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
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

                    string cmd = @"select max(s_inckey) from " + schemaTextBox.Text + ".spr_speech_table";
                    OracleCommand command1 = new OracleCommand(cmd, connection);
                    command1.Transaction = transaction;
                    OracleDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        maxPK = Convert.ToInt32(reader[0]);                     
                    }
                    transaction.Commit();
                    transaction = connection.BeginTransaction();
                }
                string question = "Вы действительно хотите удалить с сервера " + serverTextBox.Text + " из схемы " + serverTextBox.Text + " записи с " + minPK + " по " + maxPK + "?";
                long currentStartIndex = minPK + 1;
                if (MessageBox.Show(question, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    infoAboutProcessRichTextBox.Text += @"Производится удаление записей из базы." + "\n";
                    long currentFinishIndex = 0;
                  
                    while (currentStartIndex <= maxPK)
                    {
                       // str = @"delete from " + schemaTextBox.Text + ".spr_speech_table ";
                        
                        if ((currentStartIndex + 9999) < maxPK)
                        {
                            currentFinishIndex = currentStartIndex + 9999;
                        }
                        else
                        {
                            currentFinishIndex = maxPK;
                        }
                        infoAboutProcessRichTextBox.Text += @"Удаление записей с " + currentStartIndex + " по " + currentFinishIndex + "... ";
                        str = @"delete from " + schemaTextBox.Text + ".spr_speech_table ";
                        str = str + " where s_inckey between " + currentStartIndex + " AND " + currentFinishIndex;
                       
                        OracleCommand command = new OracleCommand(str, connection);
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        infoAboutProcessRichTextBox.Text += "Успешно. \n";                     
                        currentStartIndex += 10000;
                        transaction = connection.BeginTransaction();
                    }
                    transaction.Rollback();
                    MessageBox.Show("Удаление успешно завершено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    infoAboutProcessRichTextBox.Text += "Удаление успешно завершено. \n";
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
            }
        }

        private void makeScriptFileButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ButtonsOff();
                StreamWriter file = new StreamWriter(saveFileDialog.FileName, false);
                try
                {
                    infoAboutProcessRichTextBox.Text += @"Производится генерация скрипта." + "\n";
                    Application.DoEvents();
                    file.WriteLine(@"update " + schemaTextBox.Text + ".spr_speech_table ");
                    file.WriteLine("set");
                    file.WriteLine("S_TALKER_SN =  S_SYSNUMBER,");
                    file.WriteLine("S_SYSNUMBER = '',");
                    file.WriteLine("S_TALKER =  S_TALKERNAME,");
                    file.WriteLine("S_TALKERNAME =  S_DEVICEID ");
                    file.WriteLine("where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKERNAME is not null) and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "');");
                    file.WriteLine();
                    file.WriteLine("update " + schemaTextBox.Text + ".spr_speech_table ");
                    file.WriteLine("set ");
                    file.WriteLine("S_TALKER =  CONCAT('380', S_TALKER) ");
                    file.WriteLine("where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKER like '_________') and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "');");
                    file.WriteLine();
                    file.WriteLine("update " + schemaTextBox.Text + ".spr_speech_table ");
                    file.WriteLine("set ");
                    file.WriteLine("S_TALKER = S_USERNUMBER, ");
                    file.WriteLine("S_USERNUMBER = '',");
                    file.WriteLine("S_CALLTYPE = 0 ");
                    file.WriteLine("where   (s_inckey > " + inckeyTextBox.Text + ") and (S_TALKER is null) and (S_SOURCENAME = 'billing') and (S_POSTID = '" + postTextBox.Text + "');");
                    file.WriteLine();
                    file.WriteLine("update " + schemaTextBox.Text + ".spr_speech_table ");
                    file.WriteLine("set ");
                    file.WriteLine("S_USERNUMBER = concat('380',substr(s_deviceid, 1,length(s_deviceid)-1)) ");
                    file.WriteLine(" where   (s_inckey > " + inckeyTextBox.Text + ") and (S_SOURCENAME = 'billing') and (s_usernumber is null) and (S_CALLTYPE = 0) and (S_POSTID = '" + postTextBox.Text + "')");
                    file.WriteLine();
                    MessageBox.Show("Скрипт успешно сгенерирован", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    infoAboutProcessRichTextBox.Text += @"Скрипт сгенерирован успешно." + "\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    infoAboutProcessRichTextBox.Text += "Ошибка при генериции скрипта. \n";
                }
                finally
                {
                    file.Close();
                    ButtonsOn();
                }

            }
        }

        private void updateSMSButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            Application.DoEvents();
            if (serverTextBox.Text == "")
            {
                MessageBox.Show("Введите псевдоним сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (schemaTextBox.Text == "")
                {
                    MessageBox.Show("Введите название схемы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OracleConnection connection = new OracleConnection(@"Data Source=" + serverTextBox.Text + "; User ID=sysdba; password=masterkey;");
                    //string str = @"";
                    OracleTransaction transaction;
                    try
                    {
                        infoAboutProcessRichTextBox.Text += @"Производится исправление номеров собеседников из sms." + "\n";
                        Application.DoEvents();
                        connection.Open();
                        transaction = connection.BeginTransaction();
                        try
                        {
                            string cmd1 = @"update " + schemaTextBox.Text + ".spr_speech_table " +
                                          @"set
                                            s_talker = substr(s_talker, 2, length(s_talker) - 1)
                                            where (s_inckey >= " + inckeyTextBox.Text + ") and (S_POSTID = '" + postTextBox.Text + "') and (s_talker like '+%')";
                            OracleCommand command = new OracleCommand(cmd1, connection);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            infoAboutProcessRichTextBox.Text += @"Исправление номеров собеседников из sms выполнено." + "\n";
                            Application.DoEvents();
                            transaction.Commit();
                            infoAboutProcessRichTextBox.Text += @"Изменение базы успешно произведено." + "\n";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            ButtonsOn();
            Application.DoEvents();
        }

        private void inckeyTextBox_DoubleClick(object sender, EventArgs e)
        {
            inckeyTextBox.Enabled = false;
        }

        private void tableLayoutPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Location.X >= inckeyTextBox.Location.X) & (e.Location.X <= (inckeyTextBox.Location.X + inckeyTextBox.Width)) & (e.Location.Y >= inckeyTextBox.Location.Y) & (e.Location.Y <= (inckeyTextBox.Location.Y + inckeyTextBox.Height)))
            {
                inckeyTextBox.Enabled = true;
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
    }
}
