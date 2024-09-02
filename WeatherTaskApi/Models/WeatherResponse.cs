using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTaskApi.Models
{
    public class WeatherResponse
    {
        public Main Main { get; set; }
        public Coord Coord{ get; set; }
        public List<Weather> Weather { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
    }
    public class Coord
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
    }

}
