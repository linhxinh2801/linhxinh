using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmchinh
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                string tk = txtTenDN.Text;
                string mk = txtMatKhauDN.Text;
                cmd.CommandText = "SELECT TenDN, MatKhau FROM NhanVien WHERE TenDN ='" + tk + "' AND MatKhau ='" + mk + "' ";
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối");
            }
        }
    }
}
