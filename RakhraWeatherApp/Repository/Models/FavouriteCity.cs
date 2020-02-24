namespace RakhraWeatherApp.Repository.Models
{
    public class FavouriteCity: BaseModel
    {
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string TemperatureC { get; set; }
        
        public string FeelsLikeC { get; set; }
    }
}