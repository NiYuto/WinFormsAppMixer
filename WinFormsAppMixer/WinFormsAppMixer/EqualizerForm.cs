using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppMixer
{
    public partial class EqualizerForm : Form
    {
        public readonly MyEqualizerBands[] bands;
        public MyEqualizer myEqualizer;
        public EqualizerForm()
        {
            InitializeComponent();
            bands =new MyEqualizerBands[]
            {
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 100,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 200,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 400,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 800,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 1200,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 2400,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 4800,Gain = 0},
                new MyEqualizerBands{ Bandwidth = 0.8f, Frequency = 9600,Gain = 0},
            };
        }
        public MyEqualizer GetEqualizer(MeteringSampleProvider msp)
        {
            return new MyEqualizer(msp, this.bands);
        }
        
        private void Value_change(object sender, EventArgs e)
        {
            var trackbar = sender as TrackBar;
            if (myEqualizer != null&&trackbar != null)
            {
                int filteredIndex = Int32.Parse((string)trackbar.Tag);
                bands[filteredIndex].Gain = trackbar.Value;
                if (myEqualizer != null)
                    myEqualizer.Update();
            }
        }

        private void EqualizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var trackvar in this.Controls.OfType<TrackBar>())
            {
                trackvar.Value = 0;
            }
            myEqualizer.Update();
        }
    }
}
