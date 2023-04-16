using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.WaveFormRenderer;
using NAudio.Lame;
///Иногда по какой то неизведанной причине при рендере картинки
///Падает весь процесс, потому что получает на вход слишком много блоков(*?)
///

namespace WinFormsAppMixer
{
    public partial class Trim : Form
    {
        WasapiOut wasApiOut;
        AudioFileReader reader;
        AudioFileReader reader2;
        public Trim()
        {
            InitializeComponent();

        }

        private void Trim_Load(object sender, EventArgs e)
        {
            if (DataTransfer.InPath.Contains(".mp3"))
            {
                    using (Mp3FileReader mp3FileReader = new Mp3FileReader(DataTransfer.InPath))
                    {
                        using (WaveStream pcmstream = WaveFormatConversionStream.CreatePcmStream(mp3FileReader))
                        {
                            //WaveFileWriter.CreateWaveFile(saveFileDialog.FileName, pcmstream);
                            WaveFileWriter.CreateWaveFile(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav", pcmstream);
                        }
                    }
                    reader = new AudioFileReader(DataTransfer.InPath);
                    MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
                    RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200);
                    SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200);
                    AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);
                    StandardWaveFormRendererSettings settings = new StandardWaveFormRendererSettings();
                    settings.Width = pictureBox1.Width;
                    settings.TopHeight = pictureBox1.Height / 2;
                    settings.BottomHeight = pictureBox1.Height / 2;
                    settings.BackgroundColor = (System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24))))));
                    settings.TopPeakPen = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160))))));
                    settings.BottomPeakPen = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160))))));
                    WaveFormRenderer renderer = new WaveFormRenderer();
                    Image image = renderer.Render(reader, rmsPeakProvider, settings);
                    pictureBox1.Visible = true;
                    pictureBox1.Image = image;
                    reader2 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav");
                    reader.Dispose();
                    setup(reader2);
            }
        }

        void setup(AudioFileReader reader)
        {
            trackBarFrom.Maximum = (int)reader.TotalTime.TotalSeconds;
            trackBarTo.Maximum = (int)reader.TotalTime.TotalSeconds;
            trackBarFrom.Maximum = (int)reader.TotalTime.TotalSeconds;
            trackBarTo.Maximum = (int)reader.TotalTime.TotalSeconds;
            timer1.Start();
            AudioClientShareMode shareMode = AudioClientShareMode.Shared;
            bool useEventSync = false;
            var samplechanel = new SampleChannel(reader2, true);
            //var postVolumeMeter = new MeteringSampleProvider(samplechanel);
            reader.Volume = (float)trackBarVolume.Value / (float)trackBarVolume.Maximum;
            wasApiOut = new WasapiOut(shareMode, useEventSync, 50);
            wasApiOut.Init(samplechanel);
            
            Allow(true);
            labelCutFrom1.Text = reader2.CurrentTime.ToString(@"mm\:ss") + "/" + reader2.TotalTime.ToString(@"mm\:ss");
        }
        void Allow(bool isPlaying)
        {
            buttonPlay2.Enabled = isPlaying;
            buttonPause2.Enabled = !isPlaying;
        }

        private void buttonPlay2_Click(object sender, EventArgs e)
        {
            if (reader2 != null)
                if (wasApiOut.PlaybackState == PlaybackState.Paused)
                {
                    timer1.Start();
                    wasApiOut.Play();
                    Allow(false);
                }
                else
                {
                    trackBarFrom.Value = 0;
                    timer1.Start();
                    wasApiOut.Play();

                    Allow(false);
                    timer1.Enabled = true;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reader2 != null)
                trackBarTo.Value = (int)reader2.CurrentTime.TotalSeconds;
            labelСutTo.Text = reader2.CurrentTime.ToString(@"mm\:ss") + "/" + reader2.TotalTime.ToString(@"mm\:ss");
        }

        private void trackBarFrom_Scroll(object sender, EventArgs e)
        {
            if (reader2 != null)
            {
                reader2.CurrentTime = TimeSpan.FromSeconds(trackBarFrom.Value);
                labelCutFrom1.Text = reader2.CurrentTime.ToString(@"mm\:ss") + "/" + reader2.TotalTime.ToString(@"mm\:ss");
            }
                
        }

        private void trackBarTo_Scroll(object sender, EventArgs e)
        {
            if (reader2 != null)
                reader2.CurrentTime = TimeSpan.FromSeconds(trackBarTo.Value);
        }

        private void buttonPause2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wasApiOut.Pause();
            Allow(true);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            reader2.Volume = (float)trackBarVolume.Value / (float)trackBarVolume.Maximum;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cleanUp(reader2);
        }

        void cleanUp(AudioFileReader reader)
        {
            timer1.Stop();
            if (wasApiOut != null)
            {
                wasApiOut.Stop();
                wasApiOut.Dispose();
                wasApiOut = null;
            }
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }
            this.Dispose();
        }

        private void Trim_FormClosing(object sender, FormClosingEventArgs e)
        {
            cleanUp(reader2);
        }
        public void TrimFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            TimeSpan cutFromStart = TimeSpan.FromSeconds(trackBarFrom.Value);
            TimeSpan cutFromEnd = TimeSpan.FromSeconds(trackBarTo.Value);
            saveFileDialog.Filter = ".mp3(*.mp3)|*.mp3";
            int bytesPerMillisecond = reader2.WaveFormat.AverageBytesPerSecond / 1000;
            int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
            startPos = startPos - startPos % reader2.WaveFormat.BlockAlign;
            int endPos = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
            endPos = endPos - endPos % reader2.WaveFormat.BlockAlign;
            if (endPos <= startPos)
                MessageBox.Show("Выбирай правильно", "Внимание ", MessageBoxButtons.OK);
            else
                using (WaveFileWriter writer = new WaveFileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioTrimed.wav", reader2.WaveFormat))
                {
                    if(checkBox1.Checked==true)
                        reader2.Volume = 1f;
                    TrimWaveFile(reader2, writer, startPos, endPos);
                }

        }
        private void TrimWaveFile(AudioFileReader reader2, WaveFileWriter writer, int start, int end)
        {
            this.reader2.Position = start;
            byte[] buffer = new byte[1024];
            while (this.reader2.Position < end)
            {
                int bytesRequired = (int)(end - this.reader2.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = this.reader2.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.WriteData(buffer, 0, bytesRead);
                    }
                }
            }
            writer.Dispose();
            writer.Close();
            var reader3 = new WaveFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioTrimed.wav");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".mp3(*.mp3)|*.mp3";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writerLame = new LameMP3FileWriter(saveFileDialog.FileName, reader3.WaveFormat, 128))
                    reader3.CopyTo(writerLame);
                //FFMpeg.Convert(writer, saveFileDialog.FileName)
                reader3.Dispose();
                reader3.Close();
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            //buttonPause2_Click(null, null);
            TrimFile();
        }

        private void trackBarFrom_ValueChanged(object sender, EventArgs e)
        {
            if (reader2 != null)
            {
                reader2.CurrentTime = TimeSpan.FromSeconds(trackBarFrom.Value);
                labelCutFrom1.Text = reader2.CurrentTime.ToString(@"mm\:ss") + "/" + reader2.TotalTime.ToString(@"mm\:ss");
            }
        }
    }
}
