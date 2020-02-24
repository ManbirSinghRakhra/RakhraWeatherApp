using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RakhraWeatherApp.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task InitializeDataBaseTableAsync();
        Task<List<T>> GetItemsAsync();

        Task<int> SaveItemAsync<T>(T item);

        Task<int> DeleteItemAsync(T item);

    }
}