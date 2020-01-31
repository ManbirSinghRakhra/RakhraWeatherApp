using System;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
using RakhraWeatherApp.Services.Interfaces;
using ReactiveUI;
using Splat;

namespace RakhraWeatherApp.Domain.UseCases
{
    public class FavouriteWeatherInfoUseCase: IFavouriteWeatherInfoUseCase
    {
        private readonly SourceCache<FavouriteWeatherInfoModel, string> _favouriteWeatherInfoModel = new SourceCache<FavouriteWeatherInfoModel, string>(display => display.City);
        private readonly IAppRestService AppRestService;
        public IObservable<IChangeSet<FavouriteWeatherInfoModel, string>> Connect() => _favouriteWeatherInfoModel.Connect();
        
        public FavouriteWeatherInfoUseCase(IAppRestService appRestService = null)
        {
            AppRestService = appRestService ?? Locator.Current.GetService<IAppRestService>(); 
            PopulateData();
        }


        public async Task PopulateData()
        {
            var calgaryWeather = await AppRestService.GetCurrentWeather("CA", "Calgary");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Calgary", TemperatureC = calgaryWeather.TemperatureC, FeelsLikeC = calgaryWeather.FeelsLikeC});
            
            
            var torontoWeather = await AppRestService.GetCurrentWeather("CA", "Toronto");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Toronto", TemperatureC = torontoWeather.TemperatureC, FeelsLikeC = torontoWeather.FeelsLikeC});
            
            var edsonWeather = await AppRestService.GetCurrentWeather("CA", "Edson");
            _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel{ City = "Edson", TemperatureC = edsonWeather.TemperatureC, FeelsLikeC = edsonWeather.FeelsLikeC});
        }


        public void Clear() => _favouriteWeatherInfoModel.Clear();
    }

    public class FavouriteWeatherInfoModel
    {
        public string City { get; set; }
        public string TemperatureC { get; set; }
        public string FeelsLikeC { get; set; }
    }
}