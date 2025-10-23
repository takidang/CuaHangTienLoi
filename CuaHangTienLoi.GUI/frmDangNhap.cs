using System;
using System.Windows.Forms;
using CuaHangTienLoi.BUS;

namespace CuaHangTienLoi.GUI
{
    public partial class frmDangNhap : Form
    {
        public TaiKhoan TaiKhoanDangNhap { get; private set; }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtTenDangNhap.Text.Trim();
                string mk = txtMatKhau.Text;

                var bus = new TaiKhoanBUS();
                TaiKhoanDangNhap = bus.DangNhap(ten, mk);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chức năng đăng ký sẽ được thêm sau!", "Thông báo");
            // Bạn có thể mở frmDangKy ở đây sau này
        }
    }
}