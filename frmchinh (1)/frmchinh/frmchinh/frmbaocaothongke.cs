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
    public partial class frmbaocaothongke : Form
    {
        public frmbaocaothongke()
        {
            InitializeComponent();
        }
        private void LoadBaoCaoDoanhThu()
        {
            // Get the month from DateTimePicker
            int thang = dtpTuNgay.Value.Month;

            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            string query = @"
       SELECT 
                h.ID_HD, 
                k.HoTen AS TenKhachHang, 
                nv.HoTen AS TenNhanVien, 
                h.NgayLap, 
                MONTH(h.NgayLap) AS Thang,
                h.ThanhTien, 
                h.GiamGia, 
                h.Coc, 
                h.TongTien
            FROM HoaDon h
            JOIN KhachHang k ON h.ID_KhachHang = k.ID_KhachHang
            JOIN NhanVien nv ON h.ID_NV = nv.ID_NV
            WHERE MONTH(h.NgayLap) = @Thang;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // Add parameter to the query
                command.Parameters.AddWithValue("@Thang", thang);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dgvBaoCao.DataSource = dataTable;
            }
        }

        private void frmbaocaothongke_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1); // Mặc định: 1 tháng trước
        }
        private void FilterDichVu(string filterType)
        {
            if (dgvBaoCao.DataSource is DataTable dt)
            {
                DataRow resultRow = null;

                if (filterType == "Max")
                {
                    resultRow = dt.AsEnumerable()
                                  .OrderByDescending(row => row.Field<decimal>("TongDoanhThu"))
                                  .FirstOrDefault();
                }
                else if (filterType == "Min")
                {
                    resultRow = dt.AsEnumerable()
                                  .OrderBy(row => row.Field<decimal>("TongDoanhThu"))
                                  .FirstOrDefault();
                }

                if (resultRow != null)
                {
                    MessageBox.Show($"Dịch vụ: {resultRow["TenDV"]}\nDoanh thu: {resultRow["TongDoanhThu"]:C}",
                                    filterType == "Max" ? "Dịch vụ nhiều nhất" : "Dịch vụ ít nhất",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lọc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXemBC_Click(object sender, EventArgs e)
        {

            LoadBaoCaoDoanhThu();
            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            // Lặp qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dgvBaoCao.Rows)
            {
                // Kiểm tra dòng không rỗng (không phải dòng mới hoặc dòng trống)
                if (!row.IsNewRow)
                {
                    try
                    {
                        // Lấy giá trị từ các cột Thành Tiền, Giảm Giá và Cọc
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                        decimal giamGia = Convert.ToDecimal(row.Cells["GiamGia"].Value);
                        decimal coc = Convert.ToDecimal(row.Cells["Coc"].Value);

                        // Tính Tổng Tiền
                        decimal tongTien = thanhTien - giamGia + coc;

                        // Cập nhật giá trị cột Tổng Tiền
                        row.Cells["TongTien"].Value = tongTien;
                        txtTongDoanhThu.Text = tongTien.ToString();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý nếu có lỗi (ví dụ: giá trị không hợp lệ)
                        MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message);
                    }
                }
            }
        }

        private void rdCaoThap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCaoThap.Checked)
            {
                // Tính Tổng Tiền và sắp xếp theo thứ tự giảm dần
                CalculateTotalAmount();
                SortByTotalAmountDescending();
            }
        }
        private void SortByTotalAmountAscending()
        {
            dgvBaoCao.Sort(dgvBaoCao.Columns["TongTien"], System.ComponentModel.ListSortDirection.Ascending);
        }
        private void SortByTotalAmountDescending()
        {
            dgvBaoCao.Sort(dgvBaoCao.Columns["TongTien"], System.ComponentModel.ListSortDirection.Descending);
        }

        private void rdThapCao_CheckedChanged(object sender, EventArgs e)
        {

            if (rdThapCao.Checked)
            {
                // Tính Tổng Tiền và sắp xếp theo thứ tự giảm dần (từ lớn đến nhỏ)
                CalculateTotalAmount();
                SortByTotalAmountAscending();
            }
        }

        
    }
}
