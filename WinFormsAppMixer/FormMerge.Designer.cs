namespace WinFormsAppMixer
{
    partial class FormMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelName = new System.Windows.Forms.Label();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelVolumeOriginal = new System.Windows.Forms.Label();
            this.trackBarVolumeOriginal = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.trackBarTo = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCutTo1 = new System.Windows.Forms.Label();
            this.trackBarFrom = new System.Windows.Forms.TrackBar();
            this.labelCutFrom = new System.Windows.Forms.Label();
            this.labelVoluleMerge = new System.Windows.Forms.Label();
            this.trackBarVolumeMerge = new System.Windows.Forms.TrackBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonPauseOriginal = new System.Windows.Forms.Button();
            this.buttonPlayOriginal = new System.Windows.Forms.Button();
            this.buttonPauseMerge = new System.Windows.Forms.Button();
            this.buttonPlayMerge = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.songLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeMerge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelName.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.labelName.Location = new System.Drawing.Point(13, 299);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(88, 21);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Song Label";
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelOriginal.Location = new System.Drawing.Point(554, 299);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(65, 18);
            this.labelOriginal.TabIndex = 18;
            this.labelOriginal.Text = "00:00/00:00";
            // 
            // labelVolumeOriginal
            // 
            this.labelVolumeOriginal.AutoSize = true;
            this.labelVolumeOriginal.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVolumeOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelVolumeOriginal.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.labelVolumeOriginal.Location = new System.Drawing.Point(625, 157);
            this.labelVolumeOriginal.Name = "labelVolumeOriginal";
            this.labelVolumeOriginal.Size = new System.Drawing.Size(60, 21);
            this.labelVolumeOriginal.TabIndex = 16;
            this.labelVolumeOriginal.Text = "Volume";
            // 
            // trackBarVolumeOriginal
            // 
            this.trackBarVolumeOriginal.Location = new System.Drawing.Point(691, 105);
            this.trackBarVolumeOriginal.Maximum = 100;
            this.trackBarVolumeOriginal.Name = "trackBarVolumeOriginal";
            this.trackBarVolumeOriginal.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolumeOriginal.Size = new System.Drawing.Size(45, 125);
            this.trackBarVolumeOriginal.TabIndex = 15;
            this.trackBarVolumeOriginal.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarVolumeOriginal.Value = 20;
            this.trackBarVolumeOriginal.Scroll += new System.EventHandler(this.trackBarVolumeOriginal_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(24, 264);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(595, 45);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonOpen
            // 
            this.buttonOpen.FlatAppearance.BorderSize = 0;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Image = global::WinFormsAppMixer.Properties.Resources.icons8_opened_folder_48;
            this.buttonOpen.Location = new System.Drawing.Point(13, 325);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(58, 54);
            this.buttonOpen.TabIndex = 11;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // trackBarTo
            // 
            this.trackBarTo.Enabled = false;
            this.trackBarTo.Location = new System.Drawing.Point(24, 387);
            this.trackBarTo.Maximum = 100;
            this.trackBarTo.Name = "trackBarTo";
            this.trackBarTo.Size = new System.Drawing.Size(595, 45);
            this.trackBarTo.TabIndex = 20;
            this.trackBarTo.Scroll += new System.EventHandler(this.trackBarTo_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(34, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(585, 178);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCutTo1
            // 
            this.labelCutTo1.AutoSize = true;
            this.labelCutTo1.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCutTo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelCutTo1.Location = new System.Drawing.Point(554, 361);
            this.labelCutTo1.Name = "labelCutTo1";
            this.labelCutTo1.Size = new System.Drawing.Size(65, 18);
            this.labelCutTo1.TabIndex = 25;
            this.labelCutTo1.Text = "00:00/00:00";
            // 
            // trackBarFrom
            // 
            this.trackBarFrom.Enabled = false;
            this.trackBarFrom.Location = new System.Drawing.Point(24, 594);
            this.trackBarFrom.Maximum = 100;
            this.trackBarFrom.Name = "trackBarFrom";
            this.trackBarFrom.Size = new System.Drawing.Size(595, 45);
            this.trackBarFrom.TabIndex = 26;
            this.trackBarFrom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarFrom.Scroll += new System.EventHandler(this.trackBarFrom_Scroll);
            // 
            // labelCutFrom
            // 
            this.labelCutFrom.AutoSize = true;
            this.labelCutFrom.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCutFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelCutFrom.Location = new System.Drawing.Point(565, 624);
            this.labelCutFrom.Name = "labelCutFrom";
            this.labelCutFrom.Size = new System.Drawing.Size(65, 18);
            this.labelCutFrom.TabIndex = 27;
            this.labelCutFrom.Text = "00:00/00:00";
            // 
            // labelVoluleMerge
            // 
            this.labelVoluleMerge.AutoSize = true;
            this.labelVoluleMerge.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVoluleMerge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelVoluleMerge.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.labelVoluleMerge.Location = new System.Drawing.Point(625, 504);
            this.labelVoluleMerge.Name = "labelVoluleMerge";
            this.labelVoluleMerge.Size = new System.Drawing.Size(60, 21);
            this.labelVoluleMerge.TabIndex = 29;
            this.labelVoluleMerge.Text = "Volume";
            // 
            // trackBarVolumeMerge
            // 
            this.trackBarVolumeMerge.Location = new System.Drawing.Point(691, 449);
            this.trackBarVolumeMerge.Maximum = 100;
            this.trackBarVolumeMerge.Name = "trackBarVolumeMerge";
            this.trackBarVolumeMerge.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolumeMerge.Size = new System.Drawing.Size(45, 125);
            this.trackBarVolumeMerge.TabIndex = 28;
            this.trackBarVolumeMerge.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarVolumeMerge.Value = 20;
            this.trackBarVolumeMerge.Scroll += new System.EventHandler(this.trackBarVolumeMerge_Scroll);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Image = global::WinFormsAppMixer.Properties.Resources.icons8_close_50;
            this.buttonCancel.Location = new System.Drawing.Point(745, 349);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(49, 54);
            this.buttonCancel.TabIndex = 33;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.FlatAppearance.BorderSize = 0;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Image = global::WinFormsAppMixer.Properties.Resources.icons8_accept_67;
            this.buttonAccept.Location = new System.Drawing.Point(745, 278);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(49, 54);
            this.buttonAccept.TabIndex = 32;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonPauseOriginal
            // 
            this.buttonPauseOriginal.FlatAppearance.BorderSize = 0;
            this.buttonPauseOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPauseOriginal.Image = global::WinFormsAppMixer.Properties.Resources.icons8_pause_67;
            this.buttonPauseOriginal.Location = new System.Drawing.Point(743, 172);
            this.buttonPauseOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPauseOriginal.Name = "buttonPauseOriginal";
            this.buttonPauseOriginal.Size = new System.Drawing.Size(49, 54);
            this.buttonPauseOriginal.TabIndex = 31;
            this.buttonPauseOriginal.UseVisualStyleBackColor = true;
            this.buttonPauseOriginal.Click += new System.EventHandler(this.buttonPauseOriginal_Click);
            // 
            // buttonPlayOriginal
            // 
            this.buttonPlayOriginal.FlatAppearance.BorderSize = 0;
            this.buttonPlayOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayOriginal.Image = global::WinFormsAppMixer.Properties.Resources.icons8_play_64;
            this.buttonPlayOriginal.Location = new System.Drawing.Point(743, 89);
            this.buttonPlayOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlayOriginal.Name = "buttonPlayOriginal";
            this.buttonPlayOriginal.Size = new System.Drawing.Size(49, 54);
            this.buttonPlayOriginal.TabIndex = 30;
            this.buttonPlayOriginal.UseVisualStyleBackColor = true;
            this.buttonPlayOriginal.Click += new System.EventHandler(this.buttonPlayOriginal_Click);
            // 
            // buttonPauseMerge
            // 
            this.buttonPauseMerge.FlatAppearance.BorderSize = 0;
            this.buttonPauseMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPauseMerge.Image = global::WinFormsAppMixer.Properties.Resources.icons8_pause_67;
            this.buttonPauseMerge.Location = new System.Drawing.Point(743, 532);
            this.buttonPauseMerge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPauseMerge.Name = "buttonPauseMerge";
            this.buttonPauseMerge.Size = new System.Drawing.Size(49, 54);
            this.buttonPauseMerge.TabIndex = 35;
            this.buttonPauseMerge.UseVisualStyleBackColor = true;
            this.buttonPauseMerge.Click += new System.EventHandler(this.buttonPauseMerge_Click);
            // 
            // buttonPlayMerge
            // 
            this.buttonPlayMerge.FlatAppearance.BorderSize = 0;
            this.buttonPlayMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayMerge.Image = global::WinFormsAppMixer.Properties.Resources.icons8_play_64;
            this.buttonPlayMerge.Location = new System.Drawing.Point(743, 449);
            this.buttonPlayMerge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlayMerge.Name = "buttonPlayMerge";
            this.buttonPlayMerge.Size = new System.Drawing.Size(49, 54);
            this.buttonPlayMerge.TabIndex = 34;
            this.buttonPlayMerge.UseVisualStyleBackColor = true;
            this.buttonPlayMerge.Click += new System.EventHandler(this.buttonPlayMerge_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(34, 414);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(585, 178);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // songLabel2
            // 
            this.songLabel2.AutoSize = true;
            this.songLabel2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.songLabel2.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.songLabel2.Location = new System.Drawing.Point(13, 624);
            this.songLabel2.Name = "songLabel2";
            this.songLabel2.Size = new System.Drawing.Size(88, 21);
            this.songLabel2.TabIndex = 37;
            this.songLabel2.Text = "Song Label";
            // 
            // FormMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(821, 651);
            this.Controls.Add(this.songLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonPauseMerge);
            this.Controls.Add(this.buttonPlayMerge);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonPauseOriginal);
            this.Controls.Add(this.buttonPlayOriginal);
            this.Controls.Add(this.labelVoluleMerge);
            this.Controls.Add(this.trackBarVolumeMerge);
            this.Controls.Add(this.labelCutFrom);
            this.Controls.Add(this.trackBarFrom);
            this.Controls.Add(this.labelCutTo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBarTo);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.labelVolumeOriginal);
            this.Controls.Add(this.trackBarVolumeOriginal);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonOpen);
            this.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMerge";
            this.Text = "FormMerge";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMerge_FormClosing);
            this.Load += new System.EventHandler(this.FormMerge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeMerge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelOriginal;
        private Label labelVolumeOriginal;
        private TrackBar trackBarVolumeOriginal;
        private TrackBar trackBar1;
        private Button buttonOpen;
        private TrackBar trackBarTo;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label labelCutTo1;
        private TrackBar trackBarFrom;
        private Label label1;
        private Label labelVoluleMerge;
        private TrackBar trackBarVolumeMerge;
        private Button buttonCancel;
        private Button buttonAccept;
        private Button buttonPauseOriginal;
        private Button buttonPlayOriginal;
        private Button buttonPauseMerge;
        private Button buttonPlayMerge;
        private System.Windows.Forms.Timer timer2;
        private Label labelCutFrom;
        private NAudio.Gui.WaveformPainter waveformPainter1;
        private System.Windows.Forms.Timer timer3;
        private PictureBox pictureBox2;
        private Label songLabel2;
    }
}