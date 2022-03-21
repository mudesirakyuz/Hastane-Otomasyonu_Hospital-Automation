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
    public partial class Unuttum : Form
    {
        public Unuttum()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            textBox2.Visible = true;
            label2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = false;
            label2.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adınızı Giriniz...")
            {
                textBox1.Text = "";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Sicil Numaranızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Cevabınızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            textBox1.BackColor = Color.NavajoWhite;
            textBox1.ForeColor = Color.DarkOrange;
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Sicil Numaranızı Giriniz...")
            {
                textBox2.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adınızı Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Cevabınızı Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.ForeColor = Color.DarkOrange;
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Cevabınızı Giriniz...")
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
                textBox2.Text = "Sicil Numaranızı Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            textBox3.BackColor = Color.NavajoWhite;
            textBox3.ForeColor = Color.DarkOrange;
        }
        ErrorProvider eror = new ErrorProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox3.Text != "")
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text != "Kullanıcı Adınızı Giriniz...")
                    {
                        OleDbCommand cmd = new OleDbCommand("select parola from Kullanicilar where kullanici_adi='" + textBox1.Text + "' And guvenlik_sorusu='" + textBox3.Text + "'", con);
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) MessageBox.Show("Şifreniz: " + dr[0].ToString());
                        else MessageBox.Show("Kullanıcı adı veya Güvenlik Sorusunun Cevabı yanlış!");
                    }
                    else eror.SetError(textBox1, "Kullanıcı adı veya Sicil numarası boş geçilemez...");
                }
                else
                {
                    if (textBox2.Text != "Sicil Numaranızı Giriniz...")
                    {
                        OleDbCommand cmd = new OleDbCommand("select parola from Kullanicilar where personel_sicil='" + textBox2.Text + "' And guvenlik_sorusu='" + textBox3.Text + "'", con);
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) MessageBox.Show("Şifreniz: " + dr[0].ToString());
                        else MessageBox.Show("Kullanıcı adı veya Güvenlik Sorusunun Cevabı yanlış!");
                    }
                    else eror.SetError(textBox2, "Kullanıcı adı veya Sicil numarası boş geçilemez...");
                }
            }
            else eror.SetError(textBox3, "Lütfen boş bırakmayınız...");
            con.Close();
            
        }

        private void Unuttum_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Kullanıcı Adınızı Giriniz...";
            textBox2.Text = "Sicil Numaranızı Giriniz...";
            textBox3.Text = "Cevabınızı Giriniz...";
            textBox1.BackColor = DefaultBackColor;
            textBox1.ForeColor = Color.Gainsboro;
            textBox2.BackColor = DefaultBackColor;
            textBox2.ForeColor = Color.Gainsboro;
            textBox3.BackColor = DefaultBackColor;
            textBox3.ForeColor = Color.Gainsboro;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Giris();
            frm.Show();
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(5, 42, 55);
        }

        private void Unuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
