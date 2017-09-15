// <copyright file="ProgressBarCustom.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace CustomBar
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    /// <summary>
    /// The progress bar user control to keep track of the time of the song
    /// </summary>
    public partial class ProgressBarCustom : UserControl
    {
        /// <summary>
        /// The current time in the song playing
        /// </summary>
        private int currentTime = 0;

        /// <summary>
        /// The maximum length of the song playing
        /// </summary>
        private int songLength = 1;

        /// <summary>
        /// Initialises a new instance of the <see cref="ProgressBarCustom"/> class
        /// </summary>
        public ProgressBarCustom()
        {
            this.InitializeComponent();
            this.ForeColor = SystemColors.Highlight;
        }
        
        /// <summary>
        /// Gets or sets the value that represents the current time the song is playing at
        /// </summary>
        public int Value
        {
            get
            {
                return this.currentTime;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > this.songLength)
                {
                    value = this.songLength;
                }

                this.currentTime = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the song length of the current song playing
        /// </summary>
        public int MaxTime
        {
            get
            {
                return this.songLength;
            }

            set
            {
                this.songLength = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Redraws the progress bar
        /// </summary>
        /// <param name="e">The context of the redrawing</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush b = new SolidBrush(this.ForeColor);
            LinearGradientBrush linearBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.Red), Color.FromArgb(200, Color.Black), LinearGradientMode.ForwardDiagonal);
            decimal result = (decimal)this.currentTime / (decimal)this.songLength;
            int width = (int)(this.Width * result);

            e.Graphics.FillRectangle(b, 0, 0, width, this.Height);
            e.Graphics.FillRectangle(linearBrush, 0, 0, width, this.Height);
            b.Dispose();
            linearBrush.Dispose();
        }

        /// <summary>
        /// When the progress bar size is changed, a redraw will be initiated
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context of the size being changed</param>
        private void ProgressBarCustom_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
