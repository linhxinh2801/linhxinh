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
    public partial class KhachHang : Form
    {
        public static string ID ;
        public KhachHang()
        {
            InitializeComponent();
        }
        string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database=QLDVKS; Integrated Security= true;";

        #region TaiDanhSachVaTimKiem KhachHang
        private void LoadKhachHang()
        {
            lvKH.Items.Clear();
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT ID_KhachHang, HoTen, SoDT_KH, SoCC_KH, GhiChu FROM KhachHang ";
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID_KhachHang"].ToString());
                item.SubItems.Add(reader["HoTen"].ToString());
                item.SubItems.Add(reader["SoDT_KH"].ToString());
                item.SubItems.Add(reader["SoCC_KH"].ToString());
                item.SubItems.Add(reader["GhiChu"].ToString());
                lvKH.Items.Add(item);

            }
            sqlConnection.Close();
            sqlConnection.Dispose();

        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            this.LoadKhachHang();
        }
        private void FilterCustomerList(string tenKhachHang)
        {
            // Clear previous items in the ListView
            lvKH.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Truy vấn tìm kiếm khách hàng theo tên
                string query = "SELECT ID_KhachHang, HoTen, SoDT_KH, SoCC_KH, GhiChu FROM KhachHang WHERE HoTen LIKE @TenKH";




                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKH", "%" + tenKhachHang + "%");

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Tạo ListViewItem mới cho mỗi hàng dữ liệu
                            ListViewItem item = new ListViewItem(reader["ID_KhachHang"].ToString());
                            item.SubItems.Add(reader["HoTen"].ToString());

                            item.SubItems.Add(reader["SoDT_KH"].ToString());

                            item.SubItems.Add(reader["SoCC_KH"].ToString());

                            // Add the item to the ListView
                            lvKH.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lọc danh sách khách hàng: " + ex.Message);
                    }
                }
            }
        }
        private void txtTenKhach_TextChanged(object sender, EventArgs e)
        {
            string ten = txtTenKhach.Text;
            FilterCustomerList(ten);
        }

        #endregion

        #region TaoKhachHangMoi
        private void CreateCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string cchc = txtCCHC.Text;

                // Kiểm tra xem số giấy tờ đã tồn tại trong CSDL chưa
                string checkIdQuery = "SELECT ID_KhachHang FROM KhachHang WHERE SoCC_KH = @SoGiayTo";
                int idKhachHang;

                using (SqlCommand checkCmd = new SqlCommand(checkIdQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@SoGiayTo", cchc);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show("Khách hàng đã tồn tại");
                    }
                    else
                    {
                        AddCustomer();
                        // MessageBox.Show("da them Khách hàng  ");
                        LoadKhachHang();
                    }
                }
            }
        }
        #endregion

        #region CapNhatVaKiemTra
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database=QLDVKS; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (lvKH.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.");
                    return;
                }

                // Get the selected customer's ID
                ListViewItem selectedItem = lvKH.SelectedItems[0];
                int selectedCustomerId = Convert.ToInt32(selectedItem.SubItems[0].Text);

                string updateQuery = @"
                UPDATE KhachHang 
                SET HoTen = @HoTen, 
                SoDT_KH = @SoDT_KH, 
                SoCC_KH = @SoCC_KH, 
                GhiChu = @GhiChu,
                Enable = @Enable
                WHERE ID_KhachHang = @ID";

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    sqlCommand.Parameters.AddWithValue("@SoDT_KH", txtSDT.Text);
                    sqlCommand.Parameters.AddWithValue("@SoCC_KH", txtCCHC.Text);
                    sqlCommand.Parameters.AddWithValue("@GhiChu", "");
                    sqlCommand.Parameters.AddWithValue("@Enable", 0); // Assuming Enable remains active after the update.
                    sqlCommand.Parameters.AddWithValue("@ID", selectedCustomerId);

                    int numOfRowsAffected = sqlCommand.ExecuteNonQuery();

                    if (numOfRowsAffected == 1)
                    {
                        // Update the selected item's details in the ListView
                        selectedItem.SubItems[1].Text = txtHoTen.Text;
                        selectedItem.SubItems[2].Text = txtSDT.Text;
                        selectedItem.SubItems[3].Text = txtCCHC.Text;
                        selectedItem.SubItems[4].Text = txtGhiChu.Text;

                        // Clear the form fields
                        txtHoTen.Text = "";
                        txtCCHC.Text = "";
                        txtSDT.Text = "";
                        txtGhiChu.Text = "";

                        // Disable buttons
                        btnCapNhat.Enabled = false;
                        btnXoa.Enabled = false;

                        MessageBox.Show("Cập nhật thông tin khách hàng thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin khách hàng. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        private void AddCustomer()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database=QLDVKS; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string tenKH = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string soGiayTo = txtCCHC.Text;
            string ghiChu = string.IsNullOrEmpty(txtGhiChu.Text) ? null : txtGhiChu.Text; // Handle null GhiChu gracefully
            int khaDung = 0; // Assuming the default state is enabled

            string insertCustomerQuery = @"
                                        INSERT INTO KhachHang (HoTen, SoDT_KH, SoCC_KH, GhiChu, Enable) 
                                        VALUES (@TenKH, @SDT, @SoGiayTo, @GhiChu, @KhaDung);
                                        SELECT SCOPE_IDENTITY();";

            try
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(insertCustomerQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@SoGiayTo", soGiayTo);
                    if (ghiChu == null)
                        cmd.Parameters.AddWithValue("@GhiChu", DBNull.Value); // Handle null GhiChu
                    else
                        cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@KhaDung", khaDung);

                    var newCustomerId = cmd.ExecuteScalar();
                    MessageBox.Show($"Thêm khách hàng thành công với ID: {newCustomerId}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CreateCustomer();
        }
        #endregion

        #region Xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database=QLDVKS; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (lvKH.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để xóa ");
                    return;
                }

                // Get the selected customer's ID
                ListViewItem selectedItem = lvKH.SelectedItems[0];
                int selectedCustomerId = Convert.ToInt32(selectedItem.SubItems[0].Text);

                string updateQuery = "UPDATE KhachHang SET Enable = 1 WHERE ID_KhachHang = @ID";

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", selectedCustomerId);

                    int numOfRowsAffected = sqlCommand.ExecuteNonQuery();

                    if (numOfRowsAffected == 1)
                    {
                        // Remove the selected item from the ListView
                        lvKH.Items.Remove(selectedItem);

                        // Clear the form fields
                        txtHoTen.Text = "";
                        txtCCHC.Text = "";
                        txtSDT.Text = "";
                        txtGhiChu.Text = "";

                        // Disable buttons
                        btnCapNhat.Enabled = false;
                        btnXoa.Enabled = false;

                        MessageBox.Show("Khách hàng đã được xóa thành công (Enable = 1).");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để xóa. Vui lòng thử lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        #endregion
        private void lvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvKH.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvKH.SelectedItems[0];

                    txtHoTen.Text = item.SubItems[1].Text;
                    txtSDT.Text = item.SubItems[2].Text;
                    txtCCHC.Text = item.SubItems[3].Text;
                    txtGhiChu.Text = item.SubItems[4].Text;

                    btnCapNhat.Enabled = true;
                    btnXoa.Enabled = true;
                    ID =item.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
