using System.ComponentModel.DataAnnotations;

namespace EditedWeather.DTOs;

public class CityDTO
{
    [Required]
    public string CityName { get; private set; }

    public CityDTO(string cityName)
    {
        if (ValidationCityName(cityName))
        {
            CityName = cityName;
        }
        else
        {
            CityName = null;
        }
    }
    public bool ValidationCityName(string name)
    {
        if ((name == null) || name.Length < 2 || name.Length > 16)
            return false;

        return true;
    }
}
