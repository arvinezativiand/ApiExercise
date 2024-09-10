using CleanArch.Domain.CityAggregate;

namespace CleanArch.Application.Interfaces;

public interface ICityClient
{
    public string Uri(string cityName);
    MinimalCity GetMinimalCity(CityInformation city);
    Task<MinimalCity> GetCityInformation(HttpClient Client, string cityName);
}
