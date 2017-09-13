// <copyright file="LocalAudioItem.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicApplication
{
    /// <summary>
    /// Song item
    /// </summary>
    public class LocalAudioItem
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LocalAudioItem"/> class
        /// </summary>
        /// <param name="id">Song id</param>
        /// <param name="title">Song title</param>
        /// <param name="artist">Song artist</param>
        /// <param name="album">Song album</param>
        /// <param name="playlist">Song playlist</param>
        /// <param name="length">Song length</param>
        /// <param name="genre">Song genre</param>
        /// <param name="plays">Song play count</param>
        /// <param name="extension">Song file type</param>
        /// <param name="path">Song file path location</param>
        public LocalAudioItem(long id, string title, string artist, string album, string playlist, int length, string genre, int plays, string extension, string path)
        {
            this.ReaderId = id;
            this.ReaderTitle = title;
            this.ReaderArtist = artist;
            this.ReaderAlbum = album;
            this.ReaderPlaylist = playlist;
            this.ReaderLength = length;
            this.ReaderGenre = genre;
            this.ReaderPlays = plays;
            this.ReaderFileExtension = extension;
            this.ReaderFilePath = path;
        }

        /// <summary>
        /// Gets or sets unique Id of the song
        /// </summary>
        public long ReaderId { get; set; }

        /// <summary>
        /// Gets or sets title of the song
        /// </summary>
        public string ReaderTitle { get; set; }

        /// <summary>
        /// Gets or sets artist of the song
        /// </summary>
        public string ReaderArtist { get; set; }

        /// <summary>
        /// Gets or sets album of the song
        /// </summary>
        public string ReaderAlbum { get; set; }

        /// <summary>
        /// Gets or sets playlist of the song
        /// </summary>
        public string ReaderPlaylist { get; set; }

        /// <summary>
        /// Gets or sets length of the song
        /// </summary>
        public int ReaderLength { get; set; }

        /// <summary>
        /// Gets or sets genre of the song
        /// </summary>
        public string ReaderGenre { get; set; }

        /// <summary>
        /// Gets or sets count of how many times the song has been played
        /// </summary>
        public int ReaderPlays { get; set; }

        /// <summary>
        /// Gets or sets file type of the song
        /// </summary>
        public string ReaderFileExtension { get; set; }

        /// <summary>
        /// Gets or sets file location of the song
        /// </summary>
        public string ReaderFilePath { get; set; }
                       
        /// <summary>
        /// Clears the specified audio item back to null
        /// </summary>
        /// <returns>The audio item that has been cleared</returns>
        public LocalAudioItem ClearAudioItem()
        {
            this.ReaderTitle = null;
            this.ReaderArtist = null;
            this.ReaderAlbum = null;
            this.ReaderPlaylist = null;
            this.ReaderLength = 0;
            this.ReaderGenre = null;
            this.ReaderPlays = 0;
            this.ReaderFileExtension = null;
            this.ReaderFilePath = null;

            return this;
        }
    }
}
