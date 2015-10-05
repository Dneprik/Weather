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
    }
}
