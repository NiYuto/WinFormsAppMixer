using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;

namespace WinFormsAppMixer
{
    static class DataTransfer//для передачи данных 
    {
        public static string InPath;
        public static string OutPath = ($"{Environment.CurrentDirectory}");
        public static TimeSpan span;
        
    }
}
