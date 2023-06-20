using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Drawing;
//using lcpi.data.oledb; 
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SprutUpdate
{
    
    public partial class mainForm : Form
    {
        const string IBProvider = @"Provider=LCPI.IBProvider.5.Free; ";
        long lastInckeySetupDown;
        long lastInckeySourceUpdate;
        DateTime benchmarkDate;
        private void InkeyVerification()
        {
            try
            {
                if (oracleRadioButton.Checked)
                {

                    if (lastInckeySetupDown == Convert.ToInt64(lastInckeySetupDownTextBox.Text))
                    {
                        if ((Properties.Settings.Default.SUBD == "Oracle") && (Properties.Settings.Default.OracleServer == oracleServerTextBox.Text) && (Properties.Settings.Default.OracleSchema == oracleSchemaTextBox.Text))
                        {
                        }
                        else
                        {
                            lastInckeySetupDown = 0;
                            lastInckeySetupDownTextBox.Text = Convert.ToString(0);
                        }
                    }
                    else
                    {
                        lastInckeySetupDown = Convert.ToInt64(lastInckeySetupDownTextBox.Text);
                    }

                    // Source
                    if (lastInckeySourceUpdate == Convert.ToInt64(lastInckeySourceTextBox.Text))
                    {
                        if ((Properties.Settings.Default.SUBD == "Oracle") && (Properties.Settings.Default.OracleServer == oracleServerTextBox.Text) && (Properties.Settings.Default.OracleSchema == oracleSchemaTextBox.Text))
                        {
                        }
                        else
                        {
                            lastInckeySourceUpdate = 0;
                            lastInckeySourceTextBox.Text = Convert.ToString(0);
                        }
                    }
                    else
                    {
                        lastInckeySourceUpdate = Convert.ToInt64(lastInckeySourceTextBox.Text);
                    }
                }
                else
                {
                    if (lastInckeySetupDown == Convert.ToInt64(lastInckeySetupDownTextBox.Text))
                    {
                        if ((Properties.Settings.Default.SUBD == "Interbase") && (Properties.Settings.Default.InterbaseServer == interbaseServerTextBox.Text) && (Properties.Settings.Default.InterbasePath == interbasePathTextBox.Text))
                        {
                        }
                        else
                        {
                            lastInckeySetupDown = 0;
                            lastInckeySetupDownTextBox.Text = Convert.ToString(0);
                        }
                    }
                    else
                    {
                        lastInckeySetupDown = Convert.ToInt64(lastInckeySetupDownTextBox.Text);
                    }
                    // Source
                    if (lastInckeySourceUpdate == Convert.ToInt64(lastInckeySourceTextBox.Text))
                    {
                        if ((Properties.Settings.Default.SUBD == "Interbase") && (Properties.Settings.Default.InterbaseServer == interbaseServerTextBox.Text) && (Properties.Settings.Default.InterbasePath == interbasePathTextBox.Text))
                        {
                        }
                        else
                        {
                            lastInckeySourceUpdate = 0;
                            lastInckeySourceTextBox.Text = Convert.ToString(0);
                        }
                    }
                    else
                    {
                        lastInckeySourceUpdate = Convert.ToInt64(lastInckeySourceTextBox.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
        private void OracleEnabled (bool enabled)
        {
            oracleServerLabel.Enabled = enabled;
            oracleServerTextBox.Enabled = enabled;
            oracleSchemaLabel.Enabled = enabled;
            oracleSchemaTextBox.Enabled = enabled;
            return;

        }
        private void InterbaseEnabled(bool enabled)
        {
            interbaseServerLabel.Enabled = enabled;
            interbaseServerTextBox.Enabled = enabled;
            interbasePathLabel.Enabled = enabled;
            interbasePathTextBox.Enabled = enabled;
            interbaseChangeFileButton.Enabled = enabled;
            return;

        }
        private void SourceEnabled (bool enabled)
        {
            sourceServerLabel.Enabled = enabled;
            sourceServerTextBox.Enabled = enabled;
            sourcePathLabel.Enabled = enabled;
            sourcePathTextBox.Enabled = enabled;
            sourceChangeFileButton.Enabled = enabled;
            return;
        }

        private void InckeyEnabled(bool enabled)
        {
            lastInckeySourceLabel.Enabled = enabled;
            lastInckeySetupDownLabel.Enabled = enabled;
          
            return;
        }
        private void MakeUpdate (bool auto)
        {
            InkeyVerification();
            string conStr = @"";
            bool oracle = oracleRadioButton.Checked;
            if (oracle)
            {
                conStr = @"Data Source=" + oracleServerTextBox.Text + ";" +
                          "user id=" + userTextBox.Text + ";" +
                          "password=" + passwordTextBox.Text + ";";
            }
            else
            {
                conStr = IBProvider +
                          "location=" + interbaseServerTextBox.Text + ":" + interbasePathTextBox.Text + ";" +
                          "user id=" + userTextBox.Text + ";" +
                          "password=" + passwordTextBox.Text + ";" +
                          "ctype=win1251";
            }
            int result = 0;
            if (auto)
            {
                if (oracle)
                {
                    if (lastInckeyCheckBox.Checked)
                    {
                        
                        result = UpdateOracleFromSetupDown(conStr, lastInckeySetupDown);
                    }
                    else
                    {
                        result = UpdateOracleFromSetupDown(conStr, true);
                    }
                    
                }
                else
                {
                    if (lastInckeyCheckBox.Checked)
                    {

                        result = UpdateInterbaseFromSetupDown(conStr, lastInckeySetupDown);
                    }
                    else
                    {
                        result = UpdateInterbaseFromSetupDown(conStr, true);
                    }
                    
                }
                if (result == 0)
                {

                    taskStatusLabel.Text = "Обработка произведена";
                    Application.DoEvents();
                }
                if (oracle)
                {
                    if (updateNumbersCheckBox.Checked)
                    {
                        result = UpdateOracleNumbers(conStr, true);
                        if (result == 0)
                        {

                            taskStatusLabel.Text = "Исправление пользовательских номеров абонента и собеседника произведено.";
                            Application.DoEvents();
                        }
                    }
                }
                if (sourceCheckBox.Checked)
                {


                    if (oracle)
                    {
                        if (lastInckeyCheckBox.Checked)
                        {
                            result = UpdateOracleObjectName(conStr, true, lastInckeySourceUpdate);
                        }
                        else
                        {
                            result = UpdateOracleObjectName(conStr, true);
                        }
                    }
                    else
                    {
                        if (lastInckeyCheckBox.Checked)
                        {
                            result = UpdateInterbaseObjectName(conStr, true, lastInckeySourceUpdate);
                        }
                        else
                        {
                            result = UpdateInterbaseObjectName(conStr, true);
                        }

                    }                 
                    if (result == 0)
                    {
                        taskStatusLabel.Text = "Имена объектов занесены.";

                    }
                    else
                    {
                        taskStatusLabel.Text = "Имена занесены с ошибкой.";
                    }
                }
            }
            else
            {
                if (lastInckeyCheckBox.Checked)
                {
                    if (oracle)
                    {
                        result = UpdateOracleFromSetupDown(conStr, lastInckeySetupDown);
                    }
                    else
                    {
                        result = UpdateInterbaseFromSetupDown(conStr, lastInckeySetupDown);
                    }
                }
                else
                {
                    if (oracle)
                    {
                        result = UpdateOracleFromSetupDown(conStr);
                    }
                    else
                    {
                        result = UpdateInterbaseFromSetupDown(conStr);
                    }

                }
                if (result == 0)
                {

                    taskStatusLabel.Text = "Обработка произведена";
                    Application.DoEvents();
                }
                if (updateNumbersCheckBox.Checked)
                {
                    if (oracle)
                    {
                        if (lastInckeyCheckBox.Checked)
                        {
                            result = UpdateOracleNumbers(conStr, lastInckeySetupDown - 100000);
                        }
                        else
                        {
                            result = UpdateOracleNumbers(conStr);
                        }
                        if (result == 0)
                        {

                            taskStatusLabel.Text = "Исправление пользовательских номеров абонента и собеседника произведено.";
                            Application.DoEvents();
                        }
                    }
                }
                if (sourceCheckBox.Checked)
                {
                    if (lastInckeyCheckBox.Checked)
                    {
                        if (oracle)
                        {
                            result = UpdateOracleObjectName(conStr, lastInckeySourceUpdate);
                        }
                        else
                        {
                            result = UpdateInterbaseObjectName(conStr, lastInckeySourceUpdate); 
                        }
                    }
                    else
                    {
                        if (oracle)
                        {
                            result = UpdateOracleObjectName(conStr);
                        }
                        else
                        {
                            result = UpdateInterbaseObjectName(conStr);
                        }
                    }
                    if (result == 0)
                    {

                        taskStatusLabel.Text = "Исправление пользовательских номеров абонента и собеседника произведено.";
                        Application.DoEvents();
                    }
                }
            }
            return;
        }
        private void ElementsEnabled(bool enabled)
        {
            oracleRadioButton.Enabled = enabled;
            interbaseRadioButton.Enabled = enabled;
            sourceCheckBox.Enabled = enabled;
            userLabel.Enabled = enabled;
            userTextBox.Enabled = enabled;
            passwordLabel.Enabled = enabled;
            passwordTextBox.Enabled = enabled;
            lastInckeyCheckBox.Enabled = enabled;
            if (oracleRadioButton.Checked)
            {
                updateNumbersCheckBox.Enabled = enabled;
            }
            else
            {
                updateNumbersCheckBox.Enabled = false;
            }
            saveSettingsButton.Enabled = enabled;
            saveSettingsButton2.Enabled = enabled;
            freqComboBox.Enabled = enabled;
            freqLabel.Enabled = enabled;
            intervalLabel.Enabled = enabled;
            intervalNumericUpDown.Enabled = enabled;
            return;
        }
        public void EnabledOff()
        {
            OracleEnabled(false);
            InterbaseEnabled(false);
            SourceEnabled(false);
            ElementsEnabled(false);
            InckeyEnabled(false);
        }
        public void EnabledOn()
        {
            OracleEnabled(oracleRadioButton.Checked);
            InterbaseEnabled(interbaseRadioButton.Checked);
            SourceEnabled(sourceCheckBox.Checked);
            InckeyEnabled(lastInckeyCheckBox.Enabled);
            ElementsEnabled(true);
        }

        public mainForm()
        {
            InitializeComponent();
            oracleRadioButton.Checked = Properties.Settings.Default.Oracle;
            oracleServerTextBox.Text = Properties.Settings.Default.OracleServer;
            oracleSchemaTextBox.Text = Properties.Settings.Default.OracleSchema;

            interbaseRadioButton.Checked = Properties.Settings.Default.Interbase;
            interbaseServerTextBox.Text = Properties.Settings.Default.InterbaseServer;
            interbasePathTextBox.Text = Properties.Settings.Default.InterbasePath;

            sourceCheckBox.Checked = Properties.Settings.Default.SourceBase;
            sourceServerTextBox.Text = Properties.Settings.Default.SourceServer;
            sourcePathTextBox.Text = Properties.Settings.Default.SourcePath;

            lastInckeyCheckBox.Checked = Properties.Settings.Default.InckeyOn;
            lastInckeySetupDown = Properties.Settings.Default.lastInckeySetupDown;
            lastInckeySetupDownTextBox.Text = lastInckeySetupDown.ToString();
            lastInckeySourceUpdate = Properties.Settings.Default.LastInckeySourceUpdate;
            lastInckeySourceTextBox.Text = lastInckeySourceUpdate.ToString();

            updateNumbersCheckBox.Checked = Properties.Settings.Default.AbnNum;


            benchmarkDate = DateTime.Now.AddDays(Properties.Settings.Default.BufferDays);

        }

        private string[] NumbersFromSetupDown(object blob)
        {
            string[] numbers = new string[2];
            string buffer = Encoding.ASCII.GetString((byte[])blob);
            string blobText = buffer.Replace(Convert.ToChar(0).ToString(), "");
            int index = -1;
            string abnnum = @"";
            string tlcnum = @"";
            index = blobText.IndexOf("Number=");
            if (index >= 0)
            {
                int length = blobText.IndexOf(",", index) - (index + 7);
                if (length > 0)
                {
                    tlcnum = blobText.Substring(index + 7, length);
                }
                else
                {
                    tlcnum = blobText.Substring(index + 7);
                }
                buffer = blobText.Substring(index + 7);
                index = buffer.IndexOf("Number=");
                if (index >= 0)
                {
                    length = buffer.IndexOf(",", index) - (index + 7);
                    if (length > 0)
                    {
                        abnnum = buffer.Substring(index + 7, length);
                    }
                    else
                    {
                        abnnum = buffer.Substring(index + 7);
                    }
                }
            }
            numbers[0] = abnnum;
            numbers[1] = tlcnum;
            return numbers;
        }
        

        
        #region Oracle
        private string OracleDateTerm(DateTime date)
        {
            return " and (s_datetime > to_date('" + date.ToShortDateString() + " " + date.ToLongTimeString() + "', 'DD.MM.YYYY HH24:MI:ss'))";
        }
        private int UpdateOracleByTMSI(string conStr, string TMSI, string abnnum, bool interval)
        {

            string dateInterval = @""; 
            if (interval)
            {
                dateInterval = OracleDateTerm(benchmarkDate);
            }
            OracleConnection connection = new OracleConnection(conStr);
            string strUpdCmd = @"update " + oracleSchemaTextBox.Text + @".spr_speech_table
                                 set s_usernumber = '" + abnnum + "'" +
                                " where s_sysnumber2 = '" + TMSI + "'" + dateInterval;

            try
            {
                connection.Open();
                OracleTransaction updateTransaction = connection.BeginTransaction();
                try
                {
                    OracleCommand command = new OracleCommand(strUpdCmd, connection, updateTransaction);
                    command.ExecuteNonQuery();
                    updateTransaction.Commit();
                    connection.Close();
                    return 0;

                }
                catch (Exception error)
                {
                    updateTransaction.Rollback();
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return -2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return -1;
            }
        }

        private int UpdateOracleFromSetupDown(string conStr, bool interval, long s_inckey)
        {
            taskStatusLabel.Text = "Производится поиск служебной информации...";
            Application.DoEvents();
            OracleConnection oraConnection = new OracleConnection(conStr);
            try
            {
                string inckey = " AND (spr_speech_table.s_inckey > " + s_inckey + ")";
                string dateInterval = @"";
                if (interval)
                {
                    dateInterval = OracleDateTerm(benchmarkDate);
                }
                oraConnection.Open();
                string strCmd = @"";
                strCmd = @"select  count(*)
                            from   " + oracleSchemaTextBox.Text + @".spr_speech_table join  " + oracleSchemaTextBox.Text + @".SPR_SP_DATA_1_TABLE on (SPR_SPEECH_TABLE.S_INCKEY= SPR_SP_DATA_1_TABLE.S_INCKEY)
                            where  (s_sysnumber2 is not null) and (s_recordtype = 'Setup Down') and (S_FSPEECH is not null) " + dateInterval + inckey;
                OracleCommand command = new OracleCommand(strCmd, oraConnection);
                OracleDataReader reader = command.ExecuteReader();
                int countSetupDown = 0;
                while (reader.Read())
                {
                    countSetupDown = Convert.ToInt32(reader[0]); ;
                    break;
                }
                reader.Close();

                taskStatusLabel.Visible = true;
                if (countSetupDown == 0)
                {
                    taskStatusLabel.Text = "Служебная информация не найдена.";
                    oraConnection.Close();
                    return 0;
                }
                else
                {
                    taskProgressBar.Value = 0;
                    taskProgressBar.Maximum = countSetupDown;
                }
                Application.DoEvents();
                strCmd = @"select  
                            spr_speech_table.s_inckey,
                            s_sysnumber2,
                            S_FSPEECH  " +
                            "from   " + oracleSchemaTextBox.Text + @".spr_speech_table join  " + oracleSchemaTextBox.Text + @".SPR_SP_DATA_1_TABLE on (SPR_SPEECH_TABLE.S_INCKEY= SPR_SP_DATA_1_TABLE.S_INCKEY) 
                            where  (s_sysnumber2 is not null) and (s_recordtype = 'Setup Down') and (S_FSPEECH is not null) " + dateInterval + inckey;
                command.CommandText = strCmd;
                reader = command.ExecuteReader();
                string TMSI = @"";
                string[] numbers = new string[2];
                int currentID = 1;
                while (reader.Read())
                {   
                    /*
                    if (currentID == 37)
                    {
                        MessageBox.Show(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                    }
                    */
                    numbers = NumbersFromSetupDown(reader[2]);
                    TMSI = reader[1].ToString();
                    UpdateOracleByTMSI(conStr, TMSI, numbers[0], interval);
                    taskStatusLabel.Text = "Обработано:" + currentID + "/" + countSetupDown;
                    if (currentID <= taskProgressBar.Maximum)
                    {
                        taskProgressBar.Value = currentID;
                    }
                    currentID++;
                    lastInckeySetupDown = Convert.ToInt64(reader[0]);
                    Application.DoEvents();
                }
                reader.Close();
                oraConnection.Close();
                Properties.Settings.Default.lastInckeySetupDown = lastInckeySetupDown;
                Properties.Settings.Default.OracleServer = oracleServerTextBox.Text;
                Properties.Settings.Default.OracleSchema = oracleSchemaTextBox.Text;
                Properties.Settings.Default.SUBD = "Oracle";
                Properties.Settings.Default.Save();
                lastInckeySetupDownTextBox.Text = lastInckeySetupDown.ToString();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oraConnection.Close();
                return -1;
            }
        }
        private int UpdateOracleFromSetupDown(string conStr, bool interval)
        {
            return UpdateOracleFromSetupDown(conStr, interval, 0);
        }
        private int UpdateOracleFromSetupDown(string conStr, long s_inckey)
        {
            return UpdateOracleFromSetupDown(conStr, false, s_inckey);
        }
        private int UpdateOracleFromSetupDown(string conStr)
        {
            return UpdateOracleFromSetupDown(conStr, false, 0);
        }

        private int UpdateOracleNumbers(string conStr, bool interval, long s_inckey)
        {
            OracleConnection connection = new OracleConnection(conStr);
            string dateInterval = @"";
            if (interval)
            {
                dateInterval = OracleDateTerm(benchmarkDate);
            }
            string inckey = @" and (s_inckey > " + s_inckey + ")";
            string strUpdCmd = @"update " + oracleSchemaTextBox.Text + @".spr_speech_table
                                                    set s_talker = case
                                                                   when regexp_like (s_talker, '^[0-9]{9}$') then CONCAT('996', S_TALKER)
                                                                   when regexp_like (s_talker, '^0[0-9]{9}$') then concat('996',substr(s_talker, 2,length(s_talker)-1)) 
                                                                   when regexp_like (s_talker, '^[+][0-9]{9}$') then concat('996',substr(s_talker, 2,length(s_talker)-1))
                                                                   when s_talker like '+%' then substr(s_talker, 2,length(s_talker)-1)
                                                                   when s_talker like '00%' then substr(s_talker, 3,length(s_talker)-2)
                                                                   else s_talker
                                                                   end,
                                                        s_usernumber = case
                                                                       when regexp_like (s_usernumber, '^[0-9]{9}$') then CONCAT('996', s_usernumber)
                                                                       when regexp_like (s_usernumber, '^0[0-9]{9}$') then concat('996',substr(s_usernumber, 2,length(s_usernumber)-1)) 
                                                                       when regexp_like (s_usernumber, '^[+][0-9]{9}$') then concat('996',substr(s_usernumber, 2,length(s_usernumber)-1))
                                                                       when s_usernumber like '+%' then substr(s_usernumber, 2,length(s_usernumber)-1)
                                                                       when s_usernumber like '00%' then substr(s_usernumber, 3,length(s_usernumber)-2)
                                                                       else s_usernumber
                                                                       end
                                                    where ((s_talker is not null) or (s_talker <> '') or (s_talker not like '00_') or (s_usernumber is not null) or (s_usernumber <> '') or (s_usernumber not like '00_')) " + inckey + dateInterval;
            try
            {
                connection.Open();
                OracleTransaction updateTransaction = connection.BeginTransaction();
                try
                {
                    taskStatusLabel.Text = "Производится исправление пользовательских номеров абонента и собеседника";
                    OracleCommand command = new OracleCommand(strUpdCmd, connection, updateTransaction);
                    command.ExecuteNonQuery();
                    updateTransaction.Commit();
                    connection.Close();
                    
                    return 0;

                }
                catch (Exception error)
                {
                    updateTransaction.Rollback();
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return -2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return -1;
            }
        }

        private int UpdateOracleNumbers(string conStr, long s_inckey)
        {
            return UpdateOracleNumbers(conStr, false, s_inckey);
        }
        private int UpdateOracleNumbers(string conStr)
        {
            return UpdateOracleNumbers(conStr, false, 0);
        }
        private int UpdateOracleNumbers(string conStr, bool interval)
        {
            return UpdateOracleNumbers(conStr, interval, 0);
        }
        private int UpdateOracleObjectNameByInckey(string conStr, long s_inckey, string[] names)
        {

            OracleConnection connection = new OracleConnection(conStr);
            string strUpdCmd = @"update " + oracleSchemaTextBox.Text + @".spr_speech_table
                                 set s_sourcename = '" + names[0] + "', " +
                                 "s_talkername = '" + names[1] + "' " +
                                " where s_inckey = " + s_inckey;

            try
            {
                connection.Open();
                OracleTransaction updateTransaction = connection.BeginTransaction();
                try
                {
                    OracleCommand command = new OracleCommand(strUpdCmd, connection, updateTransaction);
                    command.ExecuteNonQuery();
                    updateTransaction.Commit();
                    connection.Close();
                    return 0;

                }
                catch (Exception error)
                {
                    updateTransaction.Rollback();
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return -2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return -1;
            }
        }
        private int UpdateOracleObjectName(string conStr, bool interval, long s_inckey)
        {
            taskStatusLabel.Text = "Производится поиск на соответствие с номерами объектов...";
            Application.DoEvents();
            OracleConnection oraConnection = new OracleConnection(conStr);
            try
            {
                string inckey = " AND (s_inckey > " + s_inckey + ")";
                string dateInterval = @"";
                if (interval)
                {
                    dateInterval = OracleDateTerm(benchmarkDate);
                }
                oraConnection.Open();
                string strCmd = @"";
                strCmd = @"select  count(*)
                            from   " + oracleSchemaTextBox.Text + @".spr_speech_table " +
                            "where (((s_talker is not null) and (regexp_like (s_talker, '^[0-9]{9,}$')) and (s_talkername is null)) or ((s_usernumber is not null) and (regexp_like (s_usernumber, '^[0-9]{9,}$')) and (s_sourcename is null)))" + dateInterval + inckey;
                OracleCommand command = new OracleCommand(strCmd, oraConnection);
                OracleDataReader reader = command.ExecuteReader();
                int countRowNumbers = 0;
                while (reader.Read())
                {
                    countRowNumbers = Convert.ToInt32(reader[0]); ;
                    break;
                }
                reader.Close();

                taskStatusLabel.Visible = true;
                if (countRowNumbers == 0)
                {
                    taskStatusLabel.Text = "Информация о номерах не найдена.";
                    oraConnection.Close();
                    return 0;
                }
                else
                {
                    taskProgressBar.Value = 0;
                    taskProgressBar.Maximum = countRowNumbers;
                }
                Application.DoEvents();
                strCmd = @"select  s_inckey, s_usernumber, s_talker  " +
                            "from   " + oracleSchemaTextBox.Text + @".spr_speech_table " +
                            "where (((s_talker is not null) and (regexp_like (s_talker, '^[0-9]{9,}$')) and (s_talkername is null)) or ((s_usernumber is not null) and (regexp_like (s_usernumber, '^[0-9]{9,}$')) and (s_sourcename is null)))" + dateInterval + inckey;
                command.CommandText = strCmd;
                reader = command.ExecuteReader();
                string[] names = new string[2];
                int currentID = 1;
                while (reader.Read())
                {
                    names[0] = GetObjectName(reader[1].ToString());
                    names[1] = GetObjectName(reader[2].ToString());
                    if ((names[0] != "") || (names[1] != "")) 
                    {
                        UpdateOracleObjectNameByInckey(conStr, Convert.ToInt64(reader[0]), names);
                    }
                    taskStatusLabel.Text = "Обработано:" + currentID + "/" + countRowNumbers;
                    if (currentID <= taskProgressBar.Maximum)
                    {
                        taskProgressBar.Value = currentID;
                    }
                    currentID++;
                    lastInckeySourceUpdate = Convert.ToInt64(reader[0]);
                    Application.DoEvents();
                }
                reader.Close();
                oraConnection.Close();
                Properties.Settings.Default.LastInckeySourceUpdate = lastInckeySourceUpdate;
                Properties.Settings.Default.OracleServer = oracleServerTextBox.Text;
                Properties.Settings.Default.OracleSchema = oracleSchemaTextBox.Text;
                Properties.Settings.Default.SUBD = "Oracle";
                Properties.Settings.Default.Save();
                lastInckeySourceTextBox.Text = lastInckeySourceUpdate.ToString();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oraConnection.Close();
                return -1;
            }
        }
        
        private int UpdateOracleObjectName(string conStr, bool interval)
        {
            return UpdateOracleObjectName(conStr, interval, 0);
        }
        private int UpdateOracleObjectName(string conStr,  long s_inckey)
        {
            return UpdateOracleObjectName(conStr, false, s_inckey);
        }

        private int UpdateOracleObjectName(string conStr)
        {
            return UpdateOracleObjectName(conStr, false, 0);
        }
        
        
        #endregion

        
        #region Interbase
        private string InterbaseDateTerm(DateTime date)
        {
            return " and (s_datetime > '" + date.ToShortDateString() + " " + date.ToLongTimeString() + "')";
        }
        private int UpdateInterbaseByTMSI(string conStr, string TMSI, string abnnum, bool interval)
        {
            OleDbConnection connection = new OleDbConnection(conStr);
            string dateInterval = @"";
            if (interval)
            {
                dateInterval = InterbaseDateTerm(benchmarkDate);
            }
            string strUpdCmd = @"update spr_speech_table
                                 set s_usernumber = '" + abnnum + "'" +
                                " where s_sysnumber2 = '" + TMSI + "' " + dateInterval;
           
            try
            {
                connection.Open();
                OleDbTransaction updateTransaction = connection.BeginTransaction();
                try
                {
                    OleDbCommand command = new OleDbCommand(strUpdCmd, connection, updateTransaction);
                    command.ExecuteNonQuery();
                    updateTransaction.Commit();
                    connection.Close();
                    return 0;

                }
                catch (Exception error)
                {
                    updateTransaction.Rollback();
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return -2;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return -1;
            }            
        }

        private int UpdateInterbaseFromSetupDown(string conStr, bool interval, long s_inckey)
        {
            taskStatusLabel.Text = "Производится поиск служебной информации...";
            Application.DoEvents();
            OleDbConnection ibsConnection = new OleDbConnection(conStr);
            try
            {
                string inckey = " AND (spr_speech_table.s_inckey > " + s_inckey + ")";
                string dateInterval = @"";
                if (interval)
                {
                    dateInterval = InterbaseDateTerm(benchmarkDate);
                }
                ibsConnection.Open();
                string strCmd = @"";
                strCmd = @"select  count(*)
                            from   SPR_SPEECH_TABLE join  SPR_SP_DATA_1_TABLE on (SPR_SPEECH_TABLE.S_INCKEY= SPR_SP_DATA_1_TABLE.S_INCKEY)
                            where (s_sysnumber2 is not null) and (s_recordtype = 'Setup Down') " + dateInterval + dateInterval;
                OleDbTransaction transaction = ibsConnection.BeginTransaction();
                OleDbCommand command = new OleDbCommand(strCmd, ibsConnection, transaction);
                OleDbDataReader reader = command.ExecuteReader();
                int countSetupDown = 0;
                while (reader.Read())
                {
                    countSetupDown = Convert.ToInt32(reader[0]);
                    break;
                }
                reader.Close();
                if (countSetupDown == 0)
                {
                    taskStatusLabel.Text = "Служебная информация не найдена.";
                    ibsConnection.Close();
                    return 0;
                }
                else
                {
                    taskProgressBar.Value = 0;
                    taskProgressBar.Maximum = countSetupDown;
                }
                Application.DoEvents();
                strCmd = @"select  
                            s_inckey,
                            s_sysnumber2,
                            S_FSPEECH  from   SPR_SPEECH_TABLE join  SPR_SP_DATA_1_TABLE on (SPR_SPEECH_TABLE.S_INCKEY= SPR_SP_DATA_1_TABLE.S_INCKEY)
                            where  (s_sysnumber2 is not null) and (s_recordtype = 'Setup Down') " + dateInterval + inckey;
                            
                command.CommandText = strCmd;
                reader = command.ExecuteReader();
                string TMSI = @"";
                string[] numbers = new string[2];
                int currentID = 1;
                while (reader.Read())
                {
                    numbers = NumbersFromSetupDown(reader[2]);
                    TMSI = reader[1].ToString();
                    UpdateInterbaseByTMSI(conStr,TMSI,numbers[0], interval);
                    Application.DoEvents();
                    taskStatusLabel.Text = "Обработано:" + currentID + "/" + countSetupDown;
                    if (currentID <= taskProgressBar.Maximum)
                    {
                        taskProgressBar.Value = currentID;
                    }
                    currentID++;
                    lastInckeySetupDown = Convert.ToInt64(reader[0]);
                    Application.DoEvents();
                }
                reader.Close();
                transaction.Commit();
                ibsConnection.Close();
                Properties.Settings.Default.lastInckeySetupDown = lastInckeySetupDown;
                Properties.Settings.Default.InterbaseServer = interbaseServerTextBox.Text;
                Properties.Settings.Default.InterbasePath = interbasePathTextBox.Text;
                Properties.Settings.Default.SUBD = "Interbase";
                Properties.Settings.Default.Save();
                lastInckeySetupDownTextBox.Text = lastInckeySetupDown.ToString();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                ibsConnection.Close();
                return -1;
            }
        }
        private int UpdateInterbaseFromSetupDown(string conStr)
        {
            return UpdateInterbaseFromSetupDown(conStr, false, 0);
        }
        private int UpdateInterbaseFromSetupDown(string conStr, bool interval)
        {
            return UpdateInterbaseFromSetupDown(conStr, interval, 0);
        }
        private int UpdateInterbaseFromSetupDown(string conStr, long s_inckey)
        {
            return UpdateInterbaseFromSetupDown(conStr, false, s_inckey);
        }

        private int UpdareInterbaseNumbers(string conStr)
        {

            return -1;
        }
        private int UpdateInterbaseObjectNameByInckey(string conStr, long s_inckey, string[] names)
        {

            OleDbConnection connection = new OleDbConnection(conStr);
            string strUpdCmd = @"update spr_speech_table
                                 set s_sourcename = '" + names[0] + "', " +
                                 "s_talkername = '" + names[1] + "' " +
                                " where s_inckey = " + s_inckey;

            try
            {
                connection.Open();
                OleDbTransaction updateTransaction = connection.BeginTransaction();
                try
                {
                    OleDbCommand command = new OleDbCommand(strUpdCmd, connection, updateTransaction);
                    command.ExecuteNonQuery();
                    updateTransaction.Commit();
                    connection.Close();
                    return 0;

                }
                catch (Exception error)
                {
                    updateTransaction.Rollback();
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return -2;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return -1;
            }
        }
        private int UpdateInterbaseObjectName(string conStr, bool interval, long s_inckey)
        {
            taskStatusLabel.Text = "Производится поиск на соответствие с номерами объектов...";
            Application.DoEvents();
            OleDbConnection ibsConnection = new OleDbConnection(conStr);
            try
            {
                string inckey = " AND (s_inckey > " + s_inckey + ")";
                string dateInterval = @"";
                if (interval)
                {
                    dateInterval = InterbaseDateTerm(benchmarkDate);
                }
                ibsConnection.Open();
                OleDbTransaction selectTransaction = ibsConnection.BeginTransaction();
                string strCmd = @"";
                strCmd = @"select  count(*)
                            from  spr_speech_table " +
                            "where (((s_talker is not null) and (s_talker like '%_________')) and (s_talkername is null)) or ((s_usernumber is not null) and (regexp_like (s_usernumber like '%_________')) and (s_sourcename is null)))" + dateInterval + inckey;
                OleDbCommand command = new OleDbCommand(strCmd, ibsConnection, selectTransaction);
                OleDbDataReader reader = command.ExecuteReader();
                int countRowNumbers = 0;
                while (reader.Read())
                {
                    countRowNumbers = Convert.ToInt32(reader[0]); ;
                    break;
                }
                reader.Close();

                taskStatusLabel.Visible = true;
                if (countRowNumbers == 0)
                {
                    taskStatusLabel.Text = "Строки с пользовательскими номерами отсутствуют.";
                    ibsConnection.Close();
                    return 0;
                }
                else
                {
                    taskProgressBar.Value = 0;
                    taskProgressBar.Maximum = countRowNumbers;
                }
                Application.DoEvents();

                strCmd = @"select  s_inckey, s_usernumber, s_talker  " +
                            "from  spr_speech_table " +
                            "where (((s_talker is not null) and (s_talker like '%_________')) and (s_talkername is null)) or ((s_usernumber is not null) and (regexp_like (s_usernumber like '%_________')) and (s_sourcename is null)))" + dateInterval + inckey;
                command.CommandText = strCmd;
                reader = command.ExecuteReader();
                string[] names = new string[2];
                int currentID = 1;
                while (reader.Read())
                {
                    names[0] = GetObjectName(reader[1].ToString());
                    names[1] = GetObjectName(reader[2].ToString());
                    if ((names[0] != "") || (names[1] != ""))
                    {
                        UpdateInterbaseObjectNameByInckey(conStr, Convert.ToInt64(reader[0]), names);
                    }
                    taskStatusLabel.Text = "Обработано:" + currentID + "/" + countRowNumbers;
                    if (currentID <= taskProgressBar.Maximum)
                    {
                        taskProgressBar.Value = currentID;
                    }
                    currentID++;
                    lastInckeySourceUpdate = Convert.ToInt64(reader[0]);
                    Application.DoEvents();
                }
                reader.Close();
                selectTransaction.Commit();
                ibsConnection.Close();
                Properties.Settings.Default.LastInckeySourceUpdate = lastInckeySourceUpdate;
                Properties.Settings.Default.InterbaseServer = interbaseServerTextBox.Text;
                Properties.Settings.Default.InterbasePath = interbasePathTextBox.Text;
                Properties.Settings.Default.SUBD = "Interbase";
                Properties.Settings.Default.Save();
                lastInckeySourceTextBox.Text = lastInckeySourceUpdate.ToString();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ibsConnection.Close();
                return -1;
            }
        }

        private int UpdateInterbaseObjectName(string conStr, bool interval)
        {
            return UpdateInterbaseObjectName(conStr, interval, 0);
        }
        private int UpdateInterbaseObjectName(string conStr, long s_inckey)
        {
            return UpdateInterbaseObjectName(conStr, false, s_inckey);
        }

        private int UpdateInterbaseObjectName(string conStr)
        {
            return UpdateInterbaseObjectName(conStr, false, 0);
        }
        #endregion


        #region Sourse_base
        private string GetObjectName(string number)
        {
            string conStr = IBProvider +
                              "location=" + sourceServerTextBox.Text + ":" + sourcePathTextBox.Text + ";" +
                              "user id=" + userTextBox.Text + ";" +
                              "password=" + passwordTextBox.Text + ";" +
                              "ctype=win1251";
            OleDbConnection sourceConnection = new OleDbConnection(conStr);
            try
            {
                sourceConnection.Open();
                string strCmd = @"";
                strCmd = @"select  SRC_OBJECTS.O_NAME
                                from  SRC_OBJECTS
                                join  SRC_SOURCES BH on (SRC_SOURCES.S_OBJECT =  SRC_OBJECTS.O_ID)
                                join  SRC_IDENTITY_STR on (SRC_IDENTITY_STR.I_SOURCE =  SRC_SOURCES.S_ID)
                                where SRC_IDENTITY_STR.I_VALUE = '" + number + "'";
                OleDbTransaction transaction = sourceConnection.BeginTransaction();
                OleDbCommand command = new OleDbCommand(strCmd, sourceConnection, transaction);
                OleDbDataReader reader = command.ExecuteReader();
                string objectName = "";
                while (reader.Read())
                {
                    objectName = reader[0].ToString();
                    break;
                }
                reader.Close();
                sourceConnection.Close();
                return objectName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sourceConnection.Close();
                return "";
            }
        }
        #endregion
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            oracleServerLabel.Enabled = false;
            oracleServerTextBox.Enabled = false;
            oracleSchemaLabel.Enabled = false;
            oracleSchemaTextBox.Enabled = false;
            commandButton.Enabled = false;
            commandButton2.Enabled = false;
            correctButton.Enabled = false;
            correctButton2.Enabled = false;
            updateNumbersCheckBox.Enabled = false;
            interbaseServerLabel.Enabled = true;
            interbaseServerTextBox.Enabled = true;
            interbasePathLabel.Enabled = true;
            interbasePathTextBox.Enabled = true;
            interbaseChangeFileButton.Enabled = true;

        }
        private void oracleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            interbaseServerLabel.Enabled = false;
            interbaseServerTextBox.Enabled = false;
            interbasePathLabel.Enabled = false;
            interbasePathTextBox.Enabled = false;
            interbaseChangeFileButton.Enabled = false;
            commandButton.Enabled = true;
            commandButton2.Enabled = true;
            correctButton.Enabled = true;
            correctButton2.Enabled = true;
            updateNumbersCheckBox.Enabled = true;
            oracleServerLabel.Enabled = true;
            oracleServerTextBox.Enabled = true;
            oracleSchemaLabel.Enabled = true;
            oracleSchemaTextBox.Enabled = true;
        }

        private void interbaseChangeFileButton_Click(object sender, EventArgs e)
        {
            if(interbaseOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                interbasePathTextBox.Text = interbaseOpenFileDialog.FileName;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            updateButton.Enabled = false;
            updateButton2.Enabled = false;
            startAutoUpdateButton.Enabled = false;
            startAutoUpdateButton2.Enabled = false;
            stopAutoUpdateButton.Enabled = false;
            stopAutoUpdateButton2.Enabled = false;
            EnabledOff();
            MakeUpdate(false);
            EnabledOn();
            updateButton.Enabled = true;
            updateButton2.Enabled = true;
            startAutoUpdateButton.Enabled = true;
            startAutoUpdateButton2.Enabled = true;

        }

        private void sourceChangeFileButton_Click(object sender, EventArgs e)
        {
            if (sourceOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourcePathTextBox.Text = sourceOpenFileDialog.FileName;
            }
        }

        private void sourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sourceServerLabel.Enabled = sourceCheckBox.Checked;
            sourceServerTextBox.Enabled = sourceCheckBox.Checked;
            sourcePathLabel.Enabled = sourceCheckBox.Checked;
            sourcePathTextBox.Enabled = sourceCheckBox.Checked;
            sourceChangeFileButton.Enabled = sourceCheckBox.Checked;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            NextUpdateTimeLabel.Text = "Задача " + now.ToShortDateString() + " в " + now.ToLongTimeString() + " запущена...";          
            benchmarkDate = DateTime.Now.AddDays((-1) * Convert.ToInt32(intervalNumericUpDown.Value));
            MakeUpdate(true);
            int hours = Convert.ToInt32(freqComboBox.SelectedItem);
            DateTime nextUpd = now.AddHours(hours);
            NextUpdateTimeLabel.Text = "Обработка " + now.ToShortDateString() + " в " + now.ToLongTimeString() + " произведена. Следующий запуск " + nextUpd.ToShortDateString() + " в " + nextUpd.ToLongTimeString();           
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.OracleServer = oracleServerTextBox.Text;
                Properties.Settings.Default.OracleSchema = oracleSchemaTextBox.Text;
                Properties.Settings.Default.Oracle = oracleRadioButton.Checked;

                Properties.Settings.Default.Interbase = interbaseRadioButton.Checked;
                Properties.Settings.Default.InterbaseServer = interbaseServerTextBox.Text;
                Properties.Settings.Default.InterbasePath = interbasePathTextBox.Text;

                Properties.Settings.Default.SourceBase = sourceCheckBox.Checked;
                Properties.Settings.Default.SourceServer = sourceServerTextBox.Text;
                Properties.Settings.Default.SourcePath = sourcePathTextBox.Text;

                Properties.Settings.Default.InckeyOn = lastInckeyCheckBox.Checked;
                Properties.Settings.Default.AbnNum = updateNumbersCheckBox.Checked;
                lastInckeySetupDown = Convert.ToInt64(lastInckeySetupDownTextBox.Text);
                lastInckeySourceUpdate = Convert.ToInt64(lastInckeySourceTextBox.Text);
                lastInckeySetupDownTextBox.Text = lastInckeySetupDown.ToString();
                lastInckeySourceTextBox.Text = lastInckeySourceUpdate.ToString();
                Properties.Settings.Default.lastInckeySetupDown = lastInckeySetupDown;
                Properties.Settings.Default.LastInckeySourceUpdate = lastInckeySourceUpdate;

                Properties.Settings.Default.FreqAutoUpdate = freqComboBox.SelectedIndex;
                Properties.Settings.Default.IntervalUpdate = Convert.ToInt32(intervalNumericUpDown.Value);



                Properties.Settings.Default.Save();
                MessageBox.Show("Настройки сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            benchmarkDate = DateTime.Now;
            try
            {
                intervalNumericUpDown.Value = Properties.Settings.Default.IntervalUpdate;
                if (Properties.Settings.Default.FreqAutoUpdate >= 0)
                {
                    freqComboBox.SelectedIndex = Properties.Settings.Default.FreqAutoUpdate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void startAutoUpdateButton_Click(object sender, EventArgs e)
        {
            benchmarkDate = DateTime.Now.AddDays(-1 * Convert.ToDouble(intervalNumericUpDown.Value));
            timer.Interval = 3600000 * Convert.ToInt32(freqComboBox.SelectedItem);
            updateButton.Enabled = false;
            startAutoUpdateButton.Enabled = false;
            stopAutoUpdateButton.Enabled = true;
            updateButton2.Enabled = false;
            startAutoUpdateButton2.Enabled = false;
            stopAutoUpdateButton2.Enabled = true;
            EnabledOff();
            DateTime now = DateTime.Now;
            timer.Enabled = true;
            NextUpdateTimeLabel.Text = "Задача " + now.ToShortDateString() + " в " + now.ToLongTimeString() + " запущена...";
            MakeUpdate(true);
            int hours = Convert.ToInt32(freqComboBox.SelectedItem);
            DateTime nextUpd = now.AddHours(hours);
            NextUpdateTimeLabel.Text = "Обработка " + now.ToShortDateString() + " в " + now.ToLongTimeString() + " произведена. Следующий запуск " + nextUpd.ToShortDateString() + " в " + nextUpd.ToLongTimeString(); 
            
        }

        private void stopAutoUpdateButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            EnabledOn();
            updateButton.Enabled = true;
            startAutoUpdateButton.Enabled = true;
            stopAutoUpdateButton.Enabled = false;
            updateButton2.Enabled = true;
            startAutoUpdateButton2.Enabled = true;
            stopAutoUpdateButton2.Enabled = false;
            NextUpdateTimeLabel.Text = "";
        }

        private void lastInckeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lastInckeySetupDownLabel.Enabled = lastInckeyCheckBox.Checked;
            lastInckeySourceLabel.Enabled = lastInckeyCheckBox.Checked;
        }

        private void mainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Location.X >= lastInckeySetupDownTextBox.Location.X) & (e.Location.X <= (lastInckeySetupDownTextBox.Location.X + lastInckeySetupDownTextBox.Width)) & (e.Location.Y >= lastInckeySetupDownTextBox.Location.Y) & (e.Location.Y <= (lastInckeySetupDownTextBox.Location.Y + lastInckeySetupDownTextBox.Height)))
            {
                lastInckeySetupDownTextBox.Enabled = true;
            }
            if ((e.Location.X >= lastInckeySourceTextBox.Location.X) & (e.Location.X <= (lastInckeySourceTextBox.Location.X + lastInckeySourceTextBox.Width)) & (e.Location.Y >= lastInckeySourceTextBox.Location.Y) & (e.Location.Y <= (lastInckeySourceTextBox.Location.Y + lastInckeySourceTextBox.Height)))
            {
                lastInckeySourceTextBox.Enabled = true;
            }
        }

        private void lastInckey_DoubleClick(object sender, EventArgs e)
        {
            (sender as TextBox).Enabled = false;

        }

        private void commandButton_Click(object sender, EventArgs e)
        {
            SQLCommandForm commandForm = new SQLCommandForm(oracleServerTextBox.Text, oracleSchemaTextBox.Text, passwordTextBox.Text);
            commandForm.Show();
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            SQLCommandForm commandForm = new SQLCommandForm(oracleServerTextBox.Text, oracleSchemaTextBox.Text, passwordTextBox.Text, true);
            commandForm.Show();
        }

        private void clearInterbaseButton2_Click(object sender, EventArgs e)
        {

        }

        private void clearInterbaseButton_Click(object sender, EventArgs e)
        {
            if (clearInterbaseOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("Вы дйствительно хотите очистить в базе данных поля \"Имя источника\", \"Имя собеседника\" и \"Комментарий\"?", "Удаление", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string conStr = IBProvider +
                           "location=localhost:" + clearInterbaseOpenFileDialog.FileName + ";" +
                           "user id=" + userTextBox.Text + ";" +
                           "password=" + passwordTextBox.Text + ";" +
                           "ctype=win1251";
                    OleDbConnection clearConnection = new OleDbConnection(conStr);
                    try
                    {
                        clearConnection.Open();
                        OleDbTransaction clearTransaction = clearConnection.BeginTransaction();
                        try
                        {
                            string clearStr = @"update spr_speech_table
                                                set s_talkername = '', 
                                                    s_sourcename = ''";
                            OleDbCommand clearCommand = new OleDbCommand(clearStr, clearConnection, clearTransaction);
                            clearCommand.ExecuteNonQuery();
                            clearTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clearTransaction.Rollback();
                        }
                        OleDbTransaction clearCommentTransaction = clearConnection.BeginTransaction();
                        try
                        {
                            string clearStr = @"delete from  SPR_SP_COMMENT_TABLE ";
                            OleDbCommand clearCommentCommand = new OleDbCommand(clearStr, clearConnection, clearCommentTransaction);
                            clearCommentCommand.ExecuteNonQuery();
                            clearCommentTransaction.Commit();
                            MessageBox.Show("Поля \"Имя источника\", \"Имя собеседника\" и \"Комментарий\" в базе данных успешно очищены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clearCommentTransaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearConnection.Close();
                    }
                }
            }
        }
    }
}
