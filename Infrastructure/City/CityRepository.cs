using System.Net.Http;
using System.Text.Json;
using EditedWeather.Entity.City;
using EditedWeather.Entity.CityAggregate;
using EditedWeather.Entity.CityAggregate.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using EditedWeather.DTOs;

namespace EditedWeather.Infrastructure.City;

public class CityRepository : ICityRepository
{
    public string Uri(string cityName) =>
        $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&appid=6186dda957032731c69f5fb961490fde";

    public MinimalCity GetMinimalCity(CityInformation city) => new MinimalCity(city.lat, city.lon, city.name);
   
    
    public async Task<MinimalCity> GetCityInformation(HttpClient Client, CityDTO cityDTO)
    {
        var uri = Uri(cityDTO.CityName);
        var response = await Client.GetStringAsync(uri);

        var Jrespone = JsonConvert.DeserializeObject<List<CityInformation>>(response);

        if (Jrespone == null)
        {
            throw new ArgumentNullException();
        }

        var city = Jrespone[0];
        return new MinimalCity(city.lat, city.lon, cityDTO.CityName);
        
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
}
