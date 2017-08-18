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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.totalTime = new System.Windows.Forms.Label();
            this.NoTimeLabel = new System.Windows.Forms.Label();
            this.macTrackBar1 = new XComponent.SliderBar.MACTrackBar();
            this.OptionButton = new System.Windows.Forms.Button();
            this.APIButton = new System.Windows.Forms.Button();
            this.LocalButton = new System.Windows.Forms.Button();
            this.HomePageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 5);
            this.trackBar1.Location = new System.Drawing.Point(124, 53);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(599, 44);
            this.trackBar1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(138, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalTime.Location = new System.Drawing.Point(863, 101);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(35, 13);
            this.totalTime.TabIndex = 12;
            this.totalTime.Text = "label1";
            // 
            // NoTimeLabel
            // 
            this.NoTimeLabel.AutoSize = true;
            this.NoTimeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoTimeLabel.Location = new System.Drawing.Point(232, 105);
            this.NoTimeLabel.Name = "NoTimeLabel";
            this.NoTimeLabel.Size = new System.Drawing.Size(28, 13);
            this.NoTimeLabel.TabIndex = 13;
            this.NoTimeLabel.Text = "0.00";
            // 
            // macTrackBar1
            // 
            this.macTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.macTrackBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.macTrackBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macTrackBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.macTrackBar1.IndentHeight = 6;
            this.macTrackBar1.Location = new System.Drawing.Point(235, 412);
            this.macTrackBar1.Maximum = 1;
            this.macTrackBar1.Minimum = 0;
            this.macTrackBar1.Name = "macTrackBar1";
            this.macTrackBar1.Size = new System.Drawing.Size(303, 47);
            this.macTrackBar1.TabIndex = 14;
            this.macTrackBar1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.macTrackBar1.TickHeight = 4;
            this.macTrackBar1.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.macTrackBar1.TrackerSize = new System.Drawing.Size(16, 16);
            this.macTrackBar1.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.macTrackBar1.TrackLineHeight = 3;
            this.macTrackBar1.Value = 0;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 461);
            this.Controls.Add(this.macTrackBar1);
            this.Controls.Add(this.NoTimeLabel);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.Label NoTimeLabel;
        private XComponent.SliderBar.MACTrackBar macTrackBar1;
    }
}

