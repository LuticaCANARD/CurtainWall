using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CurtainWall.BackEnd.Constants
{
    public static class DatabaseConstants
    {
        public const string DatabaseFileName = "Database.db3";
        public const SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.ReadWrite | 
            SQLiteOpenFlags.Create | // 이건 따로 뺼 수도 있음.
            SQLiteOpenFlags.SharedCache | 
            SQLiteOpenFlags.PrivateCache;
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
