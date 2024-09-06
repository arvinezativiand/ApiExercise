namespace CleanArch.Domain.CityAggregate;

public class MinimalCity
{
    public MinimalCity(double lat, double lon, string cityName)
    {
        this.lat = lat;
        this.lon = lon;
        CityName = cityName;
    }
    public string CityName { get; private set; }
    public double lat { get; private set; }
    public double lon { get; private set; }
}

