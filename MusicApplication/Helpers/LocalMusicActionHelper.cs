// <copyright file="LocalMusicActionHelper.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicApplication.Helpers
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using WMPLib;

    /// <summary>
    /// Class for executing actions on local music items
    /// </summary>
    public class LocalMusicActionHelper
    {
        private DatabaseConnHelper databaseConnHelper;

        public LocalMusicActionHelper()
        {
            databaseConnHelper = new DatabaseConnHelper();
        }

        /// <summary>
        /// Goes to a random next song when one finishes
        /// </summary>
        /// <param name="result">The index of the next song to play</param>
        /// <param name="isShuffle">Whether shuffle is toggled on or not</param>
        /// <param name="winmp">The windows media player</param>
        /// <param name="listCount">The amount of items in the object list view</param>
        /// <returns>An integer indicating the index of the next song to play</returns>
        public int Winmp_PlayStateChange(int result, bool isShuffle, WindowsMediaPlayer winmp, int listCount)
        {
            if (isShuffle && winmp.playlistCollection == null)
            {
                if (winmp.playState == WMPPlayState.wmppsMediaEnded)
                {
                    return new Random().Next(0, listCount);
                }
            }

            return -1;
        }

        public void AddSongToLocal(WindowsMediaPlayer winmp)
        {
            OpenFileDialog openFileDialogLocal = new OpenFileDialog();
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
                    IWMPMedia mediainfo = winmp.newMedia(filePath);
                    length = (int)Math.Ceiling(mediainfo.duration);
                    string addResult = this.databaseConnHelper.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
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
    }
}
