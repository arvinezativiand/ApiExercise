using Newtonsoft.Json;
using EditedWeather.DTOs;
using EditedWeather.DTOs.Mapper;
using EditedWeather.Entity.CityAggregate;
using EditedWeather.Entity.WeatherAggregate;
using EditedWeather.Entity.WeatherAggregate.Repository;

namespace EditedWeather.Infrastructure.Weather;
public class WeatherRepository : IWeatherRepository
{
    public string GetUri(MinimalCity city) => $"http://api.openweathermap.org/data/2.5/forecast?lat={city.lat}&lon={city.lon}&appid=6186dda957032731c69f5fb961490fde";

    public async Task<WeatherInformationDTO> GetWeather(HttpClient Client, MinimalCity CityInformation)
    {
        var uri = GetUri(CityInformation);
        var response = await Client.GetStringAsync(uri);

        var Jrespone = JsonConvert.DeserializeObject<WeatherInformation>(response);
        if (Jrespone == null)
        {
            throw new ArgumentNullException();
        }
        return WeatherMapper.InformationToDTO(Jrespone);
    }
}
