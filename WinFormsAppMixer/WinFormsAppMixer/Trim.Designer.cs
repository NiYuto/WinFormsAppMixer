namespace WinFormsAppMixer
{
    partial class Trim
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
            this.trackBarTo = new System.Windows.Forms.TrackBar();
            this.trackBarFrom = new System.Windows.Forms.TrackBar();
            this.labelCutFrom1 = new System.Windows.Forms.Label();
            this.labelСutTo = new System.Windows.Forms.Label();
            this.buttonPause2 = new System.Windows.Forms.Button();
            this.buttonPlay2 = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customWaveViewer1 = new WinFormsAppMixer.CustomWaveViewer();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarTo
            // 
            this.trackBarTo.AutoSize = false;
            this.trackBarTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.trackBarTo.Location = new System.Drawing.Point(12, 48);
            this.trackBarTo.Maximum = 100;
            this.trackBarTo.Name = "trackBarTo";
            this.trackBarTo.Size = new System.Drawing.Size(700, 27);
            this.trackBarTo.TabIndex = 5;
            this.trackBarTo.Scroll += new System.EventHandler(this.trackBarTo_Scroll);
            // 
            // trackBarFrom
            // 
            this.trackBarFrom.AutoSize = false;
            this.trackBarFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.trackBarFrom.Location = new System.Drawing.Point(12, 390);
            this.trackBarFrom.Maximum = 100;
            this.trackBarFrom.Name = "trackBarFrom";
            this.trackBarFrom.Size = new System.Drawing.Size(700, 33);
            this.trackBarFrom.TabIndex = 6;
            this.trackBarFrom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarFrom.Scroll += new System.EventHandler(this.trackBarFrom_Scroll);
            this.trackBarFrom.ValueChanged += new System.EventHandler(this.trackBarFrom_ValueChanged);
            // 
            // labelCutFrom1
            // 
            this.labelCutFrom1.AutoSize = true;
            this.labelCutFrom1.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCutFrom1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelCutFrom1.Location = new System.Drawing.Point(647, 424);
            this.labelCutFrom1.Name = "labelCutFrom1";
            this.labelCutFrom1.Size = new System.Drawing.Size(65, 18);
            this.labelCutFrom1.TabIndex = 10;
            this.labelCutFrom1.Text = "00:00/00:00";
            // 
            // labelСutTo
            // 
            this.labelСutTo.AutoSize = true;
            this.labelСutTo.Font = new System.Drawing.Font("Comfortaa", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelСutTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.labelСutTo.Location = new System.Drawing.Point(660, 27);
            this.labelСutTo.Name = "labelСutTo";
            this.labelСutTo.Size = new System.Drawing.Size(65, 18);
            this.labelСutTo.TabIndex = 11;
            this.labelСutTo.Text = "00:00/00:00";
            // 
            // buttonPause2
            // 
            this.buttonPause2.FlatAppearance.BorderSize = 0;
            this.buttonPause2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause2.Image = global::WinFormsAppMixer.Properties.Resources.icons8_pause_67;
            this.buttonPause2.Location = new System.Drawing.Point(741, 240);
            this.buttonPause2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPause2.Name = "buttonPause2";
            this.buttonPause2.Size = new System.Drawing.Size(49, 54);
            this.buttonPause2.TabIndex = 15;
            this.buttonPause2.UseVisualStyleBackColor = true;
            this.buttonPause2.Click += new System.EventHandler(this.buttonPause2_Click);
            // 
            // buttonPlay2
            // 
            this.buttonPlay2.FlatAppearance.BorderSize = 0;
            this.buttonPlay2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay2.Image = global::WinFormsAppMixer.Properties.Resources.icons8_play_64;
            this.buttonPlay2.Location = new System.Drawing.Point(741, 145);
            this.buttonPlay2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlay2.Name = "buttonPlay2";
            this.buttonPlay2.Size = new System.Drawing.Size(49, 54);
            this.buttonPlay2.TabIndex = 14;
            this.buttonPlay2.UseVisualStyleBackColor = true;
            this.buttonPlay2.Click += new System.EventHandler(this.buttonPlay2_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.FlatAppearance.BorderSize = 0;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Image = global::WinFormsAppMixer.Properties.Resources.icons8_accept_67;
            this.buttonAccept.Location = new System.Drawing.Point(869, 169);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(49, 54);
            this.buttonAccept.TabIndex = 16;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Image = global::WinFormsAppMixer.Properties.Resources.icons8_close_50;
            this.buttonCancel.Location = new System.Drawing.Point(869, 240);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(49, 54);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.label2.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.label2.Location = new System.Drawing.Point(802, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Volume";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(817, 169);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(45, 125);
            this.trackBarVolume.TabIndex = 18;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarVolume.Value = 20;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(25, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(674, 303);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // customWaveViewer1
            // 
            this.customWaveViewer1.BackColor = System.Drawing.Color.Transparent;
            this.customWaveViewer1.Location = new System.Drawing.Point(25, 81);
            this.customWaveViewer1.Name = "customWaveViewer1";
            this.customWaveViewer1.SamplesPerPixel = 128;
            this.customWaveViewer1.Size = new System.Drawing.Size(674, 303);
            this.customWaveViewer1.StartPosition = ((long)(0));
            this.customWaveViewer1.TabIndex = 22;
            this.customWaveViewer1.Visible = false;
            this.customWaveViewer1.WaveStream = null;
            // 
            // Trim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(944, 461);
            this.Controls.Add(this.customWaveViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonPause2);
            this.Controls.Add(this.buttonPlay2);
            this.Controls.Add(this.labelСutTo);
            this.Controls.Add(this.labelCutFrom1);
            this.Controls.Add(this.trackBarFrom);
            this.Controls.Add(this.trackBarTo);
            this.Name = "Trim";
            this.Text = "Trim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Trim_FormClosing);
            this.Load += new System.EventHandler(this.Trim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar trackBarTo;
        private TrackBar trackBarFrom;
        private Label labelCutFrom1;
        private Label labelСutTo;
        private Button buttonPause2;
        private Button buttonPlay2;
        private Button buttonAccept;
        private Button buttonCancel;
        private Label label2;
        private TrackBar trackBarVolume;
        private PictureBox pictureBox1;
        private CustomWaveViewer customWaveViewer1;
        public System.Windows.Forms.Timer timer1;
    }
}