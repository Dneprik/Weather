using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherR.Services.Networking
{
    public interface IRestClient
    {
        Task<string> GetAsync(string uri);
    }
}
