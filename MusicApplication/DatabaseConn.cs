using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Collections;

namespace MusicApplication
{
    class DatabaseConn
    {
        private static SQLiteConnection connection;
        private static ArrayList itemList;

        public DatabaseConn()
        {
            itemList = new ArrayList();
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

        public string AddSongToTable(string title, string artist, string album, string playlist, double length, string genre, int plays, string fileExtension, string filePath)
        {
            connection.Open();
            SQLiteParameter paramTitle = new SQLiteParameter("@paramTitle") { Value = title };
            SQLiteParameter paramArtist = new SQLiteParameter("@paramArtist") { Value = artist };
            SQLiteParameter paramAlbum = new SQLiteParameter("@paramAlbum") { Value = album };
            SQLiteParameter paramPlaylist = new SQLiteParameter("@paramPlaylist") { Value = playlist };
            SQLiteParameter paramLength = new SQLiteParameter("@paramLength") { Value = length };
            SQLiteParameter paramGenre = new SQLiteParameter("@paramGenre") { Value = genre };
            SQLiteParameter paramPlays = new SQLiteParameter("@paramPlays") { Value = plays };
            SQLiteParameter paramExtension = new SQLiteParameter("@paramExtension") { Value = fileExtension };
            SQLiteParameter paramPath = new SQLiteParameter("@paramPath") { Value = filePath };

            bool notExist = checkNotExists(paramPath);

            if (notExist)
            {
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
            else if (!notExist)
            {
                return "That song already exists at that file location.";
            }
            connection.Close();
            return "";
            
        }

        private bool checkNotExists(SQLiteParameter extensionParam)
        {
            connection.Open();
            SQLiteCommand checkCommand = new SQLiteCommand("SELECT FileExtension FROM LocalMusicTable WHERE FileExtension = @paramPath");
            string result = Convert.ToString(checkCommand.ExecuteScalar());
            connection.Close();

            if (result != null || result != "")
            {
                return true;
            }
            return false;
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

        public ArrayList GetSongsFromTable()
        {
            int rowCount = getRowCount();
            string getFromTable = ("SELECT * FROM LocalMusicTable");
            SQLiteCommand getFromTableCommand = new SQLiteCommand(getFromTable, connection);
            connection.Open();
            SQLiteDataReader reader = getFromTableCommand.ExecuteReader();
            ArrayList audioItemList = new ArrayList();
            while (reader.Read())
            {
                int readerId = (int)reader["Id"];
                string readerTitle = (string)reader["Title"];
                string readerArtist = (string)reader["Artist"];
                string readerAlbum = (string)reader["Album"];
                string readerPlaylist = (string)reader["PlayList"];
                double readerLength = (double)reader["Length"];
                string readerGenre = (string)reader["Genre"];
                int readerPlays = (int)reader["Plays"];
                string readerFileExtension = (string)reader["Extension"];
                string readerFilePath = (string)reader["FilePath"];
                LocalAudioItem audioItem = new LocalAudioItem(readerId, readerTitle, readerArtist, readerAlbum, readerPlaylist, readerLength, readerGenre, readerPlays, readerFileExtension, readerFilePath);
                audioItemList.Add(audioItem);
            }
            connection.Close();
            return audioItemList;
        }
    }
}
