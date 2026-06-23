namespace WeatherForecast.Core.Application.Interfaces;

public interface IOpenMeteoApiClient
{
    Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(CityRequestDto cityRequest);
    Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordinates);
}