using Refit;

namespace RakhraWeatherApp.ApiServices.Models
{
    public class WeatherDetails
    {
        [AliasAs("TemperatureC")]
        public string TemperatureC { get; set; }
        
        [AliasAs("FeelsLikeC")]
        public string FeelsLikeC { get; set; }
    }
}