using System;
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
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush b = new SolidBrush(this.ForeColor); //new brush for the background
            LinearGradientBrush linearBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.Red), Color.FromArgb(200, Color.Black), LinearGradientMode.ForwardDiagonal);
            decimal result = ((decimal)currentTime / (decimal)songLength); //gets the percentage value
            int width = (int)(this.Width * result); //paints the bar to the percentage value

            e.Graphics.FillRectangle(b, 0, 0, width, this.Height); //paints background bar
            e.Graphics.FillRectangle(linearBrush, 0, 0, width, this.Height); //paints current time bar
            b.Dispose();
            linearBrush.Dispose();
        }

        private void ProgressBarCustom_SizeChanged(object sender, EventArgs e)
        {
            //label1.Location = new Point(this.Width / 2 - 21 / 2 - 4, this.Height / 2 - 15 / 2);
            //label2.Location = new Point(this.Width - label2.Width - 10, this.Height / 2 - label2.Height);
            this.Invalidate();
        }
    }
}
