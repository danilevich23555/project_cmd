using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Statistics
{
    public partial class DateForm : Form
    {
        private bool isCnahged;
        public bool IsChanged
        {
            get
            {
                return isCnahged;
            }
        }
        private DateTime concReturnDate;

        public DateTime ConclutionReturnDate
        {
            get { return concReturnDate; }
        }
        public DateForm() : this(DateTime.Now)
        {

        }

        public DateForm(DateTime date) 
        {
            this.concReturnDate = date;
            isCnahged = false;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isCnahged = false;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            isCnahged = true;
            concReturnDate = conclutionReturnDate.Value;
            Close();
        }

        private void DateForm_Load(object sender, EventArgs e)
        {
            conclutionReturnDate.Value = concReturnDate;
        }
    }
}
