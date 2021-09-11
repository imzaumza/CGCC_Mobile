using CGCC_2.Services;
using CGCC_2.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CGCC_2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<OurDBStore>();
            MainPage = new NavigationPage(new MainPage());//new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static async Task NavigationPageAsync(ContentPage loginPage)
        {
           await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(loginPage));
        }
    }
}
