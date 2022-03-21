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
    public partial class Eczane : Form
    {

        public Eczane()
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
        private void Eczane_Load(object sender, EventArgs e)
        {
            Vezne.BigPicture_Control = "Eczane";

            dataGridView1.ForeColor = Color.DarkRed;
            combo = comboBox1.SelectedIndex + 1;
            if (con.State == ConnectionState.Closed) con.Open();
            verileri_cek();
            bs.DataSource = ds.Tables["Ilaclar"];
            dataGridView1.DataSource = bs;

            ilacidkontrol = true;

            if (ds.Tables["Ilaclar"].Rows.Count != 0)
            {
                comboBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox1.DataBindings.Add("Text", ds, "Ilaclar.ilac_adi");
                textBox2.DataBindings.Add("Text", ds, "Ilaclar.kullanim_amaci");
                textBox3.DataBindings.Add("Text", ds, "Ilaclar.yan_etkileri");
                textBox4.DataBindings.Add("Text", ds, "Ilaclar.fiyat");
                textBox5.DataBindings.Add("Text", ds, "Ilaclar.gramaj");
                textBox6.DataBindings.Add("Text", ds, "Ilaclar.adet");
                dateTimePicker1.DataBindings.Add("Text", ds, "Ilaclar.ut");
                dateTimePicker2.DataBindings.Add("Text", ds, "Ilaclar.skt");
            }


            con.Close();
        }
        int combo = 1;
        private void yeni_Click(object sender, EventArgs e)
        {
            dosya = resim2.Text;
            button1.Enabled = true;
            ekle.Enabled = true;
            bosgecilemez = true;
            yenimi = true;
            iptal.Visible = true;
            kaydet.Visible = true;

            if (comboBox1.Items.Count != 0) comboBox1.Items.Clear();

            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select firma_ad from Firma", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) comboBox1.Items.Add(dr[0].ToString());
            con.Close();

            if (ds.Tables["Ilaclar"].Rows.Count != 0)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd2 = new OleDbCommand("select firma_id,firma_ad from Firma", con);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    if (dr2[1].ToString() == comboBox1.Text) combo = int.Parse(dr2[0].ToString());
                }
                con.Close();
            }



            duzelt.Enabled = false;
            yeni.Enabled = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }
        private void duzelt_Click(object sender, EventArgs e)
        {
            dosya = resim2.Text;
            button1.Enabled = true;
            ekle.Enabled = true;
            bosgecilemez = true;
            yenimi = false;
            iptal.Visible = true;
            kaydet.Visible = true;

            if (comboBox1.Items.Count != 0) comboBox1.Items.Clear();

            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select firma_id,firma_ad from Firma", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
                if (dr[1].ToString() == comboBox1.Text) combo = int.Parse(dr[0].ToString());
            }
            con.Close();
            if (ilacidkontrol == false)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd2 = new OleDbCommand("select ilac_id from Ilaclar where ilac_adi=@ad", con);
                cmd2.Parameters.AddWithValue("@ad", textBox1.Text);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read()) ilacid = dr2[0].ToString();
                con.Close();
            }


            duzelt.Enabled = false;
            yeni.Enabled = false;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ekle.Enabled = false;
            iptal.Visible = false;
            kaydet.Visible = false;

            duzelt.Enabled = true;
            yeni.Enabled = true;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }
        ErrorProvider eror = new ErrorProvider();
        bool bosgecilemez = true;
        private void kaydet_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ekle.Enabled = false;
            iptal.Visible = false;
            kaydet.Visible = false;
            if (con.State == ConnectionState.Closed) con.Open();

            if (comboBox1.Text == "") eror.SetError(comboBox1, "Boş Geçilemez");
            else if (textBox1.Text == "") eror.SetError(textBox1, "Boş Geçilemez");
            else if (textBox2.Text == "") eror.SetError(textBox2, "Boş Geçilemez");
            else if (textBox3.Text == "") eror.SetError(textBox3, "Boş Geçilemez");
            else if (textBox4.Text == "") eror.SetError(textBox4, "Boş Geçilemez");
            else if (textBox5.Text == "") eror.SetError(textBox5, "Boş Geçilemez");
            else if (textBox6.Text == "") eror.SetError(textBox6, "Boş Geçilemez");
            else bosgecilemez = false;

            if (bosgecilemez == false)
            {
                bosgecilemez = true;
                if (yenimi == true)//insert
                {
                    OleDbCommand cmd = new OleDbCommand("insert into Ilaclar(ilac_adi,kullanim_amaci,yan_etkileri,fiyat,gramaj,adet,ut,skt,firma_id,resim) Values(@ad,@kamac,@yanet,@fiy,@gr,@adet,@ut,@skt,@firma,@resim)", con);
                    cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@kamac", textBox2.Text);
                    cmd.Parameters.AddWithValue("@yanet", textBox3.Text);
                    cmd.Parameters.AddWithValue("@fiy", textBox4.Text);
                    cmd.Parameters.AddWithValue("@gr", textBox5.Text);
                    cmd.Parameters.AddWithValue("@adet", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ut", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@skt", dateTimePicker2.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@firma", combo);
                    cmd.Parameters.AddWithValue("@resim", resim.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Gerçekleşti...");
                }
                else//update
                {
                    OleDbCommand cmd = new OleDbCommand("update Ilaclar set ilac_adi=@ad,kullanim_amaci=@kamac,yan_etkileri=@yanet,fiyat=@fiy,gramaj=@gr,adet=@adet,ut=@ut,skt=@skt,firma_id=@firma,resim=@resim where ilac_id=@id", con);
                    cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@kamac", textBox2.Text);
                    cmd.Parameters.AddWithValue("@yanet", textBox3.Text);
                    cmd.Parameters.AddWithValue("@fiy", textBox4.Text);
                    cmd.Parameters.AddWithValue("@gr", textBox5.Text);
                    cmd.Parameters.AddWithValue("@adet", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ut", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@skt", dateTimePicker2.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@firma", combo);
                    cmd.Parameters.AddWithValue("@resim", resim.Text);
                    cmd.Parameters.AddWithValue("@id", int.Parse(ilacid));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Düzeltme Başarıyla Gerçekleşti...");
                }
            }
            verileri_cek();
            
            duzelt.Enabled = true;
            yeni.Enabled = true;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        string ilacid = "1";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


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

                con.Close();
            }
            catch { }

        }
        bool ilacidkontrol;
        private void Eczane_MouseEnter(object sender, EventArgs e)
        {
            if (ilacidkontrol == true)
            {
                ilacidkontrol = false;
                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd = new OleDbCommand("select ilac_id from Ilaclar where ilac_adi=@ad", con);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) ilacid = dr[0].ToString();
                con.Close();
            }

        }

        private void sil_Click(object sender, EventArgs e)
        {
            if (ilacidkontrol == false)
            {
                if (con.State == ConnectionState.Closed) con.Open();
                OleDbCommand cmd = new OleDbCommand("select ilac_id from Ilaclar where ilac_adi=@ad", con);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) ilacid = dr[0].ToString();
                con.Close();
            }
            if (con.State == ConnectionState.Closed) con.Open();
            DialogResult c = MessageBox.Show("Eminmisiniz?", "Bilgi", MessageBoxButtons.YesNo);
            if (c == DialogResult.Yes)
            {

                OleDbCommand cmd = new OleDbCommand("delete from Ilaclar where ilac_id=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(ilacid));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi...");
            }
            else MessageBox.Show("Kayıt Silme İşlemi İptal Edildi...");
            con.Close();
            verileri_cek();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id AND ilac_adi like '%" + textBox7.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Ilaclar");
            if (label9.Text != null) label9.Visible = true;
            else label9.Visible = false;
            if (label10.Visible == true) label10.Visible = false;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter dr = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id AND kullanim_amaci like '%" + textBox8.Text + "%'", con);
            ds.Clear();
            dr.Fill(ds, "Ilaclar");
            if (label10.Text != null) label10.Visible = true;
            else label10.Visible = false;
            if (label9.Visible == true) label9.Visible = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.MdiParent = MdiParent;
            frm.Show();
            this.Close();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosya_yolu = dosya.FileName;
            resim.Text = dosya_yolu;
            pictureBox1.ImageLocation = dosya_yolu;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo = comboBox1.SelectedIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new WepCam();
            frm.Show();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button3);
        }
        public static string dosya;
        private void button2_Click(object sender, EventArgs e)
        {
            dosya = resim2.Text;
            Form frm = new BigPicture();
            frm.Show();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Green;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.YellowGreen;
            button4.ForeColor = Color.Crimson;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new Raporlama_Eczane();
            frm.MdiParent = MdiParent;
            frm.Show();

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
