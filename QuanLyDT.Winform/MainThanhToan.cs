﻿using QuanLyDT.Infrastructure;
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
    public partial class MainThanhToan : Form
    {
        //private bool isNew = true;
        private HoaDonDK thanhToan;
        private HoaDonThanhToanGUI thanhToanGUI;
        //private static List<Sim> listSim;
        private KhachHang khachHang;
        private Sim sim;
        private LibraryService libraryService;

        public MainThanhToan()
        {
            InitializeComponent();
            thanhToan = new HoaDonDK();
            thanhToanGUI = new HoaDonThanhToanGUI();
            khachHang = new KhachHang();
            sim = new Sim();
        }
        /// <summary>
        /// constructor cho việc update khách hàng
        /// </summary>
        /// <param name="title"></param>
        /// <param name="btnText"></param>
        /// <param name="benhNhan"></param>

        public MainThanhToan(string title, string maKH)
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
            //load data cho các textbox
            LoadData(title, maKH);
            thanhToan = new HoaDonDK();
            thanhToanGUI = new HoaDonThanhToanGUI();
            khachHang = new KhachHang();
            sim = new Sim();
        }

        private void LoadSim()
        {
            
        }

        private void LoadData(string title, string maKH)
        {
            //set title cho form
            Text = title;
            thanhToan = new HoaDonDK();
            khachHang = new KhachHang();
            // load data cho các textbox
            if (libraryService.TimKiemByMaKHHDTT(maKH).Count == 0)
            {
                txtMaKH.Text = maKH;
                DateTime date = DateTime.Now;
                txtCuocThueBao.Text = "50000";

            }
            else
            {
                foreach (HoaDonThanhToan item in libraryService.TimKiemByMaKHHDTT(maKH))
                {
                    txtMaKH.Text = item.MaKH.ToString();
                    txtMaSim.Text = item.MaSim.ToString();
                    txtCuocThueBao.Text = item.CuocThueBao.ToString();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            thanhToan.MaKH = int.Parse(txtMaKH.Text.ToString());
            thanhToan.MaSim = int.Parse(txtMaSim.Text.ToString());
            thanhToan.ChiPhi = int.Parse(txtCuocThueBao.Text.ToString());
            thanhToan.TG_DangKy = date;

            if (libraryService.TimKiemByMaKHHDTT(txtMaKH.Text.ToString()).Count != 0)
            {
                if (libraryService.UpdateHoaDonDK(thanhToan))
                {
                    if (DialogResult.OK == MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        DialogResult = DialogResult.OK;
                    }

                }
            }
            else
            {
                bool result = libraryService.ThemHoaDonDK(thanhToan);
                Sim s = libraryService.DanhSachSim().Find(x=>x.MaSim == thanhToan.MaSim);
                s.Status = true;
                libraryService.UpdateSim(s);

                if (result)
                {
                    if (DialogResult.OK == MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        DialogResult = DialogResult.OK;
                    }                 
                }
                else
                {
                    MessageBox.Show("Lỗi không thêm được");
                }
            }
        }

        private void btnThemSim_Click(object sender, EventArgs e)
        {
            string luu = txtMaSim.Text;
            MainTimKiemSIM f = new MainTimKiemSIM();
            f.ShowDialog();       
            if(f.getMaSim()==null)
            {
                txtMaSim.Text = luu;
            }
            else
            {
                txtMaSim.Text = f.getMaSim();
            }        
            if (f.DialogResult != DialogResult.Cancel)
            {
                
            }
        }
    }
}
