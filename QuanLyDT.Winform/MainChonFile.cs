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
                string tgBD = chuoi[1] +" "+ chuoi[2];
                string tgKT = chuoi[3] + " " + chuoi[4];

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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                fileName = saveFileDialog1.FileName;
                textBox1.Text = fileName;
                DateTime start = new DateTime(2018, 11, 15);
                int range = (DateTime.Today - start).Days;
       
                Random a = new Random();

                FileStream fs = new FileStream(fileName, FileMode.Create);
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine("IDSIM\tTGBD\tTGKT");
                List<Sim> sims = libraryService.DanhSachSim();
                
                for (int i = 1; i <= 100; i++)
                {
                    int id = sims[a.Next(1,sims.Count)].MaSim;
                    int b = a.Next(7);
                    int c = a.Next(59);
                    TimeSpan d = new System.TimeSpan(0, b, c, 0);
                    DateTime TGBD = start.AddDays(a.Next(range)).AddHours(a.Next(0, 23)).AddMinutes(a.Next(0, 60)).AddSeconds(a.Next(0, 60));

                    DateTime TGKT = TGBD.Add(d);
                    sWriter.WriteLine(id + " " + TGBD.ToString("yyyy-MM-dd HH:mm:ss") + " " + TGKT.ToString("yyyy-MM-dd HH:mm:ss"));


                }

                sWriter.Flush();


                fs.Close();
            }

        }
    }
}
