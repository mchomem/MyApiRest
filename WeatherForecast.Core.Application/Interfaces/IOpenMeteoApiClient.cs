namespace WeatherForecast.Core.Application.Interfaces;

public interface IOpenMeteoApiClient
{
    Task<Root> GetWeatherAsync(double latitude, double longitude);
}