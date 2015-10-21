using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Services.Location;
using Xamarin.Forms.Maps;

namespace WeatherR.Services.Map
{
    public class WeatherMap : IMap
    {
        private readonly Xamarin.Forms.Maps.Map _weatherMap;
        public WeatherMap(Xamarin.Forms.Maps.Map weatherMap)
        {
            _weatherMap = weatherMap;
        }


        async public void ShowCurrentLocationAsync(ILocation location)
        {
            var currentPOsition = await location.GetCurrentLocationCodinateAsync();
            _weatherMap.MoveToRegion(new MapSpan(new Position(currentPOsition.Item1, currentPOsition.Item2), 5, 5));
        }
    }
}
