using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Wave.SampleProviders;

namespace WinFormsAppMixer
{
    public partial class UserControl1 : UserControl
    {

        WasapiOut wasApiOut;
        AudioFileReader reader;
        Trim trimForm;
        EqualizerForm eForm;
        public UserControl1()
        {
           InitializeComponent();
           eForm = new EqualizerForm();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            wasApiOut.Stop();
            AllowToControl(false);
            reader.CurrentTime = TimeSpan.FromSeconds(0);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Music Formats|" +
                "*.mp3;*.wav|" +
                "mp3(*.mp3)|*.mp3 |" +
                "wav(*.wav)| *.wav";
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
                wasApiOut = new WasapiOut(shareMode, useEventSync, 50);
                //wasApiOut.Volume = 0.2f;
                reader = new AudioFileReader(openFileDialog1.FileName);
                var samplechanel = new SampleChannel(reader, true);
                var postVolumeMeter = new MeteringSampleProvider(samplechanel);
                reader.Volume = (float)trackBarVolume.Value / (float)trackBarVolume.Maximum;
                eForm.myEqualizer = eForm.GetEqualizer(postVolumeMeter);
                postVolumeMeter.StreamVolume += OnPostVolumeMeter;
                wasApiOut.Init(eForm.myEqualizer);
                AllowToControl(false);
                SpecialAllow(true);
                buttonPlay_Click(sender, e);
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (reader != null)
                if (wasApiOut.PlaybackState == PlaybackState.Paused)
                {
                    timer1.Start();
                    wasApiOut.Play();
                    AllowToControl(true);
                } 
                else
                {

                    trackBar.Enabled = true;
                    trackBar.Maximum = (int)reader.TotalTime.TotalSeconds;//настройка значения трекбара для отслеживания положения музыки
                    timer1.Start();
                    trackBar.Value = 0;
                    checkBoxMute.Enabled = true;
                    
                    //eForm
                    AllowToControl(true);
                    wasApiOut.Play();
                    timer1.Enabled = true;
                }
        }
        void AllowToControl(bool isPlaing)
        {
            buttonPlay.Enabled = !isPlaing;
            buttonStop.Enabled = isPlaing; 
            buttonPause.Enabled = isPlaing;
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if(reader != null)
            {
                if (checkBoxMute.Checked)
                    checkBoxMute.Checked = false;
                reader.Volume = (float)trackBarVolume.Value/(float)trackBarVolume.Maximum;  
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(reader != null)
                trackBar.Value =(int)reader.CurrentTime.TotalSeconds;
            labelTimer.Text=reader.CurrentTime.ToString(@"mm\:ss")+"/"+reader.TotalTime.ToString(@"mm\:ss");
            DataTransfer.span = reader.CurrentTime;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if(reader!=null)
                reader.CurrentTime = TimeSpan.FromSeconds(trackBar.Value);
        }
        void OnPostVolumeMeter(object sender,StreamVolumeEventArgs e)
        {
            volumeMeter1.Amplitude = e.MaxSampleValues[0];
        }

        private void checkBoxMute_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMute.Checked)
                reader.Volume = 0.0f;
            else
                reader.Volume = (float)trackBarVolume.Value / (float)trackBarVolume.Maximum;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wasApiOut.Pause();
            AllowToControl(false);
        }

        void cleanUp()
        {
            timer1.Stop();
            if(wasApiOut!=null)
            {
                wasApiOut.Stop();
                wasApiOut.Dispose();
                wasApiOut = null;
            }
            if(reader!=null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }
        }
        void SpecialAllow(bool fileGet)
        {
            equalizerBtn.Enabled = fileGet;
            buttonTrim.Enabled = fileGet;
            buttonMerge.Enabled = fileGet;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //this.ParentForm.FormClosing += new FormClosingEventHandler(ParentFormClosing);
        }

        void ParentFormClosing(object sender, FormClosingEventArgs e)
        {
            cleanUp();
        }

        private void buttonTrim_Click(object sender, EventArgs e)
        {
            buttonPause_Click(sender, e);
            DataTransfer.InPath=reader.FileName;
            Trim trim = (Trim)Application.OpenForms["Trim"];
            if (trim == null)
            {
                trim = new Trim();
                trim.Show();
                
            }
            else
                trim.Activate();
        }

        private void equalizerBtn_Click(object sender, EventArgs e)
        {
            eForm.Show();
            
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            buttonPause_Click(sender, e);
            DataTransfer.InPath = reader.FileName;
            FormMerge merge = (FormMerge)Application.OpenForms["Merge"];
            if(merge == null)
            {
                merge = new FormMerge();
                merge.Show();
            }
            else
                merge.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TestForm Test = (TestForm)Application.OpenForms["Test"];
            if (Test == null)
            {
                Test = new TestForm();
                Test.Show();
            }
            else
                Test.Activate();
        }
    }
}
