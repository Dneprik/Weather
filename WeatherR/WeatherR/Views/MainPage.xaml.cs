using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Weather;
using Xamarin.Forms;

namespace WeatherR.Views
{
    public partial class MainPage : ContentPage
    {
        readonly IWeatherService _weatherService = new WeatherService();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var temperature = await _weatherService.GetTemperatureAsync(string.Empty);
            temp.Text = temperature.ToString();
        }
    }
}
