﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDT.Model.DTO;

namespace QuanLyDT.Model.Interfaces
{
    public interface ISimRepository
    {
        List<SimGUI> DanhSachSim();
        List<Sim> TimKiemMaSimMax();
        List<SimGUI> TimKiemSim(string col, string info);
        List<Sim> TimKiemSimSo(string info);
        bool ThemSim(Sim sim);
        bool UpdateSim(Sim sim);
    }
}
