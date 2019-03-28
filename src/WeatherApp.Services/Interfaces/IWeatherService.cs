using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        CurrentWeather GetTemp(string zipcode);
    }
}
