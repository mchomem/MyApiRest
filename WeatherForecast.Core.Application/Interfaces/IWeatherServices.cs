namespace WeatherForecast.Core.Application.Interfaces;

public interface IWeatherServices
{
    public Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(string cityName, string state);
    public Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordenates);
}
