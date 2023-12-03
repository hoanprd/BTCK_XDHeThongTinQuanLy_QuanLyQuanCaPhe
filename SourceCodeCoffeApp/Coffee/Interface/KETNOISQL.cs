using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
// Tham chiếu Smo và Sql connect info
namespace Interface
{
    public partial class KETNOISQL : Form
    {
        public KETNOISQL()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void KETNOISQL_Load(object sender, EventArgs e)
        {
            txttencsdl.DropDownStyle = ComboBoxStyle.DropDownList;
            
            txttencsdl.Enabled = true;
        }


        private void btketnoi_MouseMove(object sender, MouseEventArgs e)
        {
            btketnoi.BackColor = Color.Chocolate;
            btketnoi.ForeColor = Color.Yellow;
        }

        private void btketnoi_MouseLeave(object sender, EventArgs e)
        {
            btketnoi.BackColor = Color.Transparent;
            btketnoi.ForeColor = SystemColors.ControlText;
        }

        private void txttencsdl_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy tên csdl theo tên sv
                string tenserver = txttensv.Text;
                Server sv = new Server(tenserver);
                DataTable bangluutenCSDL = new DataTable();
                List<string> tencsdl = new List<string>();
                foreach (Database csdl in sv.Databases)
                {
                    tencsdl.Add(csdl.Name);
                }
                txttencsdl.DataSource = tencsdl;
            }
            catch
            {
                MessageBox.Show("Chưa chọn tên của máy chủ SQL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        string duongdan = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private void btketnoi_Click(object sender, EventArgs e)
        {
            if (txttensv.Text == "")
            {
                MessageBox.Show("Chưa chọn tên của máy chủ SQL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txttencsdl.Text == "")
            {
                MessageBox.Show("Chưa chọn tên cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txttencsdl.Text == "QuanLyQuanCaPhe")
                {
                    string maychu = duongdan + @"\DatabaseCafe\tenmaychu.txt";
                    string csdl = duongdan + @"\DatabaseCafe\tencsdl.txt";
                    File.WriteAllText(maychu, txttensv.Text);
                    File.WriteAllText(csdl, txttencsdl.Text);
                    string s = duongdan + @"\DatabaseCafe\xacnhandaketnoi.txt";
                    File.WriteAllText(s, "daketnoi");
                    Home h = new Home();
                    this.Hide();
                    h.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cơ sở dữ liệu của chương trình là : 'QuanLyQuanCaPhe'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bttaocsdl_Click(object sender, EventArgs e)
        {
            if (txttensv.Text == "")
            {
                MessageBox.Show("Chưa chọn tên SQL Server.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string sqlConnectionString = @"Data Source=" + txttensv.Text + ";Integrated Security=True";
                    //FileInfo file = new FileInfo(duongdan + @"\DatabaseCafe\CSDLCAFE.sql");
                    FileInfo file = new FileInfo(Application.StartupPath + @"\CSDLCAFE.sql");
                    string script = file.OpenText().ReadToEnd();
                    SqlConnection conn = new SqlConnection(sqlConnectionString);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(script);
                    txttencsdl.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Không thể tạo cơ sở dữ liệu vui lòng kiểm tra lại đã cài đặt SQL Server hoặc cơ sở dữ liệu đã tồn tại trong máy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bttaocsdl_MouseMove(object sender, MouseEventArgs e)
        {
            bttaocsdl.BackColor = Color.Chocolate;
            bttaocsdl.ForeColor = Color.Yellow;
        }

        private void bttaocsdl_MouseLeave(object sender, EventArgs e)
        {
            bttaocsdl.BackColor = Color.Transparent;
            bttaocsdl.ForeColor = SystemColors.ControlText;
        }
    }
}
