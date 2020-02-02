using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
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
        private bool _isRefreshing;
        public ReadOnlyObservableCollection<FavouriteWeatherInfoModel> Items => _items;
        public ReactiveCommand<Unit, Task> PopulateDataCommand { get; }
        public ReactiveCommand<Unit, Unit> ClearDataCommand { get; }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => this.RaiseAndSetIfChanged(ref _isRefreshing, value);
        }


        public FavouriteWeatherViewModel(IFavouriteWeatherInfoUseCase favouriteWeatherInfoUseCase = null)
        {
            _favouriteWeatherInfoUseCase = favouriteWeatherInfoUseCase ?? Locator.Current.GetService<IFavouriteWeatherInfoUseCase>();
            PopulateDataCommand = ReactiveCommand.Create(async () => await PopulateData().ConfigureAwait(false));
            ClearDataCommand = ReactiveCommand.Create(() => Clear());
        }


        public async Task Init()
        {
            var orderByCity = SortExpressionComparer<FavouriteWeatherInfoModel>.Ascending(p => p.City);

            _favouriteWeatherInfoUseCase.Connect()
                .Sort(orderByCity)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _items)
                .Subscribe();

            await PopulateData().ConfigureAwait(false);
        }

        public void Clear() => _favouriteWeatherInfoUseCase.Clear();

        public async Task PopulateData()
        {
            await Xamarin.Forms.Device.InvokeOnMainThreadAsync(async () =>
            {
                IsRefreshing = true;
                await _favouriteWeatherInfoUseCase.PopulateData();
                IsRefreshing = false;
            }).ConfigureAwait(false);
        }
    }
}