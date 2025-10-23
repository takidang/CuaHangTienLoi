using System;
using System.Security.Cryptography;
using System.Text;
using CuaHangTienLoi.DAL;

namespace CuaHangTienLoi.BUS
{
    public class TaiKhoanBUS
    {
        // Mã hóa MD5
        public static string MaHoaMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Đăng nhập
        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Vui lòng nhập đầy đủ thông tin!");

            // Gọi DAL để lấy tài khoản
            var taiKhoanDAL = new DAL.TaiKhoanDAL().LayTheoTenDangNhap(tenDangNhap);
            if (taiKhoanDAL == null)
                throw new ArgumentException("Tài khoản không tồn tại!");

            // Mã hóa mật khẩu nhập vào
            string matKhauMaHoa = MaHoaMD5(matKhau);
            if (taiKhoanDAL.MatKhau != matKhauMaHoa)
                throw new ArgumentException("Sai mật khẩu!");

            // Trả về đối tượng BUS (không có mật khẩu)
            return new TaiKhoan
            {
                TenDangNhap = taiKhoanDAL.TenDangNhap,
                HoTen = taiKhoanDAL.HoTen,
                VaiTro = taiKhoanDAL.VaiTro
            };
        }
    }
}