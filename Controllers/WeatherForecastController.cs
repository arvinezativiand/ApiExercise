using CleanArch.Application.Services;
using CleanArch.Application.Weather.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private static IWeatherService _weather;
    public WeatherController(IWeatherService weather)
    {
        _weather = weather;
    }


    [HttpGet("{cityName}")]
    public async Task<WeatherInformationDTO> Weather(string cityName)
    {

        return await _weather.GetWeather(cityName);
    }
}

