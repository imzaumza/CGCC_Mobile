using CGCC_2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CGCC_2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public int Id { get; set; }
        public ItemDetailPage(int id)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
            Id = id;
        }
    }
}