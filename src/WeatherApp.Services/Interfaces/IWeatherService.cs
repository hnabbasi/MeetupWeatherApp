using System.Threading.Tasks;
using Refit;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        //appid=b6907d289e10d714a6e88b30761fae22
        [Get("/data/2.5/weather?zip={zipcode}&appid={appid}&units=imperial")]
        Task<CurrentWeather> GetTemp(string zipcode, string appid);
    }
}
