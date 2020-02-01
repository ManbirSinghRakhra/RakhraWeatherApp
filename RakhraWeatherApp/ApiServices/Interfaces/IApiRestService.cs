using System.Threading.Tasks;
using RakhraWeatherApp.ApiServices.Models;

namespace RakhraWeatherApp.Services.Interfaces
{
    public interface IAppRestService
    {
        Task<WeatherDetails> GetCurrentCalgaryWeather();
        Task<WeatherDetails> GetCurrentWeather(string countryCode, string cityName);
    }
}