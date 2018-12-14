using QuanLyDT.Infrastructure;
using QuanLyDT.Model.DTO;
using QuanLyDT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDT.Winform
{
    public partial class MainChonFile : Form
    {
        private string fileName;
        private LibraryService libraryService;
        public MainChonFile()
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }

        private void MainChonFile_Load(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
            Console.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                 fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;
            }
        }
        public String getFileName()
        {
            return fileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                string[] chuoi = lines[i].Split(new Char[] { ' ' });
                string tgBD = chuoi[1] +" "+ chuoi[2] + " " + chuoi[3];
                string tgKT = chuoi[4] + " " + chuoi[5] + " " + chuoi[6];

                CuocGoi cg = new CuocGoi();
                cg.MaSim = int.Parse(chuoi[0]);
                cg.TG_BatDau = DateTime.Parse(tgBD);
                cg.TG_KetThuc = DateTime.Parse(tgKT);
                TimeSpan d = cg.TG_KetThuc.Subtract(cg.TG_BatDau);
                cg.SoPhutSD = int.Parse(d.TotalMinutes.ToString());
                libraryService.ThemCuocGoi(cg);
            }
            this.Close();
        }
    }
}
