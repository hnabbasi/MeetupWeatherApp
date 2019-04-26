using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class MainPage : ContentPage
    {
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
