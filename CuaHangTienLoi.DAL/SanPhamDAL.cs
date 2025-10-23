using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CuaHangTienLoi.DAL.Models;

namespace CuaHangTienLoi.DAL
{
    public class SanPhamDAL
    {
        public List<SanPham> GetAll()
        {
            List<SanPham> list = new List<SanPham>();
            string query = "SELECT MaSP, TenSP, Gia, SoLuongTon FROM SanPham";

            using (SqlConnection conn = new SqlConnection(DataAccessHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SanPham
                            {
                                MaSP = (int)reader["MaSP"],
                                TenSP = reader["TenSP"].ToString(),
                                Gia = (decimal)reader["Gia"],
                                SoLuongTon = (int)reader["SoLuongTon"]
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}