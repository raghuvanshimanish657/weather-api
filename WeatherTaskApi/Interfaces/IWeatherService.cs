using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTaskApi.Models;

namespace WeatherTaskApi.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetCurrentWeatherAsync(string city);
        Task<ForecastResponse> Get5DayForecastAsync(string city);
        Task<AirQualityResponse> GetAirQualityAsync(string city);
        Task<WeatherResponse> GetCurrentWeatherByPincodeAsync(string pincode);
    }
}