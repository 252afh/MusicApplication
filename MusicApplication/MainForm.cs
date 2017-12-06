// <copyright file="MainForm.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicApplication
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Windows.Forms;
    using BrightIdeasSoftware;
    using MusicApplication.Enums;
    using MusicApplication.Helpers;
    using WMPLib;

    /// <summary>
    /// The main class for the music player UI
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The database connection
        /// </summary>
        private DatabaseConnHelper databaseConnection;

        /// <summary>
        /// An instance of the <see cref="WindowsMediaPlayer"/> class
        /// </summary>
        private WindowsMediaPlayer winmp;

        /// <summary>
        /// An instance of the <see cref="localMusicActionHelper"/> class
        /// </summary>
        private LocalMusicActionHelper localMusicActionHelper;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainForm"/> class
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.winmp = new WindowsMediaPlayer();
            this.databaseConnection = new DatabaseConnHelper();
            this.localMusicActionHelper = new LocalMusicActionHelper();
            this.Timer = new Timer();
            this.Timer.Tick += this.Timer_Tick;
            this.UpdateTable();
            this.AssignClickMethods();
            this.winmp.PlayStateChange += this.Winmp_PlayStateChange;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the music is paused or not
        /// </summary>
        private bool IsPaused { get; set; }

        /// <summary>
        /// Gets or sets the timer to keep track of the music play time
        /// </summary>
        private Timer Timer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the status of the shuffle button
        /// </summary>
        private bool IsShuffle { get; set; }

        /// <summary>
        /// Gets or sets the index of the next song to play
        /// </summary>
        private int NextSongIndex { get; set; }

        /// <summary>
        /// Gets or sets the count of the object list view
        /// </summary>
        private int ListCount
        {
            get
            {
                return this.ListCount;
            }

            set
            {
                this.ListCount = objectListView.GetItemCount();
            }
        }

        /// <summary>
        /// Gets a new <see cref="LocalAudioItem"/> to play based on a random integer index
        /// </summary>
        /// <param name="newState">An integer representing the enum of the play state</param>
        private void Winmp_PlayStateChange(int newState)
        {
            if (this.IsShuffle)
            {
                int toPlay = this.localMusicActionHelper.Winmp_PlayStateChange(newState, this.IsShuffle, this.winmp, this.ListCount);
                LocalAudioItem rowItem = (LocalAudioItem)objectListView.GetItem(toPlay).RowObject;
            }
        }

        /// <summary>
        /// Assigns the correct action methods to button clicks
        /// </summary>
        private void AssignClickMethods()
        {
            Control[] areaButtons = new Control[6];

            areaButtons[0] = this.musicArea2.Controls.Find("PauseButton", false)[0];
            areaButtons[1] = this.musicArea2.Controls.Find("PlayButton", false)[0];
            areaButtons[2] = this.musicArea2.Controls.Find("StopButton", false)[0];
            areaButtons[3] = this.musicArea2.Controls.Find("PlayAllButton", false)[0];
            areaButtons[4] = this.musicArea2.Controls.Find("ShuffleButton", false)[0];
            areaButtons[5] = this.musicArea2.Controls.Find("ReplayButton", false)[0];

            foreach (Control btn in areaButtons)
            {
                if (btn == null)
                {
                    throw new ArgumentNullException("Button " + btn + " does not exist to assign the click action to.");
                }
            }

            areaButtons[0].Click += this.PauseButton_Click;
            areaButtons[1].Click += this.PlayButton_Click;
            areaButtons[2].Click += this.StopButton_Click;
            areaButtons[3].Click += this.ReplayButton_Click;
            areaButtons[4].Click += this.ShuffleButton_Click;
            areaButtons[5].Click += this.RewindButton_Click;
        }

        /// <summary>
        /// Tick of the timer to set the current time the song is at
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.musicArea2.Value = (int)this.winmp.controls.currentPosition;
        }

        /// <summary>
        /// Executes when the mouse enters a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private new void MouseEnter(object sender, EventArgs e)
        {
            this.CursorActions(sender, e, (int)CursorEnums.hovered);
        }

        /// <summary>
        /// Executes when the mouse leaves a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MouseExit(object sender, EventArgs e)
        {
            this.CursorActions(sender, e, (int)CursorEnums.unhovered);
        }

        /// <summary>
        /// Executes when the mouse button is lifted up on a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MouseUnClicked(object sender, MouseEventArgs e)
        {
            this.MouseActions(sender, e, (int)ButtonsEnums.unclicked);
        }

        /// <summary>
        /// Executes when the mouse button is pressed down on a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MousePressed(object sender, MouseEventArgs e)
        {
            this.MouseActions(sender, e, (int)ButtonsEnums.clicked);
        }

        /// <summary>
        /// Handles the actions of the mouse
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The context of the action</param>
        /// <param name="num">Enum representing which action has been triggered</param>
        private void MouseActions(object sender, MouseEventArgs e, int num)
        {
            Button[] buttonList = new Button[]
            {
                this.HomePageButton,
                this.LocalButton,
                this.APIButton,
                this.OptionButton
            };
            foreach (Button selectedButton in buttonList)
            {
                if (sender.Equals(selectedButton))
                {
                    switch (num)
                    {
                        case 0: // Clicked
                            selectedButton.Image = Properties.Resources.homepage_green;
                            break;
                        case 1: // Unclicked
                            selectedButton.Image = Properties.Resources.homepage_yellow;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// The actions taken by the cursor
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The context of the cursor movement</param>
        /// <param name="num">Enum representing the action the cursor has performed</param>
        private void CursorActions(object sender, EventArgs e, int num)
        {
            Button[] buttonList = new Button[]
            {
                this.HomePageButton,
                this.LocalButton,
                this.APIButton,
                this.OptionButton
            };
            foreach (Button selectedButton in buttonList)
            {
                if (sender.Equals(selectedButton))
                {
                    switch (num)
                    {
                        case 0: // Entered
                            selectedButton.Image = Properties.Resources.homepage_yellow;
                            break;
                        case 1: // Left
                            selectedButton.Image = Properties.Resources.homepage_red;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new song file to the local song library
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context of the button being pressed</param>
        private void AddToLocalLibBtn_Click(object sender, EventArgs e)
        {
            localMusicActionHelper.AddSongToLocal();
        }

        /// <summary>
        /// Updates the view table on the form with the songs from the database table
        /// </summary>
        private void UpdateTable()
        {
            this.objectListView.ClearObjects();
            ArrayList itemList = this.databaseConnection.GetSongsFromTable();
            foreach (LocalAudioItem audioItem in itemList)
            {
                this.objectListView.AddObject(audioItem);
            }
        }

        /// <summary>
        /// Deletes the song table
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context of the button being pressed</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.databaseConnection.DropTable();
        }

        /// <summary>
        /// Executes when a row in the table is double clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context of the button being pressed</param>
        private void ObjectListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.PlaySong();
        }

        /// <summary>
        /// Override to assign a time to PlaySong as default 0
        /// </summary>
        private void PlaySong()
        {
            this.PlaySongDoubleClick(0.0);
        }

        /// <summary>
        /// Plays a song
        /// </summary>
        /// <param name="startTime">The time to start the song at</param>
        private void PlaySongDoubleClick(double startTime)
        {
            WMPPlayState playst = this.winmp.playState;

            if (!(playst == WMPPlayState.wmppsStopped || playst == WMPPlayState.wmppsUndefined))
            {
                this.StopMusic();
            }

            ListView.SelectedListViewItemCollection selectedRow = objectListView.SelectedItems;
            
            foreach (OLVListItem rowObject in selectedRow)
            {
                LocalAudioItem rowItem = (LocalAudioItem)rowObject.RowObject;

                switch (rowItem.ReaderFileExtension)
                {
                    case ".wmv":
                        this.PlaySong(startTime, rowItem);
                        break;
                }
            }
        }

        /// <summary>
        /// Plays the selected song at the designated time
        /// </summary>
        /// <param name="startTime">The time to start playing the song at</param>
        /// <param name="rowItem">The row item to be played</param>
        private void PlaySong(double startTime, LocalAudioItem rowItem)
        {
            this.winmp.URL = rowItem.ReaderFilePath;
            this.musicArea2.Value = 0;
            this.musicArea2.MaxTime = (int)rowItem.ReaderLength;
            this.winmp.controls.currentPosition = startTime;
            this.winmp.controls.play();
            this.Timer.Start();
        }
        
        /// <summary>
        /// Stops the current song from playing
        /// </summary>
        private void StopMusic()
        {
            WMPPlayState playst = this.winmp.playState;

            if (!(playst == WMPPlayState.wmppsStopped || playst == WMPPlayState.wmppsUndefined))
            {
                this.winmp.controls.stop();
                this.Timer.Stop();
                this.musicArea2.MaxTime = 0;
                this.musicArea2.Value = 0;
            }
        }
        
        /// <summary>
        /// Pauses the current song
        /// </summary>
        private void PauseMusic()
        {
            this.winmp.controls.pause();
        }

        /// <summary>
        /// Resets the playtime to 0
        /// </summary>
        private void ReplayMusic()
        {
            this.winmp.controls.currentPosition = 0;
        }

        /// <summary>
        /// Executes when the play button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.PlaySong();
        }

        /// <summary>
        /// Executes when the pause button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            this.PauseMusic();
        }

        /// <summary>
        /// Executes when the stop button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            this.StopMusic();
        }

        /// <summary>
        /// Executes when the replay button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void ReplayButton_Click(object sender, EventArgs e)
        {
            this.ReplayMusic();
        }

        /// <summary>
        /// Executes when the shuffle button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void ShuffleButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Executes when the rewind button is pressed in the <see cref="musicArea2"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The sender context</param>
        private void RewindButton_Click(object sender, EventArgs e)
        {
        }
    }
}
