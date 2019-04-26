using System;
using System.Windows.Input;
using Refit;
using WeatherApp.Services.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using WeatherApp.Models;
using System.Collections.ObjectModel;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        IWeatherService _weatherService;
        private static string apikey = "e63ae9a5453e4cec0d82c6c75131139e";

        public MainPageViewModel()
        {
            Title = "Welcome";
            //_weatherService = DependencyService.Resolve<IWeatherService>();
            _weatherService = RestService.For<IWeatherService>("http://api.openweathermap.org");
            
            SearchCommand = new Command(OnSearchTapped);

            SavedLocations = new ObservableCollection<SavedLocation>();

            GetLocations();


        }

        private async void GetLocations()
        {
            var locations = await App.Database.GetItemsAsync();

            SavedLocations.Clear();

            foreach(var l in locations)
            {
                SavedLocations.Add(l);
            }
        }

        public ObservableCollection<SavedLocation> SavedLocations { get; set; }

        public async void GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                if (placemarks != null && placemarks.Count() > 0)
                {
                    ZipCode = placemarks.First().PostalCode;

                    OnSearchTapped(null);
                }
            }
        }

        private async void OnSearchTapped(object obj)
        {
            var currentWeather = await _weatherService.GetTemp(ZipCode, apikey);

            Temp = currentWeather.Main.Temp.ToString();
            City = currentWeather.Name;

            var exists = SavedLocations.Any(x => x.Name == City && x.Zip == ZipCode);

            if (!exists)
            {
                var save = new SavedLocation { Zip = ZipCode, Name = City };
                await App.Database.SaveItemAsync(save);
                SavedLocations.Add(save);
            }
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
