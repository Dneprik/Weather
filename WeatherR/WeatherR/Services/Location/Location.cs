using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExifLib;
using Xamarin.Forms;
using XLabs.Platform.Services.Geolocation;

namespace WeatherR.Services.Location
{
    public class Location : ILocation
    {
        private IGeolocator _geolocator;

        public Location()
        {
            this._geolocator = DependencyService.Get<IGeolocator>();
        }

        async public Task<Tuple<double,double>>  GetCurrentLocationCodinateAsync()
        {
            var currentPosition = await _geolocator.GetPositionAsync(10000);
            var latitude = currentPosition.Latitude;
            var longitude = currentPosition.Longitude;
            Tuple<double,double> result = new Tuple<double, double>(latitude,longitude);
            return result;
        }


    }
}
