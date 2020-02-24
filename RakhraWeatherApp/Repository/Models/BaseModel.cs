using SQLite;

namespace RakhraWeatherApp.Repository.Models
{
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}