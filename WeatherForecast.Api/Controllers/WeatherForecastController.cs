namespace WeatherForecast.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // TODO: criar regras de temperaturas para os sumários.
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherServices _weatherService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger
        , IWeatherServices weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastModel> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("city-coordinates")]
    public async Task<IActionResult> GetCityCoordinatesAsync([FromQuery] string cityName, [FromQuery] string state)
    {
        var result = await _weatherService.GetCityCoordinatesAsync(cityName, state);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Geocoding.Root>(result);
        _logger.LogInformation("City coordinates retrieved successfully for {CityName}, {State}", cityName.ToUpper(), state.ToUpper());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CoordinatesRequestDto coordenates)
    {
        var result = await _weatherService.GetWeatherAsync(coordenates);
        var response = new ApiResponse<Core.Application.Dtos.OpenMeteo.Root>(result);
        _logger.LogInformation("Weather data retrieved successfully for coordinates: {Latitude}, {Longitude}", coordenates.Latitude, coordenates.Longitude);
        return Ok(response);
    }
}
