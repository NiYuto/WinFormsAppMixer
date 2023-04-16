namespace WinFormsAppMixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
            if(File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioTrimed.wav"))
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audioTrimed.wav");
            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav"))
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\audio.wav");
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}