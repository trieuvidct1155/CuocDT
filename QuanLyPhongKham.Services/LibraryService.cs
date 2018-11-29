using QuanLyPhongKham.Model.DTO;
using QuanLyPhongKham.Model.Interfaces;
using QuanLyPhongKham.Model.UI_DTO.fTiepNhanBenhNhan;
using System;
using System.Collections.Generic;
using System.Data;
using QuanLyPhongKham.Model.UI_DTO;

namespace QuanLyPhongKham.Services
{
    public class LibraryService : IBenhNhanRepository
    {
        #region Repositories

        private IBenhNhanRepository benhNhanRepository;
        private ITaiKhoanRepository taiKhoanRepository;

        #endregion Repositories

        #region constructor

        internal LibraryService()
        {
        }

        internal LibraryService(IBenhNhanRepository benhNhanRepository, IHoaDon)
        {
            this.benhNhanRepository = benhNhanRepository;
        }

        #endregion constructor

        #region Services cho tài khoản

        public DataTable Login(string userName, string passWord)
        {
            return taiKhoanRepository.Login(userName, passWord);
        }
        public int DoiMatKhau(string userName, string passWord, string newPassWord, int manv)
        {
            return taiKhoanRepository.DoiMatKhau(userName, passWord, newPassWord, manv);
        }

        #endregion Services cho tài khoản


        #region BenhNhanServices

        public List<BenhNhan> DanhSachBenhNhan()
        {
            return benhNhanRepository.DanhSachBenhNhan();
        }

        public List<BenhNhan> TimKiemBenhNhan(string col, string info)
        {
            return benhNhanRepository.TimKiemBenhNhan(col, info);
        }

        public bool ThemBenhNhan(BenhNhan benhNhan)
        {
            return benhNhanRepository.ThemBenhNhan(benhNhan);
        }

        public bool UpdateBenhNhan(BenhNhan benhNhan)
        {
            return benhNhanRepository.UpdateBenhNhan(benhNhan);
        }

        #endregion BenhNhanServices

        #region Services cho Khach hang

        #endregion

        #region Services cho Thanh toan

        #endregion
    }
}