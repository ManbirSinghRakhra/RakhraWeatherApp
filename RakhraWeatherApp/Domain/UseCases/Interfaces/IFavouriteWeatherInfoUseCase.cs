using System;
using System.Threading.Tasks;
using DynamicData;
using RakhraWeatherApp.Domain.Models;

namespace RakhraWeatherApp.Domain.UseCases.Interfaces
{
    public interface IFavouriteWeatherInfoUseCase
    {
        IObservable<IChangeSet<FavouriteWeatherInfoModel, string>> Connect();
        Task PopulateData();
        void Clear();
    }
}