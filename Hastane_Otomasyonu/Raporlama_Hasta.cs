using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;

namespace Hastane_Otomasyonu
{
    public partial class Raporlama_Hasta : Form
    {
        public Raporlama_Hasta()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projeler\Hastane Otomasyonu Proje\Hastane_Otomasyonu\Hastane_Otomasyonu\bin\Debug\bin\Debug\Veritabani.mdb");

        private void Raporlama_Hasta_Load(object sender, EventArgs e)
        {
            
            ReportDataSource rds =new ReportDataSource("DataSet1", Vezne.ds.Tables["Hasta"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet1 ds = new DataSet1();
            this.reportViewer1.Reset();

            OleDbDataAdapter da = new OleDbDataAdapter("Select * From Hasta where hasta_tc like '%" + textBox1.Text + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Hasta.rdlc";
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

            OleDbDataAdapter da = new OleDbDataAdapter("Select * From Hasta where hasta_ad like '%" + textBox2.Text + "%'", con);

            da.Fill(ds, ds.Tables[0].TableName);
            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Hasta.rdlc";
            this.reportViewer1.RefreshReport();

            con.Close();

            if (label2.Text != null) label2.Visible = true;
            else label2.Visible = false;
            if (label1.Visible == true) label1.Visible = false;
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
