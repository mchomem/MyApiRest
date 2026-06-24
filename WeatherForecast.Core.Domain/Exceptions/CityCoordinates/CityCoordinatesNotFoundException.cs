namespace WeatherForecast.Core.Domain.Exceptions.CityCoordinates;

public class CityCoordinatesNotFoundException : CityCoordinatesException
{
    public CityCoordinatesNotFoundException(string message = DefaultMessages.CityCoordinatesNotFoundException) : base(message) { }
}