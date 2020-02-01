using RakhraWeatherApp.Domain.UseCases;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
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
            Locator.CurrentMutable.RegisterLazySingleton(() => new FavouriteWeatherInfoUseCase(), typeof(IFavouriteWeatherInfoUseCase));
        }
    }
}