namespace WeatherForecast.Core.Domain.Exceptions.Coordenate;

public class CoordenatesInvalidLongitudeValueException : BusinessException
{
    public CoordenatesInvalidLongitudeValueException(string message = DefaultMessages.CoordenateInvalidLongitudeExcption) : base(message) {}
}
