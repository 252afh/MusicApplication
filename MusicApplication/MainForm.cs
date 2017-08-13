using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.MediaPlayer.Interop;
using MusicApplication.Enums;

namespace MusicApplication
{ 
    public partial class MainForm : Form
    {
        DatabaseConn dbConn;
        public MainForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConn();
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
            string title = openFileDialogLocal.SafeFileName;  //configure file dialog
            string artist = null;
            string album = null;
            string playlist = null;
            double length = 0;
            string genre = null;
            int plays = 0;
            bool isAdded = false;
            string extension = Path.GetExtension(filePath); //gets file extension
            switch (extension)
            {
                case ".wmv":
                    WindowsMediaPlayer winmp = new WindowsMediaPlayer(); // creates a WindowsMediaPlayer instance
                    IWMPMedia mediainfo = winmp.newMedia(filePath); //gets file length for wmp
                    length = mediainfo.duration;
                    dbConn.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
                    isAdded = true;
                    break;
                default:
                    //MessageBox.Show("Error accepting that file type, please try again", "Error importing file to local music");
                    //openFileDialogLocal.Dispose();
                    break;
            }

            dbConn.GetSongsFromTable("boop");

            if (isAdded)
            {
                ListViewItem itemToAdd = new ListViewItem();
                ListViewItem.ListViewSubItem toAddTitle, toAddArtist = null, toAddAlbum = null, toAddPlaylist = null, toAddLength = null, toAddGenre = null, toAddPlays = null, toAddExtension = null, toAddPath = null;

                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[9]
                {
                    toAddTitle = new ListViewItem.ListViewSubItem(),
                    toAddArtist = new ListViewItem.ListViewSubItem(),
                    toAddAlbum = new ListViewItem.ListViewSubItem(),
                    toAddPlaylist = new ListViewItem.ListViewSubItem(),
                    toAddLength = new ListViewItem.ListViewSubItem(),
                    toAddGenre = new ListViewItem.ListViewSubItem(),
                    toAddPlays = new ListViewItem.ListViewSubItem(),
                    toAddExtension = new ListViewItem.ListViewSubItem(),
                    toAddPath = new ListViewItem.ListViewSubItem()
                };

                toAddTitle.Text = title;
                toAddArtist.Text = artist;
                toAddAlbum.Text = album;
                toAddPlaylist.Text = playlist;
                toAddLength.Text = Math.Round(length,2).ToString();
                toAddGenre.Text = genre;
                toAddPlays.Text = plays.ToString();
                toAddExtension.Text = extension;
                toAddPath.Text = filePath;
                itemToAdd.Text = (localMusicListView.Items.Count+1).ToString();

                itemToAdd.SubItems.AddRange(subItems);
                localMusicListView.Items.Add(itemToAdd);
                
                //updateTable();
            }

            openFileDialogLocal.Dispose();
        }

        private void updateTable()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.dropTable();
        }
    }
}
