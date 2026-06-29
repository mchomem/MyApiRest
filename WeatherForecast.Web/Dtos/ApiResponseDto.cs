namespace WeaterForecast.Web.Dtos;

public class ApiResponseDto<T> where T : class
{
    public T Data { get; set; } = default!;
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
