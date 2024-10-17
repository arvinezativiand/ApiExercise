using CleanArch.Application.City.DTOs;
using CleanArch.Application.Weather.DTOs;
using CleanArch.Application.Weather.Mapper;
using CleanArch.Application.Interfaces;

namespace CleanArch.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly ICityClient _cityClient;
    private readonly IWeatherClient _weatherClient;
    private readonly HttpClient client;
    private readonly ICache _cache;


    public WeatherService(ICityClient cityClient, IWeatherClient weatherClient, ICache cache)
    {
        _cityClient = cityClient;
        _weatherClient = weatherClient;
        _cache = cache;
        client = new HttpClient();
    }

    public async Task<WeatherResponseDTO> GetWeather(string cityName)
    {
        try
        {
            var cityDTO = new CityDTO(cityName);
            var result = _cache.Get(cityDTO.CityName);
            if(result != null)
            {
                return result;
            }
            var cityInformation = await _cityClient.GetCityInformation(client, cityDTO.CityName);

            var weatherInformation = await _weatherClient.GetWeather(client, cityInformation);
            result = WeatherMapper.InformationToDTO(weatherInformation);

            _cache.Set($"{cityDTO.CityName}", result);
            return result;
        }
        catch
        {
            return new WeatherResponseDTO()
            {
                cod = "Error",
                cnt = -1,
                message = 500
            };
        }
    }
}
