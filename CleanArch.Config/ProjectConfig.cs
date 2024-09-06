using CleanArch.Application.Services;
using CleanArch.Domain.CityAggregate.Repository;
using CleanArch.Domain.WeatherAggrigate.Repository;
using CleanArch.Infrastructure.City;
using CleanArch.Infrastructure.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Config;


public class ProjectConfig
{
    public static void Init(IServiceCollection services)
    {
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IWeatherRepository, WeatherRepository>();
        services.AddTransient<IWeatherService, WeatherService>();
    }
}

