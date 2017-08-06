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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            Button[] buttonList = new Button[]
            {
                HomePageButton,
                LocalButton,
                APIButton,
                OptionButton
            };
            foreach (Button selectedButton in buttonList)
            {
                if (sender.Equals(selectedButton))
                {
                    selectedButton.Image = Properties.Resources.homepage_yellow;
                }
            }
        }
    }
}
