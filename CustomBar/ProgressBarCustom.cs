﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomBar
{
    public partial class ProgressBarCustom : UserControl
    {
        public ProgressBarCustom()
        {
            InitializeComponent();
            label1.ForeColor = Color.Black;
            this.ForeColor = SystemColors.Highlight; //default bar colour
        }
        protected int currentTime = 0; //current song time
        protected int songLength = 1; //total song time

        public int value
        {
            get
            {
                return currentTime;
            }
            set
            {
                if (value < 0) value = 0; //if less than 0 then 0
                else if (value > songLength) value = songLength; //if longer than song then songlength
                currentTime = value;
                int currentMinutes = (int)(Math.Floor(currentTime / 60.0)); //gets the minutes of the current place
                int currentSeconds = (int)(currentTime % 60); //gets the seconds of the current place
                string labelText = currentMinutes.ToString() + "." + currentSeconds.ToString(); //interpolate the string
                label1.Text = labelText; //assigns the text
                this.Invalidate(); //causes the onPaint event to trigger.
            }
        }

        public int maxTime
        {
            get
            {
                return songLength;
            }
            set
            {
                songLength = value;
                int songMinutes;
                if (songLength >= 60) {
                    songMinutes = (int)(Math.Floor(songLength / 60.0));
                }
                else
                {
                    songMinutes = 0;
                }
                int songSeconds = (int)(songLength % 60);
                string maximumText = songMinutes.ToString() + "." + songSeconds.ToString();
                label2.Text = maximumText;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush b = new SolidBrush(this.ForeColor); //new brush for the background
            LinearGradientBrush linearBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.ForwardDiagonal);
            //int width = (int)((currentTime / 100) * this.Width);
            int oneSecond = this.Width / songLength;
            int width = oneSecond * currentTime;

            e.Graphics.FillRectangle(b, 0, 0, width, this.Height);
            e.Graphics.FillRectangle(linearBrush, 0, 0, width, this.Height);
            b.Dispose();
            linearBrush.Dispose();
        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void ProgressBarCustom_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 2 - 21 / 2 - 4, this.Height / 2 - 15 / 2);
            label2.Location = new Point(this.Width - label2.Width - 10, this.Height / 2 - label2.Height);
            this.Invalidate();
        }
    }
}
