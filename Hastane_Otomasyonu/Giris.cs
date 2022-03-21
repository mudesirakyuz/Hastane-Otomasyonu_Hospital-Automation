using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Hastane_Otomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        public static void KapatEnter(Button b)   
        {
            b.BackColor = Color.Red;
            b.ForeColor = Color.White;
        }
        public static void KapatLeave(Button b)
        {
            b.BackColor = Color.FromArgb(5, 42, 55);
            b.ForeColor = Color.White;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            KapatEnter(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            KapatLeave(button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            /*System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#f58b54");
            button1.BackColor = col;*/

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text== "Kullanıcı Adınızı Giriniz...")
            {
                textBox1.Text = "";
            }
            
            if (textBox2.Text == "")
            {
                textBox2.Text = "Parolanızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            textBox1.BackColor = Color.NavajoWhite;
            textBox1.ForeColor = Color.DarkOrange;

            
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Parolanızı Giriniz...")
            {
                textBox2.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            } 
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.ForeColor = Color.DarkOrange;

            
        }
        public static void LoginEnter(Button b)
        {
            b.BackColor = Color.White;
            b.ForeColor = Color.ForestGreen;
        }
        public static void LoginLeave(Button b)
        {
            b.BackColor = Color.Black;
            b.ForeColor = Color.White;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            LoginEnter(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            LoginLeave(button1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new YeniKullanici();
            frm.Show();
            this.Hide();
        }
        public static string kullaniciadi;
        public static string parola;
        bool bashekim;
        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != "Kullanıcı Adınızı Giriniz..." || textBox2.Text != "Parolanızı Giriniz...") 
            {
                
                baglanti.Open();
                if (bashekim==true)
                {
                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Bas_Hekim_Kullanici WHERE bh_kullanici='" + textBox1.Text + "' AND bh_parola='" + textBox2.Text + "'", baglanti);
                    OleDbDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.Read())
                    {
                        kullaniciadi ="Sayın Baş Hekimimiz, "+ textBox1.Text+" Hoşgeldiniz... ";
                        button1.BackColor = Color.ForestGreen;
                        button1.ForeColor = Color.White;
                        MessageBox.Show("Giriş Başarılı...", "[Giriş Durumu]");
                        parola = textBox2.Text;
                        Form frm = new Form1();
                        frm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarısız!\nKullanıcı Adı Veya Parola Yanlış...", "[Giriş Durumu]");
                        button1.BackColor = Color.DarkRed;
                        button1.ForeColor = Color.White;
                    }
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kullanicilar WHERE kullanici_adi='" + textBox1.Text + "' AND parola='" + textBox2.Text + "'", baglanti);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        kullaniciadi = textBox1.Text;
                        button1.BackColor = Color.ForestGreen;
                        button1.ForeColor = Color.White;
                        MessageBox.Show("Giriş Başarılı...", "[Giriş Durumu]");
                        Form frm = new Form1();
                        frm.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarısız!\nKullanıcı Adı Veya Parola Yanlış...", "[Giriş Durumu]");
                        button1.BackColor = Color.DarkRed;
                        button1.ForeColor = Color.White;
                    }
                }
                
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Alanlar Boş Geçilemez!...", "[Boş Geçme Girişimi]");
                textBox1.BackColor = Color.DarkRed;
                textBox1.ForeColor = Color.White;
                textBox2.BackColor = Color.DarkRed;
                textBox2.ForeColor = Color.White;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Unuttum();
            frm.Show();
            this.Hide();
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '•';
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                bashekim = true;
                if(checkBox1.Checked==false) checkBox1.Checked = true;
            }
            else
            {
                bashekim = false;
                if (checkBox1.Checked == true) checkBox1.Checked = false;
            }
        }
    }
}
