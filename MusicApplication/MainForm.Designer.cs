using System.Drawing;

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
            this.components = new System.ComponentModel.Container();
            this.AddToLocalLibBtn = new System.Windows.Forms.Button();
            this.openFileDialogLocal = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.objectListView = new BrightIdeasSoftware.ObjectListView();
            this.OrderObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TitleObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ArtistObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AlbumObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.GenreObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DateObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LengthObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PlaysObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PlaylistObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ExtensionObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FilePathObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KeyObject = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.OptionButton = new System.Windows.Forms.Button();
            this.APIButton = new System.Windows.Forms.Button();
            this.LocalButton = new System.Windows.Forms.Button();
            this.HomePageButton = new System.Windows.Forms.Button();
            this.musicArea1 = new MusicPlayArea.MusicArea();
            this.songTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView)).BeginInit();
            this.SuspendLayout();
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
            // openFileDialogLocal
            // 
            this.openFileDialogLocal.FileName = "ImportedMusic";
            this.openFileDialogLocal.Title = "Add file to local library";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // objectListView
            // 
            this.objectListView.AllColumns.Add(this.OrderObject);
            this.objectListView.AllColumns.Add(this.TitleObject);
            this.objectListView.AllColumns.Add(this.ArtistObject);
            this.objectListView.AllColumns.Add(this.AlbumObject);
            this.objectListView.AllColumns.Add(this.GenreObject);
            this.objectListView.AllColumns.Add(this.DateObject);
            this.objectListView.AllColumns.Add(this.LengthObject);
            this.objectListView.AllColumns.Add(this.PlaysObject);
            this.objectListView.AllColumns.Add(this.PlaylistObject);
            this.objectListView.AllColumns.Add(this.ExtensionObject);
            this.objectListView.AllColumns.Add(this.FilePathObject);
            this.objectListView.AllColumns.Add(this.KeyObject);
            this.objectListView.CellEditUseWholeCell = false;
            this.objectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderObject,
            this.TitleObject,
            this.ArtistObject,
            this.AlbumObject,
            this.GenreObject,
            this.DateObject,
            this.LengthObject,
            this.PlaysObject,
            this.PlaylistObject});
            this.objectListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView.FullRowSelect = true;
            this.objectListView.GridLines = true;
            this.objectListView.Location = new System.Drawing.Point(12, 147);
            this.objectListView.Name = "objectListView";
            this.objectListView.ShowGroups = false;
            this.objectListView.Size = new System.Drawing.Size(1142, 260);
            this.objectListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.objectListView.TabIndex = 10;
            this.objectListView.UseCompatibleStateImageBehavior = false;
            this.objectListView.View = System.Windows.Forms.View.Details;
            this.objectListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objectListView_MouseDoubleClick);
            // 
            // OrderObject
            // 
            this.OrderObject.Text = "Order";
            // 
            // TitleObject
            // 
            this.TitleObject.AspectName = "readerTitle";
            this.TitleObject.Text = "Title";
            // 
            // ArtistObject
            // 
            this.ArtistObject.AspectName = "readerArtist";
            this.ArtistObject.Text = "Artist";
            // 
            // AlbumObject
            // 
            this.AlbumObject.AspectName = "readerAlbum";
            this.AlbumObject.Text = "Album";
            // 
            // GenreObject
            // 
            this.GenreObject.AspectName = "readerGenre";
            this.GenreObject.Text = "Genre";
            // 
            // DateObject
            // 
            this.DateObject.AspectName = "";
            this.DateObject.Text = "Date";
            // 
            // LengthObject
            // 
            this.LengthObject.AspectName = "readerLength";
            this.LengthObject.Text = "Length";
            // 
            // PlaysObject
            // 
            this.PlaysObject.AspectName = "readerPlays";
            this.PlaysObject.Text = "Plays";
            // 
            // PlaylistObject
            // 
            this.PlaylistObject.AspectName = "readerPlaylist";
            this.PlaylistObject.Text = "Playlist";
            // 
            // ExtensionObject
            // 
            this.ExtensionObject.AspectName = "readerFileExtension";
            this.ExtensionObject.DisplayIndex = 9;
            this.ExtensionObject.IsVisible = false;
            this.ExtensionObject.Text = "Extension";
            this.ExtensionObject.Width = 202;
            // 
            // FilePathObject
            // 
            this.FilePathObject.AspectName = "readerFilePath";
            this.FilePathObject.DisplayIndex = 10;
            this.FilePathObject.IsVisible = false;
            this.FilePathObject.Text = "FilePath";
            this.FilePathObject.Width = 149;
            // 
            // KeyObject
            // 
            this.KeyObject.AspectName = "readerId";
            this.KeyObject.DisplayIndex = 9;
            this.KeyObject.IsVisible = false;
            this.KeyObject.Text = "key";
            this.KeyObject.Width = 255;
            // 
            // OptionButton
            // 
            this.OptionButton.AutoSize = true;
            this.OptionButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.OptionButton.Location = new System.Drawing.Point(650, 2);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(136, 41);
            this.OptionButton.TabIndex = 4;
            this.OptionButton.UseVisualStyleBackColor = true;
            this.OptionButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.OptionButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.OptionButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.OptionButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // APIButton
            // 
            this.APIButton.AutoSize = true;
            this.APIButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.APIButton.Location = new System.Drawing.Point(492, 2);
            this.APIButton.Name = "APIButton";
            this.APIButton.Size = new System.Drawing.Size(136, 41);
            this.APIButton.TabIndex = 3;
            this.APIButton.UseVisualStyleBackColor = true;
            this.APIButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.APIButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.APIButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.APIButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // LocalButton
            // 
            this.LocalButton.AutoSize = true;
            this.LocalButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.LocalButton.Location = new System.Drawing.Point(330, 2);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(136, 41);
            this.LocalButton.TabIndex = 2;
            this.LocalButton.UseVisualStyleBackColor = true;
            this.LocalButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.LocalButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.LocalButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.LocalButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // HomePageButton
            // 
            this.HomePageButton.AutoSize = true;
            this.HomePageButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.HomePageButton.Location = new System.Drawing.Point(165, 2);
            this.HomePageButton.Name = "HomePageButton";
            this.HomePageButton.Size = new System.Drawing.Size(136, 41);
            this.HomePageButton.TabIndex = 1;
            this.HomePageButton.UseVisualStyleBackColor = true;
            this.HomePageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.HomePageButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.HomePageButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.HomePageButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // musicArea1
            // 
            this.musicArea1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.musicArea1.Location = new System.Drawing.Point(205, 49);
            this.musicArea1.maxTime = 6;
            this.musicArea1.Name = "musicArea1";
            this.musicArea1.Size = new System.Drawing.Size(523, 84);
            this.musicArea1.TabIndex = 14;
            this.musicArea1.value = 5;
            // 
            // songTimer
            // 
            this.songTimer.Enabled = true;
            this.songTimer.Interval = 1000;
            this.songTimer.Tick += new System.EventHandler(this.songTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 461);
            this.Controls.Add(this.musicArea1);
            this.Controls.Add(this.objectListView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddToLocalLibBtn);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.APIButton);
            this.Controls.Add(this.LocalButton);
            this.Controls.Add(this.HomePageButton);
            this.Name = "MainForm";
            this.Text = "MusicPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button HomePageButton;
        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button APIButton;
        private System.Windows.Forms.Button OptionButton;
        private System.Windows.Forms.Button AddToLocalLibBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialogLocal;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.ObjectListView objectListView;
        private BrightIdeasSoftware.OLVColumn OrderObject;
        private BrightIdeasSoftware.OLVColumn TitleObject;
        private BrightIdeasSoftware.OLVColumn ArtistObject;
        private BrightIdeasSoftware.OLVColumn GenreObject;
        private BrightIdeasSoftware.OLVColumn DateObject;
        private BrightIdeasSoftware.OLVColumn LengthObject;
        private BrightIdeasSoftware.OLVColumn PlaysObject;
        private BrightIdeasSoftware.OLVColumn PlaylistObject;
        private BrightIdeasSoftware.OLVColumn ExtensionObject;
        private BrightIdeasSoftware.OLVColumn FilePathObject;
        private BrightIdeasSoftware.OLVColumn KeyObject;
        private BrightIdeasSoftware.OLVColumn AlbumObject;
        private MusicPlayArea.MusicArea musicArea1;
        private System.Windows.Forms.Timer songTimer;
    }
}

