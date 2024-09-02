using EditedWeather.DTOs;
using EditedWeather.Entity.CityAggregate;

namespace EditedWeather.Entity.WeatherAggregate.Repository;
public interface IWeatherRepository
{
    Task<WeatherInformationDTO> GetWeather(HttpClient Client, MinimalCity CityInformation);
}
