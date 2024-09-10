using CleanArch.Application.Interfaces;
using CleanArch.Application.Weather.DTOs;
using DotNetEnv;
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
    public async Task<WeatherResponseDTO> Weather(string cityName)
    {
        Env.Load();
        return await _weather.GetWeather(cityName);
    }
}

