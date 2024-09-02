using EditedWeather.DTOs;
using EditedWeather.Entity.WeatherAggregate;

namespace EditedWeather.Services;

public interface IWeather
{
    Task<WeatherInformationDTO> GetWeather(string cityName);
}
