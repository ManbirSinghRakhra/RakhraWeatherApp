using RakhraWeatherApp.Services;
using RakhraWeatherApp.Services.Interfaces;
using Splat;

namespace RakhraWeatherApp
{
    public class AppBootstrapper: IEnableLogger
    {
        public AppBootstrapper()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => new AppRestService(), typeof(IAppRestService));
        }
    }
}