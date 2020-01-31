using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using RakhraWeatherApp.Domain.UseCases;
using ReactiveUI;

namespace RakhraWeatherApp.ViewModels
{
    public class FavouriteWeatherViewModel: ReactiveObject
    {
        private readonly ReadOnlyObservableCollection<FavouriteWeatherInfoModel> _items;
        public ReadOnlyObservableCollection<FavouriteWeatherInfoModel> Items => _items;


        public FavouriteWeatherViewModel()
        {
            var favouriteWeatherInfoUseCase = new FavouriteWeatherInfoUseCase();
            favouriteWeatherInfoUseCase.Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _items)
                .Subscribe();
        }
    }
}