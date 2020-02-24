using System.Threading.Tasks;

namespace RakhraWeatherApp.Services
{
    public interface IPermissionService
    {
        Task<bool> GetGeoLocationPermissionAsync();
    }
}