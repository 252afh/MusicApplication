// <copyright file="MusicButton.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicPlayerButton
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// The buttons to be used on the music player panel
    /// </summary>
    public partial class MusicButton : UserControl
    {
        /// <summary>
        /// The main image to be displayed on the button when not hovered
        /// </summary>
        private Image image;

        /// <summary>
        /// The image to be displayed on the button when hovered over
        /// </summary>
        private Image hoverImage;

        /// <summary>
        /// Initialises a new instance of the <see cref="MusicButton"/> class
        /// </summary>
        public MusicButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the normal image for the button
        /// </summary>
        public Image NotHoverImage
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }

        /// <summary>
        /// Gets or sets the hovered image for the button
        /// </summary>
        public Image OnHoverImage
        {
            get
            {
                return this.hoverImage;
            }

            set
            {
                this.hoverImage = value;
            }
        }

        /// <summary>
        /// Sets the image of the button to the hover image
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event context</param>
        private void MusicButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = this.hoverImage;
        }

        /// <summary>
        /// Sets the image of the button to the not hovered image
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event context</param>
        private void MusicButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = this.NotHoverImage;
        }

        /// <summary>
        /// Sets the image of the button to the not hovered hover image
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event context</param>
        private void MusicButton_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = this.NotHoverImage;
        }
    }
}
