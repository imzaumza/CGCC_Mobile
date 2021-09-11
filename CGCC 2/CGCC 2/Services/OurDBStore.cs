using CGCC_2.Interfaces;
using CGCC_2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CGCC_2.Services
{
    public class OurDBStore : IDataStore<User>
    {
        private SQLiteConnection _SQLiteConnection;
        public OurDBStore()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<User>();
        }
        public Task<bool> AddItemAsync(User user)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.name == user.name && x.userName == user.userName).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            
            return Task.FromResult(_SQLiteConnection.Delete<User>(id) > 0);
        }

        public Task<User> GetItemAsync(int id)
        {
            return Task.FromResult(_SQLiteConnection.Table<User>().FirstOrDefault(t => t.Id == id));
        }

        public Task<List<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult(_SQLiteConnection.Table<User>().ToList());
        }

        public Task<bool> UpdateItemAsync(User item)
        {
            //to be done
            throw new NotImplementedException();
        }
    }
}
