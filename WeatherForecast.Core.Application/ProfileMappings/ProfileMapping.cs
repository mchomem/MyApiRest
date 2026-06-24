namespace WeatherForecast.Core.Application.ProfileMappings;

public static class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Weather, WeatherResponseDto>().TwoWays();
    }
}