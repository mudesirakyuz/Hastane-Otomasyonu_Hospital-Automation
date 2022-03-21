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
using Microsoft.VisualBasic;

namespace Hastane_Otomasyonu
{
    public partial class YeniKullanici : Form
    {
        public YeniKullanici()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        /*public static void RastgeleTextBox(TextBox t)
        {
            int r, g, b;
            Random rnd = new Random();
            r = rnd.Next(0, 256);
            g = rnd.Next(0, 256);
            b = rnd.Next(0, 256);
            t.BackColor = Color.FromArgb(r, g, b);
            r = rnd.Next(0, 256);
            g = rnd.Next(0, 256);
            b = rnd.Next(0, 256);
            t.ForeColor = Color.FromArgb(r, g, b);
        }
        void Varsayılan(TextBox t)
        {
            t.BackColor = DefaultBackColor;
            t.ForeColor = Color.Gainsboro;
        }*/
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Giris.KapatLeave(button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Giris();
            frm.Show();
            this.Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adınızı Giriniz...")
            {
                textBox1.Text = "";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Parolanızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Parolanızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Cevabınızı Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Sicil Numaranızı Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
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
            if (textBox3.Text == "")
            {
                textBox3.Text = "Parolanızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Cevabınızı Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Sicil Numaranızı Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.ForeColor = Color.DarkOrange;
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Parolanızı Giriniz...")
            {
                textBox3.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            
            if (textBox2.Text == "")
            {
                textBox2.Text = "Parolanızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Cevabınızı Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Sicil Numaranızı Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox3.BackColor = Color.NavajoWhite;
            textBox3.ForeColor = Color.DarkOrange;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Giris.LoginEnter(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Giris.LoginLeave(button1);
        }
        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Cevabınızı Giriniz...")
            {
                textBox4.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Parolanızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Parolanızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }

            textBox4.BackColor = Color.NavajoWhite;
            textBox4.ForeColor = Color.DarkOrange;
        }
        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Sicil Numaranızı Giriniz...")
            {
                textBox5.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Parolanızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Parolanızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Cevabınızı Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            textBox5.BackColor = Color.NavajoWhite;
            textBox5.ForeColor = Color.DarkOrange;
        }
        ErrorProvider eror = new ErrorProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            if (textBox2.Text == textBox3.Text)
            {
                if (textBox1.Text != "Kullanıcı Adınızı Giriniz..." && textBox2.Text != "Parolanızı Giriniz..." && textBox3.Text != "Parolanızı Giriniz..." && textBox5.Text != "Sicil Numaranızı Giriniz...")
                {
                    baglanti.Open();
                    if (bashekim == true)
                    {
                        OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Bas_Hekim_Kullanici (bh_kullanici,bh_parola) VALUES (@kullanici_adi,@parola)", baglanti);
                        cmd2.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@parola", textBox2.Text);

                        if (kontrol == true)
                        {
                            try
                            {
                                cmd2.ExecuteNonQuery();
                            }
                            catch (OleDbException)
                            {
                                kontrol = false;
                                textBox1.BackColor = Color.Red;
                                textBox1.ForeColor = Color.White;
                                MessageBox.Show("Bu Kullanıcı Adı Kullanılıyor...", "[Kullanıcı Adı Çakışması]");
                            }

                        }
                        if (kontrol == true)
                        {
                            button1.BackColor = Color.YellowGreen;
                            button1.ForeColor = Color.White;
                            DialogResult c = MessageBox.Show("Kayıt Başarılı...", "[Kayıt Bilgilendirmesi]");
                            if (c == DialogResult.OK)
                            {
                                Form frm = new Giris();
                                frm.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand("INSERT INTO Kullanicilar (kullanici_adi,parola,personel_sicil,guvenlik_sorusu) VALUES (@kullanici_adi,@parola,@personel_sicil,@guvenlik_sorusu)", baglanti);
                        cmd.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                        cmd.Parameters.AddWithValue("@personel_dicil", textBox5.Text);
                        cmd.Parameters.AddWithValue("@guvenlik_sorusu", textBox4.Text);
                        if (kontrol == true)
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (OleDbException)
                            {
                                baglanti.Close();
                                kontrol = false;
                                textBox1.BackColor = Color.Red;
                                textBox1.ForeColor = Color.White;
                                MessageBox.Show("Bu Kullanıcı Adı Kullanılıyor...", "[Kullanıcı Adı Çakışması]");
                            }

                        }
                        if (kontrol == true)
                        {
                            button1.BackColor = Color.YellowGreen;
                            button1.ForeColor = Color.White;
                            DialogResult c = MessageBox.Show("Kayut Başarılı...", "[Kayıt Bilgilendirmesi]");
                            if (c == DialogResult.OK)
                            {
                                Form frm = new Giris();
                                frm.Show();
                                this.Close();
                            }
                        }

                        baglanti.Close();
                    }
                }
                else
                {
                    eror.SetError(textBox1, "Bu Alan Boş Geçilemez!...");
                    eror.SetError(textBox2, "Bu Alan Boş Geçilemez!...");
                    eror.SetError(textBox3, "Bu Alan Boş Geçilemez!...");
                    eror.SetError(textBox4, "Bu Alan Boş Geçilemez!...");
                    eror.SetError(textBox5, "Bu Alan Boş Geçilemez!...");
                    textBox1.BackColor = Color.DarkRed;
                    textBox1.ForeColor = Color.White;
                    textBox2.BackColor = Color.DarkRed;
                    textBox2.ForeColor = Color.White;
                    textBox3.BackColor = Color.DarkRed;
                    textBox3.ForeColor = Color.White;
                    textBox4.BackColor = Color.DarkRed;
                    textBox5.ForeColor = Color.White;
                    textBox5.BackColor = Color.DarkRed;
                    textBox5.ForeColor = Color.White;
                }
                
            }
            else MessageBox.Show("Parolalar uyuşmuyor...", "[Parola Uyuşmazlığı]");
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            //RastgeleTextBox(textBox1);
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            //RastgeleTextBox(textBox2);
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            //RastgeleTextBox(textBox3);
        }

        private void textBox4_MouseEnter(object sender, EventArgs e)
        {
            //RastgeleTextBox(textBox4);
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            //RastgeleTextBox(textBox5);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            //Varsayılan(textBox1);
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            //Varsayılan(textBox2);
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            //Varsayılan(textBox3);
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            //Varsayılan(textBox4);
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            //Varsayılan(textBox5);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Giris();
            frm.Show();
            this.Close();
        }
        bool bashekim;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string parola = Interaction.InputBox("Lütfen Yönetici Giriş Parolasını Giriniz...", "[ Yönetici Giriş Paneli ]", "", 500, 200);
                if (parola=="Çapa Hospital 123")
                {
                    textBox5.Text = " ";
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    bashekim = true;
                }
                else
                {
                    textBox5.Text = "Sicil Numaranızı Giriniz...";
                    MessageBox.Show("Parola Yanlış!...");
                    checkBox1.Checked = false;
                }
            }
            else
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                bashekim = false;
            }
        }

        private void YeniKullanici_Load(object sender, EventArgs e)
        {

        }
    }
}
