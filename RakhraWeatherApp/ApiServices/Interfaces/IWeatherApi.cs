using System.Threading.Tasks;
using RakhraWeatherApp.ApiServices.Models;
using Refit;

namespace RakhraWeatherApp.Services.Interfaces
{
    public interface IWeatherApi
    {
        [Get("/Observations/{CountryCode}/{CityName}")]
        [Headers("Content-Type: application/json")]
        Task<WeatherDetails> GetCurrentDetails(string countryCode, string cityName, [Header("x-api-key")] string api_key);
    }
}