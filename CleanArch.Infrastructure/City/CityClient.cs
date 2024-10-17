using CleanArch.Application.City;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.CityAggregate;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CleanArch.Infrastructure.City;

public class CityClient : ICityClient
{    
    private readonly IConfiguration _configuration;
    public CityClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MinimalCity GetMinimalCity(CityInformation city) => new MinimalCity(city.lat, city.lon, city.name);

    public async Task<MinimalCity> GetCityInformation(HttpClient Client, string cityName)
    {
        var baseUri = _configuration.GetSection("EnvironmentVariables").GetSection("BaseCityUri").Value;
        var apiKey = _configuration.GetSection("EnvironmentVariables").GetSection("ApiKey").Value;

        var uri = $"{baseUri}?q={cityName}&appid={apiKey}";
        var response = await Client.GetStringAsync(uri);

        var Jrespone = JsonConvert.DeserializeObject<List<CityInformation>>(response);
        if (Jrespone == null)
        {
            throw new ArgumentNullException();
        }

        var city = Jrespone[0];
        return new MinimalCity(city.lat, city.lon, cityName);
    }
}
