using System;
using System.Net.Http;
using System.Threading.Tasks;
using RakhraWeatherApp.ApiServices.Models;
using RakhraWeatherApp.Services.Interfaces;
using Refit;

namespace RakhraWeatherApp.Services
{
    public class AppRestService: IAppRestService
    {
        public async Task<WeatherDetails> GetCurrentCalgaryWeather()
        {
            var weatherApi = RestService.For<IWeatherApi>(Constants.BaseUrl);
            var currentDetails = await weatherApi.GetCurrentDetails("CA", "Calgary", Constants.ApiKey);
            return currentDetails;
        }

        public async Task<WeatherDetails> GetCurrentWeather(string countryCode, string cityName)
        {
            var weatherApi = RestService.For<IWeatherApi>(Constants.BaseUrl);
            var currentDetails = await weatherApi.GetCurrentDetails(countryCode, cityName, Constants.ApiKey);
            return currentDetails;
        }
    }
}