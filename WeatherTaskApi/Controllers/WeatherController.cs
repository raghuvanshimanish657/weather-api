using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherTaskApi.Interfaces;

namespace WeatherTaskApi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            try{
                var weather = await _weatherService.GetCurrentWeatherAsync(city);
                return Ok(weather); 
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> Get5DayForecast([FromQuery] string city)
        {
            try{
                var forecast = await _weatherService.Get5DayForecastAsync(city);
                return Ok(forecast);
            }
            catch (Exception ex){
                return NotFound(ex.Message);
            }
        }

        [HttpGet("airquality")]
        public async Task<IActionResult> GetAirQuality([FromQuery] string city)
        {
            try
            {
                var airQuality = await _weatherService.GetAirQualityAsync(city);
                return Ok(airQuality);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("currentbypincode")]
        public async Task<IActionResult> GetCurrentWeatherByPincode([FromQuery] string pincode)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeatherByPincodeAsync(pincode);
                return Ok(weather);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}