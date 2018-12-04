    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDT.Model.DTO
{
    public class LoaiCuoc
    {
        public LoaiCuoc(TimeSpan tgBD, TimeSpan tgKT, decimal giaCuoc, bool status)
        {
            TG_BatDau = tgBD;
            TG_KetThuc = tgKT;
            GiaCuoc = giaCuoc;
            Status = status;
        }

        public LoaiCuoc(DataRow row)
        {
            TG_BatDau = (TimeSpan)row["TG_BatDau"];
            TG_KetThuc = (TimeSpan)row["TG_KetThuc"];
            GiaCuoc = (decimal)row["GiaCuoc"];
            Status = (bool)row["Status"];
        }

        public LoaiCuoc() { }

        public TimeSpan TG_BatDau { get; set; }
        public TimeSpan TG_KetThuc { get; set; }
        public decimal GiaCuoc { get; set; }
        public bool Status { get; set; }
    }
}
