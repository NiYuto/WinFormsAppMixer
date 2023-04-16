using NAudio.WaveFormRenderer;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WinFormsAppMixer
{

    public partial class TestForm : Form
    {
        private string selectedFile;
        public readonly WaveFormRenderer waveFormRenderer;
        public readonly WaveFormRendererSettings standardSettings;
        public TestForm()
        {
            InitializeComponent();
            waveFormRenderer = new WaveFormRenderer();
            standardSettings = new StandardWaveFormRendererSettings();
            standardSettings.TopHeight = pictureBox1.Height / 2;
            standardSettings.BottomHeight = pictureBox1.Height / 2;
            standardSettings.Width = pictureBox1.Width;
            standardSettings.BackgroundColor = (System.Drawing.Color.FromArgb(24, 24, 24));
            standardSettings.TopPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
            standardSettings.BottomPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedFile == null) return;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files|*.mp3|WAV files|*.wav";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                selectedFile = ofd.FileName;
                RenderWaveform();
            }
        }
        private void RenderWaveform()
        {
            if (selectedFile == null) return;
            pictureBox1.Image = null;
            var rms = new RmsPeakProvider(200);
            Task.Factory.StartNew(() => RenderThread(rms, standardSettings));
        }

        private void RenderThread(IPeakProvider provider, WaveFormRendererSettings settings)
        {
            Image image = null;
            try
            {
                using(var waveStream = new AudioFileReader(selectedFile))
                {
                    image = waveFormRenderer.Render(waveStream, provider, settings);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BeginInvoke((Action)(()=>Finish(image)));
        }
        private void Finish(Image image)
        {
            pictureBox1.Image = image;
        }
    }
}
