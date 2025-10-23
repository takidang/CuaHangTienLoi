using System;
using System.Security.Cryptography;
using System.Text;
using CuaHangTienLoi.DAL;

namespace CuaHangTienLoi.BUS
{
    public class TaiKhoanBUS
    {
        // Mã hóa MD5
      

        // Đăng nhập
        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Vui lòng nhập đầy đủ thông tin!");

            var taiKhoanDAL = new DAL.TaiKhoanDAL().LayTheoTenDangNhap(tenDangNhap);
            if (taiKhoanDAL == null)
                throw new ArgumentException("Tài khoản không tồn tại!");

            // SO SÁNH TRỰC TIẾP MẬT KHẨU (KHÔNG MÃ HÓA)
            if (taiKhoanDAL.MatKhau != matKhau)
                throw new ArgumentException("Sai mật khẩu!");

            return new TaiKhoan
            {
                TenDangNhap = taiKhoanDAL.TenDangNhap,
                HoTen = taiKhoanDAL.HoTen,
                VaiTro = taiKhoanDAL.VaiTro
            };
        }
    }
}