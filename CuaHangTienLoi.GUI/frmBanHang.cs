using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CuaHangTienLoi.BUS;
using CuaHangTienLoi.DAL.Models;

namespace CuaHangTienLoi.GUI
{
    public partial class frmBanHang : Form
    {
        private bool _daDangNhap = false;

        public frmBanHang()
        {
            InitializeComponent();
            KhoaGiaoDien();
            HienThiFormDangNhap();
        }

        private void KhoaGiaoDien()
        {
            // Vô hiệu hóa tất cả chức năng
            dgvSanPham.Visible = false;
            dgvGioHang.Visible = false;
            btnThemVaoGio.Enabled = false;
            btnXoaKhoiGio.Enabled = false;
            btnThanhToan.Enabled = false;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            // Ẩn menu quản lý và báo cáo
            quảnLýToolStripMenuItem.Visible = false;
            báoCáoToolStripMenuItem.Visible = false;
        }

        private void MoKhoaGiaoDien()
        {
            lblChao.Text = $"Xin chào, {Global.TaiKhoanHienTai.HoTen} ({Global.TaiKhoanHienTai.VaiTro})";
            dgvSanPham.Visible = true;
            dgvGioHang.Visible = true;
            btnThemVaoGio.Enabled = true;
            btnXoaKhoiGio.Enabled = true;
            btnThanhToan.Enabled = true;

            // Chỉ nhân viên mới thấy menu quản lý & báo cáo
            bool laNhanVien = (Global.TaiKhoanHienTai.VaiTro == "NhanVien");
            quảnLýToolStripMenuItem.Visible = laNhanVien;
            báoCáoToolStripMenuItem.Visible = laNhanVien;

            _daDangNhap = true;
            TaiDanhSachSanPham();
        }

        private void TaiDanhSachSanPham()
        {
            try
            {
                var list = new SanPhamBUS().LayDanhSach();
                dgvSanPham.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void HienThiFormDangNhap()
        {
            using (var frmLogin = new frmDangNhap())
            {
                var result = frmLogin.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    Global.TaiKhoanHienTai = frmLogin.TaiKhoanDangNhap;
                    MoKhoaGiaoDien();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // === MENU ===
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Global.TaiKhoanHienTai = null;
                KhoaGiaoDien();
                HienThiFormDangNhap();
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // new frmQuanLySanPham().ShowDialog(this);
        }

        private void xemDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new frmBaoCaoDoanhThu().ShowDialog(this);
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThanhToan.PerformClick();
        }

        // Ngăn đóng ứng dụng khi chưa đăng nhập
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (!_daDangNhap && m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                Application.Exit();
                return;
            }
            base.WndProc(ref m);
        }
    }
}