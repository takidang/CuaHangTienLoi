using System.Collections.Generic;
using CuaHangTienLoi.DAL;

namespace CuaHangTienLoi.BUS
{
    public class SanPhamBUS
    {
        public List<DAL.Models.SanPham> LayDanhSach()
        {
            return new SanPhamDAL().GetAll();
        }
    }
}