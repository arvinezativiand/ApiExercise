namespace CleanArch.Domain.CityAggregate.Repository;

public interface ICityRepository
{
    public string Uri(string cityName);
    MinimalCity GetMinimalCity(CityInformation city);
    Task<MinimalCity> GetCityInformation(HttpClient Client, string cityName);
}

