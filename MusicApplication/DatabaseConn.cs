// <copyright file="DatabaseConn.cs" company="Emoore">
//   Copyright © EMoore. All rights reserved.
// </copyright>

namespace MusicApplication
{
    using System;
    using System.Collections;
    using System.Data.SQLite;
    using System.IO;

    /// <summary>
    /// Handles the connections to the SQLite database
    /// </summary>
    public class DatabaseConn
    {
        /// <summary>
        /// Connection to the database
        /// </summary>
        private static SQLiteConnection connection;

        /// <summary>
        /// List to contain the songs
        /// </summary>
        private static ArrayList itemList;

        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseConn"/> class
        /// </summary>
        public DatabaseConn()
        {
            itemList = new ArrayList();
            if (!File.Exists("./LocalDatabase.sqlite3"))
            {
                SQLiteConnection.CreateFile("LocalDatabase.sqlite3"); 
            }

            connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3");
            
            CreateTable();
        }

        /// <summary>
        /// Creates the table to hold the music in the SQLite database
        /// </summary>
        public static void CreateTable()
        {
            using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
            {
                using (SQLiteCommand pragmaCommand = new SQLiteCommand())
                {
                    pragmaCommand.Connection = connection;
                    string pragma = "PRAGMA journal_mode = OFF";
                    pragmaCommand.CommandText = pragma;
                    connection.Open();
                    pragmaCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
            {
                using (SQLiteCommand createTableCommand = new SQLiteCommand())
                {
                    createTableCommand.Connection = connection;
                    createTableCommand.CommandText = "CREATE TABLE IF NOT EXISTS LocalMusicTable (" +
                    "Id INTEGER PRIMARY KEY," +
                    "Title VARCHAR(20)," +
                    "Artist VARCHAR(20)," +
                    "Album VARCHAR(20)," +
                    "PlayList VARCHAR(50)," +
                    "Length int," +
                    "Genre VARCHAR(20)," +
                    "Plays int," +
                    "FileExtension VARCHAR(10)," +
                    "FilePath VARCHAR(50)" +
                    ")";
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    createTableCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes the table contents
        /// </summary>
        public void DropTable()
        {
            using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
            {
                using (SQLiteCommand dropTableCommand = new SQLiteCommand())
                {
                    dropTableCommand.Connection = connection;
                    dropTableCommand.CommandText = "DROP TABLE LocalMusicTable";
                    connection.Open();
                    dropTableCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Adds a song to the song table
        /// </summary>
        /// <param name="title">Title of the song</param>
        /// <param name="artist">Artist of the song</param>
        /// <param name="album">Album of the song</param>
        /// <param name="playlist">Playlist the song belong to</param>
        /// <param name="length">Length of the song</param>
        /// <param name="genre">Genre of the song</param>
        /// <param name="plays">Number of plays of the song</param>
        /// <param name="fileExtension">The file type of the song</param>
        /// <param name="filePath">The location of the song</param>
        /// <returns>Returns the message to display, whether the song has been successfully added or not</returns>
        public string AddSongToTable(string title, string artist, string album, string playlist, int length, string genre, int plays, string fileExtension, string filePath)
        {
            SQLiteParameter paramTitle = new SQLiteParameter("@paramTitle") { Value = title };
            SQLiteParameter paramArtist = new SQLiteParameter("@paramArtist") { Value = artist };
            SQLiteParameter paramAlbum = new SQLiteParameter("@paramAlbum") { Value = album };
            SQLiteParameter paramPlaylist = new SQLiteParameter("@paramPlaylist") { Value = playlist };
            SQLiteParameter paramLength = new SQLiteParameter("@paramLength") { Value = length };
            SQLiteParameter paramGenre = new SQLiteParameter("@paramGenre") { Value = genre };
            SQLiteParameter paramPlays = new SQLiteParameter("@paramPlays") { Value = plays };
            SQLiteParameter paramExtension = new SQLiteParameter("@paramExtension") { Value = fileExtension };
            SQLiteParameter paramPath = new SQLiteParameter("@paramPath") { Value = filePath };

            bool notExist = this.CheckNotExists(filePath);
            
            if (notExist)
            {
                using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
                {
                    using (SQLiteCommand addSongToTableCommand = new SQLiteCommand())
                    {
                        addSongToTableCommand.Connection = connection;
                        addSongToTableCommand.CommandText = "INSERT INTO LocalMusicTable (Title, Artist, Album, Playlist, Length, Genre, Plays, FileExtension, FilePath)" + " VALUES (@paramTitle, @paramArtist, @paramAlbum, @paramPlaylist, @paramLength, @paramGenre, @paramPlays, @paramExtension, @paramPath)";
                        addSongToTableCommand.Parameters.AddWithValue("@paramTitle", title);
                        addSongToTableCommand.Parameters.AddWithValue("@paramArtist", artist);
                        addSongToTableCommand.Parameters.AddWithValue("@paramAlbum", album);
                        addSongToTableCommand.Parameters.AddWithValue("@paramPlaylist", playlist);
                        addSongToTableCommand.Parameters.AddWithValue("@paramLength", length);
                        addSongToTableCommand.Parameters.AddWithValue("@paramGenre", genre);
                        addSongToTableCommand.Parameters.AddWithValue("@paramPlays", plays);
                        addSongToTableCommand.Parameters.AddWithValue("@paramExtension", fileExtension);
                        addSongToTableCommand.Parameters.AddWithValue("@paramPath", filePath);

                        if (connection.State != System.Data.ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        addSongToTableCommand.ExecuteNonQuery();
                    }
                }
            }
            else if (!notExist)
            {
                return "That song already exists at that file location.";
            }

            return string.Empty;
        }

        /// <summary>
        /// Creates an array list containing all the songs in the table then returns them
        /// </summary>
        /// <returns>The array list containing all the songs in the table</returns>
        public ArrayList GetSongsFromTable()
        {
            ArrayList audioItemList = new ArrayList();
            if (this.GetRowCount() > 0)
            {
                using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
                {
                    using (SQLiteCommand getFromTableCommand = new SQLiteCommand())
                    {
                        getFromTableCommand.Connection = connection;
                        getFromTableCommand.CommandText = "SELECT * FROM LocalMusicTable";

                        if (connection.State != System.Data.ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        SQLiteDataReader reader = getFromTableCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            long readerId = (long)reader["Id"];
                            string readerTitle = reader["Title"].ToString();
                            string readerArtist = reader["Artist"].ToString();
                            string readerAlbum = reader["Album"].ToString();
                            string readerPlaylist = reader["PlayList"].ToString();
                            int readerLength = (int)reader["Length"];
                            string readerGenre = reader["Genre"].ToString();
                            int readerPlays = (int)reader["Plays"];
                            string readerFileExtension = reader["FileExtension"].ToString();
                            string readerFilePath = reader["FilePath"].ToString();
                            LocalAudioItem audioItem = new LocalAudioItem(readerId, readerTitle, readerArtist, readerAlbum, readerPlaylist, readerLength, readerGenre, readerPlays, readerFileExtension, readerFilePath);
                            audioItemList.Add(audioItem);
                        }
                    }
                }
            }

            return audioItemList;
        }

        /// <summary>
        /// Checks whether the song exists in the table already or not
        /// </summary>
        /// <param name="filepath">The file location of the song to check</param>
        /// <returns>Whether the song exists already or not</returns>
        private bool CheckNotExists(string filepath)
        {
            using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
            {
                using (SQLiteCommand checkCommand = new SQLiteCommand())
                {
                    checkCommand.Connection = connection;
                    checkCommand.CommandText = "SELECT [FilePath] FROM [LocalMusicTable] WHERE [FilePath] = @paramPath";
                    checkCommand.Parameters.AddWithValue("@paramPath", filepath);

                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    SQLiteDataReader result = checkCommand.ExecuteReader();

                    if (result.HasRows)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the amount of items in the song table
        /// </summary>
        /// <returns>The number of songs in the song table</returns>
        private int GetRowCount()
        {
            int count = 0;
            using (connection = new SQLiteConnection("Data Source=LocalDatabase.sqlite3"))
            {
                using (SQLiteCommand getRowCountCommand = new SQLiteCommand())
                {
                    getRowCountCommand.Connection = connection;
                    getRowCountCommand.CommandText = "SELECT COUNT(Id)" + " FROM LocalMusicTable";

                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    count = Convert.ToInt32(getRowCountCommand.ExecuteScalar());
                }
            }

            return count;
        }
    }
}
