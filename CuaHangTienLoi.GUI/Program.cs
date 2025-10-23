using System;
using System.Windows.Forms;
using CuaHangTienLoi.GUI;

namespace CuaHangTienLoi.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mở form bán hàng (sẽ tự gọi đăng nhập)
            Application.Run(new frmBanHang());
        }
    }
}