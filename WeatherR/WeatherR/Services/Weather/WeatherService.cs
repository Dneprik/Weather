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
        const string GetTemperatureUri = "http://api.openweathermap.org/data/2.5/weather?q=Dnipropetrovsk";
        public async Task<double> GetTemperatureAsync(string city)
        {
            var responce = await _restClient.GetAsync(GetTemperatureUri);
            var weatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(responce);
            return weatherResponce.main.temp;
        }
    }
}
