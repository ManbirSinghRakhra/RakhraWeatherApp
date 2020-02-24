using RakhraWeatherApp.Domain.UseCases.Interfaces;
using RakhraWeatherApp.Repository.Interfaces;
using RakhraWeatherApp.Repository.Models;

namespace RakhraWeatherApp.Repository
{
    public class FavouriteWeatherInfo: BaseRepository<FavouriteCity>, IFavouriteWeatherInfo
    {
        public FavouriteWeatherInfo(IDbContext dbContext = null) : base(dbContext)
        {
            InitializeDataBaseTableAsync();
        }
    }
}