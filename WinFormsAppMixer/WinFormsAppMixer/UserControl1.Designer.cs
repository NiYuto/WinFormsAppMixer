namespace WinFormsAppMixer
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxMute = new System.Windows.Forms.CheckBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.equalizerBtn = new System.Windows.Forms.Button();
            this.buttonTrim = new System.Windows.Forms.Button();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.FlatAppearance.BorderSize = 0;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Image = global::WinFormsAppMixer.Properties.Resources.icons8_opened_folder_48;
            this.buttonOpen.Location = new System.Drawing.Point(6, 115);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(58, 54);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = global::WinFormsAppMixer.Properties.Resources.icons8_play_64;
            this.buttonPlay.Location = new System.Drawing.Point(79, 115);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(49, 54);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Image = global::WinFormsAppMixer.Properties.Resources.icons8_pause_67;
            this.buttonPause.Location = new System.Drawing.Point(129, 115);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(49, 54);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Image = global::WinFormsAppMixer.Properties.Resources.icons8_stop_50;
            this.buttonStop.Location = new System.Drawing.Point(186, 119);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 52);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // trackBar
            // 
            this.trackBar.Enabled = false;
            this.trackBar.Location = new System.Drawing.Point(24, 179);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(470, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(570, 119);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(45, 125);
            this.trackBarVolume.TabIndex = 6;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarVolume.Value = 20;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.label2.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.label2.Location = new System.Drawing.Point(500, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Volume";
            // 
            // checkBoxMute
            // 
            this.checkBoxMute.AutoSize = true;
            this.checkBoxMute.Enabled = false;
            this.checkBoxMute.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxMute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.checkBoxMute.Location = new System.Drawing.Point(500, 160);
            this.checkBoxMute.Name = "checkBoxMute";
            this.checkBoxMute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxMute.Size = new System.Drawing.Size(64, 25);
            this.checkBoxMute.TabIndex = 8;
            this.checkBoxMute.Text = "Mute";
            this.checkBoxMute.UseVisualStyleBackColor = true;
            this.checkBoxMute.CheckedChanged += new System.EventHandler(this.checkBoxMute_CheckedChanged);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelTimer.Location = new System.Drawing.Point(407, 151);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(65, 18);
            this.labelTimer.TabIndex = 9;
            this.labelTimer.Text = "00:00/00:00";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "mp3|*.mp3";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelName.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.labelName.Location = new System.Drawing.Point(16, 214);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(88, 21);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Song Label";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.Location = new System.Drawing.Point(16, 238);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter1.Size = new System.Drawing.Size(86, 23);
            this.volumeMeter1.TabIndex = 11;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // equalizerBtn
            // 
            this.equalizerBtn.Enabled = false;
            this.equalizerBtn.FlatAppearance.BorderSize = 0;
            this.equalizerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.equalizerBtn.Image = global::WinFormsAppMixer.Properties.Resources.icons8_adjust_60;
            this.equalizerBtn.Location = new System.Drawing.Point(250, 119);
            this.equalizerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.equalizerBtn.Name = "equalizerBtn";
            this.equalizerBtn.Size = new System.Drawing.Size(56, 52);
            this.equalizerBtn.TabIndex = 12;
            this.equalizerBtn.UseVisualStyleBackColor = true;
            this.equalizerBtn.Click += new System.EventHandler(this.equalizerBtn_Click);
            // 
            // buttonTrim
            // 
            this.buttonTrim.Enabled = false;
            this.buttonTrim.FlatAppearance.BorderSize = 0;
            this.buttonTrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrim.Image = global::WinFormsAppMixer.Properties.Resources.icons8_barber_scissors_50;
            this.buttonTrim.Location = new System.Drawing.Point(8, 53);
            this.buttonTrim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTrim.Name = "buttonTrim";
            this.buttonTrim.Size = new System.Drawing.Size(56, 52);
            this.buttonTrim.TabIndex = 13;
            this.buttonTrim.UseVisualStyleBackColor = true;
            this.buttonTrim.Click += new System.EventHandler(this.buttonTrim_Click);
            // 
            // buttonMerge
            // 
            this.buttonMerge.Enabled = false;
            this.buttonMerge.FlatAppearance.BorderSize = 0;
            this.buttonMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMerge.Image = global::WinFormsAppMixer.Properties.Resources.icons8_объединение_по_горизонтали_48;
            this.buttonMerge.Location = new System.Drawing.Point(72, 53);
            this.buttonMerge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(56, 52);
            this.buttonMerge.TabIndex = 14;
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::WinFormsAppMixer.Properties.Resources.icons8_opened_folder_48;
            this.button1.Location = new System.Drawing.Point(136, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 54);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.buttonTrim);
            this.Controls.Add(this.equalizerBtn);
            this.Controls.Add(this.volumeMeter1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.checkBoxMute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonOpen);
            this.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(633, 272);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOpen;
        private Button buttonPlay;
        private Button buttonPause;
        private Button buttonStop;
        private TrackBar trackBar;
        private TrackBar trackBarVolume;
        private Label label2;
        private CheckBox checkBoxMute;
        private Label labelTimer;
        private OpenFileDialog openFileDialog1;
        private Label labelName;
        private System.Windows.Forms.Timer timer1;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private Button equalizerBtn;
        private Button buttonTrim;
        private Button buttonMerge;
        private Button button1;
    }
}
