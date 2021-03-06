﻿using System.Collections;
using System.Windows.Forms;

namespace MusicApplication
{
    class ListViewItemComparer : IComparer
    {
        private int column;
        public ListViewItemComparer()
        {
            this.column = 0;
        }

        public ListViewItemComparer(int column)
        {
            this.column = column;
        }

        public int Compare(object x, object y)
        {
            return string.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
        }
    }
}
