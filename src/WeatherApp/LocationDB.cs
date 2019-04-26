using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using WeatherApp.Models;

namespace WeatherApp
{
    public class LocationDB
    {
        readonly SQLiteAsyncConnection database;

        public LocationDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SavedLocation>().Wait();
        }

        public Task<List<SavedLocation>> GetItemsAsync()
        {
            return database.Table<SavedLocation>().ToListAsync();
        }

        public Task<List<SavedLocation>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<SavedLocation>("SELECT * FROM [SavedLocation] WHERE [Done] = 0");
        }

        public Task<SavedLocation> GetItemAsync(int id)
        {
            return database.Table<SavedLocation>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SavedLocation item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SavedLocation item)
        {
            return database.DeleteAsync(item);
        }

    }
}
