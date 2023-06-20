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
    public partial class AddDaysForm : Form
    {
        private bool isChanged;

        public bool IsChanged
        {
            get { return isChanged; }
        }

        private int days;

        public int Days
        {
            get { return days; }
        }
        public AddDaysForm()
        {
            days = 30;
            isChanged = false;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            days = 30;
            isChanged = false;
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            days = Convert.ToInt32(numericUpDown.Value);
            isChanged = true;
            Close();
        }
    }
}
