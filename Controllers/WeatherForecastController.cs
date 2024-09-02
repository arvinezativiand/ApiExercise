using Microsoft.AspNetCore.Mvc;
using EditedWeather.DTOs;
using EditedWeather.Services;

namespace EditedWeather.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private static IWeather _weather;
    public WeatherController(IWeather weather)
    {
        _weather = weather;
    }


    [HttpGet("{cityName}")]
    public async Task<WeatherInformationDTO> Weather(string cityName)
    {

        return await _weather.GetWeather(cityName);
    }
}
