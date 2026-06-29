namespace WeatherForecast.Web.Services;

public class WeatherForecastApiClient
{
    private readonly HttpClient _httpClient;

    public WeatherForecastApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponseDto> GetWeatherForecastAsync(CityRequestDto cityRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/weatherforecast/city-weather", cityRequest);
        response.EnsureSuccessStatusCode();

        var weatherForecast = await response.Content.ReadFromJsonAsync<ApiResponseDto<WeatherResponseDto>>();
        return weatherForecast?.Data!;
    }
}
