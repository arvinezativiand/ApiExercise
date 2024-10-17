using CleanArch.Application.Weather.DTOs;

namespace CleanArch.Application.Interfaces;

public interface ICache
{
    public void Set(string key, WeatherResponseDTO value);
    public WeatherResponseDTO Get(string key);
}
