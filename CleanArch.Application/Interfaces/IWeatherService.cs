using CleanArch.Application.Weather.DTOs;

namespace CleanArch.Application.Interfaces;

public interface IWeatherService
{
    Task<WeatherResponseDTO> GetWeather(string cityName);
}
