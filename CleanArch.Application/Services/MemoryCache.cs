using CleanArch.Application.Interfaces;
using CleanArch.Application.Weather.DTOs;
using CleanArch.Application.Weather.Mapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CleanArch.Application.Services;

public class MemoryCache : ICache
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCache(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public void Set(string key, WeatherResponseDTO value)
    {
        var serializedValue = JsonConvert.SerializeObject(value);
        _memoryCache.Set(key, value);
    }
    public WeatherResponseDTO Get(string key)
    {
        return new WeatherResponseDTO();
    }
}
