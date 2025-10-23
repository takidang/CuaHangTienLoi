using System;
using System.Data.SqlClient;
using CuaHangTienLoi.DAL.Models;

namespace CuaHangTienLoi.DAL
{
    public class TaiKhoanDAL
    {
        public Models.TaiKhoan LayTheoTenDangNhap(string tenDangNhap)
        {
            string query = "SELECT TenDangNhap, MatKhau, HoTen, VaiTro FROM TaiKhoan WHERE TenDangNhap = @Ten";

            using (SqlConnection conn = new SqlConnection(DataAccessHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ten", tenDangNhap);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Models.TaiKhoan
                            {
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}