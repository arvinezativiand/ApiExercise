using CleanArch.Application.Interfaces;
using CleanArch.Application.Weather;
using CleanArch.Domain.CityAggregate;
using CleanArch.Domain.WeatherAggrigate;
using Newtonsoft.Json;

namespace CleanArch.Infrastructure.City;

public class WeatherClient : IWeatherClient
{
    public string GetUri(MinimalCity city) => $"http://api.openweathermap.org/data/2.5/forecast?lat={city.lat}&lon={city.lon}&appid=6186dda957032731c69f5fb961490fde";

    public async Task<WeatherInformation> GetWeather(HttpClient Client, MinimalCity city)
    {
        var baseUri = Environment.GetEnvironmentVariable("BASE_WEATHER_URI");
        var apiKey = Environment.GetEnvironmentVariable("API_KEY");

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
