using CleanArch.Application.City.DTOs;
using CleanArch.Application.Weather.DTOs;
using CleanArch.Application.Weather.Mapper;
using CleanArch.Domain.CityAggregate.Repository;
using CleanArch.Domain.WeatherAggrigate.Repository;

namespace CleanArch.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly ICityRepository _cityRepository;
    private readonly IWeatherRepository _weatherRepository;
    private readonly HttpClient client;


    public WeatherService(ICityRepository cityRepositoryl, IWeatherRepository weatherRepository)
    {
        _cityRepository = cityRepositoryl;
        _weatherRepository = weatherRepository;
        client = new HttpClient();
    }

    public async Task<WeatherInformationDTO> GetWeather(string cityName)
    {
        var cityDTO = new CityDTO(cityName);
        var cityInformation = await _cityRepository.GetCityInformation(client, cityDTO.CityName);

        var weatherInformation = await _weatherRepository.GetWeather(client, cityInformation);
        var result = WeatherMapper.InformationToDTO(weatherInformation);

        return result;
    }
}
