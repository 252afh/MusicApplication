using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApplication
{
    public partial class MainForm : Form
    {
        enum buttons
        {
            clicked,
            unclicked
        };

        enum cursors
        {
            entered,
            left
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            CursorActions(sender, e, (int)cursors.entered);
        }

        private void MouseExit(object sender, EventArgs e)
        {
            CursorActions(sender, e, (int)cursors.left);
        }

        private void MouseUnClicked(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)buttons.unclicked);
        }

        private void MousePressed(object sender, MouseEventArgs e)
        {
            MouseActions(sender, e, (int)buttons.clicked);
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
            
        }
    }
}
