using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Hastane_Otomasyonu
{
    public partial class WepCam : Form
    {
        private FilterInfoCollection webcam; //bağlı olan kamera sayısı

        private VideoCaptureDevice cam; //kullanacağımız kamera

        public WepCam()
        {
            InitializeComponent();
        }

        private void WepCam_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice); //webcam dizisine mevcut kameraları dolduruluyor...
            foreach (FilterInfo item in webcam) comboBox1.Items.Add(item.Name); //bağlı kameralar combobox a dolduruluyor
            comboBox1.SelectedIndex = 0;//ilk kamera seçiliyor
        }
        void cam_yeni()
        {
            throw new NotImplementedException();//İstisna bulduğunda at
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString); //başlaya basıldığında cam değişkenine comboboxta seçilmiş olan kamerayı atıyoruz.
            cam.NewFrame += Cam_NewFrame;
            cam.Start(); //kamerayı başlatıyoruz.
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning) cam.Stop(); // kamerayı durduruyoruz.
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)pictureBox1.Image.Clone();
            DialogResult cevap = MessageBox.Show("Bu resim kaydedilsin mi?","[ Bilgi ]",MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "(*.jpg)|*.jpg|Bitma*p(*.bmp)|*.bmp";
                DialogResult dialog = sfd.ShowDialog();  
                if (dialog == DialogResult.OK) pictureBox2.Image.Save(sfd.FileName);
                MessageBox.Show("Kaydetme Başarılı...", "[ Bilgi ]");
                button1.Visible = false;
            }
            if (cam.IsRunning == true) cam.Stop();

        }

        private void WepCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Giris.KapatEnter(button4);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkSlateGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
