// <copyright file="MusicArea.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicPlayArea
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// The music area to display information about the local music playing
    /// </summary>
    public partial class MusicArea : UserControl
    {
        /// <summary>
        /// current song time
        /// </summary>
        private int currentTime = 0;

        /// <summary>
        /// total song time
        /// </summary>
        private int songLength = 1;

        /// <summary>
        /// Play button not hovered image
        /// </summary>
        private Image playImageNotHovered;

        /// <summary>
        /// Play button hovered image
        /// </summary>
        private Image playImageHovered;

        /// <summary>
        /// Pause button not hovered image
        /// </summary>
        private Image pauseImageNotHovered;

        /// <summary>
        /// Pause button hovered image
        /// </summary>
        private Image pauseImageHovered;

        /// <summary>
        /// Stop button not hovered image
        /// </summary>
        private Image stopImageNotHovered;

        /// <summary>
        /// Stop button hovered image
        /// </summary>
        private Image stopImageHovered;

        /// <summary>
        /// Shuffle button not hovered image
        /// </summary>
        private Image shuffleImageNotHovered;

        /// <summary>
        /// Shuffle button hovered image
        /// </summary>
        private Image shuffleImageHovered;

        /// <summary>
        /// Replay button not hovered image
        /// </summary>
        private Image replayImageNotHovered;

        /// <summary>
        /// Replay button hovered image
        /// </summary>
        private Image replayImageHovered;

        /// <summary>
        /// Play all button not hovered image
        /// </summary>
        private Image playAllImageNotHovered;

        /// <summary>
        /// Play all button hovered image
        /// </summary>
        private Image playAllImageHovered;

        /// <summary>
        /// Initialises a new instance of the <see cref="MusicArea"/> class
        /// </summary>
        public MusicArea()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the play button not hovered image
        /// </summary>
        public Image PlayImageNotHovered
        {
            get
            {
                return this.playImageNotHovered;
            }

            set
            {
                this.PlayButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the play button hovered image
        /// </summary>
        public Image PlayImageHovered
        {
            get
            {
                return this.playImageHovered;
            }

            set
            {
                this.PlayButton.OnHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pause button not hovered image
        /// </summary>
        public Image PauseImageNotHovered
        {
            get
            {
                return this.pauseImageNotHovered;
            }

            set
            {
                this.PauseButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pause button hovered image
        /// </summary>
        public Image PauseImageHovered
        {
            get
            {
                return this.pauseImageNotHovered;
            }

            set
            {
                this.PauseButton.OnHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the stop button not hovered image
        /// </summary>
        public Image StopImageNotHovered
        {
            get
            {
                return this.stopImageNotHovered;
            }

            set
            {
                this.StopButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the stop button hovered image
        /// </summary>
        public Image StopImageHovered
        {
            get
            {
                return this.stopImageHovered;
            }

            set
            {
                this.StopButton.OnHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shuffle button not hovered image
        /// </summary>
        public Image ShuffleImageNotHovered
        {
            get
            {
                return this.shuffleImageNotHovered;
            }

            set
            {
                this.ShuffleButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shuffle button hovered image
        /// </summary>
        public Image ShuffleImageHovered
        {
            get
            {
                return this.shuffleImageHovered;
            }

            set
            {
                this.ShuffleButton.OnHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the replay button not hovered image
        /// </summary>
        public Image ReplayImageNotHovered
        {
            get
            {
                return this.replayImageNotHovered;
            }

            set
            {
                this.ReplayButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the replay button hovered image
        /// </summary>
        public Image ReplayImageHovered
        {
            get
            {
                return this.replayImageNotHovered;
            }

            set
            {
                this.ReplayButton.OnHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the play all button not hovered image
        /// </summary>
        public Image PlayAllImageNotHovered
        {
            get
            {
                return this.playAllImageNotHovered;
            }

            set
            {
                this.PlayAllButton.NotHoverImage = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the play all button hovered image
        /// </summary>
        public Image PlayAllImageHovered
        {
            get
            {
                return this.playAllImageHovered;
            }

            set
            {
                this.PlayAllButton.OnHoverImage = value;
                this.Invalidate();
            }
        }
        
        /// <summary>
        /// Gets or sets the current time the player is at
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
                this.progressBarCustom1.Value = this.currentTime;

                int currentMinutes = (int)Math.Floor(this.currentTime / 60.0);
                int currentSeconds = (int)(this.currentTime % 60);
                string labelText = currentMinutes.ToString() + "." + currentSeconds.ToString();
                this.label1.Text = labelText;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the total length of the song
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
                int songMinutes;
                if (this.songLength >= 60)
                {
                    songMinutes = (int)Math.Floor(this.songLength / 60.0);
                }
                else
                {
                    songMinutes = 0;
                }

                int songSeconds = (int)(this.songLength % 60);
                string maximumText = songMinutes.ToString() + "." + songSeconds.ToString();
                this.label2.Text = maximumText;
                this.progressBarCustom1.MaxTime = this.songLength;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Redraws the music area when the size is changed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context of the call</param>
        private void MusicArea_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
