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
    public partial class Form1 : Form
    {string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";

        public static string ID_KH = null;
        public Form1()
        {
            InitializeComponent();
        }
        //private void LoadChiTietHoaDon()
        //{
        //    string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
        //    lvCTHoaDon.Items.Clear();
            
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    string query = "SELECT ID_HD, ID_DV, SoLuong, ThanhTien, Ngay FROM CT_HD ";
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = query;
        //    sqlConnection.Open();
        //    SqlDataReader reader = sqlCommand.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        ListViewItem item = new ListViewItem(reader["ID_HD"].ToString());
        //        item.SubItems.Add(reader["ID_DV"].ToString());
        //        item.SubItems.Add(reader["SoLuong"].ToString());
        //        item.SubItems.Add(reader["ThanhTien"].ToString());
        //        item.SubItems.Add(reader["Ngay"].ToString());
        //        lvCTHoaDon.Items.Add(item);

        //    }
        //    sqlConnection.Close();
        //    sqlConnection.Dispose();

        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            //.LoadChiTietHoaDon();
            LoadServiceList();
            InitializeRoomTypeComboBox();          
        }
        #region TaiDanhSachDichVu + Tim kiem theo loai dich vu
        int ID;
        public void LoadServiceList()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy danh sách loại dịch vụ
                string getServicesQuery = @"
                    SELECT l.ID_LoaiDV, l.TenLoai, d.TenDV, d.DonGia, d.GhiChu, l.Enable, d.Enable
                    FROM LoaiDV l
                    JOIN DichVu d ON l.ID_LoaiDV = d.ID_LoaiDV
                    WHERE l.Enable = 0 AND d.Enable = 0
                    ORDER BY l.ID_LoaiDV, d.TenDV";

                SqlCommand getServicesCmd = new SqlCommand(getServicesQuery, conn);
                SqlDataAdapter serviceAdapter = new SqlDataAdapter(getServicesCmd);
                DataTable serviceTable = new DataTable();
                serviceAdapter.Fill(serviceTable);
                int soHang = serviceTable.Rows.Count;
                // Duyệt qua từng loại dịch vụ (LoạiDV) và tạo GroupBox
                int currentCategoryId = -1;
                GroupBox currentGroupBox = null;
                FlowLayoutPanel servicePanel = null;
                    int i = 0;
                foreach (DataRow serviceRow in serviceTable.Rows)
                {
                    int categoryId = Convert.ToInt32(serviceRow["ID_LoaiDV"]);
                    string categoryName = serviceRow["TenLoai"].ToString();
                    string serviceName = serviceRow["TenDV"].ToString();
                    float servicePrice = Convert.ToSingle(serviceRow["DonGia"]);
                    i++;
                    ID = categoryId;
                    // If we encounter a new category, create a new GroupBox (1 danh mục mới thì sẽ tạo ra một groupbox mới)
                    if (categoryId != currentCategoryId)
                    {
                        // If there was a previous category, add the panel to the flow layout
                        if (currentGroupBox != null)
                        {
                            currentGroupBox.Controls.Add(servicePanel);
                            flowLayoutPanel1.Controls.Add(currentGroupBox);
                        }

                        // Create a new GroupBox for the new category
                        currentGroupBox = new GroupBox
                        {
                            Text = categoryName,
                            Padding = new Padding(5),
                            Margin = new Padding(5)
                        };

                        // Create a new FlowLayoutPanel for services in this category
                        servicePanel = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            AutoScroll = true
                        };

                        currentCategoryId = categoryId;
                    }

                    // Tạo nút dịch vụ cho mỗi dịch vụ
                    Button serviceButton = new Button
                    {
                        Text = $"{serviceName}\n\nGiá: {servicePrice}",
                        Size = new Size(110, 70),
                        Tag = new { ServiceName = serviceName, Price = servicePrice },
                        //  ContextMenuStrip = contextMenuStrip1
                       
                    };
                    serviceButton.Click += DichVu_Click;
                    serviceButton.Margin = new Padding(3);
                    serviceButton.TextAlign = ContentAlignment.MiddleLeft;

                    // Thêm sự kiện Click cho mỗi nút dịch vụ
                   // serviceButton.Click += ServiceButton_Click;

                    // Thêm hình ảnh vào nút dịch vụ
                    try
                    {
                      //  string imagePath = $"C:\\Images\\Services\\{categoryId}.png"; // Assuming each category has an image
                      //  serviceButton.Image = Image.FromFile(imagePath);
                        //serviceButton.ImageAlign = ContentAlignment.MiddleRight;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                    }
                     currentGroupBox.Height = soHang/4 *50 +40;
                currentGroupBox.Width = 550;
                    // Thêm nút dịch vụ vào FlowLayoutPanel
                    servicePanel.Controls.Add(serviceButton);
                }
               
                // Add the last category GroupBox to the flow layout
                if (currentGroupBox != null)
                {
                    currentGroupBox.Controls.Add(servicePanel);
                    flowLayoutPanel1.Controls.Add(currentGroupBox);
                }

                conn.Close();
            }
        }
        private void DichVu_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Tag != null)
            {
                dynamic serviceInfo = clickedButton.Tag;
                string serviceName = serviceInfo.ServiceName; // Lấy tên dịch vụ từ Tag

                // Tạo kết nối cơ sở dữ liệu
                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn thông tin chi tiết dịch vụ
                    string query = @"
                SELECT dv.ID_DichVu, dv.TenDV, dv.DonGia, lv.TenLoai, dv.GhiChu
                FROM DichVu dv
                JOIN LoaiDV lv ON dv.ID_LoaiDV = lv.ID_LoaiDV
                WHERE dv.TenDV = @TenDV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDV", serviceName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy thông tin từ kết quả truy vấn
                                int serviceId = Convert.ToInt32(reader["ID_DichVu"]);
                                string serviceNameFromDb = reader["TenDV"].ToString();
                                string serviceCategory = reader["TenLoai"].ToString();
                                float servicePrice = Convert.ToSingle(reader["DonGia"]);
                                string notes = reader["GhiChu"].ToString();

                                // Thêm thông tin vào ListView
                                ListViewItem serviceItem = new ListViewItem(serviceId.ToString()); // ID dịch vụ là cột đầu tiên
                                serviceItem.SubItems.Add(serviceNameFromDb);                       // Tên dịch vụ là cột thứ hai
                                serviceItem.SubItems.Add(serviceCategory);                        // Tên loại dịch vụ là cột thứ ba
                                serviceItem.SubItems.Add(servicePrice.ToString());             // Giá là cột thứ tư
                                serviceItem.SubItems.Add(notes);                                  // Ghi chú là cột thứ năm

                                lvDichVu.Items.Add(serviceItem);

                                // Thông báo thành công
                                MessageBox.Show($"Dịch vụ '{serviceNameFromDb}' đã được thêm vào danh sách.",
                                                "Thông báo",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Nếu không tìm thấy dịch vụ
                                MessageBox.Show($"Không tìm thấy thông tin dịch vụ '{serviceName}'.",
                                                "Thông báo",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin dịch vụ.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }



        private void InitializeRoomTypeComboBox()
        {
            cbbDichVu.Items.Clear();
            cbbDichVu.Items.Add("Tất cả"); // Add "Tất cả" to show all rooms

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT TenLoai FROM LoaiDV WHERE Enable = 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string roomType = reader.GetString(0);
                            if (!cbbDichVu.Items.Contains(roomType)) // Avoid duplicate entries
                            {
                                cbbDichVu.Items.Add(roomType); // Add room types to ComboBox
                            }
                        }
                    }
                }

                cbbDichVu.SelectedIndex = 0; // Set the default selection to "Tất cả"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải loại phòng: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void LoadFilteredRoomList(string serviceType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to filter services by type
                string query = @"
                              SELECT LoaiDV.TenLoai, DichVu.TenDV, DichVu.DonGia, DichVu.ID_DichVu 
                              FROM DichVu
                              INNER JOIN LoaiDV ON DichVu.ID_LoaiDV = LoaiDV.ID_LoaiDV
                              WHERE LoaiDV.TenLoai = @serviceType AND DichVu.Enable = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@serviceType", serviceType);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable serviceTable = new DataTable();
                adapter.Fill(serviceTable);

                // Clear previous items in FlowLayoutPanel
                flowLayoutPanel1.Controls.Clear();

                // Iterate through the filtered services and add buttons to the FlowLayoutPanel
                foreach (DataRow serviceRow in serviceTable.Rows)
                {
                    string serviceName = serviceRow["TenDV"].ToString();
                    decimal servicePrice = Convert.ToDecimal(serviceRow["DonGia"]);
                    int serviceId = Convert.ToInt32(serviceRow["ID_DichVu"]);

                    // Create a Button for the service
                    Button serviceButton = new Button
                    {
                        Text = $"{serviceName}\n\nGiá: {servicePrice}",
                        Size = new Size(150, 80),
                        Tag = serviceId, // Store service ID in the Tag for later use
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleLeft
                    };

                    // Add an event handler for button click
                  //  serviceButton.Click += ServiceButton_Click;

                    // Add an image to the button (based on service type if desired)
                   

                    // Add the button to the FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(serviceButton);
                }

                conn.Close();
            }
        }
        #endregion

        private void CalculateTotalAmount()
        {
            float totalAmount = 0;

            // Duyệt qua tất cả các mục trong ListView
            foreach (ListViewItem item in lvDichVu.Items)
            {
                // Lấy giá dịch vụ từ cột thứ 4 (cột Giá)
                string priceText = item.SubItems[3].Text;

                // Kiểm tra nếu giá hợp lệ (sử dụng TryParse để tránh lỗi chuyển đổi)
                if (float.TryParse(priceText, out float price))
                {
                    totalAmount = totalAmount+ price;  // Cộng dồn vào tổng tiền
                }
            }
          
            // Hiển thị tổng tiền
            txtThanhTien.Text = totalAmount.ToString();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTong_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvCTHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void mtxtSDT_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["KhachHang"];

            if (frm != null)
                frm.BringToFront();
            else
            {
                frm = new KhachHang ();
                frm.Show();
            }

        }
        static int ID_HDn;
        private void cboGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            CreateNewInvoice();
            AddInvoiceDetails();
        }

        public void CreateNewInvoice()
        {
            // Lấy thông tin từ các TextBox
            int idNhanVien = 1; // Mã nhân viên
            int idKhachHang = Convert.ToInt32(ID_KH);  // Mã khách hàng
            DateTime ngayLap = DateTime.Today;  // Ngày lập hóa đơn
            float thanhTien = float.Parse(txtThanhTien.Text);  // Tổng tiền
            float giamGia = float.Parse(txtGiamGia.Text);  // Giảm giá
            float coc = float.Parse(txtCoc.Text);  // Tiền cọc
            float tongTien = float.Parse(txtTong.Text);  // Tổng tiền thanh toán

            try
            {
                // Kết nối tới cơ sở dữ liệu
                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Bắt đầu một giao dịch
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Thêm bản ghi mới vào bảng HoaDon
                        string insertHoaDonQuery = @"
                    INSERT INTO HoaDon (ID_NV, ID_KhachHang, NgayLap, ThanhTien, GiamGia, Coc, TongTien, Enable)
                    VALUES (@ID_NV, @ID_KhachHang, @NgayLap, @ThanhTien, @GiamGia, @Coc, @TongTien, 1); 
                    SELECT SCOPE_IDENTITY();";  // Lấy ID của hóa đơn vừa tạo

                        SqlCommand insertHoaDonCmd = new SqlCommand(insertHoaDonQuery, conn, transaction);
                        insertHoaDonCmd.Parameters.AddWithValue("@ID_NV", idNhanVien);
                        insertHoaDonCmd.Parameters.AddWithValue("@ID_KhachHang", idKhachHang);
                        insertHoaDonCmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                        insertHoaDonCmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        insertHoaDonCmd.Parameters.AddWithValue("@GiamGia", giamGia);
                        insertHoaDonCmd.Parameters.AddWithValue("@Coc", coc);
                        insertHoaDonCmd.Parameters.AddWithValue("@TongTien", tongTien);

                        // Lấy ID của hóa đơn vừa tạo
                        int idHoaDon = Convert.ToInt32(insertHoaDonCmd.ExecuteScalar());
                        ID_HDn = idHoaDon;
                        // Commit giao dịch
                        transaction.Commit();

                        MessageBox.Show("Hóa đơn đã được tạo thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi xảy ra, rollback giao dịch
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
        public void AddInvoiceDetails()
        {
            try
            {
                // Lấy ID hóa đơn
                int idHoaDon = ID_HDn;

                // Kết nối tới cơ sở dữ liệu
                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Bắt đầu một giao dịch
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Duyệt qua các mục trong ListView để thêm vào bảng CT_HD
                        foreach (ListViewItem item in lvDichVu.Items)
                        {
                            int idDichVu = Convert.ToInt32(item.SubItems[0].Text);  // Lấy ID dịch vụ
                           // Lấy số lượng
                            float donGia = float.Parse(item.SubItems[3].Text);  // Lấy đơn giá

                            // Tính thành tiền của dịch vụ
                            float thanhTienDV = donGia * 1;

                            // Thêm bản ghi vào bảng CT_HD
                            string insertCTHDQuery = @"
                                            insert into CT_HD (ID_HD, ID_DV, ThanhTien, Ngay) 
                                            VALUES (@ID_HD, @ID_DV, @ThanhTien, @Ngay)";

                            SqlCommand insertCTHDCmd = new SqlCommand(insertCTHDQuery, conn, transaction);
                            insertCTHDCmd.Parameters.AddWithValue("@ID_HD", idHoaDon);
                            insertCTHDCmd.Parameters.AddWithValue("@ID_DV", idDichVu);
                            insertCTHDCmd.Parameters.AddWithValue("@ThanhTien", thanhTienDV);
                            insertCTHDCmd.Parameters.AddWithValue("@Ngay", DateTime.Today);

                            insertCTHDCmd.ExecuteNonQuery();
                        }

                        // Commit giao dịch
                        transaction.Commit();

                        MessageBox.Show("Chi tiết hóa đơn đã được thêm thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi xảy ra, rollback giao dịch
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnXemInBill_Click(object sender, EventArgs e)
        {
            Hoá_đơn_đã_lưu hd = new Hoá_đơn_đã_lưu();
            hd.ShowDialog(this);
        }

        private void cbbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoomType = cbbDichVu.SelectedItem.ToString();

            flowLayoutPanel1.Controls.Clear(); // Clear the current rooms

            if (selectedRoomType == "Tất cả")
            {
                LoadServiceList(); // Load all rooms
            }
            else
            {
                LoadFilteredRoomList(selectedRoomType); // Load rooms filtered by type
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           KhachHang khachHang = new KhachHang ();
            khachHang.ShowDialog(this);
             
            ID_KH = KhachHang.ID;
            if(ID_KH != null)
            LoadKH(ID_KH);
           
        }
        private void LoadKH(string ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                ID_KhachHang,
                HoTen,
                SoDT_KH,
                SoCC_KH,
                GhiChu
            FROM 
                KhachHang
            WHERE 
                ID_KhachHang = @ID_KhachHang;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Gắn tham số ID_KhachHang
                    command.Parameters.AddWithValue("@ID_KhachHang", ID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Gán giá trị từ reader vào các TextBox
                                    txtHoTen.Text = reader["HoTen"].ToString();
                                    txtSDT.Text = reader["SoDT_KH"].ToString();
                                    txtCCHC.Text = reader["SoCC_KH"].ToString();
                                    txtGhiChu.Text = reader["GhiChu"].ToString();
                             
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            CalculateTotalAmountWithDiscount();
        }
        // Phương thức tính tổng tiền sau giảm giá
        private void CalculateTotalAmountWithDiscount()
        {
            try
            {
                // Lấy giá trị tổng tiền ban đầu từ txtThanhTien
                CalculateTotalAmount();

                float totalAmount = float.Parse(txtThanhTien.Text, System.Globalization.CultureInfo.InvariantCulture);

                // Lấy giá trị cần trừ (txtCon)
                float valueToSubtract = float.Parse(txtCoc.Text, System.Globalization.CultureInfo.InvariantCulture);

                // Lấy giá trị giảm giá từ ComboBox (cbbGiamGia)
                float discountPercentage = float.Parse(txtGiamGia.Text,System.Globalization.CultureInfo.InvariantCulture); ;
               

                // Tính số tiền giảm giá
                float discountAmount = totalAmount * (discountPercentage/100);

                // Tính tổng tiền sau giảm giá
                float finalAmount = totalAmount - valueToSubtract - discountAmount;

                // Hiển thị tổng tiền sau giảm giá vào txtThanhTien
                txtTong.Text = finalAmount.ToString(); // Định dạng tiền tệ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi trong việc tính toán tổng tiền: " + ex.Message);
            }
        }

        private void btnMoQL_Click(object sender, EventArgs e)
        {
            frmQuanLy ql = new frmQuanLy();
            ql.ShowDialog(this);
        }
    }
}
