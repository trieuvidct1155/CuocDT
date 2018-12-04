﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDT.Model.DTO;

namespace QuanLyDT.Model.Interfaces
{
    public interface IKhachHangRepository
    {
        List<KhachHang> DanhSachKH();
        List<KhachHang> TimKiemKH(string col, string info);
        bool ThemKH(KhachHang khachHang);
        bool UpdateKH(KhachHang khachHang);
        bool UpdateKHStatus(KhachHang khachHang);
    }
}
