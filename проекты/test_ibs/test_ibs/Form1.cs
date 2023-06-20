using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

namespace test_ibs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var cnsb = new OleDbConnectionStringBuilder();

            cnsb["provider"] = "LCPI.IBProvider.3";

            cnsb["location"] = "localhost:d:\\111.ibs";

            cnsb["user id"] = "SYSDBA";

            cnsb["password"] = "masterkey";

            

            var cn = new OleDbConnection(cnsb.ConnectionString);

            cn.Open();
            MessageBox.Show("подключение установлено","");
        
        }
    }
}
