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
        public SQLiteConnection connection;

        public DatabaseConn()
        {
            connection = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./LocalDatabase.sqlite3"))
            {
                SQLiteConnection.CreateFile("LocalDatabase.sqlite3");
            }
           
        }
    }
}
