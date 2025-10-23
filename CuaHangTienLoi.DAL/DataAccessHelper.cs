using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace CuaHangTienLoi.DAL
{
    public class DataAccessHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyShopConnection"].ConnectionString;
        }
    }
}