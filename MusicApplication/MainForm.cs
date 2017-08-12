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
            //dbConn.AddSongToTable("titleofsong", "artistofsong", "albumofsong", "playlistofsong", 4.45, "rock", 3);

            //string printed = dbConn.GetSongsFromTable();

            //testBox.Text = printed;

            openFileDialogLocal.InitialDirectory = "c://"; //sets initial directory
            openFileDialogLocal.Filter = "Allowed types (.wmv,.mp3)|*.wmv;*.mp3|Video (.wmv)|*.wmv|Music(.mp3)|*.mp3|ALL Files(*.*)|*.*"; // allowed file types
            openFileDialogLocal.FilterIndex = 1;
            DialogResult result = openFileDialogLocal.ShowDialog();
            string filePath = openFileDialogLocal.FileName;
            string artist = openFileDialogLocal.SafeFileName; //configure file dialog
            string extension = Path.GetExtension(filePath); //gets file extension

            WindowsMediaPlayer winmp = new WindowsMediaPlayer(); //plays the wmp
            winmp.URL = filePath;
            winmp.controls.play();

            double duration;
            IWMPMedia mediainfo = winmp.newMedia(filePath); //gets file length for wmp
            duration = mediainfo.duration;



        }

        private void playMedia(string filePath)
        {
            
        }

        private void openFileDialogLocal_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
