namespace WeatherForecast.Core.Application.Interfaces;

public interface IOpenMeteoApiClient
{
    Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(string cityName, string state);
    Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordinates);
}