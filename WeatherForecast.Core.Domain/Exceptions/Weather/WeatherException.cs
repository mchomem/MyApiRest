namespace WeatherForecast.Core.Domain.Exceptions.Weather;

public class WeatherException : BusinessException
{
    public WeatherException(string message) : base(message) { }
}