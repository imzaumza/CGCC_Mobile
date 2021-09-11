using CGCC_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGCC_2.Services
{
    public class MockDataStore : IDataStore<User>
    {
        readonly List<User> items;

        public MockDataStore()
        {
            items = new List<User>()
            {
                new User { Id = 1, name = "Femi Branch", password = "1234556", phone = "0809988787", userName = "fbranch@gmail.com"},
                new User { Id = 2, name = "Femi Branch", password = "1234556", phone = "0809988787", userName = "fbranch@gmail.com"},
                new User { Id = 3, name = "Femi Branch", password = "1234556", phone = "0809988787", userName = "fbranch@gmail.com"},
                new User { Id = 4, name = "Femi Branch", password = "1234556", phone = "0809988787", userName = "fbranch@gmail.com"},
                new User { Id = 5, name = "Femi Branch", password = "1234556", phone = "0809988787", userName = "fbranch@gmail.com"}
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = items.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((User arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}