using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTaskApi.Models
{
    public class AirQualityResponse
    {
        public Coord Coord{ get; set; } 
        public List<AirQualityData> List { get; set; }
    }

    public class AirQualityData
    {
        public MainPollution Main { get; set; }
        public Pollutant Components { get; set; }
        public int Dt { get; set; }
    }

    public class MainPollution
    {
        public int Aqi { get; set; }
    }

    public class Pollutant
    {
        public double Co { get; set; }
        public double No { get; set; }
        public double No2 { get; set; }
        public double O3 { get; set; }
        public double So2 { get; set; }
        public double Pm2_5 { get; set; }
        public double Pm10 { get; set; }
        public double Nh3 { get; set; }
    }
}