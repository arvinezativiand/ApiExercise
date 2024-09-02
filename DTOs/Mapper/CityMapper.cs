using EditedWeather.Entity.WeatherAggregate;

namespace EditedWeather.DTOs.Mapper;

public class CityMapper
{
    public static CityDTO CityToDTO(City city)
    {
        return new CityDTO(city.name);
    }

    public static City DTOToCity(CityDTO city)
    {
        return new City()
        {
            name = city.CityName
        };
    }
}
