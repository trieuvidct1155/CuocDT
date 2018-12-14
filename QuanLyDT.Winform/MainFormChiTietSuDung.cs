using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using QuanLyDT.Model.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDT.Services;
using QuanLyDT.Infrastructure;

namespace QuanLyDT.Winform
{
    public partial class MainFormChiTietSuDung : Form
    {
        private LibraryService libraryService;
        private int masim;
        public MainFormChiTietSuDung(int masim)
        {
            InitializeComponent();
            this.masim = masim;
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }

        private void MainFormChiTietSuDung_Load(object sender, EventArgs e)
        {
            LoadSuDung();

        }
        private void LoadSuDung()
        {
            List<CuocGoi>list = libraryService.DanhSachCuocGoi(masim);
            dgvdsthuoc.Rows.Clear();
            dgvdsthuoc.Refresh();
            foreach (CuocGoi item in list)
            {
                dgvdsthuoc.Rows.Add(item.MaSim, item.TG_BatDau, item.TG_KetThuc,item.SoPhutSD);
            }
        }

    }
}
