using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Interface
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
            string duongdan = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = duongdan + @"\DatabaseCafe\savevalues.txt";
            string mofile = File.ReadAllText(duongdan + @"\DatabaseCafe\xacnhandaketnoi.txt");
            string mofile1 = File.ReadAllText(duongdan + @"\DatabaseCafe\savevalues.txt"); 
            if (mofile1 != "1")
            {
                System.IO.File.WriteAllText(filename, "1");
                Application.Run(new KETNOISQL());
            }
            else if (mofile != "daketnoi")
            {
                Application.Run(new KETNOISQL());
            }
            else
            {
                Application.Run(new Home());
            }
        }
    }
}
