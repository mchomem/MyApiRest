namespace WeatherForecast.Infrastructure.ExternalService.DTOs.OpenMeteo.Geocoding;

public class Root
{
    [JsonPropertyName("results")]
    public List<Result>? Results { get; set; }

    [JsonPropertyName("generationtime_ms")]
    public double GenerationtimeMs { get; set; }
}