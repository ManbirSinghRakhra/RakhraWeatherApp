using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.UseCases;
using ReactiveUI;

namespace RakhraWeatherApp.ViewModels
{
    public class FavouriteWeatherViewModel: ReactiveObject
    {
        private ReadOnlyObservableCollection<FavouriteWeatherInfoModel> _items;
        private FavouriteWeatherInfoUseCase favouriteWeatherInfoUseCase;
        public ReadOnlyObservableCollection<FavouriteWeatherInfoModel> Items => _items;


        public FavouriteWeatherViewModel()
        {

        }

        public void Init()
        {
            favouriteWeatherInfoUseCase = new FavouriteWeatherInfoUseCase();
            favouriteWeatherInfoUseCase.Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _items)
                .Subscribe();
        }

        public void Clear() => favouriteWeatherInfoUseCase.Clear();

        public async Task PopulateData() => await favouriteWeatherInfoUseCase.PopulateData();
    }
}