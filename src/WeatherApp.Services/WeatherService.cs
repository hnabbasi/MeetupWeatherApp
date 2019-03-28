using System;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(WeatherService))]
namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        public CurrentWeather GetTemp(string zipcode)
        {
            CurrentWeather currentWeather = null;
            switch (zipcode)
            {
                case "77001":
                    currentWeather = new CurrentWeather { Temp = "71 F", City = "Dallas" };
                    break;
                case "77002":
                    currentWeather = new CurrentWeather { Temp = "72 F", City = "Cypress" };
                    break;
                default:
                    currentWeather = new CurrentWeather { Temp = "90 F", City = "Houston" };
                    break;
            }
            return currentWeather;
        }
    }
}
