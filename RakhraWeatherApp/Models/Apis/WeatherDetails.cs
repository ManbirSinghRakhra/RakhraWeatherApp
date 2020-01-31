using Refit;

namespace RakhraWeatherApp.Models.Apis
{
    public class WeatherDetails
    {
        [AliasAs("TemperatureC")]
        public string TemperatureC { get; set; }
        
        [AliasAs("FeelsLikeC")]
        public string FeelsLikeC { get; set; }
    }
}