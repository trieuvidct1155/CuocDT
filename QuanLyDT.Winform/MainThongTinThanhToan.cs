using QuanLyDT.Infrastructure;
using QuanLyDT.Model.DTO;
using QuanLyDT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDT.Winform
{
    public partial class MainThongTinThanhToan : Form
    {
        private bool isNew = true;
        private int IDKhachHang;
        private KhachHang khachHang;
        private HoaDonDK hoaDon;
        private LibraryService libraryService;

        public MainThongTinThanhToan()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor cho việc update khách hàng
        /// </summary>
        /// <param name="title"></param>
        /// <param name="btnText"></param>
        /// <param name="benhNhan"></param>
        //public MainThongTinThanhToan(string title, KhachHang khachHang, int ID)
        //{
        //    InitializeComponent();
        //    isNew = true;
        //    IDKhachHang = ID;
        //    this.khachHang = khachHang;
        //    libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        //    //load data cho các textbox
        //    LoadData(title, this.khachHang);
        //}

        public MainThongTinThanhToan(string title, HoaDonDK hoaDon, KhachHang khachHang)
        {
            InitializeComponent();
            isNew = false;
            this.hoaDon = hoaDon;
            this.khachHang = khachHang;
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
            //load data cho các textbox
            LoadData(title, this.hoaDon, khachHang);
        }

        private void LoadData(string title, Model.DTO.HoaDonDK hoaDon, Model.DTO.KhachHang khachHang)
        {
            //set title cho form
            Text = title;
            // load data cho các textbox
            txtMaKH.Text = khachHang.MaKH.ToString();
            txtMaSim.Text = hoaDon.MaSim.ToString();
            txtChiPhi.Text = hoaDon.ChiPhi.ToString();
            txtTGDangKy.Text = hoaDon.TG_DangKy.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
