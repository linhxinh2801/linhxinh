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
    public partial class CT_HD : Form
    {
        public CT_HD()
        {
            InitializeComponent();
        }
        public void LoadFood(int ID_HD)
        {
            string connectionString = "server=DESKTOP-8LJR7DI\\SQLEXPRESS; database = QLDVKS; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM HoaDon WHERE ID_HD = " + ID_HD;
            sqlConnection.Open();
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Chi tiết hóa đơn: " + catName;
            sqlCommand.CommandText = "SELECT * FROM CT_HD WHERE ID_HD = " + ID_HD;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("ChiTiet");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }
        //private void DisplayCategory(SqlDataReader reader)
        //{
        //	lvDSHoaDon.Items.Clear();
        //	while (reader.Read())
        //	{
        //		//ID_NV,ID_KhachHang,NgayLap,ThanhTien,GiamGia,Coc,TongTien
        //		ListViewItem item = new ListViewItem(reader["ID_NV"].ToString());
        //		lvDSHoaDon.Items.Add(item);
        //		item.SubItems.Add(reader["ID_KhachHang"].ToString());
        //		item.SubItems.Add(reader["NgayLap"].ToString());
        //		item.SubItems.Add(reader["ThanhTien"].ToString());
        //		item.SubItems.Add(reader["GiamGia"].ToString());
        //		item.SubItems.Add(reader["Coc"].ToString());
        //		item.SubItems.Add(reader["TongTien"].ToString());
        //	}
        //}
    }
}
