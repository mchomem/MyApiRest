namespace WeatherForecast.Infrastructure.ExternalService.Clients;

public class OpenMeteoApiClient : IOpenMeteoApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly string _urlBase;
    private readonly string _urlBaseGeocoding;

    public OpenMeteoApiClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;
        _urlBase = _configuration.GetSection("ExternalServices:OpenMeteoApi:UrlBase").Value!;
        _urlBaseGeocoding = _configuration.GetSection("ExternalServices:OpenMeteoApi:UrlBaseGeocoding").Value!;
    }

    public async Task<AppOpenMeteoGeocodingDto.Root> GetCityCoordinatesAsync(AppCityDto.CityRequestDto cityRequest)
    {
        var response = await _httpClient.GetFromJsonAsync<InfraOpenMeteoGeocodingDto.Root>($"{_urlBaseGeocoding}/search?name={cityRequest.Name}");

        if (!string.IsNullOrEmpty(cityRequest.State))
        {
            response?.Results = response.Results?
                .Where(r => r.Admin2 != null && r.Admin2.Equals(cityRequest.Name, StringComparison.OrdinalIgnoreCase)
                       && r.Admin1.Equals(cityRequest.State, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        var rootDto = _mapper.Map<AppOpenMeteoGeocodingDto.Root>(response!);
        return rootDto;
    }

    public async Task<AppOpenMeteoDto.Root> GetWeatherAsync(AppCoordinatesDto.CoordinatesRequestDto coordinates)
    {
        var frequency = coordinates.Frequency.ToString().ToLower();
        var url = $"{_urlBase}/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&{frequency}=temperature_2m";
        var response = await _httpClient.GetFromJsonAsync<InfraOpenMeteoDto.Root>(url);
        var rootDto = _mapper.Map<AppOpenMeteoDto.Root>(response!);
        return rootDto;
    }
}
