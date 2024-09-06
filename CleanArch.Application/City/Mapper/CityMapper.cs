using CleanArch.Application.City.DTOs;
using CleanArch.Domain.CityAggregate;

namespace CleanArch.Application.City.Mapper;

public class CityMapper
{
    public static CityDTO CityToDTO(CityInformation city)
    {
        return new CityDTO(city.name);
    }

    public static CityInformation DTOToCity(CityDTO city)
    {
        return new CityInformation()
        {
            name = city.CityName
        };
    }
}

