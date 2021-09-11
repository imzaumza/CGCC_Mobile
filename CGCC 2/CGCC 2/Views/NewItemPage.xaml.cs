using CGCC_2.Models;
using CGCC_2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CGCC_2.Views
{
    public partial class NewItemPage : ContentPage
    {
        public User Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}