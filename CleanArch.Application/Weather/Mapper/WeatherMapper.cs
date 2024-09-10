using CleanArch.Application.Weather.DTOs;
using CleanArch.Domain.WeatherAggrigate;

namespace CleanArch.Application.Weather.Mapper;

public class WeatherMapper
{
    public static WeatherResponseDTO InformationToDTO(WeatherInformation information)
    {
        return new WeatherResponseDTO()
        {
            cnt = information.cnt,
            cod = information.cod,
            message = information.message
        };
    }
}
