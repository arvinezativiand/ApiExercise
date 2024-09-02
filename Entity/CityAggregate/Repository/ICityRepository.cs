using EditedWeather.DTOs;
using EditedWeather.Entity.City;


namespace EditedWeather.Entity.CityAggregate.Repository;

public interface ICityRepository
{
    public string Uri(string cityName);
    MinimalCity GetMinimalCity(CityInformation city);
    Task<MinimalCity> GetCityInformation(HttpClient Client, CityDTO cityDTO);
}
