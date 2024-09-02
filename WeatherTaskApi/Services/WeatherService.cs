using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherTaskApi.Interfaces;
using WeatherTaskApi.Models;

namespace WeatherTaskApi.Services
{
    public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey="75f5d4887667fac91109e85fd4194401"

    public WeatherService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        //_apiKey = config["75f5d4887667fac91109e85fd4194401"];
    }

    public async Task<WeatherResponse> GetCurrentWeatherAsync(string city)
    {
        var response = await _httpClient.GetAsync($"weather?q={city}&appid={_apiKey}&units=metric");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<WeatherResponse>(content);
    }

    public async Task<WeatherResponse> GetCurrentWeatherByPincodeAsync(string pincode)
    {
        var response = await _httpClient.GetAsync($"weather?zip={pincode},IN&appid={_apiKey}&units=metric");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<WeatherResponse>(content);
    }

    public async Task<ForecastResponse> Get5DayForecastAsync(string city)
    {
        var response = await _httpClient.GetAsync($"forecast?q={city}&appid={_apiKey}&units=metric");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ForecastResponse>(content);
    }

    public async Task<AirQualityResponse> GetAirQualityAsync(string city)
    {
        var wresponse = await GetCurrentWeatherAsync(city);
        var response = await _httpClient.GetAsync($"air_pollution?lat={wresponse.Coord.Lat}&lon={wresponse.Coord.Lon}&appid={_apiKey}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AirQualityResponse>(content);
    }
}
}