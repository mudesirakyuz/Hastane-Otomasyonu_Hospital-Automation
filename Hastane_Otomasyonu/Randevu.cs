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
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        public static string saat;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void verilericek()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select Randevu.r_tarihi,Randevu.r_saat,Randevu.r_son_durum,Doktorlar.dr_ad,Doktorlar.dr_soyad,Doktorlar.dr_unvan,Poliklinik.poliklinik_adi,Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad from Randevu,Doktorlar,Poliklinik,Hasta where Doktorlar.dr_sicil_no=Randevu.r_doktor AND Hasta.hasta_tc=Randevu.hasta_tc AND Poliklinik.poliklinik_id=Randevu.r_poliklinik", con);
            ds.Clear();
            da.Fill(ds,"Randevu");
        }
        void sondurum()
        {
            OleDbCommand cmd = new OleDbCommand("select randevu_id,r_tarihi from Randevu",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dateTimePicker3.Value = DateTime.Parse(dr[1].ToString());
                TimeSpan fark = dateTimePicker3.Value - dateTimePicker2.Value;
                if (fark > TimeSpan.Parse(15.ToString()) || fark < TimeSpan.Parse(0.ToString()))
                {
                    OleDbCommand kmt = new OleDbCommand("update Randevu set r_son_durum='Geçti' where randevu_id="+ dr[0] +"", con);
                    kmt.ExecuteNonQuery();
                }
            }
        }
        public static DateTime date;
        string bugun = "";
        private void Randevu_Load(object sender, EventArgs e)
        {
            bugun = dateTimePicker1.Text;
            dataGridView1.ForeColor = Color.DarkOrange;
            con.Open();
            verilericek();
            bs.DataSource = ds.Tables["Randevu"];
            //------------------------------------
            
            textBox1.DataBindings.Add("Text", ds, "Randevu.hasta_tc");
            textBox2.DataBindings.Add("Text", ds, "Randevu.r_saat");
            dateTimePicker1.DataBindings.Add("Text", ds, "Randevu.r_tarihi");
            //comboBox1.DataBindings.Add("Text", ds,"Doktor.dr_ad");
            //comboBox2.DataBindings.Add("Text", ds, "Poliklinik.poliklinik_ad");

            //------------------------------------
            dataGridView1.DataSource = bs;
            sondurum();
            

            OleDbCommand cmd = new OleDbCommand("select poliklinik_adi from Poliklinik order by poliklinik_adi",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }

            OleDbCommand cmd2 = new OleDbCommand("select dr_ad,dr_soyad,dr_unvan,poliklinik_id from Doktorlar order by dr_ad", con);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string a = dr2[2].ToString() + " " + dr2[0].ToString() + " " + dr2[1].ToString();
                comboBox1.Items.Add(a);      
            }
            
            
            
            con.Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Tc Giriniz...")
            {
                textBox1.Text = "";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Randevu Saati...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            textBox1.BackColor = Color.NavajoWhite;
            textBox1.ForeColor = Color.DarkOrange;
        }

        
        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox1.Text == "------------Seçiniz------------")
            {
                comboBox1.Text = "";
            }
            if (comboBox2.Text == "")
            {
                comboBox2.Text = "------------Seçiniz------------";
                comboBox2.BackColor = DefaultBackColor;
                comboBox2.ForeColor = Color.Gainsboro;
            }
            comboBox1.BackColor = Color.NavajoWhite;
            comboBox1.ForeColor = Color.DarkOrange;
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox2.Text == "------------Seçiniz------------")
            {
                comboBox2.Text = "";
            }
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "------------Seçiniz------------";
                comboBox1.BackColor = DefaultBackColor;
                comboBox1.ForeColor = Color.Gainsboro;
            }
            comboBox2.BackColor = Color.NavajoWhite;
            comboBox2.ForeColor = Color.DarkOrange;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.Items.Clear();
            int a = comboBox2.SelectedIndex + 1;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select dr_ad,dr_soyad,dr_unvan from Doktorlar where poliklinik_id="+a+" order by dr_ad", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[2].ToString() + " " + dr[0].ToString() + " " + dr[1].ToString());
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Randevu();
            frm.MdiParent = MdiParent;
            frm.Show();
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            kaydet.BackColor = Color.DarkGreen;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            kaydet.BackColor = Color.LightSeaGreen;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.ForestGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSeaGreen;
        }
        void yenile()
        {
            Form frm = new Randevu();
            frm.MdiParent = MdiParent;
            frm.Show();
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Randevu Saati...")
            {
                textBox2.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Tc Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.ForeColor = Color.DarkOrange;
        }
        bool kontrol = true, formkontrol = true;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        bool kntrl = true;
        private void button7_Click(object sender, EventArgs e)
        {
            if (kntrl == true)
            {
                kntrl = false;
                groupBox4.Visible = true;
            }
            else
            {
                kntrl = true;
                groupBox4.Visible = false;
            } 
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select Randevu.r_tarihi,Randevu.r_saat,Randevu.r_son_durum,Doktorlar.dr_ad,Doktorlar.dr_soyad,Doktorlar.dr_unvan,Poliklinik.poliklinik_adi,Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad from Randevu,Doktorlar,Poliklinik,Hasta where Doktorlar.dr_sicil_no=Randevu.r_doktor AND Hasta.hasta_tc=Randevu.hasta_tc AND Poliklinik.poliklinik_id=Randevu.r_poliklinik AND Hasta.hasta_ad like '%" + textBox3.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Randevu");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select Randevu.r_tarihi,Randevu.r_saat,Randevu.r_son_durum,Doktorlar.dr_ad,Doktorlar.dr_soyad,Doktorlar.dr_unvan,Poliklinik.poliklinik_adi,Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad from Randevu,Doktorlar,Poliklinik,Hasta where Doktorlar.dr_sicil_no=Randevu.r_doktor AND Hasta.hasta_tc=Randevu.hasta_tc AND Poliklinik.poliklinik_id=Randevu.r_poliklinik AND Doktorlar.dr_ad like '%" + textBox4.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Randevu");
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select Randevu.r_tarihi,Randevu.r_saat,Randevu.r_son_durum,Doktorlar.dr_ad,Doktorlar.dr_soyad,Doktorlar.dr_unvan,Poliklinik.poliklinik_adi,Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad from Randevu,Doktorlar,Poliklinik,Hasta where Doktorlar.dr_sicil_no=Randevu.r_doktor AND Hasta.hasta_tc=Randevu.hasta_tc AND Poliklinik.poliklinik_id=Randevu.r_poliklinik AND Randevu.r_tarihi like '%" + dateTimePicker4.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Randevu");
        }
        string tuttc = "";
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            button4.Enabled = true;
            dateTimePicker1.Enabled = true;
            tuttc = textBox1.Text;
            yenikayitmi = false;
            kaydet.Visible = true;
            iptal.Visible = true;
            sil.Enabled = false;
            duzelt.Enabled = false;
            yeni.Enabled = false;
            
        }
        int randevu = 1;
        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            DialogResult c = MessageBox.Show("Eminmisiniz?", "Bilgi", MessageBoxButtons.YesNo);
            if (c == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand("delete from Randevu where randevu_id="+randevu+"", con);

                cmd.ExecuteNonQuery();
                verilericek();
                MessageBox.Show("Belirttiğiniz Kayıt Silindi...");
            }
            con.Close();
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            button4.Enabled = true;
            dateTimePicker1.Enabled = true;

            yenikayitmi = true;
            kaydet.Visible = true;
            iptal.Visible = true;
            sil.Enabled = false;
            duzelt.Enabled = false;
            yeni.Enabled = false;
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            kaydet.Visible = false;
            iptal.Visible = false;
            sil.Enabled = true;
            duzelt.Enabled = true;
            yeni.Enabled = true;
        }
        Boolean yenikayitmi;
        void kelimelere_ayir()
        {
            string isimtut = comboBox1.Text + " ", kelime = "";
            char[] metin = isimtut.ToCharArray();
            foreach (char harf in metin)
            {
                if (harf == ' ')
                {
                    listBox1.Items.Add(kelime);
                    kelime = "";
                }
                else kelime += harf;
            }
        }
        string sicil_no = "";
        void dr()
        {
            listBox1.Items.Clear();
            kelimelere_ayir();
            con.Open();
            OleDbCommand cmd =new OleDbCommand("select dr_sicil_no from Doktorlar where dr_ad=@ad AND dr_soyad=@soyad AND dr_unvan=@unvan", con);
            cmd.Parameters.AddWithValue("@ad", listBox1.Items[1].ToString());
            cmd.Parameters.AddWithValue("@soyad", listBox1.Items[2].ToString());
            cmd.Parameters.AddWithValue("@unvan", listBox1.Items[0].ToString());
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sicil_no = dr[0].ToString();
            }
            con.Close();
        }
        int combo = 1, combo2 = 1;
        bool visible = true;
        private void kaydet_Click(object sender, EventArgs e)
        {
            
            sil.Enabled = true;
            duzelt.Enabled = true;
            yeni.Enabled = true;
            dr();//Doktor Sicil No sicil_no stringinin içinde
            int pol_tut = comboBox2.SelectedIndex + 1;
            con.Open();
            if (textBox1.Text.Length == 11)
            {
                if (yenikayitmi == true)
                {
                    DateTime onbesgun = dateTimePicker2.Value.AddDays(15);
                    OleDbCommand kmt = new OleDbCommand("select hasta_tc form Hasta");
                    if (dateTimePicker1.Value >= dateTimePicker2.Value)
                    {
                        if (dateTimePicker1.Value <= onbesgun)
                        {
                            if (textBox2.Text == "Randevu Saati...") MessageBox.Show("Lütfen Randevu Saatini Giriniz...", "[Giriş Hatası]");
                            else
                            {
                                OleDbCommand cmd = new OleDbCommand("insert into Randevu(r_tarihi,r_saat,r_doktor,r_poliklinik,hasta_tc,r_son_durum) Values(@tar,@saat,@dr,@pol,@tc,'Beklemede')", con);
                                if (textBox1.Text != "Tc Giriniz..." && textBox1.Text != "" && comboBox1.Text != "-------Seçiniz-------" && comboBox2.Text != "-------Seçiniz-------")
                                {
                                    cmd.Parameters.AddWithValue("@tar", dateTimePicker1.Text);
                                    cmd.Parameters.AddWithValue("@saat", textBox2.Text);
                                    cmd.Parameters.AddWithValue("@dr", sicil_no);
                                    cmd.Parameters.AddWithValue("@pol", pol_tut);
                                    cmd.Parameters.AddWithValue("@tc", textBox1.Text);
                                    if (con.State == ConnectionState.Closed) con.Open();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Kayıt Gerçekleştirildi...");
                                    yenile();
                                }
                                else MessageBox.Show("Alanlar boş geçilemez...", "[Boş Geçme Girişimi]");
                            }
                        }
                        else MessageBox.Show("Hastanemiz 15 gün sonraya randevu vermemektedir.\nLütfen daha erken bir tarihe randevu alamazsınız...", "[Tarih Hatası]");
                    }
                    else MessageBox.Show("Geçmiş tarih için randevu alamazsınız...", "[Tarih Hatası]");
                }
                else
                {
                    textBox1.Enabled = false;
                    DateTime onbesgun2 = dateTimePicker2.Value.AddDays(15);
                    if (dateTimePicker1.Value >= dateTimePicker2.Value)
                    {
                        if (dateTimePicker1.Value <= onbesgun2)
                        {
                            OleDbCommand cmd = new OleDbCommand("update Randevu set r_tarihi=@tar,r_saat=@saat,r_doktor=@dr,r_poliklinik=@pol,hasta_tc=@tc_has,r_son_durum=@durum where hasta_tc='"+tuttc.ToString()+"'", con);
                            cmd.Parameters.AddWithValue("@tar", dateTimePicker1.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@saat", textBox2.Text);
                            cmd.Parameters.AddWithValue("@dr", sicil_no);
                            cmd.Parameters.AddWithValue("@pol", pol_tut);
                            //cmd.Parameters.AddWithValue("@tc", tuttc);
                            cmd.Parameters.AddWithValue("@tc_has", textBox1.Text);
                            cmd.Parameters.AddWithValue("@durum", "Beklemede");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Düzeltme Başarılı...");
                            verilericek();
                        }
                        else
                        {
                            visible = false;
                            MessageBox.Show("Hastanemiz 15 gün sonraya randevu vermemektedir.\nLütfen daha erken bir tarihe randevu alamazsınız...", "[Tarih Hatası]");
                        }
                    }
                    else
                    {
                        visible = false;
                        MessageBox.Show("Geçmiş tarih için randevu alamazsınız...", "[Tarih Hatası]");
                    }
                }
            }
            else MessageBox.Show("Tc numarası 11 karakterden az olamaz!\nLütfen 11 haneli TC numarasını giriniz...", "[Hata]");
            con.Close();
            if (visible == true)
            {
                kaydet.Visible = false;
                iptal.Visible = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select Randevu.r_tarihi,Randevu.r_saat,Randevu.r_son_durum,Doktorlar.dr_ad,Doktorlar.dr_soyad,Doktorlar.dr_unvan,Poliklinik.poliklinik_adi,Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad from Randevu,Doktorlar,Poliklinik,Hasta where Doktorlar.dr_sicil_no=Randevu.r_doktor AND Hasta.hasta_tc=Randevu.hasta_tc AND Poliklinik.poliklinik_id=Randevu.r_poliklinik AND Randevu.hasta_tc like '%" + textBox5.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Randevu");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                

                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd = new OleDbCommand("select randevu_id from Randevu where hasta_tc=@tc", con);
                cmd.Parameters.AddWithValue("@tc", textBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) randevu = int.Parse(dr[0].ToString());

                con.Close();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text ==bugun)
            {
                MessageBox.Show("Lütfen Önce Tarih Giriniz...");
            }
            else
            {
                date = dateTimePicker1.Value;
                if (kontrol == true)
                {
                    kontrol = false;
                    button4.BackColor = Color.DarkOrange;
                    button4.Text = "<<<";

                    formkontrol = false;
                    Form frm = new Saat();
                    frm.MdiParent = MdiParent;
                    frm.Show();
                    label2.Visible = true;

                }
                else
                {
                    label2.Visible = false;
                    kontrol = true;
                    button4.Text = ">>>";
                    button4.BackColor = Color.LightSeaGreen;
                    textBox2.Text = saat;
                }
            }
            
        }
    }
}
