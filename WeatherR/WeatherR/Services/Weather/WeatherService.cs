using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Models;
using WeatherR.Services.Networking;

namespace WeatherR.Weather
{
    class WeatherService : IWeatherService
    {
        readonly IRestClient _restClient = new RestClient();
        private string _city;
        const string GetTemperatureTodayUri = "http://api.openweathermap.org/data/2.5/weather?q=";


        public async Task<double> GetTemperatureTodayAsync(string city)
        {
            var responce = await _restClient.GetAsync(GetTemperatureTodayUri+city);
            var weatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(responce);
            return KelvinToCelsius(weatherResponce.main.temp);
        }

        private double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

    }
}
