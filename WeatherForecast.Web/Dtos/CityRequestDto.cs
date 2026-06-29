namespace WeatherForecast.Web.Dtos;

public sealed class CityRequestDto
{
    public string Name { get; set; } = string.Empty;

    // TODO: implementar um Enum ou uma string constante contendo o valor por extenso do estado, para evitar inconsistências.
    public string State { get; set; } = string.Empty;
}
