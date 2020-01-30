using System;
using DynamicData;
using RakhraWeatherApp.Domain.UseCases.Interfaces;

namespace RakhraWeatherApp.Domain.UseCases
{
    public class FavouriteWeatherInfoUseCase: IFavouriteWeatherInfoUseCase
    {
        private readonly SourceCache<FavouriteWeatherInfoModel, string> _favouriteWeatherInfoModel = new SourceCache<FavouriteWeatherInfoModel, string>(display => display.City);

        public IObservable<IChangeSet<FavouriteWeatherInfoModel, string>> Connect() => _favouriteWeatherInfoModel.Connect();
        
        public FavouriteWeatherInfoUseCase()
        {
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Calgary", TemperatureC = 4});
        }
    }

    public class FavouriteWeatherInfoModel
    {
        public string City { get; set; }
        public int TemperatureC { get; set; }
    }
}