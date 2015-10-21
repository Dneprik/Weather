using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Services.Location;
using WeatherR.Services.Map;
using WeatherR.Weather;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XLabs.Forms.Controls;
using XLabs.Platform.Services.Geolocation;

namespace WeatherR.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly IMap _weatherMap;
        private readonly ILocation _location;
        public MapPage()
        {
              InitializeComponent();

            Map map = MyWeatherMap;
            _weatherMap = new WeatherMap(map);
            _location = new Location();
            _weatherMap.ShowCurrentLocationAsync(_location);

        }


    }
}
