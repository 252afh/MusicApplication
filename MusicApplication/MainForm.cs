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
        private DatabaseConn databaseConnection;
        private WindowsMediaPlayer winmp;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainForm"/> class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
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
            CursorActions(sender, e, (int)CursorEnums.hovered);
        }

        /// <summary>
        /// Executes when the mouse leaves a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MouseExit(object sender, EventArgs e)
        {
            CursorActions(sender, e, (int)CursorEnums.unhovered);
        }

        /// <summary>
        /// Executes when the mouse button is lifted up on a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MouseUnClicked(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)ButtonsEnums.unclicked);
        }

        /// <summary>
        /// Executes when the mouse button is pressed down on a menu button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The context</param>
        private void MousePressed(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)ButtonsEnums.clicked);
        }

        private void MouseActions(object sender, MouseEventArgs e, int num)
        {
            Button[] ButtonList = new Button[]
            {
                HomePageButton,
                LocalButton,
                APIButton,
                OptionButton
            };
            foreach (Button selectedButton in ButtonList)
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

        private void CursorActions(object sender, EventArgs e, int num)
        {
            Button[] ButtonList = new Button[]
            {
                HomePageButton,
                LocalButton,
                APIButton,
                OptionButton
            };
            foreach (Button selectedButton in ButtonList)
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

        private void AddToLocalLibBtn_Click(object sender, EventArgs e)
        {
            openFileDialogLocal.InitialDirectory = "c://"; //sets initial directory
            openFileDialogLocal.Filter = "Allowed types (.wmv,.mp3)|*.wmv;*.mp3|Video (.wmv)|*.wmv|Music(.mp3)|*.mp3|ALL Files(*.*)|*.*"; // allowed file types
            openFileDialogLocal.FilterIndex = 1;
            DialogResult result = openFileDialogLocal.ShowDialog();
            string filePath = openFileDialogLocal.FileName;
            string title = Path.GetFileNameWithoutExtension(filePath);  //configure file dialog
            string artist = null;
            string album = null;
            string playlist = null;
            int length = 0;
            string genre = null;
            int plays = 0;
            string extension = Path.GetExtension(filePath); //gets file extension
            switch (extension)
            {
                case ".wmv":
                    IWMPMedia mediainfo = winmp.newMedia(filePath); //gets file length for wmp
                    length = (int)Math.Ceiling(mediainfo.duration);
                    string addResult = databaseConnection.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
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

        private void UpdateTable()
        {
            objectListView.ClearObjects();
            ArrayList itemList = databaseConnection.GetSongsFromTable();
            foreach (LocalAudioItem audioItem in itemList)
            {
                objectListView.AddObject(audioItem);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            databaseConnection.DropTable();
        }

        private void ObjectListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WMPPlayState playst = winmp.playState;

            if (!(winmp.playState == WMPPlayState.wmppsStopped || winmp.playState == WMPPlayState.wmppsUndefined))
            {
                songTimer.Stop();
                winmp.controls.stop();
            }

            ListView.SelectedListViewItemCollection selectedRow = objectListView.SelectedItems;

            foreach (OLVListItem rowObject in selectedRow) //will be able to play multiple now
            {
                songTimer = new Timer();
                LocalAudioItem rowItem = (LocalAudioItem)rowObject.RowObject;

                switch (rowItem.ReaderFileExtension)
                {
                    case ".wmv":
                        winmp.URL = rowItem.ReaderFilePath;
                        musicArea1.Value = 0;
                        musicArea1.MaxTime = (int)rowItem.ReaderLength;
                        songTimer.Start();
                        winmp.controls.play();
                        break;
                }
            }
            
        }

        private void SongTimer_Tick(object sender, EventArgs e)
        {
           musicArea1.Value = musicArea1.Value + 1;
        }
    }
}
