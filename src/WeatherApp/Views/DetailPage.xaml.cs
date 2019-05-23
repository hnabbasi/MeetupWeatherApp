using System;
using System.Collections.Generic;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(CurrentWeather current)
        {
            InitializeComponent();

            Title = current.Name;
        }
    }
}
