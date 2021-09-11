using CGCC_2.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CGCC_2.ViewModels
{
    [QueryProperty(nameof(UserObjectID), nameof(UserObjectID))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int userObjectId;
        private string userName;
        private string name;
        private string phone;
        private string password;


        public int Id { get; set; }

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

        public int UserObjectID
        {
            get
            {
                return userObjectId;
            }
            set
            {
                userObjectId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int userObjectId)
        {
            try
            {
                var userObject = await DataStore.GetItemAsync(userObjectId);
                Id = userObject.Id;
                Name = userObject.name;
                UserName = userObject.userName;
                Phone = userObject.phone;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
