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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace frmchinh
{
    public partial class LichSuHD : Form
    {
        public LichSuHD()
        {
            InitializeComponent();
        }
        private void LichSuHD_Load()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = conn.CreateCommand();
            string query = "SELECT * FROM HoaDon";
            sqlCommand.CommandText = query;
            conn.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            this.DisplayCategory(sqlDataReader);
            conn.Close();
        }
        private void DisplayCategory(SqlDataReader reader)
        {
            lvDSHoaDon.Items.Clear();
            while (reader.Read())
            {
                //ID_NV,ID_KhachHang,NgayLap,ThanhTien,GiamGia,Coc,TongTien
                ListViewItem item = new ListViewItem(reader["ID_NV"].ToString());
                lvDSHoaDon.Items.Add(item);
                item.SubItems.Add(reader["ID_KhachHang"].ToString());
                item.SubItems.Add(reader["NgayLap"].ToString());
                item.SubItems.Add(reader["ThanhTien"].ToString());
                item.SubItems.Add(reader["GiamGia"].ToString());
                item.SubItems.Add(reader["Coc"].ToString());
                item.SubItems.Add(reader["TongTien"].ToString());
            }
        }
        private void FilterCustomerList(string tenKhachHang)
        {
            // Clear previous items in the ListView
            lvDSHoaDon.Items.Clear();
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Truy vấn tìm kiếm khách hàng theo tên
                string query = "SELECT * FROM KhachHang WHERE ID_KhachHang LIKE @TenKH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKH", "%" + tenKhachHang + "%");

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ID_NV"].ToString());
                            item.SubItems.Add(reader["ID_KhachHang"].ToString());
                            item.SubItems.Add(reader["NgayLap"].ToString());
                            item.SubItems.Add(reader["ThanhTien"].ToString());
                            item.SubItems.Add(reader["GiamGia"].ToString());
                            item.SubItems.Add(reader["Coc"].ToString());
                            item.SubItems.Add(reader["TongTien"].ToString());
                            // Add the item to the ListView
                            lvDSHoaDon.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lọc danh sách khách hàng: " + ex.Message);
                    }
                }
            }
        }
        private void txtTenKh_TextChanged(object sender, EventArgs e)
        {
            string tenKhachHang = txtTenKH.Text;
            FilterCustomerList(tenKhachHang);
        }
        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    if (txtTenKH.Text != "")
        //    {
        //        CT_HD cthd = new CT_HD();
        //        cthd.Show(this);
        //        cthd.LoadFood(Convert.ToInt32(txtTenKH.Text));
        //    }
        //}

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //DataBase.getdata;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                CT_HD cthd = new CT_HD();
                cthd.Show(this);
                cthd.LoadFood(Convert.ToInt32(txtTenKH.Text));
            }
        }

        private void LichSuHD_Load_1(object sender, EventArgs e)
        {
            LichSuHD_Load();
        }
    }
}
