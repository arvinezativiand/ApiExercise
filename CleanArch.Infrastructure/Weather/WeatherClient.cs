using CleanArch.Application.Interfaces;
using CleanArch.Application.Weather;
using CleanArch.Domain.CityAggregate;
using CleanArch.Domain.WeatherAggrigate;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CleanArch.Infrastructure.City;

public class WeatherClient : IWeatherClient
{
    private readonly IConfiguration _configuration;

    public WeatherClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<WeatherInformation> GetWeather(HttpClient Client, MinimalCity city)
    {
        var baseUri = _configuration.GetSection("EnvironmentVariables").GetSection("BaseWeatherUri").Value;
        var apiKey = _configuration.GetSection("EnvironmentVariables").GetSection("ApiKey").Value;

        var uri = $"{baseUri}?lat={city.lat}&lon={city.lon}&appid={apiKey}";
        var response = await Client.GetStringAsync(uri);

        var Jrespone = JsonConvert.DeserializeObject<WeatherInformation>(response);
        if (Jrespone == null)
        {
            throw new ArgumentNullException();
        }

        return Jrespone;
    }
}
