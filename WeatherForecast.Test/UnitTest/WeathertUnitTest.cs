namespace WeatherForecast.Test.UnitTest;

public class WeathertUnitTest
{
    [Fact]
    public void ConvertToFahrenheit_TemperatureCelsius_ReturnsTemperatureFahrenheit()
    {
        // Arrange
        var cityName = "New York";
        var state = "NY";
        var country = "USA";
        var latitude = 40.7128;
        var longitude = -74.0060;
        var timezone = "Eastern Standard Time";
        var temperatureCelsius = 25.0;

        var weather = new Weather(cityName, state, country, latitude, longitude, timezone, temperatureCelsius);

        // Act
        weather.ConvertToFahrenheit();

        // Assert
        Assert.True(weather.TemperatureFahrenheit == (weather.TemperatureCelsius * 9 / 5) + 32);
    }

    [Theory]
    [InlineData(-1, "Congelante")]
    [InlineData(0, "Muito Frio")]
    [InlineData(10, "Muito Frio")]
    [InlineData(11, "Frio")]
    [InlineData(18, "Frio")]
    [InlineData(19, "Agradável")]
    [InlineData(24, "Agradável")]
    [InlineData(25, "Quente")]
    [InlineData(30, "Quente")]
    [InlineData(31, "Muito Quente")]
    [InlineData(40, "Muito Quente")]
    [InlineData(41, "Perigoso")]
    public void GetSummary_TemperatureCelsius_ReturnsExpectedSummary(int temperatureCelsius, string expectedSummary)
    {
        // Arrange
        var cityName = "New York";
        var state = "NY";
        var country = "USA";
        var latitude = 40.7128;
        var longitude = -74.0060;
        var timezone = "Eastern Standard Time";

        var weather = new Weather(cityName, state, country, latitude, longitude, timezone, temperatureCelsius);

        // Act
        weather.GetSummary();

        // Assert
        Assert.Equal(expectedSummary, weather.Summary);
    }
}
