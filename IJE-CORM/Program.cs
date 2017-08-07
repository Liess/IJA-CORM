using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IJE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(logOut);

            Application.Run(new Front());



        }



        static void logOut(object sender, EventArgs e)
        {
            new DBConnect().Update("update tblAdmin set boolAdmIsLoggedIn = false;");
            MessageBox.Show("Logged Out");
        }
    }
}
