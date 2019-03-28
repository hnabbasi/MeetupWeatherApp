using System;
using System.Windows.Input;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        IWeatherService _weatherService;

        public MainPageViewModel()
        {
            Title = "Welcome";
            _weatherService = DependencyService.Resolve<IWeatherService>();
            SearchCommand = new Command(OnSearchTapped);
        }

        private void OnSearchTapped(object obj)
        {
            var currentWeather = _weatherService.GetTemp(ZipCode);
            Temp = currentWeather.Temp;
            City = currentWeather.City;
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode= value; OnPropertyChanged(); }
        }

        private string _temp;
        public string Temp
        {
            get { return _temp; }
            set { _temp = value; OnPropertyChanged(); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand { get; }

    }
}
