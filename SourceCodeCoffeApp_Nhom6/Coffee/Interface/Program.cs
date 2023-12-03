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

            string ketNoiCSDLPath = duongdan + @"\DatabaseCafe\savevalues.txt";
            string xacNhanKetNoiCSDLPath = duongdan + @"\DatabaseCafe\xacnhandaketnoi.txt";
            string tenServerPath = duongdan + @"\DatabaseCafe\tenmaychu.txt";
            string tenCSDLPath = duongdan + @"\DatabaseCafe\tencsdl.txt";
            string checkDangKyTaiKhoanPath = duongdan + @"\DatabaseCafe\checkdk.txt";

            if (!File.Exists(ketNoiCSDLPath))
            {
                using (FileStream fs = File.Create(ketNoiCSDLPath))
                {
                    // Không cần thực hiện bất kỳ ghi nào vào FileStream
                }
            }
            if (!File.Exists(xacNhanKetNoiCSDLPath))
            {
                using (FileStream fs = File.Create(xacNhanKetNoiCSDLPath))
                {
                    // Không cần thực hiện bất kỳ ghi nào vào FileStream
                }
            }
            if (!File.Exists(tenServerPath))
            {
                using (FileStream fs = File.Create(tenServerPath))
                {
                    // Không cần thực hiện bất kỳ ghi nào vào FileStream
                }
            }
            if (!File.Exists(tenCSDLPath))
            {
                using (FileStream fs = File.Create(tenCSDLPath))
                {
                    // Không cần thực hiện bất kỳ ghi nào vào FileStream
                }
            }
            if (!File.Exists(checkDangKyTaiKhoanPath))
            {
                using (FileStream fs = File.Create(checkDangKyTaiKhoanPath))
                {
                    // Không cần thực hiện bất kỳ ghi nào vào FileStream
                }
            }

            string mofile = File.ReadAllText(duongdan + @"\DatabaseCafe\xacnhandaketnoi.txt");
            string mofile1 = File.ReadAllText(duongdan + @"\DatabaseCafe\savevalues.txt"); 
            if (mofile1 != "1")
            {
                System.IO.File.WriteAllText(ketNoiCSDLPath, "1");
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
