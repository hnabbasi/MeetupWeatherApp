using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class MainPage : ContentPage
    {
        public void Handle_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailPage(ViewModel.Current));
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var w = (CurrentWeather)e.Item;
            ViewModel.ZipCode = w.Zip;
            ViewModel.SearchCommand.Execute(null);
        }

        MainPageViewModel ViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetLocation();
        }
    }
}
