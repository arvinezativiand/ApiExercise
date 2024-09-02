using EditedWeather.DTOs;
using EditedWeather.Entity.CityAggregate.Repository;
using EditedWeather.Entity.WeatherAggregate.Repository;

namespace EditedWeather.Services;
public class Weather : IWeather
{
    private readonly ICityRepository _cityRepository;
    private readonly IWeatherRepository _weatherRepository;
    private readonly HttpClient client;


    public Weather(ICityRepository cityRepositoryl, IWeatherRepository weatherRepository)
    {
        _cityRepository = cityRepositoryl;
        _weatherRepository = weatherRepository;
        client = new HttpClient();
    }

    public async Task<WeatherInformationDTO> GetWeather(string cityName)
    {
        var cityDTO = new CityDTO(cityName);
        var cityInformation = await _cityRepository.GetCityInformation(client, cityDTO);
        var result = await _weatherRepository.GetWeather(client, cityInformation);

        return result;
    }
}
