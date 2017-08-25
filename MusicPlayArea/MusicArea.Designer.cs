namespace MusicPlayArea
{
    partial class MusicArea
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarCustom1 = new CustomBar.ProgressBarCustom();
            this.replayButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.ShuffleButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.rewindButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.stopButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.pauseButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.playButton = new ButtonforMusicPlayerBar.ButtonForPlayer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(229, 25);
            this.label1.MaximumSize = new System.Drawing.Size(50, 50);
            this.label1.MinimumSize = new System.Drawing.Size(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "0.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(414, 25);
            this.label2.MaximumSize = new System.Drawing.Size(50, 50);
            this.label2.MinimumSize = new System.Drawing.Size(40, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "0.00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(44, 25);
            this.label3.MaximumSize = new System.Drawing.Size(50, 50);
            this.label3.MinimumSize = new System.Drawing.Size(40, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "0.00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarCustom1
            // 
            this.progressBarCustom1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBarCustom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBarCustom1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.progressBarCustom1.Location = new System.Drawing.Point(44, 45);
            this.progressBarCustom1.maxTime = 150;
            this.progressBarCustom1.Name = "progressBarCustom1";
            this.progressBarCustom1.Size = new System.Drawing.Size(410, 13);
            this.progressBarCustom1.TabIndex = 0;
            this.progressBarCustom1.value = 150;
            // 
            // replayButton
            // 
            this.replayButton.BackColor = System.Drawing.Color.Transparent;
            this.replayButton.BackgroundImageNew = null;
            this.replayButton.Location = new System.Drawing.Point(366, 25);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(50, 20);
            this.replayButton.TabIndex = 9;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.BackgroundImageNew = null;
            this.ShuffleButton.Location = new System.Drawing.Point(317, 25);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(50, 20);
            this.ShuffleButton.TabIndex = 8;
            // 
            // rewindButton
            // 
            this.rewindButton.BackColor = System.Drawing.Color.Transparent;
            this.rewindButton.BackgroundImageNew = null;
            this.rewindButton.Location = new System.Drawing.Point(269, 25);
            this.rewindButton.Name = "rewindButton";
            this.rewindButton.Size = new System.Drawing.Size(50, 20);
            this.rewindButton.TabIndex = 7;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.BackgroundImageNew = null;
            this.stopButton.Location = new System.Drawing.Point(181, 25);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(50, 20);
            this.stopButton.TabIndex = 6;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.BackgroundImageNew = global::MusicPlayArea.Properties.Resources.Pause_Grey;
            this.pauseButton.Location = new System.Drawing.Point(132, 25);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 20);
            this.pauseButton.TabIndex = 5;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Black;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playButton.BackgroundImageNew = global::MusicPlayArea.Properties.Resources.Play_Grey;
            this.playButton.Location = new System.Drawing.Point(83, 25);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(50, 20);
            this.playButton.TabIndex = 4;
            // 
            // MusicArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.ShuffleButton);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarCustom1);
            this.DoubleBuffered = true;
            this.Name = "MusicArea";
            this.Size = new System.Drawing.Size(495, 84);
            this.SizeChanged += new System.EventHandler(this.MusicArea_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomBar.ProgressBarCustom progressBarCustom1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ButtonforMusicPlayerBar.ButtonForPlayer playButton;
        private ButtonforMusicPlayerBar.ButtonForPlayer pauseButton;
        private ButtonforMusicPlayerBar.ButtonForPlayer stopButton;
        private ButtonforMusicPlayerBar.ButtonForPlayer rewindButton;
        private ButtonforMusicPlayerBar.ButtonForPlayer ShuffleButton;
        private ButtonforMusicPlayerBar.ButtonForPlayer replayButton;
    }
}
