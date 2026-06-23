namespace WeatherForecast.Core.Application.Services;

public class WeatherService : IWeatherServices
{
    private readonly IOpenMeteoApiClient _openMeteoApiClient;
    private readonly IValidator<CoordinatesRequestDto> _validatorCoordinates;

    public WeatherService(IOpenMeteoApiClient openMeteoApiClient, IValidator<CoordinatesRequestDto> validatorCoordinates)
    {
        _openMeteoApiClient = openMeteoApiClient;
        _validatorCoordinates = validatorCoordinates;
    }

    public async Task<Dtos.OpenMeteo.Geocoding.Root> GetCityCoordinatesAsync(string cityName, string state)
    {
        var cityCoordinates = await _openMeteoApiClient.GetCityCoordinatesAsync(cityName, state);
        return cityCoordinates;
    }

    public async Task<Dtos.OpenMeteo.Root> GetWeatherAsync(CoordinatesRequestDto coordenates)
    {
        _validatorCoordinates.ValidateAndThrow(coordenates);
        var weatherData = await _openMeteoApiClient.GetWeatherAsync(coordenates);
        return weatherData;
    }
}
