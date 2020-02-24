using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RakhraWeatherApp.Repository.Interfaces;
using RakhraWeatherApp.Repository.Models;
using Splat;
using SQLite;
using static SQLite.SQLiteOpenFlags;

namespace RakhraWeatherApp.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        private readonly IDbContext _dbContext;

        protected BaseRepository(IDbContext dbContext = null)
        {
            _dbContext = dbContext ?? Locator.Current.GetService<IDbContext>();
        }

        public virtual async Task InitializeDataBaseTableAsync()
        {
            if (_dbContext.Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                return;
            }

            await _dbContext.Database.CreateTableAsync(typeof(T));
        }

        public virtual Task<List<T>> GetItemsAsync() => _dbContext.Database.Table<T>().ToListAsync();

        public virtual Task<T> GetItemAsync(int id) =>
            _dbContext.Database.Table<T>().Where(i => (i as BaseModel).ID == id).FirstOrDefaultAsync();

        public virtual Task<int> SaveItemAsync<T>(T item)
        {
            if (!(item is BaseModel baseModel))
            {
                return null;
            }

            return baseModel.ID != 0
                ? _dbContext.Database.UpdateAsync(item)
                : _dbContext.Database.InsertAsync(item);
        }

        public virtual Task<int> DeleteItemAsync(T item) => _dbContext.Database.DeleteAsync(item);
    }
}