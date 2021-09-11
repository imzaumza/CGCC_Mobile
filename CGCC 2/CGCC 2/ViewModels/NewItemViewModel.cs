using CGCC_2.Models;
using CGCC_2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CGCC_2.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string userName;
        private string name;
        private string phone;
        private string password;


        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);

            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(userName)
                && !String.IsNullOrWhiteSpace(password)
                && !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(phone);
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");

           
        }

        private async void OnSave()
        {
            User newItem = new User()
            {
                name = Name,
                password = Password,
                phone = Phone,
                userName = UserName
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            //  await Shell.Current.GoToAsync("..");
            await App.NavigationPageAsync(new ItemsPage());
        }
    }
}
