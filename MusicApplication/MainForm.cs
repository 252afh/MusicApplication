﻿using BrightIdeasSoftware;
using System;
using System.IO;
using System.Windows.Forms;
using MusicApplication.Enums;
using WMPLib;
using System.Collections;

namespace MusicApplication
{ 
    public partial class MainForm : Form
    {
        DatabaseConn dbConn;
        WindowsMediaPlayer winmp;
        public MainForm()
        {
            InitializeComponent();
            winmp = new WindowsMediaPlayer();
            dbConn = new DatabaseConn();
            updateTable();
            
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            CursorActions(sender, e, (int)CursorEnums.hovered);
        }

        private void MouseExit(object sender, EventArgs e)
        {
            CursorActions(sender, e, (int)CursorEnums.unhovered);
        }

        private void MouseUnClicked(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)buttonEnums.unclicked);
        }

        private void MousePressed(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)buttonEnums.clicked);
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
                    string addResult = dbConn.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
                    if (!string.IsNullOrEmpty(addResult))
                    {
                        MessageBox.Show(addResult);
                    }
                    else
                    {
                        updateTable();
                    }
                    break;
                default:
                    break;
            }
            openFileDialogLocal.Dispose();
        }

        private void updateTable()
        {
            objectListView.ClearObjects();
            ArrayList itemList = dbConn.GetSongsFromTable();
            foreach (LocalAudioItem audioItem in itemList)
            {
                objectListView.AddObject(audioItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.dropTable();
        }

        private void objectListView_MouseDoubleClick(object sender, MouseEventArgs e)
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

                switch (rowItem.readerFileExtension)
                {
                    case ".wmv":
                        winmp.URL = rowItem.readerFilePath;
                        musicArea1.value = 0;
                        musicArea1.maxTime = (int)rowItem.readerLength;
                        songTimer.Start();
                        winmp.controls.play();
                        break;
                }
            }
            
        }

        private void songTimer_Tick(object sender, EventArgs e)
        {
           musicArea1.value = musicArea1.value + 1;
        }
    }
}
