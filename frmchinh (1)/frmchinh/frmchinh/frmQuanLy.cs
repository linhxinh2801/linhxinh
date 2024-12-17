using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmchinh
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        

        

        private void btnQuanLyNV_Click_1(object sender, EventArgs e)
        {
            frmQuanLynhanvien frmQLNV = new frmQuanLynhanvien();
            frmQLNV.Show();
        }

        private void btnBaoCaoTK_Click_1(object sender, EventArgs e)
        {
            frmbaocaothongke frmBCTK = new frmbaocaothongke();
            frmBCTK.Show();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {

            LichSuHD ls = new LichSuHD();
            ls.Show();
        }

        private void btnQLDV_Click(object sender, EventArgs e)
        {
            frmDanhSachDVKS dv = new frmDanhSachDVKS();
            dv.Show();
        }


        //private void btnDangXuat_Click(object sender, EventArgs e)
        //{
        //    DangNhap dangNhap = new DangNhap();
        //    DangNhap.Show();
        //}

        //private void btnLichSu_Click(object sender, EventArgs e)
        //{
        //    LichSu lichSu = new LichSu();
        //    lichSu.Show();
        //}

        //private void btnDoiMatKhau_Click(object sender, EventArgs e)
        //{
        //    frmDoiMatKhau frmDMK = new frmDoiMatKhau();
        //    frmDMK.Show();
        //}
    }
}

