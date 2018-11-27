using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model.DTO;

namespace QuanLyPhongKham.Model.Interfaces
{
    interface IKhachHangRepository
    {
        List<KhachHang> DanhSachKH();
        List<KhachHang> TimKiemKH(string col, string info);
        bool ThemBenhNhan(KhachHang khachHang);
        bool UpdateBenhNhan(KhachHang khachHang);
    }
}
