using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherR.Models;
using WeatherR.Services.Networking;

namespace WeatherR.Weather
{
    internal class WeatherService : IWeatherService
    {
        private const string GetWeatherTodayUri = "http://api.openweathermap.org/data/2.5/weather?q=";
        private const string GetWeatherForecastUri = "http://api.openweathermap.org/data/2.5/forecast/daily?q=city&cnt=";
        private const string WeatherIconUri = "http://openweathermap.org/img/w/";
        private readonly IRestClient _restClient = new RestClient();

        public async Task<double> GetTemperatureTodayAsync(string city)
        {
            var weatherResponce = await GetWeatherTodayAsync(city);
            return KelvinToCelsius(weatherResponce.main.temp);
        }

        public async Task<double> GetHumidityTodayAsync(string city)
        {
            var weatherResponce = await GetWeatherTodayAsync(city);
            return weatherResponce.main.humidity;
        }

        public async Task<string> GetWheatherStatusAsync(string city)
        {
            var weatherResponce = await GetWeatherTodayAsync(city);
            return weatherResponce.weather[0].main;
        }

        public async Task<string> GetWheatherDescriptionAsync(string city)
        {
            var weatherResponce = await GetWeatherTodayAsync(city);
            return weatherResponce.weather[0].description;
        }

        public async Task<string> GetWheatherIconLinkAsync(string city)
        {
            var weatherResponce = await GetWeatherTodayAsync(city);
            return WeatherIconUri + weatherResponce.weather[0].icon + ".png";
        }

        public async Task<List<Tuple<DateTime, double>>> GetForecastTemperaturesAsync(string city, int days)
        {
            var forecastTemperatureList = new List<Tuple<DateTime, double>>();
            var weatherResponce = await GetWeatherForecastAsync(city, days);
            foreach (var item in weatherResponce.list)
            {
                forecastTemperatureList.Add(new Tuple<DateTime, double>(item.Dt, KelvinToCelsius(item.temp.day)));
            }

            return forecastTemperatureList;
        }

        private async Task<WeatherResponce> GetWeatherTodayAsync(string city)
        {
            var responce = await _restClient.GetAsync(GetWeatherTodayUri + city);
            return JsonConvert.DeserializeObject<WeatherResponce>(responce);
        }

        private async Task<WeatherForecastResponce> GetWeatherForecastAsync(string city, int days = 1)
        {
            if (days > 14) days = 1;
            var weatherForecastUri = GetWeatherForecastUri.Replace("city", city);
            var responce = await _restClient.GetAsync(weatherForecastUri + days);
            return JsonConvert.DeserializeObject<WeatherForecastResponce>(responce);
        }

        private double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}