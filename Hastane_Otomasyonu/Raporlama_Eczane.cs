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
    public partial class Raporlama_Eczane : Form
    {
        public Raporlama_Eczane()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");
        DataSet ds = new DataSet();
        private void Raporlama_Eczane_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet1 ds = new DataSet1();
            this.reportViewer1.Reset();

            OleDbDataAdapter da = new OleDbDataAdapter("Select Ilaclar.*,Firma.firma_ad from Ilaclar,Firma where Ilaclar.firma_id=Firma.firma_id AND Ilaclar.ilac_adi like '%" + textBox1.Text + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Eczane.rdlc";
            this.reportViewer1.RefreshReport();

            con.Close();

            
            if (label1.Text != null) label1.Visible = true;
            else label1.Visible = false;
            if (label2.Visible == true) label2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet1 ds = new DataSet1();
            this.reportViewer1.Reset();

            OleDbDataAdapter da = new OleDbDataAdapter("Select Ilaclar.*,Firma.firma_ad from Ilaclar,Firma where Ilaclar.firma_id=Firma.firma_id AND Ilaclar.kullanim_amaci like '%" + textBox2.Text + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Eczane.rdlc";
            this.reportViewer1.RefreshReport();

            con.Close();

            if (label2.Text != null) label2.Visible = true;
            else label2.Visible = false;
            if (label1.Visible == true) label1.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet1 ds = new DataSet1();
            this.reportViewer1.Reset();

            OleDbDataAdapter da = new OleDbDataAdapter("Select Ilaclar.*,Firma.firma_ad from Ilaclar,Firma where Ilaclar.firma_id=Firma.firma_id AND Firma.firma_ad like '%" + textBox3.Text + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Eczane.rdlc";
            this.reportViewer1.RefreshReport();

            con.Close();
            if (label3.Text != null) label3.Visible = true;
            else label3.Visible = false;
            if (label4.Visible == true) label4.Visible = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet1 ds = new DataSet1();
            this.reportViewer1.Reset();

            OleDbDataAdapter da = new OleDbDataAdapter("Select Ilaclar.*,Firma.firma_ad from Ilaclar,Firma where Ilaclar.firma_id=Firma.firma_id AND Ilaclar.skt like '%" + dateTimePicker2.Value.ToShortDateString() + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Eczane.rdlc";
            this.reportViewer1.RefreshReport();

            con.Close();

            if (label4.Text != null) label4.Visible = true;
            else label4.Visible = false;
            if (label3.Visible == true) label3.Visible = false;
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
    }
}
