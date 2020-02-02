using System;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.Models;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
using RakhraWeatherApp.Services.Interfaces;
using ReactiveUI;
using Splat;

namespace RakhraWeatherApp.Domain.UseCases
{
    public class FavouriteWeatherInfoUseCase: IFavouriteWeatherInfoUseCase
    {
        private readonly SourceCache<FavouriteWeatherInfoModel, string> _favouriteWeatherInfoModel = new SourceCache<FavouriteWeatherInfoModel, string>(display => display.City);
        private readonly IAppRestService _appRestService;
        public IObservable<IChangeSet<FavouriteWeatherInfoModel, string>> Connect() => _favouriteWeatherInfoModel.Connect();
        
        public FavouriteWeatherInfoUseCase(IAppRestService appRestService = null)
        {
            _appRestService = appRestService ?? Locator.Current.GetService<IAppRestService>();
        }


        public async Task PopulateData()
        {
            var calgaryWeather = await _appRestService.GetCurrentWeather("CA", "Calgary");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Calgary", TemperatureC = calgaryWeather.TemperatureC, FeelsLikeC = calgaryWeather.FeelsLikeC});
 
            var edsonWeather = await _appRestService.GetCurrentWeather("CA", "Edson");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Edson", TemperatureC = edsonWeather.TemperatureC, FeelsLikeC = edsonWeather.FeelsLikeC});

            var torontoWeather = await _appRestService.GetCurrentWeather("CA", "Toronto");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Toronto", TemperatureC = torontoWeather.TemperatureC, FeelsLikeC = torontoWeather.FeelsLikeC});
            
         }


        public void Clear() => _favouriteWeatherInfoModel.Clear();
    }
}