using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace QuanLyDT.Winform
{
    public partial class FormMail : Form
    {
        public FormMail()
        {
            InitializeComponent();
        }

        void GuiMail(string from, string to, string subject, string mess)
        {

            MailMessage message = new MailMessage(from, to, subject, mess);
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("trieuvi.bloodline2@gmail.com", "Trieu1017649311");
            client.EnableSsl = true;

            client.Send(message);
            MessageBox.Show("Thành công");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(textBox1.Text);
            string email;
            while ((email = reader.ReadLine()) != null)
            {
                GuiMail("trieuvi.bloodline2@gmail.com", email, txtSubj.Text, txtMess.Text);
            }
            this.Close();
            
        }

        private void txtListMail_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
