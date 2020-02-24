using System;
using System.IO;
using RakhraWeatherApp.Repository.Interfaces;
using SQLite;
using static SQLite.SQLiteOpenFlags;

namespace RakhraWeatherApp.Repository
{
    public class DbContext: IDbContext
    {
        private const SQLiteOpenFlags Flags =
            ReadWrite | Create | SharedCache;
        private static string DatabasePath => Path.Combine(Constants.AppBasePath, Constants.DatabaseFilename);

        private readonly Lazy<SQLiteAsyncConnection> _lazyInitializer =
            new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(DatabasePath, Flags));

        public SQLiteAsyncConnection Database => _lazyInitializer.Value;
    }
}