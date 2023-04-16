using NAudio.CoreAudioApi;
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
        public FormMerge()
        {
            InitializeComponent();
            formRenderer = new WaveFormRenderer();
            standardSettings = new StandardWaveFormRendererSettings();
            standardSettings.TopHeight = pictureBox2.Height / 2;
            standardSettings.BottomHeight = pictureBox2.Height / 2;
            standardSettings.Width = pictureBox2.Width;
            standardSettings.BackgroundColor = (System.Drawing.Color.FromArgb(24, 24, 24));
            standardSettings.TopPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
            standardSettings.BottomPeakPen = new Pen(System.Drawing.Color.FromArgb(221, 192, 160));
        }

        private void FormMerge_Load(object sender, EventArgs e)
        {
            RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200);
            if (DataTransfer.InPath.Contains(".mp3"))
            {
                if(saveFileDialog!=null)
                    saveFileDialog.Dispose();
                
                DialogResult result = MessageBox.Show("Для редактирования аудиофайла требуется формат " +
                ".wav. Конвертировать файл?", "Внимание", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Wav File(*.wav)|*.wav";
                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        return;
                    using (MediaFoundationReader readerMedia = new MediaFoundationReader(DataTransfer.InPath))
                    {
                        WaveFileWriter.CreateWaveFile(saveFileDialog.FileName, readerMedia);
                    }
                    reader2 = new AudioFileReader(saveFileDialog.FileName);
                    setup(reader2);
                    render(reader2, rmsPeakProvider);
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = DataTransfer.InPath;
                reader2 = new AudioFileReader(ofd.FileName);
                setup(reader2);
                render(reader2,rmsPeakProvider);

            }
        }
        void render(AudioFileReader reader, IPeakProvider provider)
        {
            Image image = null;
            try
            {

                customWaveViewer1.WaveStream = new WaveFileReader(reader.FileName);
                customWaveViewer1.Visible = true;
                customWaveViewer1.Fit();
                reader.Position = 0;
                
                image = formRenderer.Render(reader,  provider, standardSettings);
                pictureBox2.Image = image;
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
            openFileDialog1.Filter = "wav(*.wav)| *.wav";
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
                labelName.Text = openFileDialog1.SafeFileName;
                AudioClientShareMode shareMode = AudioClientShareMode.Shared;
                bool useEventSync = false;
                wasapiOutMerge = new WasapiOut(shareMode, useEventSync, 50);
                //wasApiOut.Volume = 0.2f;
                mergeReader = new AudioFileReader(openFileDialog1.FileName);
                mergeReader.Volume = (float)trackBarVolumeOriginal.Value / (float)trackBarVolumeOriginal.Maximum;
                wasapiOutMerge.Init(mergeReader);
                wasapiOutMerge.Play();
                AllowToControlMerge(false);
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
                    AllowToControl(true);
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
            DataTransfer.span = reader2.CurrentTime;
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
                if (wasApiOut.PlaybackState == PlaybackState.Paused)
                {
                    timer2.Start();
                    wasapiOutMerge.Play();
                    AllowToControl(true);
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
                    wasapiOutMerge.Play();
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
    }
}
