using System;
using System.IO;
using SQLite;

namespace RakhraWeatherApp
{
    public static class Constants
    {
        public const string BaseUrl = "https://api.data.pelmorex.com/weather";
        public const string ApiKey = "Vq8V0SgTAW9FLbvXpANgs7I4586XlQ3b9n88E21U";
        public const string DatabaseFilename = "RakhraWeatherAppSQLite.db3";
        public static string AppBasePath => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
}