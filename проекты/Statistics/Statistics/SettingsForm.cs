using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private DateTime sinceDate;
        public DateTime SinceDate
        {
            get { return sinceDate; }
        }
        private bool isSaved;
        public bool IsSaved
        {
            get { return isSaved; }
        }

        private bool isOnOption;

        public bool IsOnOption
        {
            get { return isOnOption; }
        }

        private int GetSettings()
        {
            string path = Directory.GetCurrentDirectory() + "\\statistics.ini";
            StreamReader file = new StreamReader(path);
            try
            {

                serverTextBox.Text = file.ReadLine();
                databaseTextBox.Text = file.ReadLine();
                dateTimePicker.Value = Convert.ToDateTime(file.ReadLine());
                if (Convert.ToInt32(file.ReadLine()) == 1) sinceCheckBox.Checked = true; else sinceCheckBox.Checked = false;
                if (Convert.ToInt32(file.ReadLine()) == 1) autoConnectCheckBox.Checked = true; else autoConnectCheckBox.Checked = false;
                file.Close();
                return 0;
            }
            catch (Exception ex)
            {
                file.Close();
                return -1;
            }
        }
        private int SaveSettings()
        {
            string path = Directory.GetCurrentDirectory() + "\\statistics.ini";
            StreamWriter file = new StreamWriter(path, false);
            try
            {

                file.WriteLine(serverTextBox.Text);
                file.WriteLine(databaseTextBox.Text);
                file.WriteLine(dateTimePicker.Value.ToShortDateString());
                if (sinceCheckBox.Checked) file.WriteLine(1); else file.WriteLine(0);
                if (autoConnectCheckBox.Checked) file.WriteLine(1); else file.WriteLine(0);
                file.Close();
                return 0;
            }
            catch (Exception ex)
            {
                file.Close();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveSettings() == 0)
            {
                isOnOption = sinceCheckBox.Checked;
                sinceDate = dateTimePicker.Value;
                isSaved = true;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isSaved = false;
            Close();
        }


    }
}
