using QuanLyDT.Infrastructure;
using QuanLyDT.Model;
using QuanLyDT.Model.DTO;
using QuanLyDT.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDT.Winform
{
    public partial class MainFormCuocDT : Form
    {
        private TaiKhoan nhanVien;
        private LibraryService libraryService;
        private static List<Model.DTO.KhachHang> listKH;
        private static List<HoaDonThanhToan> listHDTT;
        private static List<SimGUI> listSim;
        public static Model.DTO.KhachHang khachHangStatic;

        /// <summary>
        /// constructor
        /// </summary>
        public MainFormCuocDT()
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }

        public MainFormCuocDT(TaiKhoan nhanVien)
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
            this.nhanVien = nhanVien;
        }

        /// <summary>
        /// hàm load khi chạy form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormCuocDT_Load(object sender, EventArgs e)
        {

            LoadDanhSachKH();
            LoadDanhSachHDTT();
            LoadDanhSachSim();

            //set thuộc tính đầu tiên cho combobox tim kiem
            cbxTimKiem.SelectedIndex = 0;
            cbbTimKiemThanhToan.SelectedIndex = 0;
            cbbTimKiemSim.SelectedIndex = 0;
        }

       

        #region Method

        /// <summary>
        /// load danh sách khach hang cho datagridview khach hang
        /// </summary>
        private void LoadDanhSachKH()
        {
            listKH = libraryService.DanhSachKH();
            dgvDanhSachKH.Rows.Clear();
            dgvDanhSachKH.Refresh();
            foreach (Model.DTO.KhachHang item in listKH)
            {
                dgvDanhSachKH.Rows.Add(item.MaKH, item.TenKH, item.NgheNghiep,item.CMND, item.DiaChi, item.Status);
            }
        }

        private void LoadDanhSachHDTT()
        {
            listHDTT = libraryService.DanhSachHDTT();
            dgvDanhSachHoaDonThanhToan.Rows.Clear();
            dgvDanhSachHoaDonThanhToan.Refresh();
            foreach (HoaDonThanhToan item in listHDTT)
            {
                dgvDanhSachHoaDonThanhToan.Rows.Add(item.MaHD, item.MaKH, item.MaSim, item.CuocThueBao, item.TG_TaoHoaDon, item.ThanhToan);
            }
        }

        private void LoadDanhSachSim()
        {
            listSim = libraryService.DanhSachSim();
            dgvDSSim.Rows.Clear();
            dgvDSSim.Refresh();
            foreach (SimGUI item in listSim)
            {
                dgvDSSim.Rows.Add(item.MaKH, item.TenKH, item.SoSim, item.NgheNghiep, item.CMND, item.DiaChi, item.Status);
            }
        }



        #endregion Method

        #region MenuStrip Events


        #endregion MenuStrip Events

        /// <summary>
        /// Thêm khach hang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            MainDKKhachHang f = new MainDKKhachHang("Thêm khách hàng", "Thêm");
            f.ShowDialog();
            if (f.DialogResult != DialogResult.Cancel)
            {
                LoadDanhSachKH();
                khachHangStatic = listKH[listKH.Count - 1];
            }
        }

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvDanhSachKH.SelectedRows[0];
                KhachHang khachHang = listKH.Single(p => p.MaKH == (int)row.Cells[0].Value);

                MainDKKhachHang f = new MainDKKhachHang("Cập nhật thông tin khách hàng", "Cập nhật", khachHang);
                f.ShowDialog();

                if (f.DialogResult != DialogResult.Cancel)
                {
                    LoadDanhSachKH();
                }
            }
        }

        private void btnThongTinThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvDanhSachKH.SelectedRows[0];
                string maKH = row.Cells[0].Value.ToString();

                MainThongTinThanhToan f = new MainThongTinThanhToan("Xem thông tin thanh toán", maKH);
                f.ShowDialog();

                if (f.DialogResult != DialogResult.Cancel)
                {
                    LoadDanhSachKH();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvDanhSachKH.SelectedRows[0];
                string maKH = row.Cells[0].Value.ToString();
                KhachHang khachHang = listKH.Single(p => p.MaKH == (int)row.Cells[0].Value);
                MainThanhToan f = new MainThanhToan("Tiến hành thanh toán", maKH);
                f.ShowDialog();
                khachHang.Status = true;
                if (f.DialogResult != DialogResult.Cancel)
                {
                    libraryService.UpdateKHStatus(khachHang);
                    LoadDanhSachKH();
                }
            }
        }

        private void bttThemSim_Click(object sender, EventArgs e)
        {
            MainLuuSim f = new MainLuuSim("Thêm sim", "Thêm");
            f.ShowDialog();
            if (f.DialogResult != DialogResult.Cancel)
            {
                LoadDanhSachKH();
                khachHangStatic = listKH[listKH.Count - 1];
            }
        }

        private void bttEditSim_Click(object sender, EventArgs e)
        {
            if (dgvDSSim.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvDSSim.SelectedRows[0];
                string maKH = row.Cells[0].Value.ToString();
                KhachHang khachHang = listKH.Single(p => p.MaKH == (int)row.Cells[0].Value);
                MainThanhToan f = new MainThanhToan("Tiến hành thanh toán", maKH);
                f.ShowDialog();
                khachHang.Status = true;
                if (f.DialogResult != DialogResult.Cancel)
                {
                    libraryService.UpdateKHStatus(khachHang);
                    LoadDanhSachKH();
                }
            }
        }

        /// <summary>
        /// tìm kiếm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemBenhNhan_Click_1(object sender, EventArgs e)
        {
            string cot = "";
            switch (cbxTimKiem.SelectedIndex)
            {
                case 0:
                    cot = "*";
                    break;

                case 1:
                    cot = "MaKH";
                    break;

                case 2:
                    cot = "TenKH";
                    break;
            }

            if (txtTimKiem.Text == "" && cbxTimKiem.SelectedIndex != 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (libraryService.TimKiemKH(cot, txtTimKiem.Text).Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDanhSachKH.Rows.Clear();
                    dgvDanhSachKH.Refresh();
                    foreach (Model.DTO.KhachHang item in libraryService.TimKiemKH(cot, txtTimKiem.Text.ToString()))
                    {
                        dgvDanhSachKH.Rows.Add(item.MaKH, item.TenKH, item.NgheNghiep, item.CMND, item.DiaChi, item.Status);
                    }
                }
            }
        }

        /// <summary>
        /// tìm kiếm thanh toán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemThanhToan_Click(object sender, EventArgs e)
        {
            string cot = "";
            switch (cbbTimKiemThanhToan.SelectedIndex)
            {
                case 0:
                    cot = "TenKH";
                    break;
        }
            if (txtTimKiemThanhToan.Text == "" && cbbTimKiemThanhToan.SelectedIndex != 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (libraryService.TimKiemHDTT(cot, txtTimKiemThanhToan.Text).Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDanhSachKH.Rows.Clear();
                    dgvDanhSachKH.Refresh();
                    foreach (HoaDonThanhToan item in libraryService.TimKiemHDTT(cot, txtTimKiem.Text))
                    {
                        dgvDanhSachHoaDonThanhToan.Rows.Add(item.MaKH, item.MaHD, item.MaSim, item.TG_TaoHoaDon);
                    }
                }
            }
        }

        /// <summary>
        /// tìm kiếm sim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttTimKiemSim_Click(object sender, EventArgs e)
        {
            string cot = "SoSim";
            if (txtTimKiemSim.Text == "" && cbbTimKiemSim.SelectedIndex != 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (libraryService.TimKiemSim(cot, txtTimKiemSim.Text).Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDSSim.Rows.Clear();
                    dgvDSSim.Refresh();
                    foreach (SimGUI item in libraryService.TimKiemSim(cot, txtTimKiem.Text))
                    {
                        dgvDSSim.Rows.Add(item.MaKH, item.TenKH, item.SoSim, item.NgheNghiep, item.CMND, item.DiaChi,item.Status);
                    }
                }
            }
        }

    }
}