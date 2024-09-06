using CleanArch.Application.Weather.DTOs;

namespace CleanArch.Application.Services;

public interface IWeatherService
{
    Task<WeatherInformationDTO> GetWeather(string cityName);

}
