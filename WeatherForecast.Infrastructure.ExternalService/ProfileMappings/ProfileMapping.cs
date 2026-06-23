namespace WeatherForecast.Infrastructure.ExternalService.ProfileMappings;

public class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<InfraOpenMeteoDto.Root, AppOpenMeteoDto.Root>().TwoWays();
        config.NewConfig<InfraOpenMeteoDto.Hourly, AppOpenMeteoDto.Hourly>().TwoWays();
        config.NewConfig<InfraOpenMeteoDto.HourlyUnits, AppOpenMeteoDto.HourlyUnits>().TwoWays();
        config.NewConfig<InfraOpenMeteoGeocodingDto.Root, AppOpenMeteoGeocodingDto.Root>().TwoWays();
        config.NewConfig<InfraOpenMeteoGeocodingDto.Result, AppOpenMeteoGeocodingDto.Result>().TwoWays();
    }
}
