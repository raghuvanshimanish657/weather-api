using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTaskApi.Models
{
    public class ForecastResponse
    {
        public List<ForecastItem> List { get; set; }
        public City City { get; set; }
    }

    public class ForecastItem
    {
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Wind Wind { get; set; }
        public string Dt_txt { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}