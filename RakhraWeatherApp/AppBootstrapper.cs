using System;
using RakhraWeatherApp.Domain.UseCases;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
using RakhraWeatherApp.Services;
using RakhraWeatherApp.Services.Interfaces;
using RakhraWeatherApp.ViewModels;
using RakhraWeatherApp.Views;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;


namespace RakhraWeatherApp
{
    public class AppBootstrapper: ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            RegisterDependencies();
            RegisterViewModels();


            this.Router
                .NavigateAndReset
                .Execute(new FavouriteWeatherViewModel())
                .Subscribe();
        }

        private void RegisterViewModels()
        {
            Locator.CurrentMutable.Register(() => new MainPage(), typeof(IViewFor<FavouriteWeatherViewModel>));
        }

        private void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.RegisterLazySingleton(() => new AppRestService(), typeof(IAppRestService));
            Locator.CurrentMutable.RegisterLazySingleton(() => new FavouriteWeatherInfoUseCase(),
                typeof(IFavouriteWeatherInfoUseCase));
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }

        public RoutingState Router { get; protected set; }
    }
}