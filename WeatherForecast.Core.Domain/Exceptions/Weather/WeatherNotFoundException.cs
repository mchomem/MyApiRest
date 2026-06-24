namespace WeatherForecast.Core.Domain.Exceptions.Weather;

public class WeatherNotFoundException : WeatherException
{
    public WeatherNotFoundException(string message = DefaultMessages.WeatherNotFoundException) : base(message) { }
}