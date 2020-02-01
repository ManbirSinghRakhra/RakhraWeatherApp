using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.Models;
using RakhraWeatherApp.Domain.UseCases;
using RakhraWeatherApp.Domain.UseCases.Interfaces;
using ReactiveUI;
using Splat;

namespace RakhraWeatherApp.ViewModels
{
    public class FavouriteWeatherViewModel: ReactiveObject
    {
        private readonly IFavouriteWeatherInfoUseCase _favouriteWeatherInfoUseCase;
        private ReadOnlyObservableCollection<FavouriteWeatherInfoModel> _items;
        public ReadOnlyObservableCollection<FavouriteWeatherInfoModel> Items => _items;


        public FavouriteWeatherViewModel(IFavouriteWeatherInfoUseCase favouriteWeatherInfoUseCase = null)
        {
            _favouriteWeatherInfoUseCase = favouriteWeatherInfoUseCase ?? Locator.Current.GetService<IFavouriteWeatherInfoUseCase>();
        }

        public async Task Init()
        {
            _favouriteWeatherInfoUseCase.Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _items)
                .Subscribe();

            await PopulateData().ConfigureAwait(false);
        }

        public void Clear() => _favouriteWeatherInfoUseCase.Clear();

        public async Task PopulateData() => await _favouriteWeatherInfoUseCase.PopulateData().ConfigureAwait(false);
    }
}