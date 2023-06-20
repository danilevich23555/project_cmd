using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace search_sar
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new serch_sar());
        }
    }
}
