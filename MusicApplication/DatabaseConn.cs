using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace MusicApplication
{
    class DatabaseConn
    {
        public static SQLiteConnection connection;

        public DatabaseConn()
        {
            if (!File.Exists("./LocalDatabase.sqlite3"))
            {
                SQLiteConnection.CreateFile("LocalDatabase.sqlite3"); 
            }

            connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3");
            
            createTable();
        }

        public void dropTable()
        {
            string dropQuery = "DROP TABLE LocalMusicTable";
            SQLiteCommand dropTableCommand = new SQLiteCommand(dropQuery, connection);
            connection.Open();
            dropTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void createTable()
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS LocalMusicTable (" +
            "Id INTEGER PRIMARY KEY," +
            "Title VARCHAR(20)," +
            "Artist VARCHAR(20)," +
            "Album VARCHAR(20)," +
            "PlayList VARCHAR(50)," +
            "Length real," +
            "Genre VARCHAR(20)," +
            "Plays int," +
            "FileExtension VARCHAR(10)," +
            "FilePath VARCHAR(50)" +
            ")";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
            connection.Open();
            createTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void AddSongToTable(string title, string artist, string album, string playlist, double length, string genre, int plays, string fileExtension, string filePath)
        {
            connection.Open();
            var paramTitle = new SQLiteParameter("@paramTitle") { Value = title };
            var paramArtist = new SQLiteParameter("@paramArtist") { Value = artist };
            var paramAlbum = new SQLiteParameter("@paramAlbum") { Value = album };
            var paramPlaylist = new SQLiteParameter("@paramPlaylist") { Value = playlist };
            var paramLength = new SQLiteParameter("@paramLength") { Value = length };
            var paramGenre = new SQLiteParameter("@paramGenre") { Value = genre };
            var paramPlays = new SQLiteParameter("@paramPlays") { Value = plays };
            var paramExtension = new SQLiteParameter("@paramExtension") { Value = fileExtension };
            var paramPath = new SQLiteParameter("@paramPath") { Value = filePath };
            SQLiteCommand addSongToTableCommand = new SQLiteCommand("INSERT INTO LocalMusicTable (Title, Artist, Album, Playlist, Length, Genre, Plays, FileExtension, FilePath)" + " VALUES (@paramTitle, @paramArtist, @paramAlbum, @paramPlaylist, @paramLength, @paramGenre, @paramPlays, @paramExtension, @paramPath)", connection);
            addSongToTableCommand.CommandType = System.Data.CommandType.Text;
            addSongToTableCommand.Parameters.Add(paramTitle);
            addSongToTableCommand.Parameters.Add(paramArtist);
            addSongToTableCommand.Parameters.Add(paramAlbum);
            addSongToTableCommand.Parameters.Add(paramPlaylist);
            addSongToTableCommand.Parameters.Add(paramLength);
            addSongToTableCommand.Parameters.Add(paramGenre);
            addSongToTableCommand.Parameters.Add(paramPlays);
            addSongToTableCommand.Parameters.Add(paramExtension);
            addSongToTableCommand.Parameters.Add(paramPath);
            addSongToTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void GetSongsFromTable()
        {
            //getSongsFromTable(order, true);
        }

        private int getRowCount()
        {
            string countQuery = ("SELECT COUNT(Id)" + (" FROM LocalMusicTable"));
            SQLiteCommand getRowCount = new SQLiteCommand(countQuery, connection);
            connection.Open();
            int count = Convert.ToInt32(getRowCount.ExecuteScalar());
            connection.Close();
            return count;
        }

        public string GetSongsFromTable(string column)
        {
            int rowCount = getRowCount();
            string getFromTable = ("SELECT * FROM LocalMusicTable");
            SQLiteCommand getFromTableCommand = new SQLiteCommand(getFromTable, connection);
            connection.Open();
            SQLiteDataReader reader = getFromTableCommand.ExecuteReader();
            string readerResult = null;
            while (reader.Read())
            {
                readerResult = (string)reader["Title"];
            }
            connection.Close();
            return readerResult;
        }
    }
}
