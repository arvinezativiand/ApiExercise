using EditedWeather.Entity.WeatherAggregate;

namespace EditedWeather.DTOs.Mapper;
public class WeatherMapper
{
    public static WeatherInformationDTO InformationToDTO(WeatherInformation information)
    {
        return new WeatherInformationDTO()
        {
            cnt = information.cnt,
            cod = information.cod,
            message = information.message
        };
    }
}
