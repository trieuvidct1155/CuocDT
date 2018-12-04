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
    public partial class MainTimKiemSIM : Form
    {
        private LibraryService libraryService;
        public string masim;
        public MainTimKiemSIM()
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MainLuuSim f = new MainLuuSim("Thêm sim", "Thêm");
            f.ShowDialog();
            List<Sim> sims = libraryService.TimKiemSim("SoSim", f.getSoSim());
            masim = sims[0].MaSim.ToString();
            if (f.DialogResult != DialogResult.Cancel)
            {

            }
            this.Close();
        }
        public string getMaSim()
        {
            return masim;
        }

        private void MainTimKiemSIM_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {           
            masim = (string)dgvdsthuoc.SelectedRows[0].Cells[0].Value;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
