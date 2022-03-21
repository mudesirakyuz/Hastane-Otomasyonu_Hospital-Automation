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
    public partial class Satislar : Form
    {
        public Satislar()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        void verileri_cek()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select Firma.firma_ad,Ilaclar.ilac_adi,Ilaclar.kullanim_amaci,Ilaclar.yan_etkileri,Ilaclar.fiyat,Ilaclar.gramaj,Ilaclar.adet,Ilaclar.ut,Ilaclar.skt from Firma,Ilaclar where Firma.firma_id=Ilaclar.firma_id", con);
            ds.Clear();
            da.Fill(ds, "Ilaclar");
        }
        private void Satislar_Load(object sender, EventArgs e)
        {
            dataGridView1.ForeColor = Color.DarkRed;
            if (con.State == ConnectionState.Closed) con.Open();
            verileri_cek();
            bs.DataSource = ds.Tables["Ilaclar"];
            dataGridView1.DataSource = bs;

            


            con.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }
    }
}
