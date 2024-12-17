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
   
    public partial class Hoá_đơn_đã_lưu : Form
    {   public string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
        public Hoá_đơn_đã_lưu()
        {
            InitializeComponent();
        }

        private void Hoá_đơn_đã_lưu_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
           
            lvDSHD.Items.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                CT_HD.ID_HD, 
                KH.HoTen AS TenKhachHang,
                HD.TongTien AS TongTienHoaDon,
                STUFF(
                    (SELECT ', ' + DV.TenDV
                     FROM CT_HD CT2
                     INNER JOIN DichVu DV ON CT2.ID_DV = DV.ID_DichVu
                     WHERE CT2.ID_HD = CT_HD.ID_HD
                     FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TenDichVu,
                SUM(CT_HD.ThanhTien) AS ThanhTienCT,
                MIN(CT_HD.Ngay) AS NgayLap
            FROM CT_HD
            INNER JOIN HoaDon HD ON CT_HD.ID_HD = HD.ID_HD
            INNER JOIN KhachHang KH ON HD.ID_KhachHang = KH.ID_KhachHang
            GROUP BY CT_HD.ID_HD, KH.HoTen, HD.TongTien";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    // Tạo một dòng mới trong ListView
                    ListViewItem item = new ListViewItem(reader["ID_HD"].ToString()); // Mã hóa đơn
                    item.SubItems.Add(reader["TenKhachHang"].ToString()); // Tên khách hàng
                    item.SubItems.Add(reader["TongTienHoaDon"].ToString()); // Tổng tiền hóa đơn
                    item.SubItems.Add(reader["TenDichVu"].ToString()); // Tên dịch vụ
                    item.SubItems.Add(reader["ThanhTienCT"].ToString()); // Tổng tiền từ chi tiết
                    item.SubItems.Add(Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy")); // Ngày lập hóa đơn

                    lvDSHD.Items.Add(item);
                }

                sqlConnection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            FilterInvoiceList(ten);
        }
        private void FilterInvoiceList(string tenKhachHang)
        {
            // Clear previous items in the ListView
            lvDSHD.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Truy vấn lọc hóa đơn theo tên khách hàng
                string query = @"
                    SELECT 
                        CT_HD.ID_HD, 
                        KH.HoTen AS TenKhachHang,
                        HD.TongTien AS TongTienHoaDon,
                        STUFF(
                            (SELECT ', ' + DV.TenDV
                             FROM CT_HD CT2
                             INNER JOIN DichVu DV ON CT2.ID_DV = DV.ID_DichVu
                             WHERE CT2.ID_HD = CT_HD.ID_HD
                             FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TenDichVu,
                        SUM(CT_HD.ThanhTien) AS ThanhTienCT,
                        MIN(CT_HD.Ngay) AS NgayLap
                    FROM CT_HD
                    INNER JOIN HoaDon HD ON CT_HD.ID_HD = HD.ID_HD
                    INNER JOIN KhachHang KH ON HD.ID_KhachHang = KH.ID_KhachHang
                    WHERE KH.HoTen LIKE @TenKH
                    GROUP BY CT_HD.ID_HD, KH.HoTen, HD.TongTien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    cmd.Parameters.AddWithValue("@TenKH", "%" + tenKhachHang + "%");

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Tạo ListViewItem mới cho mỗi hóa đơn
                            ListViewItem item = new ListViewItem(reader["ID_HD"].ToString()); // Mã hóa đơn
                            item.SubItems.Add(reader["TenKhachHang"].ToString()); // Tên khách hàng
                            item.SubItems.Add(Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy")); // Ngày lập hóa đơn
                            item.SubItems.Add(reader["TenDichVu"].ToString()); // Dịch vụ
                            item.SubItems.Add(reader["TongTienHoaDon"].ToString()); // Tổng tiền hóa đơn

                            // Thêm vào ListView
                            lvDSHD.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lọc danh sách hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        private void FilterInvoiceListByDate(DateTime ngayLap)
        {
            // Clear previous items in the ListView
            lvDSHD.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                CT_HD.ID_HD, 
                KH.HoTen AS TenKhachHang,
                HD.TongTien AS TongTienHoaDon,
                STUFF(
                    (SELECT ', ' + DV.TenDV
                     FROM CT_HD CT2
                     INNER JOIN DichVu DV ON CT2.ID_DV = DV.ID_DichVu
                     WHERE CT2.ID_HD = CT_HD.ID_HD
                     FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TenDichVu,
                SUM(CT_HD.ThanhTien) AS ThanhTienCT,
                MIN(CT_HD.Ngay) AS NgayLap
            FROM CT_HD
            INNER JOIN HoaDon HD ON CT_HD.ID_HD = HD.ID_HD
            INNER JOIN KhachHang KH ON HD.ID_KhachHang = KH.ID_KhachHang
            WHERE CONVERT(DATE, CT_HD.Ngay) = @NgayLap
            GROUP BY CT_HD.ID_HD, KH.HoTen, HD.TongTien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap.Date);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Tạo ListViewItem mới cho mỗi hóa đơn
                            ListViewItem item = new ListViewItem(reader["ID_HD"].ToString()); // Mã hóa đơn
                            item.SubItems.Add(reader["TenKhachHang"].ToString()); // Tên khách hàng
                            item.SubItems.Add(Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy")); // Ngày lập hóa đơn
                            item.SubItems.Add(reader["TenDichVu"].ToString()); // Dịch vụ
                            item.SubItems.Add(reader["TongTienHoaDon"].ToString()); // Tổng tiền hóa đơn

                            // Thêm vào ListView
                            lvDSHD.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lọc danh sách hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            FilterInvoiceListByDate(selectedDate);
        }
    }
}
