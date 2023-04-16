using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppMixer
{
    public class MyEqualizer : ISampleProvider
    {
        private readonly ISampleProvider sourceProvider;
        private readonly MyEqualizerBands[] bands;
        private readonly BiQuadFilter[,] filters;
        private readonly int channels;
        private readonly int bandCount;
        private bool update;


        public MyEqualizer(ISampleProvider sourceProvider, MyEqualizerBands[] bands)
        {
            this.sourceProvider = sourceProvider;
            this.bands = bands;
            channels = sourceProvider.WaveFormat.Channels;
            bandCount = bands.Length;
            filters = new BiQuadFilter[channels, bands.Length];
            CreateFilters();
        }

        private void CreateFilters()
        {
            for (int bandIndex = 0; bandIndex<bandCount;bandIndex++)
            {
                var band = bands[bandIndex];
                for(int n =0; n<channels;n++)
                {
                    if (filters[n, bandIndex] == null)
                        filters[n, bandIndex] = BiQuadFilter.PeakingEQ(sourceProvider.WaveFormat.SampleRate, band.Frequency, band.Bandwidth, band.Gain);
                    else
                        filters[n, bandIndex].SetPeakingEq(sourceProvider.WaveFormat.SampleRate, band.Frequency, band.Bandwidth, band.Gain);
                }
            }
        }
        public void Update()
        {
            update = true;
            CreateFilters();
        }
        public WaveFormat WaveFormat => sourceProvider.WaveFormat;

        public int Read(float[] buffer, int offset,int count)
        {
            int samplesRead = sourceProvider.Read(buffer, offset, count);
            if(update)
            {
                CreateFilters();
                update = false;
            }
            for(int n = 0;n<samplesRead;n++)
            {
                int ch = n % channels;
                for (int band = 0; band < bandCount; band++)
                {
                    buffer[offset + n] = filters[ch, band].Transform(buffer[offset + n]);
                }
            }
            return samplesRead;
        }
    }
}
