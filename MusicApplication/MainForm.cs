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
            string extension = Path.GetExtension(filePath); //gets file extension
            switch (extension)
            {
                case ".wmv":
                    WindowsMediaPlayer winmp = new WindowsMediaPlayer(); // creates a WindowsMediaPlayer instance
                    IWMPMedia mediainfo = winmp.newMedia(filePath); //gets file length for wmp
                    length = mediainfo.duration;
                    string addResult = dbConn.AddSongToTable(title, artist = null, album = null, playlist = null, length, genre = null, plays, extension, filePath);
                    if (!string.IsNullOrEmpty(addResult))
                    {
                        MessageBox.Show(addResult);
                    }
                    updateTable();
                    break;
                default:
                    //MessageBox.Show("Error accepting that file type, please try again", "Error importing file to local music");
                    //openFileDialogLocal.Dispose();
                    break;
            }
            openFileDialogLocal.Dispose();
        }

        private void updateTable()
        {
            ArrayList itemList = dbConn.GetSongsFromTable();
            ListViewItem listViewItem;
            ListViewItem.ListViewSubItem toAddTitle, toAddArtist = null, toAddAlbum = null, toAddPlaylist = null, toAddLength = null, toAddGenre = null, toAddPlays = null, toAddExtension = null, toAddPath = null;
            foreach (LocalAudioItem item in itemList)
            {
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[7]
                {
                    toAddTitle = new ListViewItem.ListViewSubItem(),
                    toAddArtist = new ListViewItem.ListViewSubItem(),
                    toAddAlbum = new ListViewItem.ListViewSubItem(),
                    toAddPlaylist = new ListViewItem.ListViewSubItem(),
                    toAddLength = new ListViewItem.ListViewSubItem(),
                    toAddGenre = new ListViewItem.ListViewSubItem(),
                    toAddPlays = new ListViewItem.ListViewSubItem(),
                };
                toAddTitle.Text = item.readerTitle?? null;
                toAddArtist.Text = item.readerArtist ?? null;
                toAddAlbum.Text = item.readerAlbum ?? null;
                toAddPlaylist.Text = item.readerPlaylist ?? null;
                toAddLength.Text = item.readerLength.ToString() ?? "0";
                toAddGenre.Text = item.readerGenre ?? null;
                toAddPlays.Text = item.readerPlays.ToString() ?? "0";
                listViewItem = new ListViewItem() ?? null;
                listViewItem.SubItems.AddRange(subItems);
                localMusicListView.Items.Add(listViewItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.dropTable();
        }

        private void localMusicListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.localMusicListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
    }
}
