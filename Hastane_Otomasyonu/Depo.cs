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
    public partial class Depo : Form
    {
        public Depo()
        {
            InitializeComponent();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Form2.MouseEnter(button2);
            Form2.Efect(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Form2.MouseLeave(button2);
            Form2.Efect(button2);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Form2.MouseEnter(button4);
            Form2.Efect(button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Form2.MouseLeave(button4);
            Form2.Efect(button4);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Form2.MouseEnter(button3);
            Form2.Efect(button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Form2.MouseLeave(button3);
            Form2.Efect(button3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Eczane();
            frm.MdiParent = MdiParent;
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Teal;
        }
    }
}
