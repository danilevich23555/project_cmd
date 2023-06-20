using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class ConnectionForm : Form
    {

        private string server;
        public string Server
        {
            get
            {
                return server;
            }
        }
        private string database;
        public string Database
        {
            get
            {
                return database;
            }
        }

        private bool changed;
        public bool Changed
        {
            get
            {
                return changed;
            }
        }
        public ConnectionForm()
        {
            changed = false;
            server = "";
            database = "";
            InitializeComponent();
        }

        private int GetDatabase()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\statistics.ini";
                StreamReader file = new StreamReader(path);
                serverTextBox.Text = file.ReadLine();
                databaseTextBox.Text = file.ReadLine();
                file.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.server = serverTextBox.Text;
            this.database = databaseTextBox.Text;
            this.changed = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.changed = false;
            this.Close();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            if (GetDatabase() != 0)
            {
                serverTextBox.Text = "";
                databaseTextBox.Text = "";
            }
        }

    }
}
