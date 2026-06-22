namespace WeatherForecast.Core.Domain.Exceptions;

public class BusinessException : Exception
{
    protected BusinessException(string message) : base(message) { }
}