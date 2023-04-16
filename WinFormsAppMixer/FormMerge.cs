using NAudio.CoreAudioApi;
using NAudio.Gui;
using NAudio.Lame;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.WaveFormRenderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
//using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppMixer
{
    public partial class FormMerge : Form
    {
        WasapiOut wasApiOut;
        WasapiOut wasapiOutMerge;
        AudioFileReader reader2;
        AudioFileReader mergeReader;
        private readonly WaveFormRenderer formRenderer;
        private readonly WaveFormRendererSettings standardSettings;
        SaveFileDialog saveFileDialog;
        RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200);
        public FormMerge()
        {
            InitializeComponent();
            formRenderer = new WaveFormRenderer();
            standardSettings = new StandardWaveFormRendererSettings();
            standardSettings.BackgroundColor = (System.Drawing.Color.FromArgb(24, 24, 24));
            standardSettings.TopPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
            standardSettings.BottomPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
        }

        private void FormMerge_Load(object sender, EventArgs e)
        {
            var reader = new AudioFileReader(DataTransfer.InPath);
            using (Mp3FileReader mp3FileReader = new Mp3FileReader(DataTransfer.InPath))
            {
                using (WaveStream pcmstream = WaveFormatConversionStream.CreatePcmStream(mp3FileReader))
                {
                    //WaveFileWriter.CreateWaveFile(saveFileDialog.FileName, pcmstream);
                    WaveFileWriter.CreateWaveFile(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav", pcmstream);
                    labelName.Text = DataTransfer.FileName;
                }
            }
            render(reader, rmsPeakProvider, pictureBox1);
            reader.Dispose(); ;
            reader.Close();
            reader = null;
            reader2 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav");
            setup(reader2);
        }

        void render(AudioFileReader reader, IPeakProvider provider, PictureBox pictureBox)
        {
            Image image = null;
            try
            {
                standardSettings.Width = pictureBox.Width;
                standardSettings.Width = pictureBox.Width;
                standardSettings.TopHeight = pictureBox.Height / 2;
                standardSettings.BottomHeight = pictureBox.Height / 2;
                image = formRenderer.Render(reader, provider, standardSettings);
                pictureBox.Image = image;
                reader.Position = 0;
                pictureBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void setup(AudioFileReader reader)
        {
            trackBar1.Maximum = (int)reader.TotalTime.TotalSeconds;
            timer1.Start();
            AudioClientShareMode shareMode = AudioClientShareMode.Shared;
            bool useEventSync = false;
            var samplechanel = new SampleChannel(reader, true);
            //var postVolumeMeter = new MeteringSampleProvider(samplechanel);
            reader.Volume = (float)trackBarVolumeOriginal.Value / (float)trackBarVolumeOriginal.Maximum;
            reader.Position = 0;
            trackBar1.Value = ((int)reader.Position);
            wasApiOut = new WasapiOut(shareMode, useEventSync, 50);
            wasApiOut.Init(samplechanel);
            labelOriginal.Text = reader.CurrentTime.ToString(@"mm\:ss") + "/" + reader.TotalTime.ToString(@"mm\:ss");
            trackBar1.Value = ((int)reader.Position);
        }

        void AllowMerge(bool isPlaying)
        {
            buttonPauseOriginal.Enabled = isPlaying;
            buttonPauseOriginal.Enabled = !isPlaying;
        }

        void cleanUp()
        {
            if (wasapiOutMerge != null)
            {
                wasapiOutMerge.Dispose();
                wasapiOutMerge.Stop();
                wasapiOutMerge = null;
            }
            if(mergeReader!=null)
            {
                mergeReader.Close();
                mergeReader.Dispose();
                mergeReader = null;
            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "mp3(*.mp3)| *.mp3";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Chose music";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;
            DialogResult result;
            result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                cleanUp();
                songLabel2.Text = openFileDialog1.SafeFileName;
                using (Mp3FileReader mp3FileReader = new Mp3FileReader(openFileDialog1.FileName))
                {
                    using (WaveStream pcmstream = WaveFormatConversionStream.CreatePcmStream(mp3FileReader))
                    {
                        WaveFileWriter.CreateWaveFile(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerge.wav", pcmstream);
                        var reader = new AudioFileReader(openFileDialog1.FileName);
                        render(reader, rmsPeakProvider, pictureBox2);
                        reader.Dispose();
                        reader.Close();
                    }
                }
                mergeReader = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerge.wav");
                trackBarTo.Maximum = (int)mergeReader.TotalTime.TotalSeconds;
                trackBarFrom.Maximum = (int)mergeReader.TotalTime.TotalSeconds;
                timer2.Start();
                //var postVolumeMeter = new MeteringSampleProvider(samplechanel);
                mergeReader.Volume = (float)trackBarVolumeMerge.Value / (float)trackBarVolumeMerge.Maximum;
                mergeReader.Position = 0;
                trackBarTo.Value = ((int)mergeReader.Position);
                AudioClientShareMode shareMode = AudioClientShareMode.Shared;
                bool useEventSync = false;
                var samplechanel = new SampleChannel(mergeReader, true);
                wasapiOutMerge = new WasapiOut(shareMode, useEventSync, 50);
                wasapiOutMerge.Init(samplechanel);
                labelCutFrom.Text = mergeReader.CurrentTime.ToString(@"mm\:ss") + "/" + mergeReader.TotalTime.ToString(@"mm\:ss");
                AllowToControlMerge(false);
                wasapiOutMerge.Play();
                buttonPlayMerge_Click(sender, e);
            }
        }

        private void buttonPlayOriginal_Click(object sender, EventArgs e)
        {
            if (reader2 != null)
                if (wasApiOut.PlaybackState == PlaybackState.Paused)
                {
                    timer1.Start();
                    wasApiOut.Play();
                    AllowToControl(true);
                }
                else
                {

                    trackBar1.Enabled = true;
                    trackBar1.Maximum = (int)reader2.TotalTime.TotalSeconds;//настройка значения трекбара для отслеживания положения музыки
                    timer1.Start();
                    trackBar1.Value = 0;

                    //eForm
                    AllowToControlMerge(true);
                    wasApiOut.Play();
                    timer1.Enabled = true;
                }
        }
        void AllowToControl(bool isPlaing)
        {
            buttonPlayOriginal.Enabled = !isPlaing;
            buttonPauseOriginal.Enabled = isPlaing;
        }

        void AllowToControlMerge(bool isPlaing)
        {
            buttonPlayMerge.Enabled = !isPlaing;
            buttonPauseMerge.Enabled = isPlaing;
        }

        private void buttonPauseOriginal_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wasApiOut.Pause();
            AllowToControl(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reader2 != null)
                trackBar1.Value = (int)reader2.CurrentTime.TotalSeconds;
            labelOriginal.Text = reader2.CurrentTime.ToString(@"mm\:ss") + "/" + reader2.TotalTime.ToString(@"mm\:ss");

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (reader2 != null)
                reader2.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
        }

        private void trackBarVolumeOriginal_Scroll(object sender, EventArgs e)
        {
            if (reader2 != null)
                reader2.Volume = (float)trackBarVolumeOriginal.Value / (float)trackBarVolumeOriginal.Maximum;
        }

        private void FormMerge_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if(wasapiOutMerge!=null)
            {
                wasapiOutMerge.Stop();
                wasapiOutMerge.Dispose();
                wasapiOutMerge = null;
            }
            if (wasApiOut != null)
            {
                wasApiOut.Stop();
                wasApiOut.Dispose();
                wasApiOut = null;
            }
            if (reader2 != null)
            {
                reader2.Close();
                reader2.Dispose();
                reader2 = null;
            }
            if (mergeReader != null)
            {
                mergeReader.Close();
                mergeReader.Dispose();
                mergeReader = null;
            }
            
        }

        private void buttonPlayMerge_Click(object sender, EventArgs e)
        {
            if (mergeReader != null)
                if (wasapiOutMerge.PlaybackState == PlaybackState.Paused)
                {
                    timer2.Start();
                    wasapiOutMerge.Play();
                    AllowToControlMerge(true);
                }
                else
                {
                    trackBarTo.Enabled = true;
                    trackBarFrom.Enabled = true;
                    trackBarTo.Maximum = (int)mergeReader.TotalTime.TotalSeconds;//настройка значения трекбара для отслеживания положения музыки
                    trackBarFrom.Maximum = (int)mergeReader.TotalTime.TotalSeconds;
                    timer2.Start();
                    trackBarTo.Value = 0;

                    //eForm
                    AllowToControlMerge(true);
                    timer2.Enabled = true;
                }
        }

        private void buttonPauseMerge_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            wasapiOutMerge.Pause();
            AllowToControlMerge(false);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (mergeReader != null)
                trackBarTo.Value = (int)mergeReader.CurrentTime.TotalSeconds;
            labelCutTo1.Text = mergeReader.CurrentTime.ToString(@"mm\:ss") + "/" + mergeReader.TotalTime.ToString(@"mm\:ss");
        }

        private void trackBarTo_Scroll(object sender, EventArgs e)
        {
            if (mergeReader != null)
                mergeReader.CurrentTime = TimeSpan.FromSeconds(trackBarTo.Value);
        }

        private void trackBarFrom_Scroll(object sender, EventArgs e)
        {
            if (mergeReader != null)
            {
                mergeReader.CurrentTime = TimeSpan.FromSeconds(trackBarFrom.Value);
                labelCutFrom.Text = mergeReader.CurrentTime.ToString(@"mm\:ss") + "/" + mergeReader.TotalTime.ToString(@"mm\:ss");
            }
        }

        private void trackBarVolumeMerge_Scroll(object sender, EventArgs e)
        {
            mergeReader.Volume = (float)trackBarVolumeMerge.Value / (float)trackBarVolumeMerge.Maximum;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //customWaveViewer1.
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (trackBarFrom.Value > trackBarTo.Value)
                MessageBox.Show("Неверно выбрана обрезка аудио", "Ошибка", MessageBoxButtons.OK);
            else 
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                TimeSpan cutFromStart = TimeSpan.FromSeconds(trackBarFrom.Value);
                TimeSpan cutFromEnd = TimeSpan.FromSeconds(trackBarTo.Value);
                TimeSpan cutFromOriginal = TimeSpan.FromSeconds(trackBar1.Value);
                TimeSpan lenghOriginal = TimeSpan.FromSeconds(trackBar1.Maximum);
                saveFileDialog.Filter = ".mp3(*.mp3)|*.mp3";

                int bytesPerMillisecond = mergeReader.WaveFormat.AverageBytesPerSecond / 1000;
                int bPMOriginal = reader2.WaveFormat.AverageBytesPerSecond / 1000;
                int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                startPos = startPos - startPos % mergeReader.WaveFormat.BlockAlign;

                int endPos = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                endPos = endPos - endPos % mergeReader.WaveFormat.BlockAlign;
                //////////////////////////////////////////////////////////////
                

                int start = (int)cutFromOriginal.TotalMilliseconds * bPMOriginal;
                start = start - start % reader2.WaveFormat.BlockAlign;

                int end = (int)lenghOriginal.TotalMilliseconds * bPMOriginal;
                using (WaveFileWriter writer = new WaveFileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.wav", reader2.WaveFormat))
                {
                    TrimWaveFile(reader2, mergeReader, writer, startPos, endPos, start, end);
                }

                }
        }
        private void TrimWaveFile(AudioFileReader reader, AudioFileReader mergeReader, WaveFileWriter writer, int start, int end, int startOriginal, int endOriginal)
        {
            reader.Position = 0;
            mergeReader.Position = start;
            byte[] buffer = new byte[1024];
            while(reader.Position<startOriginal)
            {
                int bytesRequired = (int)(startOriginal - reader.Position);
                if(bytesRequired > 0)
                {
                    int bytesToRead= Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if(bytesRead > 0)
                        writer.Write(buffer, 0, bytesRead);
                }
                
            }
            writer.Dispose();
            writer.Close();

            var reader3 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.wav");
            using (var writerLame = new LameMP3FileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.mp3", reader3.WaveFormat, 128))
            {
                reader3.CopyTo(writerLame);
                writerLame.Dispose();
                writerLame.Close();
                var reader11 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.mp3");
                var resampler = new WdlResamplingSampleProvider(reader11, 44100);
                WaveFileWriter.CreateWaveFile16((System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged11.wav"), resampler);
                reader3.Dispose();
                reader3.Close();
            }
            using (WaveFileWriter writer2 = new WaveFileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.wav", mergeReader.WaveFormat))
            {
                while (mergeReader.Position < end)
                {
                    int bytesRequired = (int)(end - mergeReader.Position);
                    if (bytesRequired > 0)
                    {
                        int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                        int bytesRead = mergeReader.Read(buffer, 0, bytesToRead);
                        if (bytesRead > 0)
                            writer2.Write(buffer, 0, bytesRead);
                    }
                }
                writer2.Dispose();
                writer2.Close();
                var reader4 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.wav");
                using (var writerLame = new LameMP3FileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.mp3", reader4.WaveFormat, 128))
                {
                    reader4.CopyTo(writerLame);
                    writerLame.Dispose();
                    writerLame.Close();
                    var reader22 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.mp3");
                    var resampler = new WdlResamplingSampleProvider(reader22, 44100);
                    WaveFileWriter.CreateWaveFile16((System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged22.wav"), resampler);
                    reader4.Dispose();
                    reader4.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////
                using (WaveFileWriter writer3 = new WaveFileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.wav", reader2.WaveFormat))
                {
                    reader.Position = startOriginal;
                    while (reader.Position < endOriginal)
                    {
                        int bytesRequired = (int)(endOriginal - reader.Position);
                        if (bytesRequired > 0)
                        {
                            int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                            int bytesRead = reader.Read(buffer, 0, bytesToRead);
                            if (bytesRead > 0)
                                writer3.Write(buffer, 0, bytesRead);
                        }
                    }
                    writer3.Dispose();
                    writer3.Close();
                    var reader5 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.wav");
                    //////////////////////////////////////////////////////////////////////////////////////////////////////
                    using (var writerLame = new LameMP3FileWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.mp3", reader5.WaveFormat, 128))
                    {
                        reader5.CopyTo(writerLame);
                        writerLame.Dispose();
                        writerLame.Close();
                        var reader33 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.mp3");
                        var resampler = new WdlResamplingSampleProvider(reader33, 44100);
                        WaveFileWriter.CreateWaveFile16((System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged33.wav"), resampler);
                        reader5.Dispose();
                        reader5.Close();

                    }
                    writer.Dispose();
                    writer.Close();
                    writer2.Dispose();
                    writer2.Close();
                    writer3.Dispose();
                    writer3.Close();

                    AudioFileReader reader1mp3 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged11.wav");
                    AudioFileReader reader2mp3 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged22.wav");
                    AudioFileReader reader3mp3 = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged33.wav");
                    var playlist = new ConcatenatingSampleProvider(new[] { reader1mp3, reader2mp3, reader3mp3 });
                    WaveFileWriter.CreateWaveFile16(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMergedFULL.wav", playlist);
                    reader1mp3.Dispose();
                    reader1mp3.Close();
                    reader2mp3.Dispose();
                    reader2mp3.Close();
                    reader3mp3.Dispose();
                    reader3mp3.Close();
                    var sfd = new SaveFileDialog();
                    sfd.Filter = "mp3(*.mp3)| *.mp3";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var readerFinal = new AudioFileReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMergedFULL.wav");
                        using (var writerLame = new LameMP3FileWriter(sfd.FileName, readerFinal.WaveFormat, 128))
                        {
                            readerFinal.CopyTo(writerLame);
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged11.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged22.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged33.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.mp3");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.mp3");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.mp3");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged2.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMerged3.wav");
                            File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioMergedFULL.wav");
                        }
                        //FFMpeg.Convert(writer, saveFileDialog.FileName)
                    }
                }
            }

        }
        void trimSecondFile()
        {

        }
    }
}
