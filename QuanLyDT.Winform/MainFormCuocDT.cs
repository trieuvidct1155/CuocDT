using QuanLyDT.Infrastructure;
using QuanLyDT.Model;
using QuanLyDT.Model.DTO;
using QuanLyDT.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private static List<Sim> listSim;
        private static List<LoaiCuoc> listLoaiCuoc;
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
            LoadDanhSachLoaiCuoc();

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
                dgvDanhSachHoaDonThanhToan.Rows.Add(item.MaHD, item.MaKH, item.MaSim, item.CuocThueBao, item.TG_TaoHoaDon, item.ThanhToan, item.ThanhTien, item.Status);
            }
        }

        private void LoadDanhSachSim()
        {
            listSim = libraryService.DanhSachSim();
            dgvDSSim.Rows.Clear();
            dgvDSSim.Refresh();
            foreach (Sim item in listSim)
            {
                dgvDSSim.Rows.Add(item.MaSim, item.SoSim, item.Status);
            }
        }

        private void LoadDanhSachLoaiCuoc()
        {
            listLoaiCuoc = libraryService.DanhSachLoaiCuoc();
            dgvLoaiCuoc.Rows.Clear();
            dgvLoaiCuoc.Refresh();
            foreach (LoaiCuoc item in listLoaiCuoc)
            {
                dgvLoaiCuoc.Rows.Add(item.TG_BatDau, item.TG_KetThuc, item.GiaCuoc, item.Status);
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
                LoadDanhSachHDTT();
                LoadDanhSachSim();
                khachHangStatic = listKH[listKH.Count - 1];
            }
        }

        private void bttEditSim_Click(object sender, EventArgs e)
        {
            if (dgvDSSim.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvDSSim.SelectedRows[0];
                string maSim = row.Cells[0].Value.ToString();
                string status = row.Cells[2].Value.ToString();
                if(status == "False")
                {
                    MainChinhSuaSim f = new MainChinhSuaSim("Tiến hành chỉnh sửa", maSim);
                    f.ShowDialog();
                    if (f.DialogResult != DialogResult.Cancel)
                    {
                        LoadDanhSachSim();
                    }
                }
                else
                {
                    MessageBox.Show("Sim đã có người đăng ký, không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCuoc_Click(object sender, EventArgs e)
        {
            MainChinhSuaCuoc f = new MainChinhSuaCuoc("Thêm loại cước", "Thêm");
            f.ShowDialog();
            if (f.DialogResult != DialogResult.Cancel)
            {
                LoadDanhSachLoaiCuoc();
            }
        }

        private void btnEditCuoc_Click(object sender, EventArgs e)
        {
            if (dgvLoaiCuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvLoaiCuoc.SelectedRows[0];
                LoaiCuoc loaiCuoc = listLoaiCuoc.Single(p => p.TG_BatDau == (TimeSpan)row.Cells[0].Value & p.TG_KetThuc == (TimeSpan)row.Cells[1].Value);

                MainChinhSuaCuoc f = new MainChinhSuaCuoc("Cập nhật loại cước", "Cập nhật", loaiCuoc);
                f.ShowDialog();

                if (f.DialogResult != DialogResult.Cancel)
                {
                    LoadDanhSachLoaiCuoc();
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
                    cot = "*";
                    break;
                case 1:
                    cot = "TenKH";
                    break;
                case 2:
                    cot = "SoSim";
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
                    dgvDanhSachHoaDonThanhToan.Rows.Clear();
                    dgvDanhSachHoaDonThanhToan.Refresh();
                    foreach (HoaDonThanhToan item in libraryService.TimKiemHDTT(cot, txtTimKiemThanhToan.Text))
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
            string cot = "";
            switch (cbbTimKiemSim.SelectedIndex)
            {
                case 0:
                    cot = "*";
                    break;
                case 1:
                    cot = "MaSim";
                    break;
                case 2:
                    cot = "SoSim";
                    break;
            }
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
                    foreach (Sim item in libraryService.TimKiemSim(cot, txtTimKiemSim.Text))
                    {
                        dgvDSSim.Rows.Add(item.MaSim, item.SoSim, item.Status);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvLoaiCuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvLoaiCuoc.SelectedRows[0];
                LoaiCuoc loaiCuoc = listLoaiCuoc.Single(p => p.TG_BatDau == (TimeSpan)row.Cells[0].Value & p.TG_KetThuc == (TimeSpan)row.Cells[1].Value);          
                    if (libraryService.XoaCuoc(loaiCuoc))
                    {
                        if (DialogResult.OK == MessageBox.Show("Xóa thành thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                        {
                            DialogResult = DialogResult.OK;
                        }

                    }
                LoadDanhSachLoaiCuoc();
            }
        }

        private void btnHuyKham_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvDanhSachHoaDonThanhToan.SelectedRows[0];
            int khachHang =(int)row.Cells[2].Value;
            MainFormChiTietSuDung f = new MainFormChiTietSuDung(khachHang);
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainChonFile f = new MainChonFile();
            f.ShowDialog();          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvDanhSachKH.SelectedRows[0];
            string maKH = row.Cells[0].Value.ToString();
            bool status = bool.Parse(row.Cells[5].Value.ToString());
            KhachHang khachHang = listKH.Single(p => p.MaKH == (int)row.Cells[0].Value);

            if(status)
            {
                khachHang.Status = false;
                libraryService.UpdateKHStatus(khachHang);
                LoadDanhSachKH();
            }
            else
            {
                khachHang.Status = true;
                libraryService.UpdateKHStatus(khachHang);
                LoadDanhSachKH();
            }
        }
        private void btnCapNhatPhieuKham_Click(object sender, EventArgs e)
        {
            FormMail f = new FormMail();
            f.ShowDialog();
            List<Sim> sims = libraryService.DanhSachSim();
            sims = sims.Where(x => x.Status == true).ToList<Sim>();
            int gia = 0;
            foreach(Sim s in sims)
            {

                List<CuocGoi> cgs = libraryService.DanhSachCuocGoi(s.MaSim);


                
                cgs = cgs.Where(x => x.TG_BatDau == DateTime.Now.AddMonths(-1)).ToList<CuocGoi>();

                if (cgs.Count>0)
                {
                    foreach (CuocGoi cg in cgs)
                    {
                        gia = gia + TinhCuoc(cg.TG_BatDau, cg.TG_KetThuc, cg.SoPhutSD);
                    }
                }

                KhachHang kh = libraryService.TimKiemKHByMaSim(s.MaSim)[0];
                HoaDonDK dk = libraryService.TimKiemHoaDonDK("MaKH", kh.MaKH.ToString())[0];
                HoaDonThanhToan hdtt = new HoaDonThanhToan();
                hdtt.MaKH = kh.MaKH;
                hdtt.MaSim = s.MaSim;
                hdtt.TG_TaoHoaDon = DateTime.Now;
                hdtt.ThanhToan = true;
                hdtt.CuocThueBao = dk.ChiPhi;
                hdtt.ThanhTien = gia;
                libraryService.ThemHDTT(hdtt);
            }
            LoadDanhSachHDTT();
        }

        int TinhCuoc(DateTime TGBD, DateTime TGKT, int sophut)
        {
            DateTime d1 = new DateTime(TGBD.Year, TGBD.Month, TGBD.Day, 23, 0, 0);
            DateTime d2 = new DateTime(TGBD.Year, TGBD.Month, TGBD.Day, 7, 0, 0);
            TimeSpan sp1, sp2;
            int giacuoc = 0, tmp1, tmp2;
            if (TGBD.Hour >= 7 && TGBD.Hour < 23 && TGKT.Hour >= 7 && TGKT.Hour < 23)
            {
                giacuoc = sophut * 200;
            }
            else if ((TGBD.Hour > 22 || TGBD.Hour < 7) && (TGKT.Hour > 22 || TGKT.Hour < 7))
            {
                giacuoc = sophut * 150;
            }
            else if (TGBD.Hour >= 7 && TGBD.Hour <= 23)
            {
                sp1 = d1 - TGBD;
                sp2 = TGKT - d1;
                tmp1 = sp1.Hours * 60 + sp1.Minutes + 1;
                tmp2 = sp2.Hours * 60 + sp2.Minutes;
                giacuoc = tmp1 * 200 + tmp2 * 150;
            }
            else
            {
                sp1 = d2 - TGBD;
                sp2 = TGKT - d2;
                tmp1 = sp1.Hours * 60 + sp1.Minutes + 1;
                tmp2 = sp2.Hours * 60 + sp2.Minutes;
                giacuoc = tmp1 * 150 + tmp2 * 200;

            }
            return giacuoc;
        }
    }
}