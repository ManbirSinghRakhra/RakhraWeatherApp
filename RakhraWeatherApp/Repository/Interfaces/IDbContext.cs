using SQLite;

namespace RakhraWeatherApp.Repository.Interfaces
{
    public interface IDbContext
    {
        SQLiteAsyncConnection Database { get; }
    }
}