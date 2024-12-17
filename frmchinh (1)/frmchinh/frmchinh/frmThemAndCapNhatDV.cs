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
using System.Xml.Linq;

namespace frmchinh
{
    public partial class frmThemAndCapNhatDV : Form
    {
        public frmThemAndCapNhatDV()
        {
            InitializeComponent();
        }
        private void InitValues()
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID_LoaiDV,TenLoai FROM LoaiDV";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();

            adapter.Fill(ds, "LoaiDV");

            cbbLoaiDV.DataSource = ds.Tables["LoaiDV"];
            cbbLoaiDV.DisplayMember = "TenLoai";
            cbbLoaiDV.ValueMember = "ID_LoaiDV";

            conn.Close();
            conn.Dispose();
        }
        private void ResetText()
        {           
            txtGhiChu.ResetText();
            txtMaDV.ResetText();
            txtMaDV.ResetText();
            cbbLoaiDV.ResetText();
            nudDonGia.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE INSERTDichVu @ID_DichVu OUTPUT, @ID_LoaiDV, @TenDV,@DonGia, @GhiChu, @Enable";

                // Thêm tham số vào đối tượng Command
                cmd.Parameters.Add("@ID_DichVu", SqlDbType.Int);
                cmd.Parameters.Add("@ID_LoaiDV", SqlDbType.Int);
                
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar,30);
                cmd.Parameters.Add("@DonGia", SqlDbType.Float);
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar,3000);
                cmd.Parameters.Add("@Enable", SqlDbType.TinyInt);

                cmd.Parameters["@ID_DichVu"].Direction = ParameterDirection.Output;

                // Truyền giá trị vào thủ tục qua tham số               
                cmd.Parameters["@ID_LoaiDV"].Value = cbbLoaiDV.SelectedValue;
                cmd.Parameters["@TenDV"].Value = txtTenMatHang.Text;
                cmd.Parameters["@DonGia"].Value = nudDonGia.Value;
               
                cmd.Parameters["@GhiChu"].Value = txtGhiChu.Text;
                cmd.Parameters["@Enable"].Value = 0;


                // mở kết nối
                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                // Thông báo kết quả
                if (numRowAffected > 0)
                {
                    string dichvuID = cmd.Parameters["@ID_DichVu"].Value.ToString();

                    MessageBox.Show("Thành công thêm, ID_DichVu = " + dichvuID, "Message");

                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

                // đóng kết nối
                conn.Close();
                conn.Dispose();
            }

            // Bắt lỗi SQL và các lỗi khác
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Eccor");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            this.Close();
        }
        public void DisplayDichVuInfo(DataRowView rowView)
        {
            try
            {
                txtMaDV.Text = rowView["ID_DichVu"].ToString();
                txtTenMatHang.Text = rowView["TenDV"].ToString();
                txtGhiChu.Text = rowView["GhiChu"].ToString();            
                nudDonGia.Text = rowView["DonGia"].ToString();

                cbbLoaiDV.SelectedIndex = -1;

                // chọn nhóm món ăn tương ứng
                for (int index = 0; index < cbbLoaiDV.Items.Count; index++)
                {
                    DataRowView cat = cbbLoaiDV.Items[index] as DataRowView;
                    if (cat["ID_LoaiDV"].ToString() == rowView["ID_LoaiDV"].ToString())
                    {
                        cbbLoaiDV.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }
        private void frmThemDV_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateDichVu  @ID_DichVu, @ID_LoaiDV, @TenDV,@DonGia, @GhiChu, @Enable";


                // Thêm tham số vào đối tượng Command
                cmd.Parameters.Add("@ID_DichVu", SqlDbType.Int);
                cmd.Parameters.Add("@ID_LoaiDV", SqlDbType.Int);

                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@DonGia", SqlDbType.Float);
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 3000);
                cmd.Parameters.Add("@Enable", SqlDbType.TinyInt);



                // Truyền giá trị vào thủ tục qua tham số               
                cmd.Parameters["@ID_DichVu"].Value = int.Parse(txtMaDV.Text);
                cmd.Parameters["@ID_LoaiDV"].Value = cbbLoaiDV.SelectedValue;
                cmd.Parameters["@TenDV"].Value = txtTenMatHang.Text;
                cmd.Parameters["@DonGia"].Value = nudDonGia.Value;

                cmd.Parameters["@GhiChu"].Value = txtGhiChu.Text;
                cmd.Parameters["@Enable"].Value = 0;


                //mở kết nối.
                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                // Thông báo kết quả
                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully updating Dich Vu", "Message");

                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Updating Dich Vu failed");
                }

                // đóng kết nối
                conn.Close();
                conn.Dispose();
            }
            // Bắt lỗi SQL và các lỗi khác
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Eccor");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }
