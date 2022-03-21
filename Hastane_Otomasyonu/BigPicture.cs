using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class BigPicture : Form
    {
        public BigPicture()
        {
            InitializeComponent();
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

        private void BigPicture_Load(object sender, EventArgs e)
        {
            if (Vezne.BigPicture_Control=="Vezne") pictureBox1.ImageLocation = Vezne.dosya;
            if (Vezne.BigPicture_Control == "Eczane") pictureBox1.ImageLocation = Eczane.dosya;
        }
    }
}
