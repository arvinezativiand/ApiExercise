using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Infrastructure.City;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Config;


public class ProjectConfig
{
    public static void Init(IServiceCollection services)
    {
        services.AddTransient<IWeatherService, WeatherService>();
        services.AddTransient<IWeatherClient, WeatherClient>();
        services.AddTransient<ICityClient, CityClient>();
    }
}

