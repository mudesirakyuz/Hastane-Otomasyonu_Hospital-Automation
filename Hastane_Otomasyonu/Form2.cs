using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.OleDb;

namespace Hastane_Otomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        DataSet ds = new DataSet();
        public static void MouseEnter(Button b)
        {
            b.BackColor = Color.Teal;
            b.ForeColor = Color.White;
        }
        public static void MouseLeave(Button b)
        {
            b.BackColor = Color.Snow;
            b.ForeColor = Color.Maroon;
        }

        public static void Efect(Button b) 
        {
            string metin = b.Text;
            char[] harfler = metin.ToCharArray();
            b.Text = "";
            foreach (char harf in harfler)
            {
                b.Text += harf;
                Application.DoEvents();//Her Harften Sonra Biraz Bekler
                System.Threading.Thread.Sleep(40);
            }
        }
       
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button4);
            Efect(button4);
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button4);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button5);
            Efect(button5);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button5);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button6);
            Efect(button6);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button6);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button7);
            Efect(button7);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button7);
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button9);
            Efect(button9);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button9);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button8);
            Efect(button8);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button8);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSalmon;
            button1.ForeColor = Color.Firebrick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Vezne();    
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Randevu();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string parola = Interaction.InputBox("Lütfen Yönetici Giriş Parolasını Giriniz...", "[ Yönetici Giriş Paneli ]", "", 500, 200);

            if (Giris.parola == parola)
            {
                Form frm = new Depo();
                frm.MdiParent = this.MdiParent;
                frm.Show();
                this.Close();
            }
            else MessageBox.Show("Parola Yanlış Veya Başhekim Girişi Yapılmamış...","[Giriş Durumu]");

            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
