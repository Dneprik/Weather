using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherR.Weather
{
    public interface IWeatherService
    {
        Task<double> GetTemperatureTodayAsync(string city);
        Task<double> GetHumidityTodayAsync(string city);
        Task<string> GetWheatherStatusAsync(string city);
        Task<string> GetWheatherDescriptionAsync(string city);
        Task<string> GetWheatherIconLinkAsync(string city);
        Task<List<Tuple<DateTime, double>>> GetForecastTemperaturesAsync(string city, int days);
    }
}
