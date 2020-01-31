using System.Threading.Tasks;
using RakhraWeatherApp.Models.Apis;

namespace RakhraWeatherApp.Services.Interfaces
{
    public interface IAppRestService
    {
        Task<WeatherDetails> GetCurrentCalgaryWeather();
        Task<WeatherDetails> GetCurrentWeather(string countryCode, string cityName);
    }
}