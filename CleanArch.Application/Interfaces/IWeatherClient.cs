using CleanArch.Domain.CityAggregate;
using CleanArch.Domain.WeatherAggrigate;

namespace CleanArch.Application.Interfaces;

public interface IWeatherClient
{
    Task<WeatherInformation> GetWeather(HttpClient Client, MinimalCity CityInformation);
}
