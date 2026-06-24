namespace WeatherForecast.Core.Domain.Constants;

public static class DefaultMessages
{
    public const string CoordenateInvalidLatitudeExcption = "O valor de latitude é inválido.";
    public const string CoordenateInvalidLongitudeExcption = "O valor de longitude é inválido.";

    public const string CityCoordinatesNotFoundException = "Não foi possível encontrar as coordenadas da cidade informada.";

    public const string WeatherNotFoundException = "Não foi possível obter os dados meteorológicos para a cidade informada.";
}