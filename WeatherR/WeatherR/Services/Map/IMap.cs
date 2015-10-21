using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Services.Location;

namespace WeatherR.Services.Map
{
    interface IMap
    {
        void ShowCurrentLocationAsync(ILocation location);
    }
}
