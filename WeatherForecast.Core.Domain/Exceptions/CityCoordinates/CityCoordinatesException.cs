namespace WeatherForecast.Core.Domain.Exceptions.CityCoordinates;

public class CityCoordinatesException : BusinessException
{
    public CityCoordinatesException(string message) : base(message) { }
}