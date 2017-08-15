using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    class LocalAudioItem
    {
        public int readerId { get; set; }
        public string readerTitle { get; set; }
        public string readerArtist { get; set; }
        public string readerAlbum { get; set; }
        public string readerPlaylist { get; set; }
        public double readerLength { get; set; }
        public string readerGenre { get; set; }
        public int readerPlays { get; set; }
        public string readerFileExtension { get; set; }
        public string readerFilePath { get; set; }

        public LocalAudioItem(int Id, string title, string artist, string album, string playlist, double length, string genre, int plays, string extension, string path)
        {
            this.readerId = Id;
            this.readerTitle = title;
            this.readerArtist = artist;
            this.readerAlbum = album;
            this.readerPlaylist = playlist;
            this.readerLength = length;
            this.readerGenre = genre;
            this.readerPlays = plays;
            this.readerFileExtension = extension;
            this.readerFilePath = path;
        }
        
        public LocalAudioItem clearAudioItem()
        {
            this.readerTitle = null;
            this.readerArtist = null;
            this.readerAlbum = null;
            this.readerPlaylist = null;
            this.readerLength = 0;
            this.readerGenre = null;
            this.readerPlays = 0;
            this.readerFileExtension = null;
            this.readerFilePath = null;

            return this;
        }
    }
}
