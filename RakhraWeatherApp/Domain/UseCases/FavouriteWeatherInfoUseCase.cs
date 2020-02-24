using System;
using System.Linq;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.Models;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
using RakhraWeatherApp.Repository.Interfaces;
using RakhraWeatherApp.Repository.Models;
using RakhraWeatherApp.Services.Interfaces;
using ReactiveUI;
using Splat;

namespace RakhraWeatherApp.Domain.UseCases
{
    public class FavouriteWeatherInfoUseCase : IFavouriteWeatherInfoUseCase
    {
        private readonly IFavouriteWeatherInfo _favouriteWeatherInfo;
        private readonly SourceCache<FavouriteWeatherInfoModel, string> _favouriteWeatherInfoModel = new SourceCache<FavouriteWeatherInfoModel, string>(display => display.City);
        private readonly IAppRestService _appRestService;
        private readonly string[] cities = new[] { "Calgary", "Toronto", "Edson", "Bagha Purana" };
        private readonly string[] country = new[] { "CA", "CA", "CA", "IN" };
        public IObservable<IChangeSet<FavouriteWeatherInfoModel, string>> Connect() => _favouriteWeatherInfoModel.Connect();

        public FavouriteWeatherInfoUseCase(IAppRestService appRestService = null, IFavouriteWeatherInfo favouriteWeatherInfo = null)
        {
            _favouriteWeatherInfo = favouriteWeatherInfo ?? Locator.Current.GetService<IFavouriteWeatherInfo>();
            _appRestService = appRestService ?? Locator.Current.GetService<IAppRestService>();
        }

        public async Task PopulateData()
        {

            var favouriteCities = await _favouriteWeatherInfo.GetItemsAsync();
            favouriteCities.ForEach(city =>
            {
                _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel
                { City = city.City, TemperatureC = city.TemperatureC, FeelsLikeC = city.FeelsLikeC });
            });


            for (var i = 0; i < cities.Length; i++)
            {
                try
                {
                    var weather = await _appRestService.GetCurrentWeather(country[i], cities[i]);
                    _favouriteWeatherInfoModel.AddOrUpdate(new FavouriteWeatherInfoModel
                    { City = cities[i], TemperatureC = weather.TemperatureC, FeelsLikeC = weather.FeelsLikeC });

                    var thisFavouriteCity =
                        favouriteCities.Find(c => c.City == cities[i] && c.CountryCode == country[i]);
                    await _favouriteWeatherInfo.SaveItemAsync(new FavouriteCity()
                    {
                        ID = thisFavouriteCity?.ID??0,
                        TemperatureC = weather.TemperatureC,
                        FeelsLikeC = weather.FeelsLikeC,
                        City = cities[i],
                        CountryCode = country[i]
                    });
                }
                catch (Exception exp)
                {

                }

            }

        }

        public void Clear() => _favouriteWeatherInfoModel.Clear();
    }
}