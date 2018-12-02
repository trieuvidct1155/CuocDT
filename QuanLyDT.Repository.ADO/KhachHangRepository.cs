﻿using QuanLyDT.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDT.Model.DTO;
using System.Data;

namespace QuanLyDT.Repository.ADO
{
    public class KhachHangRepository : IKhachHangRepository
    {
        /// <summary>
        /// lấy danh sách khach hang trong database
        /// </summary>
        /// <returns></returns>
        public List<KhachHang> DanhSachKH()
        {
            List<KhachHang> list = new List<KhachHang>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_LoadAllKhachHang");

            foreach (DataRow row in table.Rows)
            {
                list.Add(new KhachHang(row));
            }
            return list;
        }

        /// <summary>
        /// thêm khach hang vào database
        /// </summary>
        /// <param name="khachhang"></param>
        /// <returns></returns>
        public bool ThemKH(KhachHang khachHang)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXEC dbo.SP_TaoKH @Ten , @NgheNghiep , @Cmnd , @DiaChi , @Status ",
                                        new object[] { khachHang.TenKH,
                          khachHang.NgheNghiep,khachHang.CMND, khachHang.DiaChi, khachHang.Status});
            return row > 0;
        }

        /// <summary>
        /// tìm kiếm khach hang, sử dụng SP_TimKiemKH
        /// </summary>
        /// <param name="col">cột trong database</param>
        /// <param name="info">thông tin cần tìm</param>
        /// <returns></returns>
        public List<KhachHang> TimKiemKH(string col, string info)
        {
           
            List<KhachHang> list = new List<KhachHang>();
            DataTable table = null;
            int text = int.Parse(info);
            if (col == "MaKH")
            {
                 table = DataProvider.Instane.ExecuteReader(" EXEC  dbo.SP_TimKiemKHByMa @ThongTin ", new object[] { text });
            }
            else
            {
                info = "%" + info + "%";
                table = DataProvider.Instane.ExecuteReader(" EXEC  dbo.SP_TimKiemKHByTen @ThongTin", new object[] { info });
            }

            foreach (DataRow row in table.Rows)
            {
                list.Add(new KhachHang(row));
            }
            return list;
        }

        /// <summary>
        /// Cập nhật thông tin cho khach hang
        /// </summary>
        /// <param name="benhNhan"></param>
        /// <returns></returns>
        public bool UpdateKH(KhachHang khachhang)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXEC dbo.SP_UpdateKH @MaKH , @TenKH  , @NgheNghiep , @CMND , @DiaChi , @Status ",
                          new object[] { khachhang.MaKH, khachhang.TenKH,khachhang.NgheNghiep, khachhang.CMND
                          , khachhang.DiaChi, khachhang.Status});
            return row > 0;
        }
    }
}
