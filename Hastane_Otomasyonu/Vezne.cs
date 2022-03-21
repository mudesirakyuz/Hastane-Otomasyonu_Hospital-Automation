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
using System.Globalization;


namespace Hastane_Otomasyonu
{
    public partial class Vezne : Form
    {
        public Vezne()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        //---------------------Vezne------------------------

        DataSet ds_vezne = new DataSet();
        BindingSource bs_vezne = new BindingSource();
        void verileri_cagir_vezne()
        {
            try
            {
                OleDbDataAdapter da_vezne = new OleDbDataAdapter("select Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad,Hasta.hasta_tel,Vezne.fatura_kesim_tarihi,Vezne.tahsil_tarihi,Vezne.ucret_tahsil_durumu,Islemler.islem_adi,Islemler.islem_ucreti from Hasta,Vezne,Islemler where Hasta.hasta_tc=Vezne.hasta_tc AND Vezne.islem_id=Islemler.islem_id", con);
                ds_vezne.Clear();
                da_vezne.Fill(ds_vezne, "Vezne");
            }
            catch
            { }
            
        }

        //---------------------Vezne------------------------
        void verileri_cagir()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Hasta", con);
            ds.Clear();
            da.Fill(ds, "Hasta");
            
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Tc Giriniz...")
            {
                textBox1.Text = "";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Hasta Adını Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Hasta Soyadını Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Hasta Telefonu Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Doğum Yerini Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox1.BackColor = Color.NavajoWhite;
            textBox1.ForeColor = Color.DarkOrange;
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Hasta Adını Giriniz...")
            {
                textBox2.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Tc Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Hasta Soyadını Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Hasta Telefonu Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Doğum Yerini Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox2.BackColor = Color.NavajoWhite;
            textBox2.ForeColor = Color.DarkOrange;
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Hasta Soyadını Giriniz...")
            {
                textBox3.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Tc Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Hasta Adını Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Hasta Telefonu Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Doğum Yerini Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox3.BackColor = Color.NavajoWhite;
            textBox3.ForeColor = Color.DarkOrange;
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Hasta Telefonu Giriniz...")
            {
                textBox4.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Tc Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Hasta Adını Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Hasta Soyadını Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "Doğum Yerini Giriniz...";
                textBox5.BackColor = DefaultBackColor;
                textBox5.ForeColor = Color.Gainsboro;
            }
            textBox4.BackColor = Color.NavajoWhite;
            textBox4.ForeColor = Color.DarkOrange;
        }

        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Doğum Yerini Giriniz...")
            {
                textBox5.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Tc Giriniz...";
                textBox1.BackColor = DefaultBackColor;
                textBox1.ForeColor = Color.Gainsboro;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Hasta Adını Giriniz...";
                textBox2.BackColor = DefaultBackColor;
                textBox2.ForeColor = Color.Gainsboro;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Hasta Soyadını Giriniz...";
                textBox3.BackColor = DefaultBackColor;
                textBox3.ForeColor = Color.Gainsboro;
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Hasta Telefonu Giriniz...";
                textBox4.BackColor = DefaultBackColor;
                textBox4.ForeColor = Color.Gainsboro;
            }
            textBox5.BackColor = Color.NavajoWhite;
            textBox5.ForeColor = Color.DarkOrange;
        }

       

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Teal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.CalendarTitleBackColor = Color.NavajoWhite;
            dateTimePicker1.CalendarForeColor = Color.DarkOrange;
        }
        string update_tc = null;
        private void Vezne_Load(object sender, EventArgs e)
        {
            BigPicture_Control = "Vezne";

            con.Open();
            //------------------Hasta Kabul---------------------
            update_tc = textBox1.Text; 
            verileri_cagir();
            bs.DataSource = ds.Tables["Hasta"];
            dataGridView1.DataSource = bs;

            textBox1.DataBindings.Add("Text", bs, "hasta_tc");
            textBox2.DataBindings.Add("Text", bs, "hasta_ad");
            textBox3.DataBindings.Add("Text", bs, "hasta_soyad");
            textBox4.DataBindings.Add("Text", bs, "hasta_tel");
            dateTimePicker1.DataBindings.Add("Text", bs, "hasta_dtarih");
            textBox5.DataBindings.Add("Text", bs, "dogum_yeri");
            //------------------Hasta Kabul---------------------

            //---------------------Vezne------------------------
            if (checkBox1.Checked) durum = "Tahsil Edildi";
            else durum = "Tahsil Edilmedi";
            combo = comboBox1.SelectedIndex + 1;
            hastatc = comboBox2.Text;
            verileri_cagir_vezne();
            bs_vezne.DataSource = ds_vezne.Tables["Vezne"];
            dataGridView2.DataSource = bs_vezne;

            comboBox2.DataBindings.Add("Text", bs_vezne, "hasta_tc");
            textBox12.DataBindings.Add("Text", bs_vezne, "hasta_ad");
            textBox14.DataBindings.Add("Text", bs_vezne, "hasta_soyad");
            textBox13.DataBindings.Add("Text", bs_vezne, "hasta_tel");
            dateTimePicker3.DataBindings.Add("Text", bs_vezne, "fatura_kesim_tarihi");
            dateTimePicker4.DataBindings.Add("Text", bs_vezne, "tahsil_tarihi");
            comboBox1.DataBindings.Add("Text", bs_vezne, "islem_adi");
            textBox15.DataBindings.Add("Text", bs_vezne, "islem_ucreti");

            //---------------------Vezne------------------------
            con.Close();
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            ekle.Enabled = true;
            button10.Enabled = true;
            kaydet.Visible = true;
            iptal.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            yenikayitmi = true;

            textBox1.Text = "Tc Giriniz...";
            textBox2.Text = "Hasta Adını Giriniz...";
            textBox3.Text = "Hasta Soyadını Giriniz...";
            textBox4.Text = "Hasta Telefonu Giriniz...";
            textBox5.Text = "Doğum Yerini Giriniz...";

            textBox1.Focus();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            kaydet.Visible = false;
            iptal.Visible = false;
            ekle.Enabled = false;
            button10.Enabled = false;
        }
        /*void tc_kontrol()
        {
            
            OleDbCommand cmd = new OleDbCommand("select hasta_tc from Hasta",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == textBox1.Text)
                {
                    tc_kntl = true;
                    textBox1.BackColor = Color.Red;
                    textBox1.ForeColor = Color.White;
                    MessageBox.Show("Eşdeğer Tc Kimlik Numarasına Rastlanıldı.\nLütfen Tc Kimlik Numarasını Doğru Girdiğinizden Emin Olun...");
                    textBox1.Text = "";

                }
                
                
            }
            
        }*/
        Boolean yenikayitmi;
        private void kaydet_Click(object sender, EventArgs e)
        {
            con.Open();
            kaydet.Visible = false;
            iptal.Visible = false;
            ekle.Enabled = false;
            button10.Enabled = false;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;

            if (yenikayitmi)
            {
                cmd.CommandText = "insert into Hasta (hasta_tc,hasta_ad,hasta_soyad,hasta_tel,hasta_dtarih,dogum_yeri,resim) Values (@tc,@ad,@soyad,@tel,@tar,@dogum,@resim)";
                cmd.Parameters.AddWithValue("@tc", textBox1.Text);
                cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.Parameters.AddWithValue("@tar", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@dogum", textBox5.Text);
                cmd.Parameters.AddWithValue("@resim", resim.Text);
            }
            else
            {
                cmd.CommandText = "update Hasta set hasta_tc=@tc1,hasta_ad=@ad,hasta_soyad=@soyad,hasta_tel=@tel,hasta_dtarih=@tar,dogum_yeri=@dogum,resim=@resim where hasta_tc=@tc2";
                cmd.Parameters.AddWithValue("@tc1", textBox1.Text);
                cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.Parameters.AddWithValue("@tar", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@dogum", textBox5.Text);
                cmd.Parameters.AddWithValue("@resim", resim.Text);
                cmd.Parameters.AddWithValue("@tc2", update_tc);
                
                //tc_kontrol();

            }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Gerçekleştirildi");

            }
            catch (OleDbException)
            {
                MessageBox.Show("Eşdeğer Tc Kimlik Numarasına Rastlanıldı.\nLütfen Tc Kimlik Numarasını Doğru Girdiğinizden Emin Olun...");
            }

            verileri_cagir();


            con.Close();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void duzelt_Click(object sender, EventArgs e)
        {
            ekle.Enabled = true;
            button10.Enabled = true;
            update_tc = textBox1.Text;
            kaydet.Visible = true;
            iptal.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            yenikayitmi = false;
            textBox1.Focus();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //------------------Resim--------------------
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select resim from Hasta where hasta_tc=@tc", con);
            cmd2.Parameters.AddWithValue("@tc", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read()) resim2.Text = dr2[0].ToString();
            pictureBox2.ImageLocation = resim2.Text;
            con.Close();
            //------------------Resim--------------------
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sil_Click(object sender, EventArgs e)
        {
            con.Open();
            DialogResult c = MessageBox.Show("Eminmisiniz?", "Bilgi", MessageBoxButtons.YesNo);
            if (c == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand("delete from Hasta where hasta_tc='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                verileri_cagir();
                MessageBox.Show("Kaydınız Silindi");
            }
            con.Close();
        }
        bool grb = true;
        private void ara_Click(object sender, EventArgs e)
        {
            if (grb == true)
            {
                grb = false;
                groupBox2.Visible = true;
            }
            else
            {
                grb = true;
                groupBox2.Visible = false;
            } 
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select * from Hasta where hasta_tc like '%" + textBox6.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Hasta");
            if (label9.Text!=null)label9.Visible = true;
            else label9.Visible = false;
            if (label10.Visible == true) label10.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("select * from Hasta where hasta_ad like '%" + textBox7.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Hasta");
            if (label10.Text != null) label10.Visible = true;
            else label10.Visible = false;
            if (label9.Visible == true) label9.Visible = false;
        }
        string hastatc = "";
        bool boslukkontrol;
        ErrorProvider eror = new ErrorProvider();
        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            button2.Enabled = true;
            con.Open();
            if (textBox13.Text.Length == 11)
            {
                
                    
                    if (textBox12.Text == "") eror.SetError(textBox12, "Boş Geçilemez!...");
                    else if (textBox13.Text == "") eror.SetError(textBox13, "Boş Geçilemez!...");
                    else if (textBox14.Text == "") eror.SetError(textBox14, "Boş Geçilemez!...");
                    else if (textBox15.Text == "") eror.SetError(textBox15, "Boş Geçilemez!...");
                    else if (comboBox1.Text == "") eror.SetError(comboBox1, "Boş Geçilemez!...");
                    else if (comboBox2.Text == "") eror.SetError(comboBox2, "Boş Geçilemez!...");
                    else boslukkontrol = false;
                
                if (boslukkontrol == false)
                {
                    boslukkontrol = true;
                    if (yenimi == true)
                    {
                        OleDbCommand cmd = new OleDbCommand("insert into Vezne (fatura_kesim_tarihi,tahsil_tarihi,ucret_tahsil_durumu,hasta_tc,islem_id) Values(@fkt,@tt,@durum,@tc,@islem)", con);
                        cmd.Parameters.AddWithValue("@fkt", dateTimePicker3.Value.ToShortDateString());
                        if (checkBox1.Checked) cmd.Parameters.AddWithValue("@tt", dateTimePicker4.Value.ToShortDateString());
                        else cmd.Parameters.AddWithValue("@tt", "");
                        cmd.Parameters.AddWithValue("@durum", durum);
                        cmd.Parameters.AddWithValue("@hasta_tc", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@islem", combo);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı...");
                        verileri_cagir_vezne();

                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand("update Vezne set fatura_kesim_tarihi=@fkt,tahsil_tarihi=@tt,ucret_tahsil_durumu=@durum,hasta_tc=@tc,islem_id=@islem where hasta_tc='" + hastatc + "'", con);
                        cmd.Parameters.AddWithValue("@fkt", dateTimePicker3.Value.ToShortDateString());
                        if (checkBox1.Checked) cmd.Parameters.AddWithValue("@tt", dateTimePicker4.Value.ToShortDateString());
                        else cmd.Parameters.AddWithValue("@tt", "");
                        cmd.Parameters.AddWithValue("@durum", durum);
                        cmd.Parameters.AddWithValue("@hasta_tc", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@islem", combo);
                        try
                        {
                        cmd.ExecuteNonQuery();
                        }
                        catch 
                        {

                            
                        }
                        
                        MessageBox.Show("Kayıt Düzeltme Başarılı...");
                        verileri_cagir_vezne();
                    }
                }
            }
            else eror.SetError(textBox13, "Telefon 11 karakterden az olamaz!\nLütfen 11 haneli Telefonu giriniz...");
            
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            con.Close();
           
        }
        string durum="";
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                durum = "Tahsil Edildi";
                dateTimePicker4.Visible = true;
                label22.Visible = true;
            }
            else
            {
                durum = "Tahsil Edilmedi";
                dateTimePicker4.Visible = false;
                label22.Visible = false;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            boslukkontrol = true;

            if (comboBox2.Items.Count != 0) comboBox2.Items.Clear();
            if (comboBox1.Items.Count != 0) comboBox1.Items.Clear();
            combo = comboBox1.SelectedIndex + 1;
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";

            yenimi = true;
            checkBox1.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            button2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            con.Open();

            OleDbCommand cmd = new OleDbCommand("select islem_adi from Islemler",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) comboBox1.Items.Add(dr[0].ToString());

            //---------------------------------------

            OleDbCommand cmd2 = new OleDbCommand("select hasta_tc from Randevu", con);
            OleDbDataReader dr2= cmd2.ExecuteReader();
            while (dr2.Read()) 
            {
                comboBox2.Items.Add(dr2[0].ToString());
            }
            con.Close();
        }
        Boolean kontrol = true, yenimi;
        private void button2_Click(object sender, EventArgs e)
        {
            if(kontrol==true)
            {
                kontrol = false;
                groupBox4.Visible = true;
            }
            else
            {
                kontrol = true;
                groupBox4.Visible = false;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = false;
            label12.Visible = true;
            try
            {
                OleDbDataAdapter dr = new OleDbDataAdapter("select Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad,Hasta.hasta_tel,Vezne.fatura_kesim_tarihi,Vezne.tahsil_tarihi,Vezne.ucret_tahsil_durumu,Islemler.islem_adi,Islemler.islem_ucreti from Hasta,Vezne,Islemler where Hasta.hasta_tc=Vezne.hasta_tc AND Vezne.islem_id=Islemler.islem_id AND Hasta.hasta_tc like '%" + textBox9.Text + "%'", con);
                ds_vezne.Clear();
                dr.Fill(ds_vezne, "Vezne");
            }
            catch { }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = true;
            label12.Visible = false;
            try
            {
                OleDbDataAdapter dr = new OleDbDataAdapter("select Hasta.hasta_tc,Hasta.hasta_ad,Hasta.hasta_soyad,Hasta.hasta_tel,Vezne.fatura_kesim_tarihi,Vezne.tahsil_tarihi,Vezne.ucret_tahsil_durumu,Islemler.islem_adi,Islemler.islem_ucreti from Hasta,Vezne,Islemler where Hasta.hasta_tc=Vezne.hasta_tc AND Vezne.islem_id=Islemler.islem_id AND Hasta.hasta_ad like '%" + textBox8.Text + "%'", con);
                ds_vezne.Clear();
                dr.Fill(ds_vezne, "Vezne");
            }
            catch { }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            boslukkontrol = true;

            if (comboBox2.Items.Count != 0) comboBox2.Items.Clear();
            if (comboBox1.Items.Count != 0) comboBox1.Items.Clear();
            hastatc = comboBox2.Text;
            yenimi = false;
            checkBox1.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button2.Enabled = false;

            con.Open();
            OleDbCommand cmd = new OleDbCommand("select islem_adi from Islemler",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) comboBox1.Items.Add(dr[0].ToString());

            //----------------------------------------------

            OleDbCommand cmd2 = new OleDbCommand("select hasta_tc from Randevu", con);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read()) comboBox2.Items.Add(dr2[0].ToString());

            con.Close();
        }
        int combo=1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo = comboBox1.SelectedIndex + 1;
            if(con.State==ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select islem_ucreti from Islemler where islem_id=" + combo + "", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox15.Text = dr[0].ToString();
            }
            con.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            hastatc = comboBox2.Text;

            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select hasta_ad,hasta_soyad,hasta_tel from Hasta where hasta_tc='"+comboBox2.Text+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox12.Text = dr[0].ToString();
                textBox14.Text = dr[1].ToString();
                textBox13.Text = dr[2].ToString();
            }
            con.Close();

            //------------------Resim--------------------
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select resim from Hasta where hasta_tc=@tc", con);
            cmd2.Parameters.AddWithValue("@tc", comboBox2.Text) ;
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read()) resim2.Text = dr2[0].ToString();
            pictureBox3.ImageLocation = resim2.Text;
            con.Close();
            //------------------Resim--------------------
        }
        int vezneid = 1;
        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            DialogResult c = MessageBox.Show("Eminmisiniz?", "Bilgi", MessageBoxButtons.YesNo);

            OleDbCommand cmd1 = new OleDbCommand("select vezne_id from Vezne where hasta_tc='" + comboBox2.Text + "'", con);
            OleDbDataReader dr = cmd1.ExecuteReader();
            if (dr.Read()) vezneid = int.Parse(dr[0].ToString());

            if (c == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand("delete from Vezne where vezne_id=" + vezneid + "", con);
                cmd.ExecuteNonQuery();
                verileri_cagir_vezne();
                MessageBox.Show("Belirttiğiniz Kayıt Silindi...");
            }
            con.Close();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            dosya = resim2.Text;
            Form frm = new BigPicture();
            frm.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //------------------Resim--------------------
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd2 = new OleDbCommand("select resim from Hasta where hasta_tc=@tc", con);
            cmd2.Parameters.AddWithValue("@tc", dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString()); ;
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read()) resim2.Text = dr2[0].ToString();
            pictureBox3.ImageLocation = resim2.Text;
            con.Close();
            //------------------Resim--------------------
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form frm = new WepCam();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dosya = resim2.Text;
            Form frm = new BigPicture();
            frm.Show();
        }
        public static string dosya;
        public static string BigPicture_Control;

        private void button11_Click(object sender, EventArgs e)
        {
            Form frm = new Raporlama_Hasta();
            frm.MdiParent = MdiParent;
            frm.Show();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form frm = new Satis();
            frm.MdiParent = MdiParent;
            frm.Show();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosya_yolu = dosya.FileName;
            resim.Text = dosya_yolu;
            pictureBox2.ImageLocation = dosya_yolu;
        }
    }
}
