using System;
using System.Net.Http;
using System.Threading.Tasks;
using RakhraWeatherApp.Models.Apis;
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
    }
}