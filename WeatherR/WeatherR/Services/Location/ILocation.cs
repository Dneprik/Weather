using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherR.Services.Location
{
    public interface ILocation
    {
       Task<Tuple<double, double>> GetCurrentLocationCodinateAsync();
    }
}
