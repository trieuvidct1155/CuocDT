using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    class Sim
    {
        public Sim(int maHD, int maSim, DateTime tgDK, decimal chiPhi, int maKH)
        {
            MaHD = maHD;
            MaSim = maSim;
            TG_DangKy = tgDK;
            ChiPhi = chiPhi;
            MaKH = maKH;
        }

        public Sim(DataRow row)
        {
            MaHD = (int)row["MAHD"];
            MaSim = (int)row["MaSim"];
            TG_DangKy = (DateTime)row["TG_DangKy"];
            ChiPhi = (decimal)row["ChiPhi"];
            MaKH = (int)row["MaKH"];
        }

        public Sim() { }



        public int MaHD { get; set; }
        public int MaSim { get; set; }
        public DateTime TG_DangKy { get; set; }
        public decimal ChiPhi { get; set; }
        public int MaKH { get; set; }
    }
}
