using System.Threading.Tasks;
using CoreLocation;
using Foundation;
using RakhraWeatherApp.iOS.Services;
using RakhraWeatherApp.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PermissionService))]
namespace RakhraWeatherApp.iOS.Services
{
    public class PermissionService:IPermissionService
    {
        public Task<bool> GetGeoLocationPermissionAsync()
        {
            var clLocationManager = new CLLocationManager();
            if (CLLocationManager.LocationServicesEnabled)
            {
                var status = CLLocationManager.Status;
                bool hasPermission = false;
                if (status == CLAuthorizationStatus.Authorized || status == CLAuthorizationStatus.AuthorizedAlways ||
                    status == CLAuthorizationStatus.AuthorizedWhenInUse)
                {
                    hasPermission = true;
                }

                if (status == CLAuthorizationStatus.Denied || status == CLAuthorizationStatus.Restricted ||
                    status == CLAuthorizationStatus.NotDetermined)
                {
                    hasPermission = false;
                    clLocationManager.RequestWhenInUseAuthorization();

                    //Device.BeginInvokeOnMainThread(() => UIApplication.SharedApplication.OpenUrl(new NSUrl(UIApplication.OpenSettingsUrlString)));
                }
                return Task.FromResult(hasPermission);
            }
            return Task.FromResult(false);
        }
    }
}