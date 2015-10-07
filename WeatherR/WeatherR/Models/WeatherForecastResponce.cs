using System.Collections.Generic;

namespace WeatherR.Models
{
    public class WeatherForecastResponce
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
    }
}