using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDT.Model.DTO
{
    public class Sim
    {
        public Sim(int maSim, string soSim, bool status)
        {
            MaSim = maSim;
            SoSim = soSim;
            Status = status;
        }

        public Sim(DataRow row)
        {
            MaSim = (int)row["MaSim"];
            SoSim = (string)row["SoSim"];
            Status = (bool)row["Status"];
        }

        public Sim() { }



        public int MaSim { get; set; }
        public string SoSim { get; set; }
        public bool Status { get; set; }
    }
}
