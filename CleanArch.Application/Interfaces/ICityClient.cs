using CleanArch.Domain.CityAggregate;

namespace CleanArch.Application.Interfaces;

public interface ICityClient
{
    MinimalCity GetMinimalCity(CityInformation city);
    Task<MinimalCity> GetCityInformation(HttpClient Client, string cityName);
}
