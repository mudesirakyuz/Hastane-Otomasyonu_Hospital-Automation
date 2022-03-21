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
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        Boolean yenimi;
        void verileri_cek()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id", con);
            ds.Clear();
            da.Fill(ds, "Ilaclar");
        }
        private void Satis_Load(object sender, EventArgs e)
        {
            Vezne.BigPicture_Control = "Eczane";

            dataGridView1.ForeColor = Color.DarkRed;
            if (con.State == ConnectionState.Closed) con.Open();
            verileri_cek();
            bs.DataSource = ds.Tables["Ilaclar"];
            dataGridView1.DataSource = bs;

            if (ds.Tables["Ilaclar"].Rows.Count != 0)
            {
                lb_firma.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                lb_ad.DataBindings.Add("Text", ds, "Ilaclar.ilac_adi");
                lb_kamac.DataBindings.Add("Text", ds, "Ilaclar.kullanim_amaci");
                lb_yetki.DataBindings.Add("Text", ds, "Ilaclar.yan_etkileri");
                lb_fiyat.DataBindings.Add("Text", ds, "Ilaclar.fiyat");
                lb_gramaj.DataBindings.Add("Text", ds, "Ilaclar.gramaj");
                lb_adet.DataBindings.Add("Text", ds, "Ilaclar.adet");
                lb_ut.DataBindings.Add("Text", ds, "Ilaclar.ut");
                lb_skt.DataBindings.Add("Text", ds, "Ilaclar.skt");
            }


            con.Close();
        }
        string ilacid = "1";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lb_firma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lb_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lb_kamac.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                lb_yetki.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                lb_fiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                lb_gramaj.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                lb_adet.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                lb_ut.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                lb_skt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd = new OleDbCommand("select ilac_id from Ilaclar where ilac_adi=@ad", con);
                cmd.Parameters.AddWithValue("@ad", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) ilacid = dr[0].ToString();

                //------------------Resim--------------------

                OleDbCommand cmd2 = new OleDbCommand("select resim from Ilaclar where ilac_id=@id", con);
                cmd2.Parameters.AddWithValue("@id", ilacid);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read()) resim2.Text = dr2[0].ToString();
                pictureBox1.ImageLocation = resim2.Text;

                //------------------Resim--------------------
            }
            catch { }
            con.Close();
        }
        double fiyat, adet;
        int guncel, kalan, satis_adet, firmaid;

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button4.Visible = true;
            button5.Visible = true;
            button3.Enabled = false;
        }

        void stokhesapla()
        {
            guncel = int.Parse(lb_adet.Text);
            satis_adet = int.Parse(lb_aa.Text);
            kalan = guncel - satis_adet;
            
        }
        string tarih;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button4.Visible = false;
            button5.Visible = false;
            button3.Enabled = true;
        }
        bool grb = true;
        private void button2_Click(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id AND ilac_adi like '%" + textBox7.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Ilaclar");
            if (label11.Text != null) label11.Visible = true;
            else label11.Visible = false;
            if (label10.Visible == true) label10.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id AND kullanim_amaci like '%" + textBox8.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Ilaclar");
            if (label10.Text != null) label10.Visible = true;
            else label10.Visible = false;
            if (label11.Visible == true) label11.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eczane.dosya = resim2.Text;
            Form frm = new BigPicture();
            frm.Show();
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button6);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Teal;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form frm = new Satislar();
            frm.MdiParent = MdiParent;
            frm.Show();
        }

        void firma()
        {
            OleDbCommand cmd = new OleDbCommand("select firma_id from Firma where firma_ad='" + lb_firma.Text + "'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) firmaid = int.Parse(dr[0].ToString());
        }
        void ilac()
        {
            OleDbCommand cmd = new OleDbCommand("select ilac_id from Ilaclar where ilac_adi='"+lb_ad.Text+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) ilacid = dr[0].ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button4.Visible = false;
            button5.Visible = false;
            button3.Enabled = true;
            if (con.State == ConnectionState.Closed) con.Open();
            stokhesapla();
            firma();
            ilac();
            tarih = DateTime.Now.Date.ToShortDateString();
            if (kalan > 0 && int.Parse(textBox1.Text) <= kalan)
            {
                
                OleDbCommand cmd = new OleDbCommand("insert into Satis(ilac_adi,kullanim_amaci,yan_etkileri,tutar,gramaj,adet,ut,skt,satis_tarihi,firma_id,resim) Values(@ad,@kamac,@yanet,@fiy,@gr,@adet,@ut,@skt,@sattar,@firma,@resim)", con);
                cmd.Parameters.AddWithValue("@ad", lb_ad.Text);
                cmd.Parameters.AddWithValue("@kamac", lb_kamac.Text);
                cmd.Parameters.AddWithValue("@yanet", lb_yetki.Text);
                cmd.Parameters.AddWithValue("@fiy", lb_tutar.Text);
                cmd.Parameters.AddWithValue("@gr", lb_gramaj.Text);
                cmd.Parameters.AddWithValue("@adet", int.Parse(lb_aa.Text));
                cmd.Parameters.AddWithValue("@ut", lb_ut.Text);
                cmd.Parameters.AddWithValue("@skt", lb_skt.Text);
                cmd.Parameters.AddWithValue("@sattar", tarih);
                cmd.Parameters.AddWithValue("@firma", firmaid);
                cmd.Parameters.AddWithValue("@resim", resim.Text);
                cmd.ExecuteNonQuery();
                



                OleDbCommand cmd2 = new OleDbCommand("update Ilaclar set adet=@adet where ilac_id="+ ilacid+"", con);
                cmd2.Parameters.AddWithValue("@adet", kalan);
                cmd2.ExecuteNonQuery();
                
                MessageBox.Show("Kayıt Başarıyla Gerçekleşti...");
                
            }
            else MessageBox.Show("İlaç stoğu yetersiz...");
            verileri_cek();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                fiyat = double.Parse(lb_fiyat.Text);
                adet = double.Parse(textBox1.Text);
                lb_tutar.Text = (fiyat * adet).ToString();
                lb_aa.Text = textBox1.Text;
            }
            else lb_tutar.Text = "0";
        }
    }
}
