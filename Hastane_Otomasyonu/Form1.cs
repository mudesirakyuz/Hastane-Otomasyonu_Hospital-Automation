using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Location = new Point(385, 32);
            button2.Location = new Point(415, 32);
            button3.Location = new Point(445, 32);
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                button1.Location = new Point(1440, 41);
                button2.Location = new Point(1470, 41);
                button3.Location = new Point(1500, 41);
            } 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldiniz @" + Giris.kullaniciadi + "...";
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch
                {
                }
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                button1.Location = new Point(1440, 41);
                button2.Location = new Point(1470, 41);
                button3.Location = new Point(1500, 41);
            }
            Form frm = new Form2();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void arkaPlanRengiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap==DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                MdiClient ctlMDI;
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        ctlMDI = (MdiClient)ctl;

                        ctlMDI.BackColor = this.BackColor;
                    }
                    catch
                    {
                    }
                }

            }
        }

        private void yazıRengiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                this.ForeColor = colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = fontDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }

        private void arkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                menuStrip1.BackColor = colorDialog1.Color;
            }
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                menuStrip1.ForeColor = colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = fontDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                menuStrip1.Font = fontDialog1.Font;
            }
        }

        private void arkaPlanRengiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                MdiClient ctlMDI;
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        ctlMDI = (MdiClient)ctl;

                        ctlMDI.BackColor = this.BackColor;
                    }
                    catch
                    {
                    }
                }

            }
        }

        private void yazıRengiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                this.ForeColor = colorDialog1.Color;
            }
        }

        private void yazıFontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = fontDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }

        private void arkaPlanRengiToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                contextMenuStrip1.BackColor = colorDialog1.Color;
            }
        }

        private void yazıRengiToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = colorDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                contextMenuStrip1.ForeColor = colorDialog1.Color;
            }
        }

        private void yazıFontuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = fontDialog1.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                contextMenuStrip1.Font = fontDialog1.Font;
            }
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void varsayılanStilAyarlarınıUygulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = Color.FromArgb(0,64,64);
                }
                catch
                {
                }
            }
            this.ForeColor = DefaultForeColor;
            this.Font = DefaultFont;
            menuStrip1.Font = DefaultFont;
            contextMenuStrip1.Font = DefaultFont;
            menuStrip1.ForeColor = DefaultForeColor;
            contextMenuStrip1.ForeColor = DefaultForeColor;
            menuStrip1.BackColor = DefaultBackColor;
            contextMenuStrip1.BackColor = DefaultBackColor;
        }

        private void varsayılanStilleriUygulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = Color.FromArgb(0, 64, 64);
                }
                catch
                {
                }
            }
            this.ForeColor = DefaultForeColor;
            this.Font = DefaultFont;
            menuStrip1.Font = DefaultFont;
            contextMenuStrip1.Font = DefaultFont;
            menuStrip1.ForeColor = DefaultForeColor;
            contextMenuStrip1.ForeColor = DefaultForeColor;
            menuStrip1.BackColor = DefaultBackColor;
            contextMenuStrip1.BackColor = DefaultBackColor;
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = DialogResult.No;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Application.StartupPath.ToString() + "\\ArkaPlanSes.wav";
            player.Play();

            a= MessageBox.Show("Hazırlayan: Müdesir Akyüz" + "\nNo: 184410019" + "\nSaygılarımla...","Hakkımızda...", MessageBoxButtons.OK,MessageBoxIcon.Information);
            if (a==DialogResult.OK)
            {
                player.Stop();
            }
        }
        void MouseEnter(Button b) 
        {
            b.BackColor = Color.Red;
            b.ForeColor = Color.White;
        }
        void MouseLeave(Button b)
        {
            b.BackColor = Color.White;
            b.ForeColor = Color.Black;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button1);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button3);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button3);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(button2);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(button2);
        }

        private void menüToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menüToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
