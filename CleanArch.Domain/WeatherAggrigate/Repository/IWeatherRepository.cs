using CleanArch.Domain.CityAggregate;

namespace CleanArch.Domain.WeatherAggrigate.Repository;

public interface IWeatherRepository
{
    Task<WeatherInformation> GetWeather(HttpClient Client, MinimalCity CityInformation);
}
