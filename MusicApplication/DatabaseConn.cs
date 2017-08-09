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
        static string createTableQuery = "CREATE TABLE IF NOT EXISTS LocalMusicTable (" +
            "Id int PRIMARY KEY," +
            "Title VARCHAR(20)," +
            "Artist VARCHAR(20)," +
            "Album VARCHAR(20)," +
            "PlayList VARCHAR(50)" +
            "Length double" +
            "Genre VARCHAR(20)" +
            "Plays int)";

        public DatabaseConn()
        {
            connection = new SQLiteConnection("Data Source=database.sqlite3");

            //if (!File.Exists("./LocalDatabase.sqlite3"))
            //{
                SQLiteConnection.CreateFile("LocalDatabase.sqlite3");
            //}

            createTable();
           
        }

        public static void createTable()
        {
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
            connection.Open();
            createTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void AddSongToTable(string title, string artist, string album, string playlist, double length, string genre, int plays)
        {
            string addSongQuery = ($"INSERT INTO LocalMusicTable (Title, Artist, Album, Playlist, Length, Genre, Plays) values ({title}, {artist}, {album}, {playlist}, {length}, {genre}, {plays})");
            SQLiteCommand addSongToTableCommand = new SQLiteCommand(addSongQuery, connection);
            connection.Open();
            addSongToTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public string GetSongsFromTable()
        {
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
