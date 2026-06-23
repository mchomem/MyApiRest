namespace WeatherForecast.Core.Application.Dtos.OpenMeteo.Geocoding;

public class Root
{
    public List<Result>? Results { get; set; }

    public double GenerationtimeMs { get; set; }
}
