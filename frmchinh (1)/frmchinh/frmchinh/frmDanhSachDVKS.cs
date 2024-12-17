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
    public partial class frmDanhSachDVKS : Form
    {
        private DataTable dichVuTable;
        public frmDanhSachDVKS()
        {
            InitializeComponent();
        }

        private void LoadDichVu()
        {

            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT ID_LoaiDV,TenLoai FROM LoaiDV";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            
            da.Fill(dt);

            conn.Close();
            conn.Dispose();

            cbbLoaiDV.DataSource = dt;

            cbbLoaiDV.DisplayMember = "TenLoai";

            cbbLoaiDV.ValueMember = "ID_LoaiDV";
        }


        private void LoadDSDV()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT DichVu.ID_DichVu,DichVu.ID_LoaiDV,TenDV,DonGia,GhiChu FROM DichVu,LoaiDV WHERE DichVu.ID_LoaiDV=LoaiDV.ID_LoaiDV";
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Kiểm tra nếu DataTable có dữ liệu
                if (dt.Rows.Count > 0)
                {
                    dgvDanhSachDichVu.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }
        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbbLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDanhSachDVKS_Load(object sender, EventArgs e)
        {
            this.LoadDichVu();
            this.LoadDSDV();
            
            
        }

        private void btnTh_Click(object sender, EventArgs e)
        {
            frmThemAndCapNhatDV ThemCapNhatForm = new frmThemAndCapNhatDV();
            ThemCapNhatForm.FormClosed += new FormClosedEventHandler(ThemCapNhatForm_FormClosed);

            ThemCapNhatForm.Show(this);
            
        }
        void ThemCapNhatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbLoaiDV.SelectedIndex;
            cbbLoaiDV.SelectedIndex = -1;
            cbbLoaiDV.SelectedIndex = index;
        }
        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachDichVu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachDichVu.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                frmThemAndCapNhatDV ThemCapNhatForm = new frmThemAndCapNhatDV();
                ThemCapNhatForm.FormClosed += new FormClosedEventHandler(ThemCapNhatForm_FormClosed);

                ThemCapNhatForm.Show(this);
                ThemCapNhatForm.DisplayDichVuInfo(rowView);
            }
        }

        private void dgvDanhSachDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            string selectedValue = cbbLoaiDV.SelectedValue?.ToString(); // Lấy giá trị từ ComboBox
            bool isSearchByCombo = !string.IsNullOrEmpty(selectedValue);

            // Kiểm tra điều kiện tìm kiếm
            if (!isSearchByCombo)
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm hoặc chọn dịch vụ từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xây dựng truy vấn tìm kiếm
            cmd.CommandText = "SELECT DichVu.ID_DichVu,DichVu.ID_LoaiDV,TenDV,DonGia,GhiChu " +
                              "FROM DichVu, LoaiDV " +
                              "WHERE DichVu.ID_LoaiDV = LoaiDV.ID_LoaiDV " +
                             (isSearchByCombo ? "AND LoaiDV.ID_LoaiDV = @SelectedID " : "");

            if (isSearchByCombo)
            {
                cmd.Parameters.AddWithValue("@SelectedID", selectedValue);
            }

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvDanhSachDichVu.DataSource = dt;
                    lblTongDichVu.Text = dt.Rows.Count.ToString();
                    lblLoaiDV.Text = cbbLoaiDV.Text;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDanhSachDichVu.DataSource = null; // Xóa dữ liệu hiện có nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối hoặc truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDSDV();
        }

        private void tsmXoaDV_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachDichVu.SelectedRows.Count > 0) // Kiểm tra nếu có hàng được chọn
            {

                string selectedID = dgvDanhSachDichVu.SelectedRows[0].Cells["ID_DichVu"].Value.ToString();

                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database= QLDVKS; Integrated Security=true;";
                // Bước 1: Xóa các bản ghi liên quan trong bảng CT_HD
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo câu lệnh xóa
                    string query = "DELETE FROM CT_HD WHERE ID_DV = @ID";
                    using (SqlCommand sqlCommand = new SqlCommand(query, conn))
                    {
                        // Truyền tham số vào câu truy vấn để tránh SQL Injection
                        sqlCommand.Parameters.AddWithValue("@ID", selectedID);

                        // Thực thi câu lệnh
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa thành công mục được chọn.");

                            // Xóa hàng khỏi DataGridView
                            dgvDanhSachDichVu.Rows.Remove(dgvDanhSachDichVu.SelectedRows[0]);
                        }

                    }
                    //Bước 2: Xóa bản ghi trong bảng DichVu
                    string deleteDichVuQuery = "DELETE FROM DichVu WHERE ID_DichVu = @ID";
                    using (SqlCommand cmdDichVu = new SqlCommand(deleteDichVuQuery, conn))
                    {
                        cmdDichVu.Parameters.AddWithValue("@ID", selectedID);
                        int rowsAffected = cmdDichVu.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {                           
                            dgvDanhSachDichVu.Rows.Remove(dgvDanhSachDichVu.SelectedRows[0]);
                            MessageBox.Show("Đã xóa thành công mục được chọn.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa mục được chọn.");
                        }
                    }
                }
            }
        }



        private void txtSearchByName_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearchByName.Text.Trim(); // Lấy giá trị tìm kiếm

            // Kết nối cơ sở dữ liệu
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database=QLDVKS; Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Tạo câu truy vấn có điều kiện tìm kiếm
                string query = "SELECT * FROM DichVu WHERE TenDV LIKE @SearchText";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%"); // Sử dụng tham số để tránh SQL Injection

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable filteredTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(filteredTable); // Lấy dữ liệu phù hợp từ database

                    // Cập nhật dữ liệu vào DataGridView
                    dgvDanhSachDichVu.DataSource = filteredTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi truy vấn dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

