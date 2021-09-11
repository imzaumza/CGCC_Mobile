﻿using CGCC_2.Models;
using CGCC_2.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CGCC_2.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private User _selectedItem;

        public ObservableCollection<User> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<User> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<User>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            //   await Shell.Current.GoToAsync(nameof(NewItemPage));
           await App.NavigationPageAsync(new NewItemPage());
        }

        async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //  await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.UserObjectID)}={item.Id}");
            await App.NavigationPageAsync(new ItemDetailPage(item.Id));
        
        }
    }
}