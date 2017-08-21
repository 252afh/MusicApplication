using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayArea
{
    public partial class MusicArea : UserControl
    {

        protected int currentTime = 0; //current song time
        protected int songLength = 1; //total song time

        public MusicArea()
        {
            InitializeComponent();
        }

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
                progressBarCustom1.value = currentTime;

                int currentMinutes = (int)(Math.Floor(currentTime / 60.0)); //gets the minutes of the current place
                int currentSeconds = (int)(currentTime % 60); //gets the seconds of the current place
                string labelText = currentMinutes.ToString() + "." + currentSeconds.ToString(); //interpolate the string
                label1.Text = labelText; //assigns the text
                this.Invalidate();
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
                if (songLength >= 60)
                {
                    songMinutes = (int)(Math.Floor(songLength / 60.0));
                }
                else
                {
                    songMinutes = 0;
                }
                int songSeconds = (int)(songLength % 60);
                string maximumText = songMinutes.ToString() + "." + songSeconds.ToString();
                label2.Text = maximumText;
                progressBarCustom1.maxTime = songLength;
                this.Invalidate();
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //}

        private void MusicArea_SizeChanged(object sender, EventArgs e)
        {
            //label1.Location = new Point(this.Width / 2 - 21 / 2 - 4, this.Height / 2 - 15 / 2);
            //label2.Location = new Point(this.Width - label2.Width - 10, this.Height / 2 - label2.Height);
            this.Invalidate();
        }
    }
}
