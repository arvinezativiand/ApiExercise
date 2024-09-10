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


    public WeatherService(ICityClient cityClient, IWeatherClient weatherClient)
    {
        _cityClient = cityClient;
        _weatherClient = weatherClient;
        client = new HttpClient();
    }

    public async Task<WeatherResponseDTO> GetWeather(string cityName)
    {
        try
        {
            var cityDTO = new CityDTO(cityName);
            var cityInformation = await _cityClient.GetCityInformation(client, cityDTO.CityName);

            var weatherInformation = await _weatherClient.GetWeather(client, cityInformation);
            var result = WeatherMapper.InformationToDTO(weatherInformation);

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
