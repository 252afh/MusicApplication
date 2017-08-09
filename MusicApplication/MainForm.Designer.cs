namespace MusicApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "0",
            "ExampleTitle",
            "Blink182",
            "Rock",
            "20/07/2017",
            "3.45",
            "4",
            "Playlist"}, -1);
            this.HomePageButton = new System.Windows.Forms.Button();
            this.LocalButton = new System.Windows.Forms.Button();
            this.APIButton = new System.Windows.Forms.Button();
            this.OptionButton = new System.Windows.Forms.Button();
            this.AddToLocalLibBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Plays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Playlist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HomePageButton
            // 
            this.HomePageButton.AutoSize = true;
            this.HomePageButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.HomePageButton.Location = new System.Drawing.Point(12, 31);
            this.HomePageButton.Name = "HomePageButton";
            this.HomePageButton.Size = new System.Drawing.Size(136, 41);
            this.HomePageButton.TabIndex = 1;
            this.HomePageButton.UseVisualStyleBackColor = true;
            this.HomePageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.HomePageButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.HomePageButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.HomePageButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // LocalButton
            // 
            this.LocalButton.AutoSize = true;
            this.LocalButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.LocalButton.Location = new System.Drawing.Point(322, 31);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(136, 41);
            this.LocalButton.TabIndex = 2;
            this.LocalButton.UseVisualStyleBackColor = true;
            this.LocalButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.LocalButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.LocalButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // APIButton
            // 
            this.APIButton.AutoSize = true;
            this.APIButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.APIButton.Location = new System.Drawing.Point(683, 31);
            this.APIButton.Name = "APIButton";
            this.APIButton.Size = new System.Drawing.Size(136, 41);
            this.APIButton.TabIndex = 3;
            this.APIButton.UseVisualStyleBackColor = true;
            this.APIButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.APIButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.APIButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // OptionButton
            // 
            this.OptionButton.AutoSize = true;
            this.OptionButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.OptionButton.Location = new System.Drawing.Point(1018, 31);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(136, 41);
            this.OptionButton.TabIndex = 4;
            this.OptionButton.UseVisualStyleBackColor = true;
            this.OptionButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.OptionButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.OptionButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // AddToLocalLibBtn
            // 
            this.AddToLocalLibBtn.Location = new System.Drawing.Point(12, 2);
            this.AddToLocalLibBtn.Name = "AddToLocalLibBtn";
            this.AddToLocalLibBtn.Size = new System.Drawing.Size(75, 23);
            this.AddToLocalLibBtn.TabIndex = 5;
            this.AddToLocalLibBtn.Text = "Add to local library";
            this.AddToLocalLibBtn.UseVisualStyleBackColor = true;
            this.AddToLocalLibBtn.Click += new System.EventHandler(this.AddToLocalLibBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Order,
            this.Title,
            this.Artist,
            this.Album,
            this.Date,
            this.Length,
            this.Plays,
            this.Playlist});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(80, 147);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1035, 241);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Order
            // 
            this.Order.Text = "Order";
            this.Order.Width = 86;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 86;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            this.Artist.Width = 88;
            // 
            // Album
            // 
            this.Album.Text = "Genre";
            this.Album.Width = 87;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            // 
            // Length
            // 
            this.Length.Text = "Length";
            // 
            // Plays
            // 
            this.Plays.Text = "Plays";
            // 
            // Playlist
            // 
            this.Playlist.Text = "Playlist";
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(161, 418);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(100, 20);
            this.testBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 461);
            this.Controls.Add(this.testBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.AddToLocalLibBtn);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.APIButton);
            this.Controls.Add(this.LocalButton);
            this.Controls.Add(this.HomePageButton);
            this.Name = "MainForm";
            this.Text = "MusicPlayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button HomePageButton;
        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button APIButton;
        private System.Windows.Forms.Button OptionButton;
        private System.Windows.Forms.Button AddToLocalLibBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Order;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Length;
        private System.Windows.Forms.ColumnHeader Plays;
        private System.Windows.Forms.ColumnHeader Playlist;
        private System.Windows.Forms.TextBox testBox;
    }
}

