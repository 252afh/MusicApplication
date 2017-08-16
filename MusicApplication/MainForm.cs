using BrightIdeasSoftware;
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
            double length = 0;
            string genre = null;
            int plays = 0;
            string extension = Path.GetExtension(filePath); //gets file extension
            switch (extension)
            {
                case ".wmv":
                    IWMPMedia mediainfo = winmp.newMedia(filePath); //gets file length for wmp
                    length = Math.Round(mediainfo.duration, 2);
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
            var playst = winmp.playState;
            if (!(winmp.playState == WMPPlayState.wmppsStopped || winmp.playState == WMPPlayState.wmppsUndefined))
            {
                winmp.controls.stop();
            }
            if (objectListView.SelectedItems.Count > 1)
            {

            }
            LocalAudioItem selectedRow = (LocalAudioItem)objectListView.SelectedItem.RowObject;
            int lengthInt = (int.Parse(selectedRow.readerLength.ToString().Split('.')[0]) * 60) + int.Parse(selectedRow.readerLength.ToString().Split('.')[1]);

            switch (selectedRow.readerFileExtension)
            {
                case ".wmv":
                    
                    winmp.URL = selectedRow.readerFilePath;
                    winmp.controls.play();
                    break;
            }
        }
    }
}
