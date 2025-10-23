using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangTienLoi.DAL.Models
{
    public class HoaDonInfo
    {
        public int MaHD { get; set; }
        public string TenKhach { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
    }
}
