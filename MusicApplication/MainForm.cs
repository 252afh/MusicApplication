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
    using WMPLib;

    /// <summary>
    /// The main class for the music player UI
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The database connection
        /// </summary>
        private DatabaseConn databaseConnection;

        /// <summary>
        /// An instance of the <see cref="WindowsMediaPlayer"/> class
        /// </summary>
        private WindowsMediaPlayer winmp;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainForm"/> class
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.winmp = new WindowsMediaPlayer();
            this.databaseConnection = new DatabaseConn();
            this.UpdateTable();
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
            openFileDialogLocal.InitialDirectory = "c://";
            openFileDialogLocal.Filter = "Allowed types (.wmv,.mp3)|*.wmv;*.mp3|Video (.wmv)|*.wmv|Music(.mp3)|*.mp3|ALL Files(*.*)|*.*";
            openFileDialogLocal.FilterIndex = 1;
            DialogResult result = openFileDialogLocal.ShowDialog();
            string filePath = openFileDialogLocal.FileName;
            string title = Path.GetFileNameWithoutExtension(filePath);
            string artist = null;
            string album = null;
            string playlist = null;
            int length = 0;
            string genre = null;
            int plays = 0;
            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".wmv":
                    IWMPMedia mediainfo = this.winmp.newMedia(filePath);
                    length = (int)Math.Ceiling(mediainfo.duration);
                    string addResult = this.databaseConnection.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
                    if (!string.IsNullOrEmpty(addResult))
                    {
                        MessageBox.Show(addResult);
                    }
                    else
                    {
                        UpdateTable();
                    }

                    break;
                default:
                    break;
            }

            openFileDialogLocal.Dispose();
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
            WMPPlayState playst = this.winmp.playState;

            if (!(this.winmp.playState == WMPPlayState.wmppsStopped || this.winmp.playState == WMPPlayState.wmppsUndefined))
            {
                songTimer.Stop();
                this.winmp.controls.stop();
            }

            ListView.SelectedListViewItemCollection selectedRow = objectListView.SelectedItems;

            foreach (OLVListItem rowObject in selectedRow)
            {
                this.songTimer = new Timer();
                LocalAudioItem rowItem = (LocalAudioItem)rowObject.RowObject;

                switch (rowItem.ReaderFileExtension)
                {
                    case ".wmv":
                        this.winmp.URL = rowItem.ReaderFilePath;
                        this.musicArea1.Value = 0;
                        this.musicArea1.MaxTime = (int)rowItem.ReaderLength;
                        this.songTimer.Start();
                        this.winmp.controls.play();
                        break;
                }
            }
        }

        /// <summary>
        /// The tick of the songs timer
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context the timer ticks</param>
        private void SongTimer_Tick(object sender, EventArgs e)
        {
           this.musicArea1.Value = this.musicArea1.Value + 1;
        }
    }
}
