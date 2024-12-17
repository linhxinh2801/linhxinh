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
    public partial class frmQuanLynhanvien : Form
    {
        public frmQuanLynhanvien()
        {
            InitializeComponent();
        }
        
        private void LoadDanhSachNhanVien()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID_NV, TendN, MatKhau, HoTen, SoDT_NV, SoCC_NV, NgaySinh, GioiTinh, VaiTro, DiaChi, NgayThoiViec, GhiChu FROM NhanVien";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            this.DisplayQLDVKS(sqlDataReader);
            sqlConnection.Close();
        }
        private void DisplayQLDVKS(SqlDataReader reader)
        {
            lvDanhSachNhanVien.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID_NV"].ToString());
                lvDanhSachNhanVien.Items.Add(item);
                item.SubItems.Add(reader["TenDN"].ToString());
                item.SubItems.Add("******");
                item.SubItems.Add(reader["HoTen"].ToString());
                item.SubItems.Add(reader["SoDT_NV"].ToString());
                item.SubItems.Add(reader["SoCC_NV"].ToString());
                item.SubItems.Add(reader["NgaySinh"].ToString());
                item.SubItems.Add(reader["GioiTinh"].ToString());
                item.SubItems.Add(reader["VaiTro"].ToString());
                item.SubItems.Add(reader["DiaChi"].ToString());
                item.SubItems.Add(reader["NgayThoiViec"].ToString());
                item.SubItems.Add(reader["GhiChu"].ToString());
            }
        }

        private void LoadVaiTro()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT ID_VaiTro, TenVaiTro FROM VaiTro";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adapter.Fill(dt);
            sqlConnection.Close();
            sqlConnection.Dispose();
            cbbVaiTro.DataSource = dt;
            cbbVaiTro.ValueMember = "ID_VaiTro";
            cbbVaiTro.DisplayMember = "TenVaiTro";

        }
       /// <summary>
       /// //////////
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       

       
        

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTrong_Click_1(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenDN.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtSoCC_NV.Text = "";
            mtxtSoDT_NV.Text = "";
            rdNu.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            cbbVaiTro.SelectedIndex = -1;
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
        }

        private void lvDanhSachNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Thu thập dữ liệu từ giao diện
                string tenDN = txtTenDN.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string soDT = mtxtSoDT_NV.Text.Replace(" ", "");
                string soCC = txtSoCC_NV.Text.Trim();
                DateTime? ngaySinh = dtpNgaySinh.Value;
                bool gioiTinh = rdNam.Checked; // true nếu Nam, false nếu Nữ
                string vaiTro = cbbVaiTro.SelectedItem?.ToString() ?? ""; // Kiểm tra nếu chưa chọn Vai trò
                string diaChi = txtDiaChi.Text.Trim();
                DateTime? ngayThoiViec = null;
                string ghiChu = txtGhiChu.Text.Trim();
                byte enable = 0;

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(tenDN) || string.IsNullOrWhiteSpace(matKhau) ||
                    string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(soDT) ||
                    string.IsNullOrWhiteSpace(soCC) || string.IsNullOrWhiteSpace(vaiTro))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi kết nối cơ sở dữ liệu
                string connectionString = "Data Source=quynhu\\SQLEXPRESS;Initial Catalog=QLDVKS;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu lệnh SQL
                    string sql = @"
                INSERT INTO NhanVien 
                (TenDN, MatKhau, HoTen, SoDT_NV, SoCC_NV, NgaySinh, GioiTinh, VaiTro, DiaChi, NgayThoiViec, GhiChu, Enable)
                VALUES (@TenDN, @MatKhau, @HoTen, @SoDT_NV, @SoCC_NV, @NgaySinh, @GioiTinh, @VaiTro, @DiaChi, @NgayThoiViec, @GhiChu, @Enable)";

                    // Tạo và thiết lập SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDN", tenDN);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@SoDT_NV", soDT);
                        cmd.Parameters.AddWithValue("@SoCC_NV", soCC);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ? 1 : 0); // 1: Nam, 0: Nữ
                        cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                        cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi);
                        cmd.Parameters.AddWithValue("@NgayThoiViec", ngayThoiViec.HasValue ? (object)ngayThoiViec.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu);
                        cmd.Parameters.AddWithValue("@Enable", 0);

                        // Thực thi SQL
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Lưu nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể lưu nhân viên. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNV_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=quynhu\\SQLEXPRESS; database= QLDVKS; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM NhanVien Where ID_NV = " + Convert.ToInt32(txtMaNV.Text);
            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvDanhSachNhanVien.SelectedItems[0];
                lvDanhSachNhanVien.Items.Remove(item);
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLynhanvien_Click(object sender, EventArgs e)
        {

        }

        private void lvDanhSachNhanVien_Click_1(object sender, EventArgs e)
        {
            ListViewItem item = lvDanhSachNhanVien.SelectedItems[0];
            txtMaNV.Text = item.Text;
            txtTenDN.Text = item.SubItems[1].Text;
            txtMatKhau.Text = item.SubItems[2].Text;
            txtHoTen.Text = item.SubItems[3].Text;
            mtxtSoDT_NV.Text = item.SubItems[4].Text;
            txtSoCC_NV.Text = item.SubItems[5].Text;
            dtpNgaySinh.Text = item.SubItems[6].Text;
            if (item.SubItems[7].Text == "Nam")
            {
                rdNam.Checked = true;
            }
            else if (item.SubItems[7].Text == "Nữ")
            {
                rdNu.Checked = true;
            };
            cbbVaiTro.Text = item.SubItems[8].Text;
            txtDiaChi.Text = item.SubItems[9].Text;
            txtNgayThoiViec.Text = item.SubItems[10].Text;
            txtGhiChu.Text = item.SubItems[11].Text;
            btnXoaNV.Enabled = true;
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grpDanhSachNV_Enter(object sender, EventArgs e)
        {

        }

        private void frmQuanLynhanvien_Load_1(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
            LoadVaiTro();
        }
    }
}
