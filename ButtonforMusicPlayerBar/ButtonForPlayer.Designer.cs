using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ButtonforMusicPlayerBar
{
    partial class ButtonForPlayer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        Image image;
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

        public Image BackgroundImageNew
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                Button.BackgroundImage = image;
                this.Button.Image = image;
                Button.Image = image;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush b = new SolidBrush(this.ForeColor); //new brush for the background
            LinearGradientBrush linearBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.Silver), Color.FromArgb(200, Color.Black), LinearGradientMode.ForwardDiagonal);

            e.Graphics.FillRectangle(b, 0, 0, this.Width, this.Height);
            e.Graphics.FillRectangle(linearBrush, 0, 0, this.Width, this.Height);
            b.Dispose();
            linearBrush.Dispose();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.Color.Transparent;
            this.Button.Location = new System.Drawing.Point(0, 0);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(50, 20);
            this.Button.TabIndex = 0;
            this.Button.UseVisualStyleBackColor = false;
            // 
            // ButtonForPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Button);
            this.Name = "ButtonForPlayer";
            this.Size = new System.Drawing.Size(50, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button;
    }
}
