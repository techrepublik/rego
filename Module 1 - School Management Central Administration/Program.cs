using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Module_1___School_Management_Central_Administration
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
            Application.Run(new LoginForm());
        }
    }
}
